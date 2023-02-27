using DevExpress.XtraReports.UI;
using System.IO;
using System.Linq;

namespace AccountingMS.Reports
{
    public partial class rtp_Barcode : DevExpress.XtraReports.UI.XtraReport
    {
        public rtp_Barcode()
        {
            InitializeComponent();
        }

        public static void Print(object ds, int templateID, bool _FastPrint)
        {
            rtp_Barcode report = new rtp_Barcode();
            accountingEntities db = new accountingEntities();

            var row = db.BarcodeTemplates.Single(x => x.ID == templateID);
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(row.Template.ToArray(), 0, row.Template.ToArray().Length);
                report.LoadLayout(stream);
            }

            report.DataSource = ds;
            report.DataMember = "";

            //     report.DetailReport_Expence .DataSource = report.DataSource;
            //  report.DetailReport_Expence.DataMember = "HeadOtherCharges";

            //report.lbl_companyName.Text = CurrentSession.Company.CombanyName;
            //report.lbl_Price.TextFormatString = "{0:£0.00}";

            //switch (CurrentSession.user.WhenPrintShowMode)
            //{
            //    case 0: report.ShowPreview(); break;
            //    case 1: report.PrintDialog(); break;
            //    case 2: report.Print(); break;
            //    default: report.PrintDialog(); break;
            //}
            //    report.lbl_Price.TextFormatString = "{0:0.00}" + MySetting.DefaultSetting.CurrancyChar + "";
            if (_FastPrint)

            {
                report.CreateDocument();
                report.Print();
            }
            else
                report.ShowPreview();

        }
    }
}
