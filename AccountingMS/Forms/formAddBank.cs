using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formAddBank : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        accountingEntities db = new accountingEntities();
        ClsLinQuery lq = new ClsLinQuery();
        tblAccountBank tbBank;
        ClsTblAccount clsTbAccount;
        ClsTblDefaultAccount clsTbDefaultAcc;

        private readonly UCaccBanks _ucAccBanks;
        private bool isNew;
        private long bankAccNo;
        private int dfltBankAccNo;

        public formAddBank(UCaccBanks ucAccBanks, tblAccountBank obj)
        {
            InitializeComponent();
            lq.accNo(bankAccNoTextEdit);
            InitData(obj);
            InitDefaultData();
            GetResources();
            _ucAccBanks = ucAccBanks;

            bankAccNoTextEdit.EditValueChanged += AccountLookupEdit_EditValueChanged;
            bbiAutoAccNo.CheckedChanged += BbiAutoAccNo_CheckedChanged;
        }

        private void InitData(tblAccountBank obj)
        {
            if (obj == null)
            {
                this.isNew = true;
                this.tbBank = new tblAccountBank() { bankCurrency = 0, bankBrnId = Session.CurBranch.brnId };
             
                tblBankBindingSource.DataSource = this.tbBank;
                db.tblAccountBanks.Add(tblBankBindingSource.Current as tblAccountBank);
            }
            else
            {
                this.isNew = false;
                this.tbBank = obj;
                tblBankBindingSource.DataSource = this.tbBank;
                db.tblAccountBanks.Attach(tblBankBindingSource.Current as tblAccountBank);
                SetEditForm();
            }
            new ClsTblBranch().InitBranchLookupEdit(layoutControlGroup3, tblBankBindingSource, nameof(tbBank.bankBrnId));
        }

        private void InitDefaultData()
        {
            if (!this.isNew) return;

            this.clsTbAccount = new ClsTblAccount();
            this.clsTbDefaultAcc = new ClsTblDefaultAccount();
            tbBank.bankCurrency = new ClsTblCurrency().InitCurrencyLookupEdit(bankCurrencyTextEdit);

            SetAutoAccNo();
        }

        private void SetEditForm()
        {
            this.Text = (!MySetting.GetPrivateSetting.LangEng) ? $"تعديل بيانات البنك : {this.tbBank.bankName}" : $"Update Bank Data : {this.tbBank.bankName}";
            ItemForbankAccNo.Enabled = false;
            ItemForbankNo.Enabled = false;
        }

        private void SetAutoAccNo()
        {
            ribbonPageGroupAutoAddAccNo.Visible = true;
            bbiAutoAccNo.Checked = true;
            BbiAutoAccNoItemVisibility(true);
        }

        private void AccountLookupEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;
            this.tbBank.bankCurrency = Convert.ToByte(editor.GetColumnValue("accCurrency"));
        }

        private void BbiAutoAccNo_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BbiAutoAccNoItemVisibility(bbiAutoAccNo.Checked);
        }

        private void BbiAutoAccNoItemVisibility(bool checkState)
        {
            switch (checkState)
            {
                case true:
                    ItemForbankAccNo.Visibility = LayoutVisibility.Never;
                    ItemForbankNo.Visibility = LayoutVisibility.Never;
                    ItemForbankCurrency.Visibility = LayoutVisibility.Always;
                    ItemForbankAccNo.TextAlignMode = TextAlignModeItem.AutoSize;
                    break;
                case false:
                    ItemForbankCurrency.Visibility = LayoutVisibility.Never;
                    ItemForbankAccNo.Visibility = LayoutVisibility.Always;
                    ItemForbankNo.Visibility = LayoutVisibility.Always;
                    ItemForbankAccNo.TextAlignMode = TextAlignModeItem.UseParentOptions;
                    break;
            }
            SetCurrentFocusedItem(checkState);
        }

        private void SetCurrentFocusedItem(bool autoAccNo)
        {
            if (!autoAccNo)
                bankAccNoTextEdit.Focus();
            else
                bankNameTextEdit.Focus();
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            if (!SaveAutoAccNo()) return;
            SaveAccName();

            if (SaveDB())
            {
                _ucAccBanks.flyDialogMssg = ((!MySetting.GetPrivateSetting.LangEng) ? "البنك: " : "Bank ") + bankNameTextEdit.Text;
                _ucAccBanks.focusedRowHandle = Convert.ToInt32((!bbiAutoAccNo.Checked) ? bankNoTextEdit.EditValue : this.bankAccNo % 100000);
                _ucAccBanks.flyDialogIsNew = this.isNew;

                DialogResult = DialogResult.OK;
            }
        }

        private void SaveAccName()
        {
            if (this.isNew) return;

            new ClsTblAccount().UpdateAccNameByAccNo(this.tbBank.bankAccNo, this.tbBank.bankName);
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private bool SaveAutoAccNo()
        {
            if (!this.isNew || !bbiAutoAccNo.Checked) return true;

            SetNewAccNo();
            SetBankObjFileds();

            return SaveNewAccToTblAccounts();
        }

        //private void SetNewAccNo()
        //{
        //    this.dfltBoxAccNo = Convert.ToInt32(this.clsTbAccount.GetAccountNoById(this.clsTbDefaultAcc.GetBankAccNoId()));
        //    this.bankAccNo = this.clsTbAccount.GetNewAccNo(dfltBoxAccNo.ToString());
        //}
        private bool SetNewAccNo()
        {
            tblAccountBank Bank = tblBankBindingSource.Current as tblAccountBank;
            if (Bank == null) return false;
            if (Bank.bankBrnId == null | Bank.bankBrnId == 0)
            {
                XtraMessageBox.Show("يجب تحديد الفرع الخاص بالبنك");
                return false;
            }
            this.dfltBankAccNo = Convert.ToInt32(this.clsTbAccount.GetAccountNoById(this.clsTbDefaultAcc.GetDefultAccNoId((byte)DefaultAccType.Bank, Bank.bankBrnId.Value)));

            if (this.dfltBankAccNo <= 0)
            {
                XtraMessageBox.Show("يجب تحديد الحساب الافتراضي للبنوك لهذا الفرع");
                return false;
            }
            this.bankAccNo = this.clsTbAccount.GetNewAccNo(dfltBankAccNo.ToString());
            return true;
        }
        private void SetBankObjFileds()
        {
            this.tbBank.bankAccNo = this.bankAccNo;
            this.tbBank.bankNo = Convert.ToInt32(this.bankAccNo % 100000);
        }

        private bool SaveNewAccToTblAccounts()
        {
            tblAccountBank Bank = tblBankBindingSource.Current as tblAccountBank;
            if (Bank == null) return false;
            return this.clsTbAccount.Add(DefaultAccType.Bank, this.bankAccNo, bankNameTextEdit.Text, Convert.ToByte(bankCurrencyTextEdit.EditValue), 1, Bank.bankBrnId.Value);
        }

        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = false;

            _ci = new CultureInfo("en");
            _resource = new ComponentResourceManager(typeof(Language.formAddBankEn));

            _resource.ApplyResources(layoutControlGroup3, layoutControlGroup3.Name, _ci);
            _resource.ApplyResources(ItemForbankNo, ItemForbankNo.Name, _ci);
            _resource.ApplyResources(ItemForbankAccNo, ItemForbankAccNo.Name, _ci);
            _resource.ApplyResources(ItemForbankName, ItemForbankName.Name, _ci);
            _resource.ApplyResources(ItemForbankCelling, ItemForbankCelling.Name, _ci);
            bankAccNoTextEdit.Properties.Columns[0].Caption = _resource.GetString("colAccNo");
            bankAccNoTextEdit.Properties.Columns[1].Caption = _resource.GetString("colAccName");
            this.Text = _resource.GetString("this.Text");
        }
        private bool SaveDB()
        {
            if (ClsSaveDB.Save(db, LogHelper.GetLogger()))
            {
                Session.GetDataBanks();
                return true;
            }
            return false;
        }
    }
}