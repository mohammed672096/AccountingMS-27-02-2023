using AccountingMS.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using System;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class UCcustomers : XtraUserControl
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        accountingEntities dbContext = new accountingEntities();
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblCurrency clsTbCurrency = new ClsTblCurrency();

        public string flyDialogMssg { set; get; }
        public bool flyDialogIsNew { set; get; }
        public int focusedRowHandle { set; get; }


        public UCcustomers()
        {
            InitializeComponent();
            //bbiNew.ItemShortcut = new BarShortcut(Keys.F2);
            //bbiEdit.ItemShortcut = new BarShortcut(Keys.F3);
            //bbiDelete.ItemShortcut = new BarShortcut(Keys.F6);
            //bbiRefresh.ItemShortcut = new BarShortcut(Keys.F5);
            //bbiPrintPreview.ItemShortcut = new BarShortcut(Keys.F7);
            GetResources();
            new ClsUserControlValidation(this, UserControls.Customers);

            gridControl.KeyDown += GridControl_KeyDown;
            gridView.DoubleClick += GridView_DoubleClick;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
        }

        private void GridControl_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F6:
                    bbiDelete.PerformClick();
                    break;
                case Keys.F2:
                    bbiNew.PerformClick();
                    break;
                case Keys.F3:
                    bbiEdit.PerformClick();
                    break;
                case Keys.F5:
                    bbiRefresh.PerformClick();
                    break;
                case Keys.F7:
                    bbiPrintPreview.PerformClick();
                    break;
            }
        }
        private void UCcustomers_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void InitData()
        {
            if (Session.CurrentUser.id == 1)
                tblCustomersBindingSource.DataSource = dbContext.tblCustomers.ToList();
            else
                tblCustomersBindingSource.DataSource = (from a in dbContext.tblCustomers
                                                        where a.custBrnId == Session.CurBranch.brnId
                                                        select a).ToList();
            bsiRecordsCount.Caption = "RECORDS : " + tblCustomersBindingSource.Count;
            tblCustomer gr = new tblCustomer();
            new ClsTblBranch().InitRepositoryItemBranchLookupEdit(gridControl, nameof(gr.custBrnId));
        }

        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "custCurrency")
                e.DisplayText = this.clsTbCurrency.GetCurrencyNameById(Convert.ToByte(e.Value));
            else if (e.Column.FieldName == "custSalePrice" && e.Value != null)
                e.DisplayText = EnumExtensionMethods.GetDescription((SalePriceAr)Convert.ToByte(e.Value));
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            UpdateButton();
        }


        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            using (formAddCustomer frm = new formAddCustomer(this, null))
            {
                flyDialog.WaitForm(this, 0);
                frm.Height = MySetting.GetPrivateSetting.formAddCustomerH;
                frm.Width = MySetting.GetPrivateSetting.formAddCustomerW;
                frm.StartPosition = FormStartPosition.CenterScreen;
                if (frm.ShowDialog() == DialogResult.OK)
                    RefreshListDialog();
            }
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblCustomersBindingSource)) return;
            UpdateButton();
        }

        private void UpdateButton()
        {
            flyDialog.WaitForm(this, 1);
            using (formAddCustomer frm = new formAddCustomer(this, tblCustomersBindingSource.Current as tblCustomer))
            {
                flyDialog.WaitForm(this, 0);
                frm.Height = MySetting.GetPrivateSetting.formAddCustomerH;
                frm.Width = MySetting.GetPrivateSetting.formAddCustomerW;
                frm.StartPosition = FormStartPosition.CenterScreen;
                if (frm.ShowDialog() == DialogResult.OK)
                    RefreshListDialog();
            }
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            InitData();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblCustomersBindingSource)) return;


            string custName = gridView.GetFocusedRowCellValue(colcustName).ToString();
            string mssg = ((!MySetting.GetPrivateSetting.LangEng ? "هل انت متاكد من حذف العميل: " : "Delete customer : "));// + custName);

            if (XtraMessageBox.Show(mssg, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            int[] g = gridView.GetSelectedRows();
            for (int i = 0; i < g.Length; i++)
            {
                int selectedRowHandle = g[i];
                //Int64 accNo = Convert.ToInt64(gridView.GetFocusedRowCellValue(colcustAccNo));
                Int64 accNo = Convert.ToInt64(gridView.GetRowCellValue(selectedRowHandle, colcustAccNo));
                if (dbContext.tblAccounts.Any(x => x.accNo == accNo))
                    if (!new ClsTblAccount().DeleteByAccNo(accNo)) return;
                int cusId = Convert.ToInt32(gridView.GetRowCellValue(selectedRowHandle, colid));
                dbContext.tblCustomers.Remove(dbContext.tblCustomers.FirstOrDefault(x => x.id == cusId));
                //  dbContext.tblCustomers.Remove(tblCustomersBindingSource.Current as tblCustomer);
            }
            if (!SaveDB()) return;
            InitData();
            //tblCustomersBindingSource.RemoveCurrent();

            flyDialog.ShowDialogUCCustomdMsg(this, (!MySetting.GetPrivateSetting.LangEng) ? string.Format("تم حذف العملاء المحددين وعددهم : {0} بنجاح", g.Length) :
                    string.Format("Customer {0} deleted successfully", g.Length));

        }
        //   private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    if (!ClsBindingSource.Validate(tblCustomersBindingSource)) return;
        //    string custName = gridView.GetFocusedRowCellValue(colcustName).ToString();
        //    string mssg = ((!MySetting.GetPrivateSetting.LangEng ? "هل انت متاكد من حذف العميل: " : "Delete customer : ") + custName);

        //    if (XtraMessageBox.Show(mssg, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        //    Int64 accNo = Convert.ToInt64(gridView.GetFocusedRowCellValue(colcustAccNo));
        //    if (dbContext.tblAccounts.Any(x=>x.accNo== accNo))
        //    if (!new ClsTblAccount().DeleteByAccNo(accNo)) return;
        //    int cusId = Convert.ToInt32(gridView.GetFocusedRowCellValue(colid));
        //    dbContext.tblCustomers.Remove(dbContext.tblCustomers.FirstOrDefault(x => x.id == cusId));
        //  //  dbContext.tblCustomers.Remove(tblCustomersBindingSource.Current as tblCustomer);
        //    if (!SaveDB()) return;

        //    tblCustomersBindingSource.RemoveCurrent();
        //    flyDialog.ShowDialogUCCustomdMsg(this, (!MySetting.GetPrivateSetting.LangEng) ? string.Format("تم حذف العميل: {0} بنجاح", custName) :
        //            string.Format("Customer {0} deleted successfully", custName));

        //}

        public void RefreshListDialog()
        {
            if (this.flyDialogIsNew)
                flyDialog.ShowDialogUC(this, this.flyDialogMssg);
            else
                flyDialog.ShowDialogUCUpdMsg(this, this.flyDialogMssg);

            InitData();
            gridView.FocusedRowHandle = gridView.LocateByValue("custNo", this.focusedRowHandle);
        }

        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            gridControl.RightToLeft = RightToLeft.No;

            _ci = new CultureInfo("en");
            _resource = new ComponentResourceManager(typeof(Language.UCcustomersEn));

            foreach (var control in ribbonControl.Manager.Items)
            {
                if (control is BarButtonItem)
                {
                    BarButtonItem c = control as BarButtonItem;
                    _resource.ApplyResources(c, c.Name, _ci);
                }
            }
            foreach (GridColumn c in gridView.Columns)
            {
                _resource.ApplyResources(c, c.Name, _ci);
            }

            _resource.ApplyResources(ribbonPage1, ribbonPage1.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup1, ribbonPageGroup1.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup2, ribbonPageGroup2.Name, _ci);
        }

        private bool SaveDB()
        {
            return ClsSaveDB.Save(dbContext, LogHelper.GetLogger());
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            formFoaterCustmer frm = new formFoaterCustmer();
            frm.Show();
            frm.SearchCustmer(Convert.ToInt32(gridView.GetRowCellValue(gridView.FocusedRowHandle, "custNo")), gridView.GetRowCellValue(gridView.FocusedRowHandle, "custName").ToString());


        }



    }
}
