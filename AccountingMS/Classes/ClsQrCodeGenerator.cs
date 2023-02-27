using DevExpress.XtraPrinting.BarCode;
using DevExpress.XtraReports.UI;

namespace AccountingMS
{
    public static class ClsQrCodeGenerator
    {
        public static void InitQRCode(this XRBarCode barCode, string text)
        {
            barCode.Symbology = new QRCodeGenerator();

            barCode.Text = text;
            barCode.ShowText = false;
            //barCode.HeightF = 60;
            //barCode.WidthF = 100;

            barCode.AutoModule = true;

            ((QRCodeGenerator)barCode.Symbology).CompactionMode = QRCodeCompactionMode.Byte;
            ((QRCodeGenerator)barCode.Symbology).ErrorCorrectionLevel = QRCodeErrorCorrectionLevel.H;
            ((QRCodeGenerator)barCode.Symbology).Version = QRCodeVersion.AutoVersion;
        }
    }
}
