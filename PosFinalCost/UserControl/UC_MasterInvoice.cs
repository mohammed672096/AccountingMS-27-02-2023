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
    public partial class UC_MasterInvoice : UserControl
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        private int supId;
        public UC_MasterInvoice(SupplyType type)
        {
            InitializeComponent();
            GetResources();
            InitEvents();
            supplyType=type;
            btnUpdate.Visible = (type == SupplyType.Sales);
            new ClsUserRoleValidation(this, supplyType==SupplyType.Sales?UserControls.Sale: UserControls.SaleRtrn);
            myFunaction.AppearanceGridView(gridView);

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
            btnAddNew.Click += BtnAddNew_Click;
            btnDelete.Click += BtnDelete_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnPrint.Click += BtnPrint_Click;
            btnPrintPdf.Click += BtnPrint_Click;
            btnPrintXsl.Click += BtnPrint_Click;
            btnRefresh.Click += BtnRefresh_Click;
            gridControl.KeyDown += gridControl_KeyDown;
        }

        private void GridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            //try
            //{
                GridView view = sender as GridView;
                if (view == null) return;
                if (!e.IsGetData) return;
                if (e.Column.FieldName == colIndex.FieldName)
                {
                    e.Value = view.GetVisibleRowHandle(e.ListSourceRowIndex) + 1;
                    return;
                }
                //else if (e.Column.FieldName == colAccName.FieldName)
                //{
                //    var bid = gridView.GetRowCellValue(0, colBankId);
                //    if (string.IsNullOrEmpty(view.GetListSourceRowCellValue(e.ListSourceRowIndex, colBankAmount)?.ToString())) return;
                //    decimal BankAmount = Convert.ToDecimal(view.GetListSourceRowCellValue(e.ListSourceRowIndex, colBankAmount));
                //    decimal paidCash = Convert.ToDecimal(view.GetListSourceRowCellValue(e.ListSourceRowIndex, colpaidCash));
                //    short BoxId = Convert.ToInt16(view.GetListSourceRowCellValue(e.ListSourceRowIndex, colBoxId));
                //    short BankId = Convert.ToInt16(view.GetListSourceRowCellValue(e.ListSourceRowIndex, colBankId));
                //    int CustId = Convert.ToInt32(view.GetListSourceRowCellValue(e.ListSourceRowIndex, colCustId));
                //    switch (GetFocusedObj.IsCash)
                //    {
                //        case 1 when (paidCash > 0 && BankAmount > 0):

                //            e.Value = Session.Boxes?.FirstOrDefault(x => x.ID == BoxId)?.Name + " - "
                //                + Session.Banks?.FirstOrDefault(x => x.ID == BankId)?.Name;
                //            break;
                //        case 1 when (paidCash > 0 && BankAmount <= 0):
                //            e.Value = Session.Boxes?.FirstOrDefault(x => x.ID == BoxId)?.Name;
                //            break;
                //        case 1 when (paidCash <= 0 && BankAmount > 0):
                //            e.Value = Session.Banks?.FirstOrDefault(x => x.ID == BankId)?.Name;
                //            break;
                //        case 2:
                //            e.Value = Session.Customers?.FirstOrDefault(x => x.ID == CustId)?.Name;
                //            break;
                //        default:
                //            break;
                //    }
                //}
            //}
            //catch (Exception)
            //{
            //    return;
            //}
        }

        private void GridView_HideCustomizationForm(object sender, EventArgs e)
        {
            ClsPath.SaveCustomContol(this.gridView, this.Name + this.supplyType);
        }
        private void GridView_ShowCustomizationForm(object sender, EventArgs e)
        {
            ((GridView)sender).CustomizationForm.Text = "تحديد الأعمده";
        }
        SupplyType supplyType;
        private void entityInstantFeedbackSource1_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = db.SupplyMains.Where(x => x.Date >=Session.CurrentYear.DateStart 
            && x.Date <= Session.CurrentYear.DateEnd&& (x.Status ==(byte)supplyType)&&x.BrnId==Session.CurrentBranch.ID&&!x.IsDelete&&!x.SendToserver).AsNoTracking();
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
            e.ChildList = db.SupplySubs.Where(x => x.ParentID == GetFoucsedSupplyMainId).ToList();
        }
        private int GetFoucsedSupplyMainId => Convert.ToInt32(gridView.GetFocusedRowCellValue(colID));
        private byte GetFoucSuStatus => (byte)gridView.GetFocusedRowCellValue(colStatus);

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
           
            DataUpdate();
        }
        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            //try
            //{
                if (e.Value == null) return;
                if (e.Column.FieldName == colStatus.FieldName && !string.IsNullOrEmpty(e?.Value.ToString()))
                    e.DisplayText = ClsSupplyStatus.GetString(Convert.ToByte(e?.Value), (byte)gridView.GetListSourceRowCellValue(e.ListSourceRowIndex, colIsCash));
                else if (e.Column.FieldName == colCurrency.FieldName && ((e.Value as byte?) ?? 0) != 0)
                    e.DisplayText = Session.Currencies?.FirstOrDefault(x => x.ID == ((e.Value as byte?) ?? 0))?.Name;
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
            //foreach (GridColumn c in gridView.Columns)
            //    _resource.ApplyResources(c, c.Name, _ci);
            //foreach (GridColumn c in gridView1.Columns)
            //    _resource.ApplyResources(c, c.Name, _ci);
        }
        private string GetMssg(string m,int No) => string.Format(_resource.GetString(m),No);
        private SupplyMain GetFocusedObj=>(gridView.GetFocusedRow() as ReadonlyThreadSafeProxyForObjectFromAnotherThread)?.OriginalRow as SupplyMain;
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
            if (SupplyType.SalesRtrn == supplyType)
            {
                TextEdit editor = new TextEdit();
                editor.Properties.UseSystemPasswordChar = true;
                XtraInputBoxArgs inputBoxArgs = new XtraInputBoxArgs();
                inputBoxArgs.Editor = editor;
                inputBoxArgs.Caption = "تأكيد";
                inputBoxArgs.Prompt = "يرجى إدخال الرقم السري:";
                var result = XtraInputBox.Show(inputBoxArgs)?.ToString();
                if (result != "134589")
                {
                    ClsXtraMssgBox.ShowError("عذراً الرقم السري غير صحيح");
                    return;
                }
            }
            FormEntryMain frm = new FormEntryMain(null, null,(supplyType==SupplyType.Sales?UserControls.Sale: UserControls.SaleRtrn), this.ParentForm);
            frm.FormClosed += Frm_FormClosed;
            frm.Show();
        }
        public virtual void Delete()
        {
            if (GetFocusedObj == null) return;
            if (ClsXtraMssgBox.ShowWarningYesNo(GetMssg(GetFoucSuStatus == (byte)SupplyType.Sales ? "delSaleMssg" : "delSaleRtrnMssg", GetFocusedObj.No)) == DialogResult.No) return;
            var temp = db.SupplyMains.FirstOrDefault(x => x.ID == GetFocusedObj.ID);
            if (temp != null) { temp.IsDelete = true; db.SubmitChanges(); }
            flyDialog.ShowDialogUCCustomdMsg(this, GetMssg(GetFoucSuStatus == (byte)SupplyType.Sales ? "delSaleSuccessMssg" : "delSaleRtrnSuccessMssg", GetFocusedObj.No));
            InitData();
        }
        public virtual void Print(PrintFileType printFileType = PrintFileType.Printer)
        {
            if (!ValidateData()) return;
            int id=0;
            if (!string.IsNullOrEmpty(toolStTxtInvoNo.Text))
                id = int.Parse(toolStTxtInvoNo.Text);
            else if(GetFocusedObj is SupplyMain tSupplyMain&& tSupplyMain != null)
                id = tSupplyMain.No;
            bool temp = false;
            switch (printFileType)
            {
                case PrintFileType.Printer:
                    if (Session.CurrSettings.ShowPrintMssg)
                        if (ClsXtraMssgBox.ShowQuesPrint(GetMssg("printMssg", id)) != DialogResult.Yes) return; 
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
                Task.Run(() => myFunaction.PrintInvoice(id, null, null, printFileType));
            else
            {
                flyDialog.WaitForm(this, 1);
                myFunaction.PrintInvoice(id, null, null, printFileType);
                flyDialog.WaitForm(this, 0);
            }
        }
        MyFunaction myFunaction = new MyFunaction();
        public virtual void DataUpdate()
        {
            SupplyMain supplyMain = new SupplyMain();
            supplyMain = myFunaction.GetCopyFromSupplyMain(GetFocusedObj);
            if (supplyMain == null) return;
            if (supplyMain.Status != (byte)SupplyType.Sales) return;
            //formSupplyMain frm =new formSupplyMain(supplyMain, myFunaction.GetCopyFromSupplySub(db.SupplySubs.Where(x => x.ParentID == supplyMain.ID).ToList()), SupplyType.Sales, this.ParentForm);
            FormEntryMain frm = new FormEntryMain(supplyMain, myFunaction.GetCopyFromSupplySub(db.SupplySubs.Where(x => x.ParentID == supplyMain.ID).ToList()),UserControls.Sale, this.ParentForm);
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
