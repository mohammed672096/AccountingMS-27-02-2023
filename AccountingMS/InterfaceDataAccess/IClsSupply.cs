namespace AccountingMS
{
    interface IClsSupply
    {
        bool IsSupFoundBox(int supNo, long boxNo, byte status1, byte status2);
        bool IsSupFoundCredit(int supNo, byte status1, byte status2);
        int StoreEntryNoBox(byte status1, byte status2);
        //int StoreEntryNoCredit(byte status1, byte status2);
    }
}