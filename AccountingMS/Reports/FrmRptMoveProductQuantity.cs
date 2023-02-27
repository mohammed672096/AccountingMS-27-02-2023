using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using System.IO;
using System.Data.Entity;
using AccountingMS.Classes;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Data;
using AccountingMS.Classe;

namespace AccountingMS.Report
{
    public partial class FrmRptMoveProductQuantity : DevExpress.XtraEditors.XtraForm
    {
        ClsAppearance clsAppearance = new ClsAppearance();
        public FrmRptMoveProductQuantity()
        {
            InitializeComponent();
            gridView.MasterRowGetRelationCount += GridView_MasterRowGetRelationCount;
            gridView.MasterRowEmpty += GridView_MasterRowEmpty;
            gridView.MasterRowGetChildList += GridView_MasterRowGetChildList;
            gridView.MasterRowGetRelationName += GridView_MasterRowGetRelationName;
            clsAppearance.AppearanceGridView(gridView);
            clsAppearance.AppearanceGridView(gridView1);
            gridView1.Appearance.EvenRow.BackColor = Color.WhiteSmoke;
            clsAppearance.LayoutAppearance(layoutControlGroup2);
            clsAppearance.LayoutAppearance(layoutControlGroup3);
            labelControl1.BackColor = layoutControlGroup3.AppearanceGroup.BorderColor;
            labelControl1.ForeColor = Color.White;
            textEditBarcodeNo.KeyDown += TextEditBarcodeNo_KeyDown;
        }

        private void TextEditBarcodeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(textEditBarcodeNo.Text))
                GetPrdBarcodeData(textEditBarcodeNo.Text);
            
        }
        MyFunaction myFunaction = new MyFunaction();
        private void GetPrdBarcodeData(string barcode)
        {
            barcode = myFunaction.ChickBarcodWaghit(barcode, out bool ProIsWaghit, out double value);
         tblProduct product= (from b in Session.tblBarcode
             join m in Session.tblPrdPriceMeasurment on b.brcPrdMsurId equals m.ppmId
             join p in Session.Products on m.ppmPrdId equals p.id
             where b.brcNo == barcode 
             select p).FirstOrDefault();
            if (product != null)
            {
                look_p1.EditValue = product?.id;
                textEditBarcodeNo.EditValue = null;
            }
            
        }
        private void GridView_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void GridView_MasterRowEmpty(object sender, MasterRowEmptyEventArgs e)
        {
            e.IsEmpty = false;
        }

        private void GridView_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Level1";
        }
        List<MoveProdQuantities> MoveProdsStokTo = new List<MoveProdQuantities>();
        List<MoveProdQuantities> MoveProdsStokFrom = new List<MoveProdQuantities>();
        List<MoveProdQuantities> MoveProdsExp = new List<MoveProdQuantities>();
        List<MoveProdQuantities> MoveProdsSupplySub = new List<MoveProdQuantities>();
        List<MoveProdQuantities> MoveProdsAll = new List<MoveProdQuantities>();
        private List<MoveProdQuantities> InitData(ReportProdQuantity reportProd)
        {
            MoveProdsSupplySub = (from M in db.tblSupplyMains.AsNoTracking().Where(x => x.supStatus != 15 && x.supStatus != 16 && x.supStatus != 17 && x.supStatus != 18
                                  && x.supDate >= dtime_Start.DateTime && x.supDate <= dtime_End.DateTime && x.supStrId == GetFouRepProdQuan.storId).ToList()
                                  join s in db.tblSupplySubs.AsNoTracking().Where(x => x.supPrdId == GetFouRepProdQuan.proId).ToList() on M.id equals s.supNo
                                  select new MoveProdQuantities
                                  {
                                      MusId = s.supMsur ?? 0,
                                      DocNo = M.supNo,
                                      Bayan = M.supDesc + " " + s.supDesc,
                                      MoveDate = M.supDate.Value,
                                      MoveType = ClsSupplyStatus.GetMoveString(s.supStatus),
                                      Price = (s.supStatus == 3 || s.supStatus == 7 || s.supStatus == 10 || s.supStatus == 9) ? s.supPrice : default,
                                      SalePrice = s.supSalePrice,
                                      Quantity = $"{s.supQuanMain} {UnitName(s.supMsur ?? 0)}"
                                  }).ToList();
            MoveProdsStokTo = (from r in StockTransMain.GetStockTransList
                               join subx in StockTransSub.tbStockTransSubList on r.stcId equals subx.stcMainId
                               where r.stcStrIdTo == GetFouRepProdQuan.storId && subx.stcPrdId == GetFouRepProdQuan.proId
                               && subx.stcDate >= dtime_Start.DateTime && subx.stcDate <= dtime_End.DateTime
                               select new MoveProdQuantities
                               {
                                   MusId = subx.stcMsurId,
                                   DocNo = r.stcNo,
                                   Bayan = r.stcDesc,
                                   MoveDate = r.stcDate,
                                   MoveType = "تحويل وارد",
                                   Quantity = $"{subx.stcQuantity} {UnitName(subx.stcMsurId)}"
                               }).ToList();
            MoveProdsStokFrom = (from r in StockTransMain.GetStockTransList
                                 join subx in StockTransSub.tbStockTransSubList on r.stcId equals subx.stcMainId
                                 where r.stcStrIdFrom == GetFouRepProdQuan.storId && subx.stcPrdId == GetFouRepProdQuan.proId
                                 && subx.stcDate >= dtime_Start.DateTime && subx.stcDate <= dtime_End.DateTime
                                 select new MoveProdQuantities
                                 {
                                     MusId = subx.stcMsurId,
                                     DocNo = r.stcNo,
                                     Bayan = r.stcDesc,
                                     MoveDate = r.stcDate,
                                     MoveType = "تحويل صادر",
                                     Quantity = $"{subx.stcQuantity} {UnitName(subx.stcMsurId)}"
                                 }).ToList();
            MoveProdsExp = (from exp in exp.GetPrdExpirateQuanList
                            where exp.expStrid == GetFouRepProdQuan.storId && exp.expPrdId == GetFouRepProdQuan.proId
                            && exp.expDate >= dtime_Start.DateTime && exp.expDate <= dtime_End.DateTime
                            select new MoveProdQuantities
                            {
                                MusId = exp.expPrdMsurId,
                                DocNo = exp.expMainId,
                                MoveDate = exp.expDate,
                                MoveType = "اصناف تالفة",
                                Price = exp.expPrdPrice,
                                SalePrice = exp.expPrdPrice,
                                Quantity = $"{exp.expQuan} {UnitName(exp.expPrdMsurId)}"
                            }).ToList();
            MoveProdsAll = MoveProdsStokTo;
            MoveProdsAll.AddRange(MoveProdsStokFrom);
            MoveProdsAll.AddRange(MoveProdsExp);
            MoveProdsAll.AddRange(MoveProdsSupplySub);
            return MoveProdsAll.OrderBy(x => x.MoveDate).ToList();
        }
        string UnitName(int unitID) => Session.tblPrdPriceMeasurment?.FirstOrDefault(x => x.ppmId == unitID)?.ppmMsurName;
        private void GridView_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            GetFouRepProdQuan.MoveProdQuan = (from r in StockTransMain.GetStockTransList
                                                         join subx in StockTransSub.tbStockTransSubList on r.stcId equals subx.stcMainId
                                                         where r.stcStrIdTo == GetFouRepProdQuan.storId && subx.stcPrdId == GetFouRepProdQuan.proId 
                                                         && subx.stcDate >= dtime_Start.DateTime && subx.stcDate <= dtime_End.DateTime
                                                         select new MoveProdQuantities
                                                         {
                                                             MusId = subx.stcMsurId,
                                                             DocNo = r.stcNo,
                                                             Bayan = r.stcDesc,
                                                             MoveDate = r.stcDate,
                                                             MoveType = "تحويل وارد",
                                                             Quantity = $"{subx.stcQuantity} {UnitName(subx.stcMsurId)}"
                                                         }).ToList();
            GetFouRepProdQuan.MoveProdQuan.AddRange((from r in StockTransMain.GetStockTransList
                                                               join subx in StockTransSub.tbStockTransSubList on r.stcId equals subx.stcMainId
                                                               where r.stcStrIdFrom == GetFouRepProdQuan.storId && subx.stcPrdId == GetFouRepProdQuan.proId 
                                                               && subx.stcDate >= dtime_Start.DateTime && subx.stcDate <= dtime_End.DateTime
                                                               select new MoveProdQuantities
                                                                {
                                                                    MusId = subx.stcMsurId,
                                                                    DocNo = r.stcNo,
                                                                    Bayan = r.stcDesc,
                                                                    MoveDate = r.stcDate,
                                                                    MoveType = "تحويل صادر",
                                                                   Quantity = $"{subx.stcQuantity} {UnitName(subx.stcMsurId)}"
                                                               }).ToList());
            GetFouRepProdQuan.MoveProdQuan.AddRange((from exp in exp.GetPrdExpirateQuanList
                                                                where exp.expStrid == GetFouRepProdQuan.storId && exp.expPrdId == GetFouRepProdQuan.proId 
                                                                && exp.expDate >= dtime_Start.DateTime && exp.expDate <= dtime_End.DateTime
                                                                select new MoveProdQuantities
                                                                {
                                                                    MusId = exp.expPrdMsurId,
                                                                    DocNo = exp.expMainId,
                                                                    MoveDate = exp.expDate,
                                                                    MoveType = "اصناف تالفة",
                                                                    Price = exp.expPrdPrice,
                                                                    SalePrice = exp.expPrdPrice,
                                                                    Quantity = $"{exp.expQuan} {UnitName(exp.expPrdMsurId)}"
                                                                }).ToList());
            GetFouRepProdQuan.MoveProdQuan.AddRange((from M in db.tblSupplyMains.AsNoTracking().Where(x => x.supStatus != 15 && x.supStatus != 16 && x.supStatus != 17 && x.supStatus != 18
                                                     && x.supDate >= dtime_Start.DateTime && x.supDate <= dtime_End.DateTime &&x.supStrId == GetFouRepProdQuan.storId).ToList()
                                                     join s in db.tblSupplySubs.AsNoTracking().Where(x => x.supPrdId == GetFouRepProdQuan.proId).ToList() on M.id equals s.supNo
                                                     select new MoveProdQuantities
                                                     {
                                                         MusId = s.supMsur ?? 0,
                                                         DocNo = M.supNo,
                                                         Bayan = M.supDesc + " " + s.supDesc,
                                                         MoveDate = M.supDate.Value,
                                                         MoveType = ClsSupplyStatus.GetMoveString(s.supStatus),
                                                         Price = (s.supStatus == 3 || s.supStatus == 7 || s.supStatus == 10 || s.supStatus == 9) ? s.supPrice : default,
                                                         SalePrice = s.supSalePrice,
                                                         Quantity = $"{s.supQuanMain} {UnitName(s.supMsur ?? 0)}"
                                                     }).ToList());
            int I = 1;
            var ff = bindingSource1.Current as ReportProdQuantity;
            GetFouRepProdQuan.MoveProdQuan = (from M in GetFouRepProdQuan.MoveProdQuan.OrderBy(x => x.MoveDate).ToList()
                                                         select new MoveProdQuantities
                                                         {
                                                             MusId = M.MusId,
                                                             Index = I++,
                                                             DocNo = M.DocNo,
                                                             Bayan = M.Bayan,
                                                             MoveDate = M.MoveDate,
                                                             MoveType = M.MoveType,
                                                             Price = M.Price,
                                                             SalePrice = M.SalePrice,
                                                             Quantity = M.Quantity
                                                         }).ToList();

            e.ChildList = GetFouRepProdQuan.MoveProdQuan.ToList();

        }
        private ReportProdQuantity GetFouRepProdQuan => gridView.GetFocusedRow() as ReportProdQuantity;
        List<RepMoveProduct_Result> report2;
        List<ReportProdQuantity> filter;
        int id1 = 0, id2 = 0;
        public void RefreshData()
        {
            var temp = filter;
            id1 = ((look_p1.EditValue as int?) ?? 0);
            id2 = ((look_p2.EditValue as int?) ?? 0);
            if (temp.Count() > 0)
            {
                if (id1 == 0 & id2 > 0)
                    temp = temp.Where(p => p.proId == id2).ToList();
                else if (id2 == 0 & id1 > 0)
                    temp = temp.Where(p => p.proId == id1).ToList();
                else if (id1 > 0 & id2 > 0)
                    temp = temp.Where(p => p.proId >= id1 & p.proId <= id2).ToList();

                int g1 = ((look_G.EditValue as int?) ?? 0);
                int g2 = ((look_G1.EditValue as int?) ?? 0);
                if (g1 == 0 & g2 > 0)
                    temp = temp.Where(p => p.GroId == g2).ToList();
                else if (g2 == 0 & g1 > 0)
                    temp = temp.Where(p => p.GroId == g1).ToList();
                else if (g1 > 0 & g2 > 0)
                    temp = temp.Where(p => p.GroId >= g1 & p.GroId <= g2).ToList();

                short s1 = ((look_S.EditValue as short?) ?? 0);
                short s2 = ((look_S2.EditValue as short?) ?? 0);
                if (s1 == 0 & s2 > 0)
                    temp = temp.Where(p => p.storId == s2).ToList();
                else if (s2 == 0 & s1 > 0)
                    temp = temp.Where(p => p.storId == s1).ToList();
                else if (s1 > 0 & s2 > 0)
                    temp = temp.Where(p => p.storId >= s1 & p.storId <= s2).ToList();
            }

            var maxx = temp.Max(m => m.QuaSale);//الاكثر مبيعا
            var minx = temp.Where(y => y.QuaSale != 0).Min(m => m.QuaSale);//الاقل مبيعا
           // var zirom = temp.Where(y => y.QuaSale == 0);//الذى لم يباع

            if (bestSellercheckEdit.Checked == true && lowestSellingcheckEdit.Checked == true && whichNotSoldcheckEdit.Checked == true)
            {
                bindingSource1.DataSource = temp.Where(m => m.QuaSale == maxx || m.QuaSale == minx || m.QuaSale == 0).OrderByDescending(m => m.QuaSale);
                gridView.OptionsView.ShowFooter = true; return;
            }

            if (bestSellercheckEdit.Checked == true && lowestSellingcheckEdit.Checked == true)
            {
                bindingSource1.DataSource = temp.Where(m => m.QuaSale == maxx || m.QuaSale == minx).OrderByDescending(m => m.QuaSale);
                gridView.OptionsView.ShowFooter = true; return;
            }

            if (bestSellercheckEdit.Checked == true && whichNotSoldcheckEdit.Checked == true)
            {
                bindingSource1.DataSource = temp.Where(m => m.QuaSale == maxx || m.QuaSale == 0).OrderByDescending(m => m.QuaSale);
                gridView.OptionsView.ShowFooter = true; return;
            }
             if (lowestSellingcheckEdit.Checked == true && whichNotSoldcheckEdit.Checked == true)
            {
                bindingSource1.DataSource = temp.Where(m => m.QuaSale == minx || m.QuaSale == 0).OrderByDescending(m => m.QuaSale);
                gridView.OptionsView.ShowFooter = true; return;
            }

            if (bestSellercheckEdit.Checked == true)
            {
                //bindingSource1.DataSource = temp.Where(m => m.QuaSale == maxx);
                bindingSource1.DataSource = temp.Where(m => m.QuaSale != 0).OrderByDescending(m => m.QuaSale).Take(10);
                gridView.OptionsView.ShowFooter = true; return;
            }
            if (lowestSellingcheckEdit.Checked == true)
            {
                //bindingSource1.DataSource = temp.Where(m => m.QuaSale == minx);
                bindingSource1.DataSource = temp.Where(m => m.QuaSale != 0).OrderBy(m => m.QuaSale).Take(10);
                gridView.OptionsView.ShowFooter = true; return;
            }

            if (whichNotSoldcheckEdit.Checked == true)
            {
                bindingSource1.DataSource = temp.Where(m => m.QuaSale ==0);
                gridView.OptionsView.ShowFooter = true; return;
            }

            bindingSource1.DataSource = temp.OrderBy(x => x.proId);
            gridView.OptionsView.ShowFooter = true;

        }
        ReportProductsMove1 rprtPrdMove;
        private void Print_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            RReportTypesFun();
            new ReportForm(rprtPrdMove).Show();
            flyDialog.WaitForm(this, 0);
        }
        public void Print(object ds)
        {
            rprtPrdMove = new ReportProductsMove1();
            new ClsReportHeaderData(rprtPrdMove);
            rprtPrdMove.xrLabelH.Text = ((id1 == 0 && id2 == 0) ? "الاصناف:الكل ," : (id2 == 0) ? $"الصنف :{(look_p1.GetSelectedDataRow() as tblProduct).prdName} ," : "")
               + $"من تاريخ {dtime_Start.Text} الى تاريخ {dtime_End.Text}";
            rprtPrdMove.TopMargin.HeightF -= 25;
            rprtPrdMove.PrintingSystem.ContinuousPageNumbering = true;
            rprtPrdMove.DataSource = ds;
            rprtPrdMove.DetailReport.Visible = !(bool)radioGroup1.EditValue;
            rprtPrdMove.DetailReport.DataSource = rprtPrdMove.DataSource;
            rprtPrdMove.DetailReport.DataMember = "MoveProdQuan1";
            rprtPrdMove.BindData();
            rprtPrdMove.CreateDocument();
        }
        public void RReportTypesFun()
        {
            var ff = bindingSource1.List as IList<ReportProdQuantity>;
            var reportProdQuantities = (from d in ff
                                        select new //ReportProdQuantity
                                        {
                                            prdNo = d.prdNo,
                                            prdName = d.prdName,
                                            grpName = d.grpName,
                                            //ppmMsurName = d.ppmMsurName,
                                            strName = d.strName,
                                            QuFrist = d.QuFrist,
                                            QuaBuy = d.QuaBuy,
                                            QStrIdTo = d.QStrIdTo,
                                            QuaBuyRet = d.QuaBuyRet,
                                            QuaSale = d.QuaSale,
                                            QStrIdFrom = d.QStrIdFrom,
                                            QuaSaleRet = d.QuaSaleRet,
                                            QuaExper = d.QuaExper,
                                            QLast = d.QLast,
                                            proId = d.proId,
                                            GroId = d.GroId,
                                            MusId = d.MusId,
                                            storId = d.storId,
                                            MoveProdQuan1 = !(bool)radioGroup1.EditValue ? InitData(d) : null
                                        }).ToList();
            Print(reportProdQuantities);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ExportPDF_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            RReportTypesFun();
            xtraSaveFileDialog1.Filter = "PDF Files|*.pdf";
            if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
                rprtPrdMove.ExportToPdf(xtraSaveFileDialog1.FileName);
            flyDialog.WaitForm(this, 0);
        }

        private void Refreash_Click(object sender, EventArgs e)
        {
            look_p2.EditValue = null;
            look_G1.EditValue = null;
            look_S.EditValue = null;
            look_p1.EditValue = null;
            look_S2.EditValue = null;
            look_G.EditValue = null;
            RefreshData();
        }
        private void Dtime_Start_EditValueChanged(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            LoadData();
            flyDialog.WaitForm(this, 0);
        }
        private void ExportExcel_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            RReportTypesFun();
            xtraSaveFileDialog1.Filter = "Excel Files|*.Xls";
            if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
                rprtPrdMove.ExportToXls(xtraSaveFileDialog1.FileName);
            flyDialog.WaitForm(this, 0);
        }
        ClsTblSupplySub SubList;
        ClsTblPrdExpirateQuan exp;
        ClsTblStockTransSub StockTransSub;
        ClsTblStockTransMain StockTransMain;
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();

        private void LoadData()
        {
            using (var db=new accountingEntities())
                report2 = db.RepMoveProduct(dtime_Start.DateTime, dtime_End.DateTime).ToList();
            filter = (from d in report2
                        select new ReportProdQuantity
                        {
                            prdNo = d.prdNo,
                            prdName = d.prdName,
                            grpName =d.grpNo+" - "+d.grpName,
                            strName = d.strNo + " - " + d.strName,
                            QuFrist = d.QuFrist,
                            QuaBuy = d.QuPur,
                            QStrIdTo = d.QStrTo,
                            QuaBuyRet = d.QuPurRet,
                            QuaSale = d.QuSale,
                            QStrIdFrom = d.QStrFrom,
                            QuaSaleRet = d.QuSaleRet,
                            QuaExper = d.ExpirateQuan,
                            QLast = d.prdQuantity,
                            proId = d.ProductID,
                            GroId = d.GroupID,
                            storId = d.StoreId,
                            QuaInvStore=d.QuInvStore
                        }).Distinct().ToList();
            bindingSource1.DataSource = filter.OrderBy(x => x.proId);
            RefreshData();
        }
        public class MoveProdQuantities
        {
            public int MusId { get; set; }
            public int? Index { get; set; }
            public string MoveType { get; set; }
            public int? DocNo { get; set; }
            public string Bayan { get; set; }
            public string Quantity { get; set; }
            public double? Price { get; set; }
            public double? SalePrice { get; set; }
            public DateTime MoveDate { get; set; }
        }
        public class ReportProdQuantity
        {
            public short storId { get; set; }
            public int proId { get; set; }
            public int MusId { get; set; }
            public int GroId { get; set; }
            [DisplayName("رقم الصنف")]
            public string prdNo { get; set; }
            [DisplayName("إسم الصنف")]
            public string prdName { get; set; }
            [DisplayName("المجموعة")]
            public string grpName { get; set; }
            [DisplayName("المخزن")]
            public string strName { get; set; }
            [DisplayName("كمية رصيد اول")]
            public double? QuFrist { get; set; }
            [DisplayName("كمية مشتريات")]
            public double? QuaBuy { get; set; }
            [DisplayName("كمية مردود مشتريات")]
            public double? QuaBuyRet { get; set; }
            [DisplayName("كمية مبيعات")]
            public double? QuaSale { get; set; }
            [DisplayName("كمية مردود مبيعات")]
            public double? QuaSaleRet { get; set; }
            [DisplayName("كمية تحويل وارد")]
            public double? QStrIdTo { get; set; }
            [DisplayName("كمية تحويل صادر")]
            public double? QStrIdFrom { get; set; }
            [DisplayName("كمية جرد مخزني")]
            public double? QuaInvStore { get; set; }
            [DisplayName("كمية تالف")]
            public double? QuaExper { get; set; }
            [DisplayName("كمية رصيد اخر")]
            public double? QLast { get; set; }
            public List<MoveProdQuantities> MoveProdQuan { get; set; }
        }
        //ClsTblSupplyMain TblSupplyMain;
        //List<tblSupplyMain> tblSupplyMains;
        //List<tblSupplySub> tblSupplySubs;
        accountingEntities db = new accountingEntities();
        private async void XtraFormReportsByDate_Load(object sender, EventArgs e)
        {
            dtime_End.EditValue = Session.CurrentYear.fyDateEnd;
            dtime_Start.EditValue = Session.CurrentYear.fyDateStart;
            flyDialog.WaitForm(this, 1);
            IList<Task> taskList = new List<Task>();
            taskList.Add(Task.Run(() => SubList = new ClsTblSupplySub()));
            //taskList.Add(Task.Run(() => TblSupplyMain = new ClsTblSupplyMain()));
            taskList.Add(Task.Run(() => exp = new ClsTblPrdExpirateQuan()));
            taskList.Add(Task.Run(() => StockTransSub = new ClsTblStockTransSub()));
            taskList.Add(Task.Run(() => StockTransMain = new ClsTblStockTransMain()));
            await Task.WhenAll(taskList);
            //IList<Task> taskList1 = new List<Task>();
            //taskList1.Add(Task.Run(() => tblSupplyMains = TblSupplyMain.GetSupplyMainListPurchaseNdSale()));
            //taskList1.Add(Task.Run(() => tblSupplySubs = SubList.GetSupplySubList.ToList()));
            //await Task.WhenAll(taskList1);
            look_p1.Properties.DataSource = Session.Products.OrderBy(x => x.id);
            look_p2.Properties.DataSource = Session.Products.OrderBy(x => x.id);
            look_G.Properties.DataSource = Session.tblGroupStr;
            look_G1.Properties.DataSource = Session.tblGroupStr;
            look_S.Properties.DataSource = Session.tblStore;
            look_S2.Properties.DataSource =Session.tblStore;
            LoadData();
            ReportProdQuantity f = new ReportProdQuantity();
            foreach (GridColumn item in gridView.Columns)
            {
                if (item.FieldName == nameof(f.storId) | item.FieldName == nameof(f.proId) |
                     item.FieldName == nameof(f.GroId) | item.FieldName == nameof(f.MusId))
                    item.Visible = false;
            }
            flyDialog.WaitForm(this, 0);
        }

        private void bestSellercheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            Refreash_Click(null, null);
        }

        private void look_p1_EditValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}