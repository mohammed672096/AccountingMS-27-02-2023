using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraDataLayout;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using PosFinalCost.Classe;
using System.Globalization;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;
using DevExpress.XtraLayout;

namespace PosFinalCost.Forms
{
    public partial class UC_Setting: UC_Master
    {
        string TableName= "UserSettingsProfile";
        BindingSource bindingSource = new BindingSource();
        PosDBDataContext dbLocal=new PosDBDataContext(Program.ConnectionString);
        public DataLayoutControl dataLayout = new DataLayoutControl() { Dock = DockStyle.Fill,RightToLeft=RightToLeft.Yes };
        public UC_Setting()
        {
            InitializeComponent();
            bindingNavigator11.BindingSource = bindingSource;
            bindingSource.DataSource = dbLocal.UserSettingsProfiles;
            dataLayout.ShowCustomization += DataLayoutControl1_ShowCustomization;
            dataLayout.HideCustomization += DataLayoutControl1_HideCustomization;
        }
        private void DataLayoutControl1_HideCustomization(object sender, EventArgs e)
        {
            ClsPath.SaveCustomContol(this.dataLayout, TableName);
        }
        private void DataLayoutControl1_ShowCustomization(object sender, EventArgs e)
        {
            ((DataLayoutControl)sender).CustomizationForm.Text = "تغيير التصميم";
        }
        ComponentFlyoutDialog flyDailog = new ComponentFlyoutDialog();
        public override void Save()
        {
            if (bindingSource.Current != null)
            {
                var us = bindingSource.Current as UserSettingsProfile;
                if (us == null) return;
                if (us.Name == String.Empty||us.Name is null)
                {
                    ClsXtraMssgBox.ShowError("يجب كتابة اسم نموذج الاعدادات اولا");
                    return;
                }
                if (IsNew)
                    dbLocal.UserSettingsProfiles.InsertOnSubmit(us);
                dbLocal.SubmitChanges();
                Session.GetDataUserSettingsProfile(dbLocal);
                TextReadOnly(true);
                var sett = bindingSource.Current as UserSettingsProfile;
                string mssg = $"نموذج الاعدادات: {sett?.Name}";
                flyDailog.ShowDialogUC(this, mssg, IsNew);
            }
            TextReadOnly(true);
            base.Save();
        }
        public override void New()
        {
            IsNew = true;
            TextReadOnly(false);
            base.New();
        }
        public void TextReadOnly(bool state)
        {
            foreach (var item in this.Controls)
            {
                if (item is DataLayoutControl bbi)
                {
                    foreach (var item1 in bbi.Controls)
                    {
                        if (item1 is BaseEdit txt&& txt.Name!= "UserID"&& txt.Name != "EnterTime")
                            txt.ReadOnly = state;
                    }
                    return;
                }
            }
        }
      
        public override void Delete()
        {
            var us = bindingSource.Current as UserSettingsProfile;
            if (us == null) return;
            if (ClsXtraMssgBox.ShowWarningYesNo($"هل انت متاكد من حذف سجل الاعدادات {us.Name}؟") == DialogResult.Yes)
                if (bindingSource.Current != null)
                {
                    dbLocal.UserSettingsProfiles.DeleteAllOnSubmit(dbLocal.UserSettingsProfiles.Where(x => x.ID == us.ID));
                    dbLocal.SubmitChanges();
                    RefreshData();
                }
            base.Delete();
        }
        private GridControl GetGridControl()
        {
            return dataLayout.Items.Where(x => x is LayoutControlItem layoutControl
            && layoutControl.Owner is GridControl).ToList().FirstOrDefault()?.Owner as GridControl;
                //  .ForEach(y =>
                //((LayoutControlItem)y).Owner.Appearance.Control.Font = fontConverter);
            //foreach (var item in this.Controls)
            //{
            //    if (item is DataLayoutControl bbi)
            //    {
            //        foreach (var item1 in bbi.Controls)
            //            if (item1 is GridControl Grid)
            //                return Grid;
            //        return null;
            //    }
            //}
            //return null;
        }
        public override void Print()
        {
            GetGridControl()?.ShowPrintPreview();
            base.Print();
        }
        public override void DataUpdate()
        {
            TextReadOnly(false);
            EnableOrDisyble(false);
            base.DataUpdate();
        }
        public override void RefreshData()
        {
            TextReadOnly(true);
            dbLocal = new PosDBDataContext(Program.ConnectionString);
            if(bindingSource.Current!=null)
            bindingSource.DataSource = dbLocal.GetTable(bindingSource.Current.GetType());
            base.RefreshData();
        }
    

        public override void Reset()
        {
            RefreshData();
            base.Reset();
        }
        private  void UC_Master_Load(object sender, EventArgs e)
        {
            new ClsUserRoleValidation(this, UserControls.DefaultSettings);
            Session.GetColNameForTable("UserSettingsProfile");
            MydataLayoutControl();
            this.Controls.Add(dataLayout);
            dataLayout.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
        }
        public void GetLay(GetColumnForTableResult item, LayoutControlGroup layoutControlGroup)
        {
            LayoutControlItem LayoutItem;
            LayoutItem = layoutControlGroup.AddItem(item.Caption, MyTools.GetPropertyControl(item.ColumnName, item));
            LayoutItem.Control.DataBindings.Add(new Binding("EditValue", bindingNavigator11.BindingSource, item.ColumnName, true, DataSourceUpdateMode.OnPropertyChanged));
            if (MyTools.VisibilityItem(LayoutItem)) return;
            LayoutItem.TextVisible = true;
            LayoutItem.Text = item.Caption;
            LayoutItem.CustomizationFormText = item.Caption;
            dataLayout.AddGroup(layoutControlGroup);
        }
        public  void MydataLayoutControl()
        {
            LayoutControlGroup layoutControlGroup1 = new LayoutControlGroup() { Text = "الاعدادات" };
            dataLayout.AddGroup(new LayoutControlGroup() { GroupBordersVisible = false }).Add(MyTools.MyLayoutItem(bindingNavigator11));
            Session.ColNameForTable.ToList().ForEach(x => GetLay(x, layoutControlGroup1));
            ClsPath.ReLodeCustomContol(this.dataLayout, TableName);
            dataLayout.DataSource = bindingNavigator11.BindingSource;
        }
    }
}
