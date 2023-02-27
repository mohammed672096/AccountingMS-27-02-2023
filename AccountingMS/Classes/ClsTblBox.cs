using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    class ClsTblBox
    {
        public ClsTblBox()
        {
            if (Session.Boxes.Count <= 0)
                Session.GetDataBoxes();
        }

        public void RefreshData()
        {
            Session.GetDataBoxes();
        }

        public List<tblAccountBox> GetBoxList => Session.Boxes;

        public tblAccountBox GetBoxObjById(int boxId)
        {
            return Session.Boxes.FirstOrDefault(x => x.id == boxId);
        }

        public tblAccountBox GetBoxObjByNo(int boxNo)
        {
            return Session.Boxes.FirstOrDefault(x => x.boxNo == boxNo);
        }

        public tblAccountBox GetBoxObjByAccNo(long boxAccNo)
        {
            return Session.Boxes.FirstOrDefault(x => x.boxAccNo == boxAccNo);
        }

        public string GetBoxNameByNo(int boxNo)
        {
            string boxName = Session.Boxes.Where(x => x.boxNo == boxNo).Select(x => x.boxName).FirstOrDefault();
            return boxName;
        }

        public string GetBoxNameByAccNo(long accNo)
        {
            if (accNo <= 0) return default;
            return Session.Boxes.Where(x => x.boxAccNo == accNo).Select(x => x.boxName).FirstOrDefault();
        }

        public bool Delete(tblAccountBox tbBox)
        {
            using (var db = new accountingEntities())
            {
                var box = db.tblAccountBoxes.FirstOrDefault(x => x.id == tbBox.id);
                db.tblAccountBoxes.Remove(box);
                if (ClsSaveDB.Save(db, LogHelper.GetLogger()))
                {
                    Session.Boxes.Remove(box);
                    return true;
                }
                return false;
            }
        }

        public void InitBoxLookupEdit(LookUpEdit boxLookupEdit)
        {
            boxLookupEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("boxNo", "رقم الصندوق", 11, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("boxName", "إسم الصندوق", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            boxLookupEdit.Properties.DataSource = Session.Boxes.Where(x => x.boxBrnId == Session.CurBranch.brnId);
            boxLookupEdit.Properties.DisplayMember = "boxNo";
            boxLookupEdit.Properties.ValueMember = "boxNo";
        }

        public void InitBoxLookupEditBoxNameDispMbr(LookUpEdit boxLookupEdit)
        {
            boxLookupEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("boxNo", "رقم الصندوق", 10, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("boxName", "إسم الصندوق", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            boxLookupEdit.Properties.DataSource = Session.Boxes.Where(x => x.boxCurrency == 1).Where(x => x.boxBrnId == Session.CurBranch.brnId).ToList();
            boxLookupEdit.Properties.ValueMember = "boxNo";
            boxLookupEdit.Properties.DisplayMember = "boxName";
        }
        public void InitBoxLookupEditSetteing(LookUpEdit boxLookupEdit)
        {
            boxLookupEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("boxNo", "رقم الصندوق", 11, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("boxName", "إسم الصندوق", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("boxAccNo", "رقم حساب الصندوق", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near)});
            boxLookupEdit.Properties.DataSource = Session.Boxes.Where(x => x.boxBrnId == Session.CurBranch.brnId);
            boxLookupEdit.Properties.DisplayMember = "boxName";
            boxLookupEdit.Properties.ValueMember = "boxAccNo";
        }
        public void InitBoxBankLookupEdit(LookUpEdit boxLookupEdit)
        {
            boxLookupEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("bankNo", "رقم البنك", 11, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("bankName", "إسم البنك", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            boxLookupEdit.Properties.DataSource = Session.Banks;//.Where(x => x.boxBrnId == Session.CurBranch.brnId);
            boxLookupEdit.Properties.DisplayMember = "bankNo";
            boxLookupEdit.Properties.ValueMember = "bankNo";
        }
        public void InitBoxLookupEditAccNoValMbr(LookUpEdit boxLookupEdit)
        {
            boxLookupEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("boxNo", "رقم الصندوق", 10, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("boxName", "إسم الصندوق", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            boxLookupEdit.Properties.DataSource = Session.Boxes.Where(x => x.boxBrnId == Session.CurBranch.brnId);
            boxLookupEdit.Properties.ValueMember = "boxAccNo";
            boxLookupEdit.Properties.DisplayMember = "boxNo";

            //boxLookupEdit.Properties.DataSource = bindingSourceBoxNo;
            //boxLookupEdit.Properties.DisplayMember = "boxNo";
            //boxLookupEdit.Properties.ValueMember = "boxAccNo";
            //boxLookupEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            //new DevExpress.XtraEditors.Controls.LookUpColumnInfo("boxNo", "رقم الصندوق", 11, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Near),
            //new DevExpress.XtraEditors.Controls.LookUpColumnInfo("boxName", "إسم الصندوق", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            //boxLookupEdit.Size = new System.Drawing.Size(50, 20);
        }


    }
}
