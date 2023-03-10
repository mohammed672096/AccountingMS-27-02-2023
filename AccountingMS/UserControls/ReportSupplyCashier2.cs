using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;

namespace AccountingMS
{
    public partial class ReportSupplyCashier2 : XtraReport
    {
        private string currencySign;

        public ReportSupplyCashier2(tblSupplyMain tbSupplyMain, IEnumerable<tblSupplySub> tbSupplySubList)
        {
            //  SetLanguage();
            InitializeComponent();
            //    this.DefaultPrinterSettingsUsing.UseMargins = false;
            //    SetRTL();
            //  InitBranchData();
            InitBinding(tbSupplyMain.supStatus);
            InitText(tbSupplyMain.supStatus, Convert.ToByte(tbSupplyMain.supIsCash));
            InitData(tbSupplyMain, tbSupplySubList);
        }

        private void InitText(byte supStatus, byte supIsCash)
        {
            if (supStatus == 3 || supStatus == 7)
                xrtcHeader.Text = (!MySetting.GetPrivateSetting.LangEng) ? "فاتورة مشتريات" : "Purchase Invoice";
            else if (supStatus == 4 || supStatus == 8)
                xrtcHeader.Text = (!MySetting.GetPrivateSetting.LangEng) ? "فاتورة مبيعات" : "Sales Invoice";
            else if (supStatus == 9 || supStatus == 10)
                xrtcHeader.Text = (!MySetting.GetPrivateSetting.LangEng) ? "فاتورة مردود مشتريات" : "Purchase Return Invoice";
            else if (supStatus == 11 || supStatus == 12)
                xrtcHeader.Text = (!MySetting.GetPrivateSetting.LangEng) ? "فاتورة مردود مبيعات" : "Sale Return Invoice";

            xrtcHeader.Text += (!MySetting.GetPrivateSetting.LangEng) ? ((supIsCash == 1) ? " نقدا" : " اجل") : ((supIsCash == 1) ? " Cash" : " Credit");
        }

        private void InitBinding(byte supStatus)
        {
            if (supStatus == 4 || supStatus == 8 || supStatus == 9 || supStatus == 10)
            {
                xrtcTotalRow.ExpressionBindings.Clear();
                xrtcTotalRow.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[supCredit]"));
            }
            if (supStatus == 4 || supStatus == 8 || supStatus == 11 || supStatus == 12)
            {
                xrtcPrice.ExpressionBindings.Clear();
                xrtcPrice.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[supSalePrice]"));

                //xrtcTotal.ExpressionBindings.Clear();
                //xrtcTotal.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "sumSum([supSalePrice] * [supQuanMain])"));
                //xrtcTotal.Summary = new XRSummary() { Running = SummaryRunning.Group };
            }
        }

        private void InitData(tblSupplyMain tbSupplyMain, IEnumerable<tblSupplySub> tbSupplySubList)
        {
            tblSupplyMainBindingSource.DataSource = tbSupplyMain;
            tblSupplySubBindingSource.DataSource = tbSupplySubList;

            this.currencySign = new ClsTblCurrency().GetCurrencySignById(Convert.ToByte(tbSupplyMain.supCurrency));

            //double total = (tbSupplyMain.supTotal + Convert.ToDouble(tbSupplyMain.supTaxPrice));// - Convert.ToDouble(tbSupplyMain.supDscntAmount);
            double total = (tbSupplyMain.supTotal + Convert.ToDouble(tbSupplyMain.supTaxPrice)) - Convert.ToDouble(tbSupplyMain.supDscntAmount);
            xrtcAmount.Text = $"{total:n2}{this.currencySign}";

            xrtcTotal.Text = $"{tbSupplyMain.supTotal:n2}";
            xrtcTotalTax.Text = $"{tbSupplyMain.supTaxPrice:n2}";
            xrtcTotalDiscount.Text = $"{Convert.ToDouble(tbSupplyMain.supDscntAmount):n2}";
            xrtcTotalFinal.Text = $"{total:n2}";
        }

        private void xrTableCell16_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            cell.Text = new ClsTblUser().GetUserNameById(Convert.ToInt16(cell.Value));
        }

        private void InitBranchData()
        {
            tblBranch tbBranch = new ClsTblBranch().GetBranchDataById(Session.CurBranch.brnId);

            bbbbbbbbb.Text = (!MySetting.GetPrivateSetting.LangEng) ? tbBranch.brnName : tbBranch.brnNameEn;
            //    aaaaaaaaaaaaaa.Text += (!MySetting.GetPrivateSetting.LangEng) ? tbBranch.brnAddress : tbBranch.brnAddressEn;
            //     xrLabelBranchTaxNo.Text += tbBranch.brnTaxNo;
            LoadImage();
        }

        private void LoadImage()
        {
            xrPicture1564454.Image = new ClsTblBranchImg().GetBitmapLogImage();
        }

        private void SetLanguage()
        {
            if (!MySetting.GetPrivateSetting.LangEng)
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
            else
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
        }

        private void SetRTL()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = RightToLeftLayout.No;
        }
    }
}
