using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class ucOrders : XtraUserControl
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblUser clsTbUser;
        ClsTblOrderMain clsTbOrderMain;
        ClsTblOrderSub clsTbOrderSub;
        ClsTblProduct clsTbProduct;
        ClsTblPrdPriceMeasurment clsTbPrdMsur;
        tblOrderMain tbOrderMain;
        IEnumerable<tblOrderSub> tbOrderSubList;
        CultureInfo _ci;
        ComponentResourceManager _resource;

        private readonly OrderType orderType;
        private readonly dynamic formSupply;
        private bool isNew;
        private string flyDialogMssg;
   

        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            gridControl.RightToLeft = RightToLeft.No;

            _ci = new CultureInfo("en");
            _resource = new ComponentResourceManager(typeof(Language.ucOrderEn));

            foreach (var control in ribbonControl.Manager.Items)
            {
                if (control is BarButtonItem)
                {
                    BarButtonItem c = control as BarButtonItem;
                    c.Visibility = BarItemVisibility.Always;
                    _resource.ApplyResources(c, c.Name, _ci);
                }
            }
            foreach (GridColumn c in gridView.Columns)
            {
                _resource.ApplyResources(c, c.Name, _ci);
            }
            ribbonPage1.Visible = true;
            _resource.ApplyResources(ribbonPage1, ribbonPage1.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup1, ribbonPageGroup1.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup2, ribbonPageGroup2.Name, _ci);
        }
        public ucOrders(OrderType orderType, dynamic formSupply = null)
        {
            this.orderType = orderType;
            this.formSupply = formSupply;

            InitializeComponent();
            GetResources();
            //new ClsUserControlValidation(this, UserControls.OfferPrice);
            //InitFormSupplyProperties();
            //InitText();

            gridView.DoubleClick += GridView_DoubleClick;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
        }

        private async void ucOrders_Load(object sender, EventArgs e)
        {
            await InitDataAsync();
        }

        private async Task InitDataAsync()
        {
            flyDialog.WaitForm(this, 1);

            await InitObjectsAsync();
            InitData();

            flyDialog.WaitForm(this, 0);
        }

        private async Task InitObjectsAsync()
        {
            IList<Task> taskList = new List<Task>() {
                Task.Run(() => this.clsTbUser = new ClsTblUser()),
                Task.Run(() => this.clsTbProduct = new ClsTblProduct()),
                Task.Run(() => this.clsTbPrdMsur = new ClsTblPrdPriceMeasurment()),
                Task.Run(() => this.clsTbOrderMain = new ClsTblOrderMain(this.orderType)),
                Task.Run(() => this.clsTbOrderSub = new ClsTblOrderSub(this.orderType)),
            };

            await Task.WhenAll(taskList);
        }

        private void InitData()
        {
            tblOrderMainBindingSource.DataSource = this.clsTbOrderMain.GetOrderList;
            bsiRecordsCount.Caption = $"{(!MySetting.GetPrivateSetting.LangEng ? "العدد:" : "RECORDS:")} {tblOrderMainBindingSource.Count}";
            tblOrderMain st = new tblOrderMain();
            new ClsTblBranch().InitRepositoryItemBranchLookupEdit(gridControl, nameof(st.ordBrnId));
        }

        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == colordUsrId.FieldName) e.DisplayText = this.clsTbUser.GetUserNameById(Convert.ToInt16(e.Value));
        }

        private async void GridView_DoubleClick(object sender, EventArgs e)
        {
            if (this.formSupply == null) await UpdateOrderAsync();
            else InitOrderSupply();
        }

        private void InitOrderSupply()
        {
            if (!ClsBindingSource.Validate(tblOrderMainBindingSource)) return;
            flyDialog.WaitForm(this, 1);

            var tbOrder = tblOrderMainBindingSource.Current as tblOrderMain;
            var tbOrderSubList = this.clsTbOrderSub.GetOrderListByMainId(tbOrder.ordId);

            flyDialog.WaitForm(this, 0);
            this.formSupply.InitOrderSupply(tbOrder, tbOrderSubList);
        }

        private async void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            using var form = new formAddOrder(this, this.orderType, this.clsTbOrderMain, this.clsTbOrderSub, this.clsTbProduct, this.clsTbPrdMsur);
            flyDialog.WaitForm(this, 0);

            if (form.ShowDialog() == DialogResult.OK) await CloseFormMethodsAsync();
        }

        private async Task UpdateOrderAsync()
        {
            flyDialog.WaitForm(this, 1);
            using var form = new formAddOrder(this, this.orderType, this.clsTbOrderMain, this.clsTbOrderSub, this.clsTbProduct, this.clsTbPrdMsur, tblOrderMainBindingSource.Current as tblOrderMain);
            flyDialog.WaitForm(this, 0);

            if (form.ShowDialog() == DialogResult.OK) await CloseFormMethodsAsync();
        }

        private async void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblOrderMainBindingSource)) return;
            await UpdateOrderAsync();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblOrderMainBindingSource)) return;
            DeleteRecord();
        }

        private async void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            await InitDataAsync();
        }

        private void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblOrderMainBindingSource)) return;
            PrintInvoice(tblOrderMainBindingSource.Current as tblOrderMain);
        }

        private void PrintInvoice(tblOrderMain tbOrderMain)
        {
            if (MySetting.DefaultSetting.ordersShowPrintMssg) PrintInvoiceMssg(tbOrderMain);
            else Print(tbOrderMain);
        }

        private void PrintInvoiceMssg(tblOrderMain tbOrderMain)
        {
            if (ClsXtraMssgBox.ShowQuesPrint((!MySetting.GetPrivateSetting.LangEng) ? $"هل تريد طباعة الفاتورة رقم: {tbOrderMain.ordNo}"
                : $"Do you want to print Invoice no.: {tbOrderMain.ordNo}") != DialogResult.Yes) return;
            Print(tbOrderMain);
        }

        private void Print(tblOrderMain tbOrderMain)
        {
            //flyDialog.WaitForm(this, 1);
            //if (MySetting.DefaultSetting.ordersPrintPreview)   var frm = new ReportForm(ReportType.OrderInvoice, tblObject: tbOrderMain,
            //    tblObjectList: this.clsTbOrderSub.GetOrderListByMainId(tbOrderMain.ordId), clsTbProduct: this.clsTbProduct, clsTbPrdMsur: this.clsTbPrdMsur).Show();
            //else ClsPrintReport.PrintOrder(tbOrderMain, this.clsTbOrderSub.GetOrderListByMainId(tbOrderMain.ordId), this.clsTbProduct, this.clsTbPrdMsur);
            //flyDialog.WaitForm(this, 0);
            flyDialog.WaitForm(this, 1);
            if (MySetting.DefaultSetting.ordersPrintPreview & !MySetting.DefaultSetting.rprtOrderA4CustomRpt)
            {
                var frm = new ReportForm(ReportType.OrderInvoice, tblObject: tbOrderMain,
               tblObjectList: this.clsTbOrderSub.GetOrderListByMainId(tbOrderMain.ordId),
               clsTbProduct: this.clsTbProduct, clsTbPrdMsur: this.clsTbPrdMsur);
                frm.Show();
                flyDialog.WaitForm(this, 0, frm);
            }
            else if (MySetting.DefaultSetting.ordersPrintPreview & MySetting.DefaultSetting.rprtOrderA4CustomRpt)
            {
                var frm = new ReportForm(ReportType.OrderCustom, tblObject: tbOrderMain,
                    tblObjectList: this.clsTbOrderSub.GetOrderListByMainId(tbOrderMain.ordId));
                frm.Show();
                flyDialog.WaitForm(this, 0, frm);
            }
            else
            {
                ClsPrintReport.PrintOrder(tbOrderMain, this.clsTbOrderSub.GetOrderListByMainId(tbOrderMain.ordId),
                this.clsTbProduct, this.clsTbPrdMsur);
                flyDialog.WaitForm(this, 0);
            }
           

        }

        private void DeleteRecord()
        {
            if (tblOrderMainBindingSource.Count == 0) return;
            if (DeleteRowMssg(out tblOrderMain tbOrderMain, out string orderString) != DialogResult.Yes) return;
            flyDialog.WaitForm(this, 1);

            this.clsTbOrderMain.Remove(tbOrderMain);
            this.clsTbOrderSub.RemoveByMainId(tbOrderMain.ordId);
            if (!this.clsTbOrderMain.SaveDB || !this.clsTbOrderSub.SaveDB) return;

            tblOrderMainBindingSource.RemoveCurrent();
            flyDialog.ShowDialogUCCustomdMsg(this, (!MySetting.GetPrivateSetting.LangEng) ? $"تم حذف {orderString} بنجاح!" : $"Successfully deleted {orderString}!");
            InitData();
            flyDialog.WaitForm(this, 0);
        }

        private DialogResult DeleteRowMssg(out tblOrderMain tbOrderMain, out string orderString)
        {
            tbOrderMain = tblOrderMainBindingSource.Current as tblOrderMain;
            orderString = (!MySetting.GetPrivateSetting.LangEng) ? $"{ClsOrderStatus.GetString(this.orderType)} رقم: {tbOrderMain.ordNo}" : $"order no.: {tbOrderMain.ordNo}";

            return ClsXtraMssgBox.ShowWarningYesNo((!MySetting.GetPrivateSetting.LangEng) ? $"هل أنت متاكد من حذف {orderString}؟" : $"Delete {orderString}?");
        }

        private async Task CloseFormMethodsAsync()
        {
            await RefreshListDialogAsync();
            SetFocusedRow();
            PrintInvoice(this.tbOrderMain);
        }

        public void SetRefreshListDialog(string mssg, tblOrderMain tbOrderMain, IEnumerable<tblOrderSub> tbOrderSubList, bool isNew)
        {
            this.isNew = isNew;
            this.flyDialogMssg = mssg;
            this.tbOrderMain = tbOrderMain;
            this.tbOrderSubList = tbOrderSubList;
        }

        private async Task RefreshListDialogAsync()
        {
            flyDialog.ShowDialogUC(this, this.flyDialogMssg, this.isNew);
            await InitDataAsync();
        }

        private void SetFocusedRow()
        {
            gridView.FocusedRowHandle = gridView.LocateByValue(colordNo.FieldName, this.tbOrderMain.ordNo);
        }

        private void InitFormSupplyProperties()
        {
            if (this.formSupply == null) return;

            ribbonControl.Visible = false;
            ribbonStatusBar.Visible = false;
        }

        private void InitText()
        {
            if (this.orderType != OrderType.PriceOffer) return;
            colordNo.Caption = "رقم الفاتورة";
        }
    }
}
