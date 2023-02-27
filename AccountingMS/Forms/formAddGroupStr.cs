using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formAddGroupStr : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        accountingEntities db = new accountingEntities();
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblAccount clsTbAccount;
        ClsTblGroupStr clsTbGroup;
        ClsTblDefaultAccount clsTbDefaultAcc;
        tblGroupStr tbGroupStr;

        private readonly UCstore _ucstore;
        private bool isNew;

        public formAddGroupStr(UCstore store, tblGroupStr obj)
        {
            InitializeComponent();
            InitObjects();
            InitData(obj);
            InitDefaultData();
            SetPropertiesVisibility();
            _ucstore = store;
            layoutControlGroup4.Visibility = MySetting.DefaultSetting.InvType ? LayoutVisibility.Always : LayoutVisibility.Never;
            layoutControlGroup5.Visibility = MySetting.DefaultSetting.InvType ? LayoutVisibility.Never : LayoutVisibility.Always;
            grpAccNoLookUpEdit.EditValueChanged += GrpAccNoLookUpEdit_EditValueChanged;
            bbiAutoAccNo.CheckedChanged += BbiAutoAccNo_CheckedChanged;
        }

        private void InitData(tblGroupStr obj)
        {
            InitDefaultObjects();
            if (obj == null)
            {
                this.isNew = true;
                InitNewGrpObj();
                new ClsTblBranch().InitBranchLookupEdit(layoutControlGroup3, tblGroupStrsBindingSource, nameof(this.tbGroupStr.grpBrnId));
            }
            else
            {
                ItemForgrpCurrency.Visibility = LayoutVisibility.Never;
                this.isNew = false;
                this.tbGroupStr = obj;
                tblGroupStrsBindingSource.DataSource = this.tbGroupStr;
                db.tblGroupStrs.Attach(tblGroupStrsBindingSource.Current as tblGroupStr);
            }
        }

        private void InitNewGrpObj()
        {
            this.tbGroupStr = new tblGroupStr() { grpNo = this.clsTbGroup.GetGroupNewNo(), grpBrnId = Session.CurBranch.brnId };
            tblGroupStrsBindingSource.DataSource = this.tbGroupStr;
            db.tblGroupStrs.Add(tblGroupStrsBindingSource.Current as tblGroupStr);
        }

        private void InitDefaultData()
        {
            this.clsTbAccount.InitAccountLookupEdit(grpAccNoLookUpEdit, 114101);
            this.clsTbAccount.InitAccountLookupEdit(grpCostAccNoTextEdit, 312101);
            this.clsTbAccount.InitAccountLookupEdit(grpSalesAccNoTextEdit, 411101);
            this.clsTbAccount.InitAccountLookupEdit(grpSalesRtrnAccNoTextEdit, 312301);
            this.clsTbAccount.InitAccountLookupEdit(grpPurchaseAccNoLookUpEdit);
            this.clsTbAccount.InitAccountLookupEdit(grpPurchaseRtrnAccNoLookUpEdit);
            GetResources();
        }

        private void InitObjects()
        {
            this.clsTbGroup = new ClsTblGroupStr();
            this.clsTbAccount = new ClsTblAccount();
            this.tbGroupStr = new tblGroupStr();
        }

        private void InitDefaultObjects()
        {
            this.clsTbDefaultAcc = new ClsTblDefaultAccount();
            tbGroupStr.grpCurrency = new ClsTblCurrency().InitCurrencyLookupEdit(grpCurrencyTextEdit);
        }

        private void SetPropertiesVisibility()
        {
            if (!this.isNew) return;
            bbiSaveAndNew.Visibility = BarItemVisibility.Always;
            ribbonPageGroupAutoAddAccNo.Visible = true;
        }

        private void BbiAutoAccNo_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            BbiAutoAccNoItemVisibility(bbiAutoAccNo.Checked);
        }

        private void GrpAccNoLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;
            this.tbGroupStr.grpCurrency = Convert.ToByte(editor.GetColumnValue("accCurrency"));
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bbiSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!SaveData()) return;

            _ucstore.SetRefreshListDialog(_resource.GetString("groupStr") + grpNameTextEdit.Text, this.isNew);
            DialogResult = DialogResult.OK;
        }

        private void bbiSaveAndNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!SaveData()) return;

            flyDialog.ShowDialogForm(this, _resource.GetString("groupStr") + grpNameTextEdit.Text);
            InitObjects();
            InitNewGrpObj();
            grpNoTextEdit.Focus();
        }

        private bool SaveData()
        {
            if (!dxValidationProvider1.Validate()) return false;
            if (!ValidateDefaultAccounts()) return false;
            if (!SaveAutoAccNo()) return false;
            return SaveDB();
        }

        private bool ValidateDefaultAccounts()
        {
            if (!this.isNew || !bbiAutoAccNo.Checked) return true;
            tblGroupStr gr = tblGroupStrsBindingSource.Current as tblGroupStr;
            bool isValid = !this.clsTbDefaultAcc.IsDefaultAccFound((byte)DefaultAccType.GrpAcc, gr.grpBrnId.Value) || !this.clsTbDefaultAcc.IsDefaultAccFound((byte)DefaultAccType.GrpAccSale, gr.grpBrnId.Value) ||
                !this.clsTbDefaultAcc.IsDefaultAccFound((byte)DefaultAccType.GrpAccSaleCost, gr.grpBrnId.Value) || !this.clsTbDefaultAcc.IsDefaultAccFound((byte)DefaultAccType.GrpAccSaleRtrn, gr.grpBrnId.Value) ||
                !this.clsTbDefaultAcc.IsDefaultAccFound((byte)DefaultAccType.GrpAccSaleRtrnCost, gr.grpBrnId.Value) || !this.clsTbDefaultAcc.IsDefaultAccFound((byte)DefaultAccType.GrpAccDiscount, gr.grpBrnId.Value)// ||
                /*!this.clsTbDefaultAcc.IsDefaultAccFound((byte)DefaultAccType.GrpAccPurchase, gr.grpBrnId.Value) ||*/ /*!this.clsTbDefaultAcc.IsDefaultAccFound((byte)DefaultAccType.GrpAccPurchaseRtrn, gr.grpBrnId.Value)*/ ? false : true;

            if (!isValid)
            {
                string mssg = "يجب إدخال حسابات المجموعة الإفتراضي أولاً من إعدادات النظام! \n\n";
                mssg += "إدارة النظام -> الإعدادات الإفتراضية -> الحسابات الإفتراضية -> حساب مجموعة المخازن الإفتراضي.";
                ClsXtraMssgBox.ShowError(mssg);
            }

            return isValid;
        }
     
        private bool SaveAutoAccNo()
        {
            if (!this.isNew || !bbiAutoAccNo.Checked) return true;
            bool saveNewAcc = (AddNewAccount(DefaultAccType.GrpAcc, $"مخزون {grpNameTextEdit.Text}") &&
                    AddNewAccount(DefaultAccType.GrpAccSale, $"إرادات مبيعات مخزون {grpNameTextEdit.Text}") &&
                    AddNewAccount(DefaultAccType.GrpAccSaleRtrn, $"مردود مبيعات مخزون {grpNameTextEdit.Text}"));
            AddNewAccount(DefaultAccType.GrpAccDiscount, $"خصم مخزون {grpNameTextEdit.Text}");
            if (MySetting.DefaultSetting.InvType)
            {
                return saveNewAcc && AddNewAccount(DefaultAccType.GrpAccSaleCost, $"تكلفة مبيعات مخزون {grpNameTextEdit.Text}") &&
                    AddNewAccount(DefaultAccType.GrpAccSaleRtrnCost, $"تكلفة مردود مبيعات مخزون {grpNameTextEdit.Text}");
            }
            else
            {
                return saveNewAcc && AddNewAccount(DefaultAccType.GrpAccPurchase, $"مشتريات مخزون {grpNameTextEdit.Text}") &&
                 AddNewAccount(DefaultAccType.GrpAccPurchaseRtrn, $"مردود مشتريات مخزون {grpNameTextEdit.Text}");
            }
        }

        private bool AddNewAccount(DefaultAccType grpDfltAcc, string accName)
        {
            int dfltAccNo = Convert.ToInt32(this.clsTbAccount.GetAccountNoById(this.clsTbDefaultAcc.GetDefultAccNoId((byte)grpDfltAcc, tbGroupStr.grpBrnId.Value)));
            if (dfltAccNo <= 0) return default;
            long newAccNo = this.clsTbAccount.GetNewAccNo(dfltAccNo.ToString());
            switch (grpDfltAcc)
            {
                case DefaultAccType.GrpAcc:
                    this.tbGroupStr.grpAccNo = newAccNo;
                    break;
                case DefaultAccType.GrpAccSale:
                    this.tbGroupStr.grpSalesAccNo = newAccNo;
                    break;
                case DefaultAccType.GrpAccSaleCost:
                    this.tbGroupStr.grpCostAccNo = newAccNo;
                    break;
                case DefaultAccType.GrpAccSaleRtrn:
                    this.tbGroupStr.grpSalesRtrnAccNo = newAccNo;
                    break;
                case DefaultAccType.GrpAccSaleRtrnCost:
                    this.tbGroupStr.grpCostRtrnAccNo = newAccNo;
                    break;
                case DefaultAccType.GrpAccDiscount:
                    this.tbGroupStr.grpDscntAccNo = newAccNo;
                    break;
                case DefaultAccType.GrpAccPurchase:
                    this.tbGroupStr.grpPurchaseAccNo = newAccNo;
                    break;
                case DefaultAccType.GrpAccPurchaseRtrn:
                    this.tbGroupStr.grpPurchaseRtrnAccNo = newAccNo;
                    break;
            }
            return this.clsTbAccount.Add(grpDfltAcc, newAccNo, accName, Convert.ToByte(grpCurrencyTextEdit.EditValue), this.clsTbAccount.GetAccountCategoreyByAccNo(dfltAccNo), tbGroupStr.grpBrnId.Value);
        }

        private void BbiAutoAccNoItemVisibility(bool checkState)
        {
            this.Height = checkState ? 380 : 530;
            if (MySetting.DefaultSetting.InvType)
                layoutControlGroup4.Visibility =checkState ? LayoutVisibility.Never : LayoutVisibility.Always;
            else
               layoutControlGroup5.Visibility = checkState ? LayoutVisibility.Never : LayoutVisibility.Always;
            if (layoutControlGroup4.Items.FindByName("ItemForbranch") != null)
                ((LayoutControlItem)layoutControlGroup4.Items.FindByName("ItemForbranch")).Enabled = !bbiAutoAccNo.Checked;
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
                _resource = new ComponentResourceManager(typeof(Language.formAddGroupStrEn));
            }

            if (MySetting.GetPrivateSetting.LangEng) EnglishTranslation();
        }

        private void EnglishTranslation()
        {
            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = false;

            foreach (LayoutControlItem item in layoutControlGroup3.Items)
                _resource.ApplyResources(item, item.Name, _ci);
            foreach (LayoutControlItem item in layoutControlGroup4.Items)
                _resource.ApplyResources(item, item.Name, _ci);

            _resource.ApplyResources(mainRibbonPage, mainRibbonPage.Name, _ci);
            _resource.ApplyResources(bbiSave, bbiSave.Name, _ci);
            _resource.ApplyResources(bbiSaveAndNew, bbiSaveAndNew.Name, _ci);
            _resource.ApplyResources(bbiClose, bbiClose.Name, _ci);

            _resource.ApplyResources(layoutControlGroup3, layoutControlGroup3.Name, _ci);
            _resource.ApplyResources(layoutControlGroup4, layoutControlGroup4.Name, _ci);
            grpAccNoLookUpEdit.Properties.Columns[0].Caption = _resource.GetString("colAccNo");
            grpAccNoLookUpEdit.Properties.Columns[1].Caption = _resource.GetString("colAccName");
            grpSalesAccNoTextEdit.Properties.Columns[0].Caption = _resource.GetString("colAccNo");
            grpSalesAccNoTextEdit.Properties.Columns[1].Caption = _resource.GetString("colAccName");
            grpCostAccNoTextEdit.Properties.Columns[0].Caption = _resource.GetString("colAccNo");
            grpCostAccNoTextEdit.Properties.Columns[1].Caption = _resource.GetString("colAccName");
            grpSalesRtrnAccNoTextEdit.Properties.Columns[0].Caption = _resource.GetString("colAccNo");
            grpSalesRtrnAccNoTextEdit.Properties.Columns[1].Caption = _resource.GetString("colAccName");

            this.Text = _resource.GetString("$this.Text");
        }
        private bool SaveDB()
        {
            if (ClsSaveDB.Save(db, LogHelper.GetLogger()))
            {
                Session.GetDataGroupStr();
                return true;
            }
            return false;
        }
    }
}
