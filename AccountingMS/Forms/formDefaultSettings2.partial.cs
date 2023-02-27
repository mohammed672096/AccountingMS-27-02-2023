using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace accounting_1._0
{
    public partial class formDefaultSettings2
    {
        IList<tblProductColor> tbPrdColorList;
        CustomValidationRule customValidation;

        byte prdColorCount;

        private void InitPrdColorData()
        {
            this.tbPrdColorList = this.clsTbPrdColor.GetTblProductColorList;
            this.prdColorCount = (byte)this.tbPrdColorList.Count;
            
            InitPrdBinding();
            InitCustomValidation();
        }

        private void InitCustomValidation()
        {
            this.customValidation = new CustomValidationRule();
            this.customValidation.ErrorText = "This value is not valid";
        }

        private void InitPrdBinding()
        {
            InitPrdBindingData(tblProductColorBindingSource1, colorPickEdit1, 1);
            InitPrdBindingData(tblProductColorBindingSource2, colorPickEdit2, 2);
            InitPrdBindingData(tblProductColorBindingSource3, colorPickEdit3, 3);
        }

        private void InitPrdBindingData(BindingSource tblProductColorBindingSource, ColorPickEdit colorPickEdit, byte prdColorCount)
        {
            if (prdColorCount > this.prdColorCount)
                tblProductColorBindingSource.DataSource = new tblProductColor();
            else
            {
                tblProductColor tbPrdColor = this.tbPrdColorList[prdColorCount - 1];
                tblProductColorBindingSource.DataSource = tbPrdColor;
                this.clsTbPrdColor.Attach(tblProductColorBindingSource.Current as tblProductColor);

                colorPickEdit.Color = ColorTranslator.FromHtml(tbPrdColor.colHtml);
            }
        }

        private void ColorPickEdit1_EditValueChanged(object sender, EventArgs e)
        {
            colHtmlTextEdit1.EditValue = ColorTranslator.ToHtml(colorPickEdit1.Color);
        }

        private void ColorPickEdit2_EditValueChanged(object sender, EventArgs e)
        {
            colHtmlTextEdit2.EditValue = ColorTranslator.ToHtml(colorPickEdit2.Color);
        }

        private void ColorPickEdit3_EditValueChanged(object sender, EventArgs e)
        {
            colHtmlTextEdit3.EditValue = ColorTranslator.ToHtml(colorPickEdit3.Color);
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
    }

    public class CustomValidationRule : ValidationRule
    {
        public override bool Validate(Control control, object value)
        {
            return ((Color)value == Color.Empty) ? false : true;
        }
    }
}
