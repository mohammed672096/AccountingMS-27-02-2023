using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Globalization;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class UCcurrency : DevExpress.XtraEditors.XtraUserControl
    {
        accountingEntities dbContext;
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();

        public string flyDialogMssg { set; get; }
        public bool flyDialogIsNew { set; get; }
        public string focusedRowHandle { set; get; }

        public UCcurrency()
        {
            InitializeComponent();
            GetResources();
            InitData();

            new ClsUserControlValidation(this, UserControls.Currency);
        }

        private void InitData()
        {
            dbContext = new accountingEntities();
            dbContext.tblCurrencies.Load();
            tblCurrenciesBindingSource.DataSource = dbContext.tblCurrencies.Local.ToBindingList();
            bsiRecordsCount.Caption = "RECORDS : " + tblCurrenciesBindingSource.Count;
        }

        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            using (formAddCurrency frm = new formAddCurrency(this, null))
            {
                flyDialog.WaitForm(this, 0);
                if (frm.ShowDialog() == DialogResult.OK)
                    RefreshListDialog();
            }
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            using (formAddCurrency frm = new formAddCurrency(this, tblCurrenciesBindingSource.Current as tblCurrency))
            {
                flyDialog.WaitForm(this, 0);
                if (frm.ShowDialog() == DialogResult.OK)
                    RefreshListDialog();
            }
        }

        private void gridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            ClsColumnValues cv = new ClsColumnValues();

            if (e.Column.FieldName == "curType")
                e.DisplayText = cv.CurType(Convert.ToByte(e.Value));
        }

        public void RefreshListDialog()
        {
            if (this.flyDialogIsNew)
                flyDialog.ShowDialogUC(this, this.flyDialogMssg);
            else
                flyDialog.ShowDialogUCUpdMsg(this, this.flyDialogMssg);

            InitData();
            gridView.FocusedRowHandle = gridView.LocateByValue("curName", this.focusedRowHandle);
        }

        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            gridControl.RightToLeft = RightToLeft.No;

            _ci = new CultureInfo("en");
            _resource = new ComponentResourceManager(typeof(Language.UCcurrencyEn));

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
