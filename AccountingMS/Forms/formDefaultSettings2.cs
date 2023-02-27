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
using DevExpress.Utils;
using System.Threading;
using System.Globalization;
using DevExpress.XtraPrinting.Preview;
using System.Drawing.Printing;
using System.Drawing;
using DevExpress.XtraLayout.Utils;

namespace accounting_1._0
{
    public partial class formDefaultSettings2 : XtraForm
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblProductColor clsTbPrdColor = new ClsTblProductColor();

        private long boxAccNo;
        private PrinterSettings printerSettings;

        public formDefaultSettings2()
        {
            SetLanguage();
            InitializeComponent();
            SetRTL();
            InitData();
            InitPrdColorData();
            InitDefaultData();

            teDefaultBox.EditValueChanged += TeDefaultBox_EditValueChanged;
            colorPickEdit1.EditValueChanged += ColorPickEdit1_EditValueChanged;
            colorPickEdit2.EditValueChanged += ColorPickEdit2_EditValueChanged;
            colorPickEdit3.EditValueChanged += ColorPickEdit3_EditValueChanged;
        }

        private void InitData()
        {
            this.LookAndFeel.TouchUIMode = DefaultBoolean.True;
            this.LookAndFeel.TouchScaleFactor = 1.5F;
            tblAccountBoxBindingSource.DataSource = new ClsTblBox().GetTblBoxList;
        }

        private void InitDefaultData()
        {
            this.boxAccNo = Properties.Settings.Default.defaultBox;
            teDefaultBox.EditValue = Properties.Settings.Default.defaultBox;
            teDefaultPrintPaper.EditValue = Properties.Settings.Default.printA4;
            teDefaultShowPrintMssg.EditValue = Properties.Settings.Default.showPrintMssg;
            teDefaultShowPrdQtyMssg.EditValue = Properties.Settings.Default.showPrdQtyMssg;
            tsDefaultSalePriceFloar.EditValue = Properties.Settings.Default.defaultSalePriceFloar;
            this.printerSettings = ClsPrinterSettings.RetriveSettingFromString(Properties.Settings.Default.defaultPrinterSettings);
        }

        private void TeDefaultBox_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor.EditValue == null) return;

            this.boxAccNo = Convert.ToInt64(editor.GetColumnValue("boxAccNo"));
        }

        private void btnDefaultPrinter_Click(object sender, EventArgs e)
        {
            PrintEditorForm form = new PrintEditorForm();
            (form.AcceptButton as SimpleButton).Text = "حفظ";
            form.Document = new PrintDocument() { PrinterSettings = this.printerSettings };
            if (form.ShowDialog() == DialogResult.OK)
                Properties.Settings.Default.defaultPrinterSettings = ClsPrinterSettings.ConvertSettingToString(form.Document.PrinterSettings);
        }

        private void windowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            switch(e.Button.Properties.Tag)
            {
                case "Save":
                    SaveDefaults();
                    break;
                case "Close":
                    this.Close();
                    break;
            }
        }

        private void SaveDefaults()
        {
            if (!SavePrdColor()) return;
            Properties.Settings.Default.defaultBox = this.boxAccNo;
            Properties.Settings.Default.printA4 = (byte)teDefaultPrintPaper.EditValue;
            Properties.Settings.Default.showPrintMssg = (bool)teDefaultShowPrintMssg.EditValue;
            Properties.Settings.Default.showPrdQtyMssg = (bool)teDefaultShowPrdQtyMssg.EditValue;
            Properties.Settings.Default.defaultSalePriceFloar = (bool)tsDefaultSalePriceFloar.EditValue;
            Properties.Settings.Default.Save();
            InitPrdColorData();

            string mssg = (!Properties.Settings.Default.langEng) ? "الإعدادات الإفتراضيه" : "Default Settings";
            flyDialog.ShowDialogForm(this, mssg);
        }

        private void SetLanguage()
        {
            if (!Properties.Settings.Default.langEng)
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
            else
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
        }

        private void SetRTL()
        {
            if (!Properties.Settings.Default.langEng) return;

            layoutControl1.BeginUpdate();
            layoutControl1.RightToLeft = RightToLeft.No;
            layoutControl1.OptionsView.RightToLeftMirroringApplied = false;
            layoutControl1.EndUpdate();
        }

        private void formDefaultSettings2_Load(object sender, EventArgs e)
        {
            ItemForcolHtml1.Visibility = LayoutVisibility.Never;
            ItemForcolHtml2.Visibility = LayoutVisibility.Never;
            ItemForcolHtml3.Visibility = LayoutVisibility.Never;
        }
    }
}