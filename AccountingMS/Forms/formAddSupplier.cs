using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formAddSupplier : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        accountingEntities db = new accountingEntities();
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblCurrency clsTbCurrency = new ClsTblCurrency();
        ClsSupplierBalanceData clsSplBalanceData;
        ClsTblSupplySub clsTbSupplySub;
        public  tblSupplier tbSupplier;
        ClsTblAccount clsTbAccount;
        ClsTblDefaultAccount clsTbDefaultAcc;

        private readonly string folderPath = @$"{ClsDrive.Path}:\B-Tech\Layout";
        private readonly UCsupplier _ucSupplier;
        private bool isNew;
        private long splAccNo;
        private int dfltSplAccNo;

        private void formAddSupplier_Load(object sender, EventArgs e)
        {
            new ClsLinQuery().accNo(splAccNoTextEdit);
            if (!this.isNew) InitGridLayout();
            GetResources();
        }

        public formAddSupplier(tblSupplier obj, UCsupplier ucSupplier)
        {
            InitializeComponent();
            InitData(obj);
            InitDefaultData();
            _ucSupplier = ucSupplier;
            dataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;

            ribbonControl1.SelectedPageChanged += RibbonControl1_SelectedPageChanged;
            splAccNoTextEdit.EditValueChanged += SplAccNoTextEdit_EditValueChanged;
            gridView1.OptionsDetail.DetailMode = DetailMode.Embedded;
            gridView1.MasterRowGetRelationCount += GridView1_MasterRowGetRelationCount;
            gridView1.MasterRowEmpty += GridView1_MasterRowEmpty;
            gridView1.MasterRowGetChildList += GridView1_MasterRowGetChildList;
            gridView1.MasterRowGetRelationName += GridView1_MasterRowGetRelationName;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
            gridView3.CustomColumnDisplayText += GridView3_CustomColumnDisplayText;
            gridView1.ShowCustomizationForm += GridView_ShowCustomizationForm;
            gridView3.ShowCustomizationForm += GridView_ShowCustomizationForm;
            gridView1.HideCustomizationForm += GridView1_HideCustomizationForm;
            gridView3.HideCustomizationForm += GridView3_HideCustomizationForm;
            gridViewCurrentBalance.RowCellStyle += GridView_RowCellStyle;
            gridViewPeriodBalance.RowCellStyle += GridView_RowCellStyle;
            gridViewPeriodBalance.FocusedRowChanged += GridViewPeriodBalance_FocusedRowChanged;
            btnCalculatePeriodBalance.Click += BtnCalculatePeriodBalance_Click;
            bbiClose.ItemClick += BbiClose_ItemClick;
            bbiClose1.ItemClick += BbiClose_ItemClick;
            bbiClose2.ItemClick += BbiClose_ItemClick;
            bbiCLose3.ItemClick += BbiClose_ItemClick;
            bbiPrint2.ItemClick += BbiPrint2_ItemClick;
            bbiPrint3.ItemClick += BbiPrint3_ItemClick;
            bbiAutoAccNo.CheckedChanged += BbiAutoAccNo_CheckedChanged;
            this.FormClosing += FormAddSupplier_FormClosing;
        }

        private void InitData(tblSupplier obj)
        {
            if (obj == null)
            {
                this.isNew = true;
                this.tbSupplier = new tblSupplier() { splCurrency = 0, splBrnId = Session.CurBranch.brnId, splStatus = 1 };
                new ClsTblBranch().InitBranchLookupEdit(layoutControlGroup4, tblSupplierBindingSource, nameof(tbSupplier.splBrnId));
                tblSupplierBindingSource.DataSource = this.tbSupplier;
                db.tblSuppliers.Add(tblSupplierBindingSource.Current as tblSupplier);

                SetRibbonProperties();
            }
            else
            {
                this.isNew = false;
                this.splAccNo = obj.splAccNo;
                this.tbSupplier = obj;
                tblSupplierBindingSource.DataSource = this.tbSupplier;
                db.tblSuppliers.Attach(tblSupplierBindingSource.Current as tblSupplier);

                InitSupplierrBalanceData();
                SetEditForm();
            }
        }

        private void SetRibbonProperties()
        {
            bbiAutoAccNo.Checked = true;
            BbiAutoAccNoItemVisibility(true);

            ribbonPageGroupAutoAddAccNo.Visible = true;
            ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
        }

        private void InitDefaultData()
        {
            tblCountryBindingSource.DataSource = Session.Countries;

            if (this.isNew)
            {
                this.clsTbAccount = new ClsTblAccount();
                this.clsTbDefaultAcc = new ClsTblDefaultAccount();
                this.clsTbCurrency.InitCurrencyLookupEdit(splCurrencyTextEdit);
                tbSupplier.splCurrency = clsTbCurrency.FirstCurrency;
            }
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "supStatus")
                e.DisplayText = ClsSupplyStatus.GetString(Convert.ToByte(e.Value), 2);
            else if (e.Column.FieldName == "supCurrency")
                e.DisplayText = clsTbCurrency.GetCurrencySignById(Convert.ToByte(e.Value));
        }

        private void GridView3_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "entStatus")
                e.DisplayText = ClsEntryStatus.GetString(Convert.ToByte(e.Value));
            else if (e.Column.FieldName == "entCurrency")
                e.DisplayText = clsTbCurrency.GetCurrencySignById(Convert.ToByte(e.Value));
        }

        private void GridView_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "currentBalance")
                e.Appearance.ForeColor = GetCurrentBalanceColor(Convert.ToDouble(e.CellValue));
        }

        private void GridViewPeriodBalance_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SetCurrentBalance2HeaderColor(Convert.ToDouble(gridViewPeriodBalance.GetFocusedRowCellValue(colcurrentBalance2)));
        }

        private void GridView1_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Level1";
        }

        private void GridView1_MasterRowEmpty(object sender, MasterRowEmptyEventArgs e)
        {
            e.IsEmpty = false;
        }

        private void GridView1_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void GridView1_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            e.ChildList = this.clsTbSupplySub.GetSupplySubIListBySupId(Convert.ToInt32(gridView1.GetFocusedRowCellValue(colsupId)));
        }

        private void SplAccNoTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;

            this.tbSupplier.splCurrency = Convert.ToByte(editor.GetColumnValue("accCurrency"));
        }

        private void BbiAutoAccNo_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BbiAutoAccNoItemVisibility(bbiAutoAccNo.Checked);
        }

        private void BbiAutoAccNoItemVisibility(bool checkState)
        {
            switch (checkState)
            {
                case true:
                    ItemForsplAccNo.Visibility = LayoutVisibility.Never;
                    ItemForsplNo.Visibility = LayoutVisibility.Never;
                    ItemForsplCurrency.Visibility = LayoutVisibility.Always;
                    ItemForsplAccNo.TextAlignMode = TextAlignModeItem.AutoSize;
                    break;
                case false:
                    ItemForsplCurrency.Visibility = LayoutVisibility.Never;
                    ItemForsplAccNo.Visibility = LayoutVisibility.Always;
                    ItemForsplNo.Visibility = LayoutVisibility.Always;
                    ItemForsplAccNo.TextAlignMode = TextAlignModeItem.UseParentOptions;
                    break;
            }
            SetCurrentFocusedItem(checkState);
        }

        private void SetCurrentFocusedItem(bool autoAccNo)
        {
            if (!autoAccNo)
                splAccNoTextEdit.Focus();
            else
                splCurrencyTextEdit.Focus();
        }
        public bool CloseAfterSave;
        public int supplierId;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            if (!SaveAutoAccNo()) return;
            SaveAccName();
            bool save = SaveDB();
            if (save) Session.Suppliers.Add(this.tbSupplier);
            if (save && _ucSupplier != null)
            {
                _ucSupplier.RefreshListDialog(((!MySetting.GetPrivateSetting.LangEng) ? "المورد: " : "Supplier: ") + splNameTextEdit.Text, this.isNew);
                this.Close();
                _ucSupplier.SetFocusedRow(Convert.ToInt32((!bbiAutoAccNo.Checked) ? splNoTextEdit.EditValue : this.splAccNo % 100000));
            }
            supplierId = tbSupplier.id;
            if (CloseAfterSave)
                this.Close();
        }

        private void SaveAccName()
        {
            if (this.isNew) return;

            new ClsTblAccount().UpdateAccNameByAccNo(this.tbSupplier.splAccNo, this.tbSupplier.splName);
        }

      
        private bool SaveAutoAccNo()
        {
            if (!this.isNew || !bbiAutoAccNo.Checked) return true;
            tblSupplier Supplier = tblSupplierBindingSource.Current as tblSupplier;
            if (Supplier == null) return false;
            if (Supplier.splBrnId == null | Supplier.splBrnId == 0)
            {
                XtraMessageBox.Show("يجب تحديد الفرع الخاص بالمورد");
                return false;
            }
            this.dfltSplAccNo = Convert.ToInt32(this.clsTbAccount.GetAccountNoById(this.clsTbDefaultAcc.GetDefultAccNoId((byte)DefaultAccType.Supplier, Supplier.splBrnId.Value)));

            if (this.dfltSplAccNo <= 0)
            {
                XtraMessageBox.Show("يجب تحديد الحساب الافتراضي للموردين لهذا الفرع");
                return false;
            }
            this.splAccNo = this.clsTbAccount.GetNewAccNo(dfltSplAccNo.ToString());
            SetSupplierObjFileds();
            return this.clsTbAccount.Add(DefaultAccType.Supplier, this.splAccNo, splNameTextEdit.Text, Convert.ToByte(splCurrencyTextEdit.EditValue), 2, Supplier.splBrnId.Value);
        }


        private void SetSupplierObjFileds()
        {
            this.tbSupplier.splAccNo = this.splAccNo;
            this.tbSupplier.splNo = Convert.ToInt32(this.splAccNo % 100000);
        }

        private void BbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void BbiPrint2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);

            using (ReportForm frm = new ReportForm(((ReportType)Convert.ToByte(bbiReportInvoiceType.EditValue)),
                tbSupplyMain: gridView1.GetFocusedRow() as tblSupplyMain, tbSupplySubList: this.clsTbSupplySub.GetSupplySubListBySupId(Convert.ToInt32(gridView1.GetFocusedRowCellValue(colsupId)))))
            {
                flyDialog.WaitForm(this, 0, frm);
                frm.ShowDialog();
            }
        }

        private void BbiPrint3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);

            byte entStatus = Convert.ToByte(gridView3.GetFocusedRowCellValue(colentStatus));
            ClsRprtEntryData entMain = new ClsRprtEntryData
            {
                entNo = Convert.ToInt32(gridView3.GetFocusedRowCellValue(colentNo)),
                boxName = this.tbSupplier.splName,
                entDesc = Convert.ToString(gridView3.GetFocusedRowCellValue(colentDesc)),
                entAmount = Convert.ToDouble(gridView3.GetFocusedRowCellValue((entStatus == 3 || entStatus == 6) ? colentCredit : colentDebit)),
                entDate = Convert.ToDateTime(gridView3.GetFocusedRowCellValue(colentDate)),
                entType = (entStatus == 3 || entStatus == 6) ? "سند قبض" : "سند صرف"
            };
            ClsEntryList entSub = new ClsEntryList
            {
                accNo = Convert.ToInt64(gridView3.GetFocusedRowCellValue(colentAccNo)),
                accName = Convert.ToString(gridView3.GetFocusedRowCellValue(colentAccName)),
                curreny = Convert.ToByte(gridView3.GetFocusedRowCellValue(colentCurrency)),
                desc = Convert.ToString(gridView3.GetFocusedRowCellValue(colentDesc)),
                debit = Convert.ToDouble(gridView3.GetFocusedRowCellValue((entStatus == 3 || entStatus == 6) ? colentCredit : colentDebit)),
            };

            using (ReportForm frm = new ReportForm((entStatus == 2 || entStatus == 5) ? ReportType.EntryVoucher : ReportType.EntryReceipt,
                new ArrayList { entMain }, new ArrayList { entSub }))
            {
                flyDialog.WaitForm(this, 0, frm);
                frm.ShowDialog();
            }
        }

        private void InitSupplierrBalanceData()
        {
            this.clsTbSupplySub = new ClsTblSupplySub(true);
            this.clsSplBalanceData = new ClsSupplierBalanceData(this.splAccNo);
            tblSupplyMainBindingSource.DataSource = this.clsSplBalanceData.GetSupplyMainInvoices;
            tblEntrySubBindingSource.DataSource = this.clsSplBalanceData.GetEntrySubList;

            textEditDtStart.EditValue = Session.CurrentYear.fyDateStart;
            textEditDtEnd.EditValue = Session.CurrentYear.fyDateEnd;

            SetCurrentBalance();
        }

        private void SetCurrentBalance()
        {
            double total = this.clsSplBalanceData.Credit - this.clsSplBalanceData.Debit;

            ClsBalanceColumnsData balanceColumnsData = new ClsBalanceColumnsData()
            {
                debit = this.clsSplBalanceData.Debit,
                credit = this.clsSplBalanceData.Credit,
                currentBalance = total
            };

            clsBalanceColumnsDataBindingSource1.DataSource = balanceColumnsData;
            SetCurrentBalance1HeaderColor(total);
        }

        private void SetCurrentBalance1HeaderColor(double total)
        {
            colcurrentBalance1.AppearanceHeader.ForeColor = GetCurrentBalanceColor(total);
        }

        private void SetCurrentBalance2HeaderColor(double total)
        {
            colcurrentBalance2.AppearanceHeader.ForeColor = GetCurrentBalanceColor(total);
        }

        private Color GetCurrentBalanceColor(double total)
        {
            return (total < 0) ? Color.FromArgb(192, 0, 0) : Color.Green;
        }

        private void BtnCalculatePeriodBalance_Click(object sender, EventArgs e)
        {
            this.clsSplBalanceData.CalculatePeriodBalance(this.splAccNo, textEditDtStart.DateTime, textEditDtEnd.DateTime);
            SetPeriodBalance();
        }

        private void SetPeriodBalance()
        {
            double total = this.clsSplBalanceData.CreditPeriod - this.clsSplBalanceData.DebitPeriod;

            ClsBalanceColumnsData balanceColumnsData = new ClsBalanceColumnsData()
            {
                debit = this.clsSplBalanceData.DebitPeriod,
                credit = this.clsSplBalanceData.CreditPeriod,
                currentBalance = total,
                dtStart = textEditDtStart.DateTime.Date,
                dtEnd = textEditDtEnd.DateTime.Date,
            };

            clsBalanceColumnsDataBindingSource2.Add(balanceColumnsData);
            SetCurrentBalance2HeaderColor(total);
        }

        private void RibbonControl1_SelectedPageChanged(object sender, EventArgs e)
        {
            if (ribbonControl1.SelectedPage == ribbonPageMain)
                navigationFrame1.SelectedPage = navigationPageMain;
            else if (ribbonControl1.SelectedPage == ribbonPageBalance)
                navigationFrame1.SelectedPage = navigationPageBalance;
            else if (ribbonControl1.SelectedPage == ribbonPageInvoices)
                navigationFrame1.SelectedPage = navigationPageInvoices;
            else if (ribbonControl1.SelectedPage == ribbonPageEntries)
                navigationFrame1.SelectedPage = navigationPageEntries;
        }

        private void SetEditForm()
        {
            this.Text = $"بيانات المورد : {this.tbSupplier.splName}";
            this.ClientSize = new Size(900, 460);
            navigationFrame1.SelectedPage = navigationPageBalance;
            InitRibbon();
            DisableItems();
        }

        private void DisableItems()
        {
            ItemForsplAccNo.Enabled = false;
            ItemForsplNo.Enabled = false;
        }

        private void InitRibbon()
        {
            ribbonPageMain.Text = "بيانات المورد";
            ribbonPageBalance.Visible = true;
            ribbonPageInvoices.Visible = true;
            ribbonPageEntries.Visible = true;
            ribbonControl1.SelectedPage = ribbonPageBalance;
            bbiReportInvoiceType.EditValue = MySetting.DefaultSetting.printA4;
        }

        private void GridView_ShowCustomizationForm(object sender, EventArgs e)
        {
            ((GridView)sender).CustomizationForm.Text = "تحديد الأعمده";
        }

        private void GridView1_HideCustomizationForm(object sender, EventArgs e)
        {
            gridView1.SaveLayoutToXml(this.folderPath + "\\FormSupplierGridLayoutInvoices.xml");
        }

        private void GridView3_HideCustomizationForm(object sender, EventArgs e)
        {
            gridView3.SaveLayoutToXml(this.folderPath + "\\FormSupplierGridLayoutEntries.xml");
        }

        private void FormAddSupplier_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                gridView1.SaveLayoutToXml(this.folderPath + "\\FormSupplierGridLayoutInvoices.xml");
                gridView3.SaveLayoutToXml(this.folderPath + "\\FormSupplierGridLayoutEntries.xml");
            }
            catch (Exception)
            {
            }
        }

        private void InitGridLayout()
        {
            try
            {
                string gridLayoutInvocies = this.folderPath + "\\FormSupplierGridLayoutInvoices.xml";
                string gridLayoutEntries = this.folderPath + "\\FormSupplierGridLayoutEntries.xml";

                if (!File.Exists(gridLayoutInvocies))
                {
                    gridView1.SaveLayoutToXml(gridLayoutInvocies);
                    gridView3.SaveLayoutToXml(gridLayoutEntries);
                }
                else
                {
                    gridView1.RestoreLayoutFromXml(gridLayoutInvocies);
                    gridView3.RestoreLayoutFromXml(gridLayoutEntries);
                }
            }
            catch (Exception)
            {


            }
        }

        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = false;

            _ci = new CultureInfo("en");
            _resource = new ComponentResourceManager(typeof(Language.formAddSupplierEn));

            foreach (LayoutControlItem item in layoutControlGroup3.Items)
                _resource.ApplyResources(item, item.Name, _ci);
            foreach (LayoutControlItem item in layoutControlGroup4.Items)
                _resource.ApplyResources(item, item.Name, _ci);

            _resource.ApplyResources(ribbonPageMain, ribbonPageMain.Name, _ci);
            _resource.ApplyResources(barButtonItem1, barButtonItem1.Name, _ci);
            _resource.ApplyResources(bbiClose, bbiClose.Name, _ci);
            _resource.ApplyResources(layoutControlGroup3, layoutControlGroup3.Name, _ci);
            _resource.ApplyResources(layoutControlGroup4, layoutControlGroup4.Name, _ci);
            splAccNoTextEdit.Properties.Columns[0].Caption = _resource.GetString("colAccNo");
            splAccNoTextEdit.Properties.Columns[1].Caption = _resource.GetString("colAccName");
            this.Text = _resource.GetString("$this.Text");
        }

        private bool SaveDB()
        {
            return ClsSaveDB.Save(db, LogHelper.GetLogger());
        }
    }
}