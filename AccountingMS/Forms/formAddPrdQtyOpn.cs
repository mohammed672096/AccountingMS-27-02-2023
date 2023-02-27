using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formAddPrdQtyOpn : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        accountingEntities db = new accountingEntities();
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblProductQtyOpn clsTbPrdQtyOpn;
        ClsTblProduct clsTbProduct;
        ClsTblPrdPriceMeasurment clsTbPrdMsur;
        ClsTblStore clsTbStore;
        ClsTblGroupStr clsTbGroupStr;
        tblProductQtyOpn tbProuctQtyOpn;
        ClsProductQuantList prdQty;
        List<ClsProductQuantList> prdQtyList;
        tblPrdPriceMeasurment tbPrdMsur;

        private readonly ucStoreProducts _ucStoreProducts;
        private bool isNew;
        private string saveMssg;
        private double qtyOld;
        private int groupNo;
        public formAddPrdQtyOpn(ucStoreProducts ucStoreProduct, tblProductQtyOpn obj = null)
        {
            Program.Localization();
            InitializeComponent();
            InitData(obj);
            _ucStoreProducts = ucStoreProduct;

            this.Load += FormAddPrdQtyOpn_Load;
            qtyPrdIdTextEdit.EditValueChanged += QtyPrdIdTextEdit_EditValueChanged;
            searchLookUpEdit1View.CustomColumnDisplayText += SearchLookUpEdit1View_CustomColumnDisplayText;
        }
        private async void FormAddPrdQtyOpn_Load(object sender, EventArgs e)
        {
            this.flyDialog.WaitForm(this, 1);
            await InitObjectsAsync();
            InitBindingSourceData();
            this.flyDialog.WaitForm(this, 0);
            if (!this.isNew) InitMsurData(this.tbProuctQtyOpn.qtyPrdId, this.tbProuctQtyOpn.qtyPrdMsurId);
            qtyPrdMsurIdTextEdit.EditValueChanged += QtyPrdMsurIdTextEdit_EditValueChanged;
        }
        private void InitMsurData(int prdId, int qtyPrdMsurId)
        {
            tblPrdPriceMeasurmentBindingSource.DataSource = this.clsTbPrdMsur.GetPrdPriceMsurListByPrdId(prdId);

            qtyPrdMsurIdTextEdit.EditValue = qtyPrdMsurId;
            if (tblPrdPriceMeasurmentBindingSource.DataSource != null && qtyPriceTextEdit.EditValue == null)
            {
                var list = tblPrdPriceMeasurmentBindingSource.DataSource as System.Collections.Generic.List<AccountingMS.tblPrdPriceMeasurment>;
                qtyPriceTextEdit.EditValue = list.SingleOrDefault(x => x.ppmId == qtyPrdMsurId)?.ppmPrice;


            }
            if (this.isNew)
                qtyQuantityTextEdit.EditValue = 1;
        }

        private void QtyPrdMsurIdTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null || Convert.ToInt32(editor.EditValue) == 0) return;

            var tbPrdMsur = editor.GetSelectedDataRow() as tblPrdPriceMeasurment;
            if (tbPrdMsur == null) return;

            qtyPriceTextEdit.EditValue = tbPrdMsur?.ppmPrice;

            InitMsurData(Convert.ToInt32(qtyPrdIdTextEdit.EditValue), Convert.ToInt32(qtyPrdMsurIdTextEdit.EditValue));
        }

        private async Task InitObjectsAsync()
        {
            ClsTblProductQunatity clsTbPrdQuan = null;
            ClsTblPrdPriceQuan clsTbPrdPriceQuan = null;

            IList<Task> taskList = new List<Task>();
            taskList.Add(Task.Run(() => this.clsTbPrdQtyOpn = new ClsTblProductQtyOpn()));
            taskList.Add(Task.Run(() => this.clsTbProduct = new ClsTblProduct()));
            taskList.Add(Task.Run(() => this.clsTbPrdMsur = new ClsTblPrdPriceMeasurment()));
            taskList.Add(Task.Run(() => this.clsTbGroupStr = new ClsTblGroupStr()));
            taskList.Add(Task.Run(() => this.clsTbStore = new ClsTblStore()));
            taskList.Add(Task.Run(() => clsTbPrdQuan = new ClsTblProductQunatity()));
            taskList.Add(Task.Run(() => clsTbPrdPriceQuan = new ClsTblPrdPriceQuan()));
            await Task.WhenAll(taskList);
        }
        private void InitData(tblProductQtyOpn obj = null)
        {
            if (obj == null)
            {
                this.isNew = true;
                this.clsTbGroupStr = new ClsTblGroupStr();
                bbiSaveAndNew.Visibility = BarItemVisibility.Always;
                InitNewObject();
            }
            else
            {
                this.isNew = false;
                this.qtyOld = obj.qtyQuantity;
                this.tbProuctQtyOpn = obj;

                //InitMsurData(obj.qtyPrdId);
                tblProductQtyOpnBindingSource.DataSource = this.tbProuctQtyOpn;
                //  db.tblProductQtyOpns.Attach(tblProductQtyOpnBindingSource.Current as tblProductQtyOpn);

                DisableMainEditors();
                //if (new ClsTblSupplySub().CheckPrdMsur(obj.qtyPrdMsurId)) DisableSubEditors();
            }
        }
        private void InitNewObject()
        {
            this.prdQtyList = new List<ClsProductQuantList>();
            this.tbProuctQtyOpn = new tblProductQtyOpn()
            {
                qtyDate = DateTime.Now,
                qtyBranchId = Session.CurBranch.brnId,
                qtyStatus = 1
            };
            tblProductQtyOpnBindingSource.DataSource = this.tbProuctQtyOpn;
            ///db.tblProductQtyOpns.Add(tblProductQtyOpnBindingSource.Current as tblProductQtyOpn);
        }

        private void InitBindingSourceData()
        {
            tblProductBindingSource.DataSource = this.clsTbProduct.GetProductList;
        }

        private void SearchLookUpEdit1View_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            GridView view = sender as GridView;

            if (view == null) return;
            int prdId = Convert.ToInt32(view.GetListSourceRowCellValue(e.ListSourceRowIndex, colid));
            if (e.Column.Name == "colprdStrNo")
                e.DisplayText = this.clsTbStore.GetStoreNameByProductID(Convert.ToInt32(e.Value));
            else if (e.Column.FieldName == "prdGrpNo")
                e.DisplayText = this.clsTbGroupStr.GetGroupNameById(Convert.ToInt32(e.Value));
            else if (e.Column.FieldName == colsupMusrName.FieldName)
            {
                using (accountingEntities db3 = new accountingEntities())
                {
                    var gg = db3.tblPrdPriceMeasurments.FirstOrDefault(m => m.ppmPrdId == prdId);
                    if (gg != null) e.DisplayText = gg.ppmMsurName;

                }
            }
        }

        private void repItemTxtEditBarcodeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            TextEdit editor = sender as TextEdit;
            if (editor?.EditValue == null) return;

            string barcodeNo = editor.Text;
            editor.EditValue = null;

            if (!ValidateBarcodeNo(barcodeNo)) return;
            if (IsPrdQuanOpnFound(barcodeNo)) return;

            qtyPrdIdTextEdit.EditValue = this.tbPrdMsur?.ppmPrdId;
        }

        private bool ValidateBarcodeNo(string barcodeNo)
        {
            bool isValid = this.clsTbPrdMsur.IsBarcodeNoFound(barcodeNo);
            if (!isValid) ClsXtraMssgBox.ShowError("عذراُ، رقم الباركود غير موجود!");

            return isValid;
        }

        private bool IsPrdQuanOpnFound(string barcodeNo)
        {
            var tbPrdMsur = this.clsTbPrdMsur.GetPrdPriceMsurObjByBarcodeNo(barcodeNo);
            if (tbPrdMsur == null) return false;

            bool isFound = this.clsTbPrdQtyOpn.IsPrdQuanOpnFoundByMsurId(tbPrdMsur.ppmId);
            if (isFound) ClsXtraMssgBox.ShowError(PrdQuanFoundMssg());

            this.tbPrdMsur = tbPrdMsur;
            return isFound;
        }

        private void QtyPrdIdTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit editor = sender as SearchLookUpEdit;

            if (!this.isNew) return;
            if (editor?.EditValue == null || Convert.ToInt32(editor.EditValue) == 0) return;

            this.groupNo = Convert.ToInt32(editor.Properties.View.GetFocusedRowCellValue("prdGrpNo"));
            this.tbProuctQtyOpn.qtyPrdId = Convert.ToInt32(qtyPrdIdTextEdit.EditValue);

            InitMsurData(Convert.ToInt32(qtyPrdIdTextEdit.EditValue), tbProuctQtyOpn.qtyPrdMsurId);
        }


        private bool SaveProductQtyOpn()
        {
            tblProductQtyOpn productQtyOpn = tblProductQtyOpnBindingSource.Current as tblProductQtyOpn;
            productQtyOpn.qtyStrId = MySetting.DefaultSetting.defaultStrId;

            using (accountingEntities db = new accountingEntities())
            {
                if (productQtyOpn.qtyId == 0)
                    db.tblProductQtyOpns.Add(productQtyOpn);
                else
                {
                    var Baseitem = db.tblProductQtyOpns.Find(productQtyOpn.qtyId);
                    db.Entry(Baseitem).CurrentValues.SetValues(productQtyOpn);
                }
                db.SaveChanges();
                return true;

            }
            return false;
        }
        private bool SaveData()
        {
            if (!dxValidationProvider1.Validate()) return false;

            if (!CheckPrdQtyOpn()) return false;
            //if (!SaveQuantity()) return false;
            if (!SaveProductQtyOpn()) return false;
            if (!SaveGroupTblAsset()) return false;

            this.saveMssg = (!MySetting.GetPrivateSetting.LangEng) ? "الرصيد الإفتتاحي للصنف : " : "Opening quantity for product : ";
            this.saveMssg += qtyPrdIdTextEdit.Properties.GetDisplayText(qtyPrdIdTextEdit.EditValue);
            return SaveDB();
        }

        private void bbiSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (!SaveData())
            //{
            //    ClsPrdQuantityOperations.CalculateProductQty(this.tbProuctQtyOpn.qtyPrdId);
            //    return;
            //}
            if (!SaveData()) return;

            _ucStoreProducts.FlyDialogIsNew = this.isNew;
            _ucStoreProducts.FlyDialogMssg = this.saveMssg;
            DialogResult = DialogResult.OK;
        }

        private void bbiSaveAndNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!SaveData()) return;

            this.isNew = true;
            flyDialog.ShowDialogFormBelowRIbbon(this, ribbonControl1, this.saveMssg);

            this.clsTbPrdQtyOpn = new ClsTblProductQtyOpn();
            InitNewObject();
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private bool CheckPrdQtyOpn()
        {
            ChangeFoucs();
            if (!this.isNew) return true;
            if (int.TryParse(qtyPrdMsurIdTextEdit.EditValue?.ToString(), out int id))
            {
                if (this.clsTbPrdQtyOpn.IsPrdQuanOpnFoundByMsurId(id))
                {
                    XtraMessageBox.Show(PrdQuanFoundMssg());
                    return false;
                }
            }
            else return false;

            return true;
        }

        private string PrdQuanFoundMssg()
        {
            return (!MySetting.GetPrivateSetting.LangEng) ? "عذرا تم إضافة رصيد إفتتاحي للصنف مسبقا!" : "Sorry, product already has opening quantity";
        }

        private void InitPrdQtyData()
        {
            this.prdQty = new ClsProductQuantList()
            {
                prdId = Convert.ToInt32(qtyPrdIdTextEdit.EditValue),
                prdStrId = MySetting.DefaultSetting.defaultStrId,
                prdPriceMsurId = Convert.ToInt32(qtyPrdMsurIdTextEdit.EditValue),
                prdPrice = Convert.ToDouble(qtyPriceTextEdit.EditValue),
                prdQuantity = Convert.ToDouble(qtyQuantityTextEdit.EditValue)
            };
        }

        //private bool SaveQuantity()
        //{
        //    InitPrdQtyData();

        //    if (this.isNew)
        //        if (SaveNewQuantity() && this.clsPrdPriceQuanOpr.AddNewPrdQuantity(this.prdQtyList))
        //        {
        //            return true;
        //        }
        //        else return false;
        //    else
        //    {
        //        if (SaveUpdateQuantity(out bool isIncrease))
        //            if (isIncrease)
        //            {
        //                return this.clsPrdPriceQuanOpr.AddNewPrdQuantity(this.prdQtyList);
        //            }
        //            else
        //            {
        //                return this.clsPrdPriceQuanOpr.DeductPrdQuantity(this.prdQtyList);
        //            }
        //        else return false;
        //    }
        //}

        //private bool SaveNewQuantity()
        //{
        //    this.prdQtyList.Add(this.prdQty);

        //    return this.clsPrdQuanOpr.AddPrdQuantity(this.prdQtyList);
        //}

        //private bool SaveUpdateQuantity(out bool isIncrease)
        //{
        //    this.prdQtyList = new List<ClsProductQuantList>();
        //    this.prdQty.prdQuantity -= this.qtyOld;

        //    if (this.prdQty.prdQuantity > 0)
        //    {
        //        isIncrease = true;
        //        this.prdQtyList.Add(this.prdQty);
        //        return this.clsPrdQuanOpr.AddPrdQuantity(this.prdQtyList);
        //    }
        //    else
        //    {
        //        isIncrease = false;
        //        this.prdQty.prdQuantity = -(this.prdQty.prdQuantity);
        //        this.prdQtyList.Add(this.prdQty);
        //        return this.clsPrdQuanOpr.DeductPrdQuantity(this.prdQtyList);
        //    }
        //}

        private bool SaveGroupTblAsset()
        {
            this.groupNo = this.clsTbProduct.GetPrdGroupIdByPrdId(this.tbProuctQtyOpn.qtyPrdId);

            if (this.isNew)
            {
                tblAsset tbAsset = new tblAsset()
                {
                    asEntId = Convert.ToInt32(qtyPrdMsurIdTextEdit.EditValue),
                    asAccNo = this.clsTbGroupStr.GetGroupAccNoById(this.groupNo),
                    asAccName = this.clsTbGroupStr.GetGroupNameById(this.groupNo),
                    asDebit = (Convert.ToDouble(qtyQuantityTextEdit.EditValue) * Convert.ToDouble(qtyPriceTextEdit.EditValue)),
                    asDate = DateTime.Now,
                    asBrnId = Session.CurBranch.brnId,
                    asUserId = Session.CurrentUser.id,
                    asView = 1,
                    asStatus = 10
                };
                db.tblAssets.Add(tbAsset);
                return true;
            }
            else
                return new ClsTblAsset().UpdateAssetDebitByPrdMsurId(this.tbProuctQtyOpn.qtyPrdMsurId, (Convert.ToDouble(qtyQuantityTextEdit.EditValue) * Convert.ToDouble(qtyPriceTextEdit.EditValue)));
        }

        private void ChangeFoucs()
        {
            if (qtyDateDateEdit.ContainsFocus)
                qtyPrdIdTextEdit.Focus();
            else
                qtyDateDateEdit.Focus();
        }

        private void DisableMainEditors()
        {
            ItemForqtyPrdId.Enabled = false;
            ItemForqtyPrdMsurId.Enabled = false;
            //ItemForqtyPrice.Enabled = false;
        }

        private void DisableSubEditors()
        {
            ItemForqtyQuantity.Enabled = false;
        }
        private bool SaveDB()
        {
            return ClsSaveDB.Save(db, LogHelper.GetLogger());
        }
    }
}