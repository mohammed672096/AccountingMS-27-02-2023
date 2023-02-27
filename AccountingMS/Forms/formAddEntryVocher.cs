using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formAddEntryVocher : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        accountingEntities db = new accountingEntities();
        ClsTblBox clsTbBox = new ClsTblBox();
        ClsTblAccount clsTbAccount = new ClsTblAccount();
        ClsTblCurrency clsTbCurrency = new ClsTblCurrency();
        ClsTblCustomer clsTbCustomer = new ClsTblCustomer();
        tblEntryMain tbEntMain;
        ClsTblEntryMain clsTbEntMain;
        ClsTblEntrySub clsTbEntSub;

        private readonly UCentryVocher _ucEntryVocher;
        private int entNo, entNoOld;
        private Int64 boxAccNo;
        private bool isNew;
        private byte currency;
        private byte currencyGrid;
        private byte view;
        private bool hasTax = true;
        private double taxPercent = MySetting.GetPrivateSetting.taxDefault;

        private void formAddEntVocher_Load(object sender, EventArgs e)
        {
            GetResources();
            gridView1.Columns["entAccNo"].ColumnEdit = repositoryItemLookUpEdit1;
            gridView1.Columns["entCusNo"].ColumnEdit = repositoryItemLookUpEdit2;
            gridView1.Columns["entAccName"].ColumnEdit = repositoryItemLookUpEdit3;
            gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemLookUpEdit1, repositoryItemLookUpEdit2, repositoryItemLookUpEdit3 });
            HasTax();
        }

        public formAddEntryVocher(tblEntryMain obj, IEnumerable<tblEntrySub> subObj, UCentryVocher ucEntryVoher, ClsTblEntryMain clsTbEntMain, ClsTblEntrySub clsTbEntSub = null)
        {
            Program.Localization();
            this.clsTbEntMain = clsTbEntMain;
            this.clsTbEntSub = clsTbEntSub;
            InitializeComponent();
            InitDefaultData();
            InitData(obj, subObj);
            _ucEntryVocher = ucEntryVoher;

            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
            gridView1.FocusedColumnChanged += GridView1_FocusedColumnChanged;
            gridView1.CellValueChanging += GridView1_CellValueChanging;
            gridView1.CellValueChanged += GridView1_CellValueChanged; ;

            repositoryItemLookUpEdit1.EditValueChanged += RepositoryItemLookUpEdit_EditValueChanged;
            repositoryItemLookUpEdit3.EditValueChanged += RepositoryItemLookUpEdit_EditValueChanged;
            repositoryItemLookUpEdit2.EditValueChanged += RepositoryItemLookUpEdit_EditValueChanged;
            checkEdit1.CheckedChanged += CheckEdit1_CheckedChanged;
            checkEditTax.CheckedChanged += CheckEditTax_CheckedChanged;
            entDateTextEdit.EditValueChanged += EntDateTextEdit_EditValueChanged;

            lkp_PayType.EditValueChanged += Lkp_PayType_EditValueChanged;
            lkp_PayType.Properties.DataSource = new[]
                         {
                      new { ID = 1 ,Name =MySetting.GetPrivateSetting.LangEng?"Box": "الصندوق"},
                      new { ID = 2 ,Name =MySetting.GetPrivateSetting.LangEng?"Bank":"البنك"  },
                      new { ID = 3 ,Name =MySetting.GetPrivateSetting.LangEng?"On Account":"الحساب"  },

                    };
            if (isNew)
                lkp_PayType.EditValue = 1;
            lkp_PayType.Properties.ValueMember = "ID";
            lkp_PayType.Properties.DisplayMember = "Name";
        }

        private void Lkp_PayType_EditValueChanged(object sender, EventArgs e)
        {
            try

            {
                int BrnId = Session.CurBranch.brnId;

                var drawers = db.tblAccountBoxes.Where(x => x.boxBrnId == BrnId).Select(x => new { ID = x.boxAccNo, Name = x.boxName, No = x.boxNo, Currency = x.boxCurrency });
                var banks = db.tblAccountBanks.Where(x => x.bankBrnId == BrnId).Select(x => new { ID = x.bankAccNo, Name = x.bankName, No = x.bankNo, Currency = x.bankCurrency });
                var accounts = db.tblAccounts.Where(x => db.tblAccounts.Where(a => x.accParent == x.id).Count() == 0 && x.accBrnId == BrnId).Select(x => new { ID = x.accNo, Name = x.accName, No = x.id, Currency = x.accCurrency });

                int payType = -1;
                if (int.TryParse(lkp_PayType.EditValue?.ToString(), out payType))
                    switch (payType)
                    {
                        case 1:
                            entBoxNoLookUpEdit.Properties.DataSource = drawers.ToList();
                            break;
                        case 2:
                            entBoxNoLookUpEdit.Properties.DataSource = banks.ToList();
                            break;
                        case 3:
                            entBoxNoLookUpEdit.Properties.DataSource = accounts.ToList();
                            break;
                        case 4:
                            //  lkp_PayAccount.Properties.DataSource = paycards.ToList();
                            break;
                        default:
                            entBoxNoLookUpEdit.Properties.DataSource = null;
                            return;
                    }
                entBoxNoLookUpEdit.Properties.DisplayMember = "Name";
                entBoxNoLookUpEdit.Properties.ValueMember = "ID";
                entBoxNoLookUpEdit.Properties.PopulateColumns();
                if (entBoxNoLookUpEdit.Properties.Columns?.FirstOrDefault(x => x.FieldName == "ID") != null)
                    entBoxNoLookUpEdit.Properties.Columns.Where(x => x.FieldName == "ID").FirstOrDefault().Visible = false;
                if (entBoxNoLookUpEdit.Properties.Columns?.FirstOrDefault(x => x.FieldName == "No") != null)
                    entBoxNoLookUpEdit.Properties.Columns.Where(x => x.FieldName == "No").FirstOrDefault().Visible = false;
                if (entBoxNoLookUpEdit.Properties.Columns?.FirstOrDefault(x => x.FieldName == "Currency") != null)
                    entBoxNoLookUpEdit.Properties.Columns.Where(x => x.FieldName == "Currency").FirstOrDefault().Visible = false;
                //entBoxNoLookUpEdit.Properties.Columns["ID"].Visible = false;
                //entBoxNoLookUpEdit.Properties.Columns["No"].Visible = false;
                //entBoxNoLookUpEdit.Properties.Columns["Currency"].Visible = false;
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
        void SelectPayType(int acc)
        {
            int BrnId = Session.CurBranch.brnId;
            var drawers = db.tblAccountBoxes.Where(x => x.boxBrnId == BrnId).Select(x => x.boxAccNo).ToList();
            var banks = db.tblAccountBanks.Where(x => x.bankBrnId == BrnId).Select(x => x.bankAccNo).ToList();
            var accounts = db.tblAccounts.Where(x => db.tblAccounts.Where(a => x.accParent == x.id).Count() == 0 && x.accBrnId == BrnId).Select(x => x.accNo).ToList();

            if (drawers.Contains(acc))
                lkp_PayType.EditValue = 1;
            else if (banks.Contains(acc))
                lkp_PayType.EditValue = 2;
            else lkp_PayType.EditValue = 3;

            Lkp_PayType_EditValueChanged(null, null);
            //lkp_PayType.Enabled = false;
        }
        private void EntBoxNoLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;
            try
            {
                // ID = x.boxAccNo, Name = x.boxName, No = x.boxNo, Currency = x.boxCurrency
                this.boxAccNo = Convert.ToInt64(editor.GetColumnValue("ID"));
                this.currency = Convert.ToByte(editor.GetColumnValue("Currency"));
                this.entNo = this.clsTbEntMain.GetNewEntNoByBoxNo(Convert.ToInt32(editor.GetColumnValue("No")));

                this.tbEntMain.entNo = this.entNo;
                this.tbEntMain.entBoxNo = Convert.ToInt32(editor.GetColumnValue("ID"));
                this.tbEntMain.entCurrency = this.currency;
                if (currency != 1)
                {
                    short currencyChng = this.clsTbCurrency.GetCurrencyChangeById(this.currency);
                    this.tbEntMain.entCurChange = currencyChng;
                    entCurrencyChngTextEdit.EditValue = currencyChng;
                    ItemForentCurrencyChng.Visibility = LayoutVisibility.Always;
                }
                else
                {
                    this.tbEntMain.entCurChange = null;
                    entCurrencyChngTextEdit.EditValue = null;
                    ItemForentCurrencyChng.Visibility = LayoutVisibility.Never;
                }
                entCurrTextEdit.Text = this.clsTbCurrency.GetCurrencyNameById(this.currency);
                SetRepositoryItemDataSource(Convert.ToInt64(editor.GetColumnValue("ID")));
            }
            catch { }
        }

        private void InitDefaultData()
        {
            this.clsTbAccount.InitAccountRepositoryLookupEdit(repositoryItemLookUpEdit1, "accNo", "accNo");
            this.clsTbAccount.InitAccountRepositoryLookupEdit(repositoryItemLookUpEdit3, "accName", "accName");
            this.clsTbCustomer.InitCustomerRepositoryLookupEdit(repositoryItemLookUpEdit2, "custAccNo");
            this.hasTax = MySetting.GetPrivateSetting.entryVoucherTax;
            checkEditTax.Checked = this.hasTax;
        }
        private void GridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            // string[] FieldNames = { colentAccNo.FieldName};
            // if (e.Column.FieldName == colentAccNo.FieldName || e.Column.FieldName == colentAccName.FieldName || e.Column.FieldName == colentCusName.FieldName)
            if (e.Column.FieldName == colentAccNo.FieldName)
            {
                int custAccNo = 0;
                if (int.TryParse(gridView1.GetFocusedRowCellValue(colentAccNo)?.ToString(), out custAccNo))
                {
                    var AccountBalance = new ClsTblAccount.AccountBalance(custAccNo);
                    var Focused = gridView1.GetFocusedRow() as tblEntrySub;
                    if (Focused != null)
                        Focused.AccountBalance = AccountBalance;
                    if (this.currencyGrid > 1)
                        gridView1.SetFocusedRowCellValue(colentCurChange, entCurrencyChngTextEdit.EditValue);
                }
            }
        }

        private void InitData(tblEntryMain obj, IEnumerable<tblEntrySub> subObj)
        {
            if (obj == null)
            {
                this.isNew = true;
                this.view = 1;
                InitTbEntMainObj();

                tblEntryMainsBindingSource.DataSource = this.tbEntMain;
                db.tblEntryMains.Add(tblEntryMainsBindingSource.Current as tblEntryMain);

                entBoxNoLookUpEdit.EditValueChanged += EntBoxNoLookUpEdit_EditValueChanged;
            }
            else
            {
                SelectPayType(obj.entBoxNo.Value);
                this.isNew = false;
                this.entNo = obj.entNo;
                this.entNoOld = obj.entNo;
                this.currency = Convert.ToByte(obj.entCurrency);
                this.view = Convert.ToByte(subObj.FirstOrDefault()?.entView ?? 1);
                this.hasTax = (obj.entTotalTax > 0) ? true : false;
                this.tbEntMain = obj;

                tblEntryMainsBindingSource.DataSource = this.tbEntMain;
                db.tblEntryMains.Attach(tblEntryMainsBindingSource.Current as tblEntryMain);

                tblEntrySubBindingSource.DataSource = subObj;
                foreach (var tbEntSub in subObj)
                    db.tblEntrySubs.Attach(tbEntSub);

                entCurrTextEdit.EditValue = this.clsTbCurrency.GetCurrencyNameById(this.currency);
                checkEditTax.Checked = this.hasTax;
                checkEditTax.Enabled = false;

                ItemForentCurrencyChng.Visibility = (this.currency > 1) ? LayoutVisibility.Always : LayoutVisibility.Never;
                checkEdit1.Checked = (this.view == 2) ? true : false;

                //ItemForentBoxNo.Enabled = false;
                //gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            }
        }

        private void InitTbEntMainObj()
        {
            this.tbEntMain = new tblEntryMain()
            {
                entNo=clsTbEntMain.GetNewEntNo(),
                entDate = DateTime.Now,
                entBrnId = Session.CurBranch.brnId,
                entUserId = Session.CurrentUser.id,
                entStatus = 2
            };
        }

        private void EntDateTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            DateEdit editor = sender as DateEdit;
            if (editor?.EditValue == null) return;

            for (short i = 0; i < gridView1.DataRowCount; i++)
                if (Convert.ToInt32(gridView1.GetRowCellValue(i, colentId)) != 0)
                    gridView1.SetRowCellValue(i, colentDate, editor.DateTime.Date);
        }
        private void RepositoryItemLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            GridLookUpEdit editor = sender as GridLookUpEdit;
            if (editor?.EditValue == null) return;

            long AccNo = 0;

            if (editor.GetSelectedDataRow() is AccountingMS.tblCustomer customerRow)
            {
                if (customerRow == null) return;
                this.currencyGrid = Convert.ToByte(customerRow.custCurrency);
                AccNo = customerRow.custAccNo;
            }
            else if (editor.GetSelectedDataRow() is AccountingMS.ClsTblAccount.AccountTemp AccountRow)
            {
                if (AccountRow == null) return;
                this.currencyGrid = Convert.ToByte(AccountRow.accCurrency);
                AccNo = AccountRow.accNo;
            }
            gridView1.SetFocusedRowCellValue(colentAccNo, AccNo);
            gridView1.SetFocusedRowCellValue(colentAccName, this.clsTbAccount.GetAccountNameByNo(AccNo));
            gridView1.SetFocusedRowCellValue(colentCurrency, this.currencyGrid);
            if (this.currencyGrid > 1)
                gridView1.SetFocusedRowCellValue(colentCurChange, entCurrencyChngTextEdit.EditValue);

            string custName = clsTbCustomer.GetCustomerNameByAccNo(AccNo);
            long? longNull = null;
            gridView1.SetFocusedRowCellValue(colentCusNo, !string.IsNullOrWhiteSpace(custName) ? AccNo : longNull);
            gridView1.SetFocusedRowCellValue(colentCusName, !string.IsNullOrWhiteSpace(custName) ? custName : null);
        }

        private void RepositoryItemLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            GridLookUpEdit editor = sender as GridLookUpEdit;
            if (editor?.EditValue == null) return;
            var row = editor.GetSelectedDataRow() as AccountingMS.ClsTblAccount.AccountTemp;
            if (row == null) return;
            this.currencyGrid = Convert.ToByte(row.accCurrency);
            gridView1.SetFocusedRowCellValue(colentAccNo, row.entAccNo);
            gridView1.SetFocusedRowCellValue(colentAccName, row.entAccName);
            gridView1.SetFocusedRowCellValue(colentCurrency, this.currencyGrid);

            if (this.currencyGrid > 1)
                gridView1.SetFocusedRowCellValue(colentCurChange, entCurrencyChngTextEdit.EditValue);
        }

        private void RepositoryItemLookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            GridLookUpEdit editor = sender as GridLookUpEdit;
            if (editor?.EditValue == null) return;
            var row = editor.GetSelectedDataRow() as AccountingMS.tblCustomer;
            if (row == null) return;

            this.currencyGrid = Convert.ToByte(row.custCurrency);
            gridView1.SetFocusedRowCellValue(colentCusName, row.custName);
            gridView1.SetFocusedRowCellValue(colentAccNo, row.custAccNo);
            gridView1.SetFocusedRowCellValue(colentAccName, row.custAccName);
            gridView1.SetFocusedRowCellValue(colentCurrency, this.currencyGrid);
            if (this.currencyGrid > 1)
                gridView1.SetFocusedRowCellValue(colentCurChange, entCurrencyChngTextEdit.EditValue);
        }



        private void CheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
                this.view = 2;
            else
                this.view = 1;
        }

        private void CheckEditTax_CheckedChanged(object sender, EventArgs e)
        {
            this.hasTax = checkEditTax.Checked;
            HasTax();
            SaveTaxSettings();
        }

        private void SaveTaxSettings()
        {
            MySetting.GetPrivateSetting.entryVoucherTax = checkEditTax.Checked;
            MySetting.WriterSettingXml();
        }

        private void HasTax()
        {
            bool hasTax = checkEditTax.Checked;
            colentTaxPercent.Visible = hasTax;
            colentTaxPrice.Visible = hasTax;

            if (hasTax)
            {
                colentTaxPercent.VisibleIndex = 7;
                colentTaxPrice.VisibleIndex = 8;
            }
            else ClearTaxRow();
        }

        private void ClearTaxRow()
        {
            for (short i = 0; i < gridView1.DataRowCount; i++)
            {
                gridView1.SetRowCellValue(i, colentTaxPercent, null);
                gridView1.SetRowCellValue(i, colentTaxPrice, null);
            }
        }

        private void SetTaxAmount(double amount)
        {
            if (!this.hasTax || this.taxPercent == 0) return;

            gridView1.SetFocusedRowCellValue(colentTaxPercent, this.taxPercent);
            gridView1.SetFocusedRowCellValue(colentTaxPrice, amount * (this.taxPercent / 100));
        }

        private void GridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            byte currency = Convert.ToByte(gridView1.GetFocusedRowCellValue(colentCurrency));
            double val;
            if (e.Column.FieldName == "entDebit")
            {
                if (String.IsNullOrEmpty(e.Value.ToString()) || !double.TryParse(e.Value.ToString(), out val)) return;
                SetTaxAmount(Convert.ToDouble(e.Value));
                if (currency > 1)
                {
                    double forignAmount = Convert.ToDouble(e.Value) / Convert.ToDouble(gridView1.GetFocusedRowCellValue(colentCurChange));
                    gridView1.SetFocusedRowCellValue(colentDebitFrgn, forignAmount);
                    SetTaxAmount(forignAmount);
                }
            }
            else if (e.Column.FieldName == "entDebitFrgn")
            {
                if (String.IsNullOrEmpty(e.Value.ToString()) || !double.TryParse(e.Value.ToString(), out val)) return;
                SetTaxAmount(Convert.ToDouble(e.Value));
                if (currency > 1)
                    gridView1.SetFocusedRowCellValue(colentDebit, Convert.ToDouble(e.Value) * Convert.ToInt16(gridView1.GetFocusedRowCellValue(colentCurChange)));
            }
        }
      
        private void GridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn == colentAccNo || e.FocusedColumn == colentAccName || e.FocusedColumn == colentCusNo)
                CurrencyGrid();
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "entCurrency")
                e.DisplayText = this.clsTbCurrency.GetCurrencyNameById(Convert.ToByte(e.Value));
        }


        private void SetRepositoryItemDataSource(long accNo)
        {
            //var tbAccountList = this.clsTbAccount.GetAccountListType2WhereAccNoNotEqualTo(accNo);
            //repositoryItemLookUpEdit1.DataSource = tbAccountList;
            //repositoryItemLookUpEdit3.DataSource = tbAccountList;
        }


        private void entNoTextEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            for (short i = 0; i < gridView1.DataRowCount; i++)
                gridView1.SetRowCellValue(i, colentNo, e.NewValue);
        }

        private void CurrencyGrid()
        {
            if (this.currencyGrid > 1)
            {
                colentDebitFrgn.OptionsColumn.AllowFocus = true;
                colentDebitFrgn.OptionsColumn.TabStop = true;
                colentCurChange.OptionsColumn.AllowFocus = true;
                colentCurChange.OptionsColumn.TabStop = true;
            }
            else
            {
                colentDebitFrgn.OptionsColumn.AllowFocus = false;
                colentDebitFrgn.OptionsColumn.TabStop = false;
                colentCurChange.OptionsColumn.AllowFocus = false;
                colentCurChange.OptionsColumn.TabStop = false;
            }
        }

        private double GetTotalTax()
        {
            if (!this.hasTax) return 0;
            double totalTax = 0;

            for (short i = 0; i <= gridView1.DataRowCount; i++)
                totalTax += Convert.ToDouble(gridView1.GetRowCellValue(i, colentTaxPrice));

            return totalTax;
        }

        private void UpdateMainRow()
        {
            int boxNo = Convert.ToInt32(entBoxNoLookUpEdit.EditValue);
            int OldboxNo = Convert.ToInt32(entBoxNoLookUpEdit.OldEditValue);
            double amount = Convert.ToDouble(entAmountTextEdit.EditValue);
            var lis_tbEntSub = this.clsTbEntSub.GetEntrySubDataByEntNoNdEntBox(this.entNoOld, OldboxNo);
            if (boxNo != OldboxNo)
            {
                lis_tbEntSub.Where(x => x.entIsMain == 2).ToList().ForEach(x =>
                {
                    db.tblEntrySubs.Attach(x);
                    x.entBoxNo = boxNo;
                });
            }
            var EntrySubIsMain1 = lis_tbEntSub.FirstOrDefault(x => x.entIsMain == 1);
            db.tblEntrySubs.Attach(EntrySubIsMain1);
            EntrySubIsMain1.entNo = Convert.ToInt32(entNoTextEdit.Text);
            EntrySubIsMain1.entAccNo = boxNo;
            EntrySubIsMain1.entBoxNo = boxNo;
            EntrySubIsMain1.entAccName = entBoxNoLookUpEdit.Text;
            EntrySubIsMain1.entDesc = entDescTextEdit.Text;
            EntrySubIsMain1.entDate = entDateTextEdit.DateTime;
            EntrySubIsMain1.entCurrency = this.currency;
            EntrySubIsMain1.entCredit = amount;
            EntrySubIsMain1.entView = this.view;
            if (this.hasTax) EntrySubIsMain1.entTaxPrice = GetTotalTax();
            if (this.currency > 1)
            {
                short currencyChange = Convert.ToInt16(entCurrencyChngTextEdit.EditValue);
                EntrySubIsMain1.entCredit = amount * currencyChange;
                EntrySubIsMain1.entCreditFrgn = amount;
                EntrySubIsMain1.entCurChange = currencyChange;
            }
        }

        private void SaveEntrySubData()
        {
            this.tbEntMain.entTotalTax = GetTotalTax();

            tblEntrySub entSubMain = new tblEntrySub()
            {
                entNo = Convert.ToInt32(entNoTextEdit.Text),
                entAccNo = this.boxAccNo,
                entAccName = entBoxNoLookUpEdit.Text,
                entBoxNo = Convert.ToInt32(entBoxNoLookUpEdit.EditValue),
                entCredit = Convert.ToDouble(entAmountTextEdit.Text),
                entDate = entDateTextEdit.DateTime,
                entDesc = entDescTextEdit.Text,
                entTaxPrice = GetTotalTax(),
                entCurrency = this.currency,
                entCurChange = (this.currency > 1) ? Convert.ToInt16(entCurrencyChngTextEdit.EditValue) : (short)0,
                entView = this.view,
                entBrnId = Session.CurBranch.brnId,
                entIsMain = 1,
                entEqfal = 2,
                entStatus = 2
            };
            db.tblEntrySubs.Add(entSubMain);

            for (short i = 0; i < gridView1.DataRowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, colentAccNo) == null) continue;
                tblEntrySub entSub = new tblEntrySub();
                entSub = gridView1.GetRow(i) as tblEntrySub;
                if (entSub == null) return;

                entSub.entNo = Convert.ToInt32(entNoTextEdit.Text);
                entSub.entBoxNo = Convert.ToInt32(entBoxNoLookUpEdit.EditValue);
                entSub.entDate = entDateTextEdit.DateTime;
                entSub.entCurChange = (this.currency > 1) ? Convert.ToInt16(entCurrencyChngTextEdit.EditValue) : (short)0;
                entSub.entBrnId = Session.CurBranch.brnId;
                entSub.entView = this.view;
                entSub.entEqfal = 1;
                entSub.entIsMain = 2;
                entSub.entStatus = 2;
                entSub.entDesc = entDescTextEdit.Text + " - " + entSub.entDesc;
                db.tblEntrySubs.Add(entSub);
            }
        }

        public bool ValidateAmount()
        {
            decimal eAmount = Convert.ToDecimal(entAmountTextEdit.EditValue);
            if (this.currency != 1)
                eAmount = Convert.ToDecimal(entAmountTextEdit.EditValue) * Convert.ToDecimal(entCurrencyChngTextEdit.EditValue);

            var entry = tblEntrySubBindingSource.List as IList<tblEntrySub>;
            if (entry.Count <= 0) return false;
            decimal amount = Convert.ToDecimal(entry.Sum(x => x.entDebit ?? 0));
            if (eAmount != amount)
            {
                XtraMessageBox.Show(_resource.GetString("validateAmountMssg"));
                return false;
            }
            return true;
        }
        private bool ValidateEntNo()
        {
            bool isEntNoFound = false;
            int entNo = Convert.ToInt32(entNoTextEdit.EditValue), boxNo = Convert.ToInt32(entBoxNoLookUpEdit.EditValue);
            bool chickEntNoFound = this.clsTbEntMain.IsEntryNoFound(entNo);
            if (this.isNew && chickEntNoFound)
                isEntNoFound = true;
            else if (!this.isNew && entNo != this.entNoOld && chickEntNoFound)
                isEntNoFound = true;

            if (isEntNoFound)
            {
                XtraMessageBox.Show(string.Format(_resource.GetString("vchrErrorMssg"), entNo));
                entNoTextEdit.Focus();
            }
            return isEntNoFound;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetGridFocusedColumn();
            gridView1.UpdateCurrentRow();
            if (!dxValidationProvider1.Validate()) return;
            if (!ValidateAmount()) return;
            if (ValidateEntNo()) return;

            int entNo = Convert.ToInt32(entNoTextEdit.Text);

            if (this.isNew)
                SaveEntrySubData();
            else
            {
                UpdateMainRow();
                this.tbEntMain.entTotalTax = GetTotalTax();
            }

            if (SaveDB())
            {
                string vchrSuccessMssg = MySetting.GetPrivateSetting.LangEng ? "Payment voucher no. {0}" : "سند الصرف  رقم :  {0}";
                _ucEntryVocher.RefreshListDialog(string.Format(vchrSuccessMssg, entNo), this.isNew);

                this.Close();
                _ucEntryVocher.SetFoucesdRow(entNo);
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void SetGridFocusedColumn()
        {
            if (gridView1.FocusedColumn == colentDesc)
                gridView1.FocusedColumn = colentNo;
            else
                gridView1.FocusedColumn = colentDesc;
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
                _resource = new ComponentResourceManager(typeof(formAddEntryVocher));
            }
            if (MySetting.GetPrivateSetting.LangEng) EnglishTranslation();
        }

        private void EnglishTranslation()
        {
            dataLayoutControl1.BeginUpdate();
            dataLayoutControl1.RightToLeft = RightToLeft.No;
            dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = false;
            dataLayoutControl1.EndUpdate();

            this.RightToLeft = RightToLeft.No;

            foreach (var item in layoutControlGroup4.Items)
            {
                if (item is LayoutControlItem layout)
                    _resource.ApplyResources(layout, layout.Name, _ci);
            }
            foreach (GridColumn col in gridView1.Columns)
                _resource.ApplyResources(col, col.Name, _ci);

            //_resource.ApplyResources(ribbonPage1, ribbonPage1.Name, _ci);
            //_resource.ApplyResources(ribbonPageGroup1, ribbonPageGroup1.Name, _ci);
            //_resource.ApplyResources(barButtonItem1, barButtonItem1.Name, _ci);
            //_resource.ApplyResources(barButtonItem2, barButtonItem2.Name, _ci);
            //_resource.ApplyResources(layoutControlGroup4, layoutControlGroup4.Name, _ci);
            //_resource.ApplyResources(checkEdit1, checkEdit1.Name, _ci);
            //_resource.ApplyResources(checkEditTax, checkEditTax.Name, _ci);
            if (entBoxNoLookUpEdit.Properties.Columns.Count > 0)
            {
                SetColumnCaption(entBoxNoLookUpEdit.Properties.Columns[0], "colBoxNo");
                SetColumnCaption(entBoxNoLookUpEdit.Properties.Columns[1], "colBoxNocolBoxName");

            }
            if (repositoryItemLookUpEdit1.View.Columns.Count > 0)
            {
                repositoryItemLookUpEdit1.View.Columns[0].Caption = _resource.GetString("colentAccNo.Caption");
                repositoryItemLookUpEdit1.View.Columns[1].Caption = _resource.GetString("colentAccName.Caption");

            }
            if (repositoryItemLookUpEdit2.View.Columns.Count > 0)
            {
                repositoryItemLookUpEdit2.View.Columns[0].Caption = _resource.GetString("colentAccNo.Caption");
                repositoryItemLookUpEdit2.View.Columns[1].Caption = _resource.GetString("colentCusNo.Caption");
                repositoryItemLookUpEdit2.View.Columns[2].Caption = _resource.GetString("colentCusName.Caption");

            }
            if (repositoryItemLookUpEdit3.View.Columns.Count > 0)
            {
                repositoryItemLookUpEdit3.View.Columns[0].Caption = _resource.GetString("colentAccNo.Caption");
                repositoryItemLookUpEdit3.View.Columns[1].Caption = _resource.GetString("colentAccName.Caption");

            }

            this.Text = _resource.GetString("$this.Text");
        }
        void SetColumnCaption(LookUpColumnInfo column, string key)
        {
            if (column != null)
                column.Caption = _resource.GetString(key);
        }
        private bool SaveDB()
        {
            return ClsSaveDB.Save(db, LogHelper.GetLogger());
        }
    }
}