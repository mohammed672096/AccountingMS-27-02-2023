using DevExpress.Data;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class frm_DrawerDailyJournal : frm_Master 
    {
        public frm_DrawerDailyJournal()
        {
            InitializeComponent();
            btn_Save.Visibility = btn_New.Visibility = btn_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            dateEdit1.DateTime = DateTime.Now; 

           
        }
        public override void frm_Load(object sender, EventArgs e)
        {
            base.frm_Load(sender, e);
          
            lkp_Drawer.Properties.ValueMember = "ACCID";
            lkp_Drawer.Properties.DisplayMember = "Name"; 
            lkp_Drawer.EditValue = CurrentSession.UserAccessibleDrawer.Where(x=>x.ID == CurrentSession.user.DefaultDrawer).Select(x=>x.ACCID ).FirstOrDefault();
            lkp_Drawer.ReadOnly = !(bool)CurrentSession.user.CanChangeDrawer;
            toggleSwitch1_Toggled(toggleSwitch1, new EventArgs());



        }
        public override void Print()
        {
            if (CanPerformPrint() == false) return;
            Reporting.rpt_GridReport.Print(gridControl_Main, this.Text, LangResource.Date + ":" + dateEdit1.Text, (this.RightToLeft == RightToLeft.Yes) ? true : false);
            base.Print();   
        }
        public override void RunUserPrivilage()
        {
            base.RunUserPrivilage();
           Master. EnumAccordionControl(accordionControl2 );
            toggleSwitch1.IsOn =Convert.ToBoolean( Master.GetUserSetting("frm_Journal.toggleSwitch1.IsOn", false));
        }
        public override void RefreshData()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con); 
            lkp_Drawer.Properties.DataSource = CurrentSession.UserAccessibleDrawer.Select(x => new { x.ACCID , x.Name });
            ShowDataInGrids(); 
        }
        void ShowDataInGrids()
        {
            if (lkp_Drawer.EditValue == null
                || dateEdit1.Text .Trim()=="") return; 

            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            // Debit  {0,6,13,14,16 }
            // Credit {9,10,15,17}
            var Debits = new int[] { 0, 6, 13, 14, 16 };
            var Credits = new int[] { 9, 10, 15, 17 };

            var log = (from l in db.Acc_Activities
                       from d in db.Acc_ActivityDetials.Where(x => x.AcivityID == l.ID)
                       where l.Date.Date == dateEdit1.DateTime.Date  && d.ACCID.ToString() == lkp_Drawer.EditValue.ToString()
                       select new { StatmentType =   l.Type, l.TypeID, l.Note, d.Debit, d.Credit }).ToList();

            gridControl_In.DataSource   = log.Where(x => x.Debit > 0  || Debits.Contains(Convert.ToInt32( x.StatmentType)))
                .Select(x => new  { x.StatmentType  , x.TypeID, x.Note, x.Debit }).ToList();

            gridControl_out.DataSource  = log.Where(x => x.Credit > 0 || Credits.Contains(Convert.ToInt32(x.StatmentType)))
                .Select(x => new { x.StatmentType , x.TypeID, x.Note, x.Credit }).ToList();

            gridControl_Main.DataSource = log;

             

            var History = (from l in db.Acc_Activities
                           join d in db.Acc_ActivityDetials on l.ID equals d.AcivityID 
                           where  d.ACCID.ToString() == lkp_Drawer.EditValue.ToString() && l.Date > new DateTime(DateTime.Now.Year , 1,1) 
                           select new { Date = l.Date.Date ,  d.Debit  , Credit =  d.Credit*-1 }) ;

            Series DebitSeries = new Series(LangResource.Income , ViewType.Line   ); 
            DebitSeries.ArgumentScaleType = ScaleType.DateTime;
            DebitSeries.ArgumentDataMember = "Date";
            DebitSeries.ValueScaleType = ScaleType.Numerical;
            DebitSeries.ValueDataMembers.AddRange(new string[] { "Debit" });
            DebitSeries.DataSource = History.GroupBy(x =>  x.Date  ).Select(x => new { Date =  x.Key  ,Debit =  x.Sum( d => d.Debit) }).ToList();

            Series CreditSeries = new Series(LangResource.OutCome, ViewType.Line);
            CreditSeries.ArgumentScaleType = ScaleType.DateTime;
            CreditSeries.ArgumentDataMember = "Date";
            CreditSeries.ValueScaleType = ScaleType.Numerical;
            CreditSeries.ValueDataMembers.AddRange(new string[] { "Credit" });
            CreditSeries.DataSource = History.GroupBy(x => x.Date).Select(x => new { Date = x.Key, Credit = x.Sum(d => d.Credit) }).ToList();

            

            chartControl1.Series.Clear();
            chartControl1.Series.Add(DebitSeries);
            chartControl1.Series.Add(CreditSeries);
            
            ((XYDiagram)chartControl1.Diagram).AxisY.Visibility = DevExpress.Utils.DefaultBoolean.True ;
            ((XYDiagram)chartControl1.Diagram).AxisX.Visibility = DevExpress.Utils.DefaultBoolean.True;
            chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True ;
            chartControl1.AnimationStartMode = ChartAnimationMode.OnDataChanged;
            XYDiagram diagram = (XYDiagram)chartControl1.Diagram;
            diagram.AxisX.VisualRange.Auto = false;
            diagram.AxisX.VisualRange.SetMinMaxValues(((DateTime)diagram.AxisX.WholeRange.MaxValue).AddDays(-30), diagram.AxisX.WholeRange.MaxValue);
            diagram.EnableAxisXScrolling = true;
            diagram.EnableAxisXZooming = true;


            var OpenBalanceDay = from a in db.Acc_Activities
                                   from d in db.Acc_ActivityDetials.Where(x => x.AcivityID == a.ID)
                                   where a.Date.Date < dateEdit1.DateTime.Date && d.ACCID.ToString() == lkp_Drawer.EditValue.ToString()
                                   select   d.Debit - d.Credit   ;

            var  BalanceUntilDay = from a in db.Acc_Activities
                                   from d in db.Acc_ActivityDetials.Where(x => x.AcivityID == a.ID)
                                   where a.Date.Date <= dateEdit1.DateTime.Date && d.ACCID.ToString() == lkp_Drawer.EditValue.ToString()
                                   select   d.Debit - d.Credit ;

            var CurrentBalance = from a in db.Acc_Activities
                                 from d in db.Acc_ActivityDetials.Where(x => x.AcivityID == a.ID)
                                 where   d.ACCID.ToString() == lkp_Drawer.EditValue.ToString()
                                 select    d.Debit - d.Credit  ;

            textEdit1.Text = OpenBalanceDay.ToList().Sum().ToString() ;
            textEdit2.Text = BalanceUntilDay.ToList().Sum().ToString() ;
            textEdit3.Text = CurrentBalance.ToList().Sum(). ToString();


            RepositoryItemLookUpEdit StatmentRepo = new RepositoryItemLookUpEdit();
            RepositoryItemMemoEdit  RepoMemo = new RepositoryItemMemoEdit();
          
            DataTable ProssessDT = new DataTable();
            ProssessDT.Columns.Add("ID");
            ProssessDT.Columns.Add("Name");

            for (int i = 0; i < Master.Prossess.Count(); i++) 
                ProssessDT.Rows.Add(i, Master.Prossess[i]); 
            
            StatmentRepo.DataSource = ProssessDT;
            StatmentRepo.DisplayMember = "Name";
            StatmentRepo.ValueMember = "ID"; 
            gridControl_In.RepositoryItems.Add(StatmentRepo);
            gridControl_out .RepositoryItems.Add(StatmentRepo);
            gridControl_Main .RepositoryItems.Add(StatmentRepo);
            gridView_In.Columns["StatmentType"].ColumnEdit =  
            gridView_Out .Columns["StatmentType"].ColumnEdit =  
            gridView_Main .Columns["StatmentType"].ColumnEdit = StatmentRepo;

            gridView_In.Columns["Note"].ColumnEdit =
            gridView_Out.Columns["Note"].ColumnEdit =
            gridView_Main.Columns["Note"].ColumnEdit = RepoMemo;

            gridView_In.Columns["TypeID"].Visible =
            gridView_Out.Columns["TypeID"].Visible =
            gridView_Main.Columns["TypeID"].Visible =
               gridView_In.Columns["TypeID"].OptionsColumn.ShowInCustomizationForm =
            gridView_Out.Columns["TypeID"].OptionsColumn.ShowInCustomizationForm =
            gridView_Main.Columns["TypeID"].OptionsColumn.ShowInCustomizationForm = false;


            gridView_In.Columns["StatmentType"].Caption = gridView_Out.Columns["StatmentType"].Caption = gridView_Main.Columns["StatmentType"] .Caption = LangResource.StatmentType;
            gridView_In.Columns["Note"].Caption = gridView_Out.Columns["Note"].Caption = gridView_Main.Columns["Note"].Caption = LangResource.Statment ;
            gridView_In.Columns["Debit"].Caption = 
            gridView_Out.Columns["Credit"].Caption = LangResource.Amount;

            gridView_Main.Columns["Debit"].Caption = LangResource.Income ;
            gridView_Main.Columns["Credit"].Caption = LangResource.OutCome;

            
          


         
            gridView_Main.Columns["Debit"].Summary.Clear();
            gridView_Main.Columns["Credit"].Summary.Clear();
            gridView_In.Columns["Debit"].Summary.Clear();
            gridView_Out.Columns["Credit"].Summary.Clear();

             gridView_Main.Columns["Debit"].Summary.Add(SummaryItemType.Sum , "Debit", "{0:n2}");
            gridView_Main.Columns["Credit"].Summary.Add(SummaryItemType.Sum ,"Credit", "{0:n2}"); 
              gridView_In.Columns["Debit"].Summary.Add(SummaryItemType.Sum, "Debit", "{0:n2}"); 
            gridView_Out.Columns["Credit"].Summary.Add(SummaryItemType.Sum ,"Credit", "{0:n2}");





        }
        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            GridMainItem.Visibility = (toggleSwitch1.IsOn) ? LayoutVisibility.Never : LayoutVisibility.Always;
            GridOutItem .Visibility = splitterItem1.Visibility  = GridInItem.Visibility = (!toggleSwitch1.IsOn) ? LayoutVisibility.Never : LayoutVisibility.Always;
        }

        private void lkp_Drawer_EditValueChanged(object sender, EventArgs e)
        {
            ShowDataInGrids();
             

        }

        private void gridView_Main_CustomColumnDisplayText(object sender,CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "Debit" || e.Column.FieldName == "Credit")
            {

                if (e.Value.GetType() == typeof(double) && Convert.ToDouble(e.Value) == 0)
                {
                    e.DisplayText = "";

                }
            }
        }

        private void gridView_Main_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            ColumnView columnView = sender as ColumnView;
            int h = e.RowHandle;
            GridView view = sender as GridView;
            // Debug.Print(view.Name);
            if (e.RowHandle < 0) return;
            if (view.GetRowCellValue(e.RowHandle, "Debit") != null &&
                view.GetRowCellValue(e.RowHandle, "Debit") != DBNull.Value)
            {
                if (Convert.ToDouble(view.GetRowCellValue(e.RowHandle, "Debit")) > 0)
                    e.Appearance.BackColor =   Color.FromArgb(76, 175, 80);

                else
                    e.Appearance.BackColor = Color.FromArgb(239, 83, 80)  ; 

            }
        }

        private void gridView_In_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
          
            if (e.Column.FieldName == "Debit")
            {
                e.Appearance.BackColor = Color.FromArgb(76, 175, 80);
                e.Appearance.FillRectangle(e.Cache, e.Bounds);
                e.Info.AllowDrawBackground = false;
            }
            else if (e.Column.FieldName == "Credit")
            {
                e.Appearance.BackColor = Color.FromArgb(239, 83, 80);
                e.Appearance.FillRectangle(e.Cache, e.Bounds);
                e.Info.AllowDrawBackground = false;
            }

        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {
            if (textEdit3.Text != "" && Convert.ToDouble( textEdit3.Text ) < 0)
            {
                textEdit3.BackColor = Color.FromArgb(239, 83, 80);
            }
            else
            {
                textEdit3.BackColor = Color.FromArgb(76, 175, 80);

            }
        }

        private void gridView_In_DoubleClick(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null||view.FocusedRowHandle < 0 ||
                view.GetFocusedRowCellValue("TypeID") == null ||
                view.GetFocusedRowCellValue("TypeID") == DBNull.Value ) return;
            Master.OpenByProssess(Convert.ToInt32(view.GetFocusedRowCellValue("StatmentType")), Convert.ToInt32(view.GetFocusedRowCellValue("TypeID")));

            
        }

       

        private void frm_Journal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Master.SetUserSetting("frm_Journal.toggleSwitch1.IsOn", toggleSwitch1.IsOn);
        }
    }
}
