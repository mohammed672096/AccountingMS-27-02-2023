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
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;

namespace PosFinalCost.Forms
{
    public partial class UC_DefaultSetting : UC_Master
    {
        PosDBDataContext dbLocal=new PosDBDataContext(Program.ConnectionString);
        public UC_DefaultSetting()
        {
            InitializeComponent();
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-fffffff"));
            bindingNavigator11.BindingSource = userSettingsProfileBindingSource;
            userSettingsProfileBindingSource.DataSource = dbLocal.UserSettingsProfiles;
            dataLayout.ShowCustomization += DataLayoutControl1_ShowCustomization;
            dataLayout.HideCustomization += DataLayoutControl1_HideCustomization;
        }
        CultureInfo _ci;
        ComponentResourceManager _resource;
       
        private void DataLayoutControl1_HideCustomization(object sender, EventArgs e)
        {
            ClsPath.SaveCustomContol(this.dataLayout, this.Name);
        }
        private void DataLayoutControl1_ShowCustomization(object sender, EventArgs e)
        {
            ((DataLayoutControl)sender).CustomizationForm.Text = "تغيير التصميم";
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
        public override void Save()
        {
            if (userSettingsProfileBindingSource.Current != null)
            {
                if (IsNew)
                    dbLocal.GetTable(userSettingsProfileBindingSource.Current.GetType()).InsertOnSubmit(userSettingsProfileBindingSource.Current);
                dbLocal.SubmitChanges();
                Session.GetDataUserSettingsProfile(dbLocal);
                TextReadOnly(true);
            }
            EnableOrDisyble(true);
            TextReadOnly(true);
            base.Save();
        }
        MyFunaction myfunction = new MyFunaction();
        public virtual void New()
        {
            EnableOrDisyble(false);
            TextReadOnly(false);
            IsNew = true;
            InitBraAndUserForNew();
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
        public void InitBraAndUserForNew()
        {
            foreach (var item in this.Controls)
            {
                if (item is DataLayoutControl bbi)
                {
                    foreach (var item1 in bbi.Controls)
                    {
                        if (item1 is BaseEdit txt)
                        {
                            if (txt.Name == "CurrencieID")
                                txt.EditValue = 1;
                            else if (txt.Name == "BranchID")
                                txt.EditValue = Session.CurrentBranch.ID;
                            else if (txt.Name == "UserID")
                                txt.EditValue = Session.CurrentUser.ID;
                            else if (txt.Name == "EnterTime")
                                txt.EditValue = DateTime.Now;
                        }
                    }
                    return;
                }
            }
        }
        public virtual void Delete()
        {
            //if (ClsXtraMssgBox.ShowWarningYesNo("هل انت متاكد من حذف السجل؟")==DialogResult.Yes)
            if (userSettingsProfileBindingSource.Current != null)
            {
                dbLocal.GetTable(userSettingsProfileBindingSource.Current.GetType()).DeleteOnSubmit(userSettingsProfileBindingSource.Current);
                dbLocal.SubmitChanges();
                    RefreshData();
            }
        }
        private GridControl GetGridControl()
        {
            foreach (var item in this.Controls)
            {
                if (item is DataLayoutControl bbi)
                {
                    foreach (var item1 in bbi.Controls)
                        if (item1 is GridControl Grid)
                            return Grid;
                    return null;
                }
            }
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
            TextReadOnly(false);
        }
        public virtual void RefreshData()
        {
            TextReadOnly(true);
            dbLocal = new PosDBDataContext(Program.ConnectionString);
            if(userSettingsProfileBindingSource.Current!=null)
            userSettingsProfileBindingSource.DataSource = dbLocal.GetTable(userSettingsProfileBindingSource.Current.GetType());
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
      
        public void EnableOrDisyble(bool state)
        {
            btnAddNew.Enabled = state;
            btnDelete.Enabled = state;
            btnUpdate.Enabled = state;
            btnPrint.Enabled = state;

            btnSave.Enabled = !state;
            //btnSaveAndClose.Enabled = !state;
            //btnSaveAndNew.Enabled = !state;
            btnReset.Enabled = !state;
        }

     
        private void btnSaveAndNew_Click(object sender, EventArgs e)
        {
            btnSave.PerformClick();
            btnAddNew.PerformClick();
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            btnSave.PerformClick();
            btnClose.PerformClick();
        }
        private void UC_Master_Load(object sender, EventArgs e)
        {
            GetPropertyControl();
            //await MyTools.MydataLayoutControl(dataLayout, bindingNavigator11, TableName);
            //this.Controls.Add(dataLayout);
            ClsPath.ReLodeCustomContol(this.dataLayout, this.Name);
            //dataLayout.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            TextReadOnly(true);
            //RefreshData();
            btnAddNew.Click += BtnAddNew_Click;
            btnDelete.Click += BtnDelete_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnPrint.Click += BtnPrint_Click;
            btnRefresh.Click += BtnRefresh_Click;
            btnReset.Click += BtnReset_Click;
            this.KeyDown += UC_Master_KeyDown;
            if (!Program.My_Setting.LangEng)
            {
                this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                dataLayout.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            }
        }
        public void GetPropertyControl()
        {
            UserSettingsProfile ins;
            BaseEdit edit = null;
            foreach (GetColumnForTableResult propertyValue in Session.ColNameForTable.ToList())
            {
                LayoutControlItem layoutControlItem = (LayoutControlItem)this.dataLayout.Items.Where(x => x.Name == "ItemFor"+propertyValue.ColumnName).FirstOrDefault();
                if (layoutControlItem == null) continue;  
                    layoutControlItem.Text =Program.My_Setting.LangEng? layoutControlItem.Text: propertyValue.Caption;
                edit = (BaseEdit)layoutControlItem.Control;
                if(edit is ToggleSwitch)
                {
                    ((ToggleSwitch)edit).Properties.OnText = Program.My_Setting.LangEng ? "On" : "نعم";
                    ((ToggleSwitch)edit).Properties.OffText = Program.My_Setting.LangEng ? "Off" : "لا";
                }
                switch (propertyValue.ColumnName)
                {
                    case nameof(ins.DefaultStore):
                        ((LookUpEdit)edit).IntializeData(Session.Stores);
                        break;
                    case nameof(ins.DefaultBox):
                        ((LookUpEdit)edit).IntializeData(Session.Boxes);
                        break;
                    case nameof(ins.DefaultCustomer):
                        ((LookUpEdit)edit).IntializeData(Session.Customers);
                        break;
                    case nameof(ins.DefaultBank):
                        ((LookUpEdit)edit).IntializeData(Session.Banks);
                        break;
                    case nameof(ins.DefaultBranch):
                        ((LookUpEdit)edit).IntializeData(Session.Branches);
                        break;
                    case nameof(ins.DefaultSalesPrinterName):
                        ((LookUpEdit)edit).Properties.DataSource = MyTools.GetListPrinter;
                        break;
                    case nameof(ins.DefaultPayMethodInSales):
                        foreach (var item in MyTools.PayMethodsList)
                            ((RadioGroup)edit).Properties.Items.Add(new RadioGroupItem() { Description = item.Name, Value = item.ID });
                        ((RadioGroup)edit).AutoSizeInLayoutControl = true;
                        break;
                    case nameof(ins.ReadMode):
                        foreach (var item in MyTools.ReadModeList)
                            ((RadioGroup)edit).Properties.Items.Add(new RadioGroupItem() { Description = item.Name, Value = item.ID });
                        ((RadioGroup)edit).AutoSizeInLayoutControl = true;
                        break;
                    case nameof(ins.InvoicePrintMode):
                        foreach (var item in MyTools.PrintModeList)
                            ((RadioGroup)edit).Properties.Items.Add(new RadioGroupItem() { Description = item.Name, Value = item.ID });
                        ((RadioGroup)edit).AutoSizeInLayoutControl = true;
                        break;
                    case nameof(ins.DefaultPrintPaper):
                        foreach (var item in MyTools.PrintPaperList)
                            ((RadioGroup)edit).Properties.Items.Add(new RadioGroupItem() { Description = item.Name, Value = item.ID });
                        ((RadioGroup)edit).AutoSizeInLayoutControl = true;
                        break;
                    case nameof(ins.defaultSalePriceFloar):
                    case nameof(ins.tsDefaultSalePriceAndBuy):
                        foreach (var item in MyTools.WarningLevelsList)
                            ((RadioGroup)edit).Properties.Items.Add(new RadioGroupItem() { Description = item.Name, Value = item.ID });
                        ((RadioGroup)edit).AutoSizeInLayoutControl = true;
                        break;
                    case nameof(ins.ValueCodeLength):
                    case nameof(ins.BarcodeLength):
                    case nameof(ins.ProductCodeLength):
                        ((SpinEdit)edit).Properties.Increment = 1;
                        ((SpinEdit)edit).Properties.MaxValue = 10000;
                        break;
                    case nameof(ins.DivideValueBy):
                        ((ComboBoxEdit)edit).Properties.Items.AddRange(new int[] { 1, 10, 100, 1000, 10000 });
                        break;
                }
            }
            //    switch (propertyValue.ColumnName)
            //    {

                  
            //            switch (propName)
            //            {
                            
            //                case nameof(ins.ReadMode):
            //                    edit = new RadioGroup();
            //                    foreach (var item in MyTools.ReadModeList)
            //                        ((RadioGroup)edit).Properties.Items.Add(new RadioGroupItem() { Description = item.Name, Value = item.ID });
            //                    ((RadioGroup)edit).AutoSizeInLayoutControl = true;
            //                    break;
            //                case nameof(ins.InvoicePrintMode):
            //                    edit = new RadioGroup();
            //                    foreach (var item in MyTools.PrintModeList)
            //                        ((RadioGroup)edit).Properties.Items.Add(new RadioGroupItem() { Description = item.Name, Value = item.ID });
            //                    ((RadioGroup)edit).AutoSizeInLayoutControl = true;
            //                    break;
            //                case nameof(ins.DefaultPrintPaper):
            //                    edit = new RadioGroup();
            //                    foreach (var item in MyTools.PrintPaperList)
            //                        ((RadioGroup)edit).Properties.Items.Add(new RadioGroupItem() { Description = item.Name, Value = item.ID });
            //                    ((RadioGroup)edit).AutoSizeInLayoutControl = true;
            //                    break;
            //                case nameof(ins.defaultSalePriceFloar):
            //                case nameof(ins.tsDefaultSalePriceAndBuy):
            //                    edit = new RadioGroup();
            //                    foreach (var item in MyTools.WarningLevelsList)
            //                        ((RadioGroup)edit).Properties.Items.Add(new RadioGroupItem() { Description = item.Name, Value = item.ID });
            //                    ((RadioGroup)edit).AutoSizeInLayoutControl = true;
            //                    break;
            //                case nameof(ins.ValueCodeLength):
            //                case nameof(ins.BarcodeLength):
            //                case nameof(ins.ProductCodeLength):
            //                    edit = new SpinEdit();
            //                    ((SpinEdit)edit).Properties.Increment = 1;
            //                    ((SpinEdit)edit).Properties.MaxValue = 10000;
            //                    break;
            //                case nameof(ins.DivideValueBy):
            //                    edit = new ComboBoxEdit();
            //                    ((ComboBoxEdit)edit).Properties.Items.AddRange(new int[] { 1, 10, 100, 1000, 10000 });
            //                    break;
            //            }
            //            break;
            //        case 62:
            //            switch (propName)
            //            {
            //                case nameof(ins.MaxDiscountInInvoice):
            //                case nameof(ins.taxDefault):
            //                    edit = new SpinEdit();
            //                    ((SpinEdit)edit).Properties.Increment = 0.01m;
            //                    ((SpinEdit)edit).Properties.Mask.EditMask = "p";
            //                    ((SpinEdit)edit).Properties.Mask.UseMaskAsDisplayFormat = true;
            //                    ((SpinEdit)edit).Properties.MaxValue = 1;
            //                    break;
            //            }
            //            break;
            //        default:
            //            edit = new TextEdit();
            //            break;
            //    }
            //    if (edit == null) edit = new TextEdit();
            //    if (edit != null)
            //    {
            //        edit.Name = propName;
            //        edit.Properties.NullText = "";
            //        //edit.EditValue = propertyValue;
            //    }
            //}
           
            //return edit;
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

        private void UC_Master_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F1)
            //    btnSaveAndClose.PerformClick();
            //if (e.KeyCode == Keys.F2)
            //    btnSaveAndNew.PerformClick();
            if (e.KeyCode == Keys.F3)
                btnSave.PerformClick();
            if (e.KeyCode == Keys.F5)
                btnReset.PerformClick();
            if (e.KeyCode == Keys.F5)
                btnRefresh.PerformClick();
            if (e.KeyCode == Keys.F2)
                btnAddNew.PerformClick();
            if (e.KeyCode == Keys.F4)
                btnUpdate.PerformClick();
            if (e.KeyCode == Keys.F7)
                btnPrint.PerformClick();
            if (e.KeyCode == Keys.F6)
                btnDelete.PerformClick();
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
