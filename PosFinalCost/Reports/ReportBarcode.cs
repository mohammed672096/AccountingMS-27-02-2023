using DevExpress.BarCodes;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace PosFinalCost
{
    public partial class ReportBarcode : XtraReport
    {
        public ReportBarcode(BarCode barCode, IDictionary<BarcodeSettings, string> barcodeSettings)
        {
            InitializeComponent();
            SetPageWidth(barcodeSettings);
            SetCompanyName(barcodeSettings);
            CreateBarcodeImage(barCode);
            InitLabels(barcodeSettings);
        }

        public ReportBarcode(BarCode barCode, System.Windows.Forms.PictureBox picbarcode, IDictionary<BarcodeSettings, string> barcodeSettings)
        {
            InitializeComponent();
            SetPageWidth(barcodeSettings);
            SetCompanyName(barcodeSettings);
            // CreateBarcodeImage(barCode);
            CreateBarcodeImage(barCode, picbarcode);
            //InitLabels(barcodeSettings);
            InitLabels(barcodeSettings, 1);
        }
        private void InitLabels(IDictionary<BarcodeSettings, string> barcodeSettings, int i)
        {
            foreach (var barcode in barcodeSettings)
                switch (barcode.Key)
                {
                    //case BarcodeSettings.BarcodeNo:
                    //    CreateLabel().Text = barcode.Value;
                    //    break;
                    case BarcodeSettings.ProductName:
                        CreateLabel().Text = barcode.Value;
                        break;
                    //case BarcodeSettings.OtherInfo:
                    //    CreateLabel().Text = barcode.Value;
                    //    break;
                    case BarcodeSettings.Price:
                        CreateLabel().Text = barcode.Value;
                        break;
                    case BarcodeSettings.ExpireDate:
                        CreateLabel().Text = barcode.Value;
                        break;
                }
        }
        private void CreateBarcodeImage(BarCode barCode, System.Windows.Forms.PictureBox picbarcode)
        {
            XRPictureBox pictureBox = new XRPictureBox()
            {
                Borders = BorderSide.None,
                Sizing = ImageSizeMode.AutoSize,
                LocationF = new PointF((this.PageWidth - picbarcode.Image.Width) / 2, Detail.HeightF),
            };

            pictureBox.Image = picbarcode.Image;
            Detail.Controls.Add(pictureBox);
        }
        private void SetCompanyName(IDictionary<BarcodeSettings, string> barcodeSettings)
        {
            if (barcodeSettings.ContainsKey(BarcodeSettings.CompanyName))
                CreateLabel().Text = barcodeSettings[BarcodeSettings.CompanyName];
        }

        private void CreateBarcodeImage(BarCode barCode)
        {
            XRPictureBox pictureBox = new XRPictureBox()
            {
                Borders = BorderSide.None,
                Sizing = ImageSizeMode.AutoSize,
                LocationF = new PointF((this.PageWidth - barCode.BarCodeImage.Width) / 2, Detail.HeightF),
            };

            pictureBox.Image = GetBarocdeImage(barCode);
            Detail.Controls.Add(pictureBox);
        }

        private Bitmap GetBarocdeImage(BarCode barCode)
        {
            BarCode barCodeTemp = barCode;
            barCodeTemp.TopCaption.Text = null;
            barCodeTemp.BottomCaption.Text = null;
            barCodeTemp.Options.Code128.ShowCodeText = false;
            return (Bitmap)barCodeTemp.BarCodeImage;
        }

        private void SetPageWidth(IDictionary<BarcodeSettings, string> barcodeSettings)
        {
            double rprtWidth = Convert.ToDouble(barcodeSettings.Where(x => x.Key == BarcodeSettings.PageWidth).Select(x => x.Value).FirstOrDefault());
            this.PageWidth = Convert.ToInt32((rprtWidth / 2.54) * 100);
        }

        private XRLabel CreateLabel()
        {
            XRLabel label = new XRLabel()
            {
                AutoWidth = true,
                Borders = BorderSide.None,
                Font = new System.Drawing.Font("Segoe UI", 8.4F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),// new Font("Segoe UI", 7.75F),
                LocationF = new PointF(0, Detail.HeightF),
                Padding = new PaddingInfo(0, 0, 0, 0),
                SizeF = new SizeF(this.PageWidth, 5F),
                TextAlignment = TextAlignment.MiddleCenter,
            };
            Detail.Controls.Add(label);
            return label;
        }

        private void InitLabels(IDictionary<BarcodeSettings, string> barcodeSettings)
        {
            foreach (var barcode in barcodeSettings)
                switch (barcode.Key)
                {
                    case BarcodeSettings.BarcodeNo:
                        // CreateLabel().Text = barcode.Value;
                        break;
                    case BarcodeSettings.ProductName:
                        CreateLabel().Text = barcode.Value;
                        break;
                    case BarcodeSettings.OtherInfo:
                        CreateLabel().Text = barcode.Value;
                        break;
                    case BarcodeSettings.Price:
                        CreateLabel().Text = barcode.Value;
                        break;
                    case BarcodeSettings.ExpireDate:
                        CreateLabel().Text = barcode.Value;
                        break;
                }
        }
    }
}
