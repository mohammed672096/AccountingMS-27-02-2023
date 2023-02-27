using AccountingMS.Forms.HR;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
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
    public partial class formAddEmployeeVchr : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        accountingEntities db = new accountingEntities();
        ClsTblBox clsTbBox = new ClsTblBox();
        ClsTblCurrency clsTbCurrency = new ClsTblCurrency();
        ClsTblEntryMain clsTbEntMain;
        ClsTblEntrySub clsTbEntSub;
        tblEntryMain tbEntMain;

        cashingEmployee fr1;
        private readonly UCemployeesVchr _ucEmployeeVchr;
        private bool isNew;
        private long boxAccNo;
        private int entNo, entNoOld, boxNoOld;
        private byte currency;

        public formAddEmployeeVchr(tblEntryMain obj, IEnumerable<tblEntrySub> subObj, UCemployeesVchr ucEmployeeVchr, ClsTblEntryMain clsTbEntMain, ClsTblEntrySub clsTbEntSub = null)
        {
            this.clsTbEntMain = clsTbEntMain;
            this.clsTbEntSub = clsTbEntSub;
            InitializeComponent();
            InitDefaultData();
            InitData(obj, subObj);
            GetResources();
            _ucEmployeeVchr = ucEmployeeVchr;

            entNoTextEdit.EditValueChanging += EntNoTextEdit_EditValueChanging;
            entBoxNoTextEdit.EditValueChanged += EntBoxNoTextEdit_EditValueChanged;
            entCurrencyTextEdit.EditValueChanged += EntCurrencyTextEdit_EditValueChanged;
            gridView1.CellValueChanging += GridView1_CellValueChanging;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
            repositoryItemLookUpEditEmpAccNo.EditValueChanged += RepositoryItemLookUpEdit1_EditValueChanged;
            repositoryItemLookUpEditEmpName.EditValueChanged += RepositoryItemLookUpEdit2_EditValueChanged;
            repositorybtnSalaryEdit1.Click += RepositorybtnSalaryEdit1_Click;
            this.Activated += FormAddEmployeeVchr_Activated;
        }

       

        private void RepositorybtnSalaryEdit1_Click(object sender, EventArgs e)
        {
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, colentAccName) != null)
                {
                //  gridView1.SetFocusedRowCellValue(colentAccName, editor.GetColumnValue("empName"));
               // int ID =Convert.ToInt32( gridView1.GetRowCellValue(gridView1.FocusedRowHandle, colentAccNo));
                cashingEmployee frm = new cashingEmployee(this);

                frm.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("ادخل اسم الموظف اولاً");
            }
        }

        public RadioGroupItem[] DiscountTypeList ={
                new RadioGroupItem() { Value = (int)DiscountType.OnProduct  , Description  =(MySetting.GetPrivateSetting.LangEng)?"Treasury":"الصندوق" },
                new RadioGroupItem() { Value = (int)DiscountType.OnInvoice  , Description  =(MySetting.GetPrivateSetting.LangEng)?"Bank":"البنك" },
                 };

        private void FormAddEmployeeVchr_Activated(object sender, EventArgs e)
        {
            entBoxNoTextEdit.Focus();
        }

        private void InitDefaultData()
        {
            this.clsTbBox.InitBoxLookupEdit(entBoxNoTextEdit);
            this.clsTbCurrency.InitCurrencyLookupEdit(entCurrencyTextEdit);
            tblEmployeeBindingSource.DataSource = new ClsTblEmployee().GetEmployeeList;
            if (this.tbEntMain != null && clsTbCurrency != null)
                this.tbEntMain.entCurrency = clsTbCurrency.FirstCurrency;

        }

        private void InitData(tblEntryMain obj, IEnumerable<tblEntrySub> subObj)
        {
            if (obj == null)
            {
                this.isNew = true;

                InitTbEntMainObj();
                tblEntryMainBindingSource.DataSource = this.tbEntMain;
                db.tblEntryMains.Add(tblEntryMainBindingSource.Current as tblEntryMain);
            }
            else
            {
                this.isNew = false;
                this.entNo = obj.entNo;
                this.entNoOld = obj.entNo;
                this.boxNoOld = Convert.ToInt32(obj.entBoxNo);
                this.currency = Convert.ToByte(obj.entCurrency);
                this.tbEntMain = obj;

                tblEntryMainBindingSource.DataSource = this.tbEntMain;
                db.tblEntryMains.Attach(tblEntryMainBindingSource.Current as tblEntryMain);

                tblEntrySubBindingSource.DataSource = subObj;
                foreach (var tbEntSub in subObj) db.tblEntrySubs.Attach(tbEntSub);

                SetItemCurrencyChngVisibility();
                entBoxNameTextEdit.EditValue = this.clsTbBox.GetBoxNameByNo(Convert.ToInt32(obj.entBoxNo));
            }
        }

        private void InitTbEntMainObj()
        {
            this.tbEntMain = new tblEntryMain()
            {
                entBoxNo = 0,
                entDate = DateTime.Now,
                entBrnId = Session.CurBranch.brnId,
                entUserId = Session.CurrentUser.id,
                entStatus = 7
            };
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column == colentCurrency)
                e.DisplayText = this.clsTbCurrency.GetCurrencySignById(Convert.ToByte(e.Value));
        }

        private void GridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            double val; byte currency = Convert.ToByte(gridView1.GetFocusedRowCellValue(colentCurrency));

            if (e.Column.FieldName == "entDebit")
            {
                if (String.IsNullOrEmpty(e.Value.ToString()) || !double.TryParse(e.Value.ToString(), out val)) return;
                if (currency > 1)
                {
                    double forignAmount = Convert.ToDouble(e.Value) / Convert.ToDouble(gridView1.GetFocusedRowCellValue(colentCurChange));
                    gridView1.SetFocusedRowCellValue(colentDebitFrgn, forignAmount);
                }
            }
            else if (e.Column.FieldName == "entDebitFrgn")
            {
                if (String.IsNullOrEmpty(e.Value.ToString()) || !double.TryParse(e.Value.ToString(), out val)) return;
                if (currency > 1)
                    gridView1.SetFocusedRowCellValue(colentDebit, Convert.ToDouble(e.Value) * Convert.ToInt16(gridView1.GetFocusedRowCellValue(colentCurChange)));
            }
        }

        private void EntNoTextEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            this.entNo = Convert.ToInt32(e.NewValue);
            for (short i = 0; i < gridView1.DataRowCount; i++)
                gridView1.SetRowCellValue(i, colentNo, e.NewValue);
        }

        private void EntBoxNoTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;
            switch (radioGroup1.SelectedIndex)
            {
                case 0:
                    tblAccountBox tbBox = editor.GetSelectedDataRow() as tblAccountBox;
                    if (tbBox == null)
                    {
                        editor.EditValue = 0;
                        return;
                    }
                    this.boxAccNo = tbBox.boxAccNo;
                    this.currency = Convert.ToByte(tbBox.boxCurrency);
                    this.entNo = this.clsTbEntMain.GetNewEntNoByBoxNo(tbBox.boxNo);

                    this.tbEntMain.entNo = this.entNo;
                    this.tbEntMain.entBoxNo = tbBox.boxNo;
                    this.tbEntMain.entCurrency = this.currency;

                    entNoTextEdit.EditValue = this.entNo;
                    entBoxNoTextEdit.EditValue = tbBox.boxNo;
                    entBoxNoTextEdit.EditValue = tbBox.boxNo;
                    entBoxNameTextEdit.EditValue = tbBox.boxName;
                    entCurrencyTextEdit.EditValue = tbBox.boxCurrency;
                    checkUpdateBoxNo();
                    break;
                case 1:
                    tblAccountBank tbbank = editor.GetSelectedDataRow() as tblAccountBank;
                    if (tbbank == null)
                    {
                        editor.EditValue = 0;
                        return;
                    }
                    this.boxAccNo = tbbank.bankNo;
                    this.currency = Convert.ToByte(tbbank.bankCurrency);
                    this.entNo = this.clsTbEntMain.GetNewEntNoByBoxNo(tbbank.bankNo);

                    this.tbEntMain.entNo = this.entNo;
                    this.tbEntMain.entBoxNo = tbbank.bankNo;
                    this.tbEntMain.entCurrency = this.currency;

                    entNoTextEdit.EditValue = this.entNo;
                    entBoxNoTextEdit.EditValue = tbbank.bankNo;
                    entBoxNoTextEdit.EditValue = tbbank.bankNo;
                    entBoxNameTextEdit.EditValue = tbbank.bankName;
                    entCurrencyTextEdit.EditValue = tbbank.bankCurrency;
                    checkUpdateBoxNo();
                    break;
            }
        }

        private void checkUpdateBoxNo()
        {
            if (!this.isNew && this.boxNoOld == Convert.ToInt32(entBoxNoTextEdit.EditValue))
            {
                this.entNo = this.entNoOld;
                this.tbEntMain.entNo = this.entNo;
                entNoTextEdit.EditValue = this.entNo;
            }
        }

        private void EntCurrencyTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;

            this.tbEntMain.entCurChange = Convert.ToInt16(editor.GetColumnValue("curChange"));
            entCurChangeTextEdit.EditValue = Convert.ToInt16(editor.GetColumnValue("curChange"));
            SetItemCurrencyChngVisibility();
        }

        private void SetItemCurrencyChngVisibility()
        {
            ItemForentCurChange.Visibility = (this.currency > 1) ? LayoutVisibility.Always : LayoutVisibility.Never;
        }

        private void RepositoryItemLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;

            byte currency = Convert.ToByte(editor.GetColumnValue("empCurrency"));
            gridView1.SetFocusedRowCellValue(colentAccName, editor.GetColumnValue("empName"));
            gridView1.SetFocusedRowCellValue(colentCurrency, currency);
            gridView1.SetFocusedRowCellValue(colentCurChange, (currency > 1) ? entCurChangeTextEdit.EditValue : null);
        }

        private void RepositoryItemLookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;

            byte currency = Convert.ToByte(editor.GetColumnValue("empCurrency"));
            gridView1.SetFocusedRowCellValue(colentAccNo, editor.GetColumnValue("empAccNo"));
            gridView1.SetFocusedRowCellValue(colentCurrency, currency);
            gridView1.SetFocusedRowCellValue(colentCurChange, (currency > 1) ? entCurChangeTextEdit.EditValue : null);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpdateGridView();

            if (!dxValidationProvider1.Validate()) return;
            if (!ValidateAmount()) return;
            if (ValidateEntNo()) return;

            if (this.isNew) SaveEntrySubData();
            else UpdateMainRow();

            if (SaveDB())
            {
                this.Close();
                _ucEmployeeVchr.RefreshListDialog(string.Format(_resource.GetString("entSuccessMssg"), this.entNo), this.isNew);
                _ucEmployeeVchr.SetFoucesdRow(this.entNo);
            }
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void SaveEntrySubData()
        {
            tblEntrySub tbEntSubMain = new tblEntrySub()
            {
                entNo = this.entNo,
                entAccNo = this.boxAccNo,
                entAccName = entBoxNameTextEdit.Text,
                entBoxNo = Convert.ToInt32(entBoxNoTextEdit.EditValue),
                entCredit = Convert.ToDouble(entAmountTextEdit.Text),
                entDate = entDateDateEdit.DateTime,
                entDesc = entDescTextEdit.Text,
                entCurrency = this.currency,
                entBrnId = Session.CurBranch.brnId,
                entView = 1,
                entIsMain = 1,
                entEqfal = 2,
                entStatus = 7
            };
            if (this.currency > 1) tbEntSubMain.entCurChange = Convert.ToInt16(entCurChangeTextEdit.EditValue);
            db.tblEntrySubs.Add(tbEntSubMain);

            for (short i = 0; i < gridView1.DataRowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, colentAccNo) == null) continue;
                tblEntrySub tbEntSub = new tblEntrySub();
                tbEntSub = gridView1.GetRow(i) as tblEntrySub;
                if (tbEntSub == null) return;

                tbEntSub.entNo = this.entNo;
                tbEntSub.entBoxNo = Convert.ToInt32(entBoxNoTextEdit.EditValue);
                tbEntSub.entDate = entDateDateEdit.DateTime;
                tbEntSub.entBrnId = Session.CurBranch.brnId;
                tbEntSub.entView = 1;
                tbEntSub.entEqfal = 1;
                tbEntSub.entIsMain = 2;
                tbEntSub.entStatus = 7;
                db.tblEntrySubs.Add(tbEntSub);
            }
        }

        private void UpdateMainRow()
        {
            double amount = Convert.ToDouble(entAmountTextEdit.EditValue);
            tblEntrySub tbEntSub = this.clsTbEntSub.GetEntrySubObjByEntNoNdEntBoxNoWhereEntMainIs1(this.entNo, Convert.ToInt32(entBoxNoTextEdit.EditValue));
            db.tblEntrySubs.Attach(tbEntSub);

            tbEntSub.entNo = this.entNo;
            tbEntSub.entBoxNo = Convert.ToInt32(entBoxNoTextEdit.EditValue);
            tbEntSub.entDesc = entDescTextEdit.Text;
            tbEntSub.entDate = entDateDateEdit.DateTime;
            tbEntSub.entCurrency = this.currency;
            tbEntSub.entCredit = amount;
            if (this.currency > 1)
            {
                short currencyChange = Convert.ToInt16(entCurChangeTextEdit.EditValue);
                tbEntSub.entCredit = amount * currencyChange;
                tbEntSub.entCreditFrgn = amount;
                tbEntSub.entCurChange = currencyChange;
            }
        }

        private void UpdateGridView()
        {
            gridView1.FocusedColumn = (gridView1.FocusedColumn == colentDesc) ? colentNo : colentDesc;
            gridView1.UpdateCurrentRow();
        }

        private bool ValidateEntNo()
        {
            bool isEntNoFound = false;
            int boxNo = Convert.ToInt32(entBoxNoTextEdit.EditValue);
            bool chickEntNoFound = this.clsTbEntMain.IsEntryNoFound(this.entNo);
            if (this.isNew && chickEntNoFound)
                isEntNoFound = true;
            else if (!this.isNew && this.entNo != this.entNoOld && chickEntNoFound)
                isEntNoFound = true;

            if (isEntNoFound)
            {
                XtraMessageBox.Show(string.Format(_resource.GetString("entErrorMssg"), this.entNo));
                entNoTextEdit.EditValue = this.entNoOld;
                entNoTextEdit.Focus();
            }
            return isEntNoFound;
        }

        private bool ValidateAmount()
        {
            double gridAmount = 0, entAmount = Convert.ToDouble(entAmountTextEdit.EditValue);
            if (this.currency != 1)
                entAmount = Convert.ToDouble(entAmountTextEdit.EditValue) * Convert.ToDouble(entCurChangeTextEdit.EditValue);

            for (short i = 0; i < gridView1.DataRowCount; i++)
                gridAmount += Convert.ToDouble(gridView1.GetRowCellValue(i, colentDebit));

            if (entAmount != gridAmount)
            {
                XtraMessageBox.Show(_resource.GetString("validateAmountMssg"));
                return false;
            }
            return true;
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
                _resource = new ComponentResourceManager(typeof(Language.formAddEmployeeVchrEn));
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

            _resource.ApplyResources(mainRibbonPage, mainRibbonPage.Name, _ci);
            _resource.ApplyResources(barButtonItem1, barButtonItem1.Name, _ci);
            _resource.ApplyResources(bbiClose, bbiClose.Name, _ci);
            _resource.ApplyResources(mainRibbonPageGroup, mainRibbonPageGroup.Name, _ci);
            _resource.ApplyResources(layoutControlGroup4, layoutControlGroup4.Name, _ci);

            repositoryItemLookUpEditEmpAccNo.Columns[0].Caption = _resource.GetString("repositoryItemLookUpEdit1.Columns1");
            repositoryItemLookUpEditEmpAccNo.Columns[1].Caption = _resource.GetString("repositoryItemLookUpEdit1.Columns3");
            repositoryItemLookUpEditEmpName.Columns[0].Caption = _resource.GetString("repositoryItemLookUpEdit2.Columns1");
            repositoryItemLookUpEditEmpName.Columns[1].Caption = _resource.GetString("repositoryItemLookUpEdit2.Columns3");
            colentDebit.SummaryItem.DisplayFormat = _resource.GetString("colentDebit.Summary2");

            this.Text = _resource.GetString("$this.Text");
            ChangeLayout();
        }

        private void formAddEmployeeVchr_Load(object sender, EventArgs e)
        {
            radioGroup1.Properties.Items.AddRange(DiscountTypeList);
            radioGroup1.SelectedIndex = 0;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (radioGroup1.SelectedIndex)
            {
                case 0:
                    ItemForentBoxNo.Text = "رقم الصندوق";
                    layoutControlItem1.Text = "اسم الصندوق";
                    entBoxNoTextEdit.Properties.Columns.Clear();
                    entBoxNameTextEdit.Text = "";
                    entCurrencyTextEdit.Text = "";
                    this.clsTbBox.InitBoxLookupEdit(entBoxNoTextEdit);
                    break;
                case 1:
                    ItemForentBoxNo.Text = "رقم البنك";
                    layoutControlItem1.Text = "اسم البنك";
                    entBoxNoTextEdit.Properties.Columns.Clear();
                    entBoxNameTextEdit.Text = "";
                    entCurrencyTextEdit.Text = "";
                    this.clsTbBox.InitBoxBankLookupEdit(entBoxNoTextEdit);
                    break;

                default:
                    break;
            }


        }

        private void repositoryDeleteButtonEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            //delete row
            if (gridView1.RowCount == 0) return;

            //if (XtraMessageBox.Show($"هل تريد حذف هذه الفترة ؟"{ }, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) { }
            //{
            // gridView2.GetFocusedRow();
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
            XtraMessageBox.Show("تم الحذف.");
            //}
        }

        private void ChangeLayout()
        {
            ItemForentDate.Move(ItemForentNo, InsertType.Right);
            layoutControlItem1.Move(ItemForentBoxNo, InsertType.Right);
            ItemForentAmount.Move(ItemForentCurrency, InsertType.Right);
            ItemForentCurChange.Move(ItemForentCurrency, InsertType.Right);
        }

        private bool SaveDB()
        {
            return ClsSaveDB.Save(db, LogHelper.GetLogger());
        }
    }
}
