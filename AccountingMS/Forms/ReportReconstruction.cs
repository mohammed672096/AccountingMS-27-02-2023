using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS.Forms
{
    public partial class ReportReconstruction : Form
    {
        public tblSupplier tbSupplier;
        ClsTblCurrency clsTbCurrency = new ClsTblCurrency();
        List<sumreport> reportvalue = new List<sumreport>();
        List<sumreport> reportRec = new List<sumreport>();
        public ReportReconstruction()
        {
            InitializeComponent();
            gridView2.CustomColumnDisplayText += GridView2_CustomColumnDisplayText;
            gridView2.CustomUnboundColumnData += GridView2_CustomUnboundColumnData;
            getdata();

        }

        private void GridView2_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;

            if (e.Column.FieldName == ColRest.FieldName)
            {
    
            }
            //    if (e.IsGetData) e.Value = e.ListSourceRowIndex + 1;
            //  var row = e.Row as View_ReportReconstruction;
            //e.Value = GetQuanAvlb(row != null ? row.supPrdId.GetValueOrDefault() : 0);
        }

        public class sumreport
        {
            public int CuM { get; set; }
            public string CuName { get; set; }
            public int custNo { get; set; }
            public double balance1 { get; set; }
            public double balance2 { get; set; }
            public double balance3 { get; set; }
            public double balance4 { get; set; }
            public double balance { get; set; }
        }


        private void ReportReconstruction_Load(object sender, EventArgs e)
        {
            fromdateEdit.DateTime = DateTime.Now;
            enddateEdit.DateTime = DateTime.Now;
            daydateEdit.DateTime = DateTime.Now;
            userNametextEdit.Text = Session.CurrentUser.userName;
        }

        void getdata()
        {
                tblCurrencyBindingSource.DataSource = Session.Currencies.ToList();
        }
        void filldatgrid()
        {
            if (currencytextEdit.EditValue == null)
            {
                currencytextEdit.ErrorText = (MySetting.GetPrivateSetting.LangEng ? "Sorry, choose the currency first!" : "عذراً اختر العملة أولاً!");
                return;
            }
            reportvalue.Clear();
            currencytextEdit.ErrorText = null;
            using (accountingEntities db = new accountingEntities())
            {
                DateTime datestar = Convert.ToDateTime(fromdateEdit.EditValue);
                DateTime dateend = Convert.ToDateTime(enddateEdit.EditValue);
                gridControl2.DataSource = (from s in db.tblSupplyMains.AsNoTracking().Where(a => a.supDate >= datestar
                                           && a.supDate <= dateend && (a.supStatus ==4 || a.supStatus == 8)).ToList()
                                           select new
                                           {
                                               s.supNo,
                                               supRefNo = Session.Customers.FirstOrDefault(x => x.id == s.supCustSplId)?.custNo,
                                               s.supDate,
                                               s.paidCash,
                                               s.supBankAmount,
                                               supAccName=Session.Customers.FirstOrDefault(x=>x.id==s.supCustSplId)?.custName,
                                               s.net,
                                               s.remin,
                                               CountDaysMaturity = GetDebtAges(s, false),
                                               DebtAges = GetDebtAges(s,true)
                                           }).ToList();

            }
          
        }
        string GetDebtAges(tblSupplyMain s,bool IsDebtAges=true)
        {
            TimeSpan Difference = enddateEdit.DateTime.Subtract(s.supDate.GetValueOrDefault());
            if (IsDebtAges)
            {
                int countD = Convert.ToInt32(Difference.Days);
                if (countD > 0 && countD < 31)
                    return "صفر الي 30 يوم";
                else if (countD > 31 && countD < 61)
                    return "31 الي 60 يوم";
                else if (countD > 61 && countD < 181)
                    return "61 الي 180 يوم";
                else if (countD > 180)
                    return "181 الي عام";
                else return "";
            }
            else
                return (Difference.Days).ToString();
        }
    
        private void GridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            //if (e.Column.FieldName == "Rest")

            //    e.DisplayText = Convert.ToString(Math.Round(
            //        Convert.ToDouble(gridView2.GetListSourceRowCellValue(e.ListSourceRowIndex, colnet)) -
            //        (Convert.ToDouble(gridView2.GetListSourceRowCellValue(e.ListSourceRowIndex, colpaidCash)) +
            //        Convert.ToDouble(gridView2.GetListSourceRowCellValue(e.ListSourceRowIndex, colsupBankAmount)))
            //       , 2));
            //else if (e.Column.FieldName == "CountDaysMaturity")
            //{
            //    if (gridView2.GetListSourceRowCellValue(e.ListSourceRowIndex, colsupDate) == null) return;
            //    DateTime myDateTime1 = new DateTime();
            //    DateTime myDateTime2 = new DateTime();
            //    myDateTime1 = Convert.ToDateTime(enddateEdit.Text);
            //    myDateTime2 = Convert.ToDateTime(gridView2.GetListSourceRowCellValue(e.ListSourceRowIndex, colsupDate).ToString());
            //    Difference = myDateTime1.Subtract(myDateTime2);
            //    e.DisplayText = (Difference.Days).ToString();
            //}
            //else if (e.Column.FieldName == "DebtAges")
            //{
            //    int countD = Convert.ToInt32(Difference.Days);
            //    if (countD > 0 && countD < 31)
            //        e.DisplayText = "صفر الي 30 يوم";
            //    else if (countD > 31 && countD < 61)
            //        e.DisplayText = "31 الي 60 يوم";
            //    else if (countD > 61 && countD < 181)
            //        e.DisplayText = "61 الي 180 يوم";
            //    else if (countD > 180)
            //        e.DisplayText = "181 الي عام";
            //}
        }

        public class DaysInfo
        {
            public string NameOfDay { get; set; }
            public DateTime DateOfDay { get; set; }
            public string time_attendance { get; set; }
            public string time_leave { get; set; }
        }
        public class view_rep_ReportReconstruction : View_ReportReconstruction
        {
            public double Rest { get; set; }
            public int CountDaysMaturity { get; set; }
            public string DebtAges { get; set; }
        }

        public List<DaysInfo> GetDays(int month, int year, int dy)
        {
            List<DaysInfo> daysInfoList = new List<DaysInfo>();
            DateTime currentDate;

            int totalm = 0;
            for (int day = dy; day <= totalm; day++)
            {
                currentDate = new DateTime(year, month, day);
                daysInfoList.Add(new DaysInfo() { NameOfDay = currentDate.DayOfWeek.ToString(), DateOfDay = currentDate, time_attendance = "غياب", time_leave = "غياب" });
            }
            return daysInfoList;
        }



        private void PrintButton1_Click(object sender, EventArgs e)
        {
            filldatgrid();

            gridControl2.ShowPrintPreview();
            return;
            using (ReportForm frmr = new ReportForm(null))
            {


                Reports.XtraReportReconstruction rep = new Reports.XtraReportReconstruction();
                rep.xrTitelName.Text = "تقرير اعمار الذمم    "

                    + " من تاريخ "
                   + fromdateEdit.Text
                   + " الى تاريخ "
                   + enddateEdit.Text;


                rep.DataSource = gridView2.DataSource;
                rep.RequestParameters = false;
                frmr.documentViewer1.DocumentSource = rep;


                frmr.ShowDialog();
            }
        }
      
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            filldatgrid();
        }

        private void currencytextEdit_EditValueChanged(object sender, EventArgs e)
        {
            filldatgrid();
        }

        private void layoutControl1_Click(object sender, EventArgs e)
        {

        }

        private void daydateEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void userNametextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void tblCurrencyBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void tblSupplierBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
         
        }
    }
}
