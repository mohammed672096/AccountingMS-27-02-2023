using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingMS
{
    public class ClsTblPrdExpirateQuan
    {
        accountingEntities db;
        IEnumerable<tblPrdExpirateQuan> tbPrdExpirateQuanList;

        public ClsTblPrdExpirateQuan(bool initData = true)
        {
            db = new accountingEntities();
            if (initData) InitData();
        }

        public static Task<ClsTblPrdExpirateQuan> CreateAsync()
        {
            var clsTbPrdExpirateQuan = new ClsTblPrdExpirateQuan();
            return clsTbPrdExpirateQuan.InitDataAsync();

        }

        private async Task<ClsTblPrdExpirateQuan> InitDataAsync()
        {
            await QueryListAsync();
            return this;
        }

        private void InitData()
        {
            this.tbPrdExpirateQuanList = db.tblPrdExpirateQuans.Where(x => x.expBrnId == Session.CurBranch.brnId &&
                x.expDate >= Session.CurrentYear.fyDateStart && x.expDate <= Session.CurrentYear.fyDateEnd).ToList();
        }

        private async Task QueryListAsync()
        {
            this.tbPrdExpirateQuanList = await db.tblPrdExpirateQuans.Where(x => x.expBrnId == Session.CurBranch.brnId &&
                x.expDate >= Session.CurrentYear.fyDateStart && x.expDate <= Session.CurrentYear.fyDateEnd).ToListAsync();
        }

        public IEnumerable<tblPrdExpirateQuan> GetPrdExpirateQuanList => this.tbPrdExpirateQuanList;
        public IEnumerable<tblPrdexpirateQuanMain> GetPrdExpirateQuanMainList => db.tblPrdexpirateQuanMains.Where(x => x.expMainBrnId == Session.CurBranch.brnId &&
              x.expMainDate >= Session.CurrentYear.fyDateStart && x.expMainDate <= Session.CurrentYear.fyDateEnd).AsQueryable().ToList();
        public IEnumerable<tblPrdExpirateQuan> GetPrdExpirateQuanListByPrdId(int prdId)
        {
            return this.tbPrdExpirateQuanList.Where(x => x.expPrdId == prdId).ToList();
        }
        public IEnumerable<tblPrdExpirateQuan> GetPrdExpirateQuanListByMainId(int MainId)
        {
            return this.tbPrdExpirateQuanList.Where(x => x.expMainId == MainId).ToList();
        }

        public void Add(tblPrdExpirateQuan tbPrdExpirateQuan)
        {
            db.tblPrdExpirateQuans.Add(tbPrdExpirateQuan);
        }

        public void Attach(tblPrdExpirateQuan tbPrdExpirateQuan)
        {
            db.tblPrdExpirateQuans.Attach(tbPrdExpirateQuan);
        }

        public bool Remove(tblPrdExpirateQuan tbPrdExpirateQuan)
        {
            db.tblPrdExpirateQuans.Remove(tbPrdExpirateQuan);
            return SaveDB;
        }
        public bool RemoveMain(tblPrdexpirateQuanMain tbPrdExpirateQuanMain)
        {
            db.tblPrdexpirateQuanMains.Remove(tbPrdExpirateQuanMain);
            return SaveDB;
        }
        public bool SaveDB => ClsSaveDB.Save(db, LogHelper.GetLogger());
    }
}
