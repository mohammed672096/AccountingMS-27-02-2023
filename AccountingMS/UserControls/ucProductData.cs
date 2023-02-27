using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AccountingMS
{
    public partial class ucProductData : DevExpress.XtraEditors.XtraUserControl
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblStore clsTbStore;
        ClsTblGroupStr clsTbGroupStr;
        ClsTblProductData clsTbPrdData;

        private readonly string folderPath = @$"{ClsDrive.Path}:\B-Tech\Layout\ucProductDataGridLayout.xml";

        public ucProductData()
        {
            InitializeComponent();
            InitData();
            InitGridLayout();
            new ClsUserControlValidation(this, UserControls.ProductData);

            advBandedGridView1.HideCustomizationForm += AdvBandedGridView1_HideCustomizationForm;
            advBandedGridView1.CustomColumnDisplayText += AdvBandedGridView1_CustomColumnDisplayText;
        }

        private async Task InitObjects()
        {
            IList<Task> taskList = new List<Task>();
            taskList.Add(Task.Run(() => this.clsTbStore = new ClsTblStore()));
            taskList.Add(Task.Run(() => this.clsTbGroupStr = new ClsTblGroupStr()));
            taskList.Add(Task.Run(() => this.clsTbPrdData = new ClsTblProductData()));
            await Task.WhenAll(taskList);
        }

        private async void InitData()
        {
            await InitObjects();
            tblProductDataBindingSource.DataSource = this.clsTbPrdData.GetProductDataList;
            bsiRecordsCount.Caption = ((!MySetting.GetPrivateSetting.LangEng) ? "العدد : " : "RECORDS : ") + tblProductDataBindingSource.Count;
        }

        private void InitGridLayout()
        {
            try
            {
                if (!File.Exists(this.folderPath)) advBandedGridView1.SaveLayoutToXml(this.folderPath);
                else advBandedGridView1.RestoreLayoutFromXml(this.folderPath);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        private void AdvBandedGridView1_HideCustomizationForm(object sender, EventArgs e)
        {
            advBandedGridView1.SaveLayoutToXml(this.folderPath);
        }

        private void AdvBandedGridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            var gr = advBandedGridView1.GetFocusedRow();

            if (e.Column == colprdStrNo)
                e.DisplayText = this.clsTbStore.GetStoreNameByNo(Convert.ToInt32(e.Value));
            else if (e.Column == colprdGrpNo)
                e.DisplayText = this.clsTbGroupStr.GetGroupNameById(Convert.ToInt32(e.Value));
        }

        private void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InitData();
        }

        private void bbiPrintPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            var frm = new ReportForm(ReportType.ProductsData);
            frm.Show();
            flyDialog.WaitForm(this, 0, frm);
        }

        private void advBandedGridView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == System.Windows.Forms.Keys.I)
                new formAddProductTemp().ShowDialog();
        }
    }
}
