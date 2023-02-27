using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using PosFinalCost.Classe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosFinalCost
{
    public partial class SelectReportInvoiceLayout : DevExpress.XtraEditors.XtraForm
    {
        public enum LayoutType
        {
            Sales,POS
        }
         
        public LayoutType layoutType { get; }

        public SelectReportInvoiceLayout(LayoutType layoutType)
        {
            InitializeComponent();
            this.layoutType = layoutType;
            this.Shown += SelectSalesInvoiceLayout_Shown;
        }

        private void SelectSalesInvoiceLayout_Shown(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo d = new DirectoryInfo(ClsPath.ReportSupplyCustomFolder);//Assuming Test is your Folder
                FileInfo[] Files = d.GetFiles("*.repx"); //Getting Text files
                foreach (FileInfo file in Files)
                {
                    //str = str + ", " + file.Name;
                }
                radioGroup1.Properties.Items.AddRange(Files.Select(x => new RadioGroupItem { Description = x.Name, Value = x.Name }).ToArray());
                switch (layoutType)
                {
                    case LayoutType.Sales:
                        //radioGroup1.EditValue = Program.My_Setting.Properties.Settings.Default.SelectedSalesInvoiceLayout;
                        break;
                    case LayoutType.POS:
                        //radioGroup1.EditValue = Properties.Settings.Default.SelectedPOSLayout;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (radioGroup1.EditValue is string value)
            {
                //new ReportEndUserForm("\\"+ value).Show();
                //switch (layoutType)
                //{
                //    case LayoutType.Sales:
                //        Properties.Settings.Default.SelectedSalesInvoiceLayout = value;
                //        break;
                //    case LayoutType.POS:
                //        Properties.Settings.Default.SelectedPOSLayout = value;
                //        break;
                //    default:
                //        break;
                //}
                //Properties.Settings.Default.Save();
            }
            this.Close();
        }
    }
}