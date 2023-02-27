using AccountingMS.Classes;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class UCentry : XtraUserControl
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblEntryMain clsTbEntMain;
        ClsTblEntrySub clsTbEntSub;

        private byte status;

        public UCentry(byte srchStatus)
        {
            this.status = srchStatus;
            InitializeComponent();
            GetResources();
            InitData(srchStatus);
            InitItems(srchStatus);

            new ClsUserControlValidation(this, (srchStatus == 1) ? UserControls.Entries : UserControls.EntryPhased);

            gridView.FocusedRowChanged += GridView_FocusedRowChanged;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
            if (srchStatus == 1) gridView.DoubleClick += GridView_DoubleClick;
            gridControl.KeyDown += GridControl_KeyDown;


            gridView.MasterRowGetRelationCount += GridView_MasterRowGetRelationCount;
            gridView.MasterRowEmpty += GridView_MasterRowEmpty;
            gridView.MasterRowGetChildList += GridView_MasterRowGetChildList;
            gridView.MasterRowGetRelationName += GridView_MasterRowGetRelationName;
        }
        private void GridView_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void GridView_MasterRowEmpty(object sender, MasterRowEmptyEventArgs e)
        {
            e.IsEmpty = false;
        }

        private void GridView_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Level1";
        }

        private void GridView_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            tblEntryMain tbEntMain = tblEntryMainBindingSource.Current as tblEntryMain;
            if (tbEntMain == null) return;
            tblEntrySubBindingSource.DataSource = this.clsTbEntSub.GetEntrySubDataByEntNoBoxNoNdEntStatus(tbEntMain.entNo, (int)tbEntMain?.entBoxNo, tbEntMain.entStatus);
            e.ChildList = tblEntrySubBindingSource;
        }
        private void GridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.F6)
            bbiDelete.PerformClick();
        }

        private void InitData(byte srchStatus)
        {
            switch (srchStatus)
            {
                case 1:
                    this.clsTbEntMain = new ClsTblEntryMain(EntryType.DailyEntry);
                    this.clsTbEntSub = new ClsTblEntrySub(EntryType.DailyEntry);
                    break;
                case 4:
                    this.clsTbEntMain = new ClsTblEntryMain(EntryPhased.Entry);
                    this.clsTbEntSub = new ClsTblEntrySub(EntryPhased.Entry);
                    break;
            }

            tblEntryMainBindingSource.DataSource = this.clsTbEntMain.GetEntMainList();
            bsiRecordsCount.Caption = _resource.GetString("count") + tblEntryMainBindingSource.Count;
            SetTblEntrySubBiningSourceData();
            tblEntryMain gr = new tblEntryMain();
            new ClsTblBranch().InitRepositoryItemBranchLookupEdit(gridControl, nameof(gr.entBrnId));
            gridView.Columns.ForEach(item => item.AppearanceHeader.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question);
            gridView1.Columns.ForEach(item => item.AppearanceHeader.BackColor = Color.LightBlue);
        }

        private void InitItems(byte srchStatus)
        {
            if (srchStatus != 4) return;

            colentStatus.Visible = true;
            ribbonPageGroup1.Visible = false;
            ribbonPageGroup3.Visible = false;
            ribbonPageGroup5.Visible = true;
        }

        private void RefreshData()
        {
            switch (this.status)
            {
                case 1:
                    this.clsTbEntMain.RefreshData();
                    this.clsTbEntSub.RefreshData();
                    break;
                case 4:
                    this.clsTbEntMain.RefreshPhasedData();
                    this.clsTbEntSub.RefreshPhasedData();
                    break;
            }

            tblEntryMainBindingSource.DataSource = this.clsTbEntMain.GetEntMainList();
            bsiRecordsCount.Caption = _resource.GetString("count") + tblEntryMainBindingSource.Count;
            SetTblEntrySubBiningSourceData();
        }

        private void SetTblEntrySubBiningSourceData()
        {
            tblEntrySubBindingSource.DataSource = null;
            tblEntryMain tbEntMain = tblEntryMainBindingSource.Current as tblEntryMain;
            if (tbEntMain == null) return;

            tblEntrySubBindingSource.DataSource = this.clsTbEntSub.GetEntrySubDataByEntNoBoxNoNdEntStatus(tbEntMain.entNo, (int)tbEntMain?.entBoxNo, tbEntMain.entStatus);
        }

        private void GridView_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "entStatus")
                e.DisplayText = ClsEntryStatus.GetString(Convert.ToByte(e.Value));
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            UpdateButton();
        }

        private void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            SetTblEntrySubBiningSourceData();
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            //flyDialog.WaitForm(this, 1);
            new formAddEntry(null, null, this, this.clsTbEntMain).Show();
            //flyDialog.WaitForm(this, 0);
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblEntryMainBindingSource)) return;
            UpdateButton();
        }

        private void UpdateButton()
        {
            //flyDialog.WaitForm(this, 1);
            tblEntryMain tbEntMain = tblEntryMainBindingSource.Current as tblEntryMain;
            new formAddEntry(tbEntMain, this.clsTbEntSub.GetEntrySubDataByEntNo(tbEntMain.entNo), this, this.clsTbEntMain).Show();
            //flyDialog.WaitForm(this, 0);
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            InitData(this.status);
            //RefreshData();
        }
        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblEntryMainBindingSource)) return;
            DeleteRecord();
        }
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView.OptionsSelection.MultiSelect = (!gridView.IsMultiSelect) ? true : false;
        }
        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblEntryMainBindingSource)) return;
            PrintInvoice();
        }
        private async void bbiTarhel_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblEntryMainBindingSource)) return;
            await PhaseDataAsync();
        }
        private async Task PhaseDataAsync()
        {
            if (XtraMessageBox.Show(_resource.GetString("phaseMssg"), "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            flyDialog.WaitForm(this, 1);

            ICollection<tblEntryMain> tbEntMianList = new Collection<tblEntryMain>();
            for (int i = 0; i < gridView.SelectedRowsCount; i++)
                tbEntMianList.Add(gridView.GetRow(gridView.GetSelectedRows()[i]) as tblEntryMain);
            if (tbEntMianList.Count() == 0)
            {
                flyDialog.WaitForm(this, 0);
                return;
            }
            ClsEntryTarhel clsTarhel = new ClsEntryTarhel(this.clsTbEntSub);
            bool isSaved = await Task.Run(() => clsTarhel.EntryTarhel(tbEntMianList, 4, 2));
            flyDialog.WaitForm(this, 0);
            if (isSaved)
            {
                flyDialog.ShowDialogUCCustomdMsg(this, _resource.GetString("phaseSuccessMssg"));
                InitData(this.status);
            }
            tbEntMianList.Clear();
            gridView.OptionsSelection.MultiSelect = false;
            if (clsTarhel.errorListTarhel.Count > 0)
            {
                if (tbEntMianList.Count() == 1 || clsTarhel.errorListTarhel.Count == 1)
                {
                    string mssg = $"عذراً لم يتم ترحيل السند .\n";
                    clsTarhel.errorListTarhel.ForEach(x => mssg += x.Error + "\n\n");
                    XtraMessageBox.Show(mssg);
                }
                else if (tbEntMianList.Count() > 1 && clsTarhel.errorListTarhel.Count > 1)
                {
                    if (DialogResult.Yes == ClsXtraMssgBox.ShowWarningYesNo("لم يتم ترحيل بعض السندات !!! \n هل تريد عرض السندات غير المرحله لمعرفة لماذا لم يتم ترحيلها؟"))
                    {
                        string mssg = $"عذراً لم يتم ترحيل السندات التالية .\n";
                        XtraForm xtraDialogForm = new XtraForm() { Width = this.Width / 2, Height = this.Height / 2, RightToLeft = RightToLeft.Yes, RightToLeftLayout = true };
                        xtraDialogForm.Text = mssg;
                        xtraDialogForm.StartPosition = FormStartPosition.CenterScreen;
                        GridControl gridControl = new GridControl() { Dock = DockStyle.Fill, DataSource = clsTarhel.errorListTarhel };
                        gridControl.Load += GridControl_Load;
                        xtraDialogForm.Controls.Add(gridControl);
                        xtraDialogForm.ShowDialog();
                    }
                }
            }
        }
        private void GridControl_Load(object sender, EventArgs e)
        {
            ((GridView)((GridControl)sender).MainView).OptionsBehavior.Editable = false;
            ((GridView)((GridControl)sender).MainView).Columns[0].Width = 100;
            ((GridView)((GridControl)sender).MainView).Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            ((GridView)((GridControl)sender).MainView).Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;

        }
        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblEntryMainBindingSource)) return;
            tblEntryMain tbEntMain = tblEntryMainBindingSource.Current as tblEntryMain;
            if (XtraMessageBox.Show(string.Format(_resource.GetString("undoPhaseMssg"), tbEntMain.entNo),
                "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            if (new ClsEntryDeleteTarhel().Delete(tbEntMain, this.clsTbEntSub.GetEntrySubDataByEntNoBoxNoNdEntStatus(tbEntMain.entNo, (int)tbEntMain.entBoxNo, tbEntMain.entStatus)))
            {
                flyDialog.ShowDialogUCCustomdMsg(this, string.Format(_resource.GetString("undoPhaseSuccesMssg"), tbEntMain.entNo));
                InitData(this.status);
            }
        }
        private void DeleteRecord()
        {
            int entNo = Convert.ToInt32(gridView.GetFocusedRowCellValue(colentNo));

            if (XtraMessageBox.Show(string.Format(_resource.GetString("delEntMssg"), entNo),
                "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            if (this.clsTbEntMain.Delete(tblEntryMainBindingSource.Current as tblEntryMain) && this.clsTbEntSub.DeleteRecordsByEntNo(entNo))
            {
                flyDialog.ShowDialogUCCustomdMsg(this, string.Format(_resource.GetString("delEntSuccessMssg"), entNo));
                InitData(this.status);
                //RefreshData();
            }
        }
        public void RefreshListDialog(string name, bool isNew)
        {
            if (isNew)
                flyDialog.ShowDialogUC(this, name);
            else
                flyDialog.ShowDialogUCUpdMsg(this, name);

            InitData(this.status);
            //RefreshData();
        }
        ReportForm reportForm;
        private void PrintInvoice()
        {
            flyDialog.WaitForm(this, 1);
            var enSub = new EntrySubDataCustom();
            if (MySetting.DefaultSetting.teReportEntryCustom)
            {
                if (enSub.ValidateReportEntryVocherCustomFile())
                {
                    ReportEntryCustom reportEntryCustom = new ReportEntryCustom(new EntryDataCustom(tblEntryMainBindingSource.Current as tblEntryMain, ""),
               enSub.GetEntrySubToList((tblEntrySubBindingSource.List as IList<tblEntrySub>).ToList()), ReportCustomType.Entry);
                    reportForm = new ReportForm(reportEntryCustom, "قيد يوميه");
                    reportForm.Show();
                }
            }
            else
            {
                ClsRprtEntryData entMain = new ClsRprtEntryData();
                ArrayList listMain = new ArrayList();
                ArrayList listSub = new ArrayList();
                byte status = Convert.ToByte(gridView.GetFocusedRowCellValue(colentStatus));

                entMain.entNo = Convert.ToInt32(gridView.GetFocusedRowCellValue(colentNo));
                entMain.entRefNo = Convert.ToInt32(gridView.GetFocusedRowCellValue(colentRefNo));
                entMain.entDesc = Convert.ToString(gridView.GetFocusedRowCellValue(colentDesc));
                entMain.entAmount = Convert.ToDouble(gridView.GetFocusedRowCellValue(colentAmount));
                entMain.entDate = Convert.ToDateTime(gridView.GetFocusedRowCellValue(colentDate));
                entMain.entReverseConstraint = Convert.ToString(gridView.GetFocusedRowCellValue(colentReverseConstraint));
                entMain.entReverseConstraintDate = Convert.ToDateTime(gridView.GetFocusedRowCellValue(colentReverseConstraintDate));
                entMain.entType = _resource.GetString("dailyVocher");
                if (this.status == 4)
                {
                    if (status == 5)
                        entMain.entType = _resource.GetString("paymentVocher");
                    if (status == 6)
                        entMain.entType = _resource.GetString("receiptVocher");
                }
                var sup = tblEntrySubBindingSource.List as IList<tblEntrySub>;
                entMain.boxName = sup?.FirstOrDefault(x => x.entIsMain != 2)?.entAccName;
                listMain.Add(entMain);
                sup.ToList().ForEach(x =>
                {
                    ClsEntryList entSub = new ClsEntryList();
                    entSub.id = x.id;
                    entSub.accNo = x.entAccNo ?? 0;
                    entSub.accName = x.entAccName;
                    entSub.cusName = x.entCusName;
                    entSub.curreny = Convert.ToByte(x.entCurrency);
                    entSub.desc = x.entDesc;
                    entSub.debit = (status == 6 && x.entIsMain == 2) ? x.entCredit.GetValueOrDefault() :(x.entDebit??0);
                    entSub.credit = x.entCredit.GetValueOrDefault();
                    entSub.debitFrgn = x.entDebitFrgn.GetValueOrDefault();
                    entSub.creditFrgn = x.entCreditFrgn.GetValueOrDefault();
                    entSub.entTaxNumber = x.entTaxNumber;
                    entSub.creditFrgn = x.entCreditFrgn.GetValueOrDefault();
                    entSub.invoNum = Convert.ToString(x.invoNum);
                    if (x.entIsMain == 2)
                        listSub.Add(entSub);
                });
                if (this.status == 1)
                    reportForm = new ReportForm(ReportType.Entry, listMain, listSub);
                // new ReportForm(ReportType.Entry, listMain, listSub).Show();
                else if (this.status == 4)
                {
                    if (status == 4)
                        reportForm = new ReportForm(ReportType.Entry, listMain, listSub);
                    if (status == 5)
                        reportForm = new ReportForm(ReportType.EntryVoucher, listMain, listSub);
                    //  new ReportForm(ReportType.EntryVoucher, listMain, listSub).Show();
                    if (status == 6)
                        reportForm = new ReportForm(ReportType.EntryReceipt, listMain, listSub);

                    // new ReportForm(ReportType.EntryReceipt, listMain, listSub).Show();
                }
                else
                    reportForm = new ReportForm(ReportType.Entry, listMain, listSub);
                reportForm.Show();
                listMain.Clear();
                listSub.Clear();
            }
            flyDialog.WaitForm(this, 0, reportForm);
        }
        public void SetFoucesdRow(int entNo)
        {
            gridView.FocusedRowHandle = gridView.LocateByValue("entNo", entNo);

            if (XtraMessageBox.Show(string.Format(_resource.GetString("printMssg"), entNo), "Message",
                MessageBoxButtons.YesNo) == DialogResult.Yes) PrintInvoice();
        }
        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng)
            {
                _ci = new CultureInfo("ar");
                _resource = new ComponentResourceManager(typeof(Language.EntriesNotificationAr));
            }
            else
            {
                _ci = new CultureInfo("en");
                _resource = new ComponentResourceManager(typeof(Language.UCentryEn));
            }

            if (MySetting.GetPrivateSetting.LangEng) EnglishTranslation();
        }
        private void EnglishTranslation()
        {
            this.RightToLeft = RightToLeft.No;
            gridControl.RightToLeft = RightToLeft.No;

            foreach (var control in ribbonControl.Manager.Items)
            {
                if (control is BarButtonItem)
                {
                    BarButtonItem c = control as BarButtonItem;
                    _resource.ApplyResources(c, c.Name, _ci);
                }
            }
            foreach (GridColumn c in gridView.Columns)
            {
                _resource.ApplyResources(c, c.Name, _ci);
            }
            foreach (GridColumn c in gridView1.Columns)
            {
                _resource.ApplyResources(c, c.Name, _ci);
            }

            _resource.ApplyResources(ribbonPage1, ribbonPage1.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup1, ribbonPageGroup1.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup2, ribbonPageGroup2.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup3, ribbonPageGroup3.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup5, ribbonPageGroup5.Name, _ci);
        }
    }
}

