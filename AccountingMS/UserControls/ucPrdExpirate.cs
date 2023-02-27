using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class UCprdExpirate : DevExpress.XtraEditors.XtraUserControl
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblProduct clsTbProduct;
        ClsTblPrdPriceMeasurment clsTbPrdMsur;
        ClsTblPrdExpirate clsTbPrdExpirate;
        ClsTblPrdPriceQuan clsTbPrdPrQuan;

        private bool isNew;
        private string flyDialogMssg;

        private async void UCprdExpiration_Load(object sender, EventArgs e)
        {
            await InitDataAsync();
        }

        public UCprdExpirate()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += UCprdExpiration_Load;
            gridView.DoubleClick += GridView_DoubleClick;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
        }

        private async Task InitObjectsAsync()
        {
            IList<Task> taskList = new List<Task>();
            taskList.Add(Task.Run(() => this.clsTbProduct = new ClsTblProduct()));
            taskList.Add(Task.Run(() => this.clsTbPrdMsur = new ClsTblPrdPriceMeasurment()));
            taskList.Add(Task.Run(() => this.clsTbPrdExpirate = new ClsTblPrdExpirate()));
            taskList.Add(Task.Run(() => this.clsTbPrdPrQuan = new ClsTblPrdPriceQuan()));
            await Task.WhenAll(taskList);
        }

        private async Task InitDataAsync()
        {
            await InitObjectsAsync();
            tblPrdExpirateBindingSource.DataSource = this.clsTbPrdExpirate.GetPrdExpirateList;
            bsiRecordsCount.Caption = (!MySetting.GetPrivateSetting.LangEng ? "العدد : " : "RECORDS : ") + tblPrdExpirateBindingSource.Count;
        }

        private async void GridView_DoubleClick(object sender, EventArgs e)
        {
            await UpdateButtonAsync();
        }

        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == colexpPrdId.FieldName)
                e.DisplayText = this.clsTbProduct.GetPrdNameById(Convert.ToInt32(e.Value));
            else if (e.Column.FieldName == colexpPrdMsurId.FieldName)
                e.DisplayText = this.clsTbPrdMsur.GetPrdPriceMsurNameById(Convert.ToInt32(e.Value));
            else if (e.Column.FieldName == colexpPrdPrcQuanId.FieldName)
            {
                var tbPrdPrQuan = this.clsTbPrdPrQuan.GetPrdPriceQuantObjById(Convert.ToInt32(e.Value));
                if (tbPrdPrQuan == null) return;
                Console.WriteLine($"gridView.GetRowCellValue(e.ListSourceRowIndex, colexpPrdMsurStatus): {gridView.GetRowCellValue(e.ListSourceRowIndex, colexpPrdMsurStatus)}");
                e.DisplayText = (Convert.ToByte(gridView.GetRowCellValue(e.ListSourceRowIndex, colexpPrdMsurStatus))) switch
                {
                    1 => tbPrdPrQuan.prQuantity1.ToString(),
                    2 => tbPrdPrQuan.prQuantity2.ToString(),
                    3 => tbPrdPrQuan.prQuantity3.ToString(),
                    _ => null
                };
            }
        }

        private async void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            using var form = new formAddPrdExpirate(this, this.clsTbPrdExpirate, this.clsTbProduct, this.clsTbPrdMsur);
            flyDialog.WaitForm(this, 0);

            if (form.ShowDialog() == DialogResult.OK) await RefresDialogListAsync();
        }

        private async Task UpdateButtonAsync()
        {
            if (!ClsBindingSource.Validate(tblPrdExpirateBindingSource)) return;

            flyDialog.WaitForm(this, 1);
            using var form = new formAddPrdExpirateObj(this, Convert.ToInt32(gridView.GetFocusedRowCellValue(colexpId)),
                this.clsTbPrdExpirate, this.clsTbProduct, this.clsTbPrdMsur);
            flyDialog.WaitForm(this, 0);

            if (form.ShowDialog() == DialogResult.OK) await RefresDialogListAsync();
        }

        private async void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            await UpdateButtonAsync();
        }

        private async void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblPrdExpirateBindingSource)) return;
            await DeleteRowAsync();
        }

        private async void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            await InitDataAsync();
            flyDialog.WaitForm(this, 0);
        }

        private void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        private async Task DeleteRowAsync()
        {
            var tbPrdExpirate = gridView.GetFocusedRow() as tblPrdExpirate;
            if (tbPrdExpirate == null) return;

            string mssg = $"حذف تاريخ إنتهاء الصنف: {GetPrdName(tbPrdExpirate.expPrdId)}";
            if (ClsXtraMssgBox.ShowWarningYesNo($"هل أنت متاكد من {mssg}؟") != DialogResult.Yes) return;

            flyDialog.WaitForm(this, 1);
            if (!this.clsTbPrdExpirate.Remove(tbPrdExpirate)) return;
            flyDialog.WaitForm(this, 0);

            flyDialog.ShowDialogUCCustomdMsg(this, $"تم {mssg} بنجاح!");
            await InitDataAsync();
        }

        private string GetPrdName(int exprPrdId)
        {
            return this.clsTbProduct.GetPrdNameById(exprPrdId);
        }

        private async Task RefresDialogListAsync()
        {
            flyDialog.ShowDialogUC(this, this.flyDialogMssg, this.isNew);
            flyDialog.WaitForm(this, 1);
            await InitDataAsync();
            flyDialog.WaitForm(this, 0);
        }

        internal void SetRefreshDialogList(string mssg, bool isNew)
        {
            this.isNew = isNew;
            this.flyDialogMssg = mssg;
        }
    }
}
