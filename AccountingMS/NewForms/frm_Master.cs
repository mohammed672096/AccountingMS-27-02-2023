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
using DevExpress.XtraEditors.Controls;
using System.Resources;
using System.Reflection;

namespace ERP
{
   
    public partial class frm_Master : DevExpress.XtraEditors.XtraForm
    {
        public frm_Master()
        {
            InitializeComponent();
        }

        public  bool CanAdd, AllowDelete, CanEdit, CanPrint;
        public virtual bool IsNew { get; set; }

        public bool   ChangesMade;
        public string PartName;
        public string PartNumber;
        public List<int> list;
        public virtual Master.SystemProssess  ProcessType { get; }

        public  Boolean CanSave()
        {
            if (IsNew && !CanAdd && Forms.MAIN.frm_RequestAdminAccess.RequestPremission(this.Name + "_Add") == false) return false ; 
            else if (!IsNew && !CanEdit && Forms.MAIN.frm_RequestAdminAccess.RequestPremission(this.Name + "_Edit") == false) return false;
            else  return true;
        }
        public Boolean CanPerformDelete()
        {
            //var UserCanAdd = CurrentSession.userPrivilageList.Where(h => h.PrivilageName == this.Name + "_Add");
            ////var UserCanDelete = CurrentSession.userPrivilageList.Where(h => h.PrivilageName == this.Name + "_Delete");
            //var UserCanEdit = CurrentSession.userPrivilageList.Where(h => h.PrivilageName == this.Name + "_Edit");
            ////var UserCanPrint = CurrentSession.userPrivilageList.Where(h => h.PrivilageName == this.Name + "_Print");

            //CanAdd = (UserCanAdd.Count() > 0 && (bool)UserCanAdd.First().PrivilegeValue);
            //CanDelete = (UserCanDelete.Count() > 0 && (bool)UserCanDelete.First().PrivilegeValue);
            //CanEdit = (UserCanEdit.Count() > 0 && (bool)UserCanEdit.First().PrivilegeValue);
            //CanPrint = (UserCanPrint.Count() > 0 && (bool)UserCanPrint.First().PrivilegeValue);
            RunUserPrivilage();
            if (!AllowDelete && Forms.MAIN.frm_RequestAdminAccess.RequestPremission(this.Name + "_Delete") == false)
                return false;
            else return true;
        }
        public virtual  Boolean CanPerformPrint()
        {
            //var UserCanAdd = CurrentSession.userPrivilageList.Where(h => h.PrivilageName == this.Name + "_Add");
            ////var UserCanDelete = CurrentSession.userPrivilageList.Where(h => h.PrivilageName == this.Name + "_Delete");
            //var UserCanEdit = CurrentSession.userPrivilageList.Where(h => h.PrivilageName == this.Name + "_Edit"); 
            ////var UserCanPrint = CurrentSession.userPrivilageList.Where(h => h.PrivilageName == this.Name + "_Print");

            //CanAdd = (UserCanAdd.Count() > 0 && (bool)UserCanAdd.First().PrivilegeValue);
            //CanDelete = (UserCanDelete.Count() > 0 && (bool)UserCanDelete.First().PrivilegeValue);
            //CanEdit = (UserCanEdit.Count() > 0 && (bool)UserCanEdit.First().PrivilegeValue);
            //CanPrint = (UserCanPrint.Count() > 0 && (bool)UserCanPrint.First().PrivilegeValue);
            RunUserPrivilage();
            if (!AllowDelete && Forms.MAIN.frm_RequestAdminAccess.RequestPremission(this.Name + "_Print") == false)
                return false;
            else return true;
        }
        public virtual void  frm_Load(object sender, EventArgs e)
        {
            RefreshData();
            RunUserPrivilage();
            for (int i = 0; i <= this.Controls.Count -1 ; i++)
            {
                if (this.Controls[i] is GroupControl)
                    ((GroupControl)this.Controls[i]).MouseDown += frm_Master_MouseDown;
            }
            // Load User Privilage

        }
        public virtual void RunUserPrivilage()
        {

            if (CurrentSession.user.HasAccess == 0)
            {
                CanAdd = AllowDelete = CanEdit = CanPrint = true;
                return;
            }
       
            CanAdd = CurrentSession.userPrivilageList.Where(h => h.PrivilageName == this.Name).Select(x => x.CanAdd).FirstOrDefault ();
            CanEdit = CurrentSession.userPrivilageList.Where(h => h.PrivilageName == this.Name).Select(x => x.CanEdit).FirstOrDefault();
            AllowDelete = CurrentSession.userPrivilageList.Where(h => h.PrivilageName == this.Name).Select(x => x.CanDelete).FirstOrDefault();
            CanPrint = CurrentSession.userPrivilageList.Where(h => h.PrivilageName == this.Name).Select(x => x.CanPrint).FirstOrDefault();
 
        }
        public virtual void RefreshData()
        {

        }
        public virtual void New()
        {
            barItem_Search.EditValue = null;
        }
        public virtual void Next()
        {
            
            if (list == null || list.Count() == 0) return; 
            if (barItem_Search.EditValue .In ("",null)) { barItem_Search.EditValue = list.Min();return; }
            int currentid =   Convert.ToInt32(barItem_Search.EditValue);
            int CurrentIdIndex = list.IndexOf(currentid);
            if (CurrentIdIndex + 1 == list.Count()) { return; }
            barItem_Search.EditValue = (list.ToArray())[ CurrentIdIndex + 1] ;
        }
        public virtual void Previous()
        {
    
            if (list == null || list.Count() == 0) return;
            if (barItem_Search.EditValue == null) { barItem_Search.EditValue = list.Max(); return; }
            int currentid = Convert.ToInt32(barItem_Search.EditValue);
            int CurrentIdIndex = list.IndexOf(currentid);
            if (CurrentIdIndex <= 0 ) { return; }
            barItem_Search.EditValue = (list.ToArray())[CurrentIdIndex - 1];
        }
        public virtual void GoTo(int id)
        {

        }
        public bool SaveChangedData()
        {
            switch (Master.AskForSaving())
            {

                case DialogResult.Cancel: return false;
                case DialogResult.Yes: Save(); return true;
                case DialogResult.No: return true;
                default: return false;


            }
        }
        public virtual void DataChanged(object sender, EventArgs e)
        {
            ChangesMade = true;

        }
        public virtual void Save()
        {
            if ((bool)CurrentSession.user.PrintAfterSaving&& IsNew) Print();
            Master.InsertUserLog((IsNew)? 0 :1 , this.Name, PartName ,PartNumber );
            Master.Saved( IsNew, PartName, PartNumber);
            Master.RefreshAllWindows();
            ChangesMade = false;
            IsNew = false;
        }
        public virtual void Delete()
        {
            Master.InsertUserLog(2, this.Name, PartName, PartNumber);
            Master.RefreshAllWindows();

        }
        public virtual void Print()
        {
            Master.InsertUserLog(3, this.Name, PartName, PartNumber);

           // ResourceManager rm = new ResourceManager(
           //"ERP.LangResource",
           // Assembly.GetExecutingAssembly());
           // MessageBox.Show(rm.GetObject("Store").ToString());
             
        }
        bool ProssingKey;
        /* 
        If the form is currently prossing a keyDown event 
        used to prevent  The Form.KeyDown event is raised twice when a key is pressed in
        a grid and the Form.KeyPreview option is enabled  
        */

        public virtual void frm_Master_KeyDown(object sender, KeyEventArgs e)
        {
            if (ProssingKey) return;
            ProssingKey = true; 
            if (e.KeyCode == Keys.S && e.Modifiers == Keys.Alt)
            {

            }
            if (e.KeyCode == Keys.I && e.Modifiers == Keys.Alt)
            {

            }
            if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
                
                    Save();
               
            }
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
            {
              
                    Delete();
            }
            if (e.KeyCode == Keys.N && e.Modifiers == Keys.Control)
            {
                     New();
            }
            if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                if (IsNew || ChangesMade)
                    SaveAndPrint();
                else 
                     Print();
            }
            if (e.KeyCode == Keys.R && e.Modifiers == Keys.Control)
            {
                RefreshData();
            }
            if(e.KeyCode == Keys.F &&e.Modifiers == Keys.Alt)
            {
                GUI.frm_SmartSearch.ShowFindWindow();
            }
            ProssingKey = false;
        }
        public void SaveAndPrint()
        {
            if (XtraMessageBox.Show(LangResource.MustSaveFirstDoYouWantToSave, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)  == DialogResult.Yes)
            {
                bool WasNew = IsNew;
                Save();
                if(ChangesMade == false && IsNew == false &&( CurrentSession.user.PrintAfterSaving == true && WasNew == false   ))
                    Print();
            }
        }
        public bool IsDocumentSaved()
        {
            if (ChangesMade)
            {
                if (XtraMessageBox.Show(LangResource.MustSaveFirstDoYouWantToSave, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Save();
                else
                    return false;

            }
            return true;

               
        }
        private void lkp_List_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.GetType() != typeof(EditorButton)) return;
            if (e.Button.Tag != null && e.Button.Tag.ToString() == "Search")
            {
          
            }
            if (e.Button.Tag != null && e.Button.Tag.ToString() == "Left")
            {
                Previous();

            }
            if (e.Button.Tag != null && e.Button.Tag.ToString() == "Right")
            {
                Next();
            }
        }

        private void barItem_Search_EditValueChanged(object sender, EventArgs e)
        {
            if (barItem_Search.EditValue != null && barItem_Search.EditValue != DBNull.Value && barItem_Search.EditValue.ToString().Trim() != string.Empty)
                GoTo(Convert.ToInt32(barItem_Search.EditValue));
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (IsNew || ChangesMade)
                SaveAndPrint();
            else
                Print();
        }

        public  void frm_Master_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ChangesMade && !SaveChangedData()) e.Cancel = true;

        }

        private void frm_Master_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void btn_ShowHints_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowHints();
        }

        public virtual void  ShowHints()
        {
           
        }

        private void frm_Master_MouseClick(object sender, MouseEventArgs e)
        {
             
        }

        private void frm_Master_Enter(object sender, EventArgs e)
        {
           
        }
        public int JornalID;

        private void ViewJornal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RefreshData();
        }

        private void btn_New_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            New(); 
        }
        private void bt_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }
        private void btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Delete(); 
        }
    }
}