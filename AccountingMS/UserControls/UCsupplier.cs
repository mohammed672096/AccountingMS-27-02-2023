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
    public partial class UCsupplier : XtraUserControl
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        accountingEntities db = new accountingEntities();
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblCurrency clsTbCurrency = new ClsTblCurrency();

        private void UCsupplier_Load(object sender, EventArgs e)
        {
            InitData();
        }

        public UCsupplier()
        {
            InitializeComponent();
            //bbiNew.ItemShortcut =new BarShortcut(Keys.F2);
            //bbiEdit.ItemShortcut = new BarShortcut(Keys.F4);
            //bbiDelete.ItemShortcut = new BarShortcut(Keys.F6);
            //bbiRefresh.ItemShortcut= new BarShortcut(Keys.F5);
            //bbiPrintPreview.ItemShortcut = new BarShortcut(Keys.F7);
            GetResources();
            new ClsUserControlValidation(this, UserControls.Suppliers);
          
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
            gridView.DoubleClick += GridView_DoubleClick;
            gridControl.KeyDown += GridControl_KeyDown;
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
        private void InitData()
        {
            if (Session.CurrentUser.id == 1)
                bindingSource1.DataSource = db.tblSuppliers.ToList();
            else bindingSource1.DataSource = (from a in db.tblSuppliers
                                              where a.splBrnId == Session.CurBranch.brnId
                                              select a).ToList();
            bsiRecordsCount.Caption = "RECORDS : " + bindingSource1.Count;
            tblSupplier gr = new tblSupplier();
            new ClsTblBranch().InitRepositoryItemBranchLookupEdit(gridControl, nameof(gr.splBrnId));
        }
        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "splCurrency")
                e.DisplayText = this.clsTbCurrency.GetCurrencyNameById(Convert.ToByte(e.Value));
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            UpdateForm();
        }

        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            new formAddSupplier(null, this).Show();
            flyDialog.WaitForm(this, 0);
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(bindingSource1)) return;
            UpdateForm();
        }

        private void UpdateForm()
        {
            flyDialog.WaitForm(this, 1);
            var frm = new formAddSupplier(bindingSource1.Current as tblSupplier, this);
            frm.Show();
            flyDialog.WaitForm(this, 0, frm);
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            InitData();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(bindingSource1)) return;

            string splName = gridView.GetFocusedRowCellValue(colsplName).ToString();
            string mssg = ((!MySetting.GetPrivateSetting.LangEng) ? "هل انت متاكد من حذف المورد: " : "Delete supplier : " )+ splName;

            if (XtraMessageBox.Show(mssg, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
          //  if (!new ClsTblAccount().DeleteByAccNo(Convert.ToInt64(gridView.GetFocusedRowCellValue(colsplAccNo)))) return;
            Int64 accNo = Convert.ToInt64(gridView.GetFocusedRowCellValue(colsplAccNo));
            if (db.tblAccounts.Any(x => x.accNo == accNo))
                if (!new ClsTblAccount().DeleteByAccNo(accNo)) return;
            int cusId = Convert.ToInt32(gridView.GetFocusedRowCellValue(colid));
            db.tblSuppliers.Remove(db.tblSuppliers.FirstOrDefault(x => x.id == cusId));
            //db.tblSuppliers.Remove(bindingSource1.Current as tblSupplier);
            if (!SaveDB()) return;

            bindingSource1.RemoveCurrent();
            flyDialog.ShowDialogUCCustomdMsg(this, (!MySetting.GetPrivateSetting.LangEng) ? string.Format("تم حذف المورد: {0} بنجاح", splName) :
                    string.Format("Supplier {0} deleted successfully", splName));
        }

        public void RefreshListDialog(string name, bool isNew)
        {
            if (isNew)
                flyDialog.ShowDialogUC(this, name);
            else
                flyDialog.ShowDialogUCUpdMsg(this, name);

            InitData();
        }

        public void SetFocusedRow(int splNo)
        {
            gridView.FocusedRowHandle = gridView.LocateByValue("splNo", splNo);
        }

        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            gridControl.RightToLeft = RightToLeft.No;

            _ci = new CultureInfo("en");
            _resource = new ComponentResourceManager(typeof(Language.UCsupplierEn));

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
            return ClsSaveDB.Save(db, LogHelper.GetLogger());
        }
    }
}
