using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraLayout;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace AccountingMS.Forms
{
    public partial class MasterForm :AccountingMS.FormsMain.MasterForm
    {
        internal int EntityID = 0;
        internal string EntityCode = null;
        internal string ScreenName => String.Join("", this.Text.Where(x => Char.IsDigit(x) == false && (new char[]{',' , '-'}).Contains( x)== false  ));

        public MasterForm() : base()
        {
            btn_Log.ItemClick += btn_Log_ItemClick;
        }
      
        public override void MasterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.SaveGridLayoutIfFound(CurrentSession.CurrentUser.ID.ToString());
            base.MasterForm_FormClosing(sender, e);
        }
        public override void MasterForm_Load(object sender, EventArgs e)
        {
            base.MasterForm_Load(sender, e);
            //ApplyUserSettings(CurrentSession.CurrentUser?.SettingsProfile);
            //this.RestoreGridLayoutIfFound((CurrentSession.CurrentUser?.ID)?.ToString());
        }





        //public NavigationObject _navigationObject;
        //public NavigationObject NavigationObject
        //{
        //    get
        //    {
        //        if (_navigationObject == null)
        //        {
        //            if (this.Tag is int id)
        //                _navigationObject = NavigationObjects.AllObjects.FirstOrDefault(x => x.ID == id);
        //            else
        //                _navigationObject = NavigationObjects.AllObjects.Where(x => x.Form != null).FirstOrDefault(x => x.Form.Name == Name);

        //        }
        //        return _navigationObject;
        //    }
        //}

        //UserAccessProfileDetail _profile;
        //public UserAccessProfileDetail Profile
        //{
        //    get
        //    {

        //        if (_profile == null && NavigationObject != null)
        //        {
        //            using (accountingEntities db = new accountingEntities())
        //            {
        //                _profile = CurrentSession.CurrentUser.AccessProfile.Details .Where(x =>   x.ObjectId == NavigationObject.ID).FirstOrDefault();

        //            }

        //        }

        //        return _profile;
        //    }
        //}


 

      
     




        void LogAction(WindowActions action)
        {
            LayoutControl layoutControl;
            layoutControl = this.Controls.OfType<LayoutControl>().FirstOrDefault(); 
            if (layoutControl != null)
            {
                IEnumerable<BaseEdit> controls = layoutControl.Controls.OfType<BaseEdit>();
                EntityCode = controls.Where(x => x.Name.StartsWith("Code")).FirstOrDefault()?.EditValue?.ToString();
                var id = controls.Where(x => x.Name.StartsWith("ID")).FirstOrDefault()?.EditValue;
                if (id != null)
                {
                    if (id is int IdValue)
                        EntityID = IdValue;
                    else
                        int.TryParse(id.ToString(), out EntityID);
                }
            }
            //accountingEntities.SaveTrackedItems(EntityID, EntityCode, ScreenName, this.GetType().Name, action, CurrentSession.CurrentUser.ID);
        }


 
        /// <summary>
        /// Apply the settings form a setting profile 
        /// </summary>
        /// <param name="profile"> leave null to apply the current user profile </param>
        public virtual void ApplyUserSettings(tblSetting profile )
        {
     

        }
 
  



        private void btn_Log_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Name = this.GetType().Name;
            //if (CurrentSession.CurrentUser.Type == UserType.User && CurrentSession.CurrentUser.AccessProfile.CanOpenWindow(this) == false)
            //{
            //    XtraMessageBox.Show("ليس لديك الصلاحيات اللازمه");
            //    return;
            //}


            LayoutControl layoutControl;
            layoutControl = this.Controls.OfType<LayoutControl>().FirstOrDefault();

            if (layoutControl != null)
            {
                IEnumerable<BaseEdit> controls = layoutControl.Controls.OfType<BaseEdit>(); 
                var id = controls.Where(x => x.Name.StartsWith("ID")).FirstOrDefault()?.EditValue;
                if (id != null)
                {
                    if (id is int IdValue)
                        EntityID = IdValue;
                    else
                        int.TryParse(id.ToString(), out EntityID);

                    //UserLogView.Instance.Close();
                    //UserLogView.Instance.GoTo(this.GetType().Name, EntityID);
                    //UserLogView.Instance.ShowDialog();
                }
            }
          
        }

        public override bool CheckAction(WindowActions actions)
        {
            return true;//CurrentSession.CurrentUser.Type == UserType.Administrator || Classes.UserAuthentication.CheckAction(this.Profile, actions);
        }

        public override void Save()
        {

            //if (CurrentSession.CurrentUser.SettingsProfile.PrintAfterSave && IsNew)
                btn_Print.PerformClick();
            base.Save();
        }
        public override void Delete()
        {
            LogAction(WindowActions.Delete);
            base.Delete();
        }
        public override void Saved()
        {
            LogAction((IsNew ? WindowActions.Add : WindowActions.Edit));
        }

        public override void BeforeSave()
        {
            //accountingEntities.ClearTrackedItems();
        }

        public override void AfterPrint()
        {
            LogAction(WindowActions.Print);
        }


        //////////////////////////////////
        ///

    }

}
