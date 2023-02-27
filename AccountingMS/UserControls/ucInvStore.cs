using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class ucInvStore : DevExpress.XtraEditors.XtraUserControl
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblStore clsTbStore;
        ClsTblInvStoreMain clsTbInvStoreMain;

        private InvType invType;
        private string flyDialogMssg;
        private bool isNew;
        private int invNo;

        private async void UcInvStore_Load(object sender, EventArgs e)
        {
            await InitObjectsAsync();
        //bbiExportPdf.Visibility=bbiExportXls.Visibility =this.invType == InvType.Direct? BarItemVisibility.Always: BarItemVisibility.Never;
            InitData();
        }

        public ucInvStore(InvType invType)
        {
            this.invType = invType;

            InitializeComponent();
            switch (invType)
            {
                case InvType.Manual:
                    new ClsUserControlValidation(this, UserControls.InvStoreManual);
                    break;
                case InvType.Direct:
                    new ClsUserControlValidation(this, UserControls.InvStoreDirect);
                    break;
                case InvType.Settlement:
                    new ClsUserControlValidation(this, UserControls.InvStoreSettlement);
                    break;
                default:
                    break;
            }
          
            InitEvents();
            SetProperties();
        }

        private void InitEvents()
        {
            this.Load += UcInvStore_Load;

            gridView.DoubleClick += GridView_DoubleClick;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
        }

        private void InitData()
        {
            tblInvStoreMainBindingSource.DataSource = this.clsTbInvStoreMain.GetInvStoreList(this.invType);
            bsiRecordsCount.Caption = MySetting.GetPrivateSetting.LangEng ? $"Count: {tblInvStoreMainBindingSource.Count}" :
                $"العدد: {tblInvStoreMainBindingSource.Count}";
            tblInvStoreMain st = new tblInvStoreMain();
            new ClsTblBranch().InitRepositoryItemBranchLookupEdit(gridControl, nameof(st.invBrnId));
        }

        private async Task InitObjectsAsync()
        {
            flyDialog.WaitForm(this, 1);
            IList<Task> taskList = new List<Task>();

            taskList.Add(Task.Run(() => this.clsTbStore = new ClsTblStore()));
            taskList.Add(Task.Run(() => this.clsTbInvStoreMain = new ClsTblInvStoreMain()));

            await Task.WhenAll(taskList);
            flyDialog.WaitForm(this, 0);
        }

        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == colinvStrId.FieldName) e.DisplayText = this.clsTbStore.GetStoreNameById(Convert.ToInt16(e.Value));
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            UpdateFormAsync();
        }

        private async void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            using var frm = new formAddInvStore(this, this.invType, null, this.clsTbStore, this.clsTbInvStoreMain);
            flyDialog.WaitForm(this, 0);

            if (frm.ShowDialog() == DialogResult.OK) await RefreshSavedDataAsync();
        }

        private async void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            await UpdateFormAsync();
        }

        private async Task UpdateFormAsync()
        {
            if (this.invType == InvType.Settlement) return;

            flyDialog.WaitForm(this, 1);
            using var frm = new formAddInvStore(this, this.invType, this.clsTbInvStoreMain.GetInvStoreObjById(Convert.ToInt32(gridView.GetFocusedRowCellValue(colid))), this.clsTbStore, this.clsTbInvStoreMain);
            flyDialog.WaitForm(this, 0);

            if (frm.ShowDialog() == DialogResult.OK) await RefreshSavedDataAsync();
        }

        private async void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ValidateDelete()) return;
            flyDialog.WaitForm(this, 1);

            await DeleteInvStoreAsync();
            await InitObjectsAsync();

            InitData();
        }

        private async Task DeleteInvStoreAsync()
        {
            var tbInvMain = gridView.GetRow(gridView.FocusedRowHandle) as tblInvStoreMain;
            ClsTblInvStoreSub clsTbInvSub = await Task.Run(() => new ClsTblInvStoreSub());

            try
            {
                await Task.Run(() => clsTbInvSub.RemoveInvSubListByMainId(tbInvMain.id));
                this.clsTbInvStoreMain.Remove(tbInvMain);

                flyDialog.WaitForm(this, 0);
                flyDialog.ShowDialogUCCustomdMsg(this, MySetting.GetPrivateSetting.LangEng ? $"Inventory number: {tbInvMain.invNo} has been removed successfully!" : $"تم حذف الجرد رقم: {tbInvMain.invNo} بنجاح!");
            }
            catch (Exception ex)
            {
                flyDialog.WaitForm(this, 0);
                new ExceptionLogger(ex, "uncInvStore", true);
            }
        }

        //private async Task<bool> DeletePrdQuantityAsync(tblInvStoreMain tbInvMain, ClsTblInvStoreSub clsTbInvSub)
        //{
        //    if (this.invType == InvType.Manual) return true;

        //    var tbPrdQuantityList = ClsStockPrdQuantityListConverter.InitPrdQuantityList(clsTbInvSub.GetInvStoreListByInvMainId(tbInvMain.id), tbInvMain.invStrId);

        //    if (await Task.Run(() => !new ClsPrdQuantityOperations().DeductPrdQuantity(tbPrdQuantityList)) ||
        //            await Task.Run(() => !new ClsPrdPriceQuanOperations().DeductPrdQuantity(tbPrdQuantityList))) return false;

        //    return true;
        //}

        private bool ValidateDelete()
        {
            if (!ClsBindingSource.Validate(tblInvStoreMainBindingSource)) return false;

            return ClsXtraMssgBox.ShowWarningYesNo(MySetting.GetPrivateSetting.LangEng ? $"Are you sure you want to delete Inventory Number: {gridView.GetFocusedRowCellValue(colinvNo)}?" : $"هل أنت متأكد من حذف الجرد رقم: {gridView.GetFocusedRowCellValue(colinvNo)}؟") == DialogResult.Yes ? true : false;
        }

        private async void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            await InitObjectsAsync();
            InitData();
        }

        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblInvStoreMainBindingSource)) return;
            flyDialog.WaitForm(this, 1);
          
            ReportType reportType = (this.invType) switch
            {
                InvType.Manual => ReportType.InvStoreManual,
                InvType.Direct => ReportType.InvStoreDirect,
                InvType.Settlement => ReportType.InvStoreSettlement,
            };

            var tbInvMain = gridView.GetRow(gridView.FocusedRowHandle) as tblInvStoreMain;
            var frm = new ReportForm(reportType, tblObject: tbInvMain);
            frm.Show();

            flyDialog.WaitForm(this, 0, frm);
        }

        private async Task RefreshSavedDataAsync()
        {
            await RefreshListDialogAsync();
            SetFoucesdRow();
        }

        private async Task RefreshListDialogAsync()
        {
            this.flyDialog.ShowDialogUC(this, this.flyDialogMssg, this.isNew);

            await InitObjectsAsync();
            InitData();
        }

        public void SetFoucesdRow()
        {
            gridView.FocusedRowHandle = gridView.LocateByValue(colinvNo.FieldName, invNo);
        }

        public void SetRefreshListDialog(string mssg, bool isNew, int invNo)
        {
            this.flyDialogMssg = mssg;
            this.isNew = isNew;
            this.invNo = invNo;
        }

        private void SetProperties()
        {
            bbiEdit.Visibility = this.invType == InvType.Settlement ? BarItemVisibility.Never : BarItemVisibility.Always;
            bbiDelete.Visibility = this.invType == InvType.Settlement ? BarItemVisibility.Never : BarItemVisibility.Always;
        }

        private void bbiExportXls_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.invType == InvType.Direct)
            {
                var tbInvMain = gridView.GetRow(gridView.FocusedRowHandle) as tblInvStoreMain;
                ReportInvStoreDirect reportInvStoreDirect = new ReportInvStoreDirect();
                reportInvStoreDirect.CreateDocument();
                reportInvStoreDirect.DataSource = tbInvMain;
                
                xtraSaveFileDialog1.Filter = "Excel Files|*.Xls";
                if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
                    reportInvStoreDirect.ExportToXls(xtraSaveFileDialog1.FileName);
                 
            }
        }

        private void bbiExportPdf_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.invType == InvType.Direct)
            {
                var tbInvMain = gridView.GetRow(gridView.FocusedRowHandle) as tblInvStoreMain;
                ReportInvStoreDirect reportInvStoreDirect = new ReportInvStoreDirect();
                reportInvStoreDirect.CreateDocument();
                reportInvStoreDirect.DataSource = tbInvMain;
               
                xtraSaveFileDialog1.Filter = "PDF Files|*.pdf";
                if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
                    reportInvStoreDirect.ExportToPdf(xtraSaveFileDialog1.FileName);
            }
        }
    }
}
