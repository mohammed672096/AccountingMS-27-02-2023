using AccountingMS.Classes;
using DevExpress.Data.Async.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class UCsalesInstantFeedBack : XtraUserControl
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        tblSupplyMain tbSupplyMainPrint;
        IEnumerable<tblSupplySub> tbSupplySubListPrint;
        private byte State1, State2;
        private SupplyType supplyType;
        private string flyDialogMssg;
        private int supId;
        private bool isNew;
        private bool isDataLoaded = false, isRefreshData = false, isSetFoucsedRow = false;
        private void UCsalesInstantFeedBack_Load(object sender, EventArgs e)
        {
            GetResources();
            InitEvents();
            new ClsTblBranch().InitRepositoryItemBranchLookupEdit(gridControl,"supBrnId");
        }

        public UCsalesInstantFeedBack(SupplyType supplyType)
        {
            this.supplyType = supplyType;
            InitializeComponent();
            SetUserControlLayout();
            colsupNo.Caption = Session.CurrentUser.id == 1 ? "رقم الفاتورة الفرعي" : colsupNo.Caption;
            colMainNo.Visible = Session.CurrentUser.id == 1;
            this.Load += UCsalesInstantFeedBack_Load;

            entityInstantFeedbackSource1.GetQueryable += entityInstantFeedbackSource1_GetQueryable;
            entityInstantFeedbackSource1.DismissQueryable += entityInstantFeedbackSource1_DismissQueryable;

            gridView.OptionsDetail.DetailMode = DetailMode.Embedded;
            State1 = supplyType == SupplyType.SalesPhaseAll ? (byte)8 : (byte)supplyType;
            State2 = supplyType == SupplyType.SalesPhaseAll ? (byte)12 : (byte)supplyType;
        }

        private void InitEvents()
        {
            gridControl.KeyDown += GridControl_KeyDown;

            gridView.AsyncCompleted += GridView_AsyncCompleted;
            gridView.MasterRowGetRelationCount += GridView_MasterRowGetRelationCount;
            gridView.MasterRowEmpty += GridView_MasterRowEmpty;
            gridView.MasterRowGetChildList += GridView_MasterRowGetChildList;
            gridView.MasterRowGetRelationName += GridView_MasterRowGetRelationName;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
            if (supplyType == SupplyType.Sales) gridView.DoubleClick += GridView_DoubleClick;
        }

        private void entityInstantFeedbackSource1_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            accountingEntities db = new accountingEntities();
            if (Session.CurrentUser.id == 1)
            {
                e.QueryableSource = db.tblSupplyMains.Where(x => x.supDate >= Session.CurrentYear.fyDateStart
                && x.supDate <= Session.CurrentYear.fyDateEnd && (x.supStatus == State1 || x.supStatus == State2)).AsNoTracking();
            }
            else
            {
                e.QueryableSource = db.tblSupplyMains.Where(x => x.supBrnId == Session.CurBranch.brnId
                    && x.supDate >= Session.CurrentYear.fyDateStart && x.supDate <= Session.CurrentYear.fyDateEnd
                    && (x.supStatus == State1 || x.supStatus == State2)).AsNoTracking();
            }
            e.Tag = db;
        }

        private void entityInstantFeedbackSource1_DismissQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            ((accountingEntities)e.Tag).Dispose();
        }

        private void InitData()
        {
            this.isDataLoaded = false;

            entityInstantFeedbackSource1.Refresh();
        }

        private void GridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.Alt && e.KeyCode == Keys.D && (this.supplyType == SupplyType.Sales || this.supplyType == SupplyType.SalesRtrn))
                RemoveRow();
        }

        private void GridView_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void GridView_MasterRowEmpty(object sender, MasterRowEmptyEventArgs e)
        {
            e.IsEmpty = false;
        }

        private void GridView_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Level1";
        }

        private void GridView_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
                e.ChildList = GetSupplySubListBySupId(GetFoucsedSupplyMainId);
        }
        List<tblSupplySub> GetSupplySubListBySupId(int MainId)
        {
            using (var db = new accountingEntities())
                return db.tblSupplySubs.AsNoTracking().Where(x => x.supNo == MainId).ToList();
        }
        private int GetFoucsedSupplyMainId => Convert.ToInt32(gridView.GetFocusedRowCellValue(colsupMainId));

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            UpdateButton();
        }

        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value == null) return;
            if (e.Column.FieldName == colsupStatus.FieldName && e.Value is byte s &&s>0)
                e.DisplayText = ClsSupplyStatus.GetString(s);
            else if (e.Column.FieldName == colsupCurrency.FieldName && e.Value is byte cur && cur != 0)
                e.DisplayText = Session.Currencies?.FirstOrDefault(x => x.id == cur)?.curName;
            else if (e.Column.FieldName == colsupCustSplId.FieldName && e.Value is int cus && cus != 0)
                e.DisplayText = Session.Customers?.FirstOrDefault(x=>x.id==cus)?.custName;
            
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "supMsur" && e.Value is int m && m != 0)
                e.DisplayText = Session.tblPrdPriceMeasurment?.FirstOrDefault(x=>x.ppmId==m)?.ppmMsurName;
        }

        private void GridView_AsyncCompleted(object sender, EventArgs e)
        {
            if (this.isRefreshData)
            {
                this.isRefreshData = false;
                return;
            }
            this.isDataLoaded = true;
            if (this.isSetFoucsedRow) SetFoucesdRow();
            bsiRecordsCount.Caption = $"{_resource.GetString("count")} {gridView.DataRowCount:n0}";
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ParentForm is FormMain formMain)
                formMain.simpleButtonSales_Click(sender,e);
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ValidateData()) return;
            UpdateButton();
        }
        Form form;
        private void UpdateButton()
        {
            if (GetFocusedObj()?.supBrnId != Session.CurBranch.brnId)
            {
                ClsXtraMssgBox.ShowWarning("لا يمكن تعديل فواتير خاصة بفرع اخر من هذا الفرع!!!");
                return;
            }
            try
            {
                var f = (Application.OpenForms.Cast<object>())?.FirstOrDefault(x => x is formSupplyMain formSupply && formSupply.supplyType == SupplyType.Sales && !formSupply.AddSaleInvoice.isNew);
                if (f != null && f is formSupplyMain formSupply)
                    formSupply.Activate();
                else
                {
                    flyDialog.WaitForm(this, 1);
                    form = new formSupplyMain(GetFocusedObj(), GetSupplySubListBySupId(GetFoucsedSupplyMainId), SupplyType.Sales, this.ParentForm);
                    form.Show(); flyDialog.WaitForm(this, 0, form);

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ParentForm is FormMain formMain)
                formMain.simpleButtonSaleRtrn_Click(sender,e);
        }

        private async void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ValidateData()) return;
            await PhaseDataAsync2();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ValidateData()) return;
            RemoveRow(SupplyType.SalesDel);
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ValidateData()) return;
            RemoveRow(SupplyType.SalesRtrnDel);
        }

        private void BbiDeleteAdmin_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ValidateData()) return;
            DeleteRow();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView.OptionsSelection.MultiSelect = (!gridView.IsMultiSelect) ? true : false;
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            InitData();
        }

        private void barButtonItem3_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            if (!ValidateData()) return;
            int supNo = /*(barEditItem2.EditValue is decimal id && id > 0) ? Convert.ToInt32(id) : */Convert.ToInt32(gridView.GetFocusedRowCellValue(colsupNo));
            if (ClsXtraMssgBox.ShowQuesPrint(string.Format(_resource.GetString("printMssg"), supNo)) != DialogResult.Yes) return;
            tblSupplyMain main = GetFocusedObj();
            PrintInvoice(main,GetSupplySubListBySupId(main.id));
        }

        private void bbiPrintRprtTarhel_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ValidateData()) return;
            flyDialog.WaitForm(this, 1);
            var frm = new ReportForm(ReportType.SupplyTarhel, tbSupplyMain: GetFocusedObj());
            frm.Show();
            flyDialog.WaitForm(this, 0, frm);
        }

        private bool ValidateData()
        {
            return gridView?.DataRowCount >= 1;
        }

        private void RemoveRow()
        {
            if (!ValidateData()) return;
            RemoveRow(this.supplyType == SupplyType.Sales ? SupplyType.SalesDel : SupplyType.SalesRtrnDel);
        }

        private void RemoveRow(SupplyType supplyType)
        {
            if (!DeleteRowMssg(out string delSuccessMssg)) return;
            //if (!this.clsTbSupplyMain.Remove(GetFocusedObj(), supplyType)) return;
            if (!RemoveRecordsBySupplyMainId(GetFoucsedSupplyMainId, supplyType)) return;

            flyDialog.ShowDialogUCCustomdMsg(this, delSuccessMssg);

            InitData();
        }
        public bool RemoveRecordsBySupplyMainId(int supId, SupplyType supplyType)
        {
            try
            {
                using (accountingEntities db = new accountingEntities())
                {
                    db.tblSupplyMains.AsQueryable().Where(x => x.id == supId).ToList().ForEach(x => x.supStatus = (byte)supplyType);
                    db.tblSupplySubs.AsQueryable().Where(x => x.supNo == supId).ToList().ForEach(x => x.supStatus = (byte)supplyType);
                    return ClsSaveDB.Save(db, LogHelper.GetLogger());
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        private void DeleteRow()
        {
            if (!DeleteRowMssg(out string delSuccessMssg)) return;
            if (!DeleteSupplyMainId(GetFoucsedSupplyMainId)) return;
            flyDialog.ShowDialogUCCustomdMsg(this, delSuccessMssg);
            InitData();
        }
        public bool DeleteSupplyMainId(int supId)
        {
            try
            {
                using (accountingEntities db = new accountingEntities())
                {
                    db.tblSupplyMains.Remove(db.tblSupplyMains.FirstOrDefault(x => x.id == supId));
                    if (db.tblSupplySubs.Where(x => x.supNo == supId).ToList() is List<tblSupplySub> SupplySub && SupplySub.Count > 0)
                        db.tblSupplySubs.RemoveRange(SupplySub);
                    return ClsSaveDB.Save(db, LogHelper.GetLogger());
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        private bool DeleteRowMssg(out string delSuccessMssg)
        {
            delSuccessMssg = null;
            if (GetFocusedObj() == null) return false;

            int supNo = Convert.ToInt32(gridView.GetFocusedRowCellValue(colsupNo));
            string delMssg = string.Format(_resource.GetString((this.supplyType == SupplyType.Sales ||
                this.supplyType == SupplyType.SalesDel) ? "delSaleMssg" : "delSaleRtrnMssg"), supNo);
            delSuccessMssg = string.Format(_resource.GetString((this.supplyType == SupplyType.Sales ||
                this.supplyType == SupplyType.SalesDel) ? "delSaleSuccessMssg" : "delSaleRtrnSuccessMssg"), supNo);

            return ClsXtraMssgBox.ShowWarningYesNo(delMssg) == DialogResult.Yes;
        }

        private void repositoryItemRadioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            //MySetting.DefaultSetting.printA4 = (((sender as RadioGroup).EditValue as byte?)??5);
            //MySetting.WriterSettingPublic();
            //MySetting.DefaultSetting.printA4 = MySetting.DefaultSetting.printA4;
        }

        private async void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ValidateData()) return;
            await UndoPhaseAsync();
        }
        
        private async Task UndoPhaseAsync()
        {

            if (ClsXtraMssgBox.ShowWarningYesNo(_resource.GetString("undoSelectionPhaseMssg")) != DialogResult.Yes) return;

            flyDialog.WaitForm(this, 1);
            ClsStopWatch stopWatch = new ClsStopWatch();
            var list = gridView.GetSelectedRowsAsync();

            var tbSupplyMainList = new List<tblSupplyMain>();

            foreach (var x in list) tbSupplyMainList.Add(
                 ((ReadonlyThreadSafeProxyForObjectFromAnotherThread)x).OriginalRow as tblSupplyMain);

            stopWatch.Stop($"\n\n\n==========ElappsedTimeInitAllRows = ");
            Console.WriteLine($"\n\n\n=========listCount = {tbSupplyMainList.Count()}\n\n\n");

            if (tbSupplyMainList.Count() == 0)
            {
                flyDialog.WaitForm(this, 0);
                return;
            }

            ClsSupplyTarhelDelete clsSupTarhelDelete = new ClsSupplyTarhelDelete(this.supplyType);

            bool isDeleted = await Task.Run(() => clsSupTarhelDelete.UndoPhaseInvoice(tbSupplyMainList));
            if (isDeleted)
            {
                flyDialog.WaitForm(this, 0);
                flyDialog.ShowDialogUCCustomdMsg(this, _resource.GetString("undoSelectionPhaseSuccessMssg"));
                InitData();
            }
            gridView.OptionsSelection.MultiSelect = false;
        }

       
        private tblSupplyMain GetFocusedObj()
        {
            using (var db=new accountingEntities())
            return db.tblSupplyMains.AsNoTracking().FirstOrDefault(x=>x.id== GetFoucsedSupplyMainId);
        }

     
        private async Task PhaseDataAsync2()
        {
            if (ClsXtraMssgBox.ShowWarningYesNo(_resource.GetString("phaseMssg")) != DialogResult.Yes) return;
            flyDialog.WaitForm(this, 1);
            ClsStopWatch stopWatch = new ClsStopWatch();
            var list = gridView.GetSelectedRowsAsync();
            var tbSupplyMainList = new List<tblSupplyMain>();
            foreach (var x in list) tbSupplyMainList.Add(
                 ((ReadonlyThreadSafeProxyForObjectFromAnotherThread)x).OriginalRow as tblSupplyMain);
            stopWatch.Stop($"\n\n\n==========ElappsedTimeInitAllRows = ");
            Console.WriteLine($"\n\n\n=========listCount = {tbSupplyMainList.Count()}\n\n\n");
            if (tbSupplyMainList.Count() == 0)
            {
                flyDialog.WaitForm(this, 0);
                return;
            }
            ClsSupplyTarhel clsSupTarhel = new ClsSupplyTarhel(this.supplyType);
            bool isSaved = await Task.Run(() => clsSupTarhel.PhaseInvoice(tbSupplyMainList));
            flyDialog.WaitForm(this, 0);
            if (isSaved)
            {
                flyDialog.ShowDialogUCCustomdMsg(this, _resource.GetString("phaseSuccessMssg"));
                InitData();
            }
            gridView.OptionsSelection.MultiSelect = false;
            if (clsSupTarhel.errorListTarhel.Count > 0)
            {
                if (tbSupplyMainList.Count() == 1 || clsSupTarhel.errorListTarhel.Count == 1)
                {
                    string mssg = $"عذراً لم يتم ترحيل الفاتورة .\n";
                    clsSupTarhel.errorListTarhel.ForEach(x => mssg += x.Error + "\n\n");
                    XtraMessageBox.Show(mssg);
                }
                else if (tbSupplyMainList.Count() > 1 && clsSupTarhel.errorListTarhel.Count > 1)
                {
                    if (DialogResult.Yes == ClsXtraMssgBox.ShowWarningYesNo("لم يتم ترحيل بعض الفواتير !!! \n هل تريد عرض الفواتير غير المرحله لمعرفة لماذا لم يتم ترحيلها؟"))
                    {
                        string mssg = $"عذراً لم يتم ترحيل الفواتير التالية .\n";
                        XtraForm xtraDialogForm = new XtraForm() { Width = this.Width / 2, Height = this.Height / 2, RightToLeft = RightToLeft.Yes, RightToLeftLayout = true };
                        xtraDialogForm.Text = mssg;
                        xtraDialogForm.StartPosition = FormStartPosition.CenterScreen;
                        GridControl gridControl = new GridControl() { Dock = DockStyle.Fill, DataSource = clsSupTarhel.errorListTarhel };
                        gridControl.Load += GridControl_Load;
                        xtraDialogForm.Controls.Add(gridControl);
                        xtraDialogForm.ShowDialog();
                    }
                }
            }
        }

        private void GridControl_Load(object sender, EventArgs e)
        {
            ((GridView)((GridControl)sender).MainView).OptionsBehavior.Editable = false;
            ((GridView)((GridControl)sender).MainView).Columns[0].Width = 100;
            ((GridView)((GridControl)sender).MainView).Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            ((GridView)((GridControl)sender).MainView).Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;

        }

    

        public void SetRefreshListDialog(int supId, bool isNew, tblSupplyMain tbSupplyMain, IEnumerable<tblSupplySub> tbSupplySubList)
        {
            this.supId = supId;
            this.isNew = isNew;
            this.tbSupplySubListPrint = tbSupplySubList;
        }
        public void RefreshListDialog()
        {
            this.isRefreshData = true;
            this.isSetFoucsedRow = true;
            InitData();
        }


        public void SetFoucesdRow()
        {
            if (!this.isDataLoaded) return;
            this.isSetFoucsedRow = false;

            int rowHandle = gridView.LocateByValue(colsupMainId.FieldName, this.supId);
            if (rowHandle == GridControl.InvalidRowHandle) return;

            gridView.FocusedRowHandle = rowHandle;
        }

        private void SetUserControlLayout()
        {
            InitUserRight();
            SetPropertiesVisibility();
            HideBarButtons();

            radioGroupPrintType.EditValue = MySetting.DefaultSetting.printA4;
        }

        private void HideBarButtons()
        {
            bbiDelete.Visibility = BarItemVisibility.Never;
            barButtonItem6.Visibility = BarItemVisibility.Never;
            bbiDirectSalesRtrn.Visibility = BarItemVisibility.Never;
        }

        private void InitUserRight()
        {
            if (this.supplyType == SupplyType.Sales)
                new ClsUserControlValidation(this, UserControls.Sale);
            else if (this.supplyType == SupplyType.SalesRtrn)
                new ClsUserControlValidation(this, UserControls.SaleRtrn);
            else if (this.supplyType == SupplyType.SalesPhaseAll)
                new ClsUserControlValidation(this, UserControls.SalePhased);
        }

      

        private void PrintInvoice(tblSupplyMain tbSupplyMain, IEnumerable<tblSupplySub> tbSupplySubList)
        {
            ReportType reType = (ReportType)((byte)radioGroupPrintType.EditValue);
            switch (reType)
            {
                case ReportType.SupplyA4 when MySetting.DefaultSetting.supplyA4CustomRprt:
                    if ((tbSupplyMain.supStatus == 11 || tbSupplyMain.supStatus == 12) && !MySetting.DefaultSetting.supplyRetuA4CustomRprt)
                        reType = (ReportType)((byte)radioGroupPrintType.EditValue);
                    else reType = ReportType.SupplyCustom;
                    break;
                case ReportType.SupplyChasier when MySetting.DefaultSetting.supplyCashierCustomRprt:
                    if ((tbSupplyMain.supStatus == 11 || tbSupplyMain.supStatus == 12)&& !MySetting.DefaultSetting.supplyRetuA4CustomRprt)
                        reType = (ReportType)((byte)radioGroupPrintType.EditValue);
                    else reType = ReportType.SupplyCashierCustom;
                    break;
            }
            var rprt = new ReportForm(reType, tbSupplyMain: tbSupplyMain, tbSupplySubList: tbSupplySubList);
            rprt.Show();
        }

        private void SetPropertiesVisibility()
        {
            switch (this.supplyType)
            {
                case SupplyType.Sales:
                    ribbonPageGroup5.Visible = false;
                    colsupDebit.Visible = false;
                    bbiNew.ItemShortcut = new BarShortcut(Keys.F2);
                    break;
                case SupplyType.SalesRtrn:
                    ribbonPageGroup1.Visible = false;
                    colsupCredit.Visible = false;
                    barButtonItem4.ItemShortcut = new BarShortcut(Keys.F2);
                    break;
                case SupplyType.SalesPhaseAll:
                    HideRibbonGroups();
                    ribbonPageGroup6.Visible = true;
                    colsupStatus.Visible = true;
                    colsupDebit.Visible = false;
                    break;
                case SupplyType.SalesDel:
                    HideRibbonGroups();
                    ribbonPageGroup2.Visible = false;
                    ribbonPageGroupDel.Visible = true;
                    break;
                case SupplyType.SalesRtrnDel:
                    goto case SupplyType.SalesDel;
            }
        }

        private void HideRibbonGroups()
        {
            ribbonPageGroup1.Visible = false;
            ribbonPageGroup3.Visible = false;
            ribbonPageGroup5.Visible = false;
        }

        private void BtnShowCancelSalesTarhel_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView.OptionsSelection.MultiSelect = (!gridView.IsMultiSelect) ? true : false;
        }
        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng)
            {
                _ci = new CultureInfo("ar");
                _resource = new ComponentResourceManager(typeof(Language.SalesManagementAr));
            }
            else
            {
                _ci = new CultureInfo("en");
                _resource = new ComponentResourceManager(typeof(Language.UCsaleEn));
            }

            if (MySetting.GetPrivateSetting.LangEng) EnglishTranslation();
        }

        private void EnglishTranslation()
        {
            this.RightToLeft = RightToLeft.No;
            gridControl.RightToLeft = RightToLeft.No;

            foreach (var control in ribbonControl.Manager.Items)
            {
                if (control is BarButtonItem)
                {
                    BarButtonItem c = control as BarButtonItem;
                    _resource.ApplyResources(c, c.Name, _ci);
                }
            }
            foreach (GridColumn c in gridView.Columns)
                _resource.ApplyResources(c, c.Name, _ci);
            foreach (GridColumn c in gridView1.Columns)
                _resource.ApplyResources(c, c.Name, _ci);

            _resource.ApplyResources(ribbonPage1, ribbonPage1.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup1, ribbonPageGroup1.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup2, ribbonPageGroup2.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup3, ribbonPageGroup3.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup5, ribbonPageGroup5.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup6, ribbonPageGroup6.Name, _ci);
            repositoryItemRadioGroup1.Items[1].Description = _resource.GetString("cashier");
            barButtonItem7.Caption = _resource.GetString("barButtonItem7");
            colsupDscntAmount.Caption = _resource.GetString("colsupDscntAmount");
            colsupTotalFinal.Caption = _resource.GetString("colsupTotalFinal");



            radioGroupPrintType.EditWidth = 67;
        }
    }
}
