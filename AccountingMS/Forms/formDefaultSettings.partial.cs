using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formDefaultSettings
    {
        IList<tblProductColor> tbPrdColorList;
        CustomValidationRule customValidation;
        tblProductColor tbPrdColor1;
        tblProductColor tbPrdColor2;
        tblProductColor tbPrdColor3;
        IList<tblDefaultAccount> tbDefaultAccountList;

        byte prdColorCount;
        byte dfltAccountCount;

        private void InitPrdColorData()
        {
            this.tbPrdColorList = this.clsTbPrdColor.GetProductColorList;
            this.prdColorCount = (byte)this.tbPrdColorList.Count;

            InitPrdBinding();
            InitCustomValidation();
        }

        private void InitPrdBinding()
        {
            InitPrdBindingData(tblProductColorBindingSource1, 1);
            InitPrdBindingData(tblProductColorBindingSource2, 2);
            InitPrdBindingData(tblProductColorBindingSource3, 3);
        }

        private void InitPrdBindingData(BindingSource tblProductColorBindingSource, byte prdColorCount)
        {
            if (prdColorCount > this.prdColorCount)
                tblProductColorBindingSource.DataSource = InitPrdColorObject(prdColorCount);
            else
            {
                tblProductColorBindingSource.DataSource = AttachPrdColorObject(prdColorCount);
                this.clsTbPrdColor.Attach(tblProductColorBindingSource.Current as tblProductColor);
            }
        }

        private tblProductColor InitPrdColorObject(byte prdColorCount)
        {
            switch (prdColorCount)
            {
                case 1:
                    this.tbPrdColor1 = new tblProductColor();
                    return this.tbPrdColor1;
                case 2:
                    this.tbPrdColor2 = new tblProductColor();
                    return this.tbPrdColor2;
                case 3:
                    this.tbPrdColor3 = new tblProductColor();
                    return this.tbPrdColor3;
                default:
                    return null;
            }
        }

        private object AttachPrdColorObject(byte prdColorCount)
        {
            switch (prdColorCount)
            {
                case 1:
                    this.tbPrdColor1 = this.tbPrdColorList[prdColorCount - 1];
                    colorPickEdit1.Color = ColorTranslator.FromHtml(this.tbPrdColor1.colHtml);
                    return this.tbPrdColor1;
                case 2:
                    this.tbPrdColor2 = this.tbPrdColorList[prdColorCount - 1];
                    colorPickEdit2.Color = ColorTranslator.FromHtml(this.tbPrdColor2.colHtml);
                    return this.tbPrdColor2;
                case 3:
                    this.tbPrdColor3 = this.tbPrdColorList[prdColorCount - 1];
                    colorPickEdit3.Color = ColorTranslator.FromHtml(this.tbPrdColor3.colHtml);
                    return this.tbPrdColor3;
                default:
                    return null;
            }
        }

        private void ColorPickEdit1_EditValueChanged(object sender, EventArgs e)
        {
            this.tbPrdColor1.colHtml = ColorTranslator.ToHtml(colorPickEdit1.Color);
        }

        private void ColorPickEdit2_EditValueChanged(object sender, EventArgs e)
        {
            this.tbPrdColor2.colHtml = ColorTranslator.ToHtml(colorPickEdit2.Color);
        }

        private void ColorPickEdit3_EditValueChanged(object sender, EventArgs e)
        {
            this.tbPrdColor3.colHtml = ColorTranslator.ToHtml(colorPickEdit3.Color);
        }

        private bool SavePrdColor()
        {
            if (!ValidatePrdColorData()) return false;
            SaveNewPrdColorData();

            return clsTbPrdColor.Save();
        }

        private void SaveNewPrdColorData()
        {
            if (this.prdColorCount < 1 && Convert.ToInt32(colQuanSpinEdit1.EditValue) > 0)
                this.clsTbPrdColor.Add(tblProductColorBindingSource1.Current as tblProductColor);
            if (this.prdColorCount < 2 && Convert.ToInt32(colQuanSpinEdit2.EditValue) > 0)
                this.clsTbPrdColor.Add(tblProductColorBindingSource2.Current as tblProductColor);
            if (this.prdColorCount < 3 && Convert.ToInt32(colQuanSpinEdit3.EditValue) > 0)
                this.clsTbPrdColor.Add(tblProductColorBindingSource3.Current as tblProductColor);
        }

        private bool ValidatePrdColorData()
        {
            SetValidation(colQuanSpinEdit1, colorPickEdit1);
            SetValidation(colQuanSpinEdit2, colorPickEdit2);
            SetValidation(colQuanSpinEdit3, colorPickEdit3);

            if (!dxValidationProvider1.Validate())
            {
                XtraMessageBox.Show((!Properties.Settings.Default.langEng) ? "يرجى إدخال بيانات الأصناف المطلوبه" : "Please enter all products required data", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void SetValidation(SpinEdit colQuanSpinEdit, ColorPickEdit colorPickEdit)
        {
            if (Convert.ToInt32(colQuanSpinEdit.EditValue) > 0)
                dxValidationProvider1.SetValidationRule(colorPickEdit, this.customValidation);
            else
                dxValidationProvider1.SetValidationRule(colorPickEdit, null);
        }

        private void InitCustomValidation()
        {
            this.customValidation = new CustomValidationRule();
            this.customValidation.ErrorText = "This value is not valid";
        }

        private void InitDefaultAccountsData()
        {
            this.tbDefaultAccountList = this.clsTbDefaultAccount.GetTblDefaultAccountsList;
            this.dfltAccountCount = (byte)this.tbDefaultAccountList.Count;

            InitDefaultAccBinding();
        }

        private void InitDefaultAccDataBinding(BindingSource tblDefaulttAcctBindingSource, byte dfltAccountCount)
        {
            if (!this.clsTbDefaultAccount.IsDefaultAccFound(dfltAccountCount, ClsBranchId.BranchId))
                tblDefaulttAcctBindingSource.DataSource = new tblDefaultAccount()
                {
                    dfltBrnId = ClsBranchId.BranchId,
                    dflStatus = dfltAccountCount
                };
            else
            {
                var tbDfltAcc = this.clsTbDefaultAccount.GetDefaultAccByStatus(dfltAccountCount);
                tblDefaulttAcctBindingSource.DataSource = tbDfltAcc;
                this.clsTbDefaultAccount.Attach(tbDfltAcc);
            }
        }

        private void SaveNewDefaultAccData(BindingSource tblDefaulttAcctBindingSource, LookUpEdit dflAccNoTextEdit, byte dfltAccountCount)
        {
            if (!this.clsTbDefaultAccount.IsDefaultAccFound(dfltAccountCount, ClsBranchId.BranchId) && !string.IsNullOrEmpty(dflAccNoTextEdit.Text))
                this.clsTbDefaultAccount.Add(tblDefaulttAcctBindingSource.DataSource as tblDefaultAccount);
        }

        private void InitDefaultAccBinding()
        {
            InitDefaultAccDataBinding(tblDfltAccNoBindingSource1, 1);
            InitDefaultAccDataBinding(tblDfltAccNoBindingSource2, 2);
            InitDefaultAccDataBinding(tblDfltAccNoBindingSource3, 3);
            InitDefaultAccDataBinding(tblDfltAccNoBindingSource4, 4);
            InitDefaultAccDataBinding(tblDfltAccNoBindingSource5, 5);
            InitDefaultAccDataBinding(tblDfltAccNoBindingSource6, 6);
            InitDefaultAccDataBinding(tblDfltAccNoBindingSource7, 7);
            InitDefaultAccDataBinding(tblDfltAccNoBindingSource8, 8);
            InitDefaultAccDataBinding(tblDfltAccNoBindingSource9, 9);
            InitDefaultAccDataBinding(tblDfltAccNoBindingSource10, 10);
            InitDefaultAccDataBinding(tblDfltAccNoBindingSource11, 11);
            InitDefaultAccDataBinding(tblDfltAccNoBindingSource12, 12);
            InitDefaultAccDataBinding(tblDfltAccNoBindingSource13, 13);
            InitDefaultAccDataBinding(tblDfltAccNoBindingSource14, 14);
            InitDefaultAccDataBinding(tblDfltAccNoBindingSource15, 15);
        }

        private bool SaveDefaultAccData()
        {
            SaveNewDefaultAccData(tblDfltAccNoBindingSource1, dflAccNoTextEdit1, 1);
            SaveNewDefaultAccData(tblDfltAccNoBindingSource2, dflAccNoTextEdit2, 2);
            SaveNewDefaultAccData(tblDfltAccNoBindingSource3, dflAccNoTextEdit3, 3);
            SaveNewDefaultAccData(tblDfltAccNoBindingSource4, dflAccNoTextEdit4, 4);
            SaveNewDefaultAccData(tblDfltAccNoBindingSource5, dflAccNoTextEdit5, 5);
            SaveNewDefaultAccData(tblDfltAccNoBindingSource6, dflAccNoTextEdit6, 6);
            SaveNewDefaultAccData(tblDfltAccNoBindingSource7, dflAccNoTextEdit7, 7);
            SaveNewDefaultAccData(tblDfltAccNoBindingSource8, dflAccNoTextEdit8, 8);
            SaveNewDefaultAccData(tblDfltAccNoBindingSource9, dflAccNoTextEdit9, 9);
            SaveNewDefaultAccData(tblDfltAccNoBindingSource10, dflAccNoTextEdit10, 10);
            SaveNewDefaultAccData(tblDfltAccNoBindingSource11, dflAccNoTextEdit11, 11);
            SaveNewDefaultAccData(tblDfltAccNoBindingSource12, textEditPrdExpirateAcc, 12);
            SaveNewDefaultAccData(tblDfltAccNoBindingSource13, dflAccNoTextEdit13, 13);
            SaveNewDefaultAccData(tblDfltAccNoBindingSource14, dflAccNoTextEdit14, 14);
            SaveNewDefaultAccData(tblDfltAccNoBindingSource15, dflAccNoTextEdit15, 15);

            return this.clsTbDefaultAccount.Save();
        }

        private void InitInvData()
        {
            tblInvTypeBindingSource.DataSource = this.clsTbInvType.GetTbInvType;
            this.clsTbInvType.Attach();
        }

        private void radioGroupInvType_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (!ValidateAdminUser())
            {
                e.Cancel = true;
                return;
            }
            e.Cancel = !ConfirmMssg();
        }

        private bool ValidateAdminUser()
        {
            bool isVaid = ClsUserId.UserId != 1 ? false : true;

            if (!isVaid) ClsXtraMssgBox.ShowError("عذراً ليس لديك صلاحيات للقيام بهذه العملية!");

            return isVaid;
        }

        private bool ConfirmMssg()
        {
            bool isConfirm = ClsXtraMssgBox.ShowWarningYesNo("هل أنت متأكد من تغير نوع الجرد ؟") == DialogResult.Yes ? true : false;

            return isConfirm;
        }
    }

    public class CustomValidationRule : ValidationRule
    {
        public override bool Validate(Control control, object value)
        {
            return ((Color)value == Color.Empty) ? false : true;
        }
    }
}
