using AccountingMS.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formAddRepresentative : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        accountingEntities db = new accountingEntities();
        ComponentFlyoutDialog flydDialog = new ComponentFlyoutDialog();
        ClsTblAccount clsTbAccount;
        ClsTblDefaultAccount clsTbDfltAcc;
        tblRepresentative tbRepresentative;

        private readonly UCrepresentative ucRepresentative;
        private bool isNew;

        private async void FormAddRepresentative_Load(object sender, EventArgs e)
        {
            flydDialog.WaitForm(this, 1);
            await InitDefaultDataAsync();
            flydDialog.WaitForm(this, 0);
        }

        public formAddRepresentative(UCrepresentative ucRepresentative, tblRepresentative tbRepresentative)
        {
            InitializeComponent();
            InitData(tbRepresentative);
            InitEvents();
            this.ucRepresentative = ucRepresentative;

        }

        private void InitEvents()
        {
            this.Load += FormAddRepresentative_Load;
            bbiAutoAcount.CheckedChanged += BbiAutoAcount_CheckedChanged;
            repAccNoTextEdit.EditValueChanged += RepAccNoTextEdit_EditValueChanged;
        }

        private void RepAccNoTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!this.isNew) return;

            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;

            this.tbRepresentative.repCurrency = Convert.ToByte(editor.GetColumnValue("accCurrency"));
        }

        private async Task InitDefaultDataAsync()
        {
            tbRepresentative.repCurrency = new ClsTblCurrency().InitCurrencyLookupEdit(repCurrencyTextEdit);

            this.clsTbAccount = await Task.Run(() => new ClsTblAccount());
            this.clsTbDfltAcc = await Task.Run(() => new ClsTblDefaultAccount());

            this.clsTbAccount.InitAccountLookupEdit(repAccNoTextEdit);
        }

        private void InitData(tblRepresentative tbRepresentative)
        {
            if (tbRepresentative == null)
            {
                this.isNew = true;
                InitNewObject();
                new ClsTblBranch().InitBranchLookupEdit(layoutControlGroup3, tblRepresentativeBindingSource, nameof(this.tbRepresentative.repBrnId));
                SetAutoAccItemVisibility(true);
            }
            else
            {
                this.isNew = false;
                this.tbRepresentative = tbRepresentative.ShallowCopy();

                tblRepresentativeBindingSource.DataSource = this.tbRepresentative;
                db.tblRepresentatives.Attach(this.tbRepresentative);

                SetEditProperties();
            }
        }

        private void SetEditProperties()
        {
            bbiReset.Visibility = BarItemVisibility.Never;
            ItemForrepNo.Enabled = false;
            ItemForrepAccNo.Enabled = false;
            ItemForrepCurrency.Enabled = false;
            ribbonPageGroupAccount.Visible = false;
        }

        private void InitNewObject()
        {
            this.tbRepresentative = new tblRepresentative() { repBrnId = Session.CurBranch.brnId, repStatus = 1 };
            tblRepresentativeBindingSource.DataSource = this.tbRepresentative;
        }

        private void BbiAutoAcount_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetAutoAccItemVisibility(bbiAutoAcount.Checked);
        }

        private void SetAutoAccItemVisibility(bool isAutoAccNo)
        {
            ItemForrepNo.Visibility = (!isAutoAccNo) ? LayoutVisibility.Always : LayoutVisibility.Never;
            ItemForrepAccNo.Visibility = (!isAutoAccNo) ? LayoutVisibility.Always : LayoutVisibility.Never;
            ItemForrepCurrency.Visibility = (isAutoAccNo) ? LayoutVisibility.Always : LayoutVisibility.Never;
        }

        private bool SaveData()
        {
            if (!dxValidationProvider1.Validate()) return false;
            if (!SetAutoAccNo()) return false;

            if (this.isNew) db.tblRepresentatives.Add(this.tbRepresentative);

            return ClsSaveDB.Save(db, LogHelper.GetLogger());
        }

     
        private bool SetAutoAccNo()
        {
            if (!this.isNew || !bbiAutoAcount.Checked) return true;
            tblRepresentative Representative = tblRepresentativeBindingSource.Current as tblRepresentative;
            if (Representative == null) return false;
            if (Representative.repBrnId == 0)
            {
                ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Sorry!, The branch must be selected first" : "يجب تحديد الفرع الخاص بالمندوب ");
                return false;
            }
            if (!ValidateRepDfltAcc()) return false;

            int dfltAccNo = Convert.ToInt32(this.clsTbAccount.GetAccountNoById(this.clsTbDfltAcc.GetDefaultAccIdByType(DefaultAccType.Representative)));
            long repAccNo = this.clsTbAccount.GetNewAccNo(dfltAccNo.ToString());

            this.tbRepresentative.repAccNo = repAccNo;
            this.tbRepresentative.repNo = Convert.ToInt32(repAccNo % 100000);
            return this.clsTbAccount.Add(DefaultAccType.Representative, repAccNo, repNameTextEdit.Text, this.tbRepresentative.repCurrency, this.clsTbAccount.GetAccountCategoreyByAccNo(dfltAccNo), this.tbRepresentative.repBrnId);
        }
        private bool ValidateRepDfltAcc()
        {
            bool isValid = this.clsTbDfltAcc.IsDefaultAccFound((byte)DefaultAccType.Representative);
            if (!isValid) ClsXtraMssgBox.ShowError("عذراٌ يجب إدخال حساب المندوبين الإفتراضي أولاُ من إعدادات النظام!");

            return isValid;
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!SaveData()) return;

            string mssg = $"المندوب: {this.tbRepresentative.repName}";
            this.ucRepresentative.SetRefreshListDialog(this.isNew, mssg);

            DialogResult = DialogResult.OK;
        }

        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InitNewObject();
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bbiAutoAcount_CheckedChanged_1(object sender, ItemClickEventArgs e)
        {
           
        }

        private void formAddRepresentative_Click(object sender, EventArgs e)
        {
           
        }

        private void bbiAutoAcount_ItemClick(object sender, ItemClickEventArgs e)
        {
            //formAddProudctMandob frm = new formAddProudctMandob();
            //frm.Show();
        }
    }
}
