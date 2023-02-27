using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing.Drawing2D;

namespace ERP.Forms
{
    public partial class frm_AccountTree : frm_Master 
    {
        public frm_AccountTree()
        {
            InitializeComponent();
            barItem_Search.Visibility  =
            btn_Print.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            lkp_ParentAccount.Enabled = false;

        }
        public frm_AccountTree( int ID)
        {
            InitializeComponent();
            barItem_Search.Visibility =
            btn_Print.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            lkp_ParentAccount.Enabled = false;
            LoadAccountByID(ID);
        }
        DAL.Acc_Account account = new DAL.Acc_Account();
        public override void RefreshData()
        {
            base.RefreshData();


            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            CurrentSession.UserAccessbileAccounts = (from a in db.Acc_Accounts where a.Secrecy >= CurrentSession.user.AccountSecrecyLevel select a).ToList();
            treeList1.DataSource =lkp_ParentAccount.Properties.DataSource = CurrentSession.UserAccessbileAccounts.Select(x=> new { x.ID  ,x.ParentID , x.Name  }).ToList();
            treeList1.ParentFieldName = "ParentID";
            treeList1.KeyFieldName = "ID";
            lkp_ParentAccount.Properties.ValueMember = "ID";
            lkp_ParentAccount.Properties.DisplayMember  = "Name";

        }

        private void treeList1_CustomDrawNodeButton(object sender, DevExpress.XtraTreeList.CustomDrawNodeButtonEventArgs e)
        {
            Rectangle rect = Rectangle.Inflate(e.Bounds, -2,-2);

            // painting background
            Brush backBrush = e.Cache.GetSolidBrush ( Color.WhiteSmoke   ); 
            e.Cache.FillRectangle(backBrush, rect);
            // painting borders
            e.Cache.DrawRectangle(e.Cache.GetPen(Color.Black), rect);

            // determining the character to display
            string displayCharacter = e.Expanded ? "-" : "+";
            // formatting the output character
            StringFormat outCharacterFormat = e.Appearance.GetStringFormat();
            outCharacterFormat.Alignment = StringAlignment.Center;
            outCharacterFormat.LineAlignment = StringAlignment.Center;

            // painting the character
            e.Appearance.FontSizeDelta = -2;
            e.Appearance.FontStyleDelta = FontStyle.Bold;
            e.Cache.DrawString(displayCharacter, e.Appearance.Font,
                e.Cache.GetSolidBrush(Color.Black), rect, outCharacterFormat);

            // prohibiting default painting
            e.Handled = true;

        }
        void LoadAccountByID(int  num)
        { 
            if (ChangesMade && !SaveChangedData()) return;
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            account = db.Acc_Accounts.Where(x => x.ID  == num).First();
            GetData();
            IsNew = false;
        }

        public override void Save()
        {
            if (txt_Name.Text .Trim() == "")
            {
                txt_Name.ErrorText = LangResource.ErrorCantBeEmpry;
                return;
            }
            if (IsNew)
            {
                DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con); 

                DAL.Acc_Account account = new DAL.Acc_Account()
                {

                    Number =  txt_ID.Text ,
                    Name = txt_Name.Text ,
                    CanEdit = true ,
                    Level = Convert.ToInt16(bar_Level.EditValue),
                    Note = memoEdit1.Text,
                    ParentID =(int)(lkp_ParentAccount.EditValue),
                    Secrecy = Convert.ToInt16(bar_AccountSecresy.EditValue),
                    InsertUser = CurrentSession.user.ID,
                    InsertDate = db.GetSystemDate(),
                    ID = Master.GetNewAccountID()
                };
                 
                db.Acc_Accounts.InsertOnSubmit(account); 
                db.SubmitChanges();
                
            }
            else
            { 
            
                DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con); 
                DAL.Acc_Account OldAccount = db.Acc_Accounts.Where(x => x.Number.ToString() == txt_ID.Text.ToString()).First();
                OldAccount.LastUpdateUserID = CurrentSession.user.ID;
                OldAccount.LastUpdateDate = db.GetSystemDate();
                OldAccount.LastUpdateData = account.ToString();
                OldAccount.Name =   txt_Name.Text ;
                OldAccount.Level =    Convert.ToInt16(bar_Level .EditValue );
                OldAccount.Note =   memoEdit1.Text ;
                OldAccount.Secrecy = Convert.ToInt16(bar_AccountSecresy .EditValue);
                OldAccount.Number = txt_Name.Text;
                if (OldAccount.ParentID != (int?)(lkp_ParentAccount.EditValue))
                {
                    OldAccount.ParentID = (int?)(lkp_ParentAccount.EditValue);
                    OldAccount.Number =     Master.GetNewAccountNumber((int)OldAccount.ParentID);
                }
               
               db.SubmitChanges();

            }
            PartName = account.Name;
            PartNumber = account.Number.ToString();
            base.Save();
            treeList1.SetFocusedNode(treeList1.Nodes.Where(x => x.GetValue("ID").ToString() == account.ID.ToString()).First());
        }
        public override void Delete()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

            if (!AllowDelete)
            {
                XtraMessageBox.Show(LangResource.CantDeleteNoPermission, "", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            if(CanDeleteAccount(account.ID  ,true ) == false)
            {
                return;
            }

            if (IsNew) return;
            PartName = account.Name;
            PartNumber = account.Number.ToString();
            if (Master.AskForDelete(this, IsNew, PartName, PartNumber))
            {
                db.Acc_Accounts.DeleteOnSubmit(db.Acc_Accounts.Where(x => x.Number == account.Number).FirstOrDefault());
                db.SubmitChanges();
                New();
                base.Delete();
            }
        }
        public override void Print()
        {
           // if (CanPerformPrint() == false) return;

        }
        public override void New()
        {
            if (ChangesMade && !SaveChangedData()) return;
            if (IsNew) return;
            int oldAccountNumber =account.ID;
            int? oldAccountSecrecy = Convert.ToInt16(bar_AccountSecresy.EditValue);
            account = new DAL.Acc_Account();
            account.Name = "";
            account.ParentID = oldAccountNumber;
            account.Number = Master.GetNewAccountNumber((int)account.ParentID);
            account.CanEdit = true;
            account.Secrecy = oldAccountSecrecy??0;
            GetData();
            base.New();
            IsNew = true;
        }
   

        private void GetData()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            txt_ID.Text = account.Number.ToString();
            txt_Name.Text = account.Name.ToString();
            lkp_ParentAccount.EditValue = account.ParentID;
            memoEdit1.Text = account.Note;
            bar_Level.EditValue = account.Level;
            bar_AccountSecresy.EditValue = account.Secrecy;
            bar_Level.Enabled = !HaveChilds(account.Number.ToString()); 
            txt_InsertUser.Text  =db.St_Users.Where(x=>x.ID ==  account.InsertUser).Select(x=>x.UserName ).FirstOrDefault();
            txt_LastUpdate.Text = (account .LastUpdateDate != null) ? ((DateTime)account .LastUpdateDate).ToString("yyyy-MM-dd dddd hh:mm tt") : "";
            txt_UpdateUser .Text = db.St_Users.Where(x => x.ID == account.LastUpdateUserID).Select(x => x.UserName).FirstOrDefault();
            btn_Delete.Enabled = CanDeleteAccount(account.ID);
            btn_Delete.Enabled = btn_Save.Enabled = account.CanEdit;
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node == null || e.Node.GetValue("ID") == null ) return; 
            LoadAccountByID(int.Parse( e.Node.GetValue("ID").ToString()));
        }
        bool HaveChilds(string num, bool ShowMessage = false)
        {

            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            var list = (from a in db.Acc_Accounts
                        where a.ParentID.ToString() == num
                        select a).Count();
            if ((list > 0) && ShowMessage)
            {

                XtraMessageBox.Show(LangResource.CantDeleteAccountHasChilds , "", MessageBoxButtons.OK,
                     MessageBoxIcon.Information);
            }

            return (list > 0 );
        }
        bool CanDeleteAccount(int num , bool ShowMessage = false )
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            var list = (from aa in db.Acc_ActivityDetials
                        where aa.ACCID == num
                        select aa).Count();

            if ((!(list == 0)) && ShowMessage)
            {

            XtraMessageBox.Show(LangResource.CantDeleteAccountHasAcctiveties, "", MessageBoxButtons.OK,
                 MessageBoxIcon.Information);
            }


            return ( !HaveChilds(num.ToString(), ShowMessage) && (list == 0));
        }

        private void bar_AccountSecresy_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void bar_AccountSecresy_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            if (lkp_ParentAccount.EditValue == null) return;
            account = db.Acc_Accounts.Where(x => x.ID .ToString() == lkp_ParentAccount.EditValue .ToString()).FirstOrDefault();
            if (account == null) return;
            if (Convert.ToInt16(e.NewValue) < account.Secrecy)
                e.Cancel = true;
        }
    }
}