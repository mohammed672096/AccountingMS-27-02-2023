using DevExpress.XtraEditors;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace AccountingMS
{
    public partial class ReportSaleCashier1 : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportSaleCashier1(DateTime fromDate, DateTime toDate,byte stat)
        {
            InitializeComponent();
            this.ApplyLocalization(System.Threading.Thread.CurrentThread.CurrentCulture);
            SetRTL();
            //xrTableCellCurrency.Text = clsCurrency.CurrName(this.currencyId);
            InitDefaultData(fromDate, toDate);
            if (stat == 1)
            {
                xrTableCell1.Text = MySetting.GetPrivateSetting.LangEng ? xrTableCell1.Text.Replace("Sale", "Purchase") : xrTableCell1.Text.Replace("مبيعات", "مشتريات");
                xrTableCell2.Text = MySetting.GetPrivateSetting.LangEng ? xrTableCell2.Text.Replace("Sale", "Purchase") : xrTableCell2.Text.Replace("مبيعات", "مشتريات");
                xrTableCell7.Text = MySetting.GetPrivateSetting.LangEng ? xrTableCell7.Text.Replace("Sale", "Purchase") : xrTableCell7.Text.Replace("مبيعات", "مشتريات");
            }
        }
       
        private void InitDefaultData(DateTime fromDate, DateTime toDate)
        {
            xrlRprtDate.Text = string.Format((!MySetting.GetPrivateSetting.LangEng) ? $"من تاريخ :{fromDate:yyyy/MM/dd hh:mm tt} \nالى تاريخ :{toDate:yyyy/MM/dd hh:mm tt}" : $"From Date :{fromDate:yyyy/MM/dd hh:mm tt}\n To Date :{toDate:hh:mm tt dd/MM/yyyy}");
            xrPictureBoxBranch.Image = new ClsTblBranchImg().GetBitmapLogImage();
            xrLabelBranchName.Text = Session.CurBranch.brnName;
            xrLabelBranchTaxNo.Text += Session.CurBranch.brnTaxNo;
            xrLabelBranchAddress.Text += Session.CurBranch.brnAddress;
            xrLabelBranchPhnNo1.Text += Session.CurBranch.brnPhnNo;
            xrlDate.Text = $"التاريخ: {DateTime.Now}";
        }
        private void SetRTL()
        {
            if (MySetting.GetPrivateSetting.LangEng)
            {
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = RightToLeftLayout.No;
            }
        }
    }
}
