using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class UCempVchrExtra : DevExpress.XtraEditors.XtraUserControl
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblBox clsTbBox;
        ClsTblEmployee clsTbEmployee;
        ClsTblCurrency clsTbCurrency;
        ClsTblEntryMain clsTbEntryMain;
        ClsTblEntrySub clsTbEntrySub;

        private readonly EntryType entryType;
        private int entId;
        private bool isNew;
        private string flyDialogMssg;

        public UCempVchrExtra(EntryType entryType)
        {
            this.entryType = entryType;
            InitializeComponent();
            InitData();

            gridView.DoubleClick += GridView_DoubleClick;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
        }

        private void InitData()
        {
            InitObjects();
            tblEntryMainBindingSource.DataSource = this.clsTbEntryMain.GetEntMainList();
            bsiRecordsCount.Caption = (!MySetting.GetPrivateSetting.LangEng ? "العدد : " : "RECORDS : ") + tblEntryMainBindingSource.Count;
            tblEntryMain gr = new tblEntryMain();
            new ClsTblBranch().InitRepositoryItemBranchLookupEdit(gridControl, nameof(gr.entBrnId));
        }

        private void InitObjects()
        {
            this.clsTbBox = new ClsTblBox();
            this.clsTbCurrency = new ClsTblCurrency();
            this.clsTbEmployee = new ClsTblEmployee();
            this.clsTbEntryMain = new ClsTblEntryMain(this.entryType);
            this.clsTbEntrySub = new ClsTblEntrySub(this.entryType);
        }

        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == colentBoxNo.FieldName)
                e.DisplayText = this.clsTbBox.GetBoxNameByNo(Convert.ToInt32(e.Value));
            else if (e.Column.FieldName == colentCurrency.FieldName)
                e.DisplayText = this.clsTbCurrency.GetCurrencyNameById(Convert.ToByte(e.Value));
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            EditButton();
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            using var form = new formAddEmpVchrExtra(this, this.entryType, this.clsTbEmployee, this.clsTbEntryMain, this.clsTbEntrySub);
            flyDialog.WaitForm(this, 0);

            if (form.ShowDialog() == DialogResult.OK) RefresDialogList();
        }

        private void EditButton()
        {
            if (!CheckMultiSelect()) return;
            flyDialog.WaitForm(this, 1);
            using var form = new formAddEmpVchrExtra(this, this.entryType, this.clsTbEmployee, this.clsTbEntryMain, this.clsTbEntrySub, Convert.ToInt32(gridView.GetFocusedRowCellValue(colid)));
            flyDialog.WaitForm(this, 0);

            if (form.ShowDialog() == DialogResult.OK) RefresDialogList();
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblEntryMainBindingSource)) return;
            EditButton();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblEntryMainBindingSource)) return;
            if (!CheckMultiSelect()) return;
            DeleteRecord();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            InitData();
        }

        private void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblEntryMainBindingSource)) return;
            if (!CheckMultiSelect()) return;
            PrintInvoice();
        }

        private void bbiShowPhase_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView.OptionsSelection.MultiSelect = (!gridView.IsMultiSelect) ? true : false;
        }

        private void bbiPhase_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblEntryMainBindingSource)) return;
            PhaseData();
        }

        private void PhaseData()
        {
            if (ClsXtraMssgBox.ShowWarningYesNo("هل أنت متاكد من ترحيل السندات؟") != DialogResult.Yes) return;

            var tbEntMainList = new List<tblEntryMain>();
            for (short i = 0; i < gridView.SelectedRowsCount; i++)
                tbEntMainList.Add(gridView.GetRow(gridView.GetSelectedRows()[i]) as tblEntryMain);

            byte entStatus = (this.entryType == EntryType.EmpVoucherTip) ? (byte)10 : (byte)12;
            byte assStatus = (this.entryType == EntryType.EmpVoucherTip) ? (byte)11 : (byte)12;

            if (!new ClsEntryTarhel(this.clsTbEntrySub).EntryTarhel(tbEntMainList, entStatus, assStatus)) return;
            flyDialog.ShowDialogUCCustomdMsg(this, "تم ترحيل السندات بنجاح");

            InitData();
            gridView.OptionsSelection.MultiSelect = false;
        }

        private void DeleteRecord()
        {
            var tbEntMain = tblEntryMainBindingSource.Current as tblEntryMain;
            if (ClsXtraMssgBox.ShowWarningYesNo($"هل أنت متاكد من حذف السند رقم: {tbEntMain.entNo}؟") != DialogResult.Yes) return;

            flyDialog.WaitForm(this, 1);
            if (!this.clsTbEntryMain.Delete(tbEntMain)) return;
            if (!this.clsTbEntrySub.DeleteRecordsByEntNoNdBoxNo(tbEntMain.entNo, Convert.ToInt32(tbEntMain.entBoxNo))) return;

            tblEntryMainBindingSource.RemoveCurrent();
            flyDialog.WaitForm(this, 0);
            flyDialog.ShowDialogUCCustomdMsg(this, $"تم حذف السند رقم: {tbEntMain.entNo} بنجاح!");
        }

        private void PrintInvoice()
        {
            var tbEntMain = tblEntryMainBindingSource.Current as tblEntryMain;
            if (tbEntMain == null) return;
            if (ClsXtraMssgBox.ShowQuesPrint($"هل تريد طباعة السند رقم: {tbEntMain.entNo}؟") != DialogResult.Yes) return;

               new ReportForm(ReportType.EmpVchrExtraInv, tbEntMain: tbEntMain, tblObject:
                this.clsTbEntrySub.GetEntrySubDataByEntNoNdEntBoxNoWhereEntMainIs2(tbEntMain.entNo, Convert.ToInt32(tbEntMain.entBoxNo))).Show();
        }

        private bool CheckMultiSelect()
        {
            if (!gridView.IsMultiSelect) return true;

            ClsXtraMssgBox.ShowError("عذرا لا يمكن تحديد أكثر من سند!");
            gridView.OptionsSelection.MultiSelect = false;
            return false;
        }

        private void RefresDialogList()
        {
            InitData();
            gridView.FocusedRowHandle = gridView.LocateByValue(colid.FieldName, this.entId);
            flyDialog.ShowDialogUC(this, this.flyDialogMssg, this.isNew);
            PrintInvoice();
        }

        internal void SetRefreshDialogList(string mssg, int entId, bool isNew)
        {
            this.entId = entId;
            this.isNew = isNew;
            this.flyDialogMssg = mssg;
        }
    }
}
