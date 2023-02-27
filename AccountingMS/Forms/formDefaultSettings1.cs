using AccountingMS.Classes;
using AccountingMS.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting.Preview;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formDefaultSettings1 : XtraForm
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblBranch clsTbBranch;
        ClsTblUserBranch clsTbUsrBrnch;
        ClsTblBox clsTbBox;
        ClsTblBank clsTbBank;
        ClsTblStore clsTbStore;
        ClsTblProductColor clsTbPrdColor;
        public formDefaultSettings1()
        {
            SetLanguage();
            InitializeComponent();
            SetRTL();

            this.Load += FormDefaultSettings_Load;
        }
        
        private void radioGroupInvType_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (!ValidateAdminUser())
            {
                e.Cancel = true;
                return;
            }
            e.Cancel = !ConfirmMssg();
        }

        private bool ValidateAdminUser()
        {
            bool isVaid = Session.CurrentUser.id != 1 ? false : true;
            if (!isVaid) ClsXtraMssgBox.ShowError("عذراً ليس لديك صلاحيات للقيام بهذه العملية!");
            return isVaid;
        }

        private bool ConfirmMssg()
        {
            bool isConfirm = ClsXtraMssgBox.ShowWarningYesNo("هل أنت متأكد من تغير نوع الجرد ؟") == DialogResult.Yes ? true : false;
            return isConfirm;
        }
        private async void FormDefaultSettings_Load(object sender, EventArgs e)
        {
            await InitObjectsAsync();
            InitData();
            btnReportEntryCustom.Click += BtnReportCustomRprt_Click;
            btnSupplyCashierCustomRprt.Click += BtnReportCustomRprt_Click;
            btnSupplyA4CustomRprt.Click += BtnReportCustomRprt_Click;
            btnReportReciptCustom.Click += BtnReportCustomRprt_Click;
            btnReportVocherCustom.Click += BtnReportCustomRprt_Click;
            gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
            teSupplyCashierCustomRprt.EditValueChanging += TeSupplyCashierCustomRprt_EditValueChanging;
          
            teSupplyA4CustomRprt.EditValueChanging += TeSupplyA4CustomRprt_EditValueChanging;
            teSupplyRetuA4CustomRprt.EditValueChanging += TeSupplyA4CustomRprt_EditValueChanging;
            teOrderA4CustomRprt.EditValueChanging += TeSupplyA4CustomRprt_EditValueChanging;
            textEditBranch.EditValueChanged += TextEditBranch_EditValueChanged;
            textEditBranch.EditValueChanging += TextEditBranch_EditValueChanging;
           
            tsDefaultSalePriceAndBuy.Properties.Items.AddRange(WarningLevelsList);
            cbx_ReadMode.Properties.Items.AddRange(ReadModeList);
            //tsDefaultSalePriceAndBuy.Properties.Columns = 3;
            tsDefaultSalePriceAndBuy.AutoSizeInLayoutControl = true;
            teReportVocherCustom.EditValueChanging += TeReportVocherCustom_EditValueChanging;
            teReportReciptCustom.EditValueChanging += TeReportReciptCustom_EditValueChanging;
            teReportEntryCustom.EditValueChanging += TeReportEntryCustom_EditValueChanging;
            keyValuePairs.Add(0, 1);
            keyValuePairs.Add(1, 10);
            keyValuePairs.Add(2, 100);
            keyValuePairs.Add(3, 1000);
            keyValuePairs.Add(4, 10000);
            cbx_DivideValueBy.Properties.DataSource = (from k in keyValuePairs select new { ID = k.Key, Value = k.Value }).ToList();
           
        }

        private void GridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column.Name == colcolHtml.Name && (e.IsGetData))
            {
                var tbPrdColor1 = tblProductColorBindingSource.List as List<tblProductColor>;
                e.Value = tbPrdColor1[e.ListSourceRowIndex].colHtml;
            }
        }

        public Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
        private void repositoryItemColorPickEdit1_EditValueChanged(object sender, EventArgs e)
        {
            tblProductColor tbPrdColor1 = tblProductColorBindingSource.Current as tblProductColor;
            tbPrdColor1.colHtml = ColorTranslator.ToHtml(((ColorPickEdit)sender).Color);
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
        void MessIfReportCustomNotFound()=> XtraMessageBox.Show((!MySetting.GetPrivateSetting.LangEng) ? "عذرا يجب إنشاء التقرير أولاً" : "Sorry you must create the report first!");
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
                new RadioGroupItem() { Value = (short)WarningLevels.DoNotEnteript  , Description  =(MySetting.GetPrivateSetting.LangEng)?"Permissible":"مسموح" },
                new RadioGroupItem() { Value = (short)WarningLevels.ShowWarning  , Description  =(MySetting.GetPrivateSetting.LangEng)?"Warning":"تحذير" },
                new RadioGroupItem() { Value = (short)WarningLevels.Prevent  , Description  =(MySetting.GetPrivateSetting.LangEng)?"Prevent":"منع" },

        }; 
        public RadioGroupItem[] ReadModeList ={
             new RadioGroupItem() { Value =(byte)0  , Description  =(MySetting.GetPrivateSetting.LangEng)?"Weight":"وزن" },
                new RadioGroupItem() { Value = (byte)1 , Description  =(MySetting.GetPrivateSetting.LangEng)?"Price":"سعر" },
               

        };

        private async Task InitObjectsAsync()
        {
            flyDialog.WaitForm(this, 1);
            IList<Task> taskList = new List<Task>();

            taskList.Add(Task.Run(() => this.clsTbBranch = new ClsTblBranch()));
            taskList.Add(Task.Run(() => this.clsTbUsrBrnch = new ClsTblUserBranch()));
            taskList.Add(Task.Run(() => this.clsTbBox = new ClsTblBox()));
            taskList.Add(Task.Run(() => this.clsTbBank = new ClsTblBank()));
            taskList.Add(Task.Run(() => this.clsTbStore = new ClsTblStore()));
            taskList.Add(Task.Run(() => this.clsTbPrdColor = new ClsTblProductColor()));

            await Task.WhenAll(taskList);
            flyDialog.WaitForm(this, 0);
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
            if(editor.GetSelectedDataRow() is tblBranch tbBranch&& tbBranch != null && tbBranch?.brnId!=Session.CurBranch.brnId)
            {
                SetTmpProperties(tbBranch);
                this.Close();
                ClsForceApplicationExit.ForceExit = true;
                Application.Restart();
            }
        }
        private void SetTmpProperties(tblBranch tbBranch)
        {
            MySetting.GetPrivateSetting.restartForm = true;
            MySetting.GetPrivateSetting.tmpUsrId = Session.CurrentUser.id;
            MySetting.GetPrivateSetting.tmpRoleId = Session.RoleId;
            MySetting.GetPrivateSetting.tmpUsrName = Session.CurrentUser.userName;
            MySetting.GetPrivateSetting.tmpBrnId = tbBranch.brnId;
            MySetting.GetPrivateSetting.tmpBrnName = tbBranch.brnName;
            MySetting.GetPrivateSetting.tmpFyId = (short)Session.CurrentYear.fyId;
            MySetting.GetPrivateSetting.tmpFyDtStart = Session.CurrentYear.fyDateStart;
            MySetting.GetPrivateSetting.tmpFyDtEnd = Session.CurrentYear.fyDateEnd;
            MySetting.WriterSettingXml(); 
        }

        private bool ValidateUsrBranchRole(short brnId)
        {
            if (Session.CurrentUser.id == 1) return true;
            bool isValid = this.clsTbUsrBrnch.IsUserBranchFound(Session.CurrentUser.id, brnId);
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
            tblStoreBindingSource.DataSource = this.clsTbStore.GetStoreList;
            tblBranchBindingSource.DataSource = this.clsTbBranch.GetBranchList();
            this.clsTbBox.InitBoxLookupEditSetteing(teDefaultBox);
            this.clsTbBank.InitBankLookupEdit(teDefaultBank);
            tblProductColorBindingSource.DataSource = this.clsTbPrdColor.GetProductColorList;
            tblSettingBindingSource.DataSource = MySetting.DefaultSetting;
            textEditDefaultPrinter.Properties.DataSource =Session.ListPrinter;
            textEditPrinterBarcod.Properties.DataSource = Session.ListPrinter;
            textEditOrderPrinter.Properties.DataSource = Session.ListPrinter;
            stopWatch.Stop();
        }
        private void TeSupplyA4CustomRprt_EditValueChanging(object sender,ChangingEventArgs e)
        {
            if (Convert.ToBoolean(e.NewValue) && !File.Exists(ClsPath.ReportSupplyCustomFile))
            {
                XtraMessageBox.Show((!MySetting.GetPrivateSetting.LangEng) ? "عذرا يجب إنشاء التقرير أولاً" : "Sorry you must create the report first!");
                e.NewValue = false;
                ShowReportEndUserForm(ReportCustomType.A4);
            }
        }
        private void TeSupplyCashierCustomRprt_EditValueChanging(object sender,ChangingEventArgs e)
        {
            if (Convert.ToBoolean(e.NewValue) && !File.Exists(ClsPath.ReportSupplyCashierCustomFile))
            {
                XtraMessageBox.Show((!MySetting.GetPrivateSetting.LangEng) ? "عذرا يجب إنشاء التقرير أولاً" : "Sorry you must create the report first!");
                e.NewValue = false;
                ShowReportEndUserForm(ReportCustomType.Chasier);
            }
        }
        private void BtnReportCustomRprt_Click(object sender, EventArgs e)
        {
            switch (((SimpleButton)sender).Name)
            {
                case "btnSupplyA4CustomRprt":
                    ShowReportEndUserForm(ReportCustomType.A4);
                    break;
                case "btnSupplyCashierCustomRprt":
                    ShowReportEndUserForm(ReportCustomType.Chasier); 
                    break;
                case "btnReportReciptCustom":
                    ShowReportEndUserForm(ReportCustomType.EntryReceipt);
                    break;
                case "btnReportEntryCustom":
                    ShowReportEndUserForm(ReportCustomType.Entry); 
                    break;
                case "btnReportVocherCustom":
                    ShowReportEndUserForm(ReportCustomType.EntryVoucher); 
                    break;
                default:
                    break;
            }
            
        }
      
        private void SaveData()
        {
            using (var db = new accountingEntities())
            {
                var ProductColor = tblProductColorBindingSource.List as IList<tblProductColor>;
                ProductColor.ToList().ForEach(x =>
                {
                    db.tblProductColors.FirstOrDefault(y => y.colId == x.colId).colHtml = x.colHtml;
                    db.tblProductColors.FirstOrDefault(y => y.colId == x.colId).colQuan = x.colQuan;
                });
                var setting = tblSettingBindingSource.Current as tblSetting;

                db.tblSettings.Remove(db.tblSettings.FirstOrDefault(x => x.ID == setting.ID && x.MachineName == setting.MachineName));
                db.tblSettings.Add(setting);
                if (db.SaveChanges() > 0)
                {
                    ShowSaveMssg();
                    Session.GetDataProductColors();
                }
                MySetting.DefaultSetting = db.tblSettings?.FirstOrDefault(x => x.MachineName == Environment.MachineName);
            }
        }
     
        private void ShowSaveMssg()
        {
            string mssg = (!MySetting.GetPrivateSetting.LangEng) ? "الإعدادات الإفتراضيه" : "Default Settings";
            flyDialog.ShowDialogForm(this, mssg);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetLanguage()
        {
            if (!MySetting.GetPrivateSetting.LangEng) Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
            else Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
        }

        private void SetRTL()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;
            dataLayoutControl4.BeginUpdate();
            dataLayoutControl4.RightToLeft = RightToLeft.No;
            dataLayoutControl4.OptionsView.RightToLeftMirroringApplied = false;
            dataLayoutControl4.EndUpdate();
        }
        private void btnShowPorts_Click(object sender, EventArgs e)
        {
            string portNames = null;
            var portList = SerialPort.GetPortNames();
            foreach (var port in portList) portNames += $"{port}\n";
            XtraMessageBox.Show(portNames);
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (accountingEntities db = new accountingEntities())
            {
                var setting = tblSettingBindingSource.Current as tblSetting;
                var empseting = db.tblSettings.FirstOrDefault(x => x.ID == setting.ID && x.MachineName == setting.MachineName);
                if (empseting.employees == employeesText.Text)
                {
                    if (empseting.emp == false || empseting.emp == null)
                    {
                        empseting.emp = true;
                    }
                    else
                    {
                        empseting.emp = false;
                    }
                    db.SaveChanges();
                    XtraMessageBox.Show((!MySetting.GetPrivateSetting.LangEng) ? "تم الحفظ يجب اعادة تشغل البرنامج" : "Saved, you must restart the program");

                }
                else
                {
                    XtraMessageBox.Show((!MySetting.GetPrivateSetting.LangEng) ? "كل السر غير صحيحة " : "Sorry The password is incorrect");
                }

            }
        }
    }
}