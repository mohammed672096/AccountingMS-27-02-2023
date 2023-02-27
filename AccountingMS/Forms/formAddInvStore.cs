using AccountingMS.Classe;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraLayout.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formAddInvStore : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblAccount clsTbAccount;
        ClsTblStore clsTbStore;
        ClsTblInvStoreMain clsTbInvStoreMain;
        ClsTblInvStoreSub clsTbInvStoreSub;
        ClsTblGroupStr clsTbGroup;
        ClsTblProduct clsTbProduct;
        ClsTblPrdPriceMeasurment clsTbPrdMsur;
        ClsTblBarcode clsTbBarcode;
        ClsTblProductQunatity clsTbPrdQuan;
        ClsTblPrdPriceQuan clsTbPrdPriceQuan;
        ClsProductByStore clsPrdByStore;
        tblInvStoreMain tbInvMain;
        tblProduct tbProduct;
        tblPrdPriceMeasurment tbPrdMsur;
        tblBarcode tbBarcode;
        IList<tblInvStoreSub> tbInvSubList;
        IList<tblInvStoreSub> tbInvSubListOld;
        IList<ClsProductQuantList> tbPrdQuantityListOld;

        private readonly ucInvStore ucInv;
        private InvType invType;
        private bool isNew;
        private int invNoOld;
        private short strId;
        private int grpId;
        private bool isManualInv = false, isValidateClose = true;

        private async void FormAddInvStore_Load(object sender, EventArgs e)
        {
            //await ResetPrdQuanNdPrice();
            await InitObjectsAsync();

            InitEventa();
            InitData();
            InitBindingSourceData();
        }
        public formAddInvStore()
        {
            InitializeComponent();

        }
        public formAddInvStore(ucInvStore ucInv, InvType invType, tblInvStoreMain tbInvMain, ClsTblStore clsTbStore, ClsTblInvStoreMain clsTbInvStoreMain)
        {
            Program.Localization();
            this.ucInv = ucInv;
            InitDefaultFields(invType, tbInvMain);

            InitializeComponent();
            InitDefaultObjects(clsTbStore, clsTbInvStoreMain);
            InitProperties();

            this.Load += FormAddInvStore_Load;
        }

        private void InitEventa()
        {
            this.FormClosing += FormAddInvStore_FormClosing;

            btnSubmitInv.Click += BtnSubmitInv_Click;
            btnSubmitGrpProducts.Click += BtnSubmitGrpProducts_Click;

            invBarcodeTextEdit.KeyDown += InvBarcodeTextEdit_KeyDown;
            invStrIdTextEdit.EditValueChanged += InvStrIdTextEdit_EditValueChanged;
            invStrIdTextEdit.EditValueChanging += InvStrIdTextEdit_EditValueChanging;
            invGrpIdTextEdit.EditValueChanged += InvGrpIdTextEdit_EditValueChanged;
            invManualSrchTextEdit.EditValueChanged += InvManualSrchTextEdit_EditValueChanged;

            gridControl1.ProcessGridKey += GridControl1_ProcessGridKey;

            gridView1.InitNewRow += GridView1_InitNewRow;
            gridView1.FocusedRowChanged += GridView1_FocusedRowChanged;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
            gridView1.CustomRowCellEditForEditing += GridView1_CustomRowCellEditForEditing;
            gridView1.CellValueChanging += GridView1_CellValueChanging;

            repoItemSrchLookUpEditPrd.EditValueChanged += RepoItemSrchLookUpEditPrd_EditValueChanged;
            repoItemLookUpEditPrdMsur.EditValueChanged += RepoItemLookUpEditPrdMsur_EditValueChanged;
            repoItemSrchLookUpEditPrd.EditValueChanging += RepoItemSrchLookUpEditPrd_EditValueChanging;
            repoItemLookUpEditPrdMsur.EditValueChanging += RepoItemLookUpEditPrdMsur_EditValueChanging;

        }

        private async Task InitObjectsAsync()
        {
            flyDialog.WaitForm(this, 1);
            IList<Task> taskList = new List<Task>();

            taskList.Add(Task.Run(() => this.clsTbGroup = new ClsTblGroupStr()));
            taskList.Add(Task.Run(() => this.clsTbProduct = new ClsTblProduct()));
            taskList.Add(Task.Run(() => this.clsTbPrdMsur = new ClsTblPrdPriceMeasurment()));
            taskList.Add(Task.Run(() => this.clsTbBarcode = new ClsTblBarcode()));
            taskList.Add(Task.Run(() => this.clsTbPrdQuan = new ClsTblProductQunatity()));
            taskList.Add(Task.Run(() => this.clsTbInvStoreSub = new ClsTblInvStoreSub()));
            if (this.invType == InvType.Direct) taskList.Add(Task.Run(() => this.clsTbPrdPriceQuan = new ClsTblPrdPriceQuan()));
            if (this.invType == InvType.Settlement) taskList.Add(Task.Run(() => this.clsTbAccount = new ClsTblAccount()));

            await Task.WhenAll(taskList);
            this.clsPrdByStore = new ClsProductByStore(this.clsTbProduct.GetProductList, this.clsTbPrdQuan.GetPrdQuantityList);
            flyDialog.WaitForm(this, 0);
        }

        private void InitDefaultFields(InvType invType, tblInvStoreMain tbInvMain)
        {
            this.invType = invType;
            this.tbInvMain = tbInvMain;
            this.isNew = tbInvMain == null ? true : false;
        }

        private void InitData()
        {
            if (this.isNew) InitNewInvObjects();
            else InitInvUpdateObjects();
        }

        private void InitNewInvObjects()
        {
            InitInvMain();
            InitInvSub();
        }

        private void InitInvMain()
        {
            this.tbInvMain = this.invType == InvType.Settlement ? new tblInvStoreMain() : new tblInvStoreMain()
            {
                invNo = this.clsTbInvStoreMain.GetInvStoreNewNo(),
                invDate = DateTime.Now,
                invStrId = MySetting.DefaultSetting.defaultStrId,
                invBrnId = Session.CurBranch.brnId,
                invStatus = (byte)this.invType
            };

            tblInvStoreMainBindingSource.DataSource = this.tbInvMain;
        }

        private void InitInvSub()
        {
            this.tbInvSubList = new List<tblInvStoreSub>();
            tblInvStoreSubBindingSource.DataSource = this.tbInvSubList;
        }

        private void InitInvUpdateObjects()
        {
            this.strId = this.tbInvMain.invStrId;
            this.invNoOld = this.tbInvMain.invNo;
            this.tbInvSubList = this.clsTbInvStoreSub.GetInvStoreListByInvMainId(this.tbInvMain.id);
            this.tbInvSubListOld = this.tbInvSubList.Select(x => new tblInvStoreSub() { invPrdId = x.invPrdId, invPrdMsurId = x.invPrdMsurId, invQuanDefr = x.invQuanDefr }).ToList();
            this.tbPrdQuantityListOld = this.tbInvSubList.Select(x => new ClsProductQuantList() { prdId = x.invPrdId, prdPriceMsurId = x.invPrdMsurId, prdQuantity = x.invQuanDefr, prdStrId = this.tbInvMain.invStrId }).ToList();

            tblInvStoreMainBindingSource.DataSource = this.tbInvMain;
            tblInvStoreSubBindingSource.DataSource = this.tbInvSubList;
        }

        private void InitDefaultObjects(ClsTblStore clsTbStore, ClsTblInvStoreMain clsTbInvStoreMain)
        {
            this.clsTbStore = clsTbStore;
            this.clsTbInvStoreMain = clsTbInvStoreMain;
        }

        private void InitBindingSourceData()
        {
            tblStoreBindingSource.DataSource = this.clsTbStore.GetStoreList;
            tblGroupStrBindingSource.DataSource = this.clsTbGroup.GetGroupList;
            if (this.invType != InvType.Manual) tblInvStoreMainLookupBindingSource.DataSource =
                    this.clsTbInvStoreMain.GetInvStoreList(this.invType == InvType.Direct ? InvType.Manual : InvType.Direct);
            if (this.invType == InvType.Settlement) tblAccountBindingSource.DataSource = this.clsTbAccount.GetAccountListType2();
        }

        private void InvStrIdTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null || string.IsNullOrEmpty(editor?.EditValue.ToString())) return;
            if (Convert.ToInt32(editor?.EditValue) == 0) return;

            this.strId = Convert.ToInt16(editor.GetColumnValue("id"));
            tblProductBindingSource.DataSource = this.clsPrdByStore.GetProductListByStrId(this.strId)
                .Where(x => x.prdStatus != 2).ToList();
            EnableControls();
        }

        private void InvStrIdTextEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;

            e.Cancel = !ValidateChangeStore();
        }

        private void InvManualSrchTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            btnSubmitInv.Enabled = true;
        }

        private void InvGrpIdTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            btnSubmitGrpProducts.Enabled = true;
        }

        private void GridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) invBarcodeTextEdit.Focus();
            if (e.KeyCode != Keys.Delete) return;

            if (Convert.ToInt32(gridView1.GetFocusedRowCellValue(colid)) != 0)
                this.clsTbInvStoreSub.Remove(gridView1.GetFocusedRow() as tblInvStoreSub);
            gridView1.DeleteSelectedRows();
        }

        private void GridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == colinvPrdMsurId.FieldName) e.RepositoryItem = repoItemLookUpEditPrdMsur;
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == colinvPrdMsurId.FieldName) e.DisplayText = this.clsTbPrdMsur.GetPrdPriceMsurNameById(Convert.ToInt32(e.Value));
        }

        private void GridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            tblPrdPriceMeasurmentBindingSource.DataSource = this.clsTbPrdMsur.GetPrdPriceMsurListByPrdId(Convert.ToInt32(gridView1.GetFocusedRowCellValue(colinvPrdId)));
        }

        private void GridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == colinvQuanAvl.FieldName)
                SetQuanDefrence(e.RowHandle, e.Value);
        }

        private void GridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            if (gridControl1.ContainsFocus) return;

            gridView1.SetRowCellValue(e.RowHandle, colinvBarcode, this.tbBarcode.brcNo);
            gridView1.SetRowCellValue(e.RowHandle, colinvPrdId, this.tbProduct.id);
            gridView1.SetRowCellValue(e.RowHandle, colinvPrdMsurId, this.tbPrdMsur.ppmId);
            gridView1.SetRowCellValue(e.RowHandle, colinvPrdGrpId, this.tbProduct.prdGrpNo);
            gridView1.SetRowCellValue(e.RowHandle, colinvSalePrice,clsTbPrdMsur.GetppmSalePrice(this.tbProduct.prdPriceTax,this.tbPrdMsur));
        }

        private void RepoItemSrchLookUpEditPrd_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e?.NewValue == null) return;

            this.tbProduct = this.clsTbProduct.GetPrdObjByPrdId(Convert.ToInt32(e.NewValue));
            e.Cancel = !ValidateGridPrdId(Convert.ToInt32(e.NewValue));
        }

        private void RepoItemLookUpEditPrdMsur_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e?.NewValue == null) return;

            this.tbPrdMsur = this.clsTbPrdMsur.GetPrdPriceMsurById(Convert.ToInt32(e.NewValue));
            e.Cancel = !ValidateGridPrdMsurdId(Convert.ToInt32(e.NewValue));
        }

        private void RepoItemSrchLookUpEditPrd_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit editor = sender as SearchLookUpEdit;
            if (editor?.EditValue == null || string.IsNullOrEmpty(editor.Text)) return;

            this.tbProduct = editor.GetSelectedDataRow() as tblProduct;

            InitProduct();
            InitPrdMsur();
            InitBarcode();
            InitPrdQuanNdPrice();

            gridView1.UpdateCurrentRow();
        }

        private void RepoItemLookUpEditPrdMsur_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;

            this.tbPrdMsur = editor.GetSelectedDataRow() as tblPrdPriceMeasurment;
            gridView1.SetFocusedRowCellValue(colinvPrdMsurId, this.tbPrdMsur?.ppmId);
            gridView1.SetFocusedRowCellValue(colinvSalePrice, clsTbPrdMsur.GetppmSalePrice(this.tbProduct.prdPriceTax, this.tbPrdMsur));

            InitBarcode();
            InitPrdQuanNdPrice();

            gridView1.UpdateCurrentRow();
        }

        private void InitProduct()
        {
            gridView1.SetFocusedRowCellValue(colinvPrdId, this.tbProduct.id);
            gridView1.SetFocusedRowCellValue(colinvPrdGrpId, this.tbProduct.prdGrpNo);
        }

        private void InitPrdMsur()
        {
            this.tbPrdMsur = this.clsTbPrdMsur.GetPrdPriceMsurDefaultRowByPrdId(this.tbProduct.id);
            if (this.tbPrdMsur == null) return;

            gridView1.SetFocusedRowCellValue(colinvPrdMsurId, this.tbPrdMsur.ppmId);
            gridView1.SetFocusedRowCellValue(colinvSalePrice, clsTbPrdMsur.GetppmSalePrice(this.tbProduct.prdPriceTax, this.tbPrdMsur));
            tblPrdPriceMeasurmentBindingSource.DataSource = this.clsTbPrdMsur.GetPrdPriceMsurListByPrdId(this.tbProduct.id);
        }

        private void InitBarcode()
        {
            this.tbBarcode = this.clsTbBarcode.GetBarcodeObjByPrdMsurId(this.tbPrdMsur.ppmId);
            if (this.tbBarcode == null) return;

            gridView1.SetFocusedRowCellValue(colinvBarcode, this.tbBarcode.brcNo);
        }

        private void InitPrdQuanNdPrice()
        {
            if (this.invType == InvType.Manual) return;

            SetPrdQuan(gridView1.FocusedRowHandle, this.tbProduct.id, this.tbPrdMsur);
            SetAveragePrdPrice(gridView1.FocusedRowHandle, this.tbProduct.id, this.tbPrdMsur.ppmId, this.tbPrdMsur);
        }

        private async void InvBarcodeTextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (string.IsNullOrWhiteSpace(invBarcodeTextEdit.Text)) return;

            SearchBarcodeData(invBarcodeTextEdit.Text);

            invBarcodeTextEdit.EditValue = null;
        }

        private void SearchBarcodeData(string barcodeNo)
        {
            if (!ValidateBarcode(barcodeNo)) return;
            if (!ValidateGridPrdMsur()) return;

            this.tbPrdMsur = this.clsTbPrdMsur.GetPrdPriceMsurObjById(this.tbBarcode.brcPrdMsurId);
            this.tbProduct = this.clsTbProduct.GetPrdObjByPrdId(this.tbPrdMsur?.ppmPrdId ?? 0);

            if (this.tbProduct == null || this.tbPrdMsur == null)
            {
                ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Sorry, the item you requested was not found!" : "عذراً لم يتم العثور على الصنف المطلوب!");
                return;
            }

            gridView1.AddNewRow();
            gridView1.UpdateCurrentRow();

            InitPrdQuanNdPrice();
        }

        private async void BtnSubmitInv_Click(object sender, EventArgs e)
        {
            if (!ValidateSubmitInv()) return;

            this.isManualInv = true;
            int invMainId = Convert.ToInt32(invManualSrchTextEdit.EditValue);

            this.tbInvMain = this.clsTbInvStoreMain.GetInvStoreObjById(invMainId);
            this.invNoOld = this.tbInvMain.invNo;

            tblInvStoreMainBindingSource.DataSource = this.tbInvMain;
            tblInvStoreSubBindingSource.DataSource = this.clsTbInvStoreSub.GetInvStoreListByInvMainId(invMainId);

            await SetPrdPriceNdQuan();
        }

        private async Task SetPrdPriceNdQuan()
        {
            if (this.invType != InvType.Direct) return;

            try
            {
                for (short i = 0; i < gridView1.DataRowCount; i++)
                {
                    var tbInvSub = gridView1.GetRow(i) as tblInvStoreSub;
                    if (tbInvSub == null) continue;

                    var prdMsur = this.clsTbPrdMsur.GetPrdPriceMsurObjById(tbInvSub.invPrdMsurId);

                    SetPrdQuan(i, tbInvSub.invPrdId, prdMsur);
                    SetAveragePrdPrice(i, tbInvSub.invPrdId, tbInvSub.invPrdMsurId, prdMsur);
                    SetQuanDefrence(i, gridView1.GetRowCellValue(i, colinvQuanAvl));
                }
            }
            catch (Exception ex)
            {
                new ExceptionLogger(ex, "formAddInvStore", true);
            }
        }

        private void SetPrdQuan(int i, int invPrdId, tblPrdPriceMeasurment prdMsur)
        {
            gridView1.SetRowCellValue(i, colinvQuanStr, this.clsTbPrdQuan.GetTotalPrdQuantityByPrdINddMsurStatus(invPrdId, prdMsur, this.tbInvMain.invStrId));
        }
        MyFunaction myFunaction = new MyFunaction();
        private void SetAveragePrdPrice(int i, int prdId, int prdMsurId, tblPrdPriceMeasurment prdMsur)
        {
            //var tbPrdQuan =myFunaction.GetDataProductTransaction(prdId, this.tbInvMain.invStrId, this.tbInvMain.invDate);
            gridView1.SetRowCellValue(i, colinvPriceAvrg, prdMsur.ppmPrice ?? 0);// this.clsTbPrdPriceQuan.GetCostOfNextProductTransaction(prdId, this.tbInvMain.invStrId, this.tbInvMain.invDate, prdMsur.ppmConversion ?? 1, tbPrdQuan));
        }

        private void SetQuanDefrence(int rowHandle, object value)
        {
            if (value == null || !double.TryParse(value.ToString(), out double quanAvailable)) return;

            var tbInvSub = gridView1.GetRow(rowHandle) as tblInvStoreSub;
            if (tbInvSub == null) return;

            double quanDeffrence = quanAvailable - tbInvSub.invQuanStr;

            gridView1.SetRowCellValue(rowHandle, colinvQuanDefr, quanDeffrence);
            gridView1.SetRowCellValue(rowHandle, colinvPriceDefr, Math.Round(tbInvSub.invPriceAvrg * (double)quanDeffrence, 3, MidpointRounding.AwayFromZero));
            gridView1.SetRowCellValue(rowHandle, colinvPriceTotal, Math.Round(tbInvSub.invPriceAvrg * (double)quanAvailable, 3, MidpointRounding.AwayFromZero));
            gridView1.SetRowCellValue(rowHandle, colinvSalePriceTotal, Math.Round(tbInvSub.invSalePrice * (double)quanAvailable, 3, MidpointRounding.AwayFromZero));
        }

        private bool ValidateSubmitInv()
        {
            bool isValid = true;
            bool isDataFound = tblInvStoreSubBindingSource.Count > 0 ? true : false;

            if (isDataFound)
            {
                string mssg = MySetting.GetPrivateSetting.LangEng ? $"Are you sure you want to download inventory number: {invManualSrchTextEdit.Text}? \n" :
                    $"هل أنت متأكد من إنزال الجرد رقم: {invManualSrchTextEdit.Text}؟\n";

                mssg += MySetting.GetPrivateSetting.LangEng ? "The current data will be canceled.\n\n nContinue?" : "سيتم إلغاء البيانات الحاليه.\n\nمتابعه؟";

                isValid = ClsXtraMssgBox.ShowWarningYesNo(mssg) == DialogResult.Yes ? true : false;

                if (isValid) ResetCahnges();
            }

            return isValid;
        }

        private void ResetCahnges()
        {
            flyDialog.WaitForm(this, 1);

            this.clsTbInvStoreMain.ResetChanges(this.tbInvMain);

            if (tblInvStoreSubBindingSource.Count > 1000) this.clsTbInvStoreSub = new ClsTblInvStoreSub();
            else this.clsTbInvStoreSub.ResetChanges(tblInvStoreSubBindingSource.List as IList<tblInvStoreSub>);

            flyDialog.WaitForm(this, 0);
        }

        private async void BtnSubmitGrpProducts_Click(object sender, EventArgs e)
        {
            this.grpId = Convert.ToInt32(invGrpIdTextEdit.EditValue);
            AddProductsByGrpStore(this.grpId);

            if (this.invType == InvType.Direct) await SetPrdPriceNdQuan();
        }

        private void AddProductsByGrpStore(int grpId)
        {
            flyDialog.WaitForm(this, 1);

            this.tbInvSubList = tblInvStoreSubBindingSource.List as IList<tblInvStoreSub>;

            var tbProductTmpList = this.clsPrdByStore.GetProductListByStrId(this.strId)
                .Where(x => x.prdGrpNo == grpId)
                .Where(x => !this.tbInvSubList.Any(y => y.invPrdId == x.id)).ToList();


            var PrdMsur = (from prdMsur in this.clsTbPrdMsur.GetPrdPriceMsurList
                           join prd in tbProductTmpList on prdMsur.ppmPrdId equals prd.id
                           select new
                           {
                               bar = clsTbBarcode.GetFirstBarcodeByPrdMsurId(prdMsur.ppmId),
                               prdId = prd.id,
                               prdMsur = prdMsur.ppmId,
                               prdGrpId = prd.prdGrpNo,
                               prdSalePrice = clsTbPrdMsur.GetppmSalePrice(prd.prdPriceTax, prdMsur)
                           }).ToList();


            PrdMsur.ForEach(x => tblInvStoreSubBindingSource.Add(new tblInvStoreSub()
            {
                invBarcode = x.bar,
                invPrdId = x.prdId,
                invPrdMsurId = x.prdMsur,
                invPrdGrpId = x.prdGrpId,
                invSalePrice = Convert.ToDouble(x.prdSalePrice)
            }));
            gridView1.UpdateCurrentRow();
            flyDialog.WaitForm(this, 0);
        }

        private bool SaveData()
        {
            try
            {
                //if (!SavePrdQuantity()) return false;
                if (!SaveMain()) return false;
                if (!SaveSub()) return false;
                if (!SaveInvSettlement()) return false;
            }
            catch (Exception ex)
            {
                new ExceptionLogger(ex, "formAddInvStore", true);
                return false;
            }

            return true;
        }

        private bool SaveInvSettlement()
        {
            if (this.invType != InvType.Settlement) return true;

            this.tbInvSubList = tblInvStoreSubBindingSource.List as IList<tblInvStoreSub>;
            if (this.tbInvSubList == null || this.tbInvSubList?.Count == 0) return false;

            double amountDecrease = this.tbInvSubList.Where(x => x.invPriceDefr < 0).Sum(x => x.invPriceDefr);
            double amountIncrease = this.tbInvSubList.Where(x => x.invPriceDefr > 0).Sum(x => x.invPriceDefr);
            double total = amountDecrease + amountIncrease;

            if (total == 0) return true;
            else return SaveAssetEntries(total);
        }

        private bool SaveAssetEntries(double total)
        {
            var tbInvGrpTotalList = this.tbInvSubList.GroupBy(x => x.invPrdGrpId, (key, grp) => new
            {
                grpId = key,
                total = grp.Sum(x => x.invPriceDefr)
            }).ToList();

            double grpTotal = tbInvGrpTotalList.Sum(x => x.total);
            if (grpTotal != total) return false;

            IList<tblAsset> tbAssetList = new List<tblAsset>();

            foreach (var x in tbInvGrpTotalList)
            {
                if (x.total == 0) continue;

                var tbGroup = this.clsTbGroup.GetGroupObjById(x.grpId);
                tbAssetList.Add(InitAssetObj(tbGroup.grpAccNo, this.clsTbAccount.GetAccountNameByNo(tbGroup.grpAccNo), x.total));
            }

            return SaveAssetEntriesToDB(tbAssetList, total);
        }

        private bool SaveAssetEntriesToDB(IList<tblAsset> tbAssetList, double total)
        {
            var tbAccount = this.clsTbAccount.GetAccountObjById(Convert.ToInt32(invSetlmntAccIdTextEdit.EditValue));
            var tbAssetMain = InitAssetObj(tbAccount.accNo, tbAccount.accName, -total);

            using var db = new accountingEntities();
            db.tblAssets.Add(tbAssetMain);
            db.tblAssets.AddRange(tbAssetList);

            return ClsSaveDB.Save(db, LogHelper.GetLogger());
        }

        private tblAsset InitAssetObj(long accNo, string accName, double total)
        {
            var tbAsset = new tblAsset()
            {
                asAccNo = accNo,
                asAccName = accName,
                asDesc = MySetting.GetPrivateSetting.LangEng ? "Stock Adjustment" : "تسوية مخزنية",
                asEntId = this.tbInvMain.id,
                asEntNo = this.tbInvMain.invNo,
                asDate = this.tbInvMain.invDate,
                asBrnId = this.tbInvMain.invBrnId,
                asStatus = (byte)AssetType.InvSettlement,
                asUserId = Session.CurrentUser.id,
                asView = 1
            };

            if (total > 0) tbAsset.asDebit = total;
            else tbAsset.asCredit = -(total);

            return tbAsset;
        }

        private bool SaveMain()
        {
            if (this.isNew && this.isManualInv) this.tbInvMain.invStatus = (byte)this.invType;
            if (this.invType == InvType.Settlement) this.tbInvMain.invStatus = (byte)this.invType;
            if (this.isNew && !this.isManualInv) this.clsTbInvStoreMain.Add(tblInvStoreMainBindingSource.Current as tblInvStoreMain);

            return this.clsTbInvStoreMain.SaveDB;
        }

        private bool SaveSub()
        {
            if (this.invType == InvType.Settlement) return true;

            gridView1.FocusedColumn = colid;
            gridView1.UpdateCurrentRow();

            for (short i = 0; i < gridView1.DataRowCount; i++)
            {
                var tbInvSub = gridView1.GetRow(i) as tblInvStoreSub;
                if (tbInvSub == null) continue;
                if (tbInvSub.id != 0) continue;
                tbInvSub.invMainId = this.tbInvMain.id;
                this.clsTbInvStoreSub.Add(tbInvSub);
            }

            return this.clsTbInvStoreSub.SaveDB;
        }

        //private bool SavePrdQuantity()
        //{
        //    if (this.invType != InvType.Direct) return true;

        //    var tbPrdQuantityList = ClsStockPrdQuantityListConverter.InitPrdQuantityList(tblInvStoreSubBindingSource.List as IList<tblInvStoreSub>, this.tbInvMain.invStrId);

        //    if (this.isNew) return this.clsPrdQuanOpr.AddPrdQuantity(tbPrdQuantityList) && this.clsPrdPriceQuanOpr.AddPrdQuantity(tbPrdQuantityList);
        //    else
        //    {
        //        for (short i = 0; i < tbPrdQuantityListOld.Count; i++)
        //            if (this.tbPrdQuantityListOld.ElementAt(i).prdId != tbPrdQuantityList.ElementAt(i).prdId)
        //            {
        //                var tbPrdQuan = this.tbPrdQuantityListOld.ElementAt(i).ShallowCopy();
        //                tbPrdQuan.prdQuantity = 0;

        //                tbPrdQuantityList.Insert(i, tbPrdQuan);
        //            }

        //        var tbPrdQuantityListNew = tbPrdQuantityList.Where(x => !this.tbPrdQuantityListOld.Any(y => y.prdId == x.prdId)).ToList();
        //        if (tbPrdQuantityListNew?.Count > 0)
        //            if (!this.clsPrdQuanOpr.AddPrdQuantity(tbPrdQuantityListNew) || !this.clsPrdPriceQuanOpr.AddPrdQuantity(tbPrdQuantityListNew)) return false;

        //        return this.clsPrdQuanOpr.UpdateProductQuantity(this.tbPrdQuantityListOld, tbPrdQuantityList, true) && this.clsPrdPriceQuanOpr.UpdateProductQuantity(this.tbPrdQuantityListOld, tbPrdQuantityList, true);
        //    }
        //}
        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ValidateData()) return;
            if (!SaveData()) return;

            string mssg = "";
            if (MySetting.GetPrivateSetting.LangEng)
                mssg = this.invType != InvType.Settlement ? "Inventory" : "Inventory settlement";
            else
                mssg = this.invType != InvType.Settlement ? "الجرد " : "التسوية المخزنيه للجرد ";

            mssg += MySetting.GetPrivateSetting.LangEng ? $"Number: {this.tbInvMain.invNo}" : $"رقم: {this.tbInvMain.invNo}";

            this.isValidateClose = false;
            this.ucInv.SetRefreshListDialog(mssg, this.isNew, this.tbInvMain.invNo);
            this.DialogResult = DialogResult.OK;
        }

        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ValidateReset()) return;
            if (this.isManualInv) ResetCahnges();

            this.isManualInv = false;
            InitNewInvObjects();
        }
        List<RepMoveProduct_Result> report2;
        private void bbiRefreshPrdQuanNdPrice_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.DataRowCount == 0) return;
            {
                using (var db = new accountingEntities())
                    report2 = db.RepMoveProduct(invDateDateEdit.DateTime, invDateDateEdit.DateTime).ToList();
                //await SetPrdPriceNdQuan();

                if (this.invType != InvType.Direct) return;

                try
                {
                    for (short i = 0; i < gridView1.DataRowCount; i++)
                    {
                        var tbInvSub = gridView1.GetRow(i) as tblInvStoreSub;
                        if (tbInvSub == null) continue;

                        var prdMsur = this.clsTbPrdMsur.GetPrdPriceMsurObjById(tbInvSub.invPrdMsurId);
                        //return (tbPrdQty.prdQuantity ?? 0) / (prdMsur.ppmConversion ?? 1);
                        var gg = report2.FirstOrDefault(x => x.ProductID == tbInvSub.invPrdId);
                        var q = (report2.FirstOrDefault(x => x.ProductID == tbInvSub.invPrdId)?.QuFrist ?? 0) / (prdMsur?.ppmConversion ?? 1);
                        gridView1.SetRowCellValue(i, colinvQuanStr, q);
                        //SetPrdQuan(i, tbInvSub.invPrdId, prdMsur);
                        SetAveragePrdPrice(i, tbInvSub.invPrdId, tbInvSub.invPrdMsurId, prdMsur);
                        SetQuanDefrence(i, gridView1.GetRowCellValue(i, colinvQuanAvl));
                    }
                }
                catch (Exception ex)
                {
                    new ExceptionLogger(ex, "formAddInvStore", true);
                }
            }
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!IsCloseForm()) return;

            this.isValidateClose = false;
            this.Close();
        }

        private void FormAddInvStore_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isValidateClose) return;
            e.Cancel = !IsCloseForm();
        }

        private bool IsCloseForm()
        {
            bool isCloseForm = ClsXtraMssgBox.ShowWarningYesNo(MySetting.GetPrivateSetting.LangEng ? "Are you sure to turn off the screen?" : "هل أنت متأكد من إغلاق الشاشة؟") == DialogResult.Yes ? true : false;
            if (isCloseForm && !this.isNew) this.clsTbInvStoreMain.ResetChanges(this.tbInvMain);

            return isCloseForm;
        }

        private bool ValidateData()
        {
            if (!dxValidationProvider1.Validate()) return false;
            if (!ValidateInvNo()) return false;
            if (!ValidateGrid()) return false;
            return true;
        }

        private bool ValidateInvNo()
        {
            bool isValid = true;

            if (this.isNew && !this.isManualInv && this.clsTbInvStoreMain.IsInvStoreNoFound(this.tbInvMain.invNo)) isValid = false;
            if ((!this.isNew || this.isManualInv) && this.invNoOld != this.tbInvMain.invNo && this.clsTbInvStoreMain.IsInvStoreNoFound(this.tbInvMain.invNo, this.tbInvMain.id)) isValid = false;
            if (!isValid) ClsXtraMssgBox.ShowError(MySetting.GetPrivateSetting.LangEng ? $"Sorry! Inventory number: {this.tbInvMain.invNo} has already been used!" : $"عذراً رقم الجرد: {this.tbInvMain.invNo} قد تم إستخدامه مسبقاً!");

            return isValid;
        }

        private bool ValidateGrid()
        {
            bool isValid = gridView1.DataRowCount > 0 ? true : false;

            if (!isValid) ClsXtraMssgBox.ShowError(MySetting.GetPrivateSetting.LangEng ? "Data must be entered into the table first!" : "يجب إدخال البيانات في الجدول أولاً!");

            return isValid;
        }

        private bool ValidateGridPrdId(int prdId)
        {
            bool isValid = true;

            for (short i = 0; i < gridView1.DataRowCount; i++)
                if (Convert.ToInt32(gridView1.GetRowCellValue(i, colinvPrdId)) == prdId)
                {
                    string msg = MySetting.GetPrivateSetting.LangEng ? $"Sorry, the item {this.tbProduct?.prdName} has already been entered! \n Do you want to move to the required item?" :
                        $"عذراً لقد تم إدخال الصنف {this.tbProduct?.prdName} مسبقاً!\nهل تريد الإنتقال إلى الصنف المطلوب؟";
                    if (ClsXtraMssgBox.ShowWarningYesNo(msg) == DialogResult.Yes) gridView1.FocusedRowHandle = i;

                    isValid = false;
                    break;
                }

            return isValid;
        }

        private bool ValidateGridPrdMsurdId(int prdMsurId)
        {
            bool isValid = true;

            for (short i = 0; i < gridView1.DataRowCount; i++)
                if (Convert.ToInt32(gridView1.GetRowCellValue(i, colinvPrdMsurId)) == prdMsurId)
                {
                    string msg = MySetting.GetPrivateSetting.LangEng ? $"Sorry, the unit of measure {this.tbPrdMsur.ppmMsurName} has already been entered for the item! \n Do you want to move to the required item?" :
                        $"عذراً لقد تم إدخال وحدة القياس {this.tbPrdMsur.ppmMsurName} للصنف مسبقاً!\nهل تريد الإنتقال إلى الصنف المطلوب؟";
                    if (ClsXtraMssgBox.ShowWarningYesNo(msg) == DialogResult.Yes) gridView1.FocusedRowHandle = i;

                    isValid = false;
                    break;
                }

            return isValid;
        }

        private bool ValidateGridPrdMsur()
        {
            bool isValid = true;

            for (short i = 0; i < gridView1.DataRowCount; i++)
                if (Convert.ToInt32(gridView1.GetRowCellValue(i, colinvPrdMsurId)) == this.tbBarcode.brcPrdMsurId)
                {
                    isValid = false;
                    gridView1.FocusedRowHandle = i;
                    break;
                }

            return isValid;
        }

        private bool ValidateBarcode(string barcodeNo)
        {
            this.tbBarcode = this.clsTbBarcode.GetBarcodeObjByNo(barcodeNo);

            bool isValid = this.tbBarcode != null ? true : false;

            if (!isValid)
                ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Sorry, the item you requested was not found!" : "عذراً لم يتم العثور على الصنف المطلوب!");

            return isValid;
        }

        private bool ValidateReset()
        {
            string mssg = MySetting.GetPrivateSetting.LangEng ? "Are you sure to reformat? \n" :
                "هل أنت متأكد من إعادة التهيئة؟\n";
            mssg += MySetting.GetPrivateSetting.LangEng ? "All data will be deleted. \n\n Continue?" :
                "سيتم حذف جميع البيانات.\n\nمتابعه؟";

            return ClsXtraMssgBox.ShowWarningYesNo(mssg) == DialogResult.Yes ? true : false;
        }

        private bool ValidateChangeStore()
        {
            bool isValid = gridView1.DataRowCount > 0 ? false : true;

            if (!isValid)
            {
                string mssg = MySetting.GetPrivateSetting.LangEng ? "The store cannot be changed after data has been entered into the table! \n" :
                    "لا يمكن تغير المخزن بعد أن تم إدخال بيانات في الجدول!\n";
                mssg += MySetting.GetPrivateSetting.LangEng ? "All data in the table will be deleted in case the store changes. \n\n Do you want to continue?" :
                    "سيتم حذف جميع البيانات الموجوده في الجدول في حال تم تغير المخزن.\n\nهل تريد المتابعه؟";

                if (ClsXtraMssgBox.ShowWarningYesNo(mssg) == DialogResult.Yes)
                {
                    isValid = true;
                    InitInvSub();
                }
            }

            return isValid;
        }

        private void EnableControls()
        {
            ItemForinvGrpId.Enabled = true;
            ItemForinvBarcodeSrch.Enabled = true;
            gridControl1.Enabled = true;
        }

        private void InitProperties()
        {
            if (this.invType == InvType.Manual)
                this.Text = MySetting.GetPrivateSetting.LangEng ? "Manual inventory" : "الجرد اليدوي";
            if (this.invType == InvType.Direct)
                this.Text = MySetting.GetPrivateSetting.LangEng ? "Direct inventory" : "الجرد الفوري";
            if (this.invType == InvType.Settlement)
                this.Text = MySetting.GetPrivateSetting.LangEng ? "Settlement inventory" : "تسوية المخزون";

            if (this.invType == InvType.Direct) bbiRefreshPrdQuanNdPrice.Visibility = BarItemVisibility.Always;
            if (!this.isNew || this.invType == InvType.Settlement) bbiReset.Visibility = BarItemVisibility.Never;
            if (!this.isNew || this.invType == InvType.Manual) ItemForinvManualSrch.Visibility = LayoutVisibility.Never;
            if (!this.isNew || this.invType == InvType.Manual) ItemForbtnSubmitInv.Visibility = LayoutVisibility.Never;
            if (!this.isNew && this.invType == InvType.Direct) colinvPrdMsurId.OptionsColumn.AllowEdit = false;

            if (this.invType == InvType.Settlement)
            {
                ItemForinvNo.Enabled = false;
                ItemForinvStrId.Enabled = false;
                ItemForinvDate.Enabled = false;

                ItemForinvManualSrch.Text = MySetting.GetPrivateSetting.LangEng ? "Inventory number:" : "رقم الجرد:";
                ItemForinvBarcodeSrch.Visibility = LayoutVisibility.Never;
                ItemForinvGrpId.Visibility = LayoutVisibility.Never;
                ItemForbtnSubmitGrpProducts.Visibility = LayoutVisibility.Never;
                ItemForinvSetlmntAccId.Visibility = LayoutVisibility.Always;

                gridView1.OptionsBehavior.Editable = false;
                gridView1.OptionsBehavior.ReadOnly = true;
            }

            if (this.invType == InvType.Manual)
            {

                foreach (GridColumn gridColumn in gridView1.Columns)
                {
                    if (gridColumn.Name == colinvPrdId.Name || gridColumn.Name == colinvPrdMsurId.Name
                         || gridColumn.Name == colinvBarcode.Name) continue;

                    gridColumn.Visible = false;
                    gridColumn.OptionsColumn.ShowInCustomizationForm = false;
                    gridColumn.OptionsColumn.ShowInExpressionEditor = false;
                }
            }
        }
    }
}