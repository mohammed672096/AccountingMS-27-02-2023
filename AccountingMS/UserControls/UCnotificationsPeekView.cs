using System;
using System.Threading.Tasks;

namespace AccountingMS
{
    public partial class UCnotificationsPeekView : DevExpress.XtraEditors.XtraUserControl
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblNotification clsTbNotification;

        //private  void UCnotificationsPeekView_Load(object sender, EventArgs e)
        private async void UCnotificationsPeekView_Load(object sender, EventArgs e)
        {
            await InitDataAsync();
            //InitGridData();
            InitEvents();
        }

        public UCnotificationsPeekView(ClsTblNotification clsTbNotification)
        {
            InitializeComponent();

            layoutView1.CardCaptionFormat = "تاريخ الإستحقاق: {6}";

            this.clsTbNotification = clsTbNotification;

            //this.clsTbNotification.RaiseNotificationsChanged += ClsTbNotification_RaiseNotificationsChanged;

            this.Load += UCnotificationsPeekView_Load;
        }

        private void InitEvents()
        {
            layoutView1.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
        }

        private async Task InitDataAsync()
        {

            //await InitObjectsAsync();
            await InitGridDataAsync();

        }

        private async Task InitObjectsAsync()
        {
            await Task.Run(() => this.clsTbNotification = new ClsTblNotification());
        }

        private async Task InitGridDataAsync()
        {
            //tblNotificationBindingSource.DataSource = await Task.Run(() => this.clsTbNotification.GetNotListByDate);
            gridControl1.DataSource = await Task.Run(() => this.clsTbNotification.GetNotListSupByDate);
        }

        private void InitGridData()
        {
            gridControl1.DataSource = this.clsTbNotification?.GetNotListSupByDate;
            //tblNotificationBindingSource.DataSource = this.clsTbNotification?.GetNotListByDate;
        }

        private void ClsTbNotification_RaiseNotificationsChanged(object sender, EventArgs e)
        {
            //Task.Run(() => InitGridData());
            InitGridData();
            //await Task.Run(() => InitGridData());
            //await InitGridDataAsync();
        }

        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == colnotStatus.FieldName)
                e.DisplayText = ClsNotificationStatus.GetString(Convert.ToByte(e.Value));
        }
    }
}
