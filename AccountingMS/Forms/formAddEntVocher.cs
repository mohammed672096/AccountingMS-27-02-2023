using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;
using System.Globalization;
using DevExpress.XtraLayout;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraLayout.Utils;

namespace accounting_1._0
{
    public partial class formAddEntVocher : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        accountingEntities2 db = new accountingEntities2();
        ArrayList list = new ArrayList();
        ClsLinQuery lq = new ClsLinQuery();
        ClsCurrencyData curData = new ClsCurrencyData();
        ClsTblCustomer csDt = new ClsTblCustomer();
        tblEntryMain tbEntMain;

        private readonly UCentryVocher _ucEntryVocher;
        private int entNo;
        private Int64 boxAccNo;
        private bool isNew;
        private byte currency;
        private byte currencyGrid;
        private byte view;
        private bool hasTax;

        private void formAddEntVocher_Load(object sender, EventArgs e)
        {
            lq.BoxNo(entBoxNoLookUpEdit);
            lq.AccNoGrid(repositoryItemLookUpEdit1);
            lq.AccNameGrid(repositoryItemLookUpEdit3);
            csDt.GetCustNo(repositoryItemLookUpEdit2);
            GetResources();
            gridView1.Columns["entAccNo"].ColumnEdit = repositoryItemLookUpEdit1;
            gridView1.Columns["entCusNo"].ColumnEdit = repositoryItemLookUpEdit2;
            gridView1.Columns["entAccName"].ColumnEdit = repositoryItemLookUpEdit3;
        }

        public formAddEntVocher(tblEntryMain obj, BindingList<tblEntrySub> subObj, UCentryVocher ucEntryVoher)
        {
            InitializeComponent();
            _ucEntryVocher = ucEntryVoher;

            if (obj == null)
            {
                this.isNew = true;
                this.hasTax = true;
                this.view = 1;
                this.tbEntMain = new tblEntryMain()
                {
                    entDate = DateTime.Now,
                    entBrnId = ClsBranchId.BranchId,
                    entUserId = ClsUserId.UserId,
                    entStatus = 2
                };
                tblEntryMainsBindingSource.DataSource = this.tbEntMain;
                db.tblEntryMains.Add(tblEntryMainsBindingSource.Current as tblEntryMain);
            }
            else
            {
                this.isNew = false;
                this.entNo = obj.entNo;
                this.currency = Convert.ToByte(obj.entCurrency);
                this.view = Convert.ToByte(subObj.FirstOrDefault().entView);
                this.hasTax = (obj.entTotalTax > 0) ? true : false;
                this.tbEntMain = obj;

                tblEntryMainsBindingSource.DataSource = this.tbEntMain;
                db.tblEntryMains.Attach(tblEntryMainsBindingSource.Current as tblEntryMain);

                bindingSource1.DataSource = subObj;
                foreach (var tbEntSub in subObj)
                    db.tblEntrySubs.Attach(tbEntSub);
                
                textEdit1.EditValue = lq.BoxName(Convert.ToInt32(obj.entBoxNo));
                entCurrTextEdit.EditValue = curData.CurrName(this.currency);
                checkEditTax.Checked = this.hasTax;

                if (this.currency > 1) ItemForentCurrencyChng.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                if (this.view == 2) checkEdit1.Checked = true;
            }

            entBoxNoLookUpEdit.EditValueChanged += EntBoxNoLookUpEdit_EditValueChanged;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
            gridView1.FocusedColumnChanged += GridView1_FocusedColumnChanged;
            gridView1.CellValueChanging += GridView1_CellValueChanging;
            repositoryItemLookUpEdit1.EditValueChanged += RepositoryItemLookUpEdit1_EditValueChanged;
            repositoryItemLookUpEdit2.EditValueChanged += RepositoryItemLookUpEdit2_EditValueChanged;
            repositoryItemLookUpEdit3.EditValueChanged += RepositoryItemLookUpEdit3_EditValueChanged;
            checkEdit1.CheckedChanged += CheckEdit1_CheckedChanged;
            checkEditTax.EditValueChanged += CheckEditTax_EditValueChanged;
        }

        private void RepositoryItemLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit editor = (sender as DevExpress.XtraEditors.LookUpEdit);

            Int64 custAccNo = Convert.ToInt64(editor.GetColumnValue("accNo"));
            this.currencyGrid = Convert.ToByte(editor.GetColumnValue("accCurrency"));
            gridView1.SetFocusedRowCellValue(gridView1.Columns[1], editor.GetColumnValue("accName").ToString());
            gridView1.SetFocusedRowCellValue(gridView1.Columns[4], this.currencyGrid);
            CustData(custAccNo);
            GetTaxPercent();

            if (this.currencyGrid > 1)
                gridView1.SetFocusedRowCellValue(colentCurChange, entCurrencyChngTextEdit.EditValue);
        }

        private void RepositoryItemLookUpEdit3_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor.GetColumnValue("accName") == null)
                return;

            Int64 custAccNo = Convert.ToInt64(editor.GetColumnValue("accNo"));
            this.currencyGrid = Convert.ToByte(editor.GetColumnValue("accCurrency"));
            gridView1.SetFocusedRowCellValue(gridView1.Columns[0], Convert.ToInt64(editor.GetColumnValue("accNo")));
            gridView1.SetFocusedRowCellValue(gridView1.Columns[4], this.currencyGrid);
            CustData(custAccNo);
            GetTaxPercent();

            if (this.currencyGrid > 1)
                gridView1.SetFocusedRowCellValue(colentCurChange, entCurrencyChngTextEdit.EditValue);
        }

        private void RepositoryItemLookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit editor = (sender as DevExpress.XtraEditors.LookUpEdit);
            if (editor.GetColumnValue("cstName") == null)
                return;

            Int64 cstAccNo = Convert.ToInt64(editor.GetColumnValue("cstAccNo"));
            this.currencyGrid = curData.GetCurrency((cstAccNo));
            gridView1.SetFocusedRowCellValue(gridView1.Columns[3], Convert.ToString(editor.GetColumnValue("cstName")));
            gridView1.SetFocusedRowCellValue(gridView1.Columns[0], Convert.ToInt64(editor.GetColumnValue("cstAccNo")));
            gridView1.SetFocusedRowCellValue(gridView1.Columns[1], Convert.ToString(editor.GetColumnValue("cstAccName")));
            gridView1.SetFocusedRowCellValue(gridView1.Columns[4], this.currencyGrid);
            GetTaxPercent();

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

        private void CheckEditTax_EditValueChanged(object sender, EventArgs e)
        {
            this.hasTax = (Convert.ToBoolean(checkEditTax.EditValue)) ? true : false;
            HasTax();
        }

        private void HasTax()
        {
            if (this.hasTax)
            {
                colentTaxPercent.Visible = true;
                colentTaxPrice.Visible = true;
                colentTaxPercent.VisibleIndex = 10;
                colentTaxPrice.VisibleIndex = 11;
                colentDesc.VisibleIndex = 12;
            }
            else
            {
                colentTaxPercent.Visible = false;
                colentTaxPrice.Visible = false;
            }
        }
        
        private void GridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "entDebitFrgn")
            {
                if (!String.IsNullOrEmpty(e.Value.ToString()))
                    gridView1.SetFocusedRowCellValue(colentDebit, Convert.ToInt32(e.Value) *
                        Convert.ToInt32(gridView1.GetFocusedRowCellValue(colentCurChange)));
            }

            if (this.hasTax)
            {
                if (e.Column.FieldName == "entDebit")
                    gridView1.SetFocusedRowCellValue(colentTaxPrice, Convert.ToDecimal(e.Value) * 
                        (Convert.ToDecimal(gridView1.GetFocusedRowCellValue(colentTaxPercent)) / 100));
                else if (e.Column.FieldName == "entTaxPercent")
                    gridView1.SetFocusedRowCellValue(colentTaxPrice, Convert.ToDecimal(gridView1.GetFocusedRowCellValue(colentDebit))
                        * (Convert.ToDecimal(e.Value) / 100));
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
                e.DisplayText = curData.CurrName(Convert.ToInt16(e.Value));
        }

        private void EntBoxNoLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor.GetColumnValue("boxName") == null) return;
            
            this.boxAccNo = Convert.ToInt64(editor.GetColumnValue("boxAccNo"));
            this.currency = Convert.ToByte(editor.GetColumnValue("boxCurrency"));
            this.entNo = lq.EntNoBox(Convert.ToInt32(editor.GetColumnValue("boxNo")), 2, 5);
            this.tbEntMain.entNo = this.entNo;

            entNoTextEdit.Text = this.entNo.ToString();
            textEdit1.EditValue = editor.GetColumnValue("boxName").ToString(); ;
            entCurrTextEdit.Text = curData.CurrName(this.currency);
            
            if (currency != 1)
            {
                short currencyChng = Convert.ToInt16(curData.CurrChange(this.currency));
                this.tbEntMain.entCurChange = currencyChng;

                entCurrencyChngTextEdit.EditValue = currencyChng;
                ItemForentCurrencyChng.Visibility = LayoutVisibility.Always;
            }
            else
            {
                ItemForentCurrencyChng.Visibility = LayoutVisibility.Never;
                entCurrencyChngTextEdit.EditValue = null;
            }
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

        private void CustData(Int64 custAccNo)
        {
            if (lq.InitDataCustAcc(custAccNo) == true)
            {
                gridView1.SetFocusedRowCellValue(gridView1.Columns[2], lq.custNoLq);
                gridView1.SetFocusedRowCellValue(gridView1.Columns[3], lq.custNameLq);
            }
            else
            {
                gridView1.SetFocusedRowCellValue(gridView1.Columns[2], null);
                gridView1.SetFocusedRowCellValue(gridView1.Columns[3], null);
            }
        }

        private void GetTaxPercent()
        {
            if (this.hasTax)
                gridView1.SetFocusedRowCellValue(colentTaxPercent, Properties.Settings.Default.taxDefault);
        }

        private decimal GetTotalTax()
        {
            if (!this.hasTax) return 0;
            decimal totalTax = 0;

            for (short i = 0; i <= gridView1.DataRowCount; i++)
                totalTax += Convert.ToDecimal(gridView1.GetRowCellValue(i, colentTaxPrice));

            return totalTax;
        }

        private bool UpdMainRow()
        {
            var tbEntSub = (from a in db.tblEntrySubs
                            where a.entBrnId == ClsBranchId.BranchId && (a.entDate  >= ClsFinancialYear.FyDtStart && a.entDate  <= ClsFinancialYear.FyDtEnd) && a.entStatus == 2 && a.entIsMain == 1
                            select a).ToList();
            decimal amount = Convert.ToDecimal(entAmountTextEdit.EditValue);
            bool isFound = false;

            foreach (var entSub in tbEntSub)
            {
                if (entSub.entNo == this.entNo)
                {
                    db.tblEntrySubs.Attach(entSub);

                    if (this.boxAccNo > 0)
                    {
                        entSub.entAccNo = this.boxAccNo;
                        entSub.entAccName = lq.AccNoName(this.boxAccNo);
                    }
                    entSub.entNo = Convert.ToInt32(entNoTextEdit.Text);
                    entSub.entBoxNo = Convert.ToInt32(entBoxNoLookUpEdit.Text);
                    entSub.entDesc = entDescTextEdit.Text;
                    entSub.entDate = entDateTextEdit.DateTime.Date;
                    entSub.entCurrency = this.currency;
                    entSub.entCredit = amount;
                    entSub.entTaxPrice = GetTotalTax();
                    entSub.entView = this.view;
                    if (this.currency > 1)
                    {
                        Int32 change = Convert.ToInt32(entCurrencyChngTextEdit.EditValue);
                        entSub.entCredit = amount * change;
                        entSub.entCreditFrgn = amount;
                        entSub.entCurChange = Convert.ToInt16(entCurrencyChngTextEdit.EditValue);
                    }

                    isFound = true;
                    break;
                }
            }

            if (!isFound)
                XtraMessageBox.Show("عذرا هناك خطاء في تحديث البيانات، يرجى إعادة تشغيل النظام لتخطي الخطاء.");

            return isFound;
        }
        
        private void CreateNew()
        {
            this.tbEntMain.entCurrency = this.currency;
            this.tbEntMain.entTotalTax = GetTotalTax();

            tblEntrySub entSubMain = new tblEntrySub()
            {
                entNo = Convert.ToInt32(entNoTextEdit.Text),
                entAccNo = this.boxAccNo,
                entAccName = lq.AccNoName(this.boxAccNo),
                entBoxNo = Convert.ToInt32(entBoxNoLookUpEdit.Text),
                entCredit = Convert.ToDecimal(entAmountTextEdit.Text),
                entDate = entDateTextEdit.DateTime.Date,
                entDesc = entDescTextEdit.Text,
                entTaxPrice = GetTotalTax(),
                entCurrency = this.currency,
                entCurChange = (this.currency > 1) ? Convert.ToInt16(entCurrencyChngTextEdit.EditValue) : (short)0,
                entView = this.view,
                entBrnId = ClsBranchId.BranchId,
                entIsMain = 1,
                entEqfal = 2,
                entStatus = 2
            };
            db.tblEntrySubs.Add(entSubMain);

            for (short i = 0; i < gridView1.DataRowCount; i++)
            {
                tblEntrySub entSub = new tblEntrySub();
                entSub = gridView1.GetRow(i) as tblEntrySub;
                entSub.entNo = Convert.ToInt32(entNoTextEdit.Text);
                entSub.entBoxNo = Convert.ToInt32(entBoxNoLookUpEdit.Text);
                entSub.entDate = entDateTextEdit.DateTime.Date;
                entSub.entCurChange = (this.currency > 1) ? Convert.ToInt16(entCurrencyChngTextEdit.EditValue) : (short)0;
                entSub.entBrnId = ClsBranchId.BranchId;
                entSub.entView = this.view;
                entSub.entEqfal = 1;
                entSub.entIsMain = 2;
                entSub.entStatus = 2;
                db.tblEntrySubs.Add(entSub);
            }
        }

        private void ChangeFocus()
        {
            if (entNoTextEdit.ContainsFocus)
                entDescTextEdit.Focus();
            else
                entNoTextEdit.Focus();
        }

        public bool ValidateAmount()
        {
            ChangeFocus();
            int amount = 0, eAmount = Convert.ToInt32(entAmountTextEdit.EditValue);
            if (this.currency != 1)
                eAmount = Convert.ToInt32(entAmountTextEdit.EditValue) * Convert.ToInt32(entCurrencyChngTextEdit.EditValue);

            for (short i = 0; i < gridView1.DataRowCount; i++)
            {
                amount += Convert.ToInt32(gridView1.GetRowCellValue(i, colentDebit));
            }

            if (eAmount != amount)
            {
                XtraMessageBox.Show(_resource.GetString("validateAmountMssg"));
                this.list.Clear();
                return false;
            }

            return true;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            if (!ValidateAmount()) return;

            int entNo = Convert.ToInt32(entNoTextEdit.Text);

            if (this.isNew)
            {
                if (lq.IsEntFound(entNo, 1, 4))
                {
                    XtraMessageBox.Show(string.Format(_resource.GetString("vchrErrorMssg"), entNo));
                    return;
                }
                CreateNew();
            }
            else
            {
                if (entNo != this.entNo && lq.IsEntFound(entNo, 1, 4))
                {
                    XtraMessageBox.Show(string.Format(_resource.GetString("vchrErrorMssg"), entNo));
                    entNoTextEdit.Text = Convert.ToString(this.entNo);
                    entNoTextEdit.Focus();
                    return;
                }
                if (!UpdMainRow()) return;
                this.tbEntMain.entCurrency = this.currency;
                this.tbEntMain.entTotalTax = GetTotalTax();
            }
            if (SaveDB())
            {
                _ucEntryVocher.RefreshListDialog(string.Format(_resource.GetString("vchrSuccessMssg"), entNo), this.isNew);
                this.Close();
                _ucEntryVocher.SetFoucesdRow(entNo);
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void formAddEntVocher_Activated(object sender, EventArgs e)
        {
            HasTax();
        }

        private void GetResources()
        {
            if (!Properties.Settings.Default.langEng)
            {
                _ci = new CultureInfo("ar");
                _resource = new ComponentResourceManager(typeof(accounting_1._0.Language.EntriesNotificationAr));
            }
            else
            {
                _ci = new CultureInfo("en");
                _resource = new ComponentResourceManager(typeof(accounting_1._0.Language.formAddEntVocherEn));
            }

            if (Properties.Settings.Default.langEng) EnglishTranslation();
        }

        private void EnglishTranslation()
        {
            dataLayoutControl1.BeginUpdate();
            dataLayoutControl1.RightToLeft = RightToLeft.No;
            dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = false;
            dataLayoutControl1.EndUpdate();

            this.RightToLeft = RightToLeft.No;

            foreach (LayoutControlItem item in layoutControlGroup4.Items)
                _resource.ApplyResources(item, item.Name, _ci);
            foreach (GridColumn col in gridView1.Columns)
                _resource.ApplyResources(col, col.Name, _ci);

            _resource.ApplyResources(ribbonPage1, ribbonPage1.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup1, ribbonPageGroup1.Name, _ci);
            _resource.ApplyResources(barButtonItem1, barButtonItem1.Name, _ci);
            _resource.ApplyResources(barButtonItem2, barButtonItem2.Name, _ci);
            _resource.ApplyResources(layoutControlGroup4, layoutControlGroup4.Name, _ci);
            _resource.ApplyResources(checkEdit1, checkEdit1.Name, _ci);
            _resource.ApplyResources(checkEditTax, checkEditTax.Name, _ci);

            entBoxNoLookUpEdit.Properties.Columns[0].Caption = _resource.GetString("colBoxNo");
            entBoxNoLookUpEdit.Properties.Columns[1].Caption = _resource.GetString("colBoxName");
            repositoryItemLookUpEdit1.Columns[0].Caption = _resource.GetString("colentAccNo.Caption");
            repositoryItemLookUpEdit1.Columns[1].Caption = _resource.GetString("colentAccName.Caption");
            repositoryItemLookUpEdit3.Columns[0].Caption = _resource.GetString("colentAccNo.Caption");
            repositoryItemLookUpEdit3.Columns[1].Caption = _resource.GetString("colentAccName.Caption");
            repositoryItemLookUpEdit2.Columns[0].Caption = _resource.GetString("colentCusNo.Caption");
            repositoryItemLookUpEdit2.Columns[1].Caption = _resource.GetString("colentCusName.Caption");

            this.Text = _resource.GetString("$this.Text");
        }

        private bool SaveDB()
        {
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}