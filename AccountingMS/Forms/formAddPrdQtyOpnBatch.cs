using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formAddPrdQtyOpnBatch : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        accountingEntities db = new accountingEntities();
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblProduct clsTbProduct = new ClsTblProduct();
        ClsTblGroupStr clsTbGroupStr = new ClsTblGroupStr();
        ClsTblPrdPriceMeasurment clsTbPrdMsur = new ClsTblPrdPriceMeasurment();
        ClsTblProductQtyOpn clsTbPrdQuanOpn;
        ClsTblBarcode clsTbBarcode;
        List<tblProduct> tbProductList;
        List<ClsProductQuantList> prdQtyList;

        private readonly ucStoreProducts _ucStoreProducts;
        private string saveMssg;
        private short strId = MySetting.DefaultSetting.defaultStrId;

        public formAddPrdQtyOpnBatch(ucStoreProducts ucStoreProducts)
        {
            Program.Localization();
            InitializeComponent();
            InitData();
            InitObjects();
            _ucStoreProducts = ucStoreProducts;

            gridView1.CustomRowCellEditForEditing += GridView1_CustomRowCellEditForEditing;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
            gridView1.FocusedRowChanged += GridView1_FocusedRowChanged;
            teGroupStr.EditValueChanged += TeGroupStr_EditValueChanged;
            rpLookUpEditPrdMsur.EditValueChanged += RpLookUpEditPrdMsur_EditValueChanged;
        }

        private void InitObjects()
        {
            this.clsTbPrdQuanOpn = new ClsTblProductQtyOpn();
            this.clsTbBarcode = new ClsTblBarcode();
        }

        private void InitData()
        {
            this.clsTbGroupStr.GroupNoLookkUpEdit(teGroupStr);
            teStoreDate.EditValue = DateTime.Now;
        }

        private void GridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "qtyPrdMsurId")
                e.RepositoryItem = rpLookUpEditPrdMsur;
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "qtyPrdId")
                e.DisplayText = (!MySetting.GetPrivateSetting.LangEng) ? clsTbProduct.GetPrdNameById((int)e.Value) : clsTbProduct.GetPrdNameEnById((int)e.Value);
            else if (e.Column.FieldName == "qtyPrdMsurId")
                e.DisplayText = clsTbPrdMsur.GetPrdPriceMsurNameById(Convert.ToInt32(e.Value));
        }

        private void GridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            tblPrdPriceMeasurmentBindingSource.DataSource = this.clsTbPrdMsur.GetPrdPriceMsurListByPrdId(Convert.ToInt32(gridView1.GetFocusedRowCellValue(colqtyPrdId)));
        }

        private void RpLookUpEditPrdMsur_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;

            gridView1.SetFocusedRowCellValue(colqtyPrice, editor.GetColumnValue("ppmPrice"));
            gridView1.SetFocusedRowCellValue(colprdSalePrice, editor.GetColumnValue("ppmSalePrice"));
            gridView1.SetFocusedRowCellValue(colprdBarcodeNo, editor.GetColumnValue("ppmBarcode1"));
        }

        private void TeGroupStr_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;

            InitProductQtyOpnData(Convert.ToInt32(editor.GetColumnValue("id")));
        }

        private void InitProductQtyOpnData(int grpId)
        {
            this.tbProductList = this.clsTbProduct.GetTblProductListByGrpId(grpId);
            InitProductQtyOpnList();
        }

        private void InitProductQtyOpnList()
        {
            List<tblProductQtyOpn> tbPrdQtyOpnList = new List<tblProductQtyOpn>();
            this.prdQtyList = new List<ClsProductQuantList>();

            foreach (var tbProduct in this.tbProductList)
            {
                tblPrdPriceMeasurment tbPrdMsur = this.clsTbPrdMsur.GetPrdPriceMsurUnit1ObjectByPrdId(tbProduct.id);
                if (tbPrdMsur == null) continue;
                if (this.clsTbPrdQuanOpn.IsPrdQuanOpnFoundByPrdId(tbProduct.id)) continue;

                tbPrdQtyOpnList.Add(new tblProductQtyOpn()
                {
                    qtyPrdId = tbProduct.id,
                    qtyPrdMsurId = tbPrdMsur.ppmId,
                    //prdBarcodeNo = tbPrdMsur.ppmBarcode1,
                    prdBarcodeNo = this.clsTbBarcode.GetFirstBarcodeByPrdMsurId(tbPrdMsur.ppmId),
                    qtyPrice = Convert.ToDouble(tbPrdMsur.ppmPrice),
                    prdSalePrice = clsTbPrdMsur.GetppmSalePrice(tbProduct.prdPriceTax,tbPrdMsur),
                });
            }
            tblProductQtyOpnBindingSource.DataSource = tbPrdQtyOpnList;
            bsCount.Caption = (!MySetting.GetPrivateSetting.LangEng) ? "العدد : " : "RECORDS: ";
            bsCount.Caption += tblProductQtyOpnBindingSource.Count;
        }

        private bool SaveData()
        {
            if (!dxValidationProvider1.Validate()) return false;
            if (!SaveQuantity()) return false;
            //if (!this.clsPrdQtyOpr.AddPrdQuantity(this.prdQtyList)) return false;
            //if (!this.clsPrdPriceQuanOpr.AddNewPrdQuantity(this.prdQtyList)) return false;

            this.saveMssg = (!MySetting.GetPrivateSetting.LangEng) ? "الأرصدة الإفتتاحية" : "opening quantities";

            return SaveDB();
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!SaveData()) return;

            _ucStoreProducts.FlyDialogIsNew = true;
            _ucStoreProducts.FlyDialogMssg = this.saveMssg;
            DialogResult = DialogResult.OK;
        }

        private void bbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!SaveData()) return;

            tblProductQtyOpnBindingSource.DataSource = new List<tblProductQtyOpn>();
            teGroupStr.EditValue = 0;
            flyDialog.ShowDialogForm(this, this.saveMssg);

            InitObjects();
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private bool SaveQuantity()
        {
            ChangeFocus();
            gridView1.UpdateCurrentRow();
            this.prdQtyList = new List<ClsProductQuantList>();

            for (short i = 0; i < gridView1.DataRowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, colqtyPrdId) == null || gridView1.GetRowCellValue(i, colqtyPrdMsurId) == null) continue;
                tblProductQtyOpn tbPrdQtyOpn = gridView1.GetRow(i) as tblProductQtyOpn;
                if (tbPrdQtyOpn?.qtyQuantity == 0) continue;

                tbPrdQtyOpn.qtyStrId = this.strId;
                tbPrdQtyOpn.qtyDate = Convert.ToDateTime(teStoreDate.EditValue).Date;
                tbPrdQtyOpn.qtyBranchId = Session.CurBranch.brnId;
                tbPrdQtyOpn.qtyStatus = 1;
                db.tblProductQtyOpns.Add(tbPrdQtyOpn);

                AddProductQtyList(tbPrdQtyOpn);
                SaveGroupTblAsset(tbPrdQtyOpn);
            }
            return true;
        }

        private void AddProductQtyList(tblProductQtyOpn tbPrdQtyOpn)
        {
            this.prdQtyList.Add(new ClsProductQuantList()
            {
                prdId = tbPrdQtyOpn.qtyPrdId,
                prdStrId = this.strId,
                prdPrice = tbPrdQtyOpn.qtyPrice,
                prdPriceMsurId = tbPrdQtyOpn.qtyPrdMsurId,
                prdQuantity = tbPrdQtyOpn.qtyQuantity
            });
        }

        private void SaveGroupTblAsset(tblProductQtyOpn tbPrdtQtyOpn)
        {
            tblAsset tbAsset = new tblAsset()
            {
                asEntId = tbPrdtQtyOpn.qtyPrdMsurId,
                asAccNo = this.clsTbGroupStr.GetGroupAccNoById(Convert.ToInt32(teGroupStr.EditValue)),
                asAccName = this.clsTbGroupStr.GetGroupNameById(Convert.ToInt32(teGroupStr.EditValue)),
                asDebit = (Convert.ToDouble(tbPrdtQtyOpn.qtyQuantity) * tbPrdtQtyOpn.qtyPrice),
                asDate = tbPrdtQtyOpn.qtyDate,
                asBrnId = Session.CurBranch.brnId,
                asUserId = Session.CurrentUser.id,
                asView = 1,
                asStatus = 10
            };
            db.tblAssets.Add(tbAsset);
        }

        private void ChangeFocus()
        {
            if (teGroupStr.ContainsFocus)
                teStoreDate.Focus();
            else
                teGroupStr.Focus();
        }



        private bool SaveDB()
        {
            return ClsSaveDB.Save(db, LogHelper.GetLogger());
        }
    }
}