using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingMS.Classes
{
    class ReView_ReportReconstruction
    {
        public string custAccName { get; set; }
        public int supNo { get; set; }
        public Nullable<int> supCustSplId { get; set; }
        public Nullable<System.DateTime> supDate { get; set; }
        public double net { get; set; }
        public int custNo { get; set; }
        public Nullable<double> paidCash { get; set; }
        public Nullable<double> supBankAmount { get; set; }
        public byte supStatus { get; set; }
        public double Rest { get; set; }
        public int CountDaysMaturity { get; set; }
        public string DebtAges { get; set; }

    }
}
