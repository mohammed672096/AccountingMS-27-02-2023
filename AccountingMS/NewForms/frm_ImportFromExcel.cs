using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.DataAccess.Excel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraSplashScreen;
using DevExpress.SpreadsheetSource;


namespace ERP.Forms
{
    public partial class frm_ImportFromExcel : XtraDialogForm  
    {
        DataTable dataTable = new DataTable();
        public frm_ImportFromExcel(ref DataTable _dataTable )
        {
            InitializeComponent();
            dataTable = _dataTable;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            XtraOpenFileDialog dialog = new XtraOpenFileDialog();
            dialog.Filter = "Excel File(*.xls)|*.xls|Excel File(*.xlsx)|*.xlsx";
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            textEdit1.Text = dialog.FileName;
          
        }
        private void textEdit1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cb_Sheets.Properties.Items.Clear();
                cb_Sheets.Properties.Items.AddRange(GetExcelSheetNames(textEdit1.Text));

            }
            catch 
            {
              
            }
           

           
        }
        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            
        }
        
        public static string[] GetExcelSheetNames(string filelocation)
        {



           


            using (ISpreadsheetSource spreadsheetSource = SpreadsheetSourceFactory.CreateSource(filelocation))
            {
                IWorksheetCollection worksheetCollection = spreadsheetSource.Worksheets;
              return worksheetCollection.Select(x=>x.Name).ToArray();
            }
           


        }

        private void cb_Sheets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Sheets.SelectedIndex >= 0 && cb_Sheets.Text != string.Empty )
            {
                 try
                 { 
                     gridControl1.DataSource = null;
                     gridView1.Columns.Clear();

                    ExcelDataSource ds = new ExcelDataSource();
                    ds.FileName = textEdit1.Text ;
                    DevExpress.DataAccess.Excel.ExcelSourceOptions excelSourceOptions1 = new DevExpress.DataAccess.Excel.ExcelSourceOptions();
                    DevExpress.DataAccess.Excel.ExcelWorksheetSettings excelWorksheetSettings1 = new DevExpress.DataAccess.Excel.ExcelWorksheetSettings();
                    excelWorksheetSettings1.WorksheetName = cb_Sheets .Text ;
                    excelSourceOptions1.ImportSettings = excelWorksheetSettings1;
                    ds.SourceOptions = excelSourceOptions1;
                    ds.Fill();

                    gridControl1.DataSource = ds;
                    gridView1.PopulateColumns();
                    
                 }
                 catch (Exception exception)
                 {
                     MessageBox.Show(exception.Message);
                 }
            }
        }

        private void gridView1_DataSourceChanged(object sender, EventArgs e)
        {

           

              
             cb_Balance.Properties.Items.Clear();
             cb_Barcode.Properties.Items.Clear();
            cb_BuyPrice.Properties.Items.Clear();
             cb_Company.Properties.Items.Clear();
               cb_Group.Properties.Items.Clear();
                cb_Name.Properties.Items.Clear();
           cb_SellPrice.Properties.Items.Clear();
                 cb_UOM.Properties.Items.Clear();

            cb_Balance.Properties.Items.Add("");
            cb_Barcode.Properties.Items.Add("");
            cb_BuyPrice.Properties.Items.Add("");
            cb_Company.Properties.Items.Add("");
            cb_Group.Properties.Items.Add("");
            cb_Name.Properties.Items.Add("");
            cb_SellPrice.Properties.Items.Add("");
            cb_UOM.Properties.Items.Add("");
            foreach (GridColumn column in gridView1.Columns  )
            {
               
              
             cb_Balance.Properties.Items.Add(column.FieldName );
             cb_Barcode.Properties.Items.Add(column.FieldName);
            cb_BuyPrice.Properties.Items.Add(column.FieldName);
             cb_Company.Properties.Items.Add(column.FieldName);
               cb_Group.Properties.Items.Add(column.FieldName);
                 cb_Name.Properties.Items.Add(column.FieldName);
                 cb_SellPrice.Properties.Items.Add(column.FieldName);
                 cb_UOM.Properties.Items.Add(column.FieldName);
            }
        }
        OverlayTextPainter overlayLabel = new OverlayTextPainter();

        private void simpleButton1_Click(object sender, EventArgs e)
        {


            IOverlaySplashScreenHandle overlayHandle = SplashScreenManager.ShowOverlayForm(this, false, false, Color.Gray, Color.Navy, 45, customPainter: new OverlayWindowCompositePainter(overlayLabel));
             
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con); 
            for (int i = Convert.ToInt32(spn_Start.EditValue)-1 ; i < gridView1.RowCount ; i++)
            {
                if (gridView1.GetRowCellValue(i, cb_Name.Text) != null && gridView1.GetRowCellValue(i, cb_Name.Text) != DBNull.Value &&
                    gridView1.GetRowCellValue(i, cb_Name.Text).ToString().Trim() != "")
                {


                    overlayLabel.Text = (i / gridView1.RowCount * 100).ToString();
                    DataRow row = dataTable.NewRow();
                    row["ItemName"] = gridView1.GetRowCellValue(i, cb_Name.Text);
                    if (cb_Balance.SelectedIndex > 0)
                        row["OpenBalance"] = gridView1.GetRowCellValue(i, cb_Balance.Text);
                    if (cb_Barcode.SelectedIndex > 0)
                        row["Barcode"] = gridView1.GetRowCellValue(i, cb_Barcode.Text);
                    if (cb_BuyPrice.SelectedIndex > 0)
                        row["BuyPrice"] = gridView1.GetRowCellValue(i, cb_BuyPrice.Text);
                    if (cb_Company.SelectedIndex > 0 &&  gridView1.GetRowCellValue(i, cb_Company.Text) !=null )
                    {
                        var companyID = db.Inv_Companies.Where(x => x.Name == gridView1.GetRowCellValue(i, cb_Company.Text).ToString()).Select(x => x.ID)
                            .FirstOrDefault();
                        DAL.Inv_Company company = new DAL.Inv_Company()
                        {
                            Name = gridView1.GetRowCellValue(i, cb_Company.Text).ToString()
                        };
                        if (companyID == 0)
                        {
                            db.Inv_Companies.InsertOnSubmit(company);
                            db.SubmitChanges();
                            companyID = company.ID;
                        }
                        row["Company"] = companyID;

                    }
                    if (cb_UOM.SelectedIndex > 0)
                    {
                        if(gridView1.GetRowCellValue(i, cb_UOM.Text) != null &&
                            gridView1.GetRowCellValue(i, cb_UOM.Text) != DBNull.Value &&
                            gridView1.GetRowCellValue(i, cb_UOM.Text) .ToString() !="")
                        {
                            var UOMID = db.Inv_UOMs.Where(x => x.Name == gridView1.GetRowCellValue(i, cb_UOM.Text).ToString()).Select(x => x.ID)
                         .FirstOrDefault();

                            DAL.Inv_UOM uom = new DAL.Inv_UOM()
                            {
                                Name = gridView1.GetRowCellValue(i, cb_UOM.Text).ToString()
                            };
                            if (UOMID == 0)
                            {
                                db.Inv_UOMs.InsertOnSubmit(uom);
                                db.SubmitChanges();
                                UOMID = uom.ID;
                            }
                            row["UOM"] = UOMID;

                        }


                    }

                    if (cb_Group.SelectedIndex > 0&& gridView1.GetRowCellValue(i, cb_Group.Text)!=null )
                    {
                        var GroupID = db.Inv_ItemGroups.Where(x => x.Name == gridView1.GetRowCellValue(i, cb_Group.Text).ToString()).Select(x => x.Number)
                            .FirstOrDefault();
                        DAL.Inv_ItemGroup group = new DAL.Inv_ItemGroup()
                        {
                            Name = gridView1.GetRowCellValue(i, cb_Group.Text).ToString()
                            ,
                            Number = GetNewNumber(1)
                            ,
                            ParentID = 1
                        };
                        if (GroupID == 0)
                        {
                            db.Inv_ItemGroups.InsertOnSubmit(group);
                            db.SubmitChanges();
                            GroupID = group.Number;
                        }
                        row["Group"] = GroupID;

                    }
                    if (cb_SellPrice.SelectedIndex > 0)

                        row["SellPrice"] = gridView1.GetRowCellValue(i, cb_SellPrice.Text);
                    dataTable.Rows.Add(row);

                }
            }

            SplashScreenManager.CloseOverlayForm(overlayHandle);

        }
        int GetNewNumber(int? parent)
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

            try
            {
                return (int)db.Inv_ItemGroups.Where(n => n.ParentID == parent).Max(n => n.Number) + 1;

            }
            catch
            {
                return (int)parent * 100 + 1;


            }

        }
    }
}
