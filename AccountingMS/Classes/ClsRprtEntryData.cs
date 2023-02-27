using System;

namespace AccountingMS
{
    class ClsRprtEntryData
    {
        public int entNo { get; set; }
        public string boxName { get; set; }
        public string entDesc { get; set; }
        public double entAmount { get; set; }
        public int entRefNo { get; set; }
        public string entType { get; set; }
        public DateTime entDate { get; set; }
        public string entReverseConstraint { get; set; }
        public DateTime? entReverseConstraintDate { get; set; }
    }
}
