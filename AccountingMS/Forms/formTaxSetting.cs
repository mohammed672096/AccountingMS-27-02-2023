using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formTaxSetting : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        accountingEntities db = new accountingEntities();
        BindingList<tblTaxAccount> tbTaxAccountList = new BindingList<tblTaxAccount>();
        //BindingList<tblAccount> tbAccountList = new BindingList<tblAccount>();
        //BindingList<tblAccount> tbAccountListUpdStatus = new BindingList<tblAccount>();
        private readonly UCtaxDeclaration _ucTaxDeclaration;

        public formTaxSetting(UCtaxDeclaration ucTaxDeclaration)
        {
            InitializeComponent();
            InitData();
            InitDefaultData();
            _ucTaxDeclaration = ucTaxDeclaration;
        }

        private void InitData()
        {
            var tbAcoount = (from a in db.tblAccounts
                             where a.accType == 2
                             orderby a.accNo
                             select a).ToList();
            var tbTaxAcount = db.tblTaxAccounts.ToList();

            foreach (var tTaxAccount in tbTaxAcount)
                this.tbTaxAccountList.Add(tTaxAccount);

            tblAccountBindingSource.DataSource = tbAcoount;
        }

        private void InitDefaultData()
        {
            if (this.tbTaxAccountList == null) return;

            foreach (var tbTaxAccount in this.tbTaxAccountList)
            {
                if ((tbTaxAccount.taxStatus == 1))
                    textEditTaxEntry.EditValue = tbTaxAccount.taxAccNo;
                else if ((tbTaxAccount.taxStatus == 2))
                    textEditTaxEntVocher.EditValue = tbTaxAccount.taxAccNo;
                else if ((tbTaxAccount.taxStatus == 3))
                    textEditTaxEntRecipt.EditValue = tbTaxAccount.taxAccNo;
                else if (tbTaxAccount.taxStatus == 4)
                    textEditTaxPurchase.EditValue = tbTaxAccount.taxAccNo;
                else if ((tbTaxAccount.taxStatus == 5))
                    textEditTaxSale.EditValue = tbTaxAccount.taxAccNo;
            }
            textEditTax.EditValue = MySetting.GetPrivateSetting.taxDefault;
        }

        private void barButtonSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            bool saved = (this.tbTaxAccountList.Count() == 0) ? SaveSetting() : UpdtTaxSetting();

            if (saved)
            {
                this.Close();
                _ucTaxDeclaration.RefreshListDialog("إعدادات الضريبة");
            }
        }

        private void barButtonItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private bool SaveSetting()
        {
            if (this.tbTaxAccountList.Count() == 0)
            {
                foreach (Control c in this.layoutControl1.Controls)
                {
                    if (c.Name == "textEditTax") continue;

                    if (c is LookUpEdit)
                    {
                        tblTaxAccount tbTaxAccount = new tblTaxAccount();
                        LookUpEdit textEdit = c as LookUpEdit;

                        tbTaxAccount.taxAccNo = Convert.ToInt64(textEdit.EditValue);
                        tbTaxAccount.taxAccName = textEdit.Properties.GetDisplayText(textEdit.EditValue);

                        if (textEdit.Name == "textEditTaxEntry")
                            tbTaxAccount.taxStatus = 1;
                        else if (textEdit.Name == "textEditTaxEntVocher")
                            tbTaxAccount.taxStatus = 2;
                        else if (textEdit.Name == "textEditTaxEntRecipt")
                            tbTaxAccount.taxStatus = 3;
                        else if (textEdit.Name == "textEditTaxPurchase")
                            tbTaxAccount.taxStatus = 4;
                        else if (textEdit.Name == "textEditTaxSale")
                            tbTaxAccount.taxStatus = 5;

                        db.tblTaxAccounts.Add(tbTaxAccount);
                    }
                }
            }

            MySetting.GetPrivateSetting.taxDefault = Convert.ToByte(textEditTax.EditValue);
            MySetting.WriterSettingXml(); 

            return (SaveDB()) ? true : false;
        }

        private bool UpdtTaxSetting()
        {
            foreach (var tbTaxAccount in this.tbTaxAccountList)
            {
                switch (tbTaxAccount.taxStatus)
                {
                    case 1:
                        db.tblTaxAccounts.Attach(tbTaxAccount);
                        tbTaxAccount.taxAccNo = Convert.ToInt64(textEditTaxEntry.EditValue);
                        tbTaxAccount.taxAccName = textEditTaxEntry.Properties.GetDisplayText(textEditTaxEntry.EditValue);
                        break;
                    case 2:
                        db.tblTaxAccounts.Attach(tbTaxAccount);
                        tbTaxAccount.taxAccNo = Convert.ToInt64(textEditTaxEntVocher.EditValue);
                        tbTaxAccount.taxAccName = textEditTaxEntVocher.Properties.GetDisplayText(textEditTaxEntVocher.EditValue);
                        break;
                    case 3:
                        db.tblTaxAccounts.Attach(tbTaxAccount);
                        tbTaxAccount.taxAccNo = Convert.ToInt64(textEditTaxEntRecipt.EditValue);
                        tbTaxAccount.taxAccName = textEditTaxEntRecipt.Properties.GetDisplayText(textEditTaxEntRecipt.EditValue);
                        break;
                    case 4:
                        db.tblTaxAccounts.Attach(tbTaxAccount);
                        tbTaxAccount.taxAccNo = Convert.ToInt64(textEditTaxPurchase.EditValue);
                        tbTaxAccount.taxAccName = textEditTaxPurchase.Properties.GetDisplayText(textEditTaxPurchase.EditValue);
                        break;
                    case 5:
                        db.tblTaxAccounts.Attach(tbTaxAccount);
                        tbTaxAccount.taxAccNo = Convert.ToInt64(textEditTaxSale.EditValue);
                        tbTaxAccount.taxAccName = textEditTaxSale.Properties.GetDisplayText(textEditTaxSale.EditValue);
                        break;
                }
            }
            MySetting.GetPrivateSetting.taxDefault = Convert.ToByte(textEditTax.EditValue);
            MySetting.WriterSettingXml(); 

            return (SaveDB()) ? true : false;
        }

        private bool SaveDB()
        {
            return ClsSaveDB.Save(db, LogHelper.GetLogger());
        }
    }
}