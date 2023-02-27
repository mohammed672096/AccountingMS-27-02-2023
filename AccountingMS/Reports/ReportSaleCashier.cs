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
    public partial class ReportSaleCashier : DevExpress.XtraReports.UI.XtraReport
    {
        ClsTblUser clsTbUser;
        ClsTblBranch clsTbBranch;
        ClsTblBranchImg clsTbBranchImg;
        ClsTblBox clsTbBox;
        ClsTblSupplyMain clsTbSupplyMain;
        IEnumerable<object> result;

        private long accNo;
        private short userId;
        private DateTime dtStart, dtEnd;
        private int totalInv, totalInvRtrn;
        private double total, totalTax, totalDscnt, totalBank, totalFinal;
        private double TotalCash, TotalBank, TotalCashRtrn, TotalBankRtrn;

        public ReportSaleCashier()
        {
            InitializeComponent();
            this.ApplyLocalization(System.Threading.Thread.CurrentThread.CurrentCulture);
            if (MySetting.GetPrivateSetting.LangEng)
            {
                parameterBox.Description = "Box";
                parameterDtStart.Description = "Date From";
                parameterDtEnd.Description = "Date To";
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = RightToLeftLayout.No;
            }
            this.ParametersRequestBeforeShow += ReportSaleCashier_ParametersRequestBeforeShow; ;
            this.ParametersRequestSubmit += ReportSaleCashier_ParametersRequestSubmit;
        }

        private void ReportSaleCashier_ParametersRequestBeforeShow(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            foreach (ParameterInfo info in e.ParametersInformation)
            {
                if (info.Parameter.Name == parameterDtStart.Name || info.Parameter.Name == parameterDtEnd.Name)
                    info.Editor = InitDateEdit();
            }
        }
        private DateEdit InitDateEdit()
        {
            DateEdit dateEdit = new DateEdit();
            dateEdit.Properties.Mask.EditMask = "yyyy/MM/dd HH:mm";
            dateEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            dateEdit.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            dateEdit.Properties.CalendarTimeProperties.EditMask = "HH:mm";
            return dateEdit;
        }

        public static async Task<ReportSaleCashier> CreateAsync()
        {
            var rprt = new ReportSaleCashier();
            await rprt.InitObjectsAsync();

            rprt.InitBranchData();
            rprt.InitDefaultData();

            return rprt;
        }

        private async Task InitObjectsAsync()
        {
            IList<Task> taskList = new List<Task>();

            taskList.Add(Task.Run(() => this.clsTbUser = new ClsTblUser()));
            taskList.Add(Task.Run(() => this.clsTbBranch = new ClsTblBranch()));
            taskList.Add(Task.Run(() => this.clsTbBranchImg = new ClsTblBranchImg()));
            taskList.Add(Task.Run(() => this.clsTbBox = new ClsTblBox()));
            taskList.Add(Task.Run(() => this.clsTbSupplyMain = new ClsTblSupplyMain()));

            await Task.WhenAll(taskList);
        }

        private void InitBranchData()
        {
            tblBranch tbBranch = this.clsTbBranch.GetBranchDataById(Session.CurBranch.brnId);

            xrLabelBranchName.Text = (!MySetting.GetPrivateSetting.LangEng) ? tbBranch.brnName : tbBranch.brnNameEn;
            xrLabelBranchAddress.Text += (!MySetting.GetPrivateSetting.LangEng) ? tbBranch.brnAddress : tbBranch.brnAddressEn;
            xrLabelBranchPhnNo1.Text += tbBranch.brnPhnNo;
            xrLabelBranchTaxNo.Text += tbBranch.brnTaxNo;
            LoadImage();
        }

        private void LoadImage()
        {
             xrPictureBoxBranch.Image = new ClsTblBranchImg().GetBitmapLogImage();
        }

        private void InitDefaultData()
        {
            tblUserBindingSource.DataSource = this.clsTbUser.GetUserList;
            tblBoxBindingSource.DataSource = this.clsTbBox.GetBoxList;
            parameterDtStart.Value = DateTime.Now.Date;
            parameterDtEnd.Value = Session.CurrentYear.fyDateEnd;
        }

        private void ReportSaleCashier_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            this.userId = Convert.ToInt16(parameterUser.Value);
            this.accNo = Convert.ToInt64(parameterBox.Value);
            this.dtStart = Convert.ToDateTime(parameterDtStart.Value);
            this.dtEnd = Convert.ToDateTime(parameterDtEnd.Value);

            InitText();
            ResetTotal();
            CalculateTotalSale();
            CalculateTotalSaleRtrn();
            SetTotalLabels();
        }

        private void InitText()
        {
            xrlDate.Text = $"التاريخ: {DateTime.Now}";
            xrtcHeader.Text = $"مبيعات: {this.clsTbBox.GetBoxNameByAccNo(this.accNo)}";
            if (this.userId > 0) xrtcHeader.Text += $"\nالمستخدم: {this.clsTbUser.GetUserNameById(this.userId)}";
        }

        private void CalculateTotalSale()
        {
            var result = this.clsTbSupplyMain.GetSupplyMainListSaleByDtStartEnd(this.dtStart, this.dtEnd)
                .Where(x => x.supAccNo == this.accNo && (x.supStatus == 4 || x.supStatus == 8)).ToList();

            if (this.userId > 0) result = result.Where(x => x.supUserId == this.userId).ToList();

            var resultTotalt = result.GroupBy(x => x.supAccNo, (key, grp) => new
            {
                totalInv = grp.Count(),
                total = grp.Sum(x => x.supTotal),
                totalTax = grp.Sum(x => x.supTaxPrice),
                totalDscnt = grp.Sum(x => x.supDscntAmount),
                totalBank = grp.Sum(x => x.supBankAmount)

            });

            this.TotalCash = resultTotalt.Select(x => x.total).FirstOrDefault();
            this.TotalCash += resultTotalt.Select(x => x.totalTax ?? 0).FirstOrDefault();
            this.TotalBank = resultTotalt.Select(x => Convert.ToDouble(x.totalBank)).FirstOrDefault();

            this.totalInv = resultTotalt.Select(x => x.totalInv).FirstOrDefault();
            this.total = resultTotalt.Select(x => x.total).FirstOrDefault();
            this.totalTax = resultTotalt.Select(x => Convert.ToDouble(x.totalTax)).FirstOrDefault();
            this.totalDscnt = resultTotalt.Select(x => Convert.ToDouble(x.totalDscnt)).FirstOrDefault();
            this.totalBank = resultTotalt.Select(x => Convert.ToDouble(x.totalBank)).FirstOrDefault();
            this.totalFinal = this.total + this.totalTax - this.totalDscnt;
        }

        private void CalculateTotalSaleRtrn()
        {
            var result = this.clsTbSupplyMain.GetSupplyMainListSaleByDtStartEnd(this.dtStart, this.dtEnd)
                .Where(x => x.supAccNo == this.accNo && (x.supStatus == 11 || x.supStatus == 12)).ToList();

            if (this.userId > 0) result = result.Where(x => x.supUserId == this.userId).ToList();

            var resultTotal = result.GroupBy(x => x.supAccNo, (key, grp) => new
            {
                totalInv = grp.Count(),
                total = grp.Sum(x => x.supTotal),
                totalTax = grp.Sum(x => x.supTaxPrice),
                totalDscnt = grp.Sum(x => x.supDscntAmount),
                totalBank = grp.Sum(x => x.supBankAmount)
            });

            this.TotalCashRtrn = resultTotal.Select(x => x.total).FirstOrDefault();
            this.TotalCashRtrn += resultTotal.Select(x => x.totalTax ?? 0).FirstOrDefault();
            this.TotalBankRtrn = resultTotal.Select(x => Convert.ToDouble(x.totalBank)).FirstOrDefault();

            this.totalInvRtrn = resultTotal.Select(x => x.totalInv).FirstOrDefault();
            this.total -= resultTotal.Select(x => x.total).FirstOrDefault();
            this.totalTax -= resultTotal.Select(x => Convert.ToDouble(x.totalTax)).FirstOrDefault();
            this.totalDscnt -= resultTotal.Select(x => Convert.ToDouble(x.totalDscnt)).FirstOrDefault();
            this.totalBank -= resultTotal.Select(x => Convert.ToDouble(x.totalBank)).FirstOrDefault();
            this.totalFinal = this.total + this.totalTax - this.totalDscnt;
        }

        private void SetTotalLabels()
        {

            xrtcTotalCash.Text = $"{((this.TotalCash - this.totalDscnt) - this.TotalBank):n2}";
            xrtcTotalBank.Text = $"{this.TotalBank:n2}";
            xrTableCell5.Text = $"{(this.TotalCashRtrn - this.TotalBankRtrn):n2}";
            xrTableCell9.Text = $"{(this.TotalBankRtrn):n2}";


            xrtcTotalInv.Text = $"{this.totalInv:n0}";
            xrtcTotalInvRtrn.Text = $"{this.totalInvRtrn:n0}";
            xrtcTotal.Text = $"{this.total:n2}";
            xrtcTotalDiscount.Text = $"{this.totalDscnt:n2}";
            xrtcTotalTax.Text = $"{this.totalTax:n2}";

            this.totalFinal = this.total + this.totalTax - this.totalDscnt;

            xrtcTotalFinal.Text = $"{this.totalFinal:n2}";
        }

        private void ResetTotal()
        {
            this.TotalCash = this.TotalBank = this.TotalCashRtrn = this.TotalBankRtrn = 0;

            this.totalInv = 0;
            this.totalInvRtrn = 0;
            this.total = 0;
            this.totalTax = 0;
            this.totalDscnt = 0;
            this.totalBank = 0;
            this.totalFinal = 0;
        }
    }
}
