using DevExpress.XtraBars;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class UCrepresentative : DevExpress.XtraEditors.XtraUserControl
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblRepresentitive clsTbRep;
        ClsTblCurrency clsTbCurrency;

        private bool isNew;
        private string flyMssg;

        public UCrepresentative()
        {
            InitializeComponent();

            this.Load += UcRepresentitive_Load;
            gridView.DoubleClick += GridView_DoubleClick;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
          
    }

        private async void UcRepresentitive_Load(object sender, EventArgs e)
        {
            await InitDataAsync();
        }

        private async Task InitDataAsync()
        {
            flyDialog.WaitForm(this, 1);

            this.clsTbRep = await Task.Run(() => new ClsTblRepresentitive());
            this.clsTbCurrency = await Task.Run(() => new ClsTblCurrency());

            tblRepresentativeBindingSource.DataSource = this.clsTbRep.GetRepList;
            bsiRecordsCount.Caption = string.Format(((!MySetting.GetPrivateSetting.LangEng) ? "العدد : {0:#,#}" : "RECORDS: {0:#,#}"), tblRepresentativeBindingSource.Count);
            tblRepresentative gr = new tblRepresentative();
            new ClsTblBranch().InitRepositoryItemBranchLookupEdit(gridControl, nameof(gr.repBrnId));
            flyDialog.WaitForm(this, 0);
        }

        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == colrepCurrency.FieldName)
                e.DisplayText = this.clsTbCurrency.GetCurrencyNameById(Convert.ToByte(e.Value));
        }

        private async void GridView_DoubleClick(object sender, EventArgs e)
        {
            await UpdateButtonAsync();
        }

        private async void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            //flyDialog.WaitForm(this, 1);
            using var frm = new formAddRepresentative(this, null);
            flyDialog.WaitForm(this, 0);

            if (frm.ShowDialog() == DialogResult.OK) await RefreshListDialogAsync();
        }

        private async Task UpdateButtonAsync()
        {
            if (!ClsBindingSource.Validate(tblRepresentativeBindingSource)) return;
            //flyDialog.WaitForm(this, 1);
            using var frm = new formAddRepresentative(this, tblRepresentativeBindingSource.Current as tblRepresentative);
           // flyDialog.WaitForm(this, 0);

            if (frm.ShowDialog() == DialogResult.OK) await RefreshListDialogAsync();
        }

        private async void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            await UpdateButtonAsync();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblRepresentativeBindingSource)) return;
            DeleteObject();
        }

        private async void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            await InitDataAsync();
        }

        private void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        private void DeleteObject()
        {
            var tbRepresetative = gridView.GetFocusedRow() as tblRepresentative;
            string mssg = $"حذف المندوب: {tbRepresetative.repName}";

            if (ClsXtraMssgBox.ShowWarningYesNo($"هل انت متاكد من {mssg}؟") != DialogResult.Yes) return;
            if (!new ClsTblAccount().DeleteByAccNo(tbRepresetative.repAccNo)) return;
            if (!this.clsTbRep.Delete(tbRepresetative)) return;

            tblRepresentativeBindingSource.RemoveCurrent();
            flyDialog.ShowDialogUCCustomdMsg(this, $"تم {mssg} بنجاح!");
        }

        public void SetRefreshListDialog(bool isNew, string mssg)
        {
            this.isNew = isNew;
            this.flyMssg = mssg;
        }

        private async Task RefreshListDialogAsync()
        {
            this.flyDialog.ShowDialogUC(this, this.flyMssg, this.isNew);
            await InitDataAsync();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            //formAddProudctMandob frm = new formAddProudctMandob();
            //frm.Show();
           // , Convert.ToString(gridView.GetRowCellValue(gridView.FocusedRowHandle, "colrepNo"))
            flyDialog.WaitForm(this, 1);
            using (formAddProudctMandob frm = new formAddProudctMandob(gridView.GetRowCellValue(gridView.FocusedRowHandle, "repName").ToString()))
            {
                flyDialog.WaitForm(this, 0);
                //if (frm.ShowDialog() == DialogResult.OK)
                //{
                //RefreshListDialog();
                //SetFoucesdRow();
                frm.ShowDialog();
                //}
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            using (formAddProudctMandobCpmm frm = new formAddProudctMandobCpmm(gridView.GetRowCellValue(gridView.FocusedRowHandle, "repName").ToString()))
            {
                flyDialog.WaitForm(this, 0);
                frm.ShowDialog();
            }
            
        }
    }
}
