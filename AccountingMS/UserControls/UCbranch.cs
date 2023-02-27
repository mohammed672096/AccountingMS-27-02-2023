using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class UCbranch : XtraUserControl
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        accountingEntities db = new accountingEntities();

        public UCbranch()
        {
            InitializeComponent();
            GetResources();
            InitData();

            new ClsUserControlValidation(this, UserControls.Branch);

            gridView1.DoubleClick += GridView1_DoubleClick;
        }

        private void InitData()
        {
            tblBranchBindingSource.DataSource = new ClsTblBranch(true).GetBranchList();
            bsCount.Caption = _resource.GetString("count") + tblBranchBindingSource.Count;
        }

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void bbSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            //flyDialog.WaitForm(this, 1);
            new formAddBranch(this, null).Show();
            //flyDialog.WaitForm(this, 0);
        }

        private void UpdateForm()
        {
            //flyDialog.WaitForm(this, 1);
            new formAddBranch(this, tblBranchBindingSource.Current as tblBranch).Show();
            //flyDialog.WaitForm(this, 0);
        }

        private void bbEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            UpdateForm();
        }

        private void bbRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            InitData();
        }

        public void RefreshListDialog(string mssg, bool isNew)
        {
            if (isNew)
                flyDialog.ShowDialogUC(this, mssg);
            else
                flyDialog.ShowDialogUCUpdMsg(this, mssg);

            InitData();
        }

        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng)
            {
                _ci = new CultureInfo("ar");
                _resource = new ComponentResourceManager(typeof(Language.SystemManagementAr));
            }
            else
            {
                _ci = new CultureInfo("en");
                _resource = new ComponentResourceManager(typeof(Language.UCBranchEn));
            }

            if (MySetting.GetPrivateSetting.LangEng) EnglishTranslation();
        }

        private void EnglishTranslation()
        {
            this.RightToLeft = RightToLeft.No;
            gridControl1.RightToLeft = RightToLeft.No;

            foreach (var control in ribbonControl.Manager.Items)
            {
                if (control is BarButtonItem c)
                    _resource.ApplyResources(c, c.Name, _ci);
            }
            foreach (GridColumn c in gridView1.Columns)
                _resource.ApplyResources(c, c.Name, _ci);

            _resource.ApplyResources(ribbonPage1, ribbonPage1.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup1, ribbonPageGroup1.Name, _ci);
            colbrnName.Visible = false;
            colbrnAddress.Visible = false;
            colbrnNameEn.Visible = true;
            colbrnAddressEn.Visible = true;
        }

        private bool SaveDB()
        {
            return ClsSaveDB.Save(db, LogHelper.GetLogger());
        }
    }
}
