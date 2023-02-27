using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Migrations;
using DevExpress.XtraEditors.Controls;

namespace AccountingMS.Forms
{
    public partial class frmReptotalselmandob : DevExpress.XtraEditors.XtraForm
    {
        // accountingEntities db = new accountingEntities();

        public frmReptotalselmandob()
        {
            InitializeComponent();
        }

        private void chektextEdit_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmRepReport_Load(object sender, EventArgs e)
        {
            datefirt.Text = DateTime.Now.ToString($"yyyy/MM/dd");
            datelast.Text = DateTime.Now.ToString($"yyyy/MM/dd");
            using (accountingEntities db = new accountingEntities())
            {
                tblRepresentativeBindingSource.DataSource = db.tblRepresentatives.ToList();
                datafill();
            }

            rdtextEdit.Properties.Items.AddRange(DiscountTypeList);
            rdtextEdit.SelectedIndex = 0;

            //radioGroup1.Properties.Items.AddRange(StateTypeList);
            //radioGroup1.SelectedIndex = 0;
            //stateAndDescName();
            //maxOffersProducts();
        }

        public RadioGroupItem[] DiscountTypeList ={
                new RadioGroupItem() { Value = (int)DiscountType.OnProduct  , Description  =(MySetting.GetPrivateSetting.LangEng)?"commission value":" قيمة العمولة" },
                new RadioGroupItem() { Value = (int)DiscountType.OnInvoice  , Description  =(MySetting.GetPrivateSetting.LangEng)?"commission rate":"نسبة العمولة  " },

        };
        public void datafill()
        {
            if (realvaluetextEdit.Text == "0" || realvaluetextEdit.Text.Trim()== string.Empty.Trim())
            {
                realvaluetextEdit.ErrorText = "ادخل المبلغ الذي يجب تحقيقة";
                return;
            }
            else
            {
                realvaluetextEdit.ErrorText = null;
            }

            if (valucommtextEdit.Text == "0" || valucommtextEdit.Text.Trim() == string.Empty.Trim())
            {
                valucommtextEdit.ErrorText = "ادخل قيمة أو نسبة العمولة";
                return;
            }
            else
            {
                valucommtextEdit.ErrorText = null;
            }
            using (accountingEntities db = new accountingEntities())
            {
                try
                {
                    tblSupplyMainBindingSource.Clear();
                    var datestar = datefirt.Value;
                    var dateend = datelast.Value;

                    var tallFatora = db.tblSupplyMains.ToList().Where(a => a.supDate.Value.Date >= datestar && a.supDate.Value.Date <= dateend && a.reprID == Convert.ToInt32(MandobNametEdit.EditValue));
                    tblSupplyMainBindingSource.DataSource = tallFatora;
                    totalseltextEdit.Text = db.tblSupplyMains.ToList().Where(a => a.supDate.Value.Date >= datestar && a.supDate.Value.Date <= dateend && a.reprID == Convert.ToInt32(MandobNametEdit.EditValue)).Sum(d => d.net).ToString();
                }
                catch (Exception)
                {

                }
            }
            calselmandob();

        }

        private void MandobNametEdit_EditValueChanged(object sender, EventArgs e)
        {

            datafill();

        }

        private void datefirt_BackgroundImageChanged(object sender, EventArgs e)
        {
            datafill();
        }

        private void datefirt_EditValueChanged(object sender, EventArgs e)
        {
            datafill();

        }


        private void simpleButton2_Click(object sender, EventArgs e)
        {
            datafill();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            datafill();
        }

        private void datefirt_ValueChanged(object sender, EventArgs e)
        {
            datafill();
        }

        private void repcompTextEdit1_EditValueChanged(object sender, EventArgs e)
        {
            using (accountingEntities db = new accountingEntities())
            {
                //  var repName = db.View_repComm.ToList().Where(m => m.idrepcom == Convert.ToInt32(repcompTextEdit1.EditValue));
                //   MandobNametEdit.Properties.DataSource = repName.Select(c => new { c.RepId, c.repName }).Distinct().ToList();
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            datafill();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            datafill();
            using (ReportForm frmr = new ReportForm(null))
            {
                Reports.Reporttalselmandob rep = new Reports.Reporttalselmandob();
                rep.xrTableCell4.Text = MandobNametEdit.Text;
                rep.xrTableCell6.Text = calselvaluetextEdit.Text;
                rep.xrTitelName.Text = " تقرير تفصيلى عن عمولة الاستاذ/ "
                    + MandobNametEdit.Text
                    + " من تاريخ "
                   + datefirt.Value.ToString("yyyy/MM/dd")
                   + " الى تاريخ "
                   + datelast.Value.ToString("yyyy/MM/dd");
                rep.DataSource = gridView2.DataSource;
                rep.RequestParameters = false;
                frmr.documentViewer1.DocumentSource = rep;

                frmr.ShowDialog();
            }

        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void rdtextEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rdtextEdit.SelectedIndex)
            {
                case 0://قيمة
                    layoutControlItem4.Text = "المبلغ المتفق عليه";
                    break;
                case 1://نسبة
                    layoutControlItem4.Text = "النسبة المتفق عليه";

                    break;
            }
        }
        void calselmandob()
        {
            if (rdtextEdit.SelectedIndex == 0)
            {
                calselvaluetextEdit.Text = Convert.ToString((Convert.ToDouble(totalseltextEdit.Text) * Convert.ToDouble(valucommtextEdit.Text)) / Convert.ToDouble(realvaluetextEdit.Text));
                calselvaluetextEdit.Text = Math.Round(Convert.ToDouble(calselvaluetextEdit.Text), 2).ToString();
            }
            else if (rdtextEdit.SelectedIndex == 1)
            {
                double vtotal = (Convert.ToDouble(totalseltextEdit.Text) * Convert.ToDouble(valucommtextEdit.Text)) / 100;
                // calselvaluetextEdit.Text = Convert.ToString((Convert.ToDouble(totalseltextEdit.Text) * v) / Convert.ToDouble(realvaluetextEdit.Text));
                calselvaluetextEdit.Text = Math.Round(vtotal, 2).ToString();

            }


        }
    }
}