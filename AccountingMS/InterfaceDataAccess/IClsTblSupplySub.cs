using System;
using System.Collections;
using System.Collections.Generic;

namespace AccountingMS
{
    public interface IClsTblSupplySub
    {
        IEnumerable<tblSupplySub> GetSupplySubList { get; }

        void Attach(tblSupplySub tbSupplySub);
        bool CheckPrdMsur(int prdMsurId);
        bool DeleteRecordsBySupplyMainId(int supId);
        double GetPrdMsurPurchaseLastPrice(int prdMsurId);
        int GetSupplyNumber(int supNo);
        int GetSupplyNumber(string supNo);
        double GetSupplyPrdTotalPurchasePrice(int supMainId);
        IEnumerable<tblSupplySub> GetSupplySubBListByDtStartEnd(DateTime dtStart, DateTime dtEnd);
        IEnumerable<tblSupplySub> GetSupplySubByAccNoNdDtStartEnd(long accNo, DateTime dtStart, DateTime dtEnd);
        IList GetSupplySubIListBySupId(int supMainId);
        IList GetSupplySubIListBySupId1(int supMainId);
        IEnumerable<tblSupplySub> GetSupplySubListByPrdId(int prdId);
        IEnumerable<tblSupplySub> GetSupplySubListBySupId(int supMainId);
        IEnumerable<tblSupplySub> GetSupplySubListBySupId1(int supMainId);
        double GetSupplySubProfitById(int supId);
        IEnumerable<tblSupplySub> GetSupplySubSalesNdRtrnList();
        bool IsPrdFound(int prdId);
        bool IsPrdFoundPhased(int prdId);
        bool IsPrdMsurPurchaseFound(int prdMsurId);
        bool RemoveRecordsBySupplyMainId(int supId, SupplyType supplyType);
        bool SaveDB();
    }
}