using AccountingMS.Classes;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
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
    public partial class UCsales : XtraUserControl
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblPrdPriceMeasurment clsTbPrdMsur;
        ClsTblCurrency curr = new ClsTblCurrency();
        ClsTblSupplyMain clsTbSupplyMain;
        ClsTblSupplySub clsTbSupplySub;
        ClsTblPrdManufacture clsTbPrdMan;
        tblSupplyMain tbSupplyMainPrint;
        IEnumerable<tblSupplyMain> tbSupplyMainList;
        IEnumerable<tblSupplySub> tbSupplySubListPrint;
        IDictionary<int, double> dicTotalFinalList;

        private SupplyType supplyType;

        private string flyDialogMssg;
        private int supNo;
        private bool isNew;

        private async void UCsales_Load(object sender, EventArgs e)
        {
            GetResources();
            //this.dicTotalFinalList = new Dictionary<int, double>();

            flyDialog.WaitForm(this, 1);
            await InitDataAsync();
            flyDialog.WaitForm(this, 0);

            SetUserControlLayout();
        }

        public UCsales(SupplyType supplyType)
        {
            this.supplyType = supplyType;
            InitializeComponent();

            gridView.OptionsDetail.DetailMode = DetailMode.Embedded;
            gridView.MasterRowGetRelationCount += GridView_MasterRowGetRelationCount;
            gridView.MasterRowEmpty += GridView_MasterRowEmpty;
            gridView.MasterRowGetChildList += GridView_MasterRowGetChildList;
            gridView.MasterRowGetRelationName += GridView_MasterRowGetRelationName;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
            gridView.CustomUnboundColumnData += GridView_CustomUnboundColumnData;
            if (supplyType == SupplyType.Sales) gridView.DoubleClick += GridView_DoubleClick;
        }

        private async Task InitObjectsAsync()
        {
            IList<Task> taskList = new List<Task>();

            taskList.Add(Task.Run(() => this.clsTbSupplyMain = new ClsTblSupplyMain(this.supplyType)));
            taskList.Add(Task.Run(() => this.clsTbSupplySub = new ClsTblSupplySub(this.supplyType)));
            taskList.Add(Task.Run(() => this.clsTbPrdMsur = new ClsTblPrdPriceMeasurment()));
            taskList.Add(Task.Run(() => this.clsTbPrdMan = new ClsTblPrdManufacture()));

            await Task.WhenAll(taskList);
            this.tbSupplyMainList = this.clsTbSupplyMain.GetSupplyMainList.OrderByDescending(x => x.supDate).ToList();
            tblSupplyMain g = new tblSupplyMain();
            new ClsTblBranch().InitRepositoryItemBranchLookupEdit(gridControl, nameof(g.supBrnId));
            if (Session.CurrentUser.id == 1)
                colsupNo.Caption = "رقم الفاتورة الفرعي";
            else
                colMainNo.Visible = false;
        }

        private async Task InitDataAsync()
        {
            await InitObjectsAsync();
            await InitTotalFinalList();

            //tblSupplyMainBindingSource.DataSource = this.clsTbSupplyMain.GetSupplyMainList.OrderByDescending(x => x.supDate).ToList();

            tblSupplyMainBindingSource.DataSource = this.tbSupplyMainList;
            bsiRecordsCount.Caption = _resource.GetString("count") + tblSupplyMainBindingSource.Count;
        }

        private async Task InitTotalFinalList()
        {
            if (this.tbSupplyMainList == null) return;
            this.dicTotalFinalList = new Dictionary<int, double>();
            int loopCount = 0;

            foreach (var tbSupplyMain in this.tbSupplyMainList)
            {
                await Task.Run(() => this.dicTotalFinalList.Add(loopCount, (tbSupplyMain.supTotal +
                    Convert.ToDouble(tbSupplyMain.supTaxPrice)) - Convert.ToDouble(tbSupplyMain.supDscntAmount)));

                loopCount++;
            }
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
            e.ChildList = this.clsTbSupplySub.GetSupplySubIListBySupId(GetFoucsedSupplyMainId);
        }

        private int GetFoucsedSupplyMainId => Convert.ToInt32(gridView.GetFocusedRowCellValue(colsupMainId));

        private async void GridView_DoubleClick(object sender, EventArgs e)
        {
            await UpdateButtonAsync();
        }

        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "supStatus")
                e.DisplayText = ClsSupplyStatus.GetString(Convert.ToByte(e.Value));
            else if (e.Column.FieldName == "supCurrency")
                e.DisplayText = curr.GetCurrencyNameById(Convert.ToByte(e.Value));
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            this.clsTbPrdMsur = null;
            if (e.Column.FieldName == "supMsur")
                e.DisplayText = this.clsTbPrdMsur?.GetPrdPriceMsurNameById(Convert.ToInt32(e.Value));
        }

        private void GridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (this.dicTotalFinalList == null) return;
            GridView view = sender as GridView;

            if (view == null) return;
            if (e.Column.FieldName != colsupTotalFinal.FieldName) return;
            if (!e.IsGetData) return;
            if (this.dicTotalFinalList.ContainsKey(e.ListSourceRowIndex)) e.Value = this.dicTotalFinalList[e.ListSourceRowIndex];
        }

        private async void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            //flyDialog.WaitForm(this, 1);

            //using var frm = new formSupplyMain(this, this.supplyType);
            //frm.ResetAppearance();
            //flyDialog.WaitForm(this, 0);

            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    await RefreshListDialogAsync();
            //    SetFoucesdRow(this.supNo);
            //}
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            //flyDialog.WaitForm(this, 1);
            //using (formAddSupplyVoucher frm = new formAddSupplyVoucher(null, null, this, this.supplyType))
            //{
            //    flyDialog.WaitForm(this, 0);
            //    if (frm.ShowDialog() == DialogResult.OK) await RefreshListDialogAsync();
            //}
        }

        private  void BbiDirectSalesRtrn_ItemClick(object sender, ItemClickEventArgs e)
        {
            //flyDialog.WaitForm(this, 1);
            //using (formAddSupplyVoucher frm = new formAddSupplyVoucher(null, null, this, SupplyType.DirectSalesRtrn))
            //{
            //    flyDialog.WaitForm(this, 0);
            //    if (frm.ShowDialog() == DialogResult.OK) await RefreshListDialogAsync();
            //}
        }
        private async void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblSupplyMainBindingSource)) return;
            await UpdateButtonAsync();
        }

        private async Task UpdateButtonAsync()
        {
            if ((tblSupplyMainBindingSource.Current as tblSupplyMain).supBrnId != Session.CurBranch.brnId)
            {
                ClsXtraMssgBox.ShowWarning("لا يمكن تعديل فواتير خاصة بفرع اخر من هذا الفرع!!!");
                return;
            }
            //flyDialog.WaitForm(this, 1);

            //using var frm = new formAddSupplyVoucher(tblSupplyMainBindingSource.Current as tblSupplyMain, this.clsTbSupplySub.GetSupplySubListBySupId(GetFoucsedSupplyMainId), this, this.supplyType);
            //flyDialog.WaitForm(this, 0);
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    await RefreshListDialogAsync();
            //    SetFoucesdRow(this.supNo);
            //}
        }

        private async void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblSupplyMainBindingSource)) return;
            await PhaseDataAsync();
        }

        private async void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblSupplyMainBindingSource)) return;
            await RemoveRowAsync(SupplyType.SalesDel);
        }

        private async void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblSupplyMainBindingSource)) return;
            await RemoveRowAsync(SupplyType.SalesRtrnDel);
        }

        private async void BbiDeleteAdmin_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.supplyType == SupplyType.Sales || this.supplyType == SupplyType.SalesRtrn) return;
            if (!ClsBindingSource.Validate(tblSupplyMainBindingSource)) return;
            await DeleteRowAsync();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView.OptionsSelection.MultiSelect = (!gridView.IsMultiSelect) ? true : false;
        }

        private async void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            await InitDataAsync();
            flyDialog.WaitForm(this, 0);
        }

        private void barButtonItem3_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblSupplyMainBindingSource)) return;
            if (barEditItem2.EditValue is double id && id > 0)
            {
                tblSupplyMain main = clsTbSupplyMain.GetSupplyMainList.FirstOrDefault(x => x.supNo == id);
                PrintInvoiceMssg((int)id, main, this.clsTbSupplySub.GetSupplySubListBySupId(main.id));
            }
            else
                PrintInvoiceMssg(Convert.ToInt32(gridView.GetFocusedRowCellValue(colsupNo)), tblSupplyMainBindingSource.Current as tblSupplyMain, this.clsTbSupplySub.GetSupplySubListBySupId(GetFoucsedSupplyMainId));

        }

        private void bbiPrintRprtTarhel_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblSupplyMainBindingSource)) return;
            flyDialog.WaitForm(this, 1);
              var frm = new ReportForm(ReportType.SupplyTarhel, tbSupplyMain: tblSupplyMainBindingSource.Current as tblSupplyMain);
            frm.Show();
            flyDialog.WaitForm(this, 0, frm);
        }

        private async Task RemoveRowAsync(SupplyType supplyType)
        {
            if (!DeleteRowMssg(out string delSuccessMssg)) return;
            if (!this.clsTbSupplyMain.Remove(tblSupplyMainBindingSource.Current as tblSupplyMain, supplyType)) return;
            if (/*!UpdatePrdQuantity() || */!this.clsTbSupplySub.RemoveRecordsBySupplyMainId(GetFoucsedSupplyMainId, supplyType)) return;

            tblSupplyMainBindingSource.RemoveCurrent();
            flyDialog.ShowDialogUCCustomdMsg(this, delSuccessMssg);
            await InitDataAsync();
        }

        //private bool UpdatePrdQuantity()
        //{
        //    short strId = Convert.ToInt16(gridView.GetFocusedRowCellValue(colsupStrId));
        //    var tbSupplySubList = this.clsTbSupplySub.GetSupplySubListBySupId(GetFoucsedSupplyMainId);
        //    var tbPrdQuanList = ClsSupplyPrdMan.ConvertList(tbSupplySubList, strId, this.clsTbPrdMan);
        //    return (this.supplyType == SupplyType.Sales) ? new ClsPrdQuantityOperations().AddPrdQuantity(tbPrdQuanList) && new ClsPrdPriceQuanOperations(new ClsTblPrdPriceQuan(), this.clsTbPrdMsur).AddPrdQuantity(tbPrdQuanList) :
        //        new ClsPrdQuantityOperations().DeductPrdQuantity(tbPrdQuanList) && new ClsPrdPriceQuanOperations(new ClsTblPrdPriceQuan(), this.clsTbPrdMsur).DeductPrdQuantity(tbPrdQuanList);
        //}

        private async Task DeleteRowAsync()
        {
            if (!DeleteRowMssg(out string delSuccessMssg)) return;
            if (!this.clsTbSupplyMain.Delete(tblSupplyMainBindingSource.Current as tblSupplyMain)) return;
            if (!this.clsTbSupplySub.DeleteRecordsBySupplyMainId(GetFoucsedSupplyMainId)) return;

            tblSupplyMainBindingSource.RemoveCurrent();
            flyDialog.ShowDialogUCCustomdMsg(this, delSuccessMssg);
            await InitDataAsync();
        }

        private bool DeleteRowMssg(out string delSuccessMssg)
        {
            delSuccessMssg = null;
            if (tblSupplyMainBindingSource.Current == null) return false;

            int supNo = Convert.ToInt32(gridView.GetFocusedRowCellValue(colsupNo));
            string delMssg = string.Format(_resource.GetString((this.supplyType == SupplyType.Sales || this.supplyType == SupplyType.SalesDel) ? "delSaleMssg" : "delSaleRtrnMssg"), supNo);
            delSuccessMssg = string.Format(_resource.GetString((this.supplyType == SupplyType.Sales || this.supplyType == SupplyType.SalesDel) ? "delSaleSuccessMssg" : "delSaleRtrnSuccessMssg"), supNo);

            return (XtraMessageBox.Show(delMssg, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ? true : false;
        }

        private async Task PhaseDataAsync()
        {
            if (XtraMessageBox.Show(_resource.GetString("phaseMssg"), "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            flyDialog.WaitForm(this, 1);
            ICollection<tblSupplyMain> tbSupplyMainList = new Collection<tblSupplyMain>();
            for (short i = 0; i < gridView.SelectedRowsCount; i++)
                tbSupplyMainList.Add(gridView.GetRow(gridView.GetSelectedRows()[i]) as tblSupplyMain);

            if (tbSupplyMainList.Count == 0)
            {
                flyDialog.WaitForm(this, 0);
                return;
            }
            if (new ClsSupplyTarhel(this.supplyType).PhaseInvoice(tbSupplyMainList))
            {
                flyDialog.WaitForm(this, 0);
                flyDialog.ShowDialogUCCustomdMsg(this, _resource.GetString("phaseSuccessMssg"));
                await InitDataAsync();
            }
            else flyDialog.WaitForm(this, 0);
            gridView.OptionsSelection.MultiSelect = false;
        }

        private void repositoryItemRadioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            MySetting.DefaultSetting.printA4 = (byte)(sender as RadioGroup).EditValue;
            MySetting.WriterSettingPublic();
            MySetting.DefaultSetting.printA4 = MySetting.DefaultSetting.printA4;
        }

        private async void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblSupplyMainBindingSource)) return;
            await UndoPhaseAsync();
        }

        private async Task UndoPhaseAsync()
        {
            //    tblSupplyMain tbSupplyMain = gridView.GetFocusedRow() as tblSupplyMain;
            //    if (XtraMessageBox.Show(string.Format(_resource.GetString("undoPhaseMssg"), tbSupplyMain.supNo), "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            //    flyDialog.WaitForm(this, 1);
            //    if (new ClsSupplyTarhelDelete((SupplyType)tbSupplyMain.supStatus, this.clsTbSupplySub).UndoPhase(tbSupplyMain))
            //    {
            //        tblSupplyMainBindingSource.RemoveCurrent();
            //        flyDialog.WaitForm(this, 0);
            //        flyDialog.ShowDialogUCCustomdMsg(this, string.Format(_resource.GetString("undoPhaseSuccesMssg"), tbSupplyMain.supNo));
            //        await InitDataAsync();
            //    }
            //    else flyDialog.WaitForm(this, 0);
        }

        private void SetUserControlLayout()
        {
            InitUserRight();
            SetPropertiesVisibility();
            radioGroupPrintType.EditValue = MySetting.DefaultSetting.printA4;
        }

        private void InitUserRight()
        {
            if (this.supplyType == SupplyType.Sales)
                new ClsUserControlValidation(this, UserControls.Sale);
            else if (this.supplyType == SupplyType.SalesRtrn)
                new ClsUserControlValidation(this, UserControls.SaleRtrn);
            else if (this.supplyType == SupplyType.SalesPhaseAll)
                new ClsUserControlValidation(this, UserControls.SalePhased);
        }

        public void SetRefreshListDialog(string mssg, int supNo, bool isNew, tblSupplyMain tbSupplyMain, IEnumerable<tblSupplySub> tbSupplySubList)
        {
            this.flyDialogMssg = mssg;
            this.supNo = supNo;
            this.isNew = isNew;
            this.tbSupplyMainPrint = tbSupplyMain;
            this.tbSupplySubListPrint = tbSupplySubList;
        }

        private async Task RefreshListDialogAsync()
        {
            if (this.isNew) flyDialog.ShowDialogUC(this, this.flyDialogMssg);
            else flyDialog.ShowDialogUCUpdMsg(this, this.flyDialogMssg);

            await InitDataAsync();
        }

        public void SetFoucesdRow(int supNo)
        {
            gridView.FocusedRowHandle = gridView.LocateByValue("supNo", supNo);

            if (!MySetting.DefaultSetting.defaultPrintOnSave) return;
            if (MySetting.DefaultSetting.ShowPrintMssg) PrintInvoiceMssg(supNo, this.tbSupplyMainPrint, this.tbSupplySubListPrint);
            else PrintInvoice(this.tbSupplyMainPrint, this.tbSupplySubListPrint);
        }

        private void PrintInvoiceMssg(int supNo, tblSupplyMain tbSupplyMain, IEnumerable<tblSupplySub> tbSupplySubList)
        {
            if (XtraMessageBox.Show(string.Format(_resource.GetString("printMssg"), supNo), "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                flyDialog.WaitForm(this, 1);
                using (ReportForm frm = new ReportForm((MySetting.DefaultSetting.supplyA4CustomRprt) ? ReportType.SupplyCustom :
                    (ReportType)MySetting.DefaultSetting.printA4, tbSupplyMain: tbSupplyMain, tbSupplySubList: tbSupplySubList, clsTbPrdMsur: this.clsTbPrdMsur))
                {
           
                    flyDialog.WaitForm(this, 0, frm);
                    frm.ShowDialog();
                }
            }
        }

        private void PrintInvoice(tblSupplyMain tbSupplyMain, IEnumerable<tblSupplySub> tbSupplySubList)
        {
            //flyDialog.WaitForm(this, 1);
            Task.Run(() => ClsPrintReport.PrintSupply(tbSupplyMain, tbSupplySubList));
            //flyDialog.WaitForm(this, 0);
        }


        public async Task RefreshData()
        {
            await InitDataAsync();
        }

        private void SetPropertiesVisibility()
        {
            switch (this.supplyType)
            {
                case SupplyType.Sales:
                    ribbonPageGroup5.Visible = false;
                    colsupDebit.Visible = false;
                    bbiNew.ItemShortcut = new BarShortcut(Keys.F2);
                    break;
                case SupplyType.SalesRtrn:
                    ribbonPageGroup1.Visible = false;
                    colsupCredit.Visible = false;
                    barButtonItem4.ItemShortcut = new BarShortcut(Keys.F2);
                    break;
                case SupplyType.SalesPhaseAll:
                    HideRibbonGroups();
                    ribbonPageGroup6.Visible = true;
                    colsupStatus.Visible = true;
                    colsupDebit.Visible = false;
                    break;
                case SupplyType.SalesDel:
                    HideRibbonGroups();
                    ribbonPageGroup2.Visible = false;
                    ribbonPageGroupDel.Visible = true;
                    break;
                case SupplyType.SalesRtrnDel:
                    goto case SupplyType.SalesDel;
            }


        }

        private void HideRibbonGroups()
        {
            ribbonPageGroup1.Visible = false;
            ribbonPageGroup3.Visible = false;
            ribbonPageGroup5.Visible = false;
        }

        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng)
            {
                _ci = new CultureInfo("ar");
                _resource = new ComponentResourceManager(typeof(Language.SalesManagementAr));
            }
            else
            {
                _ci = new CultureInfo("en");
                _resource = new ComponentResourceManager(typeof(Language.UCsaleEn));
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
            foreach (GridColumn c in gridView1.Columns)
                _resource.ApplyResources(c, c.Name, _ci);

            _resource.ApplyResources(ribbonPage1, ribbonPage1.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup1, ribbonPageGroup1.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup2, ribbonPageGroup2.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup3, ribbonPageGroup3.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup5, ribbonPageGroup5.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup6, ribbonPageGroup6.Name, _ci);
            repositoryItemRadioGroup1.Items[1].Description = _resource.GetString("cashier");
            barButtonItem7.Caption = _resource.GetString("barButtonItem7");
            colsupDscntAmount.Caption = _resource.GetString("colsupDscntAmount");
            colsupTotalFinal.Caption = _resource.GetString("colsupTotalFinal");


            radioGroupPrintType.EditWidth = 67;
        }

        private accountingEntities db = new accountingEntities();
        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            int[] supNos = db.tblSupplySubs.Where(x => x.supTaxPrice.HasValue == false || x.supTaxPrice.Value <= 0).GroupBy(x => x.supNo).Select(x => x.Key).ToArray();
            tblSupplyMainBindingSource.DataSource = this.tbSupplyMainList.Where(x => supNos.Contains(x.id)).ToList();
            bsiRecordsCount.Caption = _resource.GetString("count") + tblSupplyMainBindingSource.Count;
        }
    }
}
