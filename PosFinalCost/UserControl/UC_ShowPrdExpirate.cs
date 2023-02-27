using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraDataLayout;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using PosFinalCost.Classe;
using System.Data.Entity;
using System.Globalization;
using DevExpress.XtraGrid.Columns;
using DevExpress.Data.Async.Helpers;
using DevExpress.Data.Helpers;
using DevExpress.XtraReports.UI;

namespace PosFinalCost.Forms
{
    public partial class UC_ShowPrdExpirate : UserControl
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        private int supId;
        public UC_ShowPrdExpirate()
        {
            InitializeComponent();
            GetResources();
            InitEvents();
            //new ClsUserRoleValidation(this, supplyType==SupplyType.Sales?UserControls.Sale: UserControls.SaleRtrn);
            myFunaction.AppearanceGridView(gridView);

        }
        private void InitEvents()
        {
            entityInstantFeedbackSource1.GetQueryable += entityInstantFeedbackSource1_GetQueryable;
            entityInstantFeedbackSource1.DismissQueryable += entityInstantFeedbackSource1_DismissQueryable;
            gridView.OptionsDetail.DetailMode = DetailMode.Embedded;
            gridView.AsyncCompleted += GridView_AsyncCompleted;
            gridView.MasterRowGetRelationCount += GridView_MasterRowGetRelationCount;
            gridView.MasterRowEmpty += GridView_MasterRowEmpty;
            gridView.MasterRowGetChildList += GridView_MasterRowGetChildList;
            gridView.MasterRowGetRelationName += GridView_MasterRowGetRelationName;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
            gridView.DoubleClick += GridView_DoubleClick;
            btnAddNew.Click += BtnAddNew_Click;
            btnDelete.Click += BtnDelete_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnPrint.Click += BtnPrint_Click;
            btnPrintPdf.Click += BtnPrint_Click;
            btnPrintXsl.Click += BtnPrint_Click;
            btnRefresh.Click += BtnRefresh_Click;
            gridControl.KeyDown += gridControl_KeyDown;
        }

        private void entityInstantFeedbackSource1_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = db.PrdExpirateMains.Where(x => x.Date >=Session.CurrentYear.DateStart 
            && x.Date <= Session.CurrentYear.DateEnd&&x.BranchID==Session.CurrentBranch.ID).AsNoTracking();
            e.Tag = db;
        }
        private bool isDataLoaded = false, isRefreshData = false, isSetFoucsedRow = false;
        private void entityInstantFeedbackSource1_DismissQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            ((PosDBDataContext)e.Tag).Dispose();
        }
        private void InitData()
        {
            try
            {
                this.isDataLoaded = false;
                entityInstantFeedbackSource1.Refresh();
            }
            catch (Exception)
            {
                return;
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
        private void GridView_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            e.ChildList = db.PrdExpirateDetails.Where(x => x.ParentID == GetFoucsedPrdExpirateMainId).ToList();
        }
        private int GetFoucsedPrdExpirateMainId => Convert.ToInt32(gridView.GetFocusedRowCellValue(colID));

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
           
            DataUpdate();
        }
        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            //try
            //{
                if (e.Value == null) return;
                if (e.Column.FieldName == colStorID.FieldName && e.Value is short s&&s>0)
                    e.DisplayText = Session.Stores.FirstOrDefault(x=>x.ID==s)?.Name;
                else if (e.Column.FieldName == colBranchID.FieldName && e.Value is short b&&b>0)
                    e.DisplayText = Session.Branches?.FirstOrDefault(x => x.ID ==b)?.Name;
            else if (e.Column.FieldName == colUserID.FieldName && e.Value is short u&& u> 0)
                e.DisplayText = Session.UserTbls?.FirstOrDefault(x => x.ID == u)?.Name;
            //}
            //catch (Exception)
            //{
            //    return;
            //}
        }
        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            //try
            //{
                if (e.Value == null) return;
            if (e.Column.FieldName ==colsupMsur.FieldName)
                e.DisplayText = Session.PrdMeasurments?.FirstOrDefault(x => x.ID == Convert.ToInt32(e.Value))?.Name;
            if (e.Column.FieldName == colsupPrdName.FieldName && Convert.ToInt32(e.Value) != 0)
                e.DisplayText = Session.Products?.FirstOrDefault(x => x.ID == Convert.ToInt32(e.Value))?.Name;
            if (e.Column.FieldName == colStoreID.FieldName && e.Value is short s && s > 0)
                e.DisplayText = Session.Stores.FirstOrDefault(x => x.ID == s)?.Name;
            //}
            //catch (Exception)
            //{
            //    return;
            //}
        }
        private void GridView_AsyncCompleted(object sender, EventArgs e)
        {
            if (this.isRefreshData)
            {
                this.isRefreshData = false;
                return;
            }
            this.isDataLoaded = true;
            if (this.isSetFoucsedRow) SetFoucesdRow();
        }
        private bool ValidateData()=>gridView?.DataRowCount >= 1;

        private void GetResources()
        {
            if (!Program.My_Setting.LangEng)
            {
                _ci = new CultureInfo("ar");
                _resource = new ComponentResourceManager(typeof(Language.UC_MasterInvoiceAr));
            }
            else
            {
                _ci = new CultureInfo("en");
                _resource = new ComponentResourceManager(typeof(Language.UC_MasterInvEn));
                EnglishTranslation();
            }
            foreach (var control in bindingNavigator11.Items)
                if (control is ToolStripItem c)
                    _resource.ApplyResources(c, c.Name, _ci);
        }
        private void EnglishTranslation()
        {
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            gridControl.RightToLeft =System.Windows.Forms.RightToLeft.No;
            gridView.Columns.ForEach(c => _resource.ApplyResources(c, c.Name, _ci));
            gridView1.Columns.ForEach(c => _resource.ApplyResources(c, c.Name, _ci));
        }
        private string GetMssg(string m,int No) => string.Format(_resource.GetString(m),No);
        private PrdExpirateMain GetFocusedObj=>(gridView.GetFocusedRow() as ReadonlyThreadSafeProxyForObjectFromAnotherThread)?.OriginalRow as PrdExpirateMain;
        public void SetFoucesdRow()
        {
            if (!this.isDataLoaded) return;
            this.isSetFoucsedRow = false;
            int rowHandle = gridView.LocateByValue(colID.FieldName, this.supId);
            if (rowHandle == GridControl.InvalidRowHandle) return;
            gridView.FocusedRowHandle = rowHandle;
        }
        private PosDBDataContext db = new PosDBDataContext(Program.ConnectionString);
        public virtual void New()
        {
            FormEntryMain frm = new FormEntryMain(null, null,UserControls.ExpiredProducts, this.ParentForm);
            frm.FormClosed += Frm_FormClosed;
            frm.Show();
        }
        public virtual void Delete()
        {
            if (GetFocusedObj == null) return;
            //if (GetFocusedObj.SendToserver)
            //    ClsXtraMssgBox.ShowWarning("عفوا لا يمكن حذف المستند بعد رفعه الى الفرع الرئيسي");
                if (ClsXtraMssgBox.ShowWarningYesNo(GetMssg("delPrdExpirMssg", GetFocusedObj.ID)) == DialogResult.No) return;
            var temp = db.PrdExpirateMains.FirstOrDefault(x => x.ID == GetFocusedObj.ID);
            if (temp != null) { db.PrdExpirateMains.DeleteOnSubmit(temp); db.SubmitChanges(); }
            flyDialog.ShowDialogUCCustomdMsg(this, GetMssg("delPrdExpirSuccessMssg", GetFocusedObj.ID));
            InitData();
        }
        public virtual void Print(PrintFileType printFileType = PrintFileType.Printer)
        {
            if (!ValidateData()) return;
           if (GetFocusedObj is PrdExpirateMain tPrdExpirateMain && tPrdExpirateMain != null)
            {
                bool temp = false;
                switch (printFileType)
                {
                    case PrintFileType.Printer:
                        if (Session.CurrSettings.ShowPrintMssg)
                            if (ClsXtraMssgBox.ShowQuesPrint(GetMssg("printMssg", tPrdExpirateMain.ID)) != DialogResult.Yes) return;
                        temp = Session.CurrSettings.InvoicePrintMode == ((byte)PrintMode.Direct);
                        break;
                    case PrintFileType.PDF:
                    case PrintFileType.Xlsx:
                        temp = Session.CurrSettings.PrintFileMode == ((byte)PrintMode.Direct);
                        break;
                    default:
                        break;
                }
                if (temp)
                    Task.Run(() => myFunaction.PrintPrdExpirt(tPrdExpirateMain, printFileType));
                else
                {
                    flyDialog.WaitForm(this, 1);
                    myFunaction.PrintPrdExpirt(tPrdExpirateMain, printFileType);
                    flyDialog.WaitForm(this, 0);
                }
            }
        }
        MyFunaction myFunaction = new MyFunaction();
        public virtual void DataUpdate()
        {
            PrdExpirateMain PrdExpirateMain = new PrdExpirateMain();
            PrdExpirateMain = myFunaction.GetCopyFromPrdExpirateMain(GetFocusedObj);
            if (PrdExpirateMain == null|| PrdExpirateMain.SendToserver) return;
            //formPrdExpirateMain frm =new formPrdExpirateMain(PrdExpirateMain, myFunaction.GetCopyFromPrdExpirateDetail(db.PrdExpirateDetails.Where(x => x.ParentID == PrdExpirateMain.ID).ToList()), SupplyType.Sales, this.ParentForm);
            FormEntryMain frm = new FormEntryMain(PrdExpirateMain, myFunaction.GetCopyFromPrdExpirateDetail(db.PrdExpirateDetails.Where(x => x.ParentID == PrdExpirateMain.ID).ToList()),UserControls.ExpiredProducts, this.ParentForm);
            frm.FormClosed += Frm_FormClosed;
            frm.Show();
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(this.IsDisposed) return;
            RefreshData();
        }

        public virtual void RefreshData()
        {
            InitData();
        }
        private void UC_Master_Load(object sender, EventArgs e)
        {
            ClsPath.ReLodeCustomContol(this.gridView, this.Name);
            RefreshData();
         
        }
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (((ToolStripButton)sender).Name == btnPrint.Name)
                Print(PrintFileType.Printer);
            else if (((ToolStripButton)sender).Name == btnPrintPdf.Name)
                Print(PrintFileType.PDF);
            else if (((ToolStripButton)sender).Name == btnPrintXsl.Name)
                Print(PrintFileType.Xlsx);
        }
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
                RefreshData();
        }
        private void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    btnAddNew.PerformClick();
                    break;
                case Keys.F4:
                    btnUpdate.PerformClick();
                    break;
                case Keys.F5:
                    btnRefresh.PerformClick();
                    break;
                //case Keys.F6:
                //    Delete();
                //    break;
                case Keys.F7:
                    btnPrint.PerformClick();
                    break;
                default:
                    break;
            }
            if (e.Control && e.Shift && e.Alt && e.KeyCode == Keys.D)
                Delete();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            DataUpdate();
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            New();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Dispose();
        }
    }
}
