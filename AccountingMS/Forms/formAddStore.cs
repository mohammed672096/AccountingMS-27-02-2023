using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formAddStore : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        accountingEntities db = new accountingEntities();
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        CultureInfo _ci;
        ComponentResourceManager _resource;

        private readonly UCstore _ucstore;
        private bool isNew;

        public formAddStore(UCstore store, tblStore obj)
        {
            InitializeComponent();
            GetResources();
            _ucstore = store;

            if (obj == null)
            {
                this.isNew = true;
                bindingSource1.DataSource = new tblStore() { strBrnId = Session.CurBranch.brnId, strStatus = 1 };
                db.tblStores.Add(bindingSource1.Current as tblStore);
                tblStore b = new tblStore();
                new ClsTblBranch().InitBranchLookupEdit(layoutControlGroup3, bindingSource1, nameof(b.strBrnId));
            }
            else
            {
                this.isNew = false;
                bindingSource1.DataSource = obj;
                db.tblStores.Attach(bindingSource1.Current as tblStore);
            }
        }

        private bool ValidateSave()
        {
            ChangeFocus();
            bool val, isValid = dxValidationProvider1.Validate();

            if (isValid)
            {
                try
                {
                    db.SaveChanges();
                    val = true;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                    val = false;
                }
            }
            else
                val = false;

            return val;
        }

        private void ChangeFocus()
        {
            if (strNoTextEdit.ContainsFocus)
                strNameTextEdit.Focus();
            else
                strNoTextEdit.Focus();
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidateSave())
            {
                _ucstore.SetRefreshListDialog(_resource.GetString("storeSuccessMssg") + strNameTextEdit.Text, this.isNew);
                this.Close();
            }
        }

        private void bbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidateSave())
            {
                flyDialog.ShowDialogForm(this, _resource.GetString("storeSuccessMssg") + strNameTextEdit.Text);

                bindingSource1.DataSource = new tblStore();
                db.tblStores.Add(bindingSource1.Current as tblStore);
                strNoTextEdit.Focus();
            }
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng)
            {
                _ci = new CultureInfo("ar");
                _resource = new ComponentResourceManager(typeof(Language.StoreMangmentNotificationAr));
            }
            else
            {
                _ci = new CultureInfo("en");
                _resource = new ComponentResourceManager(typeof(Language.formAddStoreEn));
            }

            if (MySetting.GetPrivateSetting.LangEng) EnglishTranslation();
        }

        private void EnglishTranslation()
        {
            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = false;

            foreach (LayoutControlItem item in layoutControlGroup3.Items)
                _resource.ApplyResources(item, item.Name, _ci);

            _resource.ApplyResources(mainRibbonPage, mainRibbonPage.Name, _ci);
            _resource.ApplyResources(layoutControlGroup3, layoutControlGroup3.Name, _ci);
            _resource.ApplyResources(bbiSave, bbiSave.Name, _ci);
            _resource.ApplyResources(bbiSaveAndNew, bbiSaveAndNew.Name, _ci);
            _resource.ApplyResources(bbiClose, bbiClose.Name, _ci);

            this.Text = _resource.GetString("$this.Text");
        }
    }
}
