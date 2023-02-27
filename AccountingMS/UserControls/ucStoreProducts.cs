using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class ucStoreProducts : XtraUserControl
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblProduct clsProduct;
        ClsTblPrdPriceMeasurment clsTbPrdMsur;
        ClsTblProductQtyOpn clsTbPrdQuanOpn;
        IDictionary<int, string> dictPrdBarcodeList;

        private string prdName;
        public bool FlyDialogIsNew { set; get; }
        public string FlyDialogMssg { set; get; }

        public ucStoreProducts()
        {
            InitializeComponent();
            new ClsUserControlValidation(this, UserControls.StoreProducts);

            this.Load += UcStoreProducts_Load;
            gridView1.KeyDown += GridView1_KeyDown;
            gridView1.DoubleClick += GridView1_DoubleClick;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
            //gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
        }

        private async void UcStoreProducts_Load(object sender, EventArgs e)
        {
            await InitDataAsync();
        }

        private async Task InitObjectsAsync()
        {
            flyDialog.WaitForm(this, 1);
            IList<Task> taskList = new List<Task>();

            taskList.Add(Task.Run(() => this.clsProduct = new ClsTblProduct()));
            taskList.Add(Task.Run(() => this.clsTbPrdMsur = new ClsTblPrdPriceMeasurment()));
            taskList.Add(Task.Run(() => this.clsTbPrdQuanOpn = new ClsTblProductQtyOpn()));

            await Task.WhenAll(taskList);
            await InitDicPrdBarcode();
            await InitPrdBarcodeAsync();

            flyDialog.WaitForm(this, 0);
        }

        private async Task InitPrdBarcodeAsync()
        {
            foreach (var tbPrdQuanOpn in this.clsTbPrdQuanOpn.GetProductQtyOpnList)
                tbPrdQuanOpn.prdBarcodeNo = await Task.Run(() => this.clsTbPrdMsur.GetPrdPriceMsurBarcodeById(tbPrdQuanOpn.qtyPrdMsurId));
        }

        private async Task InitDicPrdBarcode()
        {
            this.dictPrdBarcodeList = new Dictionary<int, string>();

            var tbPrdQuanOpnGrp = this.clsTbPrdQuanOpn.GetProductQtyOpnList.GroupBy(x => x.qtyPrdMsurId, (key, grp) => new tblProductQtyOpn()
            {
                qtyPrdMsurId = key
            }).ToList();

            foreach (var tbPrdQuanOpn in tbPrdQuanOpnGrp) await Task.Run(() => this.dictPrdBarcodeList.Add(tbPrdQuanOpn.qtyPrdMsurId,
                   this.clsTbPrdMsur.GetPrdPriceMsurBarcodeById(tbPrdQuanOpn.qtyPrdMsurId)));
        }

        private async Task InitDataAsync()
        {
            await InitObjectsAsync();
            tblProductQtyOpnBindingSource.DataSource = this.clsTbPrdQuanOpn.GetProductQtyOpnList;
            bsiRecord.Caption = string.Format(((!MySetting.GetPrivateSetting.LangEng) ? "العدد : {0:#,#}" : "RECORDS: {0:#,#}"), tblProductQtyOpnBindingSource.Count);
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (this.clsProduct == null || this.clsTbPrdMsur == null) return;
            if (e.Column.FieldName == "qtyPrdId")
                e.DisplayText = (!MySetting.GetPrivateSetting.LangEng) ? this.clsProduct.GetPrdNameById(Convert.ToInt32(e.Value)) : this.clsProduct.GetPrdNameEnById(Convert.ToInt32(e.Value));
            else if (e.Column.FieldName == "qtyPrdMsurId")
                e.DisplayText = this.clsTbPrdMsur.GetPrdPriceMsurNameById(Convert.ToInt32(e.Value));
        }

        private void GridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null || this.dictPrdBarcodeList == null) return;
            if (e.Column.FieldName != colprdBarcodeNo.Name) return;
            if (!e.IsGetData) return;

            int msurId = Convert.ToInt32(view.GetRowCellValue(e.ListSourceRowIndex, colqtyPrdMsurId));
            if (this.dictPrdBarcodeList.ContainsKey(msurId)) e.Value = this.dictPrdBarcodeList[msurId];


        }

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            UpdateButton();
        }

        private async void bbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ValidateDefaultStore()) return;
            flyDialog.WaitForm(this, 1);
            using (formAddPrdQtyOpn form = new formAddPrdQtyOpn(this))
            {
                flyDialog.WaitForm(this, 0);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await RefreshListDialogAsync();
                    SetFoucesdRow();
                }
            }
        }

        private async Task UpdateButton()
        {
            flyDialog.WaitForm(this, 1);
            using (formAddPrdQtyOpn form = new formAddPrdQtyOpn(this, tblProductQtyOpnBindingSource.Current as tblProductQtyOpn))
            {
                flyDialog.WaitForm(this, 0);
                if (form.ShowDialog() == DialogResult.OK) await RefreshListDialogAsync();
            }
        }

        private async void bbiNewBatch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ValidateDefaultStore()) return;
            flyDialog.WaitForm(this, 1);
            using (formAddPrdQtyOpnBatch form = new formAddPrdQtyOpnBatch(this))
            {
                flyDialog.WaitForm(this, 0);
                if (form.ShowDialog() == DialogResult.OK) await RefreshListDialogAsync();
            }
        }

        private void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblProductQtyOpnBindingSource)) return;
            UpdateButton();
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblProductQtyOpnBindingSource)) return;
            DeleteRow();
        }

        private async void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await InitDataAsync();
        }

        private void DeleteRow()
        {
            this.prdName = gridView1.GetFocusedRowCellDisplayText(colqtyPrdId) + " " + gridView1.GetFocusedRowCellDisplayText(colqtyPrdMsurId);
            string delMssg = string.Format((!MySetting.GetPrivateSetting.LangEng) ? "هل انت متاكد من حذف الرصيد الإفتتاحي للصنف : {0}؟" : "Delete Opening quantity for product : {0}?", this.prdName);
            var prdQtyList = GetPrdQty();

            if (XtraMessageBox.Show(delMssg, "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                flyDialog.WaitForm(this, 1);
                if (!CheckTblSupplySubQty()) return;
                if (new ClsTblAsset().DeleteRowByPrdMsurId((int)gridView1.GetFocusedRowCellValue(colqtyPrdMsurId)) &&
                    clsTbPrdQuanOpn.DeleteRow(gridView1.GetFocusedRow() as tblProductQtyOpn))
                {
                    tblProductQtyOpnBindingSource.RemoveCurrent();
                    flyDialog.WaitForm(this, 0);
                    flyDialog.ShowDialogUCCustomdMsg(this, string.Format((!MySetting.GetPrivateSetting.LangEng) ? "تم حذف الرصيد الإفتتاحي للصنف : {0} بنجاح." : "Successfully deleted opeing quantity for product : {0}.", this.prdName));
                }
            }
        }

        private bool CheckTblSupplySubQty()
        {
            if (new ClsTblSupplySub().CheckPrdMsur(Convert.ToInt32(gridView1.GetFocusedRowCellValue(colqtyPrdMsurId))))
            {
                flyDialog.WaitForm(this, 0);
                XtraMessageBox.Show(string.Format((!MySetting.GetPrivateSetting.LangEng) ? ".عذرا لا يمكن حذف الرصيد الإفتتاحي للصنف : {0} بسبب وجود فواتير مقيده للصنف" : "Sorry, can not delete opening quantity for product : {0}, due to related invoice(s) for the product", this.prdName));
                return false;
            }
            return true;
        }

        private List<ClsProductQuantList> GetPrdQty()
        {
            return new List<ClsProductQuantList>() { new ClsProductQuantList()
            {
                prdId = Convert.ToInt32(gridView1.GetFocusedRowCellValue(colqtyPrdId)),
                prdPriceMsurId = Convert.ToInt32(gridView1.GetFocusedRowCellValue(colqtyPrdMsurId)),
                prdQuantity = Convert.ToDouble(gridView1.GetFocusedRowCellValue(colqtyQuantity)),
                prdStrId = MySetting.DefaultSetting.defaultStrId
            }};
        }

        private bool ValidateDefaultStore()
        {
            bool isValid = (MySetting.DefaultSetting.defaultStrId == 0) ? false : true;
            if (!isValid)
            {
                string mssg = (!MySetting.GetPrivateSetting.LangEng) ? "عذراً يجب تعين المخزن الرئيسي في إعدادات النظام أولاً" : "Please select main store from system settings first";
                XtraMessageBox.Show(mssg);
            }
            return isValid;
        }

        private void GridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.U)
            {
                using var form = new formFixPrdQuanOpn();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    InitDataAsync();
                    XtraMessageBox.Show("تم الحفظ بنجاح");
                }
            }
        }

        public async Task RefreshListDialogAsync()
        {
            if (FlyDialogIsNew)
                flyDialog.ShowDialogUC(this, FlyDialogMssg);
            else
                flyDialog.ShowDialogUCUpdMsg(this, FlyDialogMssg);

            clsTbPrdQuanOpn.RefreshData();
            await InitDataAsync();
        }

        public void SetFoucesdRow()
        {
            gridView1.FocusedRowHandle = tblProductQtyOpnBindingSource.Count;
        }

    }
}
