using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class UCaccBox : XtraUserControl
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblBox clsTbBox = new ClsTblBox();
        ClsTblCurrency clsTbCurrency = new ClsTblCurrency();

        public string flyDialogMssg { set; get; }
        public bool flyDialogIsNew { set; get; }
        public int focusedRowHandle { set; get; }

        public UCaccBox()
        {
            InitializeComponent();
            //bbiNew.ItemShortcut = new BarShortcut(Keys.F2);
            //bbiEdit.ItemShortcut = new BarShortcut(Keys.F4);
            //bbiDelete.ItemShortcut = new BarShortcut(Keys.F6);
            //bbiRefresh.ItemShortcut = new BarShortcut(Keys.F5);
            //bbiPrintPreview.ItemShortcut = new BarShortcut(Keys.F7);
            GetResources();
            InitData();
            new ClsUserControlValidation(this, UserControls.Box);

            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
            gridView.DoubleClick += GridView_DoubleClick;
            gridControl.KeyDown += GridControl_KeyDown;
        }
        private void GridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
                bbiDelete.PerformClick();
        }

        private void InitData()
        {
            tblAccountBoxesBindingSource.DataSource = this.clsTbBox.GetBoxList;
            bsiRecordsCount.Caption = "RECORDS : " + tblAccountBoxesBindingSource.Count;
            tblAccountBox gr = new tblAccountBox();
            new ClsTblBranch().InitRepositoryItemBranchLookupEdit(gridControl, nameof(gr.boxBrnId));
        }

        private void RefreshData()
        {
            this.clsTbBox.RefreshData();
            InitData();
        }

        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "boxCurrency")
                e.DisplayText = this.clsTbCurrency.GetCurrencyNameById(Convert.ToByte(e.Value));
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            using (formAddBox frm = new formAddBox(this, null))
            {
                flyDialog.WaitForm(this, 0, frm);
                if (frm.ShowDialog() == DialogResult.OK)
                    RefreshListDialog();
            }
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblAccountBoxesBindingSource)) return;
            UpdateForm();
        }

        private void UpdateForm()
        {
            flyDialog.WaitForm(this, 1);
            using (formAddBox frm = new formAddBox(this, tblAccountBoxesBindingSource.Current as tblAccountBox))
            {
                flyDialog.WaitForm(this, 0, frm);
                if (frm.ShowDialog() == DialogResult.OK)
                    RefreshListDialog();
            }
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblAccountBoxesBindingSource)) return;
            DeleteRecord();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshData();
        }

        private void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        private void DeleteRecord()
        {
            var tbBox = gridView.GetFocusedRow() as tblAccountBox;
            if (tbBox == null) return;

            string delMssg = (!MySetting.GetPrivateSetting.LangEng) ? $"هل أنت متاكد من حذف الصندوق : {tbBox.boxName}؟" : $"Delete box : {tbBox.boxName}?";
            if (XtraMessageBox.Show(delMssg, "", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            flyDialog.WaitForm(this, 1);
            bool isFound = new ClsTblEntryMain().IsBoxNoFound(tbBox.boxNo);
            if (IsFound(isFound, tbBox.boxName)) return;

            isFound = new ClsTblEntrySub().IsAccNoFound(tbBox.boxAccNo);
            if (IsFound(isFound, tbBox.boxName)) return;

            isFound = new ClsTblSupplyMain().IsAccNoFound(tbBox.boxAccNo);
            if (IsFound(isFound, tbBox.boxName)) return;

            flyDialog.WaitForm(this, 0);

            if (!new ClsTblAccount().DeleteByAccNo(tbBox.boxAccNo)) return;
            if (!this.clsTbBox.Delete(tbBox)) return;

            string mssg = (!MySetting.GetPrivateSetting.LangEng) ? $"تم حذف الصندوق : {tbBox.boxName} بنجاح." : $"Successfully deleted box : {tbBox.boxName}.";
            tblAccountBoxesBindingSource.RemoveCurrent();
            flyDialog.ShowDialogUCCustomdMsg(this, mssg);
        }

        private bool IsFound(bool isFound, string boxName)
        {
            if (isFound) DeleteErrorMssg(boxName);
            return isFound;
        }

        private void DeleteErrorMssg(string boxName)
        {
            flyDialog.WaitForm(this, 0);
            string mssg = (!MySetting.GetPrivateSetting.LangEng) ?
                $"عذرا لا يمكن حذف الصندوق : {boxName} بسبب وجود قيود، سندات، او فواتير مرتبطه بلصندوق. \nيرجى حذف القيود/سندات/فواتير امرتبطه بلصندوق اولاً." :
                $"Sorry, could not delete box : {boxName} due to Entries, Vouchers or Onvoices found related to the bank. \nPlease delete all Entries/Vouchers/Invoices related to the box first.";
            XtraMessageBox.Show(mssg);
        }

        public void RefreshListDialog()
        {
            if (this.flyDialogIsNew)
                flyDialog.ShowDialogUC(this, this.flyDialogMssg);
            else
                flyDialog.ShowDialogUCUpdMsg(this, this.flyDialogMssg);

            RefreshData();
            gridView.FocusedRowHandle = gridView.LocateByValue("boxNo", this.focusedRowHandle);
        }

        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            gridControl.RightToLeft = RightToLeft.No;

            _ci = new CultureInfo("en");
            _resource = new ComponentResourceManager(typeof(Language.UCaccBoxEn));

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
