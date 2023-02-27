using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formAddPrdExpirate : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ClsTblPrdExpirate clsTbPrdExpirate;
        ClsTblSupplyMain clsTbSupplyMain;
        ClsTblSupplySub clsTbSupplySub;
        ClsTblProduct clsTbProduct;
        ClsTblPrdPriceMeasurment clsTbPrdMsur;
        ClsTblPrdPriceQuan clsTbPrdPrcQuan;

        private readonly UCprdExpirate ucPrdExpirate;

        private async void FormAddPrdExpirate_Load(object sender, EventArgs e)
        {
            ClsStopWatch stopWatch = new ClsStopWatch();
            await InitDataAsync();
            stopWatch.Stop();
        }

        public formAddPrdExpirate(UCprdExpirate ucPrdExpiration, ClsTblPrdExpirate clsTbPrdExpirate, ClsTblProduct clsTbProduct, ClsTblPrdPriceMeasurment clsTbPrdMsur)
        {
            InitializeComponent();
            InitEvents();

            this.ucPrdExpirate = ucPrdExpiration;
            this.clsTbPrdExpirate = clsTbPrdExpirate;
            this.clsTbProduct = clsTbProduct;
            this.clsTbPrdMsur = clsTbPrdMsur;
        }

        private void InitEvents()
        {
            this.Load += FormAddPrdExpirate_Load;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
            textEditSupMainId.EditValueChanged += TextEditSupMainId_EditValueChanged;
        }

        private async Task InitDataAsync()
        {
            ClsStopWatch stopWatch = new ClsStopWatch();
            await InitObjectsAsync();
            tblSupplyMainBindingSource.DataSource = this.clsTbSupplyMain.GetSupplyMainList;
            stopWatch.Stop("InitDataAsync");
        }

        private async Task InitObjectsAsync()
        {
            IList<Task> taskList = new List<Task>();
            taskList.Add(Task.Run(() => this.clsTbSupplyMain = new ClsTblSupplyMain(SupplyType.Purchase, SupplyType.PurchasePhase)));
            taskList.Add(Task.Run(() => this.clsTbSupplySub = new ClsTblSupplySub(SupplyType.Purchase, SupplyType.PurchasePhase)));
            taskList.Add(Task.Run(() => this.clsTbPrdPrcQuan = new ClsTblPrdPriceQuan()));
            await Task.WhenAll(taskList);
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == colexpPrdId.FieldName)
                e.DisplayText = this.clsTbProduct.GetPrdNameById(Convert.ToInt32(e.Value));
            else if (e.Column.FieldName == colexpPrdMsurId.FieldName)
                e.DisplayText = this.clsTbPrdMsur.GetPrdPriceMsurNameById(Convert.ToInt32(e.Value));
        }

        private void TextEditSupMainId_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit editor = sender as SearchLookUpEdit;
            if (editor?.EditValue == null) return;

            var tbSupplyMain = editor.Properties.View.GetFocusedRow() as tblSupplyMain;
            InitPrdExpirateData(tbSupplyMain.id, tbSupplyMain.supNo);
        }

        private void InitPrdExpirateData(int supMainId, int supMainNo)
        {
            IList<tblPrdExpirate> tbPrdExpirateList = new List<tblPrdExpirate>();
            var tbSupplySubList = this.clsTbSupplySub.GetSupplySubListBySupId(supMainId);

            foreach (var tbSupplySub in tbSupplySubList)
                tbPrdExpirateList.Add(new tblPrdExpirate()
                {
                    expSupMainId = supMainId,
                    expSupNo = supMainNo,
                    expSupSubId = tbSupplySub.id,
                    expPrdId = Convert.ToInt32(tbSupplySub.supPrdId),
                    expPrdMsurId = Convert.ToInt32(tbSupplySub.supMsur),
                    expQuan = Convert.ToDouble(tbSupplySub.supQuanMain),
                    expPrdPrcQuanId = this.clsTbPrdPrcQuan.GetPrdPriceQuantIdByPrdIdNdPrice(Convert.ToInt32(tbSupplySub.supPrdId),
                        Convert.ToDouble(tbSupplySub.supPrice)),
                    expPrdDate = Session.CurrentYear.fyDateEnd,
                    expDate = DateTime.Now,
                    expBrnId = Session.CurBranch.brnId,
                    expStatus = 1
                });

            tblPrdExpirateBindingSource.DataSource = tbPrdExpirateList;
        }

        private bool SaveData()
        {
            for (short i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                var tbExpirate = gridView1.GetRow(gridView1.GetSelectedRows()[i]) as tblPrdExpirate;
                if (tbExpirate == null) continue;

                tbExpirate.expPrdMsurStatus = this.clsTbPrdMsur.GetPrdPriceMsurStatus(tbExpirate.expPrdMsurId);
                this.clsTbPrdExpirate.Add(tbExpirate);
            }
            return this.clsTbPrdExpirate.SaveDB;
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ValidateData()) return;
            if (!SaveData()) return;

            string mssg = "تاريخ إنتهاء الأصناف";
            this.ucPrdExpirate.SetRefreshDialogList(mssg, true);

            DialogResult = DialogResult.OK;
        }

        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textEditSupMainId.EditValue = null;
            tblPrdExpirateBindingSource.DataSource = null;
            tblPrdExpirateBindingSource.DataSource = typeof(tblPrdExpirate);
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private bool ValidateData()
        {
            if (!dxValidationProvider1.Validate()) return false;
            if (!ValidateGrid()) return false;
            return true;
        }

        private bool ValidateGrid()
        {
            if (gridView1.SelectedRowsCount > 0) return true;
            ClsXtraMssgBox.ShowError("يرجى تحديد الصفوف في الجدول اولاُ!");
            return false;
        }
    }
}
