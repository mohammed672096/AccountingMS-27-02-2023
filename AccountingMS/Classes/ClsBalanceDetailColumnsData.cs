namespace AccountingMS
{
    class ClsBalanceDetailColumnsData
    {
        public static ClsBalanceDetailColumnsData CreateDetailBalance(long accNo, string accName, string phnNo, string address, string taxNo, double debit, double credit, string currentBalance)
        {
            return new ClsBalanceDetailColumnsData()
            {
                accNo = accNo,
                accName = accName,
                phnNo = phnNo,
                address = address,
                taxNo = taxNo,
                debit = debit,
                credit = credit,
                currentBalance = currentBalance,
            };
        }

        public long accNo { get; set; }
        public string accName { get; set; }
        public string phnNo { get; set; }
        public string address { get; set; }
        public string taxNo { get; set; }
        public double debit { get; set; }
        public double credit { get; set; }
        public string currentBalance { get; set; }
    }
}
