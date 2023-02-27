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
using PosFinalCost.Classe;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Data;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace PosFinalCost.Report
{
    public partial class XtraFormReportsInvBuy : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormReportsInvBuy()
        {
            InitializeComponent();
            gridView.MasterRowGetRelationCount += GridView_MasterRowGetRelationCount;
            gridView.MasterRowEmpty += GridView_MasterRowEmpty;
            gridView.MasterRowGetChildList += GridView_MasterRowGetChildList;
            gridView.MasterRowGetRelationName += GridView_MasterRowGetRelationName;
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
        private void GridView_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            //GetFoucsedReportProdQuantity.MoveProdQuan = (from r in StockTransMain.GetStockTransList
            //                                                   join subx in StockTransSub.tbStockTransSubList on r.stcId equals subx.stcMainId
            //                                                   where r.stcStrIdTo == GetFoucsedReportProdQuantity.storId && subx.stcMsurId == GetFoucsedReportProdQuantity.MusId
            //                                                && subx.stcPrdId == GetFoucsedReportProdQuantity.proId && subx.stcDate >= dtime_Start.DateTime && subx.stcDate <= dtime_End.DateTime
            //                                                   select new MoveProdQuantities
            //                                                   {
            //                                                       MusId = GetFoucsedReportProdQuantity.MusId,
            //                                                       DocNo = r.stcNo,
            //                                                       Bayan = r.stcDesc,
            //                                                       MoveDate = r.stcDate,
            //                                                       MoveType = "تحويل وارد",
            //                                                       Quantity = subx.stcQuantity
            //                                                   }).ToList();
            //GetFoucsedReportProdQuantity.MoveProdQuan.AddRange((from r in StockTransMain.GetStockTransList
            //                                                          join subx in StockTransSub.tbStockTransSubList on r.stcId equals subx.stcMainId
            //                                                          where r.stcStrIdFrom == GetFoucsedReportProdQuantity.storId && subx.stcMsurId == GetFoucsedReportProdQuantity.MusId
            //                                                       && subx.stcPrdId == GetFoucsedReportProdQuantity.proId && subx.stcDate >= dtime_Start.DateTime && subx.stcDate <= dtime_End.DateTime
            //                                                          select new MoveProdQuantities
            //                                                          {
            //                                                              MusId = GetFoucsedReportProdQuantity.MusId,
            //                                                              DocNo = r.stcNo,
            //                                                              Bayan = r.stcDesc,
            //                                                              MoveDate = r.stcDate,
            //                                                              MoveType = "تحويل صادر",
            //                                                              Quantity = subx.stcQuantity
            //                                                          }).ToList());
            //GetFoucsedReportProdQuantity.MoveProdQuan.AddRange((from exp in exp.GetPrdExpirateQuanList
            //                                                          where exp.expStrid == GetFoucsedReportProdQuantity.storId && exp.expPrdMsurId == GetFoucsedReportProdQuantity.MusId
            //                                                           && exp.expPrdId == GetFoucsedReportProdQuantity.proId && exp.expDate >= dtime_Start.DateTime && exp.expDate <= dtime_End.DateTime
            //                                                          select new MoveProdQuantities
            //                                                          {
            //                                                              MusId = GetFoucsedReportProdQuantity.MusId,
            //                                                              DocNo = exp.expMainId,
            //                                                              MoveDate = exp.expDate,
            //                                                              MoveType = "اصناف تالفة",
            //                                                              Price = exp.expPrdPrice,
            //                                                              SalePrice = exp.expPrdPrice,
            //                                                              Quantity = exp.expQuan
            //                                                          }).ToList());
            //GetFoucsedReportProdQuantity.MoveProdQuan.AddRange((from M in tblSupplyMains
            //                                                          join s in tblSupplySubs on M.id equals s.supNo
            //                                                          where M.supStrId == GetFoucsedReportProdQuantity.storId && s.supMsur == GetFoucsedReportProdQuantity.MusId
            //                                                          && s.supPrdId == GetFoucsedReportProdQuantity.proId && M.supDate >= dtime_Start.DateTime && M.supDate <= dtime_End.DateTime
            //                                                          select new MoveProdQuantities
            //                                                          {
            //                                                              MusId = GetFoucsedReportProdQuantity.MusId,
            //                                                              DocNo = M.supNo,
            //                                                              Bayan = M.supDesc + " " + s.supDesc,
            //                                                              MoveDate = M.supDate.Value,
            //                                                              MoveType = ClsSupplyStatus.GetMoveString(s.supStatus),
            //                                                              Price = (s.supStatus == 3 || s.supStatus == 7 || s.supStatus == 10 || s.supStatus == 9) ? s.supPrice : default,
            //                                                              SalePrice = s.supSalePrice,
            //                                                              Quantity = s.supQuanMain
            //                                                          }).ToList());
            int I = 1; 
            var ff = bindingSource1.Current as ReportProdQuantity;
            GetFoucsedReportProdQuantity.MoveProdQuan = (from M in GetFoucsedReportProdQuantity.MoveProdQuan.OrderBy(x => x.MoveDate).ToList()
                           select new MoveProdQuantities
                           {   MusId= GetFoucsedReportProdQuantity.MusId,
                               Index =I++,
                               DocNo= M.DocNo,
                               Bayan= M.Bayan,
                               MoveDate= M.MoveDate,
                               MoveType= M.MoveType,
                               Price=  M.Price,
                               SalePrice=M.SalePrice,
                               Quantity=   M.Quantity
                           }).ToList();

            e.ChildList = GetFoucsedReportProdQuantity.MoveProdQuan.ToList();

        }
        private ReportProdQuantity GetFoucsedReportProdQuantity => gridView.GetFocusedRow() as ReportProdQuantity;
        //List<StorQuantityProduct_Result> report2;
        List<ReportProdQuantity> filter;
        int id1=0, id2=0;
        //public void RefreshData()
        //{
        //    var temp = filter;
        //     id1 = ((look_p1.EditValue as int?) ?? 0);
        //     id2 = ((look_p2.EditValue as int?) ?? 0);
        //    if (temp.Count() > 0)
        //    {
        //        if (id1 == 0 & id2 > 0)
        //            temp = temp.Where(p => p.proId == id2).ToList();
        //        else if (id2 == 0 & id1 > 0)
        //            temp = temp.Where(p => p.proId == id1).ToList();
        //        else if (id1 > 0 & id2 > 0)
        //            temp = temp.Where(p => p.proId >= id1 & p.proId <= id2).ToList();

        //        int g1 = ((look_G.EditValue as int?) ?? 0);
        //        int g2 = ((look_G1.EditValue as int?) ?? 0);
        //        if (g1 == 0 & g2 > 0)
        //            temp = temp.Where(p => p.GroId == g2).ToList();
        //        else if (g2 == 0 & g1 > 0)
        //            temp = temp.Where(p => p.GroId == g1).ToList();
        //        else if (g1 > 0 & g2 > 0)
        //            temp = temp.Where(p => p.GroId >= g1 & p.GroId <= g2).ToList();

        //        short s1 = ((look_S.EditValue as short?) ?? 0);
        //        short s2 = ((look_S2.EditValue as short?) ?? 0);
        //        if (s1 == 0 & s2 > 0)
        //            temp = temp.Where(p => p.storId == s2).ToList();
        //        else if (s2 == 0 & s1 > 0)
        //            temp = temp.Where(p => p.storId == s1).ToList();
        //        else if (s1 > 0 & s2 > 0)
        //            temp = temp.Where(p => p.storId >= s1 & p.storId <= s2).ToList();
        //    }
        //    bindingSource1.DataSource = temp.OrderBy(x => x.proId);
        //    gridView.OptionsView.ShowFooter = true;
        //}
        //ReportProductsMove1 rprtPrdMove;
        private void Print_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            RReportTypesFun();
            //new ReportForm(rprtPrdMove).Show();
            flyDialog.WaitForm(this, 0);
        }
        public void Print(object ds)
        {
            //rprtPrdMove = new ReportProductsMove1();
            //new ClsReportHeaderData(rprtPrdMove);
            //rprtPrdMove.xrLabelH.Text = ((id1 == 0 && id2 == 0) ? "الاصناف:الكل ," : (id2 == 0) ? $"الصنف :{(look_p1.GetSelectedDataRow() as tblProduct).prdName} ," : "")
            //   + $"من تاريخ {dtime_Start.Text} الى تاريخ {dtime_End.Text}";
            //rprtPrdMove.TopMargin.HeightF -= 25;
            //rprtPrdMove.PrintingSystem.ContinuousPageNumbering = true;
            //rprtPrdMove.DataSource = ds;
            //rprtPrdMove.DetailReport.Visible = !(bool)radioGroup1.EditValue;
            //rprtPrdMove.DetailReport.DataSource = rprtPrdMove.DataSource;
            //rprtPrdMove.DetailReport.DataMember = "MoveProdQuan1";
            //rprtPrdMove.BindData();
            //rprtPrdMove.CreateDocument();
        }
        public void RReportTypesFun()
        {
            //var ff = bindingSource1.List as IList<ReportProdQuantity>;
            //var reportProdQuantities = (from d in ff
            //                            select new //ReportProdQuantity
            //                            {
            //                                prdNo = d.prdNo,
            //                                prdName = d.prdName,
            //                                grpName = d.grpName,
            //                                ppmMsurName = d.ppmMsurName,
            //                                strName = d.strName,
            //                                QuFrist = d.QuFrist,
            //                                QuaBuy = d.QuaBuy,
            //                                QStrIdTo = d.QStrIdTo,
            //                                QuaBuyRet = d.QuaBuyRet,
            //                                QuaSale = d.QuaSale,
            //                                QStrIdFrom = d.QStrIdFrom,
            //                                QuaSaleRet = d.QuaSaleRet,
            //                                QuaExper = d.QuaExper,
            //                                QLast = d.QLast,
            //                                proId = d.proId,
            //                                GroId = d.GroId,
            //                                MusId = d.MusId,
            //                                storId = d.storId,
            //                                MoveProdQuan1 = !(bool)radioGroup1.EditValue? InitData(d):null
            //                            }).ToList();
            //Print(reportProdQuantities);
        }
      
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ExportPDF_Click(object sender, EventArgs e)
        {
            //flyDialog.WaitForm(this, 1);
            //RReportTypesFun();
            //xtraSaveFileDialog1.Filter = "PDF Files|*.pdf";
            //if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
            //    rprtPrdMove.ExportToPdf(xtraSaveFileDialog1.FileName);
            //    flyDialog.WaitForm(this, 0);
        }

        private void Refreash_Click(object sender, EventArgs e)
        {
            //look_p2.EditValue = null;
            //look_G1.EditValue = null;
            //look_S.EditValue = null;
            //look_p1.EditValue = null;
            //look_S2.EditValue = null;
            //look_G.EditValue = null;
            //RefreshData();
        }
        private void Dtime_Start_EditValueChanged(object sender, EventArgs e)
        {
            //flyDialog.WaitForm(this, 1);
            //LoadData();
            //flyDialog.WaitForm(this, 0);
        }
        private void ExportExcel_Click(object sender, EventArgs e)
        {
            //flyDialog.WaitForm(this, 1);
            //RReportTypesFun();
            //xtraSaveFileDialog1.Filter = "Excel Files|*.Xls";
            //if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
            //    rprtPrdMove.ExportToXls(xtraSaveFileDialog1.FileName);
            //flyDialog.WaitForm(this, 0);
        }
        //accountingEntities db;
        //ClsTblSupplySub SubList;
        //ClsTblProductQ pro;
        //ClsTblGroupStr gro;
        //ClsTblPrdPriceMeasurmentQ Mus;
        //ClsTblStore sto;
        //ClsTblPrdExpirateQuan exp;
        //ClsTblStockTransSub StockTransSub;
        //ClsTblStockTransMain StockTransMain;
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();

        //private void LoadData()
        //{
        //    report2 = db.StorQuantityProduct(dtime_Start.DateTime, dtime_End.DateTime).ToList();
        //    var data = (from s in report2
        //                join p in prodact on s.ProId equals p.id
        //                join g in gro.GetGroupList on s.prdGrpNo equals g.id
        //                join m in PrdPriceMeasurment on s.ppmId equals m.ppmId
        //                join st in sto.GetStoreList on s.StoreId equals st.id
        //                select new
        //                {   s.QStrIdTo,
        //                    s.QStrIdFrom,
        //                    s.QuFrist,
        //                    p.prdNo,
        //                    s.ppmId,
        //                    proid= p.id,
        //                    StorId=st.id,
        //                    p.prdName,
        //                    g.grpName,
        //                    st.strName,
        //                    m.ppmMsurName,
        //                    QuaSale = report2.Where(x => x.ProId == s.ProId && x.StoreId == s.StoreId && x.ppmId == s.ppmId && (x.supStatus == 4 || x.supStatus == 8)).Sum(x => x.supQuanMain),
        //                    QuaSaleRet = report2.Where(x => x.ProId == s.ProId && x.StoreId == s.StoreId && x.ppmId == s.ppmId && (x.supStatus == 11 || x.supStatus == 12)).Sum(x => x.supQuanMain),
        //                    QuaBuy = report2.Where(x => x.ProId == s.ProId && x.StoreId == s.StoreId && x.ppmId == s.ppmId && (x.supStatus == 3 || x.supStatus == 7)).Sum(x => x.supQuanMain),
        //                    QuaBuyRet = report2.Where(x => x.ProId == s.ProId && x.StoreId == s.StoreId && x.ppmId == s.ppmId && (x.supStatus == 9 || x.supStatus == 10)).Sum(x => x.supQuanMain),
        //                    QuaExper = exp.GetPrdExpirateQuanListByPrdId(s.ProId).Where(x => x.expPrdMsurId == s.ppmId && x.expStrid == s.StoreId && x.expDate >= dtime_Start.DateTime && x.expDate <= dtime_End.DateTime).Sum(x => x.expQuan)
        //                }).Distinct().ToList();
       
        //    var lastexp = (from d in data
        //               from exp in exp.GetPrdExpirateQuanList
        //               where data.Any(x => x.proid == exp.expPrdId && x.ppmId == exp.expPrdMsurId && x.StorId == exp.expStrid) == false
        //               select exp).Distinct().GroupBy(x=>new { x.expPrdId,x.expPrdMsurId,x.expStrid}).Select(x=>new ReportProdQuantity
        //               {
        //                   prdNo = (prodact.FirstOrDefault(y=>y.id==x.Key.expPrdId) is tblProduct pro && pro!=null)?pro.prdNo:default,
        //                   prdName = (prodact.FirstOrDefault(y => y.id == x.Key.expPrdId) is tblProduct pro1 && pro1 != null) ? pro1.prdName : default,
        //                   grpName =(prodact.FirstOrDefault(y => y.id == x.Key.expPrdId) is tblProduct pro2 && pro2 != null) ? gro.GetGroupNameById(pro2.prdGrpNo) : default,
        //                   ppmMsurName = PrdPriceMeasurment.Where(y => y.ppmId == x.Key.expPrdMsurId).Select(y => y.ppmMsurName).FirstOrDefault(),
        //                   strName = sto.GetStoreNameById(x.Key.expStrid),
        //                   QuFrist = 0,
        //                   QuaBuy =0,
        //                   QStrIdTo = 0,
        //                   QuaBuyRet = 0,
        //                   QuaSale = 0,
        //                   QStrIdFrom = 0,
        //                   QuaSaleRet = 0,
        //                   QuaExper = x.Sum(x=>x.expQuan),
        //                   QLast = 0 - x.Sum(x => x.expQuan),
        //                   proId=x.Key.expPrdId,
        //                   GroId= (prodact.FirstOrDefault(y => y.id == x.Key.expPrdId) is tblProduct pro3 && pro3 != null) ? pro3.prdGrpNo: default,
        //                   MusId=x.Key.expPrdMsurId,
        //                   storId=x.Key.expStrid,
        //               }).ToList();
            
        //    var lastStokTo = (from d in data
        //                      from r in StockTransMain.GetStockTransList
        //                      join subx in StockTransSub.tbStockTransSubList on r.stcId equals subx.stcMainId
        //                      where data.Any(x => x.proid == subx.stcPrdId && x.ppmId == subx.stcMsurId && x.StorId == r.stcStrIdTo) == false
        //                   select new {
        //                       subx.stcPrdId,
        //                       subx.stcMsurId,
        //                       r.stcStrIdTo,
        //                       subx.stcQuantity
        //                   }).Distinct().GroupBy(x => new { x.stcPrdId, x.stcMsurId, x.stcStrIdTo }).Select(x => new ReportProdQuantity
        //                   {
        //                       prdNo = (prodact.FirstOrDefault(y => y.id == x.Key.stcPrdId) is tblProduct pro && pro != null) ? pro.prdNo : default,
        //                       prdName = (prodact.FirstOrDefault(y => y.id == x.Key.stcPrdId) is tblProduct pro1 && pro1 != null) ? pro1.prdName : default,
        //                       grpName = (prodact.FirstOrDefault(y => y.id == x.Key.stcPrdId) is tblProduct pro2 && pro2 != null) ? gro.GetGroupNameById(pro2.prdGrpNo) : default,
        //                       ppmMsurName = PrdPriceMeasurment.Where(y => y.ppmId == x.Key.stcMsurId).Select(y => y.ppmMsurName).FirstOrDefault(),
        //                       strName = sto.GetStoreNameById(x.Key.stcStrIdTo),
        //                       QuFrist = 0,
        //                       QuaBuy = 0,
        //                       QStrIdTo = x.Sum(x => x.stcQuantity),
        //                       QuaBuyRet = 0,
        //                       QuaSale = 0,
        //                       QStrIdFrom = 0,
        //                       QuaSaleRet = 0,
        //                       QuaExper = 0,
        //                       QLast =  x.Sum(x => x.stcQuantity),
        //                       proId = x.Key.stcPrdId,
        //                       GroId = (prodact.FirstOrDefault(y => y.id == x.Key.stcPrdId) is tblProduct pro3 && pro3 != null) ? pro3.prdGrpNo : default,
        //                       MusId = x.Key.stcMsurId,
        //                       storId = x.Key.stcStrIdTo
        //                   }).ToList();
        //    lastexp.AddRange(lastStokTo);
        //    var lastStokFrom = (from d in data
        //                      from r in StockTransMain.GetStockTransList
        //                      join subx in StockTransSub.tbStockTransSubList on r.stcId equals subx.stcMainId
        //                      where data.Any(x => x.proid == subx.stcPrdId && x.ppmId == subx.stcMsurId && x.StorId == r.stcStrIdFrom) == false
        //                      select new
        //                      {
        //                          subx.stcPrdId,
        //                          subx.stcMsurId,
        //                          r.stcStrIdFrom,
        //                          subx.stcQuantity
        //                      }).Distinct().GroupBy(x => new { x.stcPrdId, x.stcMsurId, x.stcStrIdFrom }).Select(x => new ReportProdQuantity
        //                      {
        //                          prdNo = (prodact.FirstOrDefault(y => y.id == x.Key.stcPrdId) is tblProduct pro && pro != null) ? pro.prdNo : default,
        //                          prdName = (prodact.FirstOrDefault(y => y.id == x.Key.stcPrdId) is tblProduct pro1 && pro1 != null) ? pro1.prdName : default,
        //                          grpName = (prodact.FirstOrDefault(y => y.id == x.Key.stcPrdId) is tblProduct pro2 && pro2 != null) ? gro.GetGroupNameById(pro2.prdGrpNo) : default,
        //                          ppmMsurName = PrdPriceMeasurment.Where(y => y.ppmId == x.Key.stcMsurId).Select(y => y.ppmMsurName).FirstOrDefault(),
        //                          strName = sto.GetStoreNameById(x.Key.stcStrIdFrom),
        //                          QuFrist = 0,
        //                          QuaBuy = 0,
        //                          QStrIdTo = 0,
        //                          QuaBuyRet = 0,
        //                          QuaSale = 0,
        //                          QStrIdFrom = x.Sum(x => x.stcQuantity),
        //                          QuaSaleRet = 0,
        //                          QuaExper = 0,
        //                          QLast = 0 - x.Sum(x => x.stcQuantity),
        //                          proId = x.Key.stcPrdId,
        //                          GroId = (prodact.FirstOrDefault(y => y.id == x.Key.stcPrdId) is tblProduct pro3 && pro3 != null) ? pro3.prdGrpNo : default,
        //                          MusId = x.Key.stcMsurId,
        //                          storId = x.Key.stcStrIdFrom
        //                      }).ToList();
        //    lastexp.AddRange(lastStokFrom);

        //    filter = (from d in data
        //             select new ReportProdQuantity
        //             {
        //                 prdNo = d.prdNo,
        //                 prdName = d.prdName,
        //                 grpName = d.grpName,
        //                 ppmMsurName = d.ppmMsurName,
        //                 strName = d.strName,
        //                 QuFrist = d.QuFrist,
        //                 QuaBuy = d.QuaBuy,
        //                 QStrIdTo = d.QStrIdTo,
        //                 QuaBuyRet = d.QuaBuyRet,
        //                 QuaSale = d.QuaSale,
        //                 QStrIdFrom = d.QStrIdFrom,
        //                 QuaSaleRet = d.QuaSaleRet,
        //                 QuaExper = d.QuaExper,
        //                 QLast = (d.QuFrist + d.QuaBuy + d.QuaSaleRet + d.QStrIdTo) - (d.QStrIdFrom + d.QuaSale + d.QuaBuyRet + d.QuaExper),
        //                  proId =d.proid,
        //                 GroId = (prodact.FirstOrDefault(y => y.id == d.proid) is tblProduct pro3 && pro3 != null) ? pro3.prdGrpNo : default,
        //                 MusId =d.ppmId,
        //                 storId =d.StorId
        //             }).ToList();
        //    filter.AddRange(lastexp.GroupBy(x => new { x.proId,x.MusId, x.storId }).Select(x => new ReportProdQuantity
        //    {
        //        strName = x.FirstOrDefault().strName,
        //        prdNo = x.FirstOrDefault().prdNo,
        //        grpName = x.FirstOrDefault().grpName,
        //        ppmMsurName = x.FirstOrDefault().ppmMsurName,
        //        prdName = x.FirstOrDefault().prdName,
        //        QLast = ((x.Sum(y => y.QuaBuy) + x.Sum(y => y.QuaSaleRet) + x.Sum(y => y.QuFrist) + x.Sum(y => y.QStrIdTo))
        //          - (x.Sum(y => y.QStrIdFrom) + x.Sum(y => y.QuaSale) + x.Sum(y => y.QuaBuyRet) + x.Sum(y => y.QuaExper))),
        //        QStrIdFrom = x.Sum(y => y.QStrIdFrom),
        //        QStrIdTo = x.Sum(y => y.QStrIdTo),
        //        QuaBuy = x.Sum(y => y.QuaBuy),
        //        QuFrist = x.Sum(y => y.QuFrist),
        //        QuaSaleRet = x.Sum(y => y.QuaSaleRet),
        //        QuaBuyRet = x.Sum(y => y.QuaBuyRet),
        //        QuaExper = x.Sum(y => y.QuaExper),
        //        QuaSale = x.Sum(w=>w.QuaSale),
        //        proId = x.Key.proId,
        //        GroId = (prodact.FirstOrDefault(y => y.id == x.Key.proId) is tblProduct pro3 && pro3 != null) ? pro3.prdGrpNo : default,
        //        MusId = x.Key.MusId,
        //        storId = x.Key.storId,
        //    }));
        //    bindingSource1.DataSource = filter.OrderBy(x =>x.proId);
        //    RefreshData();
        //    //var ggf = filter.OrderBy(x => new { x.proId, x.MusId }).GroupBy(y => new { y.proId, y.storId }).ToList();
        //    //var ggf = filter.GroupBy(y => new { y.proId, y.storId }).ToList();
        //    //List<ReportProdQuantity> reportProdQuantities = new List<ReportProdQuantity>();
        //    //foreach (var item in ggf)
        //    //{

        //    //    if (item.Count()==2)
        //    //    {
        //    //        var x=item.OrderBy(x => x.MusId);
        //    //        reportProdQuantities.Add(new ReportProdQuantity
        //    //         {
        //    //            strName = x.FirstOrDefault().strName,
        //    //            prdNo = x.FirstOrDefault().prdNo,
        //    //            grpName = x.FirstOrDefault().grpName,
        //    //            ppmMsurName = x.FirstOrDefault().ppmMsurName,
        //    //            prdName = x.FirstOrDefault().prdName,
        //    //            QLast =(PrdPriceMeasurment.FirstOrDefault(w=>w.ppmId== x.LastOrDefault().MusId) is tblPrdPriceMeasurment tblPrdPrice)?(x.LastOrDefault().QLast/Convert.ToDouble(tblPrdPrice.ppmConversion))+x.FirstOrDefault().QLast: x.FirstOrDefault().QLast,
        //    //            QStrIdFrom = x.Sum(y => y.QStrIdFrom),
        //    //            QStrIdTo = x.Sum(y => y.QStrIdTo),
        //    //            QuaBuy = x.Sum(y => y.QuaBuy),
        //    //            QuFrist = x.Sum(y => y.QuFrist),
        //    //            QuaSaleRet = x.Sum(y => y.QuaSaleRet),
        //    //            QuaBuyRet = x.Sum(y => y.QuaBuyRet),
        //    //            QuaExper = x.Sum(y => y.QuaExper),
        //    //            QuaSale = (PrdPriceMeasurment.FirstOrDefault(w => w.ppmId == x.LastOrDefault().MusId) is tblPrdPriceMeasurment tblPrdPrice1) ? (x.LastOrDefault().QuaSale / Convert.ToDouble(tblPrdPrice1.ppmConversion)) + x.FirstOrDefault().QuaSale : x.FirstOrDefault().QuaSale,
        //    //            proId = item.Key.proId,
        //    //            GroId = (prodact.FirstOrDefault(y => y.id == item.Key.proId) is tblProduct pro3 && pro3 != null) ? pro3.prdGrpNo : default,
        //    //            //MusId = x.Key.MusId,
        //    //            storId = item.Key.storId,
        //    //        });
        //    //    }
        //    //    else
        //    //        reportProdQuantities.Add(item.FirstOrDefault());
        //    //}
        //    //bindingSource1.DataSource = reportProdQuantities;
        //    //RefreshData();
        //}

        public class MoveProdQuantities
        {
            public int MusId { get; set; }
            public int? Index { get; set; }
            public string MoveType { get; set; }
            public int? DocNo { get; set; }
            public string Bayan { get; set; }
            public double? Quantity { get; set; }
            public decimal? Price { get; set; }
            public decimal? SalePrice { get; set; }
            public DateTime MoveDate { get; set; }
        }
        ReportProdQuantity temp;
        public class ReportProdQuantity
        {
            public short storId { get; set; }
            public int   proId { get; set; }
            public int   MusId { get; set; }
            public int   GroId { get; set; }
            [DisplayName("رقم الصنف")]
            public string prdNo { get; set; }
            [DisplayName("إسم الصنف")]
            public string prdName { get; set; }
            [DisplayName("المجموعة")]
            public string grpName { get; set; }
            [DisplayName("وحدة القياس")]
            public string ppmMsurName { get; set; }
            [DisplayName("المخزن")]
            public string strName { get; set; }
            [DisplayName("كمية رصيد اول")]
            public double? QuFrist { get; set; }
            [DisplayName("كمية مشتريات")]
            public double? QuaBuy { get; set; }
            [DisplayName("كمية تحويل وارد")]
            public double? QStrIdTo { get; set; }
            [DisplayName("كمية مردود مبيعات")]
            public double? QuaSaleRet { get; set; }
            [DisplayName("كمية مبيعات")]
            public double? QuaSale { get; set; }
            [DisplayName("كمية مردود مشتريات")]
            public double? QuaBuyRet { get; set; }

            [DisplayName("كمية تحويل صادر")]
            public double? QStrIdFrom { get; set; }
            [DisplayName("كمية تالف")]
            public double? QuaExper { get; set; }

            [DisplayName("كمية رصيد اخر")]
            public double? QLast { get; set; }
            public List<MoveProdQuantities> MoveProdQuan { get; set; }
        }
     
        private async void XtraFormReportsByDate_Load(object sender, EventArgs e)
        {
            //flyDialog.WaitForm(this, 1);
            //IList<Task> taskList = new List<Task>();
            //taskList.Add(Task.Run(() => SubList = new ClsTblSupplySub()));
            //taskList.Add(Task.Run(() => TblSupplyMain = new ClsTblSupplyMain()));
            //taskList.Add(Task.Run(() => pro = new ClsTblProductQ()));
            //taskList.Add(Task.Run(() => gro = new ClsTblGroupStr()));
            //taskList.Add(Task.Run(() => Mus = new ClsTblPrdPriceMeasurmentQ()));
            //taskList.Add(Task.Run(() => sto = new ClsTblStore()));
            //taskList.Add(Task.Run(() => exp = new ClsTblPrdExpirateQuan()));
            //taskList.Add(Task.Run(() => StockTransSub = new ClsTblStockTransSub()));
            //taskList.Add(Task.Run(() => StockTransMain = new ClsTblStockTransMain()));
            //taskList.Add(Task.Run(() => db = new accountingEntities()));
            //await Task.WhenAll(taskList);
            //IList<Task> taskList1 = new List<Task>();
            //taskList1.Add(Task.Run(() => PrdPriceMeasurment = Mus.GetPrdPriceMsurList.ToList()));
            //taskList1.Add(Task.Run(() => prodact = pro.GetProductList.ToList()));
            //taskList1.Add(Task.Run(() => tblSupplyMains = TblSupplyMain.GetSupplyMainListPurchaseNdSale()));
            //taskList1.Add(Task.Run(() => tblSupplySubs = SubList.GetSupplySubList.ToList()));
            //await Task.WhenAll(taskList1);
            //look_p1.Properties.DataSource = prodact.OrderBy(x=>x.id);
            //look_p2.Properties.DataSource = prodact.OrderBy(x => x.id);
            //look_G.Properties.DataSource = gro.GetGroupList.ToList();
            //look_G1.Properties.DataSource = gro.GetGroupList.ToList();
            //look_S.Properties.DataSource = sto.GetStoreList.ToList();
            //look_S2.Properties.DataSource = sto.GetStoreList.ToList();
            //LoadData();
            //gridView1.Columns.Add(new GridColumn()
            //{
            //    Name = "Index",
            //    FieldName = "Index",
            //    Caption = "م",
            //    UnboundType = UnboundColumnType.Integer,
            //    MaxWidth = 60
            //});
            //gridView1.Columns["Index"].OptionsColumn.AllowFocus = false;
            //gridView1.Columns["Index"].VisibleIndex = 0;
            //gridView1.Columns["Index"]?.SummaryItem.SetSummary(SummaryItemType.Count, "{0:d}");
            ReportProdQuantity f = new ReportProdQuantity();
            foreach (GridColumn item in gridView.Columns)
            {
                if (item.FieldName == nameof(f.storId) | item.FieldName == nameof(f.proId) |
                     item.FieldName == nameof(f.GroId) | item.FieldName == nameof(f.MusId))
                    item.Visible = false;
            }
            flyDialog.WaitForm(this,0);
        }

        private void look_p1_EditValueChanged(object sender, EventArgs e)
        {
            //RefreshData();
        }
    }
}