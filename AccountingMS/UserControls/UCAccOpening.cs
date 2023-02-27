using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Columns;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class UCaccOpening : XtraUserControl
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ComponentFlyoutDialog flyDailog = new ComponentFlyoutDialog();
        ClsTblAccount clsTbAccount;
        ClsTblCurrency clsTbCurrency;
        ClsTblAsset clsTbAsset;
        ClsTblAssetFrgn clsTbAssetFrgn;

        private byte status;
        private byte currency;

        public UCaccOpening()
        {
            InitializeComponent();
            InitData();
            InitDefaultData();
            GetResources();

            asAccNoLookUpEdit.EditValueChanged += AsAccNoLookUpEdit_EditValueChanged;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
        }

        private void InitObjects()
        {
            this.clsTbAccount = new ClsTblAccount();
            this.clsTbCurrency = new ClsTblCurrency();
        }

        private void InitData()
        {
            InitObjects();
            InitAsset();
            InitAssetForgn();
        }

        private void InitAsset()
        {
            this.clsTbAsset = new ClsTblAsset(true);
            tblAssetBindingSource.DataSource = this.clsTbAsset.AssetOpeningList;
            bsiRecordsCount.Caption = (!MySetting.GetPrivateSetting.LangEng) ? "العملات المحلية: " : "Local currency : " + tblAssetBindingSource.Count;
        }

        private void InitAssetForgn()
        {
            this.clsTbAssetFrgn = new ClsTblAssetFrgn();
            tblAssetFrgnBindingSource.DataSource = this.clsTbAssetFrgn.GetAssetFrgnList;
            bsiRecordsCountFrgn.Caption = (!MySetting.GetPrivateSetting.LangEng) ? "العملات المحلية: " : "Forign currency : " + tblAssetFrgnGridBindingSource.Count;
        }

        private void InitDefaultData()
        {
            tblAccountLocalCurrencyBindingSource.DataSource = this.clsTbAccount.GetAccountListType2LocalCurrency();
            tblAccountFrgnCurrencyBindingSource.DataSource = this.clsTbAccount.GetAccountListType2FrgnCurrency();
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "asCurrency")
                e.DisplayText = this.clsTbCurrency.GetCurrencyNameById(Convert.ToByte(e.Value));
        }

        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        public bool validate()
        {
            string mssg1 = (!MySetting.GetPrivateSetting.LangEng) ? "يرجى إدخال رقم الحساب وجانب المدين أو الدائن اولا!" : "Please enter account no. and debit or credit amount";
            string mssg2 = (!MySetting.GetPrivateSetting.LangEng) ? "يرجى إدخال جانب المدين أو الدائن اولا!" : "Please enter debit or credit amount";
            if (this.status == 1)
            {

                if (String.IsNullOrEmpty(accNoLookUp.Text))
                {

                    XtraMessageBox.Show(mssg1, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dxValidationProvider1.Validate();
                    accNoLookUp.Focus();
                    return false;
                }
                FieldInfo fi = typeof(DXValidationProvider).GetField("errorProvider", BindingFlags.NonPublic | BindingFlags.Instance);
                DXErrorProvider errorProvier = fi.GetValue(dxValidationProvider1) as DXErrorProvider;
                errorProvier.SetError(accNoLookUp, null);

                if (String.IsNullOrEmpty(textEdit2.Text) && String.IsNullOrEmpty(textEdit3.Text))
                {
                    XtraMessageBox.Show(mssg2, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dxValidationProvider1.Validate(textEdit2);
                    dxValidationProvider1.Validate(textEdit3);
                    textEdit2.Focus();
                    return false;
                }

                errorProvier.SetError(textEdit2, null);
                errorProvier.SetError(textEdit3, null);
                return true;
            }
            else
            {
                if (String.IsNullOrEmpty(asAccNoLookUpEdit.Text))
                {
                    XtraMessageBox.Show(mssg1, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dxValidationProvider2.Validate();
                    asAccNoLookUpEdit.Focus();
                    return false;
                }
                if (!int.TryParse(asCurrencyChngTextEdit.Text, out int val) || val == 0)
                {
                    dxValidationProvider2.Validate();
                    asCurrencyChngTextEdit.Focus();
                    return false;
                }
                FieldInfo fi = typeof(DXValidationProvider).GetField("errorProvider", BindingFlags.NonPublic | BindingFlags.Instance);
                DXErrorProvider errorProvier = fi.GetValue(dxValidationProvider2) as DXErrorProvider;
                errorProvier.SetError(asAccNoLookUpEdit, null);
                errorProvier.SetError(asCurrencyChngTextEdit, null);

                if (String.IsNullOrEmpty(asDebitFrgnTextEdit.Text) && String.IsNullOrEmpty(asCreditFrgnTextEdit.Text))
                {
                    XtraMessageBox.Show(mssg2, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dxValidationProvider2.Validate(asDebitFrgnTextEdit);
                    dxValidationProvider2.Validate(asCreditFrgnTextEdit);
                    asDebitFrgnTextEdit.Focus();
                    return false;
                }

                errorProvier.SetError(asCurrencyChngTextEdit, null);
                errorProvier.SetError(asDebitFrgnTextEdit, null);
                errorProvier.SetError(asCreditFrgnTextEdit, null);
                return true;
            }
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            this.status = 1;

            if (validate())
            {
                tblAsset tbAsset = new tblAsset
                {
                    asAccNo = Convert.ToInt64(accNoLookUp.EditValue),
                    asAccName = Convert.ToString(accNoLookUp.GetColumnValue("accName")),
                    asDate = DateTime.Now,
                    asBrnId = Session.CurBranch.brnId,
                    asUserId = Session.CurrentUser.id,
                    asEntId = 0,
                    asView = 1,
                    asStatus = 1
                };
                if (!String.IsNullOrEmpty(textEdit2.Text))
                    tbAsset.asDebit = Convert.ToInt32(textEdit2.EditValue);
                if (!String.IsNullOrEmpty(textEdit3.Text))
                    tbAsset.asCredit = Convert.ToInt32(textEdit3.EditValue);

                this.clsTbAsset.Add(tbAsset);

                if (this.clsTbAsset.Save)
                {
                    flyDailog.ShowDialogUC(this, (!MySetting.GetPrivateSetting.LangEng) ? "الرصيد الإفتتاحي" : "Opening credit");
                    InitAsset();

                    accNoLookUp.EditValue = null;
                    textEdit2.EditValue = null;
                    textEdit3.EditValue = null;
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.status = 2;

            if (validate())
            {
                short currencyChng = Convert.ToInt16(asCurrencyChngTextEdit.EditValue);
                tblAssetFrgn tbAssetFrgn = new tblAssetFrgn
                {
                    asAccNo = Convert.ToInt64(asAccNoLookUpEdit.EditValue),
                    asAccName = Convert.ToString(asAccNoLookUpEdit.GetColumnValue("accName")),
                    asDate = DateTime.Now,
                    asCurrency = this.currency,
                    asCurrencyChng = currencyChng,
                    asBrnId = Session.CurBranch.brnId,
                    asUserId = Session.CurrentUser.id,
                    asStatus = 1
                };
                if (!string.IsNullOrEmpty(asDebitFrgnTextEdit.Text))
                {
                    tbAssetFrgn.asDebit = Convert.ToInt32(asDebitFrgnTextEdit.EditValue) * currencyChng;
                    tbAssetFrgn.asDebitFrgn = Convert.ToInt32(asDebitFrgnTextEdit.EditValue);
                }
                if (!string.IsNullOrEmpty(asCreditFrgnTextEdit.Text))
                {
                    tbAssetFrgn.asCredit = Convert.ToInt32(asCreditFrgnTextEdit.EditValue) * currencyChng;
                    tbAssetFrgn.asCreditFrgn = Convert.ToInt32(asCreditFrgnTextEdit.EditValue);
                }
                this.clsTbAssetFrgn.Add(tbAssetFrgn);

                if (this.clsTbAssetFrgn.Save)
                {
                    flyDailog.ShowDialogUC(this, (!MySetting.GetPrivateSetting.LangEng) ? "الرصيد الإفتتاحي" : "Opening credit");
                    InitAssetForgn();

                    asAccNoLookUpEdit.EditValue = null;
                    asCurrencyChngTextEdit.EditValue = null;
                    asDebitFrgnTextEdit.EditValue = null;
                    asCurrencyChngTextEdit.EditValue = null;
                }
            }
        }

        private void AsAccNoLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;
            if (editor.GetColumnValue("accName") == null) return;

            this.currency = Convert.ToByte(editor.GetColumnValue("accCurrency"));
            asCurrencyChngTextEdit.EditValue = this.clsTbCurrency.GetCurrencyNameById(this.currency);
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblAssetBindingSource)) return;
            if (XtraMessageBox.Show(((!MySetting.GetPrivateSetting.LangEng) ? "هل انت متاكد من حذف الرصيد الافتتاحي : " : "Delete opeinging credit for : ")
                + gridView.GetFocusedRowCellValue(colasAccName), "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.clsTbAsset.Delete(tblAssetBindingSource.Current as tblAsset);
                if (this.clsTbAsset.Save)
                {
                    tblAssetBindingSource.RemoveCurrent();
                    flyDailog.ShowDialogUCCustomdMsg(this, (!MySetting.GetPrivateSetting.LangEng) ? "تم الحذف بنجاح" : "Deleted successfully");
                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblAssetFrgnGridBindingSource)) return;
            if (XtraMessageBox.Show(((!MySetting.GetPrivateSetting.LangEng) ? "هل انت متاكد من حذف الرصيد الافتتاحي : " : "Delete opeinging credit for : ")
                + gridView1.GetFocusedRowCellValue(colasAccName1), "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.clsTbAssetFrgn.Delete(tblAssetFrgnGridBindingSource.Current as tblAssetFrgn);
                if (this.clsTbAssetFrgn.Save)
                {
                    tblAssetFrgnGridBindingSource.RemoveCurrent();
                    flyDailog.ShowDialogUCCustomdMsg(this, (!MySetting.GetPrivateSetting.LangEng) ? "تم الحذف بنجاح" : "Deleted successfully");
                }
            }
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            InitData();
        }

        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            gridControl.RightToLeft = RightToLeft.No;

            _ci = new CultureInfo("en");
            _resource = new ComponentResourceManager(typeof(Language.UCAccOpeningEn));

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
            foreach (GridColumn c in gridView1.Columns)
            {
                _resource.ApplyResources(c, c.Name, _ci);
            }

            _resource.ApplyResources(ribbonPage1, ribbonPage1.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup1, ribbonPageGroup1.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup2, ribbonPageGroup2.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup3, ribbonPageGroup3.Name, _ci);
            _resource.ApplyResources(layoutControlGroup2, layoutControlGroup2.Name, _ci);
            _resource.ApplyResources(layoutControlItem1, layoutControlItem1.Name, _ci);
            _resource.ApplyResources(layoutControlItem2, layoutControlItem2.Name, _ci);
            _resource.ApplyResources(layoutControlItem3, layoutControlItem3.Name, _ci);
            _resource.ApplyResources(layoutControlGroup5, layoutControlGroup5.Name, _ci);
            _resource.ApplyResources(ItemForasAccNo, ItemForasAccNo.Name, _ci);
            _resource.ApplyResources(ItemForasCurrencyChng, ItemForasCurrencyChng.Name, _ci);
            _resource.ApplyResources(ItemForasDebitFrgn, ItemForasDebitFrgn.Name, _ci);
            _resource.ApplyResources(ItemForasCreditFrgn, ItemForasCreditFrgn.Name, _ci);

            layoutControlGroup2.AppearanceGroup.FontSizeDelta = -2;
            layoutControlGroup5.AppearanceGroup.FontSizeDelta = -2;
        }

        private void accNoLookUp_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Redo)
            {

                InitObjects();
                InitDefaultData();
            }
        }
    }
}
