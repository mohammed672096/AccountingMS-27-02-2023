using DevExpress.BarCodes;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.BarCode;
using DevExpress.XtraReports.UI;
using PosFinalCost.Classe;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosFinalCost
{
    public partial class formBarcode : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public string supPrdNameBarcode;
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        public formBarcode()
        {
            Program.Localization();
            InitializeComponent();
            this.barCode = new BarCode();

            InitComboBoxes();
            InitBarocdeSymbology();
            InitBarcodeDefaultData();
            InitUserSettings();

            this.Load += FormBarcode_Load;
            textEditSrchBarcode.KeyDown += TextEditSrchBarcode_KeyDown;
            textEditProduct.EditValueChanged += BarCodeText_EditValueChanged;
            textEditPrdMsur.EditValueChanged += TextEditPrdMsur_EditValueChanged;
            comboBoxEditSymbology.EditValueChanged += ComboBoxEdit2_EditValueChanged;
        }

        #region barcode 
        Image reImg
        {
            get;
            set;
        }
        BarcodeLib.Barcode b = new BarcodeLib.Barcode()
        {
            EncodedType = BarcodeLib.TYPE.CODE128,
            IncludeLabel = true,
            LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER,
            Alignment = BarcodeLib.AlignmentPositions.CENTER

        };
        Image drawImg(int width = 100, int Height = 50, string code = "")
        {

            int W = width;
            int H = Height;


            try
            {
                // b.BarWidth = textBoxBarWidth.Text.Trim().Length < 1 ? null : (int?)Convert.ToInt32(textBoxBarWidth.Text.Trim());

                Image img = b.Encode(BarcodeLib.TYPE.CODE128, code, W, H);// this.btnForeColor.BackColor, this.btnBackColor.BackColor, W, H);

                return img;
            }
            catch (Exception ex)
            {

                width++;
                return drawImg(width, Height, code);
            }


        }
        #endregion

        private void FormBarcode_Load(object sender, EventArgs e)
        {
            tblProductBindingSource.DataSource = Session.Products;
            textEditCompanyName.EditValue = Session.CurrentBranch.Name;
        }

        private void InitBarcodeDefaultData()
        {
            this.barCode.Symbology = Symbology.EAN13;

            Font fontDefault = new Font("Segoe UI", 8.75F);
            barCode.CodeTextFont = fontDefault;
            barCode.BottomCaption.Font = fontDefault;
            barCode.TopCaption.Font = fontDefault;
            barCode.TopCaption.Font = label1.Font;
            barCode.BottomCaption.Font = label1.Font;
        }

        private void InitBarocdeSymbology()
        {
            comboBoxEditSymbology.Properties.Items.AddRange(typeof(Symbology).GetEnumValues());
            comboBoxEditSymbology.EditValue = Symbology.Code128;
        }

        private void showTextCE_CheckStateChanged(object sender, EventArgs e)
        {
            SetBarcodeShowText();
            RefreshBarcodePicture();
        }

        private void TextEditSrchBarcode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SearchProduct(textEditSrchBarcode.Text);
        }
        //PosDBDataContext db = new PosDBDataContext(Program.ConnectionString);

        public  void SearchProduct(string barcodeNo)
        {
            textEditSrchBarcode.EditValue = null;
            if (!ValidateBarcodeNo(barcodeNo)) return;

            var barcode = Session.Barcodes.FirstOrDefault(x => x.MsurBarcode == barcodeNo);
            if (barcode == null) return;
            var PriceMsur = Session.PrdMeasurments.FirstOrDefault(x => x.ID == barcode.MsurId);

            textEditPrdMsur.EditValue = barcode.MsurId;
            textEditProduct.EditValue = PriceMsur.PrdId;
        }

        private bool ValidateBarcodeNo(string barcodeNo)
        {

            bool isValid = Session.Barcodes.Any(x => x.MsurBarcode == barcodeNo);
            if (!isValid)
                ClsXtraMssgBox.ShowError(Program.My_Setting.LangEng ? "Sorry, the barcode number does not exist!" : "عذراُ، رقم الباركود غير موجود!");

            return isValid;
        }

        private void BarCodeText_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit editor = sender as SearchLookUpEdit;
            if (editor?.EditValue == null) return;

            textEditProductName.EditValue = editor.Properties.GetDisplayText(editor.EditValue);
            InitPrdMsurData(Convert.ToInt32(editor.EditValue));
        }

        private void TextEditPrdMsur_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;

            //    var tbPrdMsur = editor.GetSelectedDataRow() as tblPrdPriceMeasurment;
            if (editor?.EditValue is int ppmId)
            {
                var tbPrdMsur = Session.PrdMeasurments.FirstOrDefault(x => x.ID == ppmId);
                if (tbPrdMsur == null) return;
                var barcode = Session.Barcodes.FirstOrDefault(x => x.MsurId == tbPrdMsur.ID);
                textEditBarocdeNo.EditValue = barcode.MsurBarcode;
                bool proTax = (Session.Products.AsQueryable().FirstOrDefault(x => x.ID == tbPrdMsur.PrdId)?.PriceTax)??false;
                textEditPrdPrice.EditValue = myFunaction.GetSalePrice(proTax,tbPrdMsur);
            }

            //   textEditBarocdeNo.EditValue = tbPrdMsur.ppmBarcode1;

        }
        MyFunaction myFunaction = new MyFunaction();
        private void InitPrdMsurData(int prdId)
        {
            tblPrdPriceMeasurmentBindingSource.DataSource = Session.PrdMeasurments.Where(x => x.PrdId == prdId).ToList();
            textEditPrdMsur.EditValue = Session.PrdMeasurments.FirstOrDefault(x => x.PrdId == prdId && x.Default == true)?.ID;
        }

        private void ComboBoxEdit2_EditValueChanged(object sender, EventArgs e)
        {
            this.barCode.Symbology = (Symbology)comboBoxEditSymbology.EditValue;
            RefreshBarcodePicture();
        }

        private void editValueChanged(object sender, EventArgs e)
        {
            RefreshBarcodePicture();
        }

        #region RefreshBarcodePicture
        void RefreshBarcodePicture()
        {
            pictureEdit.Image = null;
            InitializeBarCode();
            try
            {
                errorText.Visible = false;
                pictureEdit.Image = barCode?.BarCodeImage;
                pictureEdit.Size = pictureEdit.Image.Size;
            }
            catch
            {
                errorText.Visible = true;
            }
            pictureEdit.Refresh();

            if (!string.IsNullOrEmpty(textEditBarocdeNo.Text))
            {
                reImg = drawImg(code: textEditBarocdeNo.Text);
                picbarcode.Image = reImg;
                picbarcode.Width = reImg.Width + 20;
                picbarcode.Refresh();
                picbarcode.Update();
            }
        }

        void InitializeBarCode()
        {
            if (barCode == null) return;
            //barCode.Symbology = Symbology.DataBar;

            barCode.BackColor = backColorE.Color;
            barCode.ForeColor = foreColorE.Color;
            barCode.RotationAngle = (float)angleSE.Value;
            barCode.CodeTextHorizontalAlignment = (StringAlignment)codeTextHorzAlignmentCB.SelectedItem;
            barCode.CodeTextVerticalAlignment = (StringAlignment)codeTextVertAlignmentCB.SelectedItem;
            if (codeTextFE.SelectedItem != null) barCode.CodeTextFont = new Font((string)codeTextFE.SelectedItem, barCode.CodeTextFont.Size);

            barCode.TopCaption.Text = checkEditCompanyName.Checked ? textEditCompanyName.Text : string.Empty;
            barCode.TopCaption.HorizontalAlignment = (StringAlignment)topCaptionAligmentCB.SelectedItem;
            barCode.TopCaption.ForeColor = topCaptionForeCE.Color;
            if (topCaptionFE.SelectedItem != null) barCode.TopCaption.Font = new Font((string)topCaptionFE.SelectedItem, barCode.TopCaption.Font.Size);

            barCode.BottomCaption.Text = checkEditPrdName.Checked ? textEditProductName.Text : string.Empty;
            barCode.BottomCaption.HorizontalAlignment = (StringAlignment)bottomCaptionAligmentCB.SelectedItem;
            barCode.BottomCaption.ForeColor = bottomCaptionForeCE.Color;
            if (bottomCaptionFE.SelectedItem != null) barCode.BottomCaption.Font = new Font((string)bottomCaptionFE.SelectedItem, barCode.BottomCaption.Font.Size);

            if (!string.IsNullOrEmpty(textEditWidth.Text)) barCode.Module = Convert.ToDouble(textEditWidth.EditValue);
            if (!string.IsNullOrEmpty(textEditHeight.Text)) barCode.BarHeight = float.Parse(textEditHeight.Text);

            barCode.AutoSize = true;
            barCode.DpiX = 108;
            barCode.DpiY = 108;
            InitializeBarcodeText();
        }

        void InitializeBarcodeText()
        {
            barCode.CodeText = string.IsNullOrEmpty(textEditBarocdeNo.Text) ? null : textEditBarocdeNo.EditValue.ToString();
        }
        #endregion

        private void BtnDefaultSettings_Click(object sender, EventArgs e)
        {
            InitDefaultSettings();
            RefreshBarcodePicture();
        }

        private void BtnUserSettings_Click(object sender, EventArgs e)
        {
            InitUserSettings();
            RefreshBarcodePicture();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;

            flyDialog.WaitForm(this, 1);
            //  ReportBarcode report = new ReportBarcode(this.barCode, GetDictionarySettings());
            ReportBarcode report = new ReportBarcode(this.barCode, this.picbarcode, GetDictionarySettings());
            // report.Margins.Left = 3;
            report.Margins.Right = 3;
            report.DefaultPrinterSettingsUsing.UseMargins = true;
            report.ShowPrintMarginsWarning = false;
            //     report.PrintingSystem.StartPrint += PrintingSystem_StartPrint;
            report.PrintingSystem.StartPrint += (ss, ee) => { ee.PrintDocument.PrinterSettings.Copies = Convert.ToInt16(spinEdit1.EditValue); };
            using ReportPrintTool printTool = new ReportPrintTool(report);

            flyDialog.WaitForm(this, 0);

            printTool.ShowPreviewDialog();
            spinEdit1.EditValue = 1;
        }



        private bool ValidateData()
        {
            if (!dxValidationProvider1.Validate()) return false;
            if (textEditBarocdeNo.EditValue == null) return false;
            return true;
        }

        private void BtnPrintBarocde_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;
            flyDialog.WaitForm(this, 1);
            PrintBarcode(this.barCode, picbarcode, GetDictionarySettings(), Convert.ToInt16(spinEdit1.EditValue));
            flyDialog.WaitForm(this, 0);
            spinEdit1.EditValue = 1;

        }
        public void PrintBarcode(DevExpress.BarCodes.BarCode barCode, System.Windows.Forms.PictureBox picbarcode, IDictionary<BarcodeSettings, string> barcodeSettings, short Copies = 1)
        {
            using var report = new ReportBarcode(barCode, picbarcode, barcodeSettings);
            report.ShowPrintMarginsWarning = false;
            report.PrintingSystem.StartPrint += (ss, ee) => { ee.PrintDocument.PrinterSettings.Copies = Copies; };
            report.PrinterName = textEditPrinterBarcod.Text;
            report.Margins.Right = 3;
            report.DefaultPrinterSettingsUsing.UseMargins = true;
            report.CreateDocument();
            report.Print();
        }
        private Bitmap GetNewBarcode()
        {
            BarCode barCodeTemp = this.barCode;
            barCodeTemp.TopCaption.Text = null;
            barCodeTemp.BottomCaption.Text = null;
            return (Bitmap)barCodeTemp.BarCodeImage;
        }

        private IDictionary<BarcodeSettings, string> GetDictionarySettings()
        {
            IDictionary<BarcodeSettings, string> barcodeSettings = new Dictionary<BarcodeSettings, string>();

            if (checkEditCompanyName.Checked && !string.IsNullOrEmpty(textEditCompanyName.Text))
                barcodeSettings.Add(BarcodeSettings.CompanyName, textEditCompanyName.Text);
            if (checkEditBarcodeNo.Checked && !string.IsNullOrEmpty(textEditBarocdeNo.Text))
                barcodeSettings.Add(BarcodeSettings.BarcodeNo, textEditBarocdeNo.Text);
            if (checkEditPrdName.Checked && !string.IsNullOrEmpty(textEditProductName.Text))
                barcodeSettings.Add(BarcodeSettings.ProductName, textEditProductName.Text);
            if (!string.IsNullOrWhiteSpace(textEditOtherInfo.Text))
                barcodeSettings.Add(BarcodeSettings.OtherInfo, textEditOtherInfo.Text);
            if (checkEditExpireDate.Checked && !string.IsNullOrEmpty(textEditExpireDate.Text))
                barcodeSettings.Add(BarcodeSettings.ExpireDate, string.Format((!Program.My_Setting.LangEng) ? "تاريخ الإنتهاء: {0}" : "Expiration Date: {0}", textEditExpireDate.DateTime.ToShortDateString()));
            if (checkEditPrdPrice.Checked && !string.IsNullOrEmpty(textEditPrdPrice.Text))
            {
                decimal price = Convert.ToDecimal(textEditPrdPrice.EditValue);
                decimal tax = Convert.ToDecimal(Session.CurrSettings.taxDefault);
                decimal priceTax = (tax != 0) ? (price + (price * tax)) : price;
                if (Program.My_Setting.LangEng)
                    barcodeSettings.Add(BarcodeSettings.Price, (!checkEditSaleTax.Checked ? $"price: {price:n2}" : $"The price includes tax: {priceTax:n2}"));
                else
                    barcodeSettings.Add(BarcodeSettings.Price, (!checkEditSaleTax.Checked ? $"السعر: {price:n2}" : $"السعر شامل الضريبة: {priceTax:n2}"));
            }
            barcodeSettings.Add(BarcodeSettings.PageWidth, Convert.ToDouble(textEditPageWidth.EditValue).ToString());

            return barcodeSettings;
        }

        private void InitDefaultSettings()
        {
            comboBoxEditSymbology.EditValue = Symbology.Code128;
            checkEditBarcodeNo.Checked = true;
            checkEditCompanyName.Checked = true;
            checkEditPrdName.Checked = true;
            checkEditExpireDate.Checked = false;
            checkEditPrdPrice.Checked = false;
            textEditWidth.EditValue = 0.5F;
            textEditHeight.EditValue = 10F;
            textEditPageWidth.EditValue = 7F;
        }

        private void InitUserSettings()
        {
            BarSetting.ReadBarSettingXml();
            comboBoxEditSymbology.EditValue = (Symbology)BarSetting.GetBarSetting.barcodeSymbology;
            checkEditBarcodeNo.Checked = BarSetting.GetBarSetting.barcodeBarcodeNo;
            checkEditCompanyName.Checked = BarSetting.GetBarSetting.barcodeCompanyName;
            checkEditPrdName.Checked = BarSetting.GetBarSetting.barcodePrdName;
            checkEditExpireDate.Checked = BarSetting.GetBarSetting.barcodeExpireDate;
            checkEditPrdPrice.Checked = BarSetting.GetBarSetting.barcodePrdPrice;
            textEditWidth.EditValue = BarSetting.GetBarSetting.barcodeWidth;
            textEditHeight.EditValue = BarSetting.GetBarSetting.barcodeHeight;
            textEditPageWidth.EditValue = BarSetting.GetBarSetting.barcodePageWidth;
            checkEditSaleTax.Checked = BarSetting.GetBarSetting.checkEditSaleTax;
            textEditPrinterBarcod.EditValue = BarSetting.GetBarSetting.barcodePrinterName;
        }

        private void BtnSaveUserSettings_Click(object sender, EventArgs e)
        {
            BarSetting.GetBarSetting.barcodeSymbology = Convert.ToByte(comboBoxEditSymbology.EditValue);
            BarSetting.GetBarSetting.barcodeBarcodeNo = checkEditBarcodeNo.Checked;
            BarSetting.GetBarSetting.barcodeCompanyName = checkEditCompanyName.Checked;
            BarSetting.GetBarSetting.barcodePrdName = checkEditPrdName.Checked;
            BarSetting.GetBarSetting.barcodeExpireDate = checkEditExpireDate.Checked;
            BarSetting.GetBarSetting.barcodePrdPrice = checkEditPrdPrice.Checked;
            BarSetting.GetBarSetting.barcodeWidth = (float)Convert.ToDouble(textEditWidth.EditValue);
            BarSetting.GetBarSetting.barcodeHeight = (float)Convert.ToDouble(textEditHeight.EditValue);
            BarSetting.GetBarSetting.barcodePageWidth = (float)Convert.ToDouble(textEditPageWidth.EditValue);
            BarSetting.GetBarSetting.checkEditSaleTax = checkEditSaleTax.Checked;
            BarSetting.GetBarSetting.barcodePrinterName = textEditPrinterBarcod.Text;
            BarSetting.WriterBarSettingXml();
            XtraMessageBox.Show((!Program.My_Setting.LangEng) ? "تم حفظ الإعدادات بنجاح." : "Saved successfully.");
        }
        public static BarSetting BarSetting = new BarSetting();
        private void SetBarcodeShowText()
        {
            barCode.Options.Codabar.ShowCodeText = checkEditBarcodeNo.Checked;
            barCode.Options.Code11.ShowCodeText = checkEditBarcodeNo.Checked;
            barCode.Options.Code39.ShowCodeText = checkEditBarcodeNo.Checked;
            barCode.Options.Code39Extended.ShowCodeText = checkEditBarcodeNo.Checked;
            barCode.Options.Code93.ShowCodeText = checkEditBarcodeNo.Checked;
            barCode.Options.Code93Extended.ShowCodeText = checkEditBarcodeNo.Checked;
            barCode.Options.Code128.ShowCodeText = checkEditBarcodeNo.Checked;
            barCode.Options.CodeMSI.ShowCodeText = checkEditBarcodeNo.Checked;
            barCode.Options.DataBar.ShowCodeText = checkEditBarcodeNo.Checked;
            barCode.Options.DataMatrix.ShowCodeText = checkEditBarcodeNo.Checked;
            barCode.Options.DataMatrixGS1.ShowCodeText = checkEditBarcodeNo.Checked;
            barCode.Options.EAN8.ShowCodeText = checkEditBarcodeNo.Checked;
            barCode.Options.EAN13.ShowCodeText = checkEditBarcodeNo.Checked;
            barCode.Options.EAN128.ShowCodeText = checkEditBarcodeNo.Checked;
            barCode.Options.Industrial2of5.ShowCodeText = checkEditBarcodeNo.Checked;
            barCode.Options.Interleaved2of5.ShowCodeText = checkEditBarcodeNo.Checked;
            barCode.Options.IntelligentMail.ShowCodeText = checkEditBarcodeNo.Checked;
            barCode.Options.ITF14.ShowCodeText = checkEditBarcodeNo.Checked;
            barCode.Options.Matrix2of5.ShowCodeText = checkEditBarcodeNo.Checked;
            barCode.Options.PDF417.ShowCodeText = checkEditBarcodeNo.Checked;
            barCode.Options.PostNet.ShowCodeText = checkEditBarcodeNo.Checked;
            barCode.Options.QRCode.ShowCodeText = checkEditBarcodeNo.Checked;
            barCode.Options.UPCA.ShowCodeText = checkEditBarcodeNo.Checked;
            barCode.Options.UPCE0.ShowCodeText = checkEditBarcodeNo.Checked;
            barCode.Options.UPCE1.ShowCodeText = checkEditBarcodeNo.Checked;
            barCode.Options.UPCSupplemental2.ShowCodeText = checkEditBarcodeNo.Checked;
            barCode.Options.UPCSupplemental5.ShowCodeText = checkEditBarcodeNo.Checked;
        }

        private BarCodeGeneratorBase GetBarCodeSymbology(Symbology symbology)
        {
            switch (symbology)
            {
                case Symbology.QRCode:
                    return new QRCodeGenerator();
                case Symbology.Codabar:
                    return new CodabarGenerator();
                case Symbology.Code11:
                    return new Code11Generator();
                case Symbology.Code128:
                    return new Code128Generator();
                case Symbology.Code39:
                    return new Code39Generator();
                case Symbology.Code39Extended:
                    return new Code93ExtendedGenerator();
                case Symbology.Code93:
                    return new Code93Generator();
                case Symbology.Code93Extended:
                    return new Code93ExtendedGenerator();
                case Symbology.CodeMSI:
                    return new CodeMSIGenerator();
                case Symbology.DataBar:
                    return new DataBarGenerator();
                case Symbology.DataMatrix:
                    return new DataMatrixGenerator();
                case Symbology.DataMatrixGS1:
                    return new DataMatrixGS1Generator();
                case Symbology.EAN128:
                    return new EAN128Generator();
                default:
                    return new Code11Generator();
            }
        }

        private void InitComboBoxes()
        {
            textEditPrinterBarcod.Properties.DataSource = MyTools.GetListPrinter;
            foreach (StringAlignment alignment in Enum.GetValues(typeof(StringAlignment)))
            {
                topCaptionAligmentCB.Properties.Items.Add(alignment);
                bottomCaptionAligmentCB.Properties.Items.Add(alignment);
                codeTextHorzAlignmentCB.Properties.Items.Add(alignment);
                codeTextVertAlignmentCB.Properties.Items.Add(alignment);
            }
            ((System.ComponentModel.ISupportInitialize)(this.topCaptionAligmentCB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomCaptionAligmentCB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeTextHorzAlignmentCB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeTextVertAlignmentCB.Properties)).BeginInit();
            topCaptionAligmentCB.SelectedIndex = 1;
            bottomCaptionAligmentCB.SelectedIndex = 1;
            codeTextHorzAlignmentCB.SelectedIndex = 1;
            codeTextVertAlignmentCB.SelectedIndex = 1;
            ((System.ComponentModel.ISupportInitialize)(this.topCaptionAligmentCB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomCaptionAligmentCB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeTextHorzAlignmentCB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeTextVertAlignmentCB.Properties)).EndInit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void checkEditSaleTax_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEditSaleTax.Checked) checkEditPrdPrice.Checked = true;
        }

        private void formBarcode_Activated(object sender, EventArgs e)
        {
        
            //textEditProduct.Text= supPrdNameBarcode ;
        }
    }
}

