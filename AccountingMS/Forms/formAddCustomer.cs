using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formAddCustomer : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        accountingEntities db = new accountingEntities();
        ClsLinQuery lq = new ClsLinQuery();
        ClsTblCurrency clsTbCurrency = new ClsTblCurrency();
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsCustomerBalanceData clsCustBalanceData;
        tblCustomer tbCustomer;
        ClsTblAccount clsTbAccount;
        ClsTblDefaultAccount clsTbDefaultAcc;

        private readonly string folderPath = @$"{ClsDrive.Path}:\B-Tech\Layout";
        private readonly UCcustomers _ucCustomers;
        private bool isNew;
        private long custAccNo;
        private int dfltCustAccNo;
        public bool CloseAfterSave { set; get; }
        public int customersId { set; get; }
        private void formAddCustomer_Load(object sender, EventArgs e)
        {
            navigationFrame1.TransitionAnimationProperties.FrameInterval = 7000;
            if (!this.isNew) InitGridLayout();
        }

        public formAddCustomer(UCcustomers ucCustomers, tblCustomer obj)
        {
            InitializeComponent();
            InitData(obj);
            InitDefaultData();
            GetResources();
            InitEvents();
            _ucCustomers = ucCustomers;

        }

        private void InitEvents()
        {
            custAccNoLookUpEdit.EditValueChanged += CustAccNoLookUpEdit_EditValueChanged;
            custCountryTextEdit.EditValueChanged += CustCountryTextEdit_EditValueChanged;
            ribbonControl1.SelectedPageChanged += RibbonControl1_SelectedPageChanged;
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
            custSalePriceTextEdit.EditValueChanged += CustSalePriceTextEdit_EditValueChanged;
            this.FormClosing += FormAddCustomer_FormClosing;
        }

        private void InitData(tblCustomer obj)
        {
            if (obj == null)
            {
                this.isNew = true;
                this.tbCustomer = new tblCustomer() { custBrnId = Session.CurBranch.brnId, custCurrency = 0, custStatus = 1 };
                new ClsTblBranch().InitBranchLookupEdit(layoutControlGroup4, tblCustomerBindingSource, nameof(tbCustomer.custBrnId));
                tblCustomerBindingSource.DataSource = this.tbCustomer;
                db.tblCustomers.Add(tblCustomerBindingSource.Current as tblCustomer);

                SetRibbonProperties();
            }
            else
            {
                this.isNew = false;
                this.tbCustomer = obj;
                this.custAccNo = obj.custAccNo;
                custCountryEnTextEdit.Text = obj.custCountryEn;
                custNameEnTextEdit.Text = obj.custNameEn;
                custCityEnTextEdit.Text = obj.custCityEn;
                custAddressEnTextEdit.Text = obj.custAddressEn;

                CommercialRegisterTextEdit.Text = this.tbCustomer.CommercialRegister;
                CommercialRegisterEnTextEdit.Text = this.tbCustomer.PostalCode;

                tblCustomerBindingSource.DataSource = this.tbCustomer;
                db.tblCustomers.Attach(tblCustomerBindingSource.Current as tblCustomer);

                InitCustomerBalanceData();
                InitEditForm();
            }
        }

        private void SetRibbonProperties()
        {
            bbiAutoAccNo.Checked = true;
            BbiAutoAccNoItemVisibility(true);

            ribbonPageGroupAutoAddAccNo.Visible = true;
            ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
        }

        private void CustSalePriceTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;
        }

        private void InitDefaultData()
        {
            lq.accNo(custAccNoLookUpEdit);
            InitCustSalePrice();
            tblCountryBindingSource.DataSource = Session.Countries;
            tblBankBindingSource.DataSource = new ClsTblBank().GetTblBankList;
            if (this.isNew)
            {
                this.clsTbAccount = new ClsTblAccount();
                this.clsTbDefaultAcc = new ClsTblDefaultAccount();
                this.clsTbCurrency.InitCurrencyLookupEdit(custCurrencyTextEdit);
                tbCustomer.custCurrency = clsTbCurrency.FirstCurrency;
            }
        }

        private void InitCustSalePrice()
        {
            custSalePriceTextEdit.Properties.DataSource = ((!MySetting.GetPrivateSetting.LangEng) ? typeof(SalePriceAr) : typeof(SalePriceEn)).ToListEnum();
            custSalePriceTextEdit.Properties.DisplayMember = "Value";
            custSalePriceTextEdit.Properties.ValueMember = "Key";
            custSalePriceTextEdit.Properties.ShowHeader = false;
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "supStatus")
                e.DisplayText = ClsSupplyStatus.GetString(Convert.ToByte(e.Value));
            else if (e.Column.FieldName == "supCurrency")
                e.DisplayText = this.clsTbCurrency.GetCurrencySignById(Convert.ToByte(e.Value));
            else if (e.Column.FieldName == colsupIsCash.FieldName)
                e.DisplayText = (Convert.ToByte(e.Value) == 1) ? "النقد" : "الآجل";
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
            e.ChildList = this.clsCustBalanceData.GetTblSupplySubListBySupId(Convert.ToInt32(gridView1.GetFocusedRowCellValue(colsupId)));
        }

        private void CustAccNoLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;

            long accNo = Convert.ToInt64(editor.GetColumnValue("accNo"));
            string name = Convert.ToString(editor.GetColumnValue("accName"));

            this.tbCustomer.custAccNo = accNo;
            this.tbCustomer.custAccName = name;
            this.tbCustomer.custName = name;
            this.tbCustomer.custCurrency = Convert.ToByte(editor.GetColumnValue("accCurrency"));

            custAccNoLookUpEdit.EditValue = accNo;
            custAccNameTextEdit.EditValue = name;
            custNameTextEdit.EditValue = name;
        }

        private void CustCountryTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null)
            {
                custCountryEnTextEdit.Text = string.Empty;
                return;
            }

            custCountryEnTextEdit.EditValue = editor?.EditValue;

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
                    ItemForcustAccNo.Visibility = LayoutVisibility.Never;
                    ItemForcustAccName.Visibility = LayoutVisibility.Never;
                    ItemForcustNo.Visibility = LayoutVisibility.Never;
                    ItemForcustCurrency.Visibility = LayoutVisibility.Always;
                    break;
                case false:
                    ItemForcustCurrency.Visibility = LayoutVisibility.Never;
                    ItemForcustAccNo.Visibility = LayoutVisibility.Always;
                    ItemForcustAccName.Visibility = LayoutVisibility.Always;
                    ItemForcustNo.Visibility = LayoutVisibility.Always;
                    break;
            }
            SetCurrentFocusedItem(checkState);
        }

        private void SetCurrentFocusedItem(bool autoAccNo)
        {
            if (!autoAccNo)
                custAccNoLookUpEdit.Focus();
            else
                custCurrencyTextEdit.Focus();
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            if (!SaveAutoAccNo()) return;
            SetCustomerObjFileds();
            SaveAccName();
            bool save = SaveDB();
            if(this.isNew&& save) 
                Session.Customers.Add(this.tbCustomer);
            else if (!this.isNew && save)
            {
                Session.GetDataCustomrtWhithBalances();
                Session.GetDataCustomers();
            }
                if (save&&_ucCustomers != null)
            {
                _ucCustomers.flyDialogMssg = ((!MySetting.GetPrivateSetting.LangEng) ? "العميل :" : "Custommer ") + custNameTextEdit.Text;
                _ucCustomers.focusedRowHandle = (!bbiAutoAccNo.Checked) ? Convert.ToInt32(custNoTextEdit.EditValue) : Convert.ToInt32(this.custAccNo % 100000);
                _ucCustomers.flyDialogIsNew = this.isNew;
                DialogResult = DialogResult.OK;
            }
            customersId = tbCustomer.id;
            if (CloseAfterSave) this.Close();
        }

        private void SaveAccName()
        {
            try
            {
                if (this.isNew) return;
                this.tbCustomer.custAccName = this.tbCustomer.custName;
                new ClsTblAccount().UpdateAccNameByAccNo(this.tbCustomer.custAccNo, this.tbCustomer.custName);
            }
            catch (Exception ex)
            {

            }

        }

        private bool SaveAutoAccNo()
        {
            if (!this.isNew || !bbiAutoAccNo.Checked) return true;
            tblCustomer Customer = tblCustomerBindingSource.Current as tblCustomer;
            if (Customer == null) return false;
            if (Customer.custBrnId == null | Customer.custBrnId == 0)
            {
                XtraMessageBox.Show("يجب تحديد الفرع الخاص بالعميل");
                return false;
            }
            this.dfltCustAccNo = Convert.ToInt32(this.clsTbAccount.GetAccountNoById(this.clsTbDefaultAcc.GetDefultAccNoId((byte)DefaultAccType.Customer, Customer.custBrnId.Value)));
            if (this.dfltCustAccNo <= 0)
            {
                XtraMessageBox.Show("يجب تحديد الحساب الافتراضي للعملاء لهذا الفرع");
                return false;
            }
            this.custAccNo = this.clsTbAccount.GetNewAccNo(dfltCustAccNo.ToString());
            return this.clsTbAccount.Add(DefaultAccType.Customer, this.custAccNo, custNameTextEdit.Text, Convert.ToByte(custCurrencyTextEdit.EditValue), 1, Customer.custBrnId.Value);
        }
        private void SetCustomerObjFileds()
        {
            this.tbCustomer.custAccNo = this.custAccNo;
            this.tbCustomer.custAccName = custNameTextEdit.Text;
            this.tbCustomer.custNo = Convert.ToInt32(this.custAccNo % 100000);
            this.tbCustomer.custNameEn = custNameEnTextEdit.Text;
            this.tbCustomer.custCountryEn = custCountryEnTextEdit.Text;
            this.tbCustomer.custCityEn = custCityEnTextEdit.Text;
            this.tbCustomer.custAddressEn = custAddressEnTextEdit.Text;
            this.tbCustomer.CommercialRegister = CommercialRegisterTextEdit.Text;
            this.tbCustomer.PostalCode = CommercialRegisterEnTextEdit.Text;
        }

        private void BbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void BbiPrint2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            List<tblSupplySub> tbSupplySubList = this.clsCustBalanceData.GetTblSupplySubListBySupId(Convert.ToInt32(gridView1.GetFocusedRowCellValue(colsupId))) as List<tblSupplySub>;
            using (ReportForm frm = new ReportForm(((ReportType)Convert.ToByte(bbiReportInvoiceType.EditValue)),
                tbSupplyMain: gridView1.GetFocusedRow() as tblSupplyMain, tbSupplySubList: tbSupplySubList))
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
                boxName = this.tbCustomer.custName,
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

            using (ReportForm frm =new ReportForm((entStatus == 2 || entStatus == 5) ? ReportType.EntryVoucher : ReportType.EntryReceipt
                , new ArrayList { entMain }, new ArrayList { entSub }))
            {
                flyDialog.WaitForm(this, 0, frm);
                frm.ShowDialog();
            }
        }

        private void InitCustomerBalanceData()
        {
            this.clsCustBalanceData = new ClsCustomerBalanceData();
            this.clsCustBalanceData.CalculateBalance(this.custAccNo);
            tblSupplyMainBindingSource.DataSource = this.clsCustBalanceData.GetCustomerInvoices(this.tbCustomer.id);
            tblEntrySubBindingSource.DataSource = this.clsCustBalanceData.GetCustomerEntries(this.custAccNo);

            textEditDtStart.EditValue = Session.CurrentYear.fyDateStart;
            textEditDtEnd.EditValue = Session.CurrentYear.fyDateEnd;

            SetCurrentBalance();
        }

        private void SetCurrentBalance()
        {
            double total = this.clsCustBalanceData.CreditPeriod - this.clsCustBalanceData.DebitPeriod;

            ClsBalanceColumnsData balanceColumnsData = new ClsBalanceColumnsData()
            {
                debit = this.clsCustBalanceData.DebitPeriod,
                credit = this.clsCustBalanceData.CreditPeriod,
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
            this.clsCustBalanceData.CalculatePeriodBalance(this.custAccNo, textEditDtStart.DateTime, textEditDtEnd.DateTime);
            SetPeriodBalance();
        }

        private void SetPeriodBalance()
        {
            double total = this.clsCustBalanceData.CreditPeriod - this.clsCustBalanceData.DebitPeriod;

            ClsBalanceColumnsData balanceColumnsData = new ClsBalanceColumnsData()
            {
                debit = this.clsCustBalanceData.DebitPeriod,
                credit = this.clsCustBalanceData.CreditPeriod,
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

        private void InitEditForm()
        {
            this.Text = $"بيانات العميل : {this.tbCustomer.custName}";
            this.ClientSize = new Size(900, 460);
            navigationFrame1.SelectedPage = navigationPageBalance;
            InitRibbon();
            DisableItems();
        }

        private void DisableItems()
        {
            ItemForcustAccNo.Enabled = false;
            ItemForcustNo.Enabled = false;
        }

        private void InitRibbon()
        {
            ribbonPageMain.Text = "بيانات العميل";
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
            gridView1.SaveLayoutToXml(this.folderPath + "\\FormCustomerGridLayoutInvoices.xml");
        }

        private void GridView3_HideCustomizationForm(object sender, EventArgs e)
        {
            gridView3.SaveLayoutToXml(this.folderPath + "\\FormCustomerGridLayoutEntries.xml");
        }

        private void FormAddCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                gridView1.SaveLayoutToXml(this.folderPath + "\\FormCustomerGridLayoutInvoices.xml");
                gridView3.SaveLayoutToXml(this.folderPath + "\\FormCustomerGridLayoutEntries.xml");
                MySetting.GetPrivateSetting.formAddCustomerH = this.Height;
                MySetting.GetPrivateSetting.formAddCustomerW = this.Width;
                MySetting.WriterSettingXml();
            }
            catch (Exception)
            {


            }
        }

        private void InitGridLayout()
        {
            try
            {
                string gridLayoutInvocies = this.folderPath + "\\FormCustomerGridLayoutInvoices.xml";
                string gridLayoutEntries = this.folderPath + "\\FormCustomerGridLayoutEntries.xml";

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
            _resource = new ComponentResourceManager(typeof(Language.formAddCustomerEn));

            foreach (LayoutControlItem item in layoutControlGroup3.Items)
            {
                _resource.ApplyResources(item, item.Name, _ci);
            }
            foreach (LayoutControlItem item in layoutControlGroup4.Items)
            {
                _resource.ApplyResources(item, item.Name, _ci);
            }

            _resource.ApplyResources(ribbonPageMain, ribbonPageMain.Name, _ci);
            _resource.ApplyResources(ribbonPageInvoices, ribbonPageInvoices.Name, _ci);
            _resource.ApplyResources(bbiClose, bbiClose.Name, _ci);
            _resource.ApplyResources(layoutControlGroup3, layoutControlGroup3.Name, _ci);
            _resource.ApplyResources(layoutControlGroup4, layoutControlGroup4.Name, _ci);
            custAccNoLookUpEdit.Properties.Columns[0].Caption = _resource.GetString("colAccNo");
            custAccNoLookUpEdit.Properties.Columns[1].Caption = _resource.GetString("colAccName");
            this.Text = _resource.GetString("this.Text");

            EnLayout();
        }

        private void EnLayout()
        {
            ItemForcustAccName.Move(ItemForcustAccNo, InsertType.Right);
            ItemForcustCellingCredit.Move(ItemForcustNo, InsertType.Right);
            ItemForcustPhnNo.Move(ItemForcustName, InsertType.Right);
            ItemForcustCity.Move(ItemForcustCountry, InsertType.Right);
            ItemForcustEmail.Move(ItemForcustAddress, InsertType.Right);

            custNoTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
        }

        private bool SaveDB()
        {
            return ClsSaveDB.Save(db, LogHelper.GetLogger());
        }

        private void bbiClose_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}