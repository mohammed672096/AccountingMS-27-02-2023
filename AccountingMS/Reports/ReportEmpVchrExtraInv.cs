using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    public partial class ReportEmpVchrExtraInv : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportEmpVchrExtraInv(tblEntryMain tbEntMain, IEnumerable<tblEntrySub> tbEntSubList)
        {
            InitializeComponent();
            InitDefaultData(tbEntMain.entStatus);
            InitEntMainData(tbEntMain, tbEntSubList.Select(x => x.entAccName).FirstOrDefault());
            InitEntSubData(tbEntSubList);
        }

        private void InitDefaultData(byte entStatus)
        {
            xrlHeader.Text += ClsEntryStatus.GetString(entStatus);
            new ClsReportHeaderData(this);
        }

        private void InitEntMainData(tblEntryMain tbEntMain, string toAccount)
        {
            xrlEntNo.Text += tbEntMain.entNo;
            xrlBoxName.Text += new ClsTblBox().GetBoxNameByNo(Convert.ToInt32(tbEntMain.entBoxNo));
            xrlToAccount.Text += toAccount;
            xrlEntAmount.Text += $"{tbEntMain.entAmount:n2} {new ClsTblCurrency().GetCurrencySignById(Convert.ToByte(tbEntMain.entCurrency))}";
            xrlEntDate.Text += $"{tbEntMain.entDate: yyyy/MM/dd hh:mm tt}";
        }

        private void InitEntSubData(IEnumerable<tblEntrySub> tbEntSubList)
        {
            tblEntrySubBindingSource.DataSource = tbEntSubList;
        }
    }
}
