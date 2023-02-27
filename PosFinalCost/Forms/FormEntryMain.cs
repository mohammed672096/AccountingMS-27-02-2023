using DevExpress.Charts.Native;
using DevExpress.DashboardCommon.Viewer;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using PosFinalCost.Classe;
using PosFinalCost.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Resources.ResXFileRef;

namespace PosFinalCost
{
    public partial class FormEntryMain : DevExpress.XtraBars.ToolbarForm.ToolbarForm
    {
        ComponentFlyoutDialog flydDialog = new ComponentFlyoutDialog();
        private SupplyType supplyType;
        private EntryType entryType;

        private void formSupplyMain_Load(object sender, EventArgs e)
        {
          
            flydDialog.WaitForm(this, 1);
            SetUserControl(supplyMain, subObj);
            //SetFont();
            flydDialog.WaitForm(this, 0);
        }

       
        public Form parent1;
        object supplyMain;
        object subObj;
        UserControls GetUserControls;
        public FormEntryMain(object _supplyMain,object _subObj,UserControls userControls,Form _parent)
        {
            supplyMain = _supplyMain;
            subObj = _subObj;
            GetUserControls = userControls;
            InitializeComponent();
            parent1 = _parent;
            InitEvents();
        }
        private void InitEvents()
        {
            xtraTabControl1.CloseButtonClick += XtraTabControl1_CloseButtonClick;
            xtraTabControl1.ControlAdded += XtraTabControl1_ControlRemoved;
            xtraTabControl1.ControlRemoved += XtraTabControl1_ControlRemoved;
            if (GetUserControls != UserControls.ExpiredProducts)
                InitFormSize();
            SetRTL();
            xtraTabControl1.CustomHeaderButtonClick += XtraTabControl1_CustomHeaderButtonClick;
            this.Shown += FormSupplyMain_Shown;
        }
        private void FormSupplyMain_Shown(object sender, EventArgs e)
        {
            if ((this.GetUserControls == UserControls.Sale|| this.GetUserControls == UserControls.ExpiredProducts) && AddSaleInvoice!=null)
                AddSaleInvoice.textEditBarcodeNo.Focus();
        }

        private void XtraTabControl1_CustomHeaderButtonClick(object sender, CustomHeaderButtonEventArgs e)
        {
            SetUserControl();
        }
        private void BtnCalculator_ItemClick(object sender, ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }
        private void barButFont_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FontDialog dialog = new FontDialog())
            {
                Font fontConverter = (Font)converter.ConvertFromString(Program.My_Setting.SystemFontSale);
                if(fontConverter != null)   
                dialog.Font = fontConverter;
                else
                    dialog.Font = WindowsFormsSettings.DefaultFont;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Program.My_Setting.SystemFontSale = converter.ConvertToString(dialog.Font);
                    MySetting.ReadWriterSettingXml();
                }
                if (AddSaleInvoice != null)
                    AddSaleInvoice.SetFont();
            }
        }
        TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
        private void XtraTabControl1_ControlRemoved(object sender, ControlEventArgs e)
        {
            for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
                xtraTabControl1.TabPages[i].Text = this.Text + (i+ 1).ToString();
        }
        private void XtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            AddSaleInvoice.btnClose.PerformClick();
        }
        dynamic AddSaleInvoice;
        XtraTabPage tabpage;
        public void SetUserControl(object supplyMain =null,object  subObj=null)
        {
           if (GetUserControls == UserControls.Sale|| GetUserControls == UserControls.SaleRtrn)
            {
                this.supplyType = GetUserControls == UserControls.Sale? SupplyType.Sales: SupplyType.SalesRtrn;
                this.Text = ClsSupplyStatus.GetString((byte)this.supplyType, false, true);
                AddSaleInvoice = new UC_AddSaleInvoice((SupplyMain)supplyMain,(IEnumerable<SupplySub>)subObj, this.supplyType);
            }
           else if (GetUserControls == UserControls.EntryRcpt || GetUserControls == UserControls.EntryVoucer)
            {
                this.entryType = GetUserControls == UserControls.EntryRcpt ? EntryType.EntryReceipt : EntryType.EntryVoucher;
                this.Text =MyTools.EntryTypesList.FirstOrDefault(x=> ((byte)x.ID) ==(byte)this.entryType).Name; 
                AddSaleInvoice = new UC_AddEntry((EntryMain)supplyMain, (IEnumerable<EntrySub>)subObj, this.entryType);
            }
            else if (GetUserControls == UserControls.ExpiredProducts)
            {
                this.Text = "الاصناف التالفة";
                AddSaleInvoice = new UC_PrdExpirate((PrdExpirateMain)supplyMain, (IEnumerable<PrdExpirateDetail>)subObj);
            }
            tabpage = new XtraTabPage() { Text = this.Text };
            if (AddSaleInvoice == null) return;
            tabpage.Controls.Add(AddSaleInvoice);
            AddSaleInvoice.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(tabpage);
            xtraTabControl1.SelectedTabPage = tabpage;
           
        }
        private void formSupplyRcptMain_KeyDown(object sender, KeyEventArgs e)
        {
            AddSaleInvoice = xtraTabControl1.SelectedTabPage.Controls[0];
            if (!AddSaleInvoice.isNew&& !AddSaleInvoice.bindingNavigator11.Enabled)
            {
                if (e.Control && e.Shift && e.Alt && e.KeyCode == Keys.U)
                    AddSaleInvoice.EnabledORDisabledUpdate(true);
                if (e.KeyCode == Keys.F1)
                    SetUserControl();
                return;
            }
            switch (e.KeyCode)
            {
                case Keys.F1:
                    SetUserControl();
                    break;
                case Keys.F2 when(GetUserControls == UserControls.Sale || GetUserControls == UserControls.SaleRtrn):
                    AddSaleInvoice.btnSetCashInvoice.PerformClick();
                    break;
                case Keys.F3:
                    AddSaleInvoice.btnSaveAndNew.PerformClick();
                    break;
                case Keys.F4:
                    AddSaleInvoice.btnSave.PerformClick();
                    break;
                case Keys.F5:
                    AddSaleInvoice.btnReset.PerformClick();
                    break;
                case Keys.F6 when (GetUserControls == UserControls.Sale || GetUserControls == UserControls.SaleRtrn|| GetUserControls == UserControls.ExpiredProducts):
                    AddSaleInvoice.btnEditQuantity.PerformClick();
                    break;
                case Keys.F7 when (GetUserControls == UserControls.Sale || GetUserControls == UserControls.SaleRtrn):
                    AddSaleInvoice.btnEditPrice.PerformClick();
                    break;
                case Keys.F8 when (GetUserControls == UserControls.Sale || GetUserControls == UserControls.SaleRtrn):
                    AddSaleInvoice.btnPrdPrice.PerformClick();
                    break;
                case Keys.F11 when (GetUserControls == UserControls.Sale || GetUserControls == UserControls.SaleRtrn):
                    AddSaleInvoice.btnPaidCreditShortcut.PerformClick();
                    break;
                case Keys.F12 when(GetUserControls != UserControls.ExpiredProducts):
                    AddSaleInvoice?.btnSaveAndNewNoPrint?.PerformClick();
                    break;
                default:
                    break;
            }
            if (e.Control && e.Alt && e.KeyCode == Keys.D)
                AddSaleInvoice.dataLayConMain.AllowCustomization = true;
            if (GetUserControls == UserControls.Sale || GetUserControls == UserControls.SaleRtrn)
                if (e.Control && e.KeyCode == Keys.F && !AddSaleInvoice.gridControl.ContainsFocus && this.supplyType != SupplyType.SalesRtrn)
                AddSaleInvoice.ShowPrdSearchPanel();
        }
        public void SetDialogResultOK()
        {
            DialogResult = DialogResult.OK;
        }
        private void InitFormSize()
        {
            if (Program.My_Setting.formSupplyWindState == FormWindowState.Maximized || Program.My_Setting.formSupplyMainW == 0 || Program.My_Setting.formSupplyMainH == 0) return;
            this.Width = Program.My_Setting.formSupplyMainW;
            this.Height = Program.My_Setting.formSupplyMainH;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void formSupplyMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.My_Setting.formSupplyMainW = this.Width;
            Program.My_Setting.formSupplyMainH = this.Height;
            Program.My_Setting.formSupplyWindState = this.WindowState;
            Console.WriteLine(this.Height);
            MySetting.ReadWriterSettingXml();
        }
        private void SetRTL()
        {
            if (!Program.My_Setting.LangEng) return;
            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = false;
        }
    }
}