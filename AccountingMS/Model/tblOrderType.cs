using System.Collections.Generic;

namespace AccountingMS
{
    public class tblOrderType
    {
        public short ordStatus { get; set; }
        public string ordCaption { get; set; }

        public static IEnumerable<tblOrderType> GetData()
        {
            return new List<tblOrderType>()
            {
                InitObject(1),
                InitObject(2),
                InitObject(3),
            };
        }

        private static tblOrderType InitObject(short status)
        {
            return new tblOrderType() { ordStatus = status, ordCaption = ClsOrderStatus.GetStringPlural((byte)status) };
        }
    }
}
