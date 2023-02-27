using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblGroupStr
    {
        public ClsTblGroupStr()
        {
            //if (Session.tblGroupStr.Count <= 0)
                Session.GetDataGroupStr();
        }

        public void RefreshData()
        {
            Session.GetDataGroupStr();
        }

        public IEnumerable<tblGroupStr> GetGroupList => Session.tblGroupStr;

        public tblGroupStr GetGroupObjById(int grpId)
        {
            return Session.tblGroupStr.FirstOrDefault(x => x.id == grpId);
        }

        public int GetGroupNewNo()
        {
            return Session.tblGroupStr.OrderByDescending(x => x.grpNo).Select(x => x.grpNo).FirstOrDefault() + 1;
        }

        public int GetGroupNoById(int grpId)
        {
            return (Session.tblGroupStr.FirstOrDefault(x => x.id == grpId)?.grpNo) ?? 0;
        }

        public long GetGroupAccNoById(Int64 grpId)
        {
            return (Session.tblGroupStr?.FirstOrDefault(x => x.id == grpId || x.grpAccNo == grpId)?.grpAccNo) ?? 0;
        }

        public string GetGroupNameById(int grpId)
        {
            return (Session.tblGroupStr?.FirstOrDefault(x => x.id == grpId)?.grpName);
        }

        public string GetGroupNameByAccNo(long grpAccNo)
        {
            return (Session.tblGroupStr?.FirstOrDefault(x => x.grpAccNo == grpAccNo)?.grpName);
        }

        public byte GetGroupCurrencyById(int grpId)
        {
            return (Session.tblGroupStr?.FirstOrDefault(x => x.id == grpId)?.grpCurrency) ?? 0;
        }

        public long GetGroupCostAccNoById(int grpId)
        {
            return (Session.tblGroupStr?.FirstOrDefault(x => x.id == grpId)?.grpCostAccNo) ?? 0;
        }

        public long GetGroupCostRtrnAccNoById(int grpId)
        {
            return (Session.tblGroupStr?.FirstOrDefault(x => x.id == grpId)?.grpCostRtrnAccNo) ?? 0;
        }

        public long GetGroupSaleAccNoById(int grpId)
        {
            return (Session.tblGroupStr?.FirstOrDefault(x => x.id == grpId)?.grpSalesAccNo) ?? 0;
        }

        public long GetGroupSaleRtrnAccNoById(int grpId)
        {
            return (Session.tblGroupStr?.FirstOrDefault(x => x.id == grpId)?.grpSalesRtrnAccNo) ?? 0;
        }

        public long GetGroupPurchaseAccNoById(int grpId)
        {
            return (Session.tblGroupStr?.FirstOrDefault(x => x.id == grpId)?.grpPurchaseAccNo) ?? 0;
        }

        public long GetGroupPurchaseRtrnAccNoById(int grpId)
        {
            return (Session.tblGroupStr?.FirstOrDefault(x => x.id == grpId)?.grpPurchaseRtrnAccNo) ?? 0;
        }

        public void GroupNoLookkUpEdit(DevExpress.XtraEditors.LookUpEdit grpNoLookUp)
        {
            grpNoLookUp.Properties.DataSource = Session.tblGroupStr;
            grpNoLookUp.Properties.DisplayMember = "grpName";
            grpNoLookUp.Properties.ValueMember = "id";
            grpNoLookUp.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("grpNo", "رقم المجموعة", 11, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("grpName", "إسم المجموعة", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
        }
    }
}
