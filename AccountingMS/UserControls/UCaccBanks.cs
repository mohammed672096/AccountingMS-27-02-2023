using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class UCaccBanks : XtraUserControl
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblBank clsTbBank = new ClsTblBank();
        ClsTblCurrency clsTbCurrency = new ClsTblCurrency();

        public string flyDialogMssg { set; get; }
        public bool flyDialogIsNew { set; get; }
        public int focusedRowHandle { set; get; }

        public UCaccBanks()
        {
            InitializeComponent();
            GetResources();
            InitData();
            new ClsUserControlValidation(this, UserControls.Bank);

            gridView.DoubleClick += GridView_DoubleClick;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
            gridControl.KeyDown += GridControl_KeyDown;
        }
        private void GridControl_KeyDown(object sender, KeyEventArgs e)
        {   if(e.KeyCode==Keys.F6)
            bbiDelete.PerformClick();
        }

        private void InitData()
        {
            tblAccountBanksBindingSource.DataSource = this.clsTbBank.GetTblBankList;
            bsiRecordsCount.Caption = "RECORDS : " + tblAccountBanksBindingSource.Count;
            tblAccountBank gr = new tblAccountBank();
            new ClsTblBranch().InitRepositoryItemBranchLookupEdit(gridControl, nameof(gr.bankBrnId));
        }

        private void RefreshData()
        {
            this.clsTbBank.RefreshData();
            InitData();
        }

        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "bankCurrency")
                e.DisplayText = this.clsTbCurrency.GetCurrencyNameById(Convert.ToByte(e.Value));
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            using (formAddBank frm = new formAddBank(this, null))
            {
                flyDialog.WaitForm(this, 0, frm);
                if (frm.ShowDialog() == DialogResult.OK)
                    RefreshListDialog();
            }
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblAccountBanksBindingSource)) return;
            UpdateForm();
        }

        private void UpdateForm()
        {
            flyDialog.WaitForm(this, 1);
            using (formAddBank frm = new formAddBank(this, tblAccountBanksBindingSource.Current as tblAccountBank))
            {
                flyDialog.WaitForm(this, 0,frm);
                if (frm.ShowDialog() == DialogResult.OK)
                    RefreshListDialog();
            }
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblAccountBanksBindingSource)) return;
            DeletetRecord();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshData();
        }

        private void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        private void DeletetRecord()
        {
            var tbBank = gridView.GetFocusedRow() as tblAccountBank;
            if (tbBank == null) return;

            string delMssg = (!MySetting.GetPrivateSetting.LangEng) ? $"هل أنت متاكد من حذف البنك : {tbBank.bankName}؟" : $"Delete bank : {tbBank.bankName}?";
            if (XtraMessageBox.Show(delMssg, "", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            flyDialog.WaitForm(this, 1);

            bool isFound = new ClsTblEntrySub().IsAccNoFound(tbBank.bankAccNo);
            if (IsFound(isFound, tbBank.bankName)) return;

            isFound = new ClsTblSupplyMain().IsAccNoFound(tbBank.bankAccNo);
            if (IsFound(isFound, tbBank.bankName)) return;

            flyDialog.WaitForm(this, 0);

            if (!new ClsTblAccount().DeleteByAccNo(tbBank.bankAccNo)) return;
            if (!this.clsTbBank.Delete(tbBank)) return;

            string mssg = (!MySetting.GetPrivateSetting.LangEng) ? $"تم حذف البنك : {tbBank.bankName} بنجاح." :
                                                                   $"Successfully deleted bank : {tbBank.bankName}.";
            flyDialog.ShowDialogUCCustomdMsg(this, mssg);
            tblAccountBanksBindingSource.RemoveCurrent();
        }

        private bool IsFound(bool isFound, string bankName)
        {
            if (isFound) DeleteErrorMssg(bankName);
            return isFound;
        }

        private void DeleteErrorMssg(string bankName)
        {
            flyDialog.WaitForm(this, 0);
            string mssg = (!MySetting.GetPrivateSetting.LangEng) ? $"عذرا لا يمكن حذف البنك : {bankName} بسبب وجود سندات او فواتير مرتبطه بلبنك. \nيرجى حذف السندات/الفواتير المرتبطه بلبنك أولاً." :
                            $"Sorry, could not delete bank : {bankName} due to Vouchers or Invoices found related to the bank. \nPlease delete all Vouchers/Invoices related to the bank first.";
            XtraMessageBox.Show(mssg);
        }

        public void RefreshListDialog()
        {
            if (this.flyDialogIsNew)
                flyDialog.ShowDialogUC(this, this.flyDialogMssg);
            else
                flyDialog.ShowDialogUCUpdMsg(this, this.flyDialogMssg);

            RefreshData();
            gridView.FocusedRowHandle = gridView.LocateByValue("bankNo", this.focusedRowHandle);
        }

        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            gridControl.RightToLeft = RightToLeft.No;

            _ci = new CultureInfo("en");
            _resource = new ComponentResourceManager(typeof(Language.UCaccBanksEn));

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

            ribbonPage1.Text = _resource.GetString("ribbonPage1.Text");
            ribbonPageGroup1.Text = _resource.GetString("ribbonPageGroup1.Text");
            ribbonPageGroup2.Text = _resource.GetString("ribbonPageGroup2.Text");
        }
    }
}
