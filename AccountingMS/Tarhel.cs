using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accounting_1._0
{
    class Tarhel
    {
        accountingEntities2 db;
        ArrayList list = new ArrayList();
        public void EntryTarhel (ArrayList list, byte status)
        {
            db = new accountingEntities2();
            var entryMain = db.tblEntryMains.ToList();
            var entrySub = db.tblEntrySubs.ToList();
            DateTime d = DateTime.Now;
            DateTime dd = d.Date;
            int entryNo = 0;

            for (int i = 0; i < list.Count; i++)
            {
                entryNo = (int)list[i]; 

                foreach (var entryMainUpdate in entryMain)
                {
                    if (entryMainUpdate.entNo == entryNo)
                    {
                        entryMainUpdate.entStatus = status;
                        db.SaveChanges();
                        break;
                    }
                }
                Boolean flag = false;
                long tempAccNo = 0;
                string tempAccName = null;

                foreach (var entrySubUpdate in entrySub)
                {
                    if (entrySubUpdate.entNo == entryNo)
                    {
                        if (flag == true)
                        {
                            entrySubUpdate.entStatus = status;

                            tblAsset asset = new tblAsset();
                            asset.asAccNo = tempAccNo;
                            asset.asAccName = tempAccName;
                            asset.asDate = dd;
                            asset.asEntNo = entrySubUpdate.id;
                            asset.asDebit = entrySubUpdate.entCredit;
                            asset.asCredit = entrySubUpdate.entDebit;
                            asset.asStatus = status;

                            db.tblAssets.Add(asset);
                            db.SaveChanges();
                        }
                        if (flag == false)
                        {
                            tempAccNo = Convert.ToInt64(entrySubUpdate.entAccNo);
                            tempAccName = entrySubUpdate.entAccName;
                            entrySubUpdate.entStatus = status;
                            db.SaveChanges();
                            flag = true;
                        }
                    }
                }
            }
        }
    }
}
