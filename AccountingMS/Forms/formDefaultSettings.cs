using AccountingMS.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraPrinting.Preview;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formDefaultSettings : XtraForm
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblBranch clsTbBranch;
        ClsTblUserBranch clsTbUsrBrnch;
        ClsTblAccount clsTbAccount;
        ClsTblDefaultAccount clsTbDefaultAccount;
        ClsTblBox clsTbBox;
        ClsTblBank clsTbBank;
        ClsTblStore clsTbStore;
        ClsTblProductColor clsTbPrdColor;
        ClsTblInvType clsTbInvType;

        private long boxAccNo;
        private PrinterSettings printerSettings = new PrinterSettings();
        private PrinterSettings ordersPrinterSettings = new PrinterSettings();
        private PrinterSettings barocdePrinterSettings = new PrinterSettings();

        public formDefaultSettings()
        {
            SetLanguage();
            InitializeComponent();
            InitLookAndFeel();
            SetRTL();

            this.Load += FormDefaultSettings_Load;
        }

        private async void FormDefaultSettings_Load(object sender, EventArgs e)
        {
            await InitObjectsAsync();
            InitData();
            InitPrdColorData();
            InitDefaultData();
            InitDefaultAccountsData();
            InitBarcodeWeightData();
            InitBranchData();
            InitInvData();
            btnSupplyCashierCustomRprt.Click += BtnSupplyCashierCustomRprt_Click;
            teSupplyCashierCustomRprt.EditValueChanging += TeSupplyCashierCustomRprt_EditValueChanging;
            colorPickEdit1.EditValueChanged += ColorPickEdit1_EditValueChanged;
            colorPickEdit2.EditValueChanged += ColorPickEdit2_EditValueChanged;
            colorPickEdit3.EditValueChanged += ColorPickEdit3_EditValueChanged;
            //teDefaultBox.EditValueChanged += TeDefaultBox_EditValueChanged;
            btnSupplyA4CustomRprt.Click += BtnSupplyA4CustomRprt_Click;
            teSupplyA4CustomRprt.EditValueChanging += TeSupplyA4CustomRprt_EditValueChanging;
            teSupplyRetuA4CustomRprt.EditValueChanging += TeSupplyA4CustomRprt_EditValueChanging;
            teOrderA4CustomRprt.EditValueChanging += TeSupplyA4CustomRprt_EditValueChanging;
            textEditBranch.EditValueChanged += TextEditBranch_EditValueChanged;
            textEditBranch.EditValueChanging += TextEditBranch_EditValueChanging;
            txRprtSupplyCustomType.EditValueChanged += TxRprtSupplyCustomType_EditValueChanged;
           
            tsDefaultSalePriceAndBuy.Properties.Items.AddRange(WarningLevelsList);
            tsDefaultSalePriceAndBuy.Properties.Columns = 3;
            tsDefaultSalePriceAndBuy.AutoSizeInLayoutControl = true;
            teReportVocherCustom.EditValueChanging += TeReportVocherCustom_EditValueChanging;
            teReportReciptCustom.EditValueChanging += TeReportReciptCustom_EditValueChanging;
            teReportEntryCustom.EditValueChanging += TeReportEntryCustom_EditValueChanging;
        }

        private void TeReportEntryCustom_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (Convert.ToBoolean(e.NewValue) && !File.Exists(ClsPath.ReportDailyEntryCustomFile))
            {
                MessIfReportCustomNotFound();
                 e.NewValue = false;
                ShowReportEndUserForm(ReportCustomType.Entry);
            }
        }
        void MessIfReportCustomNotFound()=> XtraMessageBox.Show((!Program.My_Setting.LangEng) ? "عذرا يجب إنشاء التقرير أولاً" : "Sorry you must create the report first!");
        private void TeReportReciptCustom_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (Convert.ToBoolean(e.NewValue) && !File.Exists(ClsPath.ReportEntryReciptCustomFile))
            {
                MessIfReportCustomNotFound(); 
                e.NewValue = false;
                ShowReportEndUserForm(ReportCustomType.EntryReceipt);
            }
        }

        private void TeReportVocherCustom_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (Convert.ToBoolean(e.NewValue) && !File.Exists(ClsPath.ReportEntryVocherCustomFile))
            {
                MessIfReportCustomNotFound();
                e.NewValue = false;
                ShowReportEndUserForm(ReportCustomType.EntryVoucher);
            }
        }

        public  RadioGroupItem[] WarningLevelsList ={
                new RadioGroupItem() { Value = (short)WarningLevels.DoNotEnteript  , Description  =(Program.My_Setting.LangEng)?"Permissible":"مسموح" },
                new RadioGroupItem() { Value = (short)WarningLevels.ShowWarning  , Description  =(Program.My_Setting.LangEng)?"Warning":"تحذير" },
                new RadioGroupItem() { Value = (short)WarningLevels.Prevent  , Description  =(Program.My_Setting.LangEng)?"Prevent":"منع" },

        };
       
        private async Task InitObjectsAsync()
        {
            flyDialog.WaitForm(this, 1);
            IList<Task> taskList = new List<Task>();

            taskList.Add(Task.Run(() => this.clsTbBranch = new ClsTblBranch()));
            taskList.Add(Task.Run(() => this.clsTbUsrBrnch = new ClsTblUserBranch()));
            taskList.Add(Task.Run(() => this.clsTbAccount = new ClsTblAccount()));
            taskList.Add(Task.Run(() => this.clsTbDefaultAccount = new ClsTblDefaultAccount()));
            taskList.Add(Task.Run(() => this.clsTbBox = new ClsTblBox()));
            taskList.Add(Task.Run(() => this.clsTbBank = new ClsTblBank()));
            taskList.Add(Task.Run(() => this.clsTbStore = new ClsTblStore()));
            taskList.Add(Task.Run(() => this.clsTbPrdColor = new ClsTblProductColor()));
            taskList.Add(Task.Run(() => this.clsTbInvType = new ClsTblInvType()));

            await Task.WhenAll(taskList);
            flyDialog.WaitForm(this, 0);
        }

        private void InitLookAndFeel()
        {
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.LookAndFeel.SetSkinStyle("The Bezier", "Twenty");
            this.LookAndFeel.TouchUIMode = DefaultBoolean.True;
            this.LookAndFeel.TouchScaleFactor = 1.5F;
        }

        private void InitBranchData()
        {
            textEditBranch.EditValue = ClsBranchId.BranchId;
            layoutControlGroupBranch.Text += ClsBranchId.BranchName;
        }

        private void ShowReportEndUserForm(ReportCustomType CustomType)
        {
            flyDialog.WaitForm(this, 1);
            using (ReportEndUserForm reportEndUserForm = new ReportEndUserForm(CustomType))
            {
                flyDialog.WaitForm(this, 0);
                reportEndUserForm.ShowDialog();
            }
        }
        private void TextEditBranch_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;

            var brnName = this.clsTbBranch.GetBranchName(Convert.ToInt16(e.NewValue));

            if (!ValidateUsrBranchRole(Convert.ToInt16(e.NewValue)))
            {
                e.Cancel = true;
                return;
            }

            e.Cancel = !ConfirmChangeBranch(brnName);
        }

        private void TextEditBranch_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;

            var tbBranch = editor.GetSelectedDataRow() as tblBranch;

            SetTmpProperties(tbBranch);

            this.Close();
            ClsForceApplicationExit.ForceExit = true;
            Application.Restart();
        }

        private void TxRprtSupplyCustomType_EditValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.rprtSupplyCustomType = (byte)txRprtSupplyCustomType.EditValue;
        }

        private void SetTmpProperties(tblBranch tbBranch)
        {
            Properties.Settings.Default.restartForm = true;
            Properties.Settings.Default.tmpUsrId = ClsUserId.UserId;
            Properties.Settings.Default.tmpRoleId = ClsUserId.RoleId;
            Properties.Settings.Default.tmpUsrName = ClsUserId.UserName;
            Properties.Settings.Default.tmpBrnId = tbBranch.brnId;
            Properties.Settings.Default.tmpBrnName = tbBranch.brnName;
            Properties.Settings.Default.tmpFyId = (short)ClsFinancialYear.FyId;
            Properties.Settings.Default.tmpFyDtStart = ClsFinancialYear.FyDtStart;
            Properties.Settings.Default.tmpFyDtEnd = ClsFinancialYear.FyDtEnd;
            Properties.Settings.Default.Save(); 
        }

        private bool ValidateUsrBranchRole(short brnId)
        {
            if (ClsUserId.UserId == 1) return true;
            bool isValid = this.clsTbUsrBrnch.IsUserBranchFound(ClsUserId.UserId, brnId);

            if (!isValid)
                ClsXtraMssgBox.ShowError("عذراً ليس لديك صلاحيات للإنتقال إلى الفرع المطلوب!");

            return isValid;
        }

        private bool ConfirmChangeBranch(string brnName)
        {
            string mssg = $"هل أنت متاكد من الإنتقال إلى الفرع: {brnName}؟";
            mssg += "\nسيقوم النظام بإعادة التشغيل في حال الموافقة.";


            return ClsXtraMssgBox.ShowWarningYesNo(mssg) == DialogResult.Yes ? true : false;
        }

        private void InitData()
        {
            ClsStopWatch stopWatch = new ClsStopWatch();
            tblAccountBoxBindingSource.DataSource = this.clsTbBox.GetBoxList;
            tblStoreBindingSource.DataSource = this.clsTbStore.GetStoreList;
            tblBranchBindingSource.DataSource = this.clsTbBranch.GetBranchList();
            tblAccountBindingSource.DataSource = this.clsTbAccount.GetAccountListByLevel(
                Convert.ToByte(MySetting.CurrSetting.dfltAccLevel - 1));
            textEditPrdExpirateAcc.Properties.DataSource = this.clsTbAccount.GetAccountListCategoery3();
            this.clsTbBox.InitBoxLookupEditSetteing(teDefaultBox);
            this.clsTbBank.InitBankLookupEdit(teDefaultBank);
            stopWatch.Stop();
        }

        private void InitDefaultData()
        {
            this.boxAccNo = MySetting.CurrSetting.defaultBox;
            this.printerSettings.PrinterName = Properties.Settings.Default.defaultPrinterSettings;// ClsPrinterSettings.RetriveSettingFromString(Properties.Settings.Default.defaultPrinterSettings);
            this.ordersPrinterSettings.PrinterName = Properties.Settings.Default.ordersPrinter;// ClsPrinterSettings.RetriveSettingFromString(Properties.Settings.Default.ordersPrinter);
            this.barocdePrinterSettings.PrinterName = Properties.Settings.Default.defaultPrinterBarcode;// ClsPrinterSettings.RetriveSettingFromString(Properties.Settings.Default.defaultPrinterBarcode);

            InitSupplySettings();
            InitOrdersSettings();
            teDefaultStrId.EditValue = MySetting.CurrSetting.defaultStrId;
            textEditDfltAccLevel.EditValue = MySetting.CurrSetting.dfltAccLevel;
            teDefaultShowCarData.IsOn = Properties.Settings.Default.ShowlayoutControlCarData;
            switch_GroupProductsInInvoices.IsOn = Properties.Settings.Default.GroupProductsInInvoices;
            switch_GroupWeightProdInInvoices.IsOn = Properties.Settings.Default.GroupWeightProdInInvoices;
        }
      
        private void InitSupplySettings()
        {
            teDefaultBox.EditValue = MySetting.CurrSetting.defaultBox;
            teDefaultBank.EditValue = MySetting.CurrSetting.defaultBank;
            teDefaultPrintPaper.EditValue = Properties.Settings.Default.printA4;
            teDefaultPrintOnSave.EditValue = Properties.Settings.Default.defaultPrintOnSave;
            teDefaultShowPrintMssg.EditValue = Properties.Settings.Default.showPrintMssg;
            teDefaultShowPrdQtyMssg.EditValue = Properties.Settings.Default.showPrdQtyMssg;
            tsDefaultSalePriceFloar.EditValue = Properties.Settings.Default.defaultSalePriceFloar;
            tsDefaultAutoSupplyTarhel.EditValue = MySetting.CurrSetting.autoSupplyTarhel;
            tsDefaultSendToECR.EditValue = Properties.Settings.Default.isSendToECR;
            teSupplyA4CustomRprt.EditValue = Properties.Settings.Default.supplyA4CustomRprt;
            teSupplyRetuA4CustomRprt.EditValue = Properties.Settings.Default.supplyRetuA4CustomRprt;
            teOrderA4CustomRprt.EditValue = Properties.Settings.Default.rprtOrderA4CustomRpt;
            teSupplyCashierCustomRprt.EditValue = Properties.Settings.Default.supplyCashierCustomRprt;
            teShowRprtPurchaseHeader.EditValue = Properties.Settings.Default.showRprtPurchaseHeader;
            teShowRprtSaleHeader.EditValue = Properties.Settings.Default.showRprtSaleHeader;
            teECRport.EditValue = Properties.Settings.Default.ecrPort;
            txRprtSupplyCustomType.EditValue = Properties.Settings.Default.rprtSupplyCustomType;
            PayPartInvoValue.EditValue=Properties.Settings.Default.PayPartInvoValue;
            AllowSaveInvoInBeforeDate.EditValue = MySetting.CurrSetting.AllowSaveInvoInBeforeDate;
            tsDefaultSalePriceAndBuy.EditValue = Properties.Settings.Default.tsDefaultSalePriceAndBuy;
            teSendDataToServerOnSave.EditValue = Properties.Settings.Default.SendDataToServerOnSave;
            teReportReciptCustom.EditValue = Properties.Settings.Default.teReportReciptCustom;
            teReportVocherCustom.EditValue = Properties.Settings.Default.teReportVocherCustom;
            teReportEntryCustom.EditValue = Properties.Settings.Default.teReportEntryCustom;
        }

        private void InitOrdersSettings()
        {
            teOrdersPrinttMssg.EditValue = Properties.Settings.Default.ordersShowPrintMssg;
            teOrdersPrintPreview.EditValue = Properties.Settings.Default.ordersPrintPreview;
            textEditOrderVoucher.Text = Properties.Settings.Default.ordersVoucherStr;
            textEditOrderExecute.Text = Properties.Settings.Default.ordersExecuteStr;
            textEditOrderReceipt.Text = Properties.Settings.Default.ordersReceiptStr;
            textEditOrderVoucherPlu.Text = Properties.Settings.Default.ordersVoucherStrPlu;
            textEditOrderExecutePlu.Text = Properties.Settings.Default.ordersExecuteStrPlu;
            textEditOrderReceiptPlu.Text = Properties.Settings.Default.ordersReceiptStrPlu;
        }

        private void InitBarcodeWeightData()
        {
            tgl_ReadFromScaleBarcode.IsOn = Properties.Settings.Default.ReadFormScaleBarcode;
            tgl_TaxReadMode.IsOn = Properties.Settings.Default.TaxReadMode;
            txt_ScaleBarcodePrefix.Text = Properties.Settings.Default.ScaleBarcodePrefix;
            spn_ProductCodeLength.EditValue = Properties.Settings.Default.ProductCodeLength;
            spn_BarcodeLength.EditValue = Properties.Settings.Default.BarcodeLength;
            spn_ValueCodeLength.EditValue = Properties.Settings.Default.ValueCodeLength;
            cbx_ReadMode.SelectedIndex = Properties.Settings.Default.ReadMode;
            chk_IgnoreCheckDigit.Checked = Properties.Settings.Default.IgnoreCheckDigit;
            cbx_DivideValueBy.SelectedIndex = Properties.Settings.Default.DivideValueBy;
        }

        private void TeDefaultBox_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;

            this.boxAccNo = Convert.ToInt64(editor.GetColumnValue("boxAccNo"));
        }

        private void btnDefaultPrinter_Click(object sender, EventArgs e)
        {
            using var form = new PrintEditorForm();
            ((SimpleButton)form.AcceptButton).Text = "حفظ";
            form.Document = new PrintDocument() { PrinterSettings = this.printerSettings };
            if (form.ShowDialog() == DialogResult.OK)
                Properties.Settings.Default.defaultPrinterSettings = form.Document.PrinterSettings.PrinterName;// ClsPrinterSettings.ConvertSettingToString(form.Document.PrinterSettings);
        }

        private void btnOrdersPrinter_Click(object sender, EventArgs e)
        {
            using var form = new PrintEditorForm();
            ((SimpleButton)form.AcceptButton).Text = "حفظ";
            form.Document = new PrintDocument() { PrinterSettings = this.ordersPrinterSettings };
            if (form.ShowDialog() == DialogResult.OK)
                Properties.Settings.Default.ordersPrinter = form.Document.PrinterSettings.PrinterName;//  ClsPrinterSettings.ConvertSettingToString(form.Document.PrinterSettings);
        }


        private void BtnBarcodePrinter_Click(object sender, EventArgs e)
        {
            using var printerForm = new PrintEditorForm();
            ((SimpleButton)printerForm.AcceptButton).Text = "حفظ";
            printerForm.Document = new PrintDocument() { PrinterSettings = this.barocdePrinterSettings };
            if (printerForm.ShowDialog() == DialogResult.OK)
                Properties.Settings.Default.defaultPrinterBarcode = printerForm.Document.PrinterSettings.PrinterName;//  ClsPrinterSettings.ConvertSettingToString(printerForm.Document.PrinterSettings);
        }
     
        private void TeSupplyA4CustomRprt_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (Convert.ToBoolean(e.NewValue) && !File.Exists(ClsPath.ReportSupplyCustomFile))
            {
                XtraMessageBox.Show((!Program.My_Setting.LangEng) ? "عذرا يجب إنشاء التقرير أولاً" : "Sorry you must create the report first!");
                e.NewValue = false;
                ShowReportEndUserForm(ReportCustomType.A4);
            }
        }
        private void TeSupplyCashierCustomRprt_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (Convert.ToBoolean(e.NewValue) && !File.Exists(ClsPath.ReportSupplyCashierCustomFile))
            {
                XtraMessageBox.Show((!Program.My_Setting.LangEng) ? "عذرا يجب إنشاء التقرير أولاً" : "Sorry you must create the report first!");
                e.NewValue = false;
                ShowReportEndUserForm(ReportCustomType.Chasier);
            }
        }
        private void BtnSupplyA4CustomRprt_Click(object sender, EventArgs e)
        {
            ShowReportEndUserForm(ReportCustomType.A4);
        }
        private void BtnSupplyCashierCustomRprt_Click(object sender, EventArgs e)
        {
            ShowReportEndUserForm(ReportCustomType.Chasier);
        }

        private void SaveDefaults()
        {
            if (!SavePrdColor()) return;
            if (!SaveDefaultAccData()) return;

            SaveSupplySettings();
            SaveOrdersSettings();
            SaveBarcodeWeightSettings();

            this.clsTbInvType.SaveDB();

            MySetting.CurrSetting.defaultStrId = Convert.ToInt16(teDefaultStrId.EditValue);
            MySetting.CurrSetting.dfltAccLevel = Convert.ToByte(textEditDfltAccLevel.EditValue);
            Properties.Settings.Default.Save(); 

            InitPrdColorData();
            InitDefaultAccountsData();
            ShowSaveMssg();
        }

        private void SaveSupplySettings()
        {
            MySetting.CurrSetting.defaultBox = Convert.ToInt64(teDefaultBox.EditValue);
            MySetting.CurrSetting.defaultBank = Convert.ToInt16(teDefaultBank.EditValue);
            Properties.Settings.Default.printA4 = (byte)teDefaultPrintPaper.EditValue;
            Properties.Settings.Default.defaultPrintOnSave = (bool)teDefaultPrintOnSave.EditValue;
            Properties.Settings.Default.showPrintMssg = (bool)teDefaultShowPrintMssg.EditValue;
            Properties.Settings.Default.showPrdQtyMssg = (bool)teDefaultShowPrdQtyMssg.EditValue;
            Properties.Settings.Default.defaultSalePriceFloar = (bool)tsDefaultSalePriceFloar.EditValue;
            MySetting.CurrSetting.autoSupplyTarhel = (bool)tsDefaultAutoSupplyTarhel.EditValue;
            Properties.Settings.Default.isSendToECR = (bool)tsDefaultSendToECR.EditValue;
            Properties.Settings.Default.supplyA4CustomRprt = (bool)teSupplyA4CustomRprt.EditValue;
            Properties.Settings.Default.supplyRetuA4CustomRprt = (bool)teSupplyRetuA4CustomRprt.EditValue;
            Properties.Settings.Default.rprtOrderA4CustomRpt= (bool)teOrderA4CustomRprt.EditValue;
            Properties.Settings.Default.showRprtPurchaseHeader = (bool)teShowRprtPurchaseHeader.EditValue;
            Properties.Settings.Default.supplyCashierCustomRprt = (bool)teSupplyCashierCustomRprt.EditValue;
            Properties.Settings.Default.showRprtSaleHeader = (bool)teShowRprtSaleHeader.EditValue;
            Properties.Settings.Default.ecrPort = teECRport.Text;
            Properties.Settings.Default.rprtSupplyCustomType = (byte)txRprtSupplyCustomType.EditValue;
            Properties.Settings.Default.PayPartInvoValue = (bool)PayPartInvoValue.EditValue;
            MySetting.CurrSetting.AllowSaveInvoInBeforeDate = (bool)AllowSaveInvoInBeforeDate.EditValue;
            Properties.Settings.Default.tsDefaultSalePriceAndBuy = (short)tsDefaultSalePriceAndBuy.EditValue;
            Properties.Settings.Default.SendDataToServerOnSave = (bool)teSendDataToServerOnSave.EditValue;
            Properties.Settings.Default.GroupWeightProdInInvoices = (bool)switch_GroupWeightProdInInvoices.EditValue;
            Properties.Settings.Default.teReportVocherCustom = (bool)teReportVocherCustom.EditValue;
            Properties.Settings.Default.teReportReciptCustom = (bool)teReportReciptCustom.EditValue;
            Properties.Settings.Default.teReportEntryCustom = (bool)teReportEntryCustom.EditValue;
            
        }

        private void SaveOrdersSettings()
        {
            Properties.Settings.Default.ordersVoucherStr = textEditOrderVoucher.Text;
            Properties.Settings.Default.ordersExecuteStr = textEditOrderExecute.Text;
            Properties.Settings.Default.ordersReceiptStr = textEditOrderReceipt.Text;
            Properties.Settings.Default.ordersVoucherStrPlu = textEditOrderVoucherPlu.Text;
            Properties.Settings.Default.ordersExecuteStrPlu = textEditOrderExecutePlu.Text;
            Properties.Settings.Default.ordersReceiptStrPlu = textEditOrderReceiptPlu.Text;
            Properties.Settings.Default.ordersShowPrintMssg = (bool)teOrdersPrinttMssg.EditValue;
            Properties.Settings.Default.ordersPrintPreview = (bool)teOrdersPrintPreview.EditValue;
        }

        private void SaveBarcodeWeightSettings()
        {
            Properties.Settings.Default.ReadFormScaleBarcode = tgl_ReadFromScaleBarcode.IsOn;
            Properties.Settings.Default.TaxReadMode = tgl_TaxReadMode.IsOn;
            Properties.Settings.Default.ScaleBarcodePrefix = txt_ScaleBarcodePrefix.Text;
            Properties.Settings.Default.ProductCodeLength = Convert.ToInt32(spn_ProductCodeLength.EditValue);
            Properties.Settings.Default.BarcodeLength = Convert.ToInt32(spn_BarcodeLength.EditValue);
            Properties.Settings.Default.ValueCodeLength = Convert.ToInt32(spn_ValueCodeLength.EditValue);
            Properties.Settings.Default.ReadMode = cbx_ReadMode.SelectedIndex;
            Properties.Settings.Default.IgnoreCheckDigit = chk_IgnoreCheckDigit.Checked;
            Properties.Settings.Default.DivideValueBy = cbx_DivideValueBy.SelectedIndex;

        }

        private void ShowSaveMssg()
        {
            string mssg = (!Program.My_Setting.LangEng) ? "الإعدادات الإفتراضيه" : "Default Settings";
            flyDialog.ShowDialogForm(this, mssg);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveDefaults();
            Program.printA4 = Properties.Settings.Default.printA4;
            Program.supplyCashierCustomRprt = Properties.Settings.Default.supplyCashierCustomRprt;
            Program.supplyRetuA4CustomRprt = Properties.Settings.Default.supplyRetuA4CustomRprt;
            Program.supplyA4CustomRprt = Properties.Settings.Default.supplyA4CustomRprt;
            Program.langEng = Program.My_Setting.LangEng;
            Program.rprtOrderA4CustomRpt = Properties.Settings.Default.rprtOrderA4CustomRpt;
            Program.defaultPrinterSettings = Properties.Settings.Default.defaultPrinterSettings;
            Program.ordersPrinter = Properties.Settings.Default.ordersPrinter;
            Program.defaultPrinterBarcode = Properties.Settings.Default.defaultPrinterBarcode;
            Program.rprtSupplyCustomType = Properties.Settings.Default.rprtSupplyCustomType;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetLanguage()
        {
            if (!Program.My_Setting.LangEng) Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
            else Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
        }

        private void SetRTL()
        {
            if (!Program.My_Setting.LangEng) return;

            layoutControl1.BeginUpdate();
            layoutControl1.RightToLeft = RightToLeft.No;
            layoutControl1.OptionsView.RightToLeftMirroringApplied = false;
            layoutControl1.EndUpdate();
        }

        private void teDefaultShowCarData_Toggled(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowlayoutControlCarData = teDefaultShowCarData.IsOn;
            Properties.Settings.Default.Save(); 
            
        }

        private void btnShowPorts_Click(object sender, EventArgs e)
        {
            string portNames = null;
            var portList = SerialPort.GetPortNames();

            foreach (var port in portList) portNames += $"{port}\n";

            XtraMessageBox.Show(portNames);
        }

        private void switch_GroupProductsInInvoices_Toggled(object sender, EventArgs e)
        {
            Properties.Settings.Default.GroupProductsInInvoices = switch_GroupProductsInInvoices.IsOn;
            Properties.Settings.Default.Save(); 
            
        }
        XtraFormConncetionAccDB FormConncetionAccDB;
        private void btnSettingCon_Click(object sender, EventArgs e)
        {
            FormConncetionAccDB = new XtraFormConncetionAccDB();
            FormConncetionAccDB.Show();
        }

        private void btnReportVocherCustom_Click(object sender, EventArgs e)
        {
            ShowReportEndUserForm(ReportCustomType.EntryVoucher);
        }

        private void btnReportReciptCustom_Click(object sender, EventArgs e)
        {
            ShowReportEndUserForm(ReportCustomType.EntryReceipt);
        }

        private void btnReportEntryCustom_Click(object sender, EventArgs e)
        {
            ShowReportEndUserForm(ReportCustomType.Entry);
        }
    }
}