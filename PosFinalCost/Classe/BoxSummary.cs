using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosFinalCost.Classe
{
   public class BoxSummary
    {
        [DisplayName("العدد")]
        public int Count { get; set; }
        [DisplayName("المدفوع نقدا")]
        public double paidCash { get; set; }
        [DisplayName("المدفوع شبكة")]
        public double BankAmount { get; set; }
        [DisplayName("نوع العملية")]
        public string Type { get; set; }
        public List<SummaryDetail> SummaryDetails { get; set; }
    }
    public class SummaryDetail
    {
        [DisplayName("رقم العملية")]
        public int No { get; set; }
        [DisplayName("نوع العملية")]
        public string OperType { get; set; }
        [DisplayName("الاجمالي")]
        public double Net { get; set; }
        [DisplayName("تاريخ العملية")]
        public string Date { get; set; }
    }
}
