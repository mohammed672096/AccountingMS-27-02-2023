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
using DevExpress.XtraLayout;

namespace PosFinalCost.Forms
{
    public partial class UC_Master : UserControl
    {
        public UC_Master()
        {
            InitializeComponent();
            GetResources();
            btnUpdatePermission.Click += BtnUpdatePermission_Click;
        }
        private void BtnUpdatePermission_Click(object sender, EventArgs e)
        {
            UpdatePermissionUser();
        }
        CultureInfo _ci;
        ComponentResourceManager _resource;
        private void GetResources()
        {
            if (!Program.My_Setting.LangEng)
            {
                _ci = new CultureInfo("ar");
                _resource = new ComponentResourceManager(typeof(Language.UC_MasterInvoiceAr));
            }
            else
            {
                _ci = new CultureInfo("en");
                _resource = new ComponentResourceManager(typeof(Language.UC_MasterInvEn));
                EnglishTranslation();
            }
            foreach (var control in bindingNavigator11.Items)
                if (control is ToolStripItem c)
                    _resource.ApplyResources(c, c.Name, _ci);
        }
        private void EnglishTranslation()
        {
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        }
        public bool IsNew;
        public string MessString;
        public static string No;
        public static string ErrorText
        {
            get
            {
                return "هذا الحقل مطلوب";
            }
        }
        public static string MessgTextValidNo
        {
            get
            {
                return !Program.My_Setting.LangEng ? $"رقم {No} موجود من قبل !!!\n قم باختيار رقم اخر" : $"Number {No} already exists,\n choose another Number!!!";
            }
        }
        public static string MessgTextDelete
        {
            get
            {
                return !Program.My_Setting.LangEng ? $"هل انت متاكد من حذف  {No} ?" : $"Are you sure to delete {No} ?";
            }
        }
        public virtual void Save()
        {
            EnableOrDisyble(true);
        }
        public virtual void New()
        {
            EnableOrDisyble(false);
            IsNew = true;
        }
        public virtual void Delete()
        {

        }
        public virtual void UpdatePermissionUser()
        {
            EnableOrDisyble(false);
        }
        private GridControl GetGridControl()
        {
            foreach (var item in this.Controls)
                if (item is DataLayoutControl bbi)
                    return (bbi.Items.Where(x => x is LayoutControlItem layoutControl && layoutControl.Control is GridControl grid).ToList().FirstOrDefault() as LayoutControlItem)?.Control as GridControl;
            return null;
        }
        public virtual void Print()
        {
            GetGridControl()?.ShowPrintPreview();
        }
        public virtual void DataUpdate()
        {
            IsNew = false;
            EnableOrDisyble(false);
        }
        public virtual void RefreshData()
        {
            //dbLocal = new PosDBDataContext(Program.ConnectionString);
            //if(bindingSource.Current!=null)
            //bindingSource.DataSource = dbLocal.GetTable(bindingSource.Current.GetType());
        }
        public virtual void ShowError()
        {
            ClsXtraMssgBox.ShowError(MessgTextValidNo);
        }

        public virtual void Reset()
        {
            EnableOrDisyble(true);
            RefreshData();
        }
        public virtual bool IsDataVailde()
        {
            return true;
        }
      
        public virtual void EnableOrDisyble(bool state)
        {
            btnAddNew.Enabled = state;
            btnDelete.Enabled = state;
            btnUpdate.Enabled = state;
            btnUpdatePermission.Enabled = state;
            btnPrint.Enabled = state;

            btnSave.Enabled = !state;
            //btnSaveAndNew.Enabled = !state;
            btnReset.Enabled = !state;
        }

     
        private void btnSaveAndNew_Click(object sender, EventArgs e)
        {
            btnSave.PerformClick();
            btnAddNew.PerformClick();
        }

        private void UC_Master_Load(object sender, EventArgs e)
        {
            btnAddNew.Click += BtnAddNew_Click;
            btnDelete.Click += BtnDelete_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnPrint.Click += BtnPrint_Click;
            btnRefresh.Click += BtnRefresh_Click;
            btnReset.Click += BtnReset_Click;
            this.KeyDown += UC_Master_KeyDown;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
                RefreshData();
        }

        public void UC_Master_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                btnRefresh.PerformClick();
            if (e.KeyCode == Keys.F2)
                btnAddNew.PerformClick();
            if (e.KeyCode == Keys.F3)
                btnSave.PerformClick();
            if (e.KeyCode == Keys.F4)
                btnUpdate.PerformClick();
            if (e.KeyCode == Keys.F5)
                btnReset.PerformClick();
            if (e.KeyCode == Keys.F6)
                btnDelete.PerformClick();
            if (e.KeyCode == Keys.F7)
                btnPrint.PerformClick();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            DataUpdate();
      
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            New();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsDataVailde())
                Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Dispose();
        }
    }
}
