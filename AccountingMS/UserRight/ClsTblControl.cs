using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    class ClsTblControl
    {
        accountingEntities db = new accountingEntities();
        IEnumerable<tblControl> tbControlList;

        public ClsTblControl()
        {
            InitData();
        }

        private void InitData()
        {
            this.tbControlList = db.tblControls.OrderBy(x => x.cntucNo).ThenBy(x => x.cntId).ToList();
        }

        public IEnumerable<tblControl> GetControlList => this.tbControlList;

        public IEnumerable<tblControl> GetControlListByUCNo(byte ucNo)
        {
            return this.tbControlList.Where(x => x.cntucNo == ucNo);
        }

        public short GetControlIdByNameNducNo(string cntName, byte ucNo)
        {
            return this.tbControlList.Where(x => x.cntucNo == ucNo && x.cntName == cntName).Select(x => x.cntId).FirstOrDefault();
        }

        public string GetControlNameById(short cntId)
        {
            return this.tbControlList.Where(x => x.cntId == cntId).Select(x => x.cntName).FirstOrDefault();
        }

        public string GetControlCaptionById(short cntId)
        {
            return this.tbControlList.Where(x => x.cntId == cntId).Select(x =>
                (!MySetting.GetPrivateSetting.LangEng) ? x.cntCaption : x.cntCaptionEn).FirstOrDefault();
        }
    }
}
