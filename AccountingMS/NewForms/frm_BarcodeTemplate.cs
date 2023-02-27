using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing.Printing;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using ERP.Reporting;
using System.IO;
using System.Xml.Linq;
using DAL;
using System.Xml;
using System.Diagnostics;
using DevExpress.Office.Utils;

namespace ERP.Forms
{
    public partial class frm_BarcodeTemplate : XtraForm
    {
        public  rpt_Barcode  CurrentReport = new rpt_Barcode();
        private bool IsGettingData;
   
        public frm_BarcodeTemplate()
        {
            InitializeComponent();
            foreach (int num in Enum.GetValues(typeof(PaperKind)))
                this.cb_Papers.Properties.Items.Add(new ImageComboBoxItem(Enum.GetName(typeof(PaperKind), (object)num), (object)Enum.GetName(typeof(PaperKind), (object)num), -1));
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
                comboBoxEdit1.Properties.Items.Add(strPrinter);

            RefreshData();
            txt_Paperheight.EditValueChanged += EditValueChanged;
            txt_Paperwidth.EditValueChanged += EditValueChanged;
            txtColumnsCount.EditValueChanged += EditValueChanged;
            txt_MarginBottom.EditValueChanged += EditValueChanged;
            txt_MarginTop.EditValueChanged += EditValueChanged;
            txt_MarginLeft.EditValueChanged += EditValueChanged;
            txt_MarginRight.EditValueChanged += EditValueChanged;
            txtRowsCount.EditValueChanged += EditValueChanged;
            cb_Papers.EditValueChanged += EditValueChanged;
            comboBoxEdit1.EditValueChanged += EditValueChanged;

        }

        void SetData()
        {
            if (IsGettingData) return;
            CurrentReport.Detail.MultiColumn.ColumnCount = Convert.ToInt16(txtColumnsCount.EditValue);
            CurrentReport.Height = Convert.ToInt16(txt_Paperheight .EditValue);
            CurrentReport.Width  = Convert.ToInt16(txt_Paperwidth   .EditValue);
            CurrentReport.Margins .Bottom   = Convert.ToInt32(txt_MarginBottom.EditValue);
            CurrentReport.Margins.Left = Convert.ToInt32(txt_MarginLeft.EditValue);
            CurrentReport.Margins.Right = Convert.ToInt32(txt_MarginRight.EditValue);
            CurrentReport.Margins.Top = Convert.ToInt32(txt_MarginTop.EditValue);
            CurrentReport.PaperKind  = (PaperKind)Enum.Parse(typeof(PaperKind), cb_Papers.Text);
            CurrentReport.PageHeight = Convert.ToInt32(txt_Paperheight.EditValue);
            CurrentReport.PageWidth = Convert.ToInt32(txt_Paperwidth.EditValue);
            CurrentReport.PrinterName = comboBoxEdit1.Text;
            CurrentReport.Name = textEdit1.Text;

        }

        void GetData()
        {
            IsGettingData = true;
            txtColumnsCount.EditValue = CurrentReport.Detail.MultiColumn.ColumnCount;
            txt_Paperheight.EditValue = CurrentReport.Height;
            txt_Paperwidth.EditValue = CurrentReport.Width;
            txt_MarginBottom.EditValue = CurrentReport.Margins.Bottom;
            txt_MarginLeft.EditValue = CurrentReport.Margins.Left;
            txt_MarginRight.EditValue = CurrentReport.Margins.Right;
            txt_MarginTop.EditValue = CurrentReport.Margins.Top;
            cb_Papers.Text = CurrentReport.PaperKind.ToString();
            txt_Paperheight.EditValue = CurrentReport.PageHeight;
            txt_Paperwidth.EditValue = CurrentReport.PageWidth;
            comboBoxEdit1.Text = CurrentReport.PrinterName;
            textEdit1.Text=    CurrentReport.Name;
            IsGettingData = false ;

        }
        void RefreshData()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            var templates = db.BarcodeTemplates.Select(x => x);
       
        
            DataTable table = new DataTable();

            table.Columns.Add("Name");
            table.Columns.Add("Template");
            table.Columns.Add("Size");
            table.Columns.Add("Image",typeof(Image));
            foreach (var  temp  in templates )
            {
                DataRow row = table.NewRow();
                row["Name"] = temp.Name;
                row["Template"] = temp.Template;
                XtraReport report = XtraReport.FromStream(new MemoryStream(Encoding.UTF8.GetBytes(temp.Template)));
                row["Size"] = report.PageSize.ToString();
                Stream stream = new MemoryStream();
                report.ExportToImage(stream: stream);
                row["Image"] = Image.FromStream(stream);
                table.Rows.Add(row);
                    
            }

            listBoxControl1.DataSource = table ;
            listBoxControl1.DisplayMember = "Name";
            listBoxControl1.ValueMember = "Template";

        }
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            XRDesignForm form = new XRDesignForm();
            mdiController = form.DesignMdiController;
            // Handle the DesignPanelLoaded event of the MDI controller,
            // to override the SaveCommandHandler for every loaded report.
            mdiController.DesignPanelLoaded +=
                new DesignerLoadedEventHandler(mdiController_DesignPanelLoaded);
            // Open an empty report in the form.
            mdiController.OpenReport(CurrentReport);
            // Show the form.
            form.ShowDialog();
            if (mdiController.ActiveDesignPanel != null)
            {
                mdiController.ActiveDesignPanel.CloseReport();
            }
        }
        XRDesignMdiController mdiController;
        void mdiController_DesignPanelLoaded(object sender, DesignerLoadedEventArgs e)
        {
            XRDesignPanel panel = (XRDesignPanel)sender;
            panel.AddCommandHandler(new SaveCommandHandler(panel));
        }

        public class SaveCommandHandler : ICommandHandler
        {
            XRDesignPanel panel;

            public SaveCommandHandler(XRDesignPanel panel)
            {
                this.panel = panel;
            }

            public void HandleCommand(ReportCommand command,   object[] args)
            {
                // Save the report.
                Save();
            } 
            public bool CanHandleCommand(ReportCommand command,
                ref bool useNextHandler)
            {
                useNextHandler = !(command == ReportCommand.SaveFile ||
                                   command == ReportCommand.SaveFileAs);
                return !useNextHandler;
            } 
            void Save()
            { 
                panel.Report.Name = panel.Report.GetType().Name; 
                panel.ReportState = ReportState.Saved;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            db.BarcodeTemplates.DeleteAllOnSubmit(db.BarcodeTemplates.Where(x=>x.Name == CurrentReport.Name));
            SetData();
            MemoryStream stream = new MemoryStream();  
            CurrentReport.SaveLayout(stream);
        
            db.BarcodeTemplates.InsertOnSubmit(new BarcodeTemplate()
            {
                Name = CurrentReport.Name,
                Template = Encoding.UTF8.GetString(stream.ToArray())
            });
            db.SubmitChanges();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            CurrentReport = new rpt_Barcode();
            GetData();
        }

        private void cb_Papers_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_Paperheight.Enabled = txt_Paperwidth.Enabled = (cb_Papers.Text == "Custom");
        }

        private void EditValueChanged(object sender, EventArgs e)
        { 
            SetData();
            Stream stream = new System.IO.MemoryStream();
            CurrentReport.ExportToImage(stream: stream); 
            pictureEdit1.Image = System.Drawing.Image.FromStream(stream);

        }

        private void listBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
