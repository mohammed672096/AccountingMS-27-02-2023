using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblStore
    {
        public ClsTblStore()
        {
            //if (Session.tblStore.Count <= 0)
                Session.GetDataStore();
        }
        public void RefreshData()
        {
            Session.GetDataStore();
        }

        public IEnumerable<tblStore> GetStoreList => Session.tblStore;

        public short GetNewStoreNo()
        {
            return Convert.ToInt16(Session.tblStore.OrderByDescending(x => x.strNo).Select(x => x.strNo).FirstOrDefault() + 1);
        }

        public string GetStoreNameById(short strId)
        {
            return Session.tblStore?.FirstOrDefault(x => x.id == strId)?.strName;
        }

        public string GetStoreNameByNo(int strNo)
        {
            return Session.tblStore?.FirstOrDefault(x => x.strNo == strNo)?.strName;
        }
        public string GetStoreNameByProductID(int proID)
        {
            short strId = Session.ProductQunatities.FirstOrDefault(x => x.prdId == proID)?.prdStrId??0;
            return Session.tblStore?.FirstOrDefault(x => x.id == strId)?.strName;
        }
        public bool Add(tblStore tbStore)
        {
            using (var db = new accountingEntities())
            {
                db.tblStores.Add(tbStore);
                if (ClsSaveDB.Save(db, LogHelper.GetLogger()))
                {
                    Session.tblStore.Add(tbStore);
                    return true;
                }
                return false;
            }
        }

        public bool Attach(tblStore tbStore)
        {
            using (var db = new accountingEntities())
            {
                db.tblStores.Remove(db.tblStores.FirstOrDefault(x => x.id == tbStore.id));
                db.tblStores.Add(tbStore);
                if (ClsSaveDB.Save(db, LogHelper.GetLogger()))
                {
                    Session.tblStore.Remove(Session.tblStore.FirstOrDefault(x => x.id == tbStore.id));
                    Session.tblStore.Add(tbStore);
                    return true;
                }
                return false;
            }
        }
    }
}
