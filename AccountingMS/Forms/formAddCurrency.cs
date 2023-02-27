using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formAddCurrency : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        accountingEntities db;
        CultureInfo _ci;
        ComponentResourceManager _resource;

        readonly UCcurrency _ucCurrency;
        bool isNew;

        public formAddCurrency(UCcurrency ucCurrency, tblCurrency obj)
        {
            InitializeComponent();
            GetResources();
            _ucCurrency = ucCurrency;

            db = new accountingEntities();

            if (obj == null)
            {
                this.isNew = true;
                bindingSource1.DataSource = new tblCurrency();
                db.tblCurrencies.Add(bindingSource1.Current as tblCurrency);
            }
            else
            {
                this.isNew = false;
                bindingSource1.DataSource = obj;
                db.tblCurrencies.Attach(bindingSource1.Current as tblCurrency);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;

            if (SaveDB())
            {
                _ucCurrency.flyDialogMssg = ((!MySetting.GetPrivateSetting.LangEng) ? "العملة: " : "Currency ") + curNameTextEdit.Text;
                _ucCurrency.focusedRowHandle = Convert.ToString(curNameTextEdit.EditValue);
                _ucCurrency.flyDialogIsNew = this.isNew;

                DialogResult = DialogResult.OK;
            }
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;

            if (SaveDB())
            {
                _ucCurrency.flyDialogMssg = ((!MySetting.GetPrivateSetting.LangEng) ? "العملة: " : "Currency ") + curNameTextEdit.Text;
                _ucCurrency.focusedRowHandle = Convert.ToString(curNameTextEdit.EditValue);
                _ucCurrency.flyDialogIsNew = this.isNew;

                DialogResult = DialogResult.OK;
            }
        }

        private void BbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private bool SaveDB()
        {
            if (ClsSaveDB.Save(db, LogHelper.GetLogger()))
            {
                Session.GetDataCurrencies();
                return true;
            }
            return false;
        }


        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = false;

            _ci = new CultureInfo("en");
            _resource = new ComponentResourceManager(typeof(Language.formAddCurrencyEn));

            _resource.ApplyResources(layoutControlGroup1, layoutControlGroup1.Name, _ci);
            _resource.ApplyResources(ItemForcurName, ItemForcurName.Name, _ci);
            _resource.ApplyResources(ItemForcurSign, ItemForcurSign.Name, _ci);
            _resource.ApplyResources(ItemForcurType, ItemForcurType.Name, _ci);
            _resource.ApplyResources(ItemForcurChange, ItemForcurChange.Name, _ci);
            _resource.ApplyResources(ItemForcurCelling, ItemForcurCelling.Name, _ci);
            _resource.ApplyResources(ItemForcurFloar, ItemForcurFloar.Name, _ci);
            curTypeRadioGroup.Properties.Items[0].Description = _resource.GetString("curTypeRadioGroup.Properties.Items1");
            curTypeRadioGroup.Properties.Items[1].Description = _resource.GetString("curTypeRadioGroup.Properties.Items3");
            this.Text = _resource.GetString("this.Text");
        }
    }
}