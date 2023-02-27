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

namespace AccountingMS.Forms
{
    public partial class frmRepProductCommReport : DevExpress.XtraEditors.XtraForm
    {
        // accountingEntities db = new accountingEntities();

        public frmRepProductCommReport()
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
                //MandobNametEdit.Properties.DataSource = (from Rep in db.tblRepresentatives.ToList() select new { repName = Rep.repName });
                //MandobNametEdit.Properties.DisplayMember = "repName";
                //MandobNametEdit.Properties.ValueMember = "repName";
                repcompTextEdit1.Properties.DataSource = db.RepCommissions.ToList();
                // radioGroup1.SelectedIndex = 0;
                datafill();
            }
        }

        //ClsTblSupplyMain clsTbSupplyMain;
        public void supplymaindetails()
        {
            //var tbSupplyMainDetailList = (from tbSupplyMain in this.clsTbSupplyMain.GetSupplyMainListSaleByDtStartEnd(this.dtStart, this.dtEnd)
            //                              where (accNo != 0 ? tbSupplyMain.supAccNo == accNo : tbSupplyMain.supIsCash == 2)
            //                              join tbSupplySub in db.tblSupplySubs
            //                              on tbSupplyMain.id equals tbSupplySub.supNo into tbSupplyMainDetail1
            //                              select new
            //                              {
            //                                  itbSupplyMain = tbSupplyMain as ItblSupplyMainDetail,
            //                                  prdPrice = tbSupplyMainDetail1.Sum(x => Convert.ToDecimal(x.supPrice) * Convert.ToDecimal(x.supQuanMain)),
            //                                  sPrice = tbSupplyMainDetail1.Sum(x => Convert.ToDecimal(x.supSalePrice) * Convert.ToDecimal(x.supQuanMain)),
            //                              }).ToList();



        }


        public void datafill()
        {
            using (accountingEntities db = new accountingEntities())
            {
                try
                {
                    tblSupplyMainBindingSource.Clear();
                    var datestar = datefirt.Value;
                    var dateend = datelast.Value;

                    var tallFatora = db.View_repCommReport.ToList().Where(a => a.supDate.Date >= datestar && a.supDate.Date <= dateend && a.RepId == Convert.ToInt32(MandobNametEdit.EditValue));
                    gridControl1.DataSource = tallFatora;
                }
                catch (Exception)
                {

                }
            }

        }

        private void MandobNametEdit_EditValueChanged(object sender, EventArgs e)
        {
            //  
            //textEdit1
            //using (accountingEntities db = new accountingEntities())
            //{
            //    var prd = db.View_repComm.ToList().Where(m => m.RepId == Convert.ToInt32(MandobNametEdit.EditValue));

            //    prdtextEdit.Properties.DataSource = prd;
            //    datafill();
            //}
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

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //try
            //{
            //    if (gridView1.RowCount > 0)
            //    {

            //        var dbMandob = db.tblSupplyMains.ToList();
            //        var datestar = DateTime.Parse(datefirt.Text);
            //        var dateend = DateTime.Parse(datelast.Text);

            //        if (radioGroup1.SelectedIndex == 0)
            //        {
            //            dbMandob = db.tblSupplyMains.ToList().FindAll(a => a.supDate >= datestar && a.supDate <= dateend);
            //        }
            //        else
            //        {
            //            dbMandob = db.tblSupplyMains.ToList().FindAll(a => a.repName == MandobNametEdit.Text && a.supDate >= datestar && a.supDate <= dateend);
            //        }

            //        for (int i = 0; i < dbMandob.Count ; i++)
            //        {
            //            dbMandob.ElementAt(i).commission = 5;
            //            db.SaveChanges();
            //                              }

            //    }

            //}
            //catch (Exception)
            //{


            //}
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            datafill();
        }

        private void datefirt_ValueChanged(object sender, EventArgs e)
        {
            datafill();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void repcompTextEdit1_EditValueChanged(object sender, EventArgs e)
        {
            using (accountingEntities db = new accountingEntities())
            {
                var repName = db.View_repComm.ToList().Where(m => m.idrepcom == Convert.ToInt32(repcompTextEdit1.EditValue));
                MandobNametEdit.Properties.DataSource = repName.Select(c => new { c.RepId, c.repName }).Distinct().ToList();
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            datafill();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }
    }
}