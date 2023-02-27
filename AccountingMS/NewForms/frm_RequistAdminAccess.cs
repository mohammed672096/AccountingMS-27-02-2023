using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Forms.MAIN
{
    public partial class frm_RequestAdminAccess : DevExpress.XtraEditors.XtraForm   
    {
        string _PremissionName;
        static  bool gotAccess = false;
        private  frm_RequestAdminAccess()
        {
            InitializeComponent();
            gotAccess = false;
        }

        public static bool  RequestPremission(string premissionName  )
        { 
            frm_RequestAdminAccess frm = new frm_RequestAdminAccess();
            frm._PremissionName = premissionName;
            frm.simpleLabelItem1.Text = LangResource.UserWantToChange.Replace("@", CurrentSession.user.UserName);
            frm.ShowDialog();
              
            return gotAccess;
        }

        private void frm_RequestAdminAccess_Load(object sender, EventArgs e)
        { 
            gotAccess = false ; 
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            gotAccess = false;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            var encryptedPass = MyCryptography.Encrypt (textEdit2.Text);
            var user = db.St_Users.Where(x => x.UserName == textEdit1.Text && x.PassWord == encryptedPass ).SingleOrDefault();
            if (user != null)
            {
                string actionName = _PremissionName.Substring(_PremissionName.LastIndexOf("_")+1);
                bool access = false; 
                if(user.HasAccess == 1)
                {
                switch (actionName )
                {
                    case "Open":
                         access = db.St_UserPrivileges
                            .Where(x => x.UserID == user.ID 
                            && x.PrivilageName == _PremissionName.Substring(0, _PremissionName.LastIndexOf("_")))
                            .Select(x=>x.CanOpen).FirstOrDefault(); 
                        break;
                    case "Add":
                        access = db.St_UserPrivileges
                           .Where(x => x.UserID == user.ID
                           && x.PrivilageName == _PremissionName.Substring(0, _PremissionName.LastIndexOf("_")))
                           .Select(x => x.CanAdd ).FirstOrDefault();
                        break;
                    case "Edit":
                        access = db.St_UserPrivileges
                           .Where(x => x.UserID == user.ID
                           && x.PrivilageName == _PremissionName.Substring(0, _PremissionName.LastIndexOf("_")))
                           .Select(x => x.CanEdit ).FirstOrDefault();
                        break;
                    case "Delete":
                        access = db.St_UserPrivileges
                           .Where(x => x.UserID == user.ID
                           && x.PrivilageName == _PremissionName.Substring(0, _PremissionName.LastIndexOf("_")))
                           .Select(x => x.CanDelete).FirstOrDefault();
                        break;
                    case "Print":
                        access = db.St_UserPrivileges
                           .Where(x => x.UserID == user.ID
                           && x.PrivilageName == _PremissionName.Substring(0, _PremissionName.LastIndexOf("_")))
                           .Select(x => x.CanPrint).FirstOrDefault();
                        break;
                    default:
                        break;
                    }
                }
                else if (user.HasAccess == 0)
                    access = true;

                if (access)
                {
                    gotAccess = true;
                    Close();
                }
                else
                {
                    simpleLabelItem4.Text = LangResource.UserHasNoAccess;
                    simpleLabelItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
                //var access = db.St_UserPrivileges.Where(x => x.UserID == user.ID && x.PrivilageName == _PremissionName).FirstOrDefault();
                //if (access!= null && access.PrivilegeValue == true )
                //{
                //    gotAccess = true;
                //    Close();
                //}
                //else
                //{
                //    simpleLabelItem4.Text = LangResource.UserHasNoAccess;
                //    simpleLabelItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                //}


            }
            else
            {
                simpleLabelItem4.Text = LangResource.WrongUSerNameOrPass;
                simpleLabelItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }

        }
    }
}
