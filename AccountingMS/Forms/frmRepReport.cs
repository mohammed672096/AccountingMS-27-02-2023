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
    public partial class frmRepReport : DevExpress.XtraEditors.XtraForm
    {
        // accountingEntities db = new accountingEntities();

        public frmRepReport()
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
                MandobNametEdit.Properties.DataSource = (from Rep in db.tblRepresentatives.ToList() select new { repName = Rep.repName });
                MandobNametEdit.Properties.DisplayMember = "repName";
                MandobNametEdit.Properties.ValueMember = "repName";


                radioGroup1.SelectedIndex = 0;
                // TODO: This line of code loads data into the 'repeoresentativeDataSet1.tblRepresentative' table. You can move, or remove it, as needed.
                // this.tblRepresentativeTableAdapter.Fill(this.repeoresentativeDataSet1.tblRepresentative);
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

                    var datestar = datefirt.Value.Date;
                    var dateend = datelast.Value.Date;

                    if (radioGroup1.SelectedIndex == 0)
                    {
                        var tall = db.View_profit.ToList().Where(a => a.supDate.Value.Date >= datestar && a.supDate.Value.Date <= dateend).GroupBy(i => new { i.repName })
                                                                 .Select(s => new
                                                                 {
                                                                     s.Key.repName,
                                                                     supTotal = Math.Round(Convert.ToDecimal(s.Sum(g => (g.supTotal))), 2),
                                                                     supTaxPrice = Math.Round(Convert.ToDecimal(s.Sum(g => g.supTaxPrice)), 2)
                                                                                    ,
                                                                     commission = Math.Round(Convert.ToDecimal(s.Sum(g => g.commission)), 2)
                                                                 });
                        gridControl2.DataSource = tall;
                        gridControl2.Visible = true;
                        gridControl1.Visible = false;
                    }
                    else
                    {
                        if (MandobNametEdit.ItemIndex < 0)
                        {
                            return;
                        }

                        tblSupplyMainBindingSource.DataSource = db.View_profit.ToList().Where(a => a.repName == MandobNametEdit.Text && a.supDate.Value.Date >= datestar && a.supDate.Value.Date <= dateend);
                        // .Select({ s => s.repName , supTaxPrice }) ;
                        var cur = db.tblRepresentatives.FirstOrDefault(a => a.repName == MandobNametEdit.Text);
                        var currnsy = db.tblCurrencies.FirstOrDefault(a => a.id == cur.repCurrency);

                        textEdit5.Text = currnsy.curName.ToString();
                        repRatetextEdit.Text = cur.repRate.ToString();
                        gridControl2.Visible = false;
                        gridControl1.Visible = true;

                    }
                }
                catch (Exception)
                {

                }
            }

        }

        void commissionFill()
        {
            try
            {
                if (gridView1.RowCount > 0)
                {


                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        gridView1.FocusedRowHandle = i;
                        var dd = 0;
                        //  dd = gridView1.GetRowCellValue(i, "colsupTaxPrice") ;
                        dd = 55;

                        //gridView1.SetRowCellValue(i, commissionfaild, dd) ;
                        // gridView1.SetRowCellValue(i, "commissionfaild" , dd) ;
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "commission", dd);
                        gridView1.UpdateCurrentRow();

                        //gridView1.UpdateCurrentRow();
                        //gridView1.RefreshData();
                    }

                }

            }
            catch (Exception)
            {


            }


        }

        private void MandobNametEdit_EditValueChanged(object sender, EventArgs e)
        {
            datafill();
            repRatetextEdit_EditValueChanged(null, null);
        }

        private void datefirt_BackgroundImageChanged(object sender, EventArgs e)
        {
            datafill();
        }

        private void datefirt_EditValueChanged(object sender, EventArgs e)
        {
            datafill();
            repRatetextEdit_EditValueChanged(null, null);
        }

        private void datelast_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //if (radioGroup1.SelectedIndex == 0)
            //    gridControl2.ShowRibbonPrintPreview();
            //else
            //    gridControl1.ShowRibbonPrintPreview();
            // AccountingMS. Reports.ReporrtForm frmr = new Reports.ReportForm();

            using (ReportForm frmr = new ReportForm(null))
            {

                if (radioGroup1.SelectedIndex == 0)
                {
                    Reports.ReportRepresentativeSum rep = new Reports.ReportRepresentativeSum();
                    rep.xrTitelName.Text = " تقرير عن اجمالى عمولة مندوب من تاريخ"
                        + datefirt.Value.ToString("yyyy/MM/dd")
                        + " الى تاريخ "
                        + datelast.Value.ToString("yyyy/MM/dd");

                    rep.DataSource = gridView2.DataSource;
                    rep.RequestParameters = false;
                    frmr.documentViewer1.DocumentSource = rep;

                }
                else
                {
                    Reports.ReportRepresentative rep = new Reports.ReportRepresentative();
                    rep.xrTitelName.Text = " تقرير تفصيلى عن عمولة الاستاذ/ "
                        + MandobNametEdit.Text
                        + " من تاريخ "
                       + datefirt.Value.ToString("yyyy/MM/dd")
                       + " الى تاريخ "
                       + datelast.Value.ToString("yyyy/MM/dd");


                    rep.DataSource = gridView1.DataSource;
                    rep.RequestParameters = false;
                    frmr.documentViewer1.DocumentSource = rep;

                }


                frmr.ShowDialog();
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                MandobNametEdit.Enabled = false;
                gridControl1.Visible = false;
                gridControl2.Visible = true;
            }
            else
            {
                MandobNametEdit.Enabled = true;
                gridControl1.Visible = true;
                gridControl2.Visible = false;
            }
            datafill();
            repRatetextEdit_EditValueChanged(null, null);
        }

        private void radioGroup1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (chektextEdit.Checked == true)
            //{
            //    MandobNametEdit.Enabled = false;
            //}
            //else
            //{
            //    MandobNametEdit.Enabled = true;
            //}
            //datafill();

            // var radioGroup = sender as RadioGroup;
            //if (e.Control)
            //    switch (e.KeyCode)
            //    {
            //        case Keys.D1:
            //            radioGroup.SelectedIndex = 0;
            //            break;
            //        case Keys.D2:
            //            radioGroup.SelectedIndex = 1;
            //            break;
            //    }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            datafill();
            repRatetextEdit_EditValueChanged(null, null);
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

        private void repRatetextEdit_EditValueChanged(object sender, EventArgs e)
        {
            //decimal comm = decimal.Parse(repRatetextEdit.Text);
            //if (comm > 0)
            //{
            //    try
            //    {
            //        if (radioGroup1.SelectedIndex == 0)
            //        {
            //            if (gridView2.RowCount > 0)
            //            {

            //                for (int i = 0; i < gridView2.RowCount; i++)
            //                {
            //                    decimal Prices = 0;
            //                    decimal Totals = 0;
            //                    Prices = Convert.ToDecimal(this.gridView2.GetRowCellValue(i, "supTaxPrice"));
            //                    Totals = Convert.ToDecimal(this.gridView2.GetRowCellValue(i, "supTotal"));
            //                    if (textEdit4.Checked == true)
            //                    {
            //                        decimal result = Math.Round((Totals * comm) / 100, 2);
            //                        this.gridView2.SetRowCellValue(i, "commission", result);

            //                    }
            //                    else
            //                    {
            //                        var result = Math.Round(((Totals - Prices) * comm) / 100, 2);
            //                        this.gridView2.SetRowCellValue(i, "commission".ToString(), result);
            //                        // string dataInCell = gridView2.Rows[i].Cells[j].Value.ToString();


            //                    }


            //                }

            //            }

            //        }
            //        else
            //        {


            //            if (gridView1.RowCount > 0)
            //            {

            //                for (int i = 0; i < gridView1.RowCount; i++)
            //                {
            //                    decimal Prices = 0;
            //                    decimal Totals = 0;
            //                    Prices = Convert.ToDecimal(this.gridView1.GetRowCellValue(i, "supTaxPrice"));
            //                    Totals = Convert.ToDecimal(this.gridView1.GetRowCellValue(i, "supTotal"));
            //                    if (textEdit4.Checked == true)
            //                    {
            //                        decimal result = Math.Round((Totals * comm) / 100, 2);
            //                        this.gridView1.SetRowCellValue(i, "commission", result);

            //                    }
            //                    else
            //                    {
            //                        var result = Math.Round(((Totals - Prices) * comm) / 100, 2);
            //                        this.gridView1.SetRowCellValue(i, "commission".ToString(), result);
            //                        // string dataInCell = gridView1.Rows[i].Cells[j].Value.ToString();


            //                    }


            //                }

            //            }
            //        }

            //    }
            //    catch (Exception)
            //    {


            //    }

            //}

        }

        private void textEdit4_CheckedChanged(object sender, EventArgs e)
        {
            repRatetextEdit_EditValueChanged(null, null);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            datafill();
            repRatetextEdit_EditValueChanged(null, null);
        }

        private void datefirt_ValueChanged(object sender, EventArgs e)
        {
            datafill();
            repRatetextEdit_EditValueChanged(null, null);
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            repRatetextEdit_EditValueChanged(null, null);
        }
    }
}