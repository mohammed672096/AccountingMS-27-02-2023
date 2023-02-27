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
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class UCpurchases : XtraUserControl
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblPrdPriceMeasurment clsTbPrdMsur = new ClsTblPrdPriceMeasurment();
        ClsTblCurrency curr = new ClsTblCurrency();
        ClsTblSupplyMain clsTbSupplyMain;
        ClsTblSupplySub clsTbSupplySub;
        ClsTblSupplier ClsTblSupplier;
        tblSupplyMain tbSupplyMainPrint;
        IEnumerable<tblSupplySub> tbSupplySubListPrint;
        IEnumerable<tblSupplyMain> tbSupplyMainList;
        IDictionary<int, double> dicTotalFinalList;

        private SupplyType supplyType;
        private int supNo;
        private bool isNew;

        public UCpurchases(SupplyType supplyType)
        {
            this.supplyType = supplyType;
            InitializeComponent();
            GetResources();
            InitData();
            InitUserRight();
            SetUserControlLayout();
            gridControl.KeyDown += GridControl_KeyDown;

            gridView.MasterRowGetRelationCount += GridView_MasterRowGetRelationCount;
            gridView.MasterRowEmpty += GridView_MasterRowEmpty;
            gridView.MasterRowGetChildList += GridView_MasterRowGetChildList;
            gridView.MasterRowGetRelationName += GridView_MasterRowGetRelationName;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
            gridView.CustomUnboundColumnData += GridView_CustomUnboundColumnData;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
            if (supplyType == SupplyType.Purchase) gridView.DoubleClick += GridView_DoubleClick;
        }
        private accountingEntities db = new accountingEntities();
        private void barCheckItem1_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            int[] supNos = db.tblSupplySubs.Where(x => x.supTaxPrice.HasValue == false || x.supTaxPrice.Value <= 0).GroupBy(x => x.supNo).Select(x => x.Key).ToArray();
            tblSupplyMainBindingSource.DataSource = this.tbSupplyMainList.Where(x => supNos.Contains(x.id)).ToList();
            bsiRecordsCount.Caption = _resource.GetString("count") + tblSupplyMainBindingSource.Count;
        }
        private void GridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6 && (this.supplyType == SupplyType.Purchase))
                bbiDelete.PerformClick();
            else if (e.KeyCode == Keys.F6 && (this.supplyType == SupplyType.PurchaseRtrn))
                barButtonItem7.PerformClick();
        }
        private void InitData()
        {
            this.clsTbSupplyMain = new ClsTblSupplyMain(this.supplyType);
            this.clsTbSupplySub = new ClsTblSupplySub(this.supplyType);
            this.ClsTblSupplier = new ClsTblSupplier();
            this.tbSupplyMainList = this.clsTbSupplyMain.GetSupplyMainList.OrderByDescending(x => x.supDate).ToList();

            InitTotalFinalList();

            tblSupplyMainBindingSource.DataSource = this.tbSupplyMainList;
            bsiRecordsCount.Caption = _resource.GetString("count") + tblSupplyMainBindingSource.Count;
            tblSupplyMain v = new tblSupplyMain();
            new ClsTblBranch().InitRepositoryItemBranchLookupEdit(gridControl, nameof(v.supBrnId));
            if (Session.CurrentUser.id == 1)
                colsupNo.Caption = "رقم الفاتورة الفرعي";
            else
                colMainNo.Visible = false;
        }

        private void InitTotalFinalList()
        {
            if (this.tbSupplyMainList == null) return;
            this.dicTotalFinalList = new Dictionary<int, double>();
            int loopCount = 0;

            foreach (var tbSupplyMain in this.tbSupplyMainList)
            {
                this.dicTotalFinalList.Add(loopCount, (tbSupplyMain.supTotal +
                    Convert.ToDouble(tbSupplyMain.supTaxPrice)) - Convert.ToDouble(tbSupplyMain.supDscntAmount));

                loopCount++;
            }
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "supMsur")
                e.DisplayText = clsTbPrdMsur.GetPrdPriceMsurNameById(Convert.ToInt32(e.Value));
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            UpdateButton();
        }

        private void GridView_MasterRowGetRelationCount(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void GridView_MasterRowEmpty(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs e)
        {
            e.IsEmpty = false;
        }

        private void GridView_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Level1";
        }

        private void GridView_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            e.ChildList = this.clsTbSupplySub.GetSupplySubIListBySupId(GetFoucsedSupplyMainId);
        }

        private int GetFoucsedSupplyMainId => Convert.ToInt32(gridView.GetFocusedRowCellValue(colsupMainId));

        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value == null) return;
            if (e.Column.FieldName == "supStatus")
                e.DisplayText = ClsSupplyStatus.GetString(Convert.ToByte(e.Value));
            else if (e.Column.FieldName == "supCurrency")
                e.DisplayText = curr.GetCurrencyNameById(Convert.ToByte(e.Value));
            else if (e.Column.FieldName == colsupCustSplId.FieldName)
            { 
                int sup = ((e.Value as int?) ?? 0);
                e.DisplayText = sup != 0? this.ClsTblSupplier.GetSupplierNameById(sup):"";
            }
                

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

        private void UpdateButton()
        {
            if ((tblSupplyMainBindingSource.Current as tblSupplyMain).supBrnId != Session.CurBranch.brnId)
            {
                ClsXtraMssgBox.ShowWarning("لا يمكن تعديل فواتير خاصة بفرع اخر من هذا الفرع!!!");
                return;
            }
            try
            {
                var f = (Application.OpenForms.Cast<object>())?.FirstOrDefault(x => x is formSupplyMain formSupply 
                && formSupply.supplyType == SupplyType.Purchase && !formSupply.AddSaleInvoice.isNew) as Form;
                if (f != null && f is formSupplyMain formSupply)
                    formSupply.Activate();
                else
                {
                    flyDialog.WaitForm(this, 1);
                    f = new formSupplyMain(tblSupplyMainBindingSource.Current as tblSupplyMain, 
                        this.clsTbSupplySub.GetSupplySubListBySupId(GetFoucsedSupplyMainId).ToList(), SupplyType.Purchase, this.ParentForm);
                    f.Show(); flyDialog.WaitForm(this, 0, f);

                }
                //var ff = (Application.OpenForms.Cast<object>())?.FirstOrDefault(x => x is formAddSupplyRcpt addSupplyRcpt
                //&& addSupplyRcpt.supplyType == SupplyType.Purchase && !(addSupplyRcpt.ParentForm is formSupplyMain)) as Form;
                //if (ff != null && ff is formAddSupplyRcpt addSupplyRcpt)
                //    addSupplyRcpt.Activate();
                //else
                //{
                //    flyDialog.WaitForm(this, 1);
                //    ff = new formAddSupplyRcpt(tblSupplyMainBindingSource.Current as tblSupplyMain,
                //this.clsTbSupplySub.GetSupplySubListBySupId(GetFoucsedSupplyMainId), this, this.supplyType);
                //    ff.Show();
                //    flyDialog.WaitForm(this, 0, ff);

                //}
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            //flyDialog.WaitForm(this, 1);
            //using var frm = new formAddSupplyRcpt(tblSupplyMainBindingSource.Current as tblSupplyMain,
            //    this.clsTbSupplySub.GetSupplySubListBySupId(GetFoucsedSupplyMainId), this, this.supplyType);
            //flyDialog.WaitForm(this, 0);

            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    RefreshListDialog();
            //    SetFoucesdRow(this.supNo);
            //}
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            //flyDialog.WaitForm(this, 1);
            ////using var frm = await formSupplyMain.CreateAsync(this, this.supplyType);
            //using var frm = new formSupplyMain(this, this.supplyType);
            //frm.ResetAppearance();

            //flyDialog.WaitForm(this, 0);
            if (this.ParentForm is FormMain formMain)
                formMain.simpleButtonPurchase_Click(sender,e);
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    RefreshListDialog();
            //    SetFoucesdRow(this.supNo);
            //}
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ParentForm is FormMain formMain)
                formMain.simpleButtonPurchaseRtrn_Click(sender,e);
            //flyDialog.WaitForm(this, 1);
            //using var frm = new formAddSupplyRcpt(null, null, this, this.supplyType);
            //flyDialog.WaitForm(this, 0);

            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    RefreshListDialog();
            //    SetFoucesdRow(this.supNo);
            //}
        }

        private void bbiDirectPurchaseRtrn_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (this.ParentForm is FormMain formMain)
                {
                    var f = (Application.OpenForms.Cast<object>())?.FirstOrDefault(x => x is formSupplyMain formAddSupplyRcpt && formAddSupplyRcpt.supplyType == SupplyType.DirectPurchaseRtrn);
                    if (f != null && f is formSupplyMain formAddSupplyRcpt)
                        formAddSupplyRcpt.Activate();
                    else
                    {
                        flyDialog.WaitForm(this, 1);
                        formSupplyMain frm = new formSupplyMain(null, null, SupplyType.DirectPurchaseRtrn, formMain);
                        frm.Show();
                        flyDialog.WaitForm(this, 0, frm);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

            //flyDialog.WaitForm(this, 1);
            //using var form = new formAddSupplyRcpt(null, null, this, SupplyType.DirectPurchaseRtrn);
            //flyDialog.WaitForm(this, 0);

            //if (form.ShowDialog() == DialogResult.OK)
            //{
            //    RefreshListDialog();
            //    SetFoucesdRow(this.supNo);
            //}
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblSupplyMainBindingSource)) return;
            UpdateButton();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblSupplyMainBindingSource)) return;
            RemoveRow(SupplyType.PurchaseDel);
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblSupplyMainBindingSource)) return;
            RemoveRow(SupplyType.PurchaseRtrnDel);
        }

        private void BbiDeleteAdmin_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblSupplyMainBindingSource)) return;
            DeleteRow();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            InitData();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblSupplyMainBindingSource)) return;

            if (barEditItem2.EditValue is double id && id > 0)
            {
                tblSupplyMain main = clsTbSupplyMain.GetSupplyMainList.FirstOrDefault(x => x.supNo == id);
                PrintInvoiceMssg((int)id, main, this.clsTbSupplySub.GetSupplySubListBySupId(main.id));
            }
            else
            {
                PrintInvoiceMssg(Convert.ToInt32(gridView.GetFocusedRowCellValue(colsupNo)), tblSupplyMainBindingSource.Current as tblSupplyMain, this.clsTbSupplySub.GetSupplySubListBySupId(GetFoucsedSupplyMainId));
            }
        }

        private void bbiPrintRprtTarhel_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblSupplyMainBindingSource)) return;
            flyDialog.WaitForm(this, 1);
              var frm = new ReportForm(ReportType.SupplyTarhel, tbSupplyMain: tblSupplyMainBindingSource.Current as tblSupplyMain);
            frm.Show();
            flyDialog.WaitForm(this, 0, frm);
        }

        private void repositoryItemRadioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            MySetting.DefaultSetting.printA4 = (byte)(sender as RadioGroup).EditValue;
            MySetting.WriterSettingPublic(); 
            MySetting.DefaultSetting.printA4 = MySetting.DefaultSetting.printA4;
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView.OptionsSelection.MultiSelect = (!gridView.IsMultiSelect) ? true : false;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblSupplyMainBindingSource)) return;
            PhaseData();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblSupplyMainBindingSource)) return;
            UndoPhase();
        }

        private void RemoveRow(SupplyType supplyType)
        {
            if (!DeleteRowMssg(out string delSuccessMssg)) return;
            if (!this.clsTbSupplyMain.Remove(tblSupplyMainBindingSource.Current as tblSupplyMain, supplyType)) return;
            if (/*!UpdatePrdQuantity() || */!this.clsTbSupplySub.RemoveRecordsBySupplyMainId(GetFoucsedSupplyMainId, supplyType)) return;

            tblSupplyMainBindingSource.RemoveCurrent();
            flyDialog.ShowDialogUCCustomdMsg(this, delSuccessMssg);
            InitData();
        }

        //private bool UpdatePrdQuantity()
        //{
        //    short strId = Convert.ToInt16(gridView.GetFocusedRowCellValue(colsupStrId));
        //    IEnumerable<tblSupplySub> tbSupplySubList = this.clsTbSupplySub.GetSupplySubListBySupId(GetFoucsedSupplyMainId);

        //    return (this.supplyType == SupplyType.Purchase) ? new ClsPrdQuantityOperations().DeductPrdQuantity(tbSupplySubList, strId) && new ClsPrdPriceQuanOperations(new ClsTblPrdPriceQuan(), this.clsTbPrdMsur).DeductPrdQuantity(tbSupplySubList) :
        //        new ClsPrdQuantityOperations().AddPrdQuantity(tbSupplySubList, strId) && new ClsPrdPriceQuanOperations(new ClsTblPrdPriceQuan(), this.clsTbPrdMsur).AddPrdQuantity(tbSupplySubList);
        //}

        private void DeleteRow()
        {
            if (!DeleteRowMssg(out string delSuccessMssg)) return;
            if (!this.clsTbSupplyMain.Delete(tblSupplyMainBindingSource.Current as tblSupplyMain)) return;
            if (!this.clsTbSupplySub.DeleteRecordsBySupplyMainId(GetFoucsedSupplyMainId)) return;

            tblSupplyMainBindingSource.RemoveCurrent();
            flyDialog.ShowDialogUCCustomdMsg(this, delSuccessMssg);
            InitData();
        }

        private bool DeleteRowMssg(out string delSuccessMssg)
        {
            delSuccessMssg = null;
            if (tblSupplyMainBindingSource.Current == null) return false;

            int supNo = Convert.ToInt32(gridView.GetFocusedRowCellValue(colsupNo));
            string delMssg = string.Format(_resource.GetString((this.supplyType == SupplyType.Purchase || this.supplyType == SupplyType.PurchaseDel) ? "delPurchaseMssg" : "delPurchaseRtrnMssg"), supNo);
            delSuccessMssg = string.Format(_resource.GetString((this.supplyType == SupplyType.Purchase || this.supplyType == SupplyType.PurchaseDel) ? "delPurchaseSuccessMssg" : "delPurchaseRtrnSuccessMssg"), supNo);

            return (XtraMessageBox.Show(delMssg, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ? true : false;
        }

        private void PhaseData()
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
                InitData();
            }
            else flyDialog.WaitForm(this, 0);
            gridView.OptionsSelection.MultiSelect = false;
        }

        //private void UndoPhase()
        //{
        //    tblSupplyMain tbSupplyMain = gridView.GetFocusedRow() as tblSupplyMain;
        //    if (XtraMessageBox.Show(string.Format(_resource.GetString("undoPhaseMssg"), tbSupplyMain.supNo), "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

        //    flyDialog.WaitForm(this, 1);
        //    if (new ClsSupplyTarhelDelete((SupplyType)tbSupplyMain.supStatus, this.clsTbSupplySub).UndoPhase(tbSupplyMain))
        //    {
        //        tblSupplyMainBindingSource.RemoveCurrent();
        //        flyDialog.WaitForm(this, 0);
        //        flyDialog.ShowDialogUCCustomdMsg(this, string.Format(_resource.GetString("undoPhaseSuccesMssg"), tbSupplyMain.supNo));
        //        InitData();
        //    }
        //    else flyDialog.WaitForm(this, 0);
        //}
        private void UndoPhase()
        {
            if (ClsXtraMssgBox.ShowWarningYesNo(_resource.GetString("undoSelectionPhaseMssg")) != DialogResult.Yes) return;
            // if (XtraMessageBox.Show(_resource.GetString("undoPhaseMssg"), "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            flyDialog.WaitForm(this, 1);
            ICollection<tblSupplyMain> tbSupplyMainList = new Collection<tblSupplyMain>();
            for (short i = 0; i < gridView.SelectedRowsCount; i++)
                tbSupplyMainList.Add(gridView.GetRow(gridView.GetSelectedRows()[i]) as tblSupplyMain);
            if (tbSupplyMainList.Count == 0)
            {
                flyDialog.WaitForm(this, 0);
                return;
            }
            if (new ClsSupplyTarhelDelete(this.supplyType).UndoPhaseInvoice(tbSupplyMainList))
            {
                flyDialog.WaitForm(this, 0);
                flyDialog.ShowDialogUCCustomdMsg(this, _resource.GetString("undoSelectionPhaseSuccessMssg"));
                InitData();
            }
            else flyDialog.WaitForm(this, 0);
            gridView.OptionsSelection.MultiSelect = false;
        }
        public void SetRefreshListDialog(int supNo, bool isNew, tblSupplyMain tbSupplyMain, IEnumerable<tblSupplySub> tbSupplySubList)
        {
            this.supNo = supNo;
            this.isNew = isNew;
            this.tbSupplyMainPrint = tbSupplyMain;
            this.tbSupplySubListPrint = tbSupplySubList;
        }

        public void RefreshListDialog()
        {
            //var submain = this.tbSupplyMainList.FirstOrDefault(x => x.id == this.tbSupplyMainPrint?.id);
            //if(submain==null&& tbSupplyMainPrint!=null)
            //this.tbSupplyMainList.Add(this.tbSupplyMainPrint);

            //tblSupplyMainBindingSource.DataSource = this.tbSupplyMainList;
            InitData();
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
                using (ReportForm frm = new ReportForm((ReportType)MySetting.DefaultSetting.printA4, tbSupplyMain: tbSupplyMain, tbSupplySubList: tbSupplySubList))
                {
                    flyDialog.WaitForm(this, 0,frm);
                    frm.ShowDialog();
                }
            }
        }

        private void PrintInvoice(tblSupplyMain tbSupplyMain, IEnumerable<tblSupplySub> tbSupplySubList)
        {
            flyDialog.WaitForm(this, 1);
            ClsPrintReport.PrintSupply(tbSupplyMain, tbSupplySubList);
            flyDialog.WaitForm(this, 0);
        }

        public void RefreshData()
        {
            InitData();
        }

        private void InitUserRight()
        {
            if (this.supplyType == SupplyType.Purchase)
                new ClsUserControlValidation(this, UserControls.Purchase);
            else if (this.supplyType == SupplyType.PurchaseRtrn)
                new ClsUserControlValidation(this, UserControls.PurchaseRtrn);
            else if (this.supplyType == SupplyType.PurchasePhaseAll)
                new ClsUserControlValidation(this, UserControls.PurchasePhased);
        }

        private void SetUserControlLayout()
        {
            radioGroupPrintType.EditValue = MySetting.DefaultSetting.printA4;
            switch (this.supplyType)
            {
                case SupplyType.Purchase:
                    ribbonPageGroup4.Visible = false;
                    colsupCredit.Visible = false;
                    bbiNew.ItemShortcut = new BarShortcut(Keys.F2);
                    break;
                case SupplyType.PurchaseRtrn:
                    ribbonPageGroup1.Visible = false;
                    colsupDebit.Visible = false;
                    barButtonItem5.ItemShortcut = new BarShortcut(Keys.F2);
                    break;
                case SupplyType.PurchasePhaseAll:
                    HideRibbonGroups();
                    ribbonPageGroup6.Visible = true;
                    colsupCredit.Visible = false;
                    colsupStatus.Visible = true;
                    break;
                case SupplyType.PurchaseDel:
                    HideRibbonGroups();
                    ribbonPageGroup2.Visible = false;
                    ribbonPageGroupDel.Visible = true;
                    break;
                case SupplyType.PurchaseRtrnDel:
                    goto case SupplyType.PurchaseDel;
            }
        }

        private void HideRibbonGroups()
        {
            ribbonPageGroup1.Visible = false;
            ribbonPageGroup3.Visible = false;
            ribbonPageGroup4.Visible = false;
        }

        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng)
            {
                _ci = new CultureInfo("ar");
                _resource = new ComponentResourceManager(typeof(Language.PurchaseManagementAr));
            }
            else
            {
                _ci = new CultureInfo("en");
                _resource = new ComponentResourceManager(typeof(Language.UCpurchasesEn));
            }

            if (MySetting.GetPrivateSetting.LangEng) EnglishTranslation();
        }

        private void EnglishTranslation()
        {
            RightToLeft = RightToLeft.No;
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
            _resource.ApplyResources(ribbonPageGroup4, ribbonPageGroup4.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup6, ribbonPageGroup6.Name, _ci);
            repositoryItemRadioGroup1.Items[1].Description = _resource.GetString("cashier");
            colsupDscntAmount.Caption = _resource.GetString("colsupDscntAmount");
            colsupTotalFinal.Caption = _resource.GetString("colsupTotalFinal");
            barCheckItem1.Caption = _resource.GetString("barCheckItem1");
            radioGroupPrintType.EditWidth = 67;
        }

        private void BtnShowCancelBuyTarhel_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView.OptionsSelection.MultiSelect = (!gridView.IsMultiSelect) ? true : false;
        }
    }
}

