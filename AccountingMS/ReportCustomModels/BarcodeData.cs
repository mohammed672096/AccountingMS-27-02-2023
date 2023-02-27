using System;
using System.Drawing;

namespace AccountingMS.ReportCustomModels
{
    public class BarcodeData
    {
        // comboBoxEditSymbology.Properties.Items.AddRange(typeof(Symbology).GetEnumValues());
        public int ID { get; set; }
        public string Code { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double TaxPrice { get => Price + (Price * MySetting.GetPrivateSetting.taxDefault / 100); }
        public string Barcode { get; set; }
        public Image BarcodeImage
        {
            get
            {
                return drawImg(code: Barcode);
            }
        }
        public string CompanyName { get; set; }
        public string Notes { get; set; }
        public int BarcodeCount { get; set; }
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public DateTime DateProduction { get; set; }
        public DateTime DateExpirate { get; set; }



        private Image drawImg(int width = 100, int Height = 40, string code = "")
        {

            int W = width;
            int H = Height;
            if (code == null)
                code = "0000000";

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
        BarcodeLib.Barcode b = new BarcodeLib.Barcode()
        {
            EncodedType = BarcodeLib.TYPE.CODE128,
            IncludeLabel = true,
            LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER,
            Alignment = BarcodeLib.AlignmentPositions.CENTER
        };
    }
}
