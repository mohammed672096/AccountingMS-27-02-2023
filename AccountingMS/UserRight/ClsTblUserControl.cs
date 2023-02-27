using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    class ClsTblUserControl
    {
        accountingEntities db = new accountingEntities();
        IEnumerable<tblUserControl> tbUserControlList;

        public ClsTblUserControl()
        {
            InitData();
        }

        private void InitData()
        {
            this.tbUserControlList = db.tblUserControls.OrderBy(x => x.ucNo).ToList();
        }

        public IEnumerable<tblUserControl> GetUserControlList => this.tbUserControlList;

        public byte GetUserControlNoByName(string ucName)
        {
            return this.tbUserControlList.Where(x => x.ucName == ucName).Select(x => x.ucNo).FirstOrDefault();
        }

        public bool CheclBBI(string bbiName)
        {
            return this.tbUserControlList.Any(x => x.ucName == bbiName);
        }

        public string GetUserControlNameByNo(byte ucNo)
        {
            return this.tbUserControlList.Where(x => x.ucNo == ucNo).Select(x =>
                (!MySetting.GetPrivateSetting.LangEng) ? x.ucCaption : x.ucCaptionEn).FirstOrDefault();
        }
    }
}
