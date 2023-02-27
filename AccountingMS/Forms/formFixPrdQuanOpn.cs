using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formFixPrdQuanOpn : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        accountingEntities db;
        ClsTblProduct clsTbProduct;
        ClsTblPrdPriceMeasurment clsTbPrdMsur;
        ClsTblProductQtyOpn clsTbPrdQuanOpn;

        private async void FormFixPrdQuanOpn_Load(object sender, EventArgs e)
        {
            await InitDataAsync();
        }

        public formFixPrdQuanOpn()
        {
            InitializeComponent();

            this.Load += FormFixPrdQuanOpn_Load;
            gridView1.CustomRowCellEditForEditing += GridView1_CustomRowCellEditForEditing;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
            gridView1.FocusedRowChanged += GridView1_FocusedRowChanged;
        }

        private async Task InitDataAsync()
        {
            await InitObjectsAsync();
            await InitDataGridAsync();
        }

        private async Task InitObjectsAsync()
        {
            IList<Task> taskList = new List<Task>();
            taskList.Add(Task.Run(() => db = new accountingEntities()));
            taskList.Add(Task.Run(() => this.clsTbProduct = new ClsTblProduct()));
            taskList.Add(Task.Run(() => this.clsTbPrdMsur = new ClsTblPrdPriceMeasurment()));
            taskList.Add(Task.Run(() => this.clsTbPrdQuanOpn = new ClsTblProductQtyOpn()));

            await Task.WhenAll(taskList);
        }

        private async Task InitDataGridAsync()
        {
            IList<tblProductQtyOpn> tbPrdQuanOpnList = new List<tblProductQtyOpn>();

            foreach (var tbPrdQuanOpn in this.clsTbPrdQuanOpn.GetProductQtyOpnList)
                if (await Task.Run(() => !this.clsTbPrdMsur.ValidatePrdMsur(tbPrdQuanOpn.qtyPrdId, tbPrdQuanOpn.qtyPrdMsurId)))
                {
                    db.tblProductQtyOpns.Attach(tbPrdQuanOpn);

                    var tbPrdMsur = await Task.Run(() => this.clsTbPrdMsur.GetPrdPriceMsurDefaultRowByPrdId(tbPrdQuanOpn.qtyPrdId));

                    tbPrdQuanOpn.qtyPrdMsurId = tbPrdMsur.ppmId;
                    tbPrdQuanOpn.qtyPrice = Convert.ToDouble(tbPrdMsur.ppmPrice);
                    tbPrdQuanOpn.prdBarcodeNo = await Task.Run(() => this.clsTbPrdMsur.GetPrdPriceMsurListByPrdId(tbPrdQuanOpn.qtyPrdId).Count().ToString());

                    tbPrdQuanOpnList.Add(tbPrdQuanOpn);
                }
            tblProductQtyOpnBindingSource.DataSource = tbPrdQuanOpnList;
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "qtyPrdId")
                e.DisplayText = (!MySetting.GetPrivateSetting.LangEng) ? this.clsTbProduct.GetPrdNameById((int)e.Value) : clsTbProduct.GetPrdNameEnById((int)e.Value);
            else if (e.Column.FieldName == "qtyPrdMsurId")
                e.DisplayText = this.clsTbPrdMsur.GetPrdPriceMsurNameById(Convert.ToInt32(e.Value));
        }

        private void GridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            tblPrdPriceMeasurmentBindingSource.DataSource = this.clsTbPrdMsur.GetPrdPriceMsurListByPrdId(Convert.ToInt32(gridView1.GetFocusedRowCellValue(colqtyPrdId)));
        }

        private void GridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == colqtyPrdMsurId.FieldName)
                e.RepositoryItem = repoItemLookUpEditPrdMsur;
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ClsSaveDB.Save(db, LogHelper.GetLogger())) DialogResult = DialogResult.OK;
        }
    }
}