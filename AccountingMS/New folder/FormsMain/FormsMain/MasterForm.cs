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
using DevExpress.XtraBars;
using DevExpress.XtraLayout;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.Data.Helpers;
using DevExpress.XtraBars.Docking.Helpers;
using DevExpress.XtraDataLayout;

namespace AccountingMS.FormsMain
{
    public abstract partial class MasterForm : DevExpress.XtraEditors.XtraForm
    {
        public bool ShowMessage { get; set; } = true;

        public void DisableValidation(LayoutControl layoutControl)
        {
            foreach (var item in layoutControl.Controls)
            {
                if (item is BaseEdit edit)
                    edit.CausesValidation = false;
            }
        }
        public void EnableValidation(LayoutControl layoutControl)
        {
            foreach (var item in layoutControl.Controls)
            {
                if (item is BaseEdit edit)
                    edit.CausesValidation = true;
            }
        }
        public void BindDateChanged(LayoutControl layoutControl)
        {
            layoutControl.AllowCustomization = false;
            foreach (var item in layoutControl.Controls)
            {

                if (item is BaseEdit edit)
                    edit.EditValueChanged += (ss, ee)
                        =>
                    {
                        if (((BaseEdit)ss).ContainsFocus)
                        {
                            DataChanged = true;
                            //  System.Diagnostics.Debug.Print(((BaseEdit)ss).Name);
                        }
                    };
                else if (item is GridControl control)
                {

                    (control.MainView as GridView).RowUpdated += (ss, ee) => DataChanged = true;

                }
            }
        }
        public virtual bool IsSafeToClearData()
        {
            if (DataChanged)
            {
                var result = XtraMessageBox.Show(this, "هل تريد حفظ التغييرات؟", "تاكيد الحفظ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    btn_Save.PerformClick();
                    if (DataChanged)
                        return false;
                    else
                        return true;
                }
                else if (result == DialogResult.No)
                {
                    return true;
                }
                else if (result == DialogResult.Cancel)
                {
                    return false;
                }

            }
            return true;
        }
        private bool _isNew;
        public bool IsNew
        {
            get
            {

                return _isNew;
            }
            set
            {
                _isNew = value;
                btn_Delete.Enabled = !_isNew;
            }
        }
        public abstract bool CheckAction(WindowActions actions);
        public void AddMenuButton(ItemClickEventHandler args = null)
        {
            AddMenuButton("القائمه", args);
        }

        public void AddMenuButton(string caption, ItemClickEventHandler args = null)
        {
            DevExpress.XtraBars.BarButtonItem btn_Menu = new DevExpress.XtraBars.BarButtonItem();
            btn_Menu.Caption = caption; ;
            btn_Menu.Id = 3;
            //    btn_Menu.ImageOptions.SvgImage = global::Hassib.Properties.Resources.listview;
            btn_Menu.Name = "btn_Menu";
            btn_Menu.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barManager1.Items.Add(btn_Menu);
            this.bar2.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(btn_Menu));
            if (args != null)
                btn_Menu.ItemClick += args;
        }

        public void AddBarButton(BarItem btn)
        {
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { btn });
            this.bar2.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(btn));

        }
        public virtual void New()
        {
            DataChanged = false;
            IsNew = true;

        }
        public virtual void Delete()
        {
            XtraMessageBox.Show(text: "تم الحذف بنجاح", caption: this.Text, buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
            RefreshData();
            DataChanged = false;
        }
        public virtual void Print()
        {

        }
        public virtual void RefreshData()
        {

        }

        public abstract void Saved();

        public virtual void Save()
        {
            if (ShowMessage)
                XtraMessageBox.Show(text: "تم الحفظ بنجاح", caption: this.Text, buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
            Saved();
            DataChanged = false;
            IsNew = false;
        }

        public abstract void BeforeSave();

        private void Btn_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item.Enabled && CheckAction(IsNew ? WindowActions.Add : WindowActions.Edit))
            {
                BeforeSave();
                Save();

            }
        }
        protected bool DataChanged;
        protected override DevExpress.XtraEditors.FormShowMode ShowMode
        {
            get
            {
                return DevExpress.XtraEditors.FormShowMode.AfterInitialization;
            }
        }

        public MasterForm()
        {
            InitializeComponent();
            btn_Delete.ItemClick += Btn_Delete_ItemClick;
            btn_New.ItemClick += Btn_New_ItemClick;
            btn_Save.ItemClick += Btn_Save_ItemClick;
            btn_Print.ItemClick += Btn_print_ItemClick;
            btn_Refresh.ItemClick += Btn_Refresh_ItemClick;
            this.KeyPreview = true;
            this.KeyDown += MasterForm_KeyDown;
            this.Load += MasterForm_Load;
            this.FormClosing += MasterForm_FormClosing;
        }
        private void Btn_New_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item.Enabled)
                if (IsSafeToClearData())
                    New();
        }
        private void Btn_Refresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshData();
        }

        private void Btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item.Enabled && CheckAction(WindowActions.Delete))
            {
                if (XtraMessageBox.Show(text: "هل تريد الحذف", caption: this.Text, buttons: MessageBoxButtons.YesNo, icon: MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Delete();
                }
            };
        }
        private void Btn_print_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Enabled && CheckAction(WindowActions.Print))
            {
                Print();
                AfterPrint();

            }
        }
        public abstract void AfterPrint();
        public virtual void MasterForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            e.Cancel = !IsSafeToClearData();
        }

        public virtual void MasterForm_Load(object sender, EventArgs e)
        {
            RefreshData();

        }

        private void MasterForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control && e.Modifiers == Keys.Shift)
                btn_SaveAndNew.PerformClick();

            if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
                btn_Save.PerformClick();
            else if (e.KeyCode == Keys.N && e.Modifiers == Keys.Control)
                btn_New.PerformClick();
            else if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
                btn_Delete.PerformClick();
            else if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
                btn_Print.PerformClick();

        }

        private void btn_SaveAndNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            btn_Save.PerformClick();
            btn_New.PerformClick();
        }
    }

}
