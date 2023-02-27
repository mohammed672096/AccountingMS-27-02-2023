using AccountingMS.ReportCustomModels;
using AccountingMS.Reports;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UserDesigner;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AccountingMS.Forms
{
    public partial class frm_BarcodeTemplates : XtraForm
    {
        private log4net.ILog log = LogHelper.GetLogger();

        public frm_BarcodeTemplates()
        {
            frm_PrintItemBarcode.CheckIfTableExist();
            InitializeComponent();

        }

        rtp_Barcode report;
        private void GridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var row = gridView1.GetRow(e.RowHandle) as BarcodeTemplates;

            if (report == null)
                report = new rtp_Barcode();
            MemoryStream stream = new MemoryStream();
            report.SaveLayout(stream);
            row.Template = stream.ToArray();
            report = null;
        }

        private void GridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void GridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var row = e.Row as BarcodeTemplates;
            if (row == null) return;
            if (string.IsNullOrEmpty(row.Name))
            {
                e.Valid = false;
                gridView1.SetColumnError(gridView1.Columns[nameof(row.Name)], "برجاء ادخال الاسم ");

            }
        }

        accountingEntities db = new accountingEntities();






        private void frm_BarcodeTemplates_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (gridView1.HasColumnErrors)
            {
                e.Cancel = true;
                return;
            }
            db.SaveChanges();
        }
        BindingList<BarcodeTemplates> bindingSource;
        private void frm_BarcodeTemplates_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'accountingDataSet.BarcodeTemplates' table. You can move, or remove it, as needed.

            bindingSource = new BindingList<BarcodeTemplates>(db.BarcodeTemplates.Select(x => x).ToList());

            gridControl1.DataSource = bindingSource;

            //  ; 
            gridView1.ValidateRow += GridView1_ValidateRow;
            gridView1.InvalidRowException += GridView1_InvalidRowException;
            gridView1.InitNewRow += GridView1_InitNewRow;
            gridView1.PopupMenuShowing += GridView1_PopupMenuShowing;
            gridView1.Columns["ID"].Visible =
            gridView1.Columns["Template"].Visible = false;
            gridView1.Columns["Name"].Caption = "اسم النموذج";
            gridView1.Columns["IsDefault"].Caption = "افتراضي";
            gridView1.Columns["IsDefault"].OptionsColumn.AllowEdit = false;
            gridView1.CellValueChanged += GridView1_CellValueChanged;
            gridView1.FocusedRowChanged += GridView1_FocusedRowChanged;
            gridView1.RowCellClick += GridView1_RowCellClick;



        }




        private void GridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column.FieldName == "IsDefault")
            {
                var row = gridView1.GetRow(e.RowHandle) as BarcodeTemplates;
                if (row == null) return;
                row.IsDefault = true;
                var list = gridView1.DataSource as Collection<BarcodeTemplates>;
                for (int i = 0; i < list.Count; i++)
                    if (i != e.RowHandle)
                        list[i].IsDefault = false;

            }
        }

        private void GridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            var row = gridView1.GetFocusedRow() as BarcodeTemplates;
            if (row == null) return;
            EditingReport = new rtp_Barcode();
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(row.Template.ToArray(), 0, row.Template.ToArray().Length);
                EditingReport.LoadLayout(stream);

            }
        }

        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var temp = gridView1.GetRow(e.RowHandle) as BarcodeTemplates;
            DeleteTemplate(temp);
            db.BarcodeTemplates.Add(temp);
            db.SaveChanges();

        }
        void DeleteTemplate(BarcodeTemplates entity)
        {
            if (entity == null) return;
            db.BarcodeTemplates.RemoveRange(db.BarcodeTemplates.Where(x => x.ID == entity.ID));
            db.SaveChanges();

        }

        private void GridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
            {
                var menu = e.Menu as GridViewMenu;
                var itm = new DXMenuItem("تعديل التصميم");
                itm.Click += Itm_Click;
                menu.Items.Add(itm);

                var copy = new DXMenuItem("نسخ");
                copy.Click += Copy_Click;
                menu.Items.Add(copy);

                var delete = new DXMenuItem("حذف");
                delete.Click += Delete_Click;
                menu.Items.Add(delete);

                if (report != null)
                {
                    var past = new DXMenuItem("لصق");
                    past.Click += Past_Click;
                    menu.Items.Add(past);
                }
                var reset = new DXMenuItem("اعاده تعيين");
                reset.Click += Reset_Click;
                menu.Items.Add(reset);

            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            var row = gridView1.GetFocusedRow() as BarcodeTemplates;
            if (row != null)
            {
                if (XtraMessageBox.Show("هل تريد الحذف", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DeleteTemplate(row);
                    gridView1.DeleteSelectedRows();
                }
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("هل تريد اعاده تعيين هذا التصميم ؟ ", "", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            var row = gridView1.GetFocusedRow() as BarcodeTemplates;
            var rpt = new rtp_Barcode();
            using (MemoryStream stream = new MemoryStream())
            {
                rpt.SaveLayout(stream);
                row.Template = stream.ToArray();
            }

        }

        private void Past_Click(object sender, EventArgs e)
        {
            var row = gridView1.GetFocusedRow() as BarcodeTemplates;
            if (row == null) return;
            if (report == null)
                report = new rtp_Barcode();
            using (MemoryStream stream = new MemoryStream())
            {
                report.SaveLayout(stream);
                row.Template = stream.ToArray();
                report = null;
            }
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            var row = gridView1.GetFocusedRow() as BarcodeTemplates;
            using (MemoryStream stream = new MemoryStream())
            {


                stream.Write(row.Template.ToArray(), 0, row.Template.ToArray().Length);
                if (report == null)
                    report = new rtp_Barcode();
                report.LoadLayout(stream);
            }
        }

        private void Itm_Click(object sender, EventArgs e)
        {
            db.SaveChanges();

            try
            {
                this.log.Debug("INisdeNewTry");
                var row = gridView1.GetFocusedRow() as BarcodeTemplates;

                if (row == null) return;

                rtp_Barcode rprt = new rtp_Barcode();

                using (MemoryStream stream = new MemoryStream())
                {
                    stream.Write(row.Template.ToArray(), 0, row.Template.ToArray().Length);
                    rprt.LoadLayout(stream);
                }
                this.log.Debug("PassedInitReport");

                formReportDesigner frm = new formReportDesigner(rprt, row);
                frm.ShowDialog();
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(exception.Message);
                string errorLog = $"StartThreadExcptionEventHandler Date : {DateTime.Now:dd-MM-yyyy HH:mm:ss} \n ExceptionInnerException => {exception.InnerException} \n ExceptionMessage => {exception.Message} " +
                $"\n Exception.Source => {exception.Source} \n ExceptionStackTrace =>{exception.StackTrace} \n Exception.StackTrace.ToString() => {exception.StackTrace.ToString()} \n ExceptionToString =>{exception.ToString()} " +
                $"\n ExceptionTargetSite => {exception.TargetSite} \n BaseException() => {exception.GetBaseException()} \nEndThreadExcptionEventHandler Date : {DateTime.Now:dd-MM-yyyy HH:mm:ss} \n";
                this.log.Debug($"tryNew \n{exception}");
            }

            //var row = gridView1.GetFocusedRow() as BarcodeTemplates;
            //if (row == null) return;
            //// EditingReport = row.ID;
            //EditingReport = new Reports.rtp_Barcode();

            //using (MemoryStream stream = new MemoryStream())
            //{
            //    stream.Write(row.Template.ToArray(), 0, row.Template.ToArray().Length);
            //    EditingReport.LoadLayout(stream);
            //}


            //            EditingReport.DataSource = GetDummyData();


            //XRDesignMdiController mdiController;
            ////  rpt.ShowDesigner();
            //XRDesignForm form = new XRDesignForm();
            //mdiController = form.DesignMdiController;

            //// Handle the DesignPanelLoaded event of the MDI controller,
            //// to override the SaveCommandHandler for every loaded report.
            //mdiController.DesignPanelLoaded +=
            //    new DesignerLoadedEventHandler(mdiController_DesignPanelLoaded);

            //// Open an empty report in the form.
            //mdiController.OpenReport(EditingReport);

            //try
            //{
            //    // Show the form.
            //    form.ShowDialog();

            //}
            //catch
            //{
            //    form.ShowDialog();
            //}
            //finally
            //{
            //    if (mdiController.ActiveDesignPanel != null)
            //    {
            //        mdiController.ActiveDesignPanel.CloseReport();
            //    }
            //    using (MemoryStream stream = new MemoryStream())
            //    {
            //        EditingReport.SaveLayout(stream);
            //        row.Template = stream.ToArray();
            //    }
            //    GridView1_CellValueChanged(sender, new DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs(gridView1.FocusedRowHandle,
            //        gridView1.Columns["Template"], row.Template));
            //}

        }
        //private void OnDesignerLoaded(object sender, DesignerLoadedEventArgs e)
        //{
        //    BindingSource bs = new BindingSource();
        //    bs.DataSource = typeof(BarcodeData);
        //    List<BarcodeData> data =
        //    for (int i = 0; i < data.Count; i++)
        //    {
        //        bs.Add(data[i]);
        //    }
        //    DesignToolHelper.AddToContainer(e.DesignerHost, bs);
        //}
        List<BarcodeData> GetDummyData()
        {
            return new List<BarcodeData>() {
             new BarcodeData()
                {
                    Barcode ="22334455667",
                    Code ="12-3",
                    CompanyName ="شركه المجد",
                    ID = 12,
                    Notes ="هنا تضع الملاحظات",
                    Price =15.5,
                    ProductName ="لحم جمل"
                },
                 new BarcodeData()
                {
                    Barcode ="28544450007",
                    Code ="16-7",
                    CompanyName ="شركه المجد",
                    ID = 13,
                    Notes ="هنا تضع الملاحظات",
                    Price =12.5,
                    ProductName ="لحم بقري"
                }
            };
        }
        static rtp_Barcode EditingReport;


        void mdiController_DesignPanelLoaded(object sender, DesignerLoadedEventArgs e)
        {
            XRDesignPanel panel = (XRDesignPanel)sender;
            panel.AddCommandHandler(new SaveCommandHandler(panel));
        }
        public class SaveCommandHandler : DevExpress.XtraReports.UserDesigner.ICommandHandler
        {
            XRDesignPanel panel;

            public SaveCommandHandler(XRDesignPanel panel)
            {
                this.panel = panel;
            }

            public void HandleCommand(DevExpress.XtraReports.UserDesigner.ReportCommand command,
                object[] args)
            {
                // Save the report.
                Save();
            }

            public bool CanHandleCommand(DevExpress.XtraReports.UserDesigner.ReportCommand command,
                ref bool useNextHandler)
            {
                useNextHandler = !(command == ReportCommand.SaveFile ||
                                   command == ReportCommand.SaveFileAs);
                return !useNextHandler;
            }

            void Save()
            {
                panel.ReportState = ReportState.Saved;
            }
        }
    }
}

