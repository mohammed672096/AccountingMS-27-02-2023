using DevExpress.Charts.Native;
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
using AccountingMS.Classes;
using AccountingMS.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Resources.ResXFileRef;
using AccountingMS.Classe;

namespace AccountingMS
{
    public partial class formSupplyMain : DevExpress.XtraBars.ToolbarForm.ToolbarForm
    {
        ComponentFlyoutDialog flydDialog = new ComponentFlyoutDialog();
        public SupplyType supplyType;

        private void formSupplyMain_Load(object sender, EventArgs e)
        {
            InitText();
            flydDialog.WaitForm(this, 1);

            SetUserControl(tblSupplyMain, subObj);
          
            flydDialog.WaitForm(this, 0);
        }

        private void InitText()
        {
            this.Text = ClsSupplyStatus.GetString((byte)this.supplyType);
            if(MySetting.GetPrivateSetting.LangEng)
            xtraTabControl1.CustomHeaderButtons[0].Caption = "Add New (F1)";
        }
        public Form parent1;
        tblSupplyMain tblSupplyMain;
        List<tblSupplySub> subObj;
        public formSupplyMain(tblSupplyMain _supplyMain, List<tblSupplySub> _subObj, SupplyType supplyType,Form _parent)
        {
            tblSupplyMain = _supplyMain;
            subObj = _subObj;
            this.supplyType = supplyType;
            InitializeComponent();
            parent1 = _parent;
            xtraTabControl1.CloseButtonClick += XtraTabControl1_CloseButtonClick;
            xtraTabControl1.ControlAdded += XtraTabControl1_ControlRemoved;
            xtraTabControl1.ControlRemoved += XtraTabControl1_ControlRemoved;
            InitFormSize();
            SetRTL();
            xtraTabControl1.CustomHeaderButtonClick += XtraTabControl1_CustomHeaderButtonClick;
            this.Shown += FormSupplyMain_Shown;
        }

        private void FormSupplyMain_Shown(object sender, EventArgs e)
        {
            //SetFont();
            if (AddSaleInvoice!=null)
                if (AddSaleInvoice.textEditBarcodeNo.Enabled)
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
        MyFunaction myFunaction = new MyFunaction();
        private void barButFont_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                using (FontDialog dialog = new FontDialog())
                {
                    Font fontConverter = myFunaction.SalesFontConverter();
                    if (fontConverter != null)
                        dialog.Font = fontConverter;
                    else
                        dialog.Font = WindowsFormsSettings.DefaultFont;
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        MySetting.GetPrivateSetting.SystemFontSales = converter.ConvertToString(dialog.Font);
                        MySetting.WriterSettingXml();
                    }
                    if (AddSaleInvoice != null)
                        AddSaleInvoice.SetFontAndInitFlyDialogPrdSrch();
                }
            }
            catch (Exception ex)
            {
                ClsXtraMssgBox.ShowError(ex.Message);
                return;
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
            //ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;
            //(arg.Page as XtraTabPage).Dispose();
        }
        public  UC_AddSaleInvoice AddSaleInvoice;
        XtraTabPage tabpage;
        public void SetUserControl(tblSupplyMain tblSupplyMain=null, IEnumerable<tblSupplySub> subObj=null)
        {
            AddSaleInvoice = new UC_AddSaleInvoice(tblSupplyMain, subObj, this.supplyType);
            tabpage = new XtraTabPage() { Text = this.Text };
            if (AddSaleInvoice == null) return;
            tabpage.Controls.Add(AddSaleInvoice);
            AddSaleInvoice.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(tabpage);
            xtraTabControl1.SelectedTabPage = tabpage;
           
        }
        private void formSupplyRcptMain_KeyDown(object sender, KeyEventArgs e)
        {
            AddSaleInvoice = ((UC_AddSaleInvoice)xtraTabControl1.SelectedTabPage.Controls[0]);
            if (!AddSaleInvoice.isNew)
            {
                if (e.Control && e.Shift && e.Alt && e.KeyCode == Keys.U)
                    AddSaleInvoice.EnableOrDisyble(true);
                if (e.KeyCode == Keys.F1)
                    SetUserControl();
                return;
            }
            switch (e.KeyCode)
            {
                case Keys.F1:
                    SetUserControl();
                    break;
                case Keys.F2:
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
                case Keys.F6:
                    AddSaleInvoice.btnEditQuantity.PerformClick();
                    break;
                case Keys.F7:
                    AddSaleInvoice.btnEditPrice.PerformClick();
                    break;
                case Keys.F8:
                    AddSaleInvoice.btnPrdPrice.PerformClick();
                    break;
                case Keys.F9:
                    AddSaleInvoice.btnAddProduct.PerformClick();
                    break;
                case Keys.F10 when(!AddSaleInvoice.isRtrn):
                    AddSaleInvoice.bbiPriceOffer.PerformClick();
                    break; 
                case Keys.F11:
                    AddSaleInvoice.btnPaidCreditShortcut.PerformClick();
                    break;
                case Keys.F12:
                    AddSaleInvoice.btnSaveAndNewNoPrint.PerformClick();
                    break;
                default:
                    break;
            }
            if (e.Control && e.Alt && e.KeyCode == Keys.D)
                AddSaleInvoice.dataLayConMain.AllowCustomization = true;
          if (e.Control && e.KeyCode == Keys.F && !AddSaleInvoice.gridControl.ContainsFocus && (this.supplyType == SupplyType.Sales|| this.supplyType == SupplyType.Purchase))
                    AddSaleInvoice.ShowPrdSearchPanel();
        }
        public void SetDialogResultOK()
        {
            DialogResult = DialogResult.OK;
        }
        private void InitFormSize()
        {
            if (MySetting.GetPrivateSetting.formSupplyWindState == FormWindowState.Maximized || MySetting.GetPrivateSetting.formSupplyMainW == 0 || MySetting.GetPrivateSetting.formSupplyMainH == 0) return;
            this.Width = MySetting.GetPrivateSetting.formSupplyMainW;
            this.Height = MySetting.GetPrivateSetting.formSupplyMainH;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void formSupplyMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            MySetting.GetPrivateSetting.formSupplyMainW = this.Width;
            MySetting.GetPrivateSetting.formSupplyMainH = this.Height;
            MySetting.GetPrivateSetting.formSupplyWindState = this.WindowState;
            Console.WriteLine(this.Height);
            MySetting.WriterSettingXml();
        }
        private void SetRTL()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;
            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = false;
        }
    }
}