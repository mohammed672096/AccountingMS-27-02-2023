using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class UCemployeesVchr : XtraUserControl
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblCurrency clsTbCurrency = new ClsTblCurrency();
        ClsTblBox clsTbBox = new ClsTblBox();
        ClsTblEntryMain clsTbEntMain;
        ClsTblEntrySub clsTbEntSub;
        EntryType entryType;

        public UCemployeesVchr(EntryType entryType)
        {
            this.entryType = entryType;

            InitializeComponent();
            GetResources();
            InitData();
            InitUserRight();
            InitProperties();
            splitContainerControl1.SplitterPosition = Convert.ToInt32(this.Width * 0.7);

            gridView.DoubleClick += GridView_DoubleClick;
            gridView.FocusedRowChanged += GridView_FocusedRowChanged;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
            gridControl.KeyDown += GridControl_KeyDown;
        }
        private void GridControl_KeyDown(object sender, KeyEventArgs e)
        {
            bbiDelete.PerformClick();
        }

        private void InitData()
        {
            this.clsTbEntMain = new ClsTblEntryMain(this.entryType);
            this.clsTbEntSub = new ClsTblEntrySub(this.entryType);
            tblEntryMainBindingSource.DataSource = this.clsTbEntMain.GetEntMainList();
            bsiRecordsCount.Caption = _resource.GetString("count") + tblEntryMainBindingSource.Count;
            SetTblEntrySubBiningSourceData();
            tblEntryMain gr = new tblEntryMain();
            new ClsTblBranch().InitRepositoryItemBranchLookupEdit(gridControl, nameof(gr.entBrnId));
        }

        private void InitUserRight()
        {
            if (this.entryType == EntryType.EmpVoucher) new ClsUserControlValidation(this, UserControls.EmployeesVoucher);
        }

        private void InitProperties()
        {
            if (this.entryType != EntryType.EmpVoucherPhasedAll) return;

            colentStatus.Group();
            //colentStatus.Visible = true;
            //colentStatus.VisibleIndex = -1;

            ribbonPageGroup1.Visible = false;
            ribbonPageGroup2.Visible = false;
            ribbonPageGroup3.Visible = false;
            ribbonPageGroupPhasedUndo.Visible = true;
        }

        private void SetTblEntrySubBiningSourceData()
        {
            tblEntrySubBindingSource.DataSource = null;
            tblEntryMain tbEntMain = tblEntryMainBindingSource.Current as tblEntryMain;
            if (tbEntMain == null) return;

            tblEntrySubBindingSource.DataSource = this.clsTbEntSub.GetEntrySubDataByEntNoBoxNoNdStatusWhereEntMainIs2(
                tbEntMain.entNo, (byte)tbEntMain.entBoxNo, tbEntMain.entStatus);
        }


        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column == colentBoxNo)
                e.DisplayText = this.clsTbBox.GetBoxNameByNo(Convert.ToInt32(e.Value));
            else if (e.Column == colentCurrency)
                e.DisplayText = this.clsTbCurrency.GetCurrencyNameById(Convert.ToByte(e.Value));
            else if (e.Column == colentStatus && this.entryType == EntryType.EmpVoucherPhasedAll)
                e.DisplayText = ClsEntryStatus.GetString(Convert.ToByte(e.Value));
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column == colentCurrency1)
                e.DisplayText = this.clsTbCurrency.GetCurrencySignById(Convert.ToByte(e.Value));
        }

        private void GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SetTblEntrySubBiningSourceData();
            SetGridView2Properties();
        }

        private void SetGridView2Properties()
        {
            if (this.entryType != EntryType.EmpVoucherPhasedAll) return;
            byte entStatus = Convert.ToByte(gridView.GetFocusedRowCellValue(colentStatus));

            colentCusName.Visible = (entStatus == 8) ? false : true;
            colentDebitFrgn.VisibleIndex = (entStatus == 8) ? 2 : -1;
            colentAccName.Caption = (entStatus == 8) ? "إسم الموظف" : "إلى حساب";
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            UpdateButton();
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            new formAddEmployeeVchr(null, null, this, this.clsTbEntMain).Show();
            flyDialog.WaitForm(this, 0);
        }

        private void UpdateButton()
        {
            flyDialog.WaitForm(this, 1);
            tblEntryMain tbEntMain = (gridView.GetFocusedRow() as tblEntryMain).ShallowCopy();
            new formAddEmployeeVchr(tbEntMain, this.clsTbEntSub.GetEntrySubDataByEntNoNdEntBoxNoWhereEntMainIs2(tbEntMain.entNo,
                Convert.ToInt32(tbEntMain.entBoxNo)), this, this.clsTbEntMain, this.clsTbEntSub).Show();
            flyDialog.WaitForm(this, 0);
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblEntryMainBindingSource)) return;
            UpdateButton();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblEntryMainBindingSource)) return;
            DeleteRecord();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            InitData();
            flyDialog.WaitForm(this, 0);
        }

        private void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblEntryMainBindingSource)) return;
            PrintInvoice();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView.OptionsSelection.MultiSelect = (!gridView.IsMultiSelect) ? true : false;
        }

        private void bbiUndoPhase_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblEntryMainBindingSource)) return;
            UndoPhase();
        }

        private void UndoPhase()
        {
            tblEntryMain tbEntMain = tblEntryMainBindingSource.Current as tblEntryMain;
            string mssg = $"إلغاء ترحيل سند {ClsEntryStatus.GetString(tbEntMain.entStatus)} رقم: {tbEntMain.entNo}";

            if (ClsXtraMssgBox.ShowWarningYesNo($"هل أنت متاكد من {mssg}؟") != DialogResult.Yes) return;
            if (!new ClsEntryDeleteTarhel().Delete(tbEntMain, this.clsTbEntSub.GetEntrySubDataByEntNoBoxNoNdEntStatus(tbEntMain.entNo,
                (int)tbEntMain.entBoxNo, tbEntMain.entStatus))) return;

            flyDialog.ShowDialogUCCustomdMsg(this, $"تم {mssg} بنجاح!");
            InitData();

        }

        private void bbiRefreshPhase_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            InitData();
            flyDialog.WaitForm(this, 0);
        }

        private async void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
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
            if (tbEntMianList.Count == 0)
            {
                flyDialog.WaitForm(this, 0);
                return;
            }
            ClsEntryTarhel clsTarhel = new ClsEntryTarhel(this.clsTbEntSub);
            bool isSaved = await Task.Run(() => clsTarhel.EntryTarhel(tbEntMianList, 8, 9));
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

            if (XtraMessageBox.Show(string.Format(_resource.GetString("delEntMssg"), entNo),
                "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            if (this.clsTbEntMain.Delete(tblEntryMainBindingSource.Current as tblEntryMain) && this.clsTbEntSub.DeleteRecordsByEntNoNdBoxNo(entNo, boxNo))
            {
                flyDialog.ShowDialogUCCustomdMsg(this, string.Format(_resource.GetString("delEntSuccessMssg"), entNo));
                InitData();
            }
        }

        private void PrintInvoice()
        {
            flyDialog.WaitForm(this, 1);
            BindingList<tblEntrySub> tbEntSubList = new BindingList<tblEntrySub>();

            for (short i = 0; i < gridView1.DataRowCount; i++)
                tbEntSubList.Add(gridView1.GetRow(i) as tblEntrySub);

            var frm = new ReportForm(ReportType.EntryEmp, tbEntMain: tblEntryMainBindingSource.Current as tblEntryMain, tbEntSubList: tbEntSubList);
            frm.Show();
            flyDialog.WaitForm(this, 0, frm);
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
                _resource = new ComponentResourceManager(typeof(Language.EmployeesNotificationAr));
            }
            else
            {
                _ci = new CultureInfo("en");
                _resource = new ComponentResourceManager(typeof(Language.UCemployeesVchrEn));
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
                _resource.ApplyResources(c, c.Name, _ci);

            _resource.ApplyResources(ribbonPage1, ribbonPage1.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup1, ribbonPageGroup1.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup2, ribbonPageGroup2.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup3, ribbonPageGroup3.Name, _ci);
        }
    }
}
