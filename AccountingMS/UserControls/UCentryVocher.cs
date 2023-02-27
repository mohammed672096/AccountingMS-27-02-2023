using AccountingMS.Classes;
using DevExpress.Data.Async.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class UCentryVocher : XtraUserControl
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblBox clsTbBox;
        ClsTblBank ClsTblBank;
        ClsTblAccount clsTblAccount = new ClsTblAccount();
        ClsTblEntryMain clsTbEntMain;
        ClsTblEntrySub clsTbEntSub;
        ClsTblBranch clsTblBranch;
        public UCentryVocher()
        {
            InitializeComponent();
            GetResources();
            InitData();

            new ClsUserControlValidation(this, UserControls.EntryVoucer);

            gridView.DoubleClick += GridView_DoubleClick;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
            gridView.FocusedRowChanged += GridView_FocusedRowChanged;
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
            e.ChildList =this.clsTbEntSub.GetEntrySubDataByEntNoNdEntBoxNoWhereEntMainIs2(
                Convert.ToInt32(gridView.GetFocusedRowCellValue(colentNo)), Convert.ToInt32(gridView.GetFocusedRowCellValue(colentBoxNo))).ToList();

        }
        private void GridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
                bbiDelete.PerformClick();
        }

        public async void InitData()
        {
            IList<Task> taskList = new List<Task>();
            taskList.Add(Task.Run(() => this.clsTbEntMain = new ClsTblEntryMain(EntryType.EntryVoucher)));
            taskList.Add(Task.Run(() => this.clsTbEntSub = new ClsTblEntrySub(EntryType.EntryVoucher)));
            taskList.Add(Task.Run(() => clsTbBox = new ClsTblBox()));
            taskList.Add(Task.Run(() => this.ClsTblBank = new ClsTblBank()));
            taskList.Add(Task.Run(() => this.clsTblBranch = new ClsTblBranch()));
            await Task.WhenAll(taskList);
            tblEntryMainBindingSource.DataSource = this.clsTbEntMain.GetEntMainList();
            bsiRecordsCount.Caption = _resource.GetString("count") + tblEntryMainBindingSource.Count;
            SetTblEntrySubBiningSourceData();
            tblEntryMain gr = new tblEntryMain();
            this.clsTblBranch.InitRepositoryItemBranchLookupEdit(gridControl, nameof(gr.entBrnId));
            gridView.Columns.ForEach(item => item.AppearanceHeader.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question);
            gridView1.Columns.ForEach(item => item.AppearanceHeader.BackColor = Color.LightBlue);
        }

        private void SetTblEntrySubBiningSourceData()
        {
            tblEntrySubBindingSource.DataSource = null;
            if (gridView.GetFocusedRow() as tblEntryMain == null) return;

            tblEntrySubBindingSource.DataSource = this.clsTbEntSub.GetEntrySubDataByEntNoNdEntBoxNoWhereEntMainIs2(
                Convert.ToInt32(gridView.GetFocusedRowCellValue(colentNo)), Convert.ToInt32(gridView.GetFocusedRowCellValue(colentBoxNo)));
        }

        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "entBoxNo")
                e.DisplayText = clsTblAccount.GetAccountNameByNo(Convert.ToInt32(e.Value)); //this.clsTbBox.GetBoxNameByNo(Convert.ToInt32(e.Value));
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            UpdateButton();
        }

        private void GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SetTblEntrySubBiningSourceData();
        }
        Form form;
        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            form = new formAddEntryVocher(null, null, this, this.clsTbEntMain);
            form.Show();
            flyDialog.WaitForm(this, 0, form);
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblEntryMainBindingSource)) return;
            UpdateButton();
        }

        private void UpdateButton()
        {
            flyDialog.WaitForm(this, 1);
            tblEntryMain tbEntMain = tblEntryMainBindingSource.Current as tblEntryMain;
            form = new formAddEntryVocher(tbEntMain, this.clsTbEntSub.GetEntrySubDataByEntNoNdEntBoxNoWhereEntMainIs2(tbEntMain.entNo,
                Convert.ToInt32(tbEntMain.entBoxNo)), this, this.clsTbEntMain, this.clsTbEntSub);
            form.Show();
            flyDialog.WaitForm(this, 0, form);
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblEntryMainBindingSource)) return;
            DeleteRecord();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            InitData();
        }

        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblEntryMainBindingSource)) return;

            PrintInvoice();
        }
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView.OptionsSelection.MultiSelect = (!gridView.IsMultiSelect) ? true : false;
        }

        private async void bbiPhased_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblEntryMainBindingSource)) return;
            await PhaseDataAsync();
        }
        private async Task PhaseDataAsync()
        {
            if (XtraMessageBox.Show(_resource.GetString("phaseMssg"), "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            flyDialog.WaitForm(this, 1);
            ClsStopWatch stopWatch = new ClsStopWatch();
            ICollection<tblEntryMain> tbEntMianList = new Collection<tblEntryMain>();
            for (int i = 0; i < gridView.SelectedRowsCount; i++)
                tbEntMianList.Add(gridView.GetRow(gridView.GetSelectedRows()[i]) as tblEntryMain);
            stopWatch.Stop($"\n\n\n==========ElappsedTimeInitAllRows = ");
            if (tbEntMianList.Count() == 0)
            {
                flyDialog.WaitForm(this, 0);
                return;
            }
            ClsEntryTarhel clsTarhel = new ClsEntryTarhel(this.clsTbEntSub);
            bool isSaved = await Task.Run(() => clsTarhel.EntryTarhel(tbEntMianList, 5, 3));
            flyDialog.WaitForm(this, 0);
            if (isSaved)
            {
                flyDialog.ShowDialogUCCustomdMsg(this, _resource.GetString("phaseSuccessMssg"));
                InitData();
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
                    if (DialogResult.Yes == ClsXtraMssgBox.ShowWarningYesNo("لم يتم ترحيل بعض السندات !!! \n هل تريد عرض الفواتير غير المرحله لمعرفة لماذا لم يتم ترحيلها؟"))
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

        private void DeleteRecord()
        {
            int entNo = Convert.ToInt32(gridView.GetFocusedRowCellValue(colentNo)), boxNo = Convert.ToInt32(gridView.GetFocusedRowCellValue(colentBoxNo));

            if (XtraMessageBox.Show(string.Format(_resource.GetString("delVchrMssg"), entNo),
                "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            if (this.clsTbEntMain.Delete(tblEntryMainBindingSource.Current as tblEntryMain) && this.clsTbEntSub.DeleteRecordsByEntNoNdBoxNo(entNo, boxNo))
            {
                flyDialog.ShowDialogUCCustomdMsg(this, string.Format(_resource.GetString("delVchrSuccessMssg"), entNo));
                InitData();
            }
        }

        private void PrintInvoice()
        {
            flyDialog.WaitForm(this, 1);
            ReportForm reportForm;
            var enSub = new EntrySubDataCustom();
            if (MySetting.DefaultSetting.teReportVocherCustom)
            {
                if (enSub.ValidateReportEntryVocherCustomFile())
                {
                    tblEntryMain entryMain = tblEntryMainBindingSource.Current as tblEntryMain;
                    var box = clsTbBox.GetBoxNameByAccNo(entryMain.entBoxNo.GetValueOrDefault());
                    if (box == string.Empty || box == null)
                        box = ClsTblBank.GetBankNameByAccNo(entryMain.entBoxNo.GetValueOrDefault());
                    else
                        box = "نقدي";
                    ReportEntryCustom reportEntryCustom = new ReportEntryCustom(new EntryDataCustom(entryMain, box),
                    enSub.GetEntrySubToList((tblEntrySubBindingSource.List as IList<tblEntrySub>).ToList()), ReportCustomType.EntryVoucher);
                    reportForm = new ReportForm(reportEntryCustom, "سند صرف");
                    reportForm.Show();
                    flyDialog.WaitForm(this, 0, reportForm);
                }
            }
            else
            {
                ClsRprtEntryData entMain = new ClsRprtEntryData();
                ArrayList listMain = new ArrayList();
                ArrayList listSub = new ArrayList();

                entMain.entNo = Convert.ToInt32(gridView.GetFocusedRowCellValue(colentNo));
                entMain.entRefNo = Convert.ToInt32(gridView.GetFocusedRowCellValue(colentRefNo));
                entMain.boxName = Convert.ToString(gridView.GetFocusedRowCellDisplayText(colentBoxNo));
                entMain.entDesc = Convert.ToString(gridView.GetFocusedRowCellValue(colentDesc));
                entMain.entAmount = Convert.ToDouble(gridView.GetFocusedRowCellValue(colentAmount));
                entMain.entDate = (DateTime)gridView.GetFocusedRowCellValue(colentDate);
                entMain.entType = _resource.GetString("paymentVocher");
                listMain.Add(entMain);

                //for (short i = 0; i < gridView1.DataRowCount; i++)
                //{
                //    ClsEntryList entSub = new ClsEntryList();

                //    entSub.accNo = Convert.ToInt64(gridView1.GetRowCellValue(i, colentAccNo));
                //    entSub.accName = Convert.ToString(gridView1.GetRowCellValue(i, colentAccName));
                //    entSub.curreny = Convert.ToByte(gridView1.GetRowCellValue(i, colentCurrency));
                //    entSub.desc = Convert.ToString(gridView1.GetRowCellValue(i, colentDesc1));
                //    entSub.debit = Convert.ToDouble(gridView1.GetRowCellValue(i, colentDebit));
                //    entSub.curreny = Convert.ToByte(gridView1.GetRowCellValue(i, colentCurrency));
                //    if (entSub.curreny != 1)
                //        entSub.debit = Convert.ToDouble(gridView1.GetRowCellValue(i, colentDebitFrgn));
                //    listSub.Add(entSub);
                //}
                var g = this.clsTbEntSub.GetEntrySubDataByEntNoNdEntBoxNoWhereEntMainIs2(
                Convert.ToInt32(gridView.GetFocusedRowCellValue(colentNo)), Convert.ToInt32(gridView.GetFocusedRowCellValue(colentBoxNo))).ToList();
                g.ForEach(x =>
                {
                    ClsEntryList entSub = new ClsEntryList();
                    entSub.accNo = Convert.ToInt64(x.entAccNo);
                    entSub.accName = Convert.ToString(x.entAccName);
                    entSub.curreny = Convert.ToByte(x.entCurrency);
                    entSub.desc = Convert.ToString(x.entDesc);
                    entSub.debit = Convert.ToDouble(x.entDebit);
                    entSub.curreny = Convert.ToByte(x.entCurrency);
                    Console.WriteLine($"ucEntryReciptCurrency : {Convert.ToByte(x.entCurrency)}, {entSub.curreny}");
                    if (entSub.curreny != 1)
                        entSub.debit = Convert.ToDouble(x.entDebitFrgn);
                    listSub.Add(entSub);
                });
                reportForm = new ReportForm(ReportType.EntryVoucher, listMain, listSub);
                reportForm.Show();
                listMain.Clear();
                listSub.Clear();
                flyDialog.WaitForm(this, 0, reportForm);
            }

        }

        public void RefreshListDialog(string name, bool isNew)
        {
            if (isNew) flyDialog.ShowDialogUC(this, name);
            else flyDialog.ShowDialogUCUpdMsg(this, name);

            InitData();
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
                _resource = new ComponentResourceManager(typeof(Language.UCentryVocherEn));
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
        }
    }
}

