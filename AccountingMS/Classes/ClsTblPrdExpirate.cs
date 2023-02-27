using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblPrdExpirate
    {
        accountingEntities db;
        IEnumerable<tblPrdExpirate> tbPrdExpirateList;

        public ClsTblPrdExpirate()
        {
            InitData();
        }

        private void InitData()
        {
            db = new accountingEntities();
            this.tbPrdExpirateList = db.tblPrdExpirates.Where(x => x.expBrnId == Session.CurBranch.brnId && x.expDate >= Session.CurrentYear.fyDateStart &&
                x.expDate <= Session.CurrentYear.fyDateEnd).OrderBy(x => x.expSupMainId).ToList();
        }

        public IEnumerable<tblPrdExpirate> GetPrdExpirateList => this.tbPrdExpirateList;

        public tblPrdExpirate GetPrdExpirateObjById(int expId)
        {
            return this.tbPrdExpirateList.FirstOrDefault(x => x.expId == expId);
        }

        public void Add(tblPrdExpirate tbPrdExpirate)
        {
            db.tblPrdExpirates.Add(tbPrdExpirate);
        }

        public void Attach(tblPrdExpirate tbPrdExpirate)
        {
            db.tblPrdExpirates.Attach(tbPrdExpirate);
        }

        public bool Remove(tblPrdExpirate tbPrdExpirate)
        {
            db.tblPrdExpirates.Remove(tbPrdExpirate);
            return SaveDB;
        }

        public bool SaveDB => ClsSaveDB.Save(db, LogHelper.GetLogger());
    }
}
