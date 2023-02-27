using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class UCprdExpirateQuan : DevExpress.XtraEditors.XtraUserControl
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblProduct clsTbProduct;
        ClsTblPrdPriceMeasurment clsTbPrdMsur;
        ClsTblPrdExpirateQuan clsTbPrdExpirateQuan;
        ClsTblAsset clsTbAsset;
        ClsTblStore clsTblStore;
        private bool isNew;
        private string flyDialogMssg;

        private async void UCprdExpiration_Load(object sender, EventArgs e)
        {
            await InitDataAsync();
        }

        public UCprdExpirateQuan()
        {
            InitializeComponent();
            new ClsUserControlValidation(this, UserControls.ExpiredProducts);
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += UCprdExpiration_Load;
            gridView.DoubleClick += GridView_DoubleClick;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;

            gridView.MasterRowEmpty += GridView_MasterRowEmpty;
            gridView.MasterRowGetRelationCount += GridView_MasterRowGetRelationCount;
            gridView.MasterRowGetRelationName += GridView_MasterRowGetRelationName;
            gridView.MasterRowGetChildList += GridView_MasterRowGetChildList;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
        }

        private void GridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Name == colexpPrdId.Name)
                e.DisplayText = this.clsTbProduct.GetPrdNameById(Convert.ToInt32(e.Value));
            else if (e.Column.FieldName == colexpPrdMsurId.FieldName)
                e.DisplayText = this.clsTbPrdMsur.GetPrdPriceMsurNameById(Convert.ToInt32(e.Value));
            else if (e.Column.Name == colexpPrdNo.Name)
                e.DisplayText = this.clsTbProduct.GetPrdNoById(Convert.ToInt32(e.Value));
        }

        private void GridView_MasterRowEmpty(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs e)
        {
            e.IsEmpty = false;
        }

        private void GridView_MasterRowGetRelationCount(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void GridView_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Level1";
        }

        private void GridView_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            e.ChildList = this.clsTbPrdExpirateQuan.GetPrdExpirateQuanList.Where(x => x.expMainId==Convert.ToInt32(gridView.GetFocusedRowCellValue(colexpMainId))).ToList();
        }


        private async Task InitObjectsAsync()
        {
            IList<Task> taskList = new List<Task>();
            taskList.Add(Task.Run(() => this.clsTbProduct = new ClsTblProduct()));
            taskList.Add(Task.Run(() => this.clsTbPrdMsur = new ClsTblPrdPriceMeasurment()));
            taskList.Add(Task.Run(() => this.clsTbPrdExpirateQuan = new ClsTblPrdExpirateQuan()));
            taskList.Add(Task.Run(() => this.clsTblStore = new ClsTblStore()));
            await Task.WhenAll(taskList);
        }

        private async Task InitDataAsync()
        {
            flyDialog.WaitForm(this, 1);
            await Task.Run(() => InitObjectsAsync());

            tblPrdexpirateQuanMainBindingSource.DataSource = this.clsTbPrdExpirateQuan.GetPrdExpirateQuanMainList;
            bsiRecordsCount.Caption = (!MySetting.GetPrivateSetting.LangEng ? "العدد : " : "RECORDS : ") + tblPrdExpirateQuanBindingSource.Count;

            flyDialog.WaitForm(this, 0);
        }

        private async void GridView_DoubleClick(object sender, EventArgs e)
        {
            if(bbiEdit.Visibility==BarItemVisibility.Always)
            await UpdateButtonAsync();
        }

        private void GridView_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == colexpMainStrid.FieldName)
                e.DisplayText = this.clsTblStore.GetStoreNameById(Convert.ToInt16(e.Value));
        }

        private async void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            using var form = new formAddPrdExpirateQuan(this, this.clsTbPrdExpirateQuan, this.clsTbProduct, this.clsTbPrdMsur,null, this.clsTblStore);
            flyDialog.WaitForm(this, 0);

            if (form.ShowDialog() == DialogResult.OK) await RefresDialogListAsync();
        }

        private async Task UpdateButtonAsync()
        {
            flyDialog.WaitForm(this, 1);
        
            using var form = new formAddPrdExpirateQuan(this, this.clsTbPrdExpirateQuan, this.clsTbProduct, this.clsTbPrdMsur,
                tbPrdExpirateQuanMain: gridView.GetFocusedRow() as tblPrdexpirateQuanMain,this.clsTblStore);
            flyDialog.WaitForm(this, 0);

            if (form.ShowDialog() == DialogResult.OK) await RefresDialogListAsync();
        }

        private async void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblPrdexpirateQuanMainBindingSource)) return;
            await UpdateButtonAsync();
        }

        private async void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblPrdexpirateQuanMainBindingSource)) return;
            await DeleteRowAsync();
        }

        private async void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            await InitDataAsync();
        }
       
        private void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblPrdexpirateQuanMainBindingSource)) return;
            PrintInvoice();
        }
        private void PrintInvoice()
        {
            flyDialog.WaitForm(this, 1);
            var frm = new ReportForm(ReportType.PrdExpirate, tblObject: tblPrdexpirateQuanMainBindingSource.Current as tblPrdexpirateQuanMain, tblObjectList:
              this.clsTbPrdExpirateQuan.GetPrdExpirateQuanListByMainId(Convert.ToInt32(gridView.GetFocusedRowCellValue(colexpMainId))));
            frm.Show();
            flyDialog.WaitForm(this, 0,frm);

        }
        private async Task DeleteRowAsync()
        {
            var tbPrdExpirateQuanMain = gridView.GetFocusedRow() as tblPrdexpirateQuanMain;
            if (tbPrdExpirateQuanMain == null) return;

            string mssg = $"حذف قائمة الاصناف التالفة المحددة من المخزن: {GetStoreName(tbPrdExpirateQuanMain.expMainStrid)}";
            if (ClsXtraMssgBox.ShowWarningYesNo($"هل أنت متاكد من {mssg}؟") != DialogResult.Yes) return;

            flyDialog.WaitForm(this, 1);
            await InitDeleteObjescts();
            var pro=this.clsTbPrdExpirateQuan.GetPrdExpirateQuanList.Where(x => x.expMainId == tbPrdExpirateQuanMain.expMainId).ToList();
            foreach (var item in pro)
                if (!this.clsTbPrdExpirateQuan.Remove(item) || !this.clsTbAsset.DeleteAssetByEntIdNdStatus(item.expId, (byte)AssetType.PrdExpirate)) return;
            if (!this.clsTbPrdExpirateQuan.RemoveMain(tbPrdExpirateQuanMain)) return;
            flyDialog.WaitForm(this, 0);

            flyDialog.ShowDialogUCCustomdMsg(this, $"تم {mssg} بنجاح!");
            await InitDataAsync();
        }

        //private IEnumerable<ClsProductQuantList> GetPrdQuanList(tblPrdExpirateQuan tbPrdExpirateQuan)
        //{
        //    return new List<ClsProductQuantList>() { new ClsProductQuantList()
        //    {
        //        prdId = tbPrdExpirateQuan.expPrdId,
        //        prdPriceMsurId = tbPrdExpirateQuan.expPrdMsurId,
        //        prdPrice = tbPrdExpirateQuan.expPrdPrice,
        //        prdQuantity = tbPrdExpirateQuan.expQuan,
        //        prdStrId = MySetting.DefaultSetting.defaultStrId
        //    }};
        //}
       
        private async Task InitDeleteObjescts()
        {
            IList<Task> taskList = new List<Task>();
            ClsTblPrdPriceQuan clsTbPrdPrQuan = null;

            taskList.Add(Task.Run(() => this.clsTbAsset = new ClsTblAsset()));
            taskList.Add(Task.Run(() => clsTbPrdPrQuan = new ClsTblPrdPriceQuan()));

            await Task.WhenAll(taskList);
        }

        private string GetStoreName(short exprStoreId)
        {
            return this.clsTblStore.GetStoreNameById(exprStoreId);
        }

        private async Task RefresDialogListAsync()
        {
            flyDialog.ShowDialogUC(this, this.flyDialogMssg, this.isNew);
            await InitDataAsync();
        }

        internal void SetRefreshDialogList(string mssg, bool isNew)
        {
            this.isNew = isNew;
            this.flyDialogMssg = mssg;
        }

        private void UCprdExpirateQuan_Load(object sender, EventArgs e)
        {

        }
    }
}
