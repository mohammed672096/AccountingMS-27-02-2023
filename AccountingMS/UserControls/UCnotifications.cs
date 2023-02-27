using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class UCnotifications : DevExpress.XtraEditors.XtraUserControl
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblNotification clsTbNotification;
        IList<tblNotificationDetail> tbNoDetailtList;

        private bool notIsComplete;
        private DateTime notDate;

        private async void UCnotifications_Load(object sender, EventArgs e)
        {
            InitEvents();
            await InitDataAsync();
            tblNotification st = new tblNotification();
            new ClsTblBranch().InitRepositoryItemBranchLookupEdit(gridControl, nameof(st.notBrnId));
        }

        public UCnotifications(ClsTblNotification clsTbNotification)
        {
            InitializeComponent();

            this.clsTbNotification = clsTbNotification;

            this.Load += UCnotifications_Load;
        }

        private void InitEvents()
        {
            gridView.RowStyle += GridView_RowStyle;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;

            this.clsTbNotification.RaiseNotificationsChanged += ClsTbNotification_RaiseNotificationsChanged;
        }

        private async Task InitDataAsync()
        {
            flyDialog.WaitForm(this, 1);

            //await InitObjectsAsync();
            await InitGridDataAsync();

            flyDialog.WaitForm(this, 0);
        }

        private async Task InitObjectsAsync()
        {
            await Task.Run(() => this.clsTbNotification = new ClsTblNotification());
        }

        private async Task InitGridDataAsync()
        {
            tblNotificationDetailBindingSource.DataSource = await Task.Run(() => this.clsTbNotification.GetNotListDetail);
            bsiRecordsCount.Caption = "عدد الإشعارات قيد المعالجة : " + await Task.Run(() => this.clsTbNotification.GetNotCountUnComplete);
        }

        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == colnotStatus.FieldName)
                e.DisplayText = ClsNotificationStatus.GetString(Convert.ToByte(e.Value));
            if (e.Column.FieldName == colnotIsComplete.FieldName)
                e.DisplayText = !Convert.ToBoolean(e.Value) ? "قيد الإنتظار" : "تم الإنتهاء";
        }

        private void GridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;

            this.notDate = Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, colnotDate));
            this.notIsComplete = Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, colnotIsComplete));

            if (!this.notIsComplete)
            {
                //e.Appearance.FontStyleDelta = this.notDate > DateTime.Now ? FontStyle.Regular : FontStyle.Bold;
                e.Appearance.FontStyleDelta = FontStyle.Bold;
                e.Appearance.ForeColor = this.notDate >= DateTime.Now ? DXSkinColors.ForeColors.Warning : DXSkinColors.ForeColors.Critical;
            }
            else
            {
                //e.Appearance.FontStyleDelta = FontStyle.Strikeout;
                e.Appearance.ForeColor = DXSkinColors.ForeColors.Information;
            }

            if (view.IsRowSelected(e.RowHandle))
            {
                e.Appearance.ForeColor = Color.White;
                e.Appearance.BackColor = DXSkinColors.FillColors.Primary;
            }

            e.HighPriority = true;
        }

        private void ClsTbNotification_RaiseNotificationsChanged(object sender, EventArgs e)
        {
            //InitDataAsync();
            //await InitDataAsync();
        }

        private void bbiShowHideSelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView.OptionsSelection.MultiSelect = !gridView.IsMultiSelect;
        }

        private async void bbiCompleted_ItemClick(object sender, ItemClickEventArgs e)
        {
            await UpdateNotificationStatus(true);
        }

        private async void bbiUnComplete_ItemClick(object sender, ItemClickEventArgs e)
        {
            await UpdateNotificationStatus(false);
        }

        private async void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            await InitDataAsync();
        }

        private void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        private async Task UpdateNotificationStatus(bool isComplete)
        {
            if (!ClsBindingSource.Validate(tblNotificationDetailBindingSource)) return;
            if (!ValidateUpdateStatus(isComplete)) return;

            await InitSelectedListAsync();

            if (await UpdateTblNotificationStatus(isComplete))
                flyDialog.ShowDialogUCCustomdMsg(this, "تمت العملية بنجاح");

            await InitDataAsync();

            gridView.OptionsSelection.MultiSelect = false;
        }

        private async Task<bool> UpdateTblNotificationStatus(bool isComplete)
        {
            return await Task.Run(() => this.clsTbNotification.UpdateNotStatus(this.tbNoDetailtList, isComplete));
        }

        private async Task InitSelectedListAsync()
        {
            this.tbNoDetailtList?.Clear();
            this.tbNoDetailtList = new List<tblNotificationDetail>();

            await Task.Run(() =>
            {
                for (short i = 0; i < gridView.SelectedRowsCount; i++)
                    this.tbNoDetailtList.Add(gridView.GetRow(gridView.GetSelectedRows()[i]) as tblNotificationDetail);
            });
        }

        private bool ValidateUpdateStatus(bool isComplete)
        {
            string mssg = $"هل أنت متأكد من تغير حالة الإشعارات إلى: {(isComplete ? "تم الإنتهاء" : "قيد المعالجة")} ؟";
            return ClsXtraMssgBox.ShowWarningYesNo(mssg) == DialogResult.Yes ? true : false;
        }
    }
}
