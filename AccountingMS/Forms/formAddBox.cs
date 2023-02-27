using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formAddBox : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        accountingEntities db = new accountingEntities();
        ClsLinQuery lq = new ClsLinQuery();
        ClsTblCurrency clsTbCurrency;
        ClsTblAccount clsTbAccount;
        ClsTblDefaultAccount clsTbDefaultAcc;
        tblAccountBox tbBox;

        private readonly UCaccBox _ucAccBox;
        private bool isNew;
        private long boxAccNo;
        private int dfltBoxAccNo;

        public formAddBox(UCaccBox ucAccBox, tblAccountBox obj)
        {
            InitializeComponent();
            lq.accNo(boxAccNoTextEdit);
            InitData(obj);
            InitDefaultData();
            GetResources();
            _ucAccBox = ucAccBox;

            boxAccNoTextEdit.EditValueChanged += AccountLookupEdit_EditValueChanged;
            bbiAutoAccNo.CheckedChanged += BbiAutoAccNo_CheckedChanged;
        }

        private void InitData(tblAccountBox obj)
        {
            if (obj == null)
            {
                this.isNew = true;
                this.tbBox = new tblAccountBox() { boxCurrency = 0, boxBrnId = Session.CurBranch.brnId };
                bindingSource1.DataSource = tbBox;
                db.tblAccountBoxes.Add(bindingSource1.Current as tblAccountBox);
            }
            else
            {
                this.isNew = false;
                this.tbBox = obj;
                bindingSource1.DataSource = this.tbBox;
                db.tblAccountBoxes.Attach(bindingSource1.Current as tblAccountBox);
                SetEditForm();
            }
            new ClsTblBranch().InitBranchLookupEdit(layoutControlGroup3, bindingSource1, nameof(this.tbBox.boxBrnId));
        }

        private void InitDefaultData()
        {
            if (this.isNew)
            {
                this.clsTbAccount = new ClsTblAccount();
                this.clsTbDefaultAcc = new ClsTblDefaultAccount();
                this.clsTbCurrency = new ClsTblCurrency();

                this.clsTbCurrency.InitCurrencyLookupEdit(boxCurrencyTextEdit);

                this.tbBox.boxCurrency = clsTbCurrency.FirstCurrency;

                SetAutoAccNo();
            }
        }

        private void SetEditForm()
        {
            this.Text = (!MySetting.GetPrivateSetting.LangEng) ? $"تعديل بيانات الصندوق : {this.tbBox.boxName}" : $"Update Box Data : {this.tbBox.boxName}";
           ItemForboxAccountNo.Enabled = false;
            ItemForboxNo.Enabled = false;
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
            this.tbBox.boxCurrency = Convert.ToByte(editor.GetColumnValue("accCurrency"));
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
                    ItemForboxAccountNo.Visibility = LayoutVisibility.Never;
                    ItemForboxNo.Visibility = LayoutVisibility.Never;
                    ItemForboxCurrency.Visibility = LayoutVisibility.Always;
                    ItemForboxAccountNo.TextAlignMode = TextAlignModeItem.AutoSize;
                    break;
                case false:
                    ItemForboxCurrency.Visibility = LayoutVisibility.Never;
                    ItemForboxAccountNo.Visibility = LayoutVisibility.Always;
                    ItemForboxNo.Visibility = LayoutVisibility.Always;
                    ItemForboxAccountNo.TextAlignMode = TextAlignModeItem.UseParentOptions;
                    break;
            }
            SetCurrentFocusedItem(checkState);
        }

        private void SetCurrentFocusedItem(bool autoAccNo)
        {
            if (!autoAccNo)
                boxAccNoTextEdit.Focus();
            else
                boxNameTextEdit.Focus();
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            if (!SaveAutoAccNo()) return;
            SaveAccName();

            if (SaveDB())
            {
                _ucAccBox.flyDialogMssg = ((!MySetting.GetPrivateSetting.LangEng) ? "الصندوق: " : "Box ") + boxNameTextEdit.Text;
                _ucAccBox.focusedRowHandle = Convert.ToInt32((!bbiAutoAccNo.Checked) ? boxNoTextEdit.EditValue : this.boxAccNo % 100000);
                _ucAccBox.flyDialogIsNew = this.isNew;

                DialogResult = DialogResult.OK;
            }
        }

        private void SaveAccName()
        {
            if (this.isNew) return;

            new ClsTblAccount().UpdateAccNameByAccNo(this.tbBox.boxAccNo, this.tbBox.boxName);
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private bool SaveAutoAccNo()
        {
            if (!this.isNew || !bbiAutoAccNo.Checked) return true;

            SetNewAccNo();
            SetBoxObjFileds();

            return SaveNewAccToTblAccounts();
        }

        private bool SetNewAccNo()
        {
            tblAccountBox boxes = bindingSource1.Current as tblAccountBox;
            if (boxes == null) return false;
            if (boxes.boxBrnId == null | boxes.boxBrnId == 0)
            {
                XtraMessageBox.Show("يجب تحديد الفرع الخاص بالصندوق");
                return false;
            }
            this.dfltBoxAccNo = Convert.ToInt32(this.clsTbAccount.GetAccountNoById(this.clsTbDefaultAcc.GetDefultAccNoId((byte)DefaultAccType.Box, boxes.boxBrnId.Value)));

            if (this.dfltBoxAccNo <= 0)
            {
                XtraMessageBox.Show("يجب تحديد الحساب الافتراضي للصناديق لهذا الفرع");
                return false;
            }
            this.boxAccNo = this.clsTbAccount.GetNewAccNo(dfltBoxAccNo.ToString());
            return true;
        }

        private void SetBoxObjFileds()
        {
            this.tbBox.boxAccNo = this.boxAccNo;
            this.tbBox.boxNo = Convert.ToInt32(this.boxAccNo % 100000);//db.tblAccountBoxes.Max(x => x.boxNo) + 1; 
        }

        private bool SaveNewAccToTblAccounts()
        {
            tblAccountBox boxes = bindingSource1.Current as tblAccountBox;
            if (boxes == null) return false;

            return this.clsTbAccount.Add(DefaultAccType.Box, this.boxAccNo, boxNameTextEdit.Text, Convert.ToByte(boxCurrencyTextEdit.EditValue), 1, boxes.boxBrnId.Value);
        }

        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = false;

            _ci = new CultureInfo("en");
            _resource = new ComponentResourceManager(typeof(Language.formAddBoxEn));

            _resource.ApplyResources(layoutControlGroup3, layoutControlGroup3.Name, _ci);
            _resource.ApplyResources(ItemForboxName, ItemForboxName.Name, _ci);
            _resource.ApplyResources(ItemForboxNo, ItemForboxNo.Name, _ci);
            _resource.ApplyResources(ItemForboxAccountNo, ItemForboxAccountNo.Name, _ci);
            _resource.ApplyResources(ItemForboxCelling, ItemForboxCelling.Name, _ci);
            boxAccNoTextEdit.Properties.Columns[0].Caption = _resource.GetString("colAccNo");
            boxAccNoTextEdit.Properties.Columns[1].Caption = _resource.GetString("colAccName");
            this.Text = _resource.GetString("this.Text");
        }

        private bool SaveDB()
        {
            if (ClsSaveDB.Save(db, LogHelper.GetLogger()))
            {
                Session.GetDataBoxes();
                return true;
            }
            return false;
        }
    }
}
