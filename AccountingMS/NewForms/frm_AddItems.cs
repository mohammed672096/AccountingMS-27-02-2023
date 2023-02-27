using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace ERP.Forms
{
    public partial class frm_AddItems : XtraForm
    {
        private DataTable maDataTable = new DataTable();

        public frm_AddItems()
        {
            InitializeComponent();
        }
        
        private void frm_AddItems_Load(object sender, EventArgs e)
        {
            LoadData();
            lkp_Company.ItemIndex = 0;
            lkp_Store.ItemIndex = 0;
            lkp_UOM.ItemIndex = 0;
            Treelkp_Group.EditValue = 1;

            IntDataTable();
        }

        void IntDataTable()
        {
            maDataTable = new DataTable();
  
            maDataTable.Columns.Add("ItemName",typeof (string)).Caption= LangResource.Name   ;
            maDataTable.Columns.Add("Group",typeof(Int32)).Caption = LangResource.ItemGroup ;
            maDataTable.Columns.Add("Company", typeof(Int32)).Caption = LangResource.Company ;
            maDataTable.Columns.Add("Warrenty", typeof(bool )).Caption = LangResource.Warranty ;
            maDataTable.Columns.Add("Expire", typeof(bool)).Caption = LangResource.Expier ;
            maDataTable.Columns.Add("Color", typeof(bool)).Caption = LangResource.Color ;
            maDataTable.Columns.Add("Serial", typeof(bool)).Caption = LangResource.Serial ;
            maDataTable.Columns.Add("Size", typeof(bool)).Caption = LangResource.Size ;
            maDataTable.Columns.Add("UOM", typeof(Int32)).Caption = LangResource.UOM ;
            maDataTable.Columns.Add("BuyPrice", typeof(double )).Caption = LangResource.BuyPrice ;
            maDataTable.Columns.Add("SellPrice", typeof(double)).Caption = LangResource.SellPrice ;
            maDataTable.Columns.Add("barcode", typeof(string )).Caption = LangResource.Barcode ;
            maDataTable.Columns.Add("Store").Caption = LangResource.Store ; 
            maDataTable.Columns.Add("OpenBalance", typeof(double)).Caption = LangResource.OpenBalance;

            gridControl1 .DataSource = maDataTable; 

            gb_MainInfo.Columns.Clear();
            gb_ItemProp.Columns.Clear();
            gb_UOM.Columns.Clear();
            gb_Stock.Columns.Clear(); 

            gb_MainInfo.Columns.Add(bandedGridView1.Columns["ItemName"]);
            gb_MainInfo.Columns.Add(bandedGridView1.Columns["Group"]);
            gb_MainInfo.Columns.Add(bandedGridView1.Columns["Company"]);

            gb_ItemProp.Columns.Add(bandedGridView1.Columns["Warrenty"]);
            gb_ItemProp.Columns.Add(bandedGridView1.Columns["Expire"]  );
            gb_ItemProp.Columns.Add(bandedGridView1.Columns["Color"]   );
            gb_ItemProp.Columns.Add(bandedGridView1.Columns["Serial"]   );
            gb_ItemProp.Columns.Add(bandedGridView1.Columns["Size"]    );

            gb_UOM.Columns.Add(bandedGridView1.Columns["UOM"]);
            gb_UOM.Columns.Add(bandedGridView1.Columns["BuyPrice"]);
            gb_UOM.Columns.Add(bandedGridView1.Columns["SellPrice"]);
            gb_UOM.Columns.Add(bandedGridView1.Columns["barcode"]);

            gb_Stock .Columns.Add(bandedGridView1.Columns["Store"]); 
            gb_Stock.Columns.Add(bandedGridView1.Columns["OpenBalance"]);

            bandedGridView1.Columns["Warrenty"].ColumnEdit =
                bandedGridView1.Columns["Expire"].ColumnEdit =
                    bandedGridView1.Columns["Color"].ColumnEdit =
                        bandedGridView1.Columns["Serial"].ColumnEdit =
                            bandedGridView1.Columns["Size"].ColumnEdit = repositoryItemCheckEdit1;

            bandedGridView1.Columns["Group"].ColumnEdit = repoGroup;
            bandedGridView1.Columns["Company"].ColumnEdit = repoCompany ;
            bandedGridView1.Columns["UOM"].ColumnEdit = repoUOM ;
            bandedGridView1.Columns["Store"].ColumnEdit = repoStore;

            RepositoryItemSpinEdit repospin = new RepositoryItemSpinEdit();

            bandedGridView1.Columns["BuyPrice"].ColumnEdit =
                bandedGridView1.Columns["SellPrice"].ColumnEdit =
                    bandedGridView1.Columns["OpenBalance"].ColumnEdit = repospin;
             
        }

        public void LoadData()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

            var companys = from c in db.Inv_Companies select c;
            var group = from g in db.Inv_ItemGroups select g;


            lkp_Company.Properties.DataSource = repoCompany.DataSource = companys.ToList();
            lkp_Company.Properties.ValueMember = repoCompany.ValueMember  = "ID";
            lkp_Company.Properties.DisplayMember = repoCompany.DisplayMember =  "Name";
            lkp_Company.Properties.PopulateColumns();
            lkp_Company.Properties.Columns[0].Visible = false;

            Treelkp_Group.Properties.DataSource = repoGroup .DataSource  = group.ToList();
            Treelkp_Group.Properties.ValueMember= repoGroup.ValueMember  = "Number";
            Treelkp_Group.Properties.DisplayMember= repoGroup.DisplayMember  = "Name";
            Treelkp_Group.Properties.TreeList.ParentFieldName = repoGroup.TreeList.ParentFieldName  = "ParentID";
            Treelkp_Group.Properties.TreeList.KeyFieldName= repoGroup.TreeList.KeyFieldName = "Number";

            var UOM = from u in db.Inv_UOMs  select u;
            lkp_UOM .Properties.DataSource=repoUOM.DataSource  = UOM.ToList();
            lkp_UOM .Properties.ValueMember=repoUOM.ValueMember  = "ID";
            lkp_UOM .Properties.DisplayMember=repoUOM.DisplayMember  = "Name";

            var store = (from s in db.Inv_Stores select new { s.ID, s.Name }).ToList();
            lkp_Store.Properties.DataSource =repoStore .DataSource  = store;
            lkp_Store.Properties.ValueMember = repoStore.ValueMember = "ID";
            lkp_Store.Properties.DisplayMember = repoStore.DisplayMember = "Name";

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            gridControl1.Enabled = false;
            btn_Save.Enabled = false;
            Thread t = new Thread(Submit);
            t.Start();
            //   Submit();

        }

        void RefreshData()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con); 
            CurrentSession.Products = (from c in db.Inv_Items select c).ToList();
            CurrentSession.ProductsUints = (from c in db.Inv_ItemUnits select c).ToList();
            Master.RefreshAllWindows();
        }
        private void chk_Warranty_CheckedChanged(object sender, EventArgs e)
        {
            spn_Warranty.Visible = chk_Warranty.Checked; 
        }

        private void chk_Expire_CheckedChanged(object sender, EventArgs e)
        {
            spn_Expire.Visible = chk_Expire.Checked;

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frm_Main.OpenForm(new frm_Inv_Company(), InDialog: true);
            LoadData();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            frm_Main.OpenForm(new frm_ItemGroup(), InDialog: true);
            LoadData();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            frm_Main.OpenForm(new frm_UOM(),InDialog: true);
            LoadData();
        }

        private void btn_New_Click(object sender, EventArgs e)
        {

            if (gridControl1.Enabled ==false ||  XtraMessageBox.Show("لم يتم حفظ هذه الاصناف بعد " +
                                    "<br> هل تريد ازاله الاصناف ؟ ", 
                    allowHtmlText: DefaultBoolean.True ,caption:"",buttons: MessageBoxButtons.YesNo,icon: MessageBoxIcon.Stop ) == DialogResult.Yes )
            {
                IntDataTable();
                gridControl1.Enabled = true ;
                btn_Save.Enabled = true;
                memoEdit1.Text = String.Empty;
            }
        }
        int GetNextItemID()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

            try
            {
                return (int)db.Inv_Items.Max(n => n.ID) + 1;

            }
            catch
            {
                return (int)1;


            }
        }
        int GetOpenBalanceNextID()
        {
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
            try
            {
                return (int)db.Inv_ItemOpenBalances.Max(n => n.ID) + 1;
            }
            catch
            {
                return (int)1;
            }
        }
        public static string GetMaxCode()
        {
            DAL.ERPDataContext dbs = new DAL.ERPDataContext(Program.setting.con);
            try
            {
                var ST = dbs.Inv_Items.Max(n => n.Code);
                if (ST != null) return ST;
            }
            catch
            {

            }
            return "PRD000000";
        }
        void Submit()
        {
           
            DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con); 
           

            this .Invoke(new Action(() => simpleLabelItem1.Text = "جاري الحفظ .... " ));
            progressBarControl1.Invoke( new Action (() => progressBarControl1.Position = 0)); 
            progressBarControl1.Invoke(new Action(() => progressBarControl1.Properties.Maximum = maDataTable.Rows.Count));
            //
            foreach (DataRow  row in maDataTable.Rows)
            {
                // 
                progressBarControl1.Invoke(new Action(() => progressBarControl1.Position++));
                this .Invoke(new Action(() => simpleLabelItem2.Text = ("جاري تجهيز صنف رقم "+ progressBarControl1.Position + " من " + progressBarControl1.Properties.Maximum + " صنف ")));
                //


                if (row["ItemName"] != null && row["ItemName"] != DBNull.Value &&
                    row["ItemName"].ToString().Trim() != string.Empty         )
                {
                    if (db.Inv_Items.Where(x => x.Name == row["ItemName"].ToString().TrimEnd().TrimStart()).Count() ==     0)
                    {


                        this.Invoke(new Action(() =>
                            memoEdit1.Text += Environment.NewLine + "جاري تجهيز " +
                                              row["ItemName"].ToString().TrimEnd().TrimStart()));

                      var item = new Inv_Item()
                        { 
                            Code = (row["Barcode"] == null
                                 || row["Barcode"] == null)
                                    ? Master.GetNextNumberInString(GetMaxCode())
                                    : row["Barcode"].ToString().Trim(),
                            Name = row["ItemName"].ToString().TrimEnd().TrimStart(),
                            Company = (row["Company"] != DBNull.Value && row["Company"] != null)
                                ? Convert.ToInt16(row["Company"])
                                : Convert.ToInt16(lkp_Company.EditValue),
                            GroupID = (row["Group"] != DBNull.Value && row["Group"] != null)
                                ? Convert.ToInt16(row["Group"])
                                : Convert.ToInt16(Treelkp_Group.EditValue),
                            Expier = (row["Expire"] != DBNull.Value && row["Expire"] != null)
                                ? Convert.ToBoolean(row["Expire"])
                                : chk_Expire.Checked,
                            Color = (row["Color"] != DBNull.Value && row["Color"] != null)
                                ? Convert.ToBoolean(row["Color"])
                                : chk_Color.Checked,
                            Serial = (row["Serial"] != DBNull.Value && row["Serial"] != null)
                                ? Convert.ToBoolean(row["Serial"])
                                : chk_Serial.Checked,
                            Size = (row["Size"] != DBNull.Value && row["Size"] != null)
                                ? Convert.ToBoolean(row["Size"])
                                : chk_Size.Checked,
                            ShelfLife = Convert.ToInt16(spn_Expire.EditValue),
                            WarntyDuration = Convert.ToInt16(spn_Warranty.EditValue),
                        };
                        db.Inv_Items.InsertOnSubmit(item);
                        db.SubmitChanges();
                        db.Inv_ItemUnits.InsertOnSubmit (new Inv_ItemUnit()
                        {
                            ItemID = item.ID ,
                            UnitID = (row["UOM"] != DBNull.Value && row["UOM"] != null)
                                ? Convert.ToInt32(row["UOM"])
                                : Convert.ToInt32(lkp_UOM.EditValue),
                            BuyPrice = (row["BuyPrice"] != DBNull.Value && row["BuyPrice"] != null)
                                ? Convert.ToDouble(row["BuyPrice"])
                                : 0,
                            SellPrice = (row["SellPrice"] != DBNull.Value && row["SellPrice"] != null)
                                ? Convert.ToDouble(row["SellPrice"])
                                : 0,
                            DefualtBuy = true,
                            DefualtSell = true,
                            //Barcode =
                            //    (row["Barcode"] == null
                            //     || row["Barcode"] == null)
                            //        ? NextID.ToString().Trim()
                            //        : row["Barcode"].ToString().Trim(),
                            Factor = 1
                        });
                        db.Inv_ItemBarcodes.InsertOnSubmit(new Inv_ItemBarcode()
                        {
                         ItemID = item.ID,
                            UnitID = (row["UOM"] != DBNull.Value && row["UOM"] != null)
                                ? Convert.ToInt32(row["UOM"])
                                : Convert.ToInt32(lkp_UOM.EditValue),
                            Barcode = (row["Barcode"] == null
                                 || row["Barcode"] == null)
                                    ? item.ID.ToString().Trim()
                                    : row["Barcode"].ToString().Trim()
                        });
                        db.SubmitChanges();

                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                            memoEdit1.Text += Environment.NewLine + "هذا الصنف موجود بالفعل  " +
                                              row["ItemName"].ToString().TrimEnd().TrimStart()));
                    }
                }
            }

             
             
            this.Invoke(new Action(() =>
                memoEdit1.Text += Environment.NewLine + "تم حفظ الاصناف "));
             
            if (checkEdit1.Checked)
            {
                this.Invoke(new Action(() => simpleLabelItem2.Text = "جاري تجهيز بيانات مستند الرصيد الافتتاحي "));
                DAL.Inv_ItemOpenBalance openBalance = new Inv_ItemOpenBalance()
                {
                    ID = GetOpenBalanceNextID(),
                    BranchID = Convert.ToInt32(lkp_Store.EditValue ),
                    Date = db.GetSystemDate(),
                    UserID = CurrentSession.user.ID ,
                    Notes ="تم الانشاء من شاشه اضافه الاصناف "
                };
                List<DAL.Inv_ItemOpenBalanceDetail> details = new List<Inv_ItemOpenBalanceDetail>(); 
                foreach (DataRow row in maDataTable.Rows)
                {
                    if (row["ItemName"] != null && row["ItemName"] != DBNull.Value &&
                        row["ItemName"].ToString().Trim() != string.Empty &&
                        db.Inv_Items.Where(x => x.Name == row["ItemName"].ToString().TrimEnd().TrimStart()).Count() > 0)
                    {
                        if((row["OpenBalance"] != null && row["OpenBalance"] != DBNull.Value && row["OpenBalance"].ToString().Trim() != string.Empty 
                            && Convert.ToDouble(row["OpenBalance"])> 0))
                        {
                            this.Invoke(new Action(() =>
                                memoEdit1.Text += Environment.NewLine + "جاري تجهيز رصيد  " + row["ItemName"].ToString().TrimEnd().TrimStart()));

                            details.Add(new Inv_ItemOpenBalanceDetail()
                            {
                                ItemOpenBalanceID = openBalance.ID,
                                BranchID = (row["Store"] != DBNull.Value && row["Store"] != null) ? Convert.ToInt16(row["Store"]) : Convert.ToInt32(lkp_Store.EditValue),
                                ItemeQty = Convert.ToDouble(row["OpenBalance"]),
                                ItemUnitID = (row["UOM"] != DBNull.Value && row["UOM"] != null) ? Convert.ToInt32(row["UOM"]) : Convert.ToInt32(lkp_UOM.EditValue),
                                ItemID = db.Inv_Items.Where(x=>x.Name == row["ItemName"].ToString().TrimEnd().TrimStart()).Select(x=>x.ID ).First(),
                                PurchasePrice  = (row["BuyPrice"] != DBNull.Value && row["BuyPrice"] != null) ? Convert.ToDouble(row["BuyPrice"]) : 0,
                                SellPrice = (row["SellPrice"] != DBNull.Value && row["SellPrice"] != null) ? Convert.ToDouble(row["SellPrice"]) : 0,
                                TotalPurchasePrice =((row["BuyPrice"] != DBNull.Value && row["BuyPrice"] != null) ? Convert.ToDouble(row["BuyPrice"]) : 0) 
                                * Convert.ToDouble(row["OpenBalance"]),
                                TotalSellPrice= ((row["SellPrice"] != DBNull.Value && row["SellPrice"] != null) ? Convert.ToDouble(row["SellPrice"]) : 0)
                                    * Convert.ToDouble(row["OpenBalance"]),

                            });

                        }
                       
                    }
                }
                db.Inv_ItemOpenBalances.InsertOnSubmit(openBalance);
                db.SubmitChanges();
                db.Inv_ItemOpenBalanceDetails.InsertAllOnSubmit(details);
                db.SubmitChanges();
                List<Inv_StoreLog> logs = new List<Inv_StoreLog>();
                foreach (var d in details )
                {
                    logs.Add(new Inv_StoreLog()
                    {
                        BuyPrice = d.PurchasePrice  ,
                        date = openBalance.Date,
                        ItemID = d.ItemID,
                        ExpDate = db.GetSystemDate() .AddMonths(6),
                        ItemQuIN = d.ItemeQty ,
                        ItemQuOut = 0,
                        SellPrice = d.SellPrice  ,
                        Note = LangResource.OpenBalanceNumber + " " + openBalance.ID, 
                        StoreID = d.BranchID,
                        Type = 1,
                        TypeID = d.ID
                    });
                }
                db.Inv_StoreLogs.InsertAllOnSubmit(logs);
                db.SubmitChanges();
                this.Invoke(new Action(() => memoEdit1.Text += Environment.NewLine + "تم اضافه الرصيد الافتتاحي "));
            }
            this.Invoke(new Action(() => simpleLabelItem2.Text =  "....."));
            this.Invoke(new Action(() => simpleLabelItem1.Text = "تم الحفظ بنجاح"));
            this.Invoke(new Action(() => RefreshData()));
        }

        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            

                GridControl gridControl = sender as GridControl;
                GridView focusedView = gridControl.FocusedView as GridView;
                if (e.KeyCode == Keys.Return)
                {
                    GridColumn focusedColumn = (gridControl.FocusedView as ColumnView).FocusedColumn;
                    int focusedRowHandle = (gridControl.FocusedView as ColumnView).FocusedRowHandle;
                    if (focusedView.FocusedColumn == focusedView.Columns["ItemName"])
                    {

                        this.gridControl1_ProcessGridKey(sender, new KeyEventArgs(Keys.Tab));

                    }
                    
                }
                else if (e.KeyCode == Keys.Tab && e.Modifiers != Keys.Shift)
                {
                    if (focusedView.FocusedColumn.VisibleIndex == 0)
                        focusedView.FocusedColumn = focusedView.VisibleColumns[focusedView.VisibleColumns.Count - 1];
                    else
                        focusedView.FocusedColumn = focusedView.VisibleColumns[focusedView.FocusedColumn.VisibleIndex - 1];
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
                    focusedView.DeleteSelectedRows();


            }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            new frm_ImportFromExcel( ref maDataTable ).Show();
        }


        void memoEdit1_EditValueChanged(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                SetSelection();
            }));
        }
        private void SetSelection()
        {
            memoEdit1.SelectionStart = memoEdit1.Text.Length;
            memoEdit1.ScrollToCaret();
        }

        private void progressBarControl1_EditValueChanged(object sender, EventArgs e)
        {
            progressBarControl1.Refresh();
        }
    }
}
