using AccountingMS.Classes;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formAddEntry : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        accountingEntities db = new accountingEntities();
        ClsTblAccount clsTbAccount;
        ClsTblCurrency clsTbCurrency;
        ClsTblCustomer clsTbCustomer;
        ClsTblSupplier clsTbSupplier;
        tblEntryMain tbEntMain;
        ClsTblEntryMain clsTbEntMain;
        FlyoutDialog flyDialogSrch;
        tblAccount tbAccount;

        private readonly UCentry _ucEntry;
        private int entNo;
        private bool isNew;
        private bool hasTax = true, isSupplier = false;
        private double taxPercent = MySetting.GetPrivateSetting.taxDefault;

        private async void FormAddEntry_Load(object sender, EventArgs e)
        {
            GetResources();
            HasTax();
            await InitDataAsync();
            InitEvents();

            gridView1.RestoreGridLayout($"{this.Name}New");
        }

        public formAddEntry(tblEntryMain obj, IEnumerable<tblEntrySub> subObj, UCentry ucEntry, ClsTblEntryMain clsTbEntMain)
        {
            Program.Localization();
            this.clsTbEntMain = clsTbEntMain;
            InitializeComponent();
            InitDefaultData();
            InitData(obj, subObj);
            _ucEntry = ucEntry;

            this.Load += FormAddEntry_Load;
        }

        private void InitEvents()
        {
            gridView1.KeyDown += GridView1_KeyDown;
            gridView1.CellValueChanging += GridView1_CellValueChanging;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
            gridView1.ShowingEditor += GridView1_ShowingEditor;
            gridView1.RowCellStyle += GridView1_RowCellStyle;
            gridView1.FocusedRowChanged += GridView1_FocusedRowChanged;

            gridViewAccount.KeyDown += GridViewAccount_KeyDown;
            gridViewAccount.DoubleClick += GridViewAccount_DoubleClick;
            gridViewAccount.CustomColumnDisplayText += GridViewAccount_CustomColumnDisplayText;

            checkEditTax.EditValueChanged += CheckEditTax_EditValueChanged;
            entDateDateEdit.EditValueChanged += EntDateDateEdit_EditValueChanged;

            repoItemLkUpEditAccNo.EditValueChanged += RepoItemLkUpEditAcc_EditValueChanged;
            repoItemLkUpEditAccName.EditValueChanged += RepoItemLkUpEditAcc_EditValueChanged;
        }

        private async Task InitDataAsync()
        {
            flyDialog.WaitForm(this, 1);

            await InitObjectsAsync();
            InitData();

            flyDialog.WaitForm(this, 0);
        }

        private async Task InitObjectsAsync()
        {
            IList<Task> taskList = new List<Task>()
            {
                Task.Run(() => this.clsTbAccount = new ClsTblAccount()),
                Task.Run(() => this.clsTbCurrency = new ClsTblCurrency()),
                Task.Run(() => this.clsTbCustomer = new ClsTblCustomer()),
                Task.Run(() => this.clsTbSupplier = new ClsTblSupplier()),
            };

            await Task.WhenAll(taskList);
        }

        private void InitData()
        {
            tblAccountBindingSource.DataSource = this.clsTbAccount.GetAccountListType2();
        }

        private void InitDefaultData()
        {
            this.hasTax = MySetting.GetPrivateSetting.entryTax;
            checkEditTax.Checked = this.hasTax;
        }


        private void InitData(tblEntryMain obj, IEnumerable<tblEntrySub> subObj)
        {
            if (obj == null)
            {
                this.isNew = true;
                InitTbEntMainObj();
                tblEntryMainsBindingSource.DataSource = this.tbEntMain;
                db.tblEntryMains.Add(tblEntryMainsBindingSource.Current as tblEntryMain);
            }
            else
            {
                this.isNew = false;
                this.entNo = obj.entNo;
                this.hasTax = (obj.entTotalTax > 0) ? true : false;
                this.tbEntMain = obj;

                tblEntryMainsBindingSource.DataSource = this.tbEntMain;
                db.tblEntryMains.Attach(tblEntryMainsBindingSource.Current as tblEntryMain);

                tblEntrySubBindingSource.DataSource = subObj;
                foreach (var tbEntSub in subObj)
                    db.tblEntrySubs.Attach(tbEntSub);

                checkEditTax.Checked = this.hasTax;
                gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            }
        }

        private void InitTbEntMainObj()
        {
            this.tbEntMain = new tblEntryMain()
            {
                entNo = this.clsTbEntMain.GetNewEntNo(),
                entDate = DateTime.Now,
                entBrnId = Session.CurBranch.brnId,
                entUserId = Session.CurrentUser.id,
                entBoxNo = 0,
                entStatus = 1
            };
        }

        private void EntDateDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            DateEdit editor = sender as DateEdit;
            if (editor?.EditValue == null) return;

            for (short i = 0; i < gridView1.DataRowCount; i++)
                if (Convert.ToInt32(gridView1.GetRowCellValue(i, colentId)) != 0)
                    gridView1.SetRowCellValue(i, colentDate, editor.DateTime.Date);
        }

        private void CheckEditTax_EditValueChanged(object sender, EventArgs e)
        {
            this.hasTax = checkEditTax.Checked;
            HasTax();
            SaveTaxSettings();
        }


        private void SaveTaxSettings()
        {
            MySetting.GetPrivateSetting.entryTax = checkEditTax.Checked;
            MySetting.WriterSettingXml();
        }

        private void GridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) DeleteRow();
        }

        private void DeleteRow()
        {
            var tbEntrySub = gridView1.GetFocusedRow() as tblEntrySub;
            if (!this.isNew && tbEntrySub?.id != 0) db.Entry(tbEntrySub).State = System.Data.Entity.EntityState.Deleted;

            gridView1.DeleteSelectedRows();

            GetTotalAmounts(-1, out decimal debit, out decimal credit);
            CalculateRemaining(debit, credit);
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "entCurrency")
                e.DisplayText = this.clsTbCurrency.GetCurrencyNameById(Convert.ToByte(e.Value));
        }

        private void GridViewAccount_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == colaccCurrency.FieldName)
                e.DisplayText = this.clsTbCurrency.GetCurrencyNameById(Convert.ToByte(e.Value));
        }

        private void GridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (gridView1.FocusedColumn == colentDebit)
                e.Cancel = CheckColumnValue(colentCredit, gridView1.FocusedRowHandle);
            else if (gridView1.FocusedColumn == colentCredit)
                e.Cancel = CheckColumnValue(colentDebit, gridView1.FocusedRowHandle);
            else if (gridView1.FocusedColumn == colentDebitFrgn)
                e.Cancel = CheckColumnValue(colentCreditFrgn, gridView1.FocusedRowHandle);
            else if (gridView1.FocusedColumn == colentCreditFrgn)
                e.Cancel = CheckColumnValue(colentDebitFrgn, gridView1.FocusedRowHandle);
        }

        private void GridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == colentDebit.FieldName && CheckColumnValue(colentCredit, e.RowHandle))
                e.Appearance.BackColor = Color.Red;
            else if (e.Column.FieldName == colentCredit.FieldName && CheckColumnValue(colentDebit, e.RowHandle))
                e.Appearance.BackColor = Color.Red;
            else if (e.Column.FieldName == colentDebitFrgn.FieldName && CheckColumnValue(colentCreditFrgn, e.RowHandle))
                e.Appearance.BackColor = Color.Red;
            else if (e.Column.FieldName == colentCreditFrgn.FieldName && CheckColumnValue(colentDebitFrgn, e.RowHandle))
                e.Appearance.BackColor = Color.Red;
        }

        private bool CheckColumnValue(GridColumn column, int focusedRowHandle)
        {
            return (gridView1.GetRowCellValue(focusedRowHandle, column) != null) ? true : false;
        }

        private void GridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            InitCurrencyProperties();
        }

        private void RepoItemLkUpEditAcc_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;

            var tbAccount = editor.GetSelectedDataRow() as tblAccount;
            if (tbAccount == null) return;

            gridView1.SetFocusedRowCellValue(colentAccNo, tbAccount?.accNo);
            gridView1.SetFocusedRowCellValue(colentAccName, tbAccount?.accName);
            gridView1.SetFocusedRowCellValue(colentCurrncy, tbAccount?.accCurrency);

            InitCurrencyProperties();
            ClearSupplierData();
        }

        private void InitCurrencyProperties()
        {
            byte currencyId = Convert.ToByte(gridView1.GetFocusedRowCellValue(colentCurrncy));

            SetCurrencyChng(currencyId);
            SetCurrencyColumnsProperties(currencyId);
        }

        private void SetCurrencyChng(byte currencyId)
        {
            if (currencyId <= 1)
            {
                gridView1.SetFocusedRowCellValue(colentCurChange, null);
                return;
            }

            short currencyChng = Convert.ToInt16(gridView1.GetFocusedRowCellValue(colentCurChange));
            if (currencyChng > 0) return;

            currencyChng = this.clsTbCurrency.GetCurrencyChangeById(currencyId);
            gridView1.SetFocusedRowCellValue(colentCurChange, currencyChng);
        }

        private void SetCurrencyColumnsProperties(byte currencyId)
        {
            colentCurChange.OptionsColumn.TabStop = currencyId > 1;
            colentCurChange.OptionsColumn.AllowEdit = currencyId > 1;

            colentDebitFrgn.OptionsColumn.TabStop = currencyId > 1;
            colentDebitFrgn.OptionsColumn.AllowEdit = currencyId > 1;

            colentCreditFrgn.OptionsColumn.TabStop = currencyId > 1;
            colentCreditFrgn.OptionsColumn.AllowEdit = currencyId > 1;
        }

        private void GridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            byte currency = Convert.ToByte(gridView1.GetFocusedRowCellValue(colentCurrncy));

            if (e.Column.FieldName == "entDebit")
            {
                if (String.IsNullOrEmpty(e.Value.ToString())) return;
                SetTaxAmount(Convert.ToDouble(e.Value));

                GetTotalAmounts(e.RowHandle, out decimal debit, out decimal credit);
                debit += Convert.ToDecimal(e.Value);
                CalculateRemaining(debit, credit);

                if (currency > 1)
                {
                    double forignAmount = Convert.ToDouble(e.Value) / Convert.ToDouble(gridView1.GetFocusedRowCellValue(colentCurChange));
                    gridView1.SetFocusedRowCellValue(colentDebitFrgn, forignAmount);
                    SetTaxAmount(forignAmount);
                }
            }
            else if (e.Column.FieldName == "entCredit")
            {
                if (String.IsNullOrEmpty(e.Value.ToString())) return;
                SetTaxAmount(Convert.ToDouble(e.Value));

                GetTotalAmounts(e.RowHandle, out decimal debit, out decimal credit);
                credit += Convert.ToDecimal(e.Value);
                CalculateRemaining(debit, credit);

                if (currency > 1)
                {
                    double forignAmount = Convert.ToDouble(e.Value) / Convert.ToInt16(gridView1.GetFocusedRowCellValue(colentCurChange));
                    gridView1.SetFocusedRowCellValue(colentCreditFrgn, forignAmount);
                    SetTaxAmount(forignAmount);
                }
            }
            else if (e.Column.FieldName == "entDebitFrgn")
            {
                if (String.IsNullOrEmpty(e.Value.ToString())) return;
                SetTaxAmount(Convert.ToDouble(e.Value));
                if (currency > 1)
                    gridView1.SetFocusedRowCellValue(colentDebit, Convert.ToDouble(e.Value) * Convert.ToInt16(gridView1.GetFocusedRowCellValue(colentCurChange)));
            }
            else if (e.Column.FieldName == "entCreditFrgn")
            {
                if (String.IsNullOrEmpty(e.Value.ToString())) return;
                SetTaxAmount(Convert.ToDouble(e.Value));
                if (currency > 1)
                    gridView1.SetFocusedRowCellValue(colentCredit, Convert.ToDouble(e.Value) * Convert.ToInt16(gridView1.GetFocusedRowCellValue(colentCurChange)));
            }
        }

        private void GetTotalAmounts(int rowHandle, out decimal debit, out decimal credit)
        {
            debit = 0;
            credit = 0;

            for (short i = 0; i < gridView1.DataRowCount; i++)
            {
                if (i == rowHandle) continue;

                debit += Convert.ToDecimal(gridView1.GetRowCellValue(i, colentDebit));
                credit += Convert.ToDecimal(gridView1.GetRowCellValue(i, colentCredit));
            }
        }

        private void CalculateRemaining(decimal debit, decimal credit)
        {
            labelRemaining.Text = MySetting.GetPrivateSetting.LangEng ? "Remaining: " : "المتبقي: ";

            if (debit > credit)
                labelRemaining.Text += MySetting.GetPrivateSetting.LangEng ? $"{debit - credit} Debit" : $"{debit - credit} دائن";
            else if (credit > debit)
                labelRemaining.Text += MySetting.GetPrivateSetting.LangEng ? $"{credit - debit} Credit" : $"{credit - debit} مدين";
            else
                labelRemaining.Text += "0";
        }

        private void SetTaxAmount(double amount)
        {
            if (!this.hasTax || this.taxPercent == 0) return;

            gridView1.SetFocusedRowCellValue(colentTaxPercent, this.taxPercent);
            gridView1.SetFocusedRowCellValue(colentTaxPrice, amount * (this.taxPercent / 100));
        }

        private double GetTotalTax()
        {
            if (!this.hasTax) return 0;
            double totalTax = 0;

            for (short i = 0; i <= gridView1.DataRowCount; i++)
                totalTax += Convert.ToDouble(gridView1.GetRowCellValue(i, colentTaxPrice));

            return totalTax;
        }

        private void SaveEntrySubData()
        {
            for (short i = 0; i < gridView1.DataRowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, colentAccNo) == null) continue;
                tblEntrySub entSub = new tblEntrySub();
                entSub = gridView1.GetRow(i) as tblEntrySub;
                if (entSub == null) return;
                if (entSub?.id != 0) continue;

                entSub.entNo = Convert.ToInt32(entNoTextEdit.EditValue);
                entSub.entDate = entDateDateEdit.DateTime;
                entSub.entBrnId = Session.CurBranch.brnId;
                entSub.entBoxNo = 0;
                entSub.entView = 0;
                entSub.entIsMain = 2;
                entSub.entEqfal = 1;
                entSub.entStatus = 1;
                entSub.entDesc = entDescTextEdit.Text + " - " + entSub.entDesc;
                db.tblEntrySubs.Add(entSub);
            }
        }

        private bool ValidateAmount()
        {
            decimal eAmount = Convert.ToDecimal(entAmountTextEdit.EditValue);
            var entry=tblEntrySubBindingSource.List as IList<tblEntrySub>;
            if (entry.Count <= 0) return false;
            decimal debit = Convert.ToDecimal(entry.Sum(x => x.entDebit??0));
            decimal credit = Convert.ToDecimal(entry.Sum(x => x.entCredit??0));
            if (eAmount != debit || eAmount != credit)
            {
                XtraMessageBox.Show(_resource.GetString("validateAmountMssg"));
                return false;
            }
            return true;
        }

        private void entNoTextEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            for (short i = 0; i < gridView1.DataRowCount; i++)
                gridView1.SetRowCellValue(i, colentNo, e.NewValue);
        }

        private void barButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetGridFocusedColumn();
            gridView1.UpdateCurrentRow();

            if (!dxValidationProvider1.Validate()) return;
            if (!ValidateAmount()) return;
            if (ValidateEntNo()) return;

            this.tbEntMain.entTotalTax = GetTotalTax();
            int entNo = Convert.ToInt32(entNoTextEdit.EditValue);

            SaveEntrySubData();

            if (SaveDB())
            {
                _ucEntry.RefreshListDialog(string.Format(_resource.GetString("entSuccessMssg"), entNo), this.isNew);
                this.Close();
                _ucEntry.SetFoucesdRow(entNo);
            }
        }

        private void barButtonItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bbiSrchCustomers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InitCustomerData();
        }

        private void bbiSrchSuppliers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InitSupplierData();
        }

        private void GridViewAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) InitAccountSrchData();
        }

        private void GridViewAccount_DoubleClick(object sender, EventArgs e)
        {
            InitAccountSrchData();
        }

        private void InitCustomerData()
        {
            this.isSupplier = false;
            this.flyDialogSrch = ClsFlyoutDialog.InitFlyoutDialog(this, gridControlAccount, "بحث العملاء");

            tblAccountSrchBindingSource.DataSource = this.clsTbCustomer.GetCustomersList().Select(x => new tblAccount()
            {
                accNo = x.custAccNo,
                accName = x.custAccName,
                accCurrency = x.custCurrency
            }).ToList();

            this.flyDialogSrch.ShowDialog();
        }

        private void InitSupplierData()
        {
            this.isSupplier = true;
            this.flyDialogSrch = ClsFlyoutDialog.InitFlyoutDialog(this, gridControlAccount, "بحث الموردين");

            tblAccountSrchBindingSource.DataSource = this.clsTbSupplier.GetSuppliersList().Select(x => new tblAccount()
            {
                accNo = x.splAccNo,
                accName = x.splName,
                accCurrency = x.splCurrency
            }).ToList();

            this.flyDialogSrch.ShowDialog();
        }

        private void InitAccountSrchData()
        {
            this.tbAccount = gridViewAccount.GetFocusedRow() as tblAccount;
            this.flyDialogSrch.Close();

            if (gridView1.FocusedRowHandle < 0) gridView1.AddNewRow();

            SetFocusedRowData(gridView1.FocusedRowHandle);
            SetSupplierData();
        }

        private void SetSupplierData()
        {
            if (!this.isSupplier)
            {
                ClearSupplierData();
                return;
            }

            long accNo = Convert.ToInt64(gridView1.GetFocusedRowCellValue(colentAccNo));
            var tbSupplier = this.clsTbSupplier.GetSupplierObjByAccNo(accNo);

            gridView1.SetFocusedRowCellValue(colentCusName, tbSupplier?.splName);
            gridView1.SetFocusedRowCellValue(colentTaxNumber, tbSupplier?.splTaxNo);

            this.isSupplier = false;
        }

        private void ClearSupplierData()
        {
            gridView1.SetFocusedRowCellValue(colentCusName, null);
            gridView1.SetFocusedRowCellValue(colentTaxNumber, null);
        }

        private void SetFocusedRowData(int rowHandle)
        {
            gridView1.SetRowCellValue(rowHandle, colentAccNo, this.tbAccount?.accNo);
            gridView1.SetRowCellValue(rowHandle, colentAccName, this.tbAccount?.accName);
            gridView1.SetRowCellValue(rowHandle, colentCurrncy, this.tbAccount?.accCurrency);
            gridView1.UpdateCurrentRow();
        }

        private void formAddEntry_Activated(object sender, EventArgs e)
        {
            if (!this.isNew)
            {
                checkEditTax.Checked = this.hasTax;
                HasTax();
            }
        }

        private bool ValidateEntNo()
        {
            bool isEntNoFound = false;
            int entNo = Convert.ToInt32(entNoTextEdit.EditValue);

            if (this.isNew && this.clsTbEntMain.IsEntryNoFound(entNo))
                isEntNoFound = true;
            else if (!this.isNew && entNo != this.entNo && this.clsTbEntMain.IsEntryNoFound(entNo))
                isEntNoFound = true;

            if (isEntNoFound)
            {
                XtraMessageBox.Show(string.Format(_resource.GetString("entErrorMssg"), entNo));
                entNoTextEdit.Focus();
            }
            return isEntNoFound;
        }

        private void SetGridFocusedColumn()
        {
            if (gridView1.FocusedColumn == colentDesc)
                gridView1.FocusedColumn = colentNo;
            else
                gridView1.FocusedColumn = colentDesc;
        }

        private void HasTax()
        {
            bool hasTax = checkEditTax.Checked;
            switch (hasTax)
            {
                case true:
                    colentTaxPercent.Visible = true;
                    colentTaxPrice.Visible = true;
                    colentTaxPercent.VisibleIndex = 10;
                    colentTaxPrice.VisibleIndex = 11;
                    colentDesc.VisibleIndex = 12;
                    break;
                case false:
                    colentTaxPercent.Visible = false;
                    colentTaxPrice.Visible = false;
                    ClearTaxRow();
                    break;
            }
        }

        private void ClearTaxRow()
        {
            for (short i = 0; i < gridView1.DataRowCount; i++)
            {
                gridView1.SetRowCellValue(i, colentTaxPercent, null);
                gridView1.SetRowCellValue(i, colentTaxPrice, null);
            }
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
                _resource = new ComponentResourceManager(typeof(formAddEntry));
            }

            if (MySetting.GetPrivateSetting.LangEng) EnglishTranslation();
        }

        private void EnglishTranslation()
        {
            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = false;

            foreach (LayoutControlItem item in layoutControlGroup4.Items)
            {
                _resource.ApplyResources(item, item.Name, _ci);
            }
            foreach (GridColumn col in gridView1.Columns)
            {
                _resource.ApplyResources(col, col.Name, _ci);
            }

            _resource.ApplyResources(ribbonPage1, ribbonPage1.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup1, ribbonPageGroup1.Name, _ci);
            _resource.ApplyResources(barButtonItemSave, barButtonItemSave.Name, _ci);
            _resource.ApplyResources(barButtonItemClose, barButtonItemClose.Name, _ci);
            _resource.ApplyResources(layoutControlGroup4, layoutControlGroup4.Name, _ci);

            checkEditTax.Properties.Caption = _resource.GetString("checkEditTax.Properties.Caption");

            this.Text = _resource.GetString("$this.Text");

            EnglishLayout();
        }

        private void EnglishLayout()
        {
            ItemForentDate.Move(ItemForentNo, InsertType.Right);
            ItemForentAmount.Move(ItemForentRefNo, InsertType.Right);
        }

        private bool SaveDB()
        {
            return ClsSaveDB.Save(db, LogHelper.GetLogger());
        }

        private void formAddEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            gridView1.SaveGridLayout($"{this.Name}New");
        }
    }
}