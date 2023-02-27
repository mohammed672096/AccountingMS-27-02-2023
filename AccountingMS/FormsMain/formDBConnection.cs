using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraSplashScreen;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formDBConnection : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        OverlayTextPainter overlayLabel;
        OverlayWindowOptions overlayWindow;
        IOverlaySplashScreenHandle overlaySplashScreen;

        public formDBConnection()
        {
            InitializeComponent();
            InitSplashScreen();
            ribbonControl1.OptionsTouch.TouchUI = DevExpress.Utils.DefaultBoolean.True;
            this.KeyDown += FormDBConnection_KeyDown;
            DataBaseComboBox.QueryPopUp += DataBaseComboBox_QueryPopUp;
            this.Load += FormDBConnection_Load;
        }

        private void FormDBConnection_Load(object sender, EventArgs e)
        {
            LoadServers();
        }

        public void LoadServers()
        {
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            DataTable table = instance.GetDataSources();
            string ServerName = Environment.MachineName;
            foreach (DataRow row in table.Rows)
                ServersComboBox.Properties.Items.Add(ServerName + "\\" + row["InstanceName"].ToString());
            ServersComboBox.Text = ServerName;
            //DataBaseComboBox.Text = "accounting";
            layoutControlGroup5.Visibility = rbWindows.Checked ? LayoutVisibility.Never : LayoutVisibility.Always;
        
        }
        private void InitSplashScreen()
        {
            this.overlayLabel = new OverlayTextPainterEx() { Font = new Font("Segoe UI", 8.5F), Color = Color.FromArgb(192, 0, 0) };
            this.overlayWindow = new OverlayWindowOptions() { Opacity = 200 / 255D };
        }
        private void rbSQL_CheckedChanged(object sender, EventArgs e)
        {
            layoutControlGroup5.Visibility = rbWindows.Checked ? LayoutVisibility.Never : LayoutVisibility.Always;
            if (rbWindows.Checked)
                txtSqlUserName.Focus();
            else
            {
                txtSqlUserName.ResetText();
                txtSqlPassword.ResetText();
                btnSave.Focus();
            }
        }
        private void DataBaseComboBox_QueryPopUp(object sender, CancelEventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder builder = GetBuilder();
                builder.InitialCatalog = "master";
                SqlConnection connSQLServer = new SqlConnection(builder.ConnectionString);

                SqlDataAdapter da = new SqlDataAdapter("select name from sys.databases", connSQLServer);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataBaseComboBox.Properties.Items.Clear();
                if (dt.Rows.Count > 0)
                    for (int i = 0; i < dt.Rows.Count; i++)
                        DataBaseComboBox.Properties.Items.Add(dt.Rows[i]["name"]);
                //DataBaseComboBox.SelectedItem = "accounting";
            }
            catch (Exception ex)
            {
                DataBaseComboBox.Properties.Items.Clear();
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        SqlConnectionStringBuilder GetBuilder()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnectionString_DB());
            builder.IntegratedSecurity = (rbWindows.Checked);
            builder.DataSource = ServersComboBox.Text;
            builder.InitialCatalog = DataBaseComboBox.Text;
            if (rbSQL.Checked)
            {
                builder.UserID = txtSqlUserName.Text;
                builder.Password = txtSqlPassword.Text;
            }
            return builder;
        }
        private void SetOverlayLabel(bool isConnectingLabel)
        {
            this.overlayLabel.Text = $"يرجى الإنتظار.. {((isConnectingLabel) ? "جاري الربط مع السرفر" : "جاري حفظ بيانات السرفر")}";
        }

        private void SplashScreenShow(bool isConnectingLabel)
        {
            SetOverlayLabel(isConnectingLabel);
            this.overlayWindow.CustomPainter = this.overlayLabel;
            this.overlaySplashScreen = SplashScreenManager.ShowOverlayForm(this, this.overlayWindow);
        }

        private void SplashScreenClose()
        {
            this.overlaySplashScreen.Close();
        }

        private void BtnTestConnection_Click(object sender, EventArgs e)
        {
            bool isConnected = TestConnection(ServersComboBox.Text);

            XtraMessageBox.Show($"{((isConnected) ? "تم الإتصال بلسرفر بنجاح" : "عذرا هناك خطاء في الإتصال بلسرفر، يرجى التحقق من إدخال إسم السررفر بشكل صحيح")}");
        }

        private void BtnResetServerName_Click(object sender, EventArgs e)
        {
            ServersComboBox.Text = Environment.MachineName;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SplashScreenShow(false);
            //if (!ValidateInstallation()) return;
            if (SaveEntityConnectionString(out Configuration config) && new ClsTestDBConnection().TestConnection(
                config.ConnectionStrings.ConnectionStrings["accountingEntities"].ConnectionString.ToString()) && SaveSqlConnectionString())
            {
                SaveAppFirstRun();
                SaveHDDSerial();
                SaveDefaultSettings();
                SplashScreenClose();
                RestartApplication();
            }
            else
            {
                SplashScreenClose();
                XtraMessageBox.Show("عذرا هناك خطاء في الإتصال بلسرفر، يرجى التحقق من إدخال إسم السررفر بشكل صحيح");
            }
        }

        private void SaveDefaultSettings()
        {
            ClsEncryption clsEncrp = new ClsEncryption(); 
            if (string.IsNullOrWhiteSpace(ConnSetting.GetConnSetting.accountingConnectionVal))
                ConnSetting.GetConnSetting.accountingConnectionVal = clsEncrp.EncryptString("8-" + ClsHardDriveSerial.HDDSerieal());
            if (string.IsNullOrWhiteSpace(ConnSetting.GetConnSetting.accountingConnectionFlag))
                ConnSetting.GetConnSetting.accountingConnectionFlag = clsEncrp.EncryptString(ClsHardDriveSerial.HDDSerieal() + "0");
            ConnSetting.WriterSettingXml(); 
        }

        private bool ValidateInstallation()
        {
            if (Directory.Exists(@$"{ClsDrive.Path}:\B-Tech\DB") && (string.IsNullOrWhiteSpace(ConnSetting.GetConnSetting.accountingConnectionVal) ||
                string.IsNullOrWhiteSpace(ConnSetting.GetConnSetting.accountingConnectionFlag) || ConnSetting.GetConnSetting.accountingConnectionDt == new DateTime(0001, 1, 1)))
            {
                XtraMessageBox.Show(this, "للمتابعة يرجى شراء النسخه الأصليه! \n للتواصل الإتصال على الأرقام التالية: 0535213680");
                Application.Exit();
                return false;
            }
            return true;
        }

        private void SaveAppFirstRun()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["ApplicationFirstRun"].Value = false.ToString();
            config.Save(ConfigurationSaveMode.Modified);
        }

        private void SaveHDDSerial()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Serial"].Value = new ClsEncryption().EncryptString(ClsHardDriveSerial.HDDSerieal());
            config.Save(ConfigurationSaveMode.Modified);
        }

        private void RestartApplication()
        {
            this.Close();
            Application.ExitThread();
            Thread thread = new Thread(new ThreadStart(RunNewThread));
            thread.Start();
        }

        private void RunNewThread()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            Process.Start(path + "AccountingMS.exe");
        }

        private bool TestConnection(string serverName)
        {
            SplashScreenShow(true);
            bool isConnected = new ClsTestDBConnection(serverName).TestConnection();
            SplashScreenClose();

            return isConnected;
        }

        private string SetConnectionString()
        {
            return $"metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string=\"{ConnectionString_DB()}MultipleActiveResultSets=True;App=EntityFramework\"";
        }

        private bool SaveEntityConnectionString(out Configuration config)
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            try
            {
                config.ConnectionStrings.ConnectionStrings["accountingEntities"].ConnectionString = SetConnectionString();
                config.ConnectionStrings.ConnectionStrings["accountingEntities"].ProviderName = "System.Data.EntityClient";
                config.Save(ConfigurationSaveMode.Modified);
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return false;
            }
        }
        public string ConnectionString_DB()
        {
            string conStraing = "";
            if (rbSQL.Checked)
                conStraing = $"data source={ServersComboBox.Text};Initial Catalog={DataBaseComboBox.Text};user id={txtSqlUserName.Text};password={txtSqlPassword.Text};";
            else if (rbWindows.Checked)
                conStraing = $"data source={ServersComboBox.Text};Initial Catalog={DataBaseComboBox.Text};Integrated Security=true;";
            return conStraing;
        }
        private bool SaveSqlConnectionString()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string connectionString = ConnectionString_DB();
            try
            {
                config.ConnectionStrings.ConnectionStrings["accountingConnectionString"].ConnectionString = connectionString;
                config.ConnectionStrings.ConnectionStrings["accountingConnectionString"].ProviderName = "System.Data.SqlClient";
                config.Save(ConfigurationSaveMode.Modified);
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return false;
            }
        }

        private void FormDBConnection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.Alt && e.KeyCode == Keys.S)
            {
                SaveHDDSerial();
                SaveAppFirstRun();
                RestartApplication();
            }
            if (e.Control && e.Shift && e.KeyCode == Keys.D)
            {
                ClsThreadCulture.ChangeCultureEn();
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = false;
                var drive = XtraInputBox.Show("Drive:", "ChangeDrive", "D");
                ClsThreadCulture.ChangeCultureDefault();
                this.RightToLeft = RightToLeft.Yes;
                this.RightToLeftLayout = true;
                MySetting.GetPrivateSetting.drive = drive;
                MySetting.WriterSettingXml(); 
            }
        }
    }

    class OverlayTextPainterEx : OverlayTextPainter
    {
        protected override Rectangle CalcTextBounds(OverlayLayeredWindowObjectInfoArgs drawArgs)
        {
            Size textSz = CalcTextSize(drawArgs);
            return textSz.AlignWith(drawArgs.Bounds).WithY(drawArgs.ImageBounds.Bottom + 10).WithX(drawArgs.Bounds.Width / 2 - 100);
        }
    }
}