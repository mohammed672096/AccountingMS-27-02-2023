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
    public partial class UC_MasterEntry : UC_Master
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        private int supId;
        public UC_MasterEntry(EntryType type)
        {
            bindingNavigator11.AddNewItem = null;
            InitializeComponent();
            GetResources();
            InitEvents();
            entryType=type;
            btnSave.Visible=btnReset.Visible= Movelast.Visible= Movefirst.Visible=
                Moveprevious.Visible= Movenext.Visible= toolStripLabel7.Visible=
                toolStripTextBox7.Visible= false;
            btnRefresh.Visible =btnAddNew.Enabled= true;

            new ClsUserRoleValidation(this, GetUserType(entryType));

            MyTools.AllBoxesAndBanks();
        }
        private void InitEvents()
        {
            gridView.ShowCustomizationForm += GridView_ShowCustomizationForm;
            gridView.HideCustomizationForm += GridView_HideCustomizationForm;
            entityInstantFeedbackSource1.GetQueryable += entityInstantFeedbackSource1_GetQueryable;
            entityInstantFeedbackSource1.DismissQueryable += entityInstantFeedbackSource1_DismissQueryable;
            gridView.OptionsDetail.DetailMode = DetailMode.Embedded;
            gridView.AsyncCompleted += GridView_AsyncCompleted;
            gridView.MasterRowGetRelationCount += GridView_MasterRowGetRelationCount;
            gridView.MasterRowEmpty += GridView_MasterRowEmpty;
            gridView.MasterRowGetChildList += GridView_MasterRowGetChildList;
            gridView.MasterRowGetRelationName += GridView_MasterRowGetRelationName;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
            gridView.CustomUnboundColumnData += GridView_CustomUnboundColumnData;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
            gridView.DoubleClick += GridView_DoubleClick;
        }

        private void GridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (view == null) return;
                //if (!e.IsGetData) return;
                if (e.Column.FieldName == colIndex.FieldName)
                {
                    e.Value = view.GetVisibleRowHandle(e.ListSourceRowIndex) + 1;
                    return;
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void GridView_HideCustomizationForm(object sender, EventArgs e)
        {
            ClsPath.SaveCustomContol(this.gridView, this.Name + this.entryType);
        }
        private void GridView_ShowCustomizationForm(object sender, EventArgs e)
        {
            ((GridView)sender).CustomizationForm.Text = "تحديد الأعمده";
        }
        EntryType entryType;
        private void entityInstantFeedbackSource1_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = db.EntryMains.Where(x => x.Date >=Session.CurrentYear.DateStart 
            && x.Date <= Session.CurrentYear.DateEnd&& (x.Status ==(byte)entryType)&&x.BranchID==Session.CurrentBranch.ID&&!x.SendToserver).AsNoTracking();
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
            e.ChildList = db.EntrySubs.Where(x => x.ParentID == GetFoucsedEntryMainId).ToList();
        }
        private int GetFoucsedEntryMainId => Convert.ToInt32(gridView.GetFocusedRowCellValue(colID));
        private byte GetFoucSuStatus => (byte)gridView.GetFocusedRowCellValue(colStatus);

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            DataUpdate();
        }
        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            try
            {
                if (e.Value == null) return;
                switch (e.Column.FieldName)
                { 
                    case "Status"when(!string.IsNullOrEmpty(e?.Value.ToString())):
                        e.DisplayText = MyTools.EntryStatus(Convert.ToByte(e?.Value)) + " " + MyTools.EntryPayMethodType((byte)gridView.GetListSourceRowCellValue(e.ListSourceRowIndex, colIsCash));
                        break;
                    case "Currency" when (((e.Value as byte?) ?? 0) != 0):
                        e.DisplayText = Session.Currencies.FirstOrDefault(x => x.ID == ((e.Value as byte?) ?? 0)).Name; 
                        break;
                    case "AccNo" when (colAccName.Name==e.Column.Name):
                        e.DisplayText = MyTools.l1?.FirstOrDefault(x=>(long)x.ID==((e.Value as long?)??0))?.Name;
                        break;
                    //case "Status" when (!string.IsNullOrEmpty(e?.Value.ToString())):
                    //    e.DisplayText = MyTools.EntryStatus(Convert.ToByte(e?.Value)) + " " + MyTools.EntryPayMethodType((byte)gridView.GetListSourceRowCellValue(e.ListSourceRowIndex, colIsCash));
                    //    break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            try
            {
                if (e.Value == null) return;
            if (e.Column.FieldName == colentCusName.FieldName&& Session.Customers?.FirstOrDefault(x => x.ID == Convert.ToInt32(e.Value)) is Customer customer&& customer!=null)
                    e.DisplayText = customer?.No+"-"+customer?.Name;
              else if (e.Column.FieldName == colentCurrency.FieldName && ((e.Value as byte?) ?? 0) != 0)
                        e.DisplayText = Session.Currencies.FirstOrDefault(x => x.ID == ((e.Value as byte?) ?? 0)).Name;
            }
            catch (Exception)
            {
                return;
            }
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
        private EntryMain GetFocusedObj =>(gridView.GetFocusedRow() as ReadonlyThreadSafeProxyForObjectFromAnotherThread)?.OriginalRow as EntryMain;
        public void SetFoucesdRow()
        {
            if (!this.isDataLoaded) return;
            this.isSetFoucsedRow = false;
            int rowHandle = gridView.LocateByValue(colID.FieldName, this.supId);
            if (rowHandle == GridControl.InvalidRowHandle) return;
            gridView.FocusedRowHandle = rowHandle;
        }
        private PosDBDataContext db = new PosDBDataContext(Program.ConnectionString);
        public override void New()
        {
            FormEntryMain frm = new FormEntryMain(null, null, GetUserType(entryType), this.ParentForm);
            frm.FormClosed += Frm_FormClosed;
            frm.Show();
        }
        UserControls GetUserType(EntryType type)
        {
            switch (type)
            {
                case EntryType.DailyEntry:
                    return UserControls.Entries;
                case EntryType.EntryVoucher:
                    return UserControls.EntryVoucer;
                case EntryType.EntryReceipt:
                    return UserControls.EntryRcpt;
                default:
                    return UserControls.EntryRcpt;
            }
        }
        public override void Delete()
        {
            //if (GetFocusedObj == null) return;
            //if (ClsXtraMssgBox.ShowWarningYesNo(GetMssg(GetFoucSuStatus == (byte)EntryType.Sales ? "delSaleMssg" : "delSaleRtrnMssg", GetFocusedObj.No)) == DialogResult.No) return;
            //var temp = db.EntryMains.FirstOrDefault(x => x.ID == GetFocusedObj.ID);
            //if (temp != null) { temp.IsDelete = true; db.SubmitChanges(); }
            //flyDialog.ShowDialogUCCustomdMsg(this, GetMssg(GetFoucSuStatus == (byte)EntryType.Sales ? "delSaleSuccessMssg" : "delSaleRtrnSuccessMssg", GetFocusedObj.No));
            //InitData();
        }
        public override void Print()
        {
            PrintEntry(PrintMode.ShowPreview);
        }
        public void PrintEntry(PrintMode printMode)
        {
            if (!ValidateData()) return;
            int id = 0;
            //if (!string.IsNullOrEmpty(toolStTxtInvoNo.Text))
            //    id = int.Parse(toolStTxtInvoNo.Text);
            //else 
            if (GetFocusedObj is EntryMain tEntryMain && tEntryMain != null)
                id = tEntryMain.No;
            if (Session.CurrSettings.ShowPrintMssg)
                if (ClsXtraMssgBox.ShowQuesPrint(GetMssg("printMssgEntry", id)) != DialogResult.Yes) return;
            if (printMode == PrintMode.Direct)
                Task.Run(() => myFunaction.PrintEntry(id, null, null));
            else
            {
                flyDialog.WaitForm(this, 1);
                myFunaction.PrintEntry(id, null, null);
                flyDialog.WaitForm(this, 0);
            }
        }
        MyFunaction myFunaction = new MyFunaction();
        public override void DataUpdate()
        {
            EntryMain EntryMain = new EntryMain();
            EntryMain = myFunaction.GetCopyFromEntryMain(GetFocusedObj);
            if (EntryMain == null) return;
            //if (EntryMain.Status != (byte)entryType.Sales) return;
            //formEntryMain frm = new formEntryMain(EntryMain, myFunaction.GetCopyFromEntrySub(db.EntrySubs.Where(x => x.ParentID == EntryMain.ID).ToList()), EntryType.Sales, this.ParentForm);
            FormEntryMain frm = new FormEntryMain(EntryMain, myFunaction.GetCopyFromEntrySub(db.EntrySubs.Where(x => x.ParentID == EntryMain.ID).ToList()),GetUserType(entryType), this.ParentForm);
            frm.FormClosed += Frm_FormClosed;
            frm.Show();
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(this.IsDisposed) return;
            RefreshData();
        }
        public override void RefreshData()
        {
            InitData();
        }
        private void UC_Master_Load(object sender, EventArgs e)
        {
            ClsPath.ReLodeCustomContol(this.gridView, this.Name);
            RefreshData();
        }
    }
}
