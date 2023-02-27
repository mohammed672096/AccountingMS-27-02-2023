using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formAddEmpVchrExtra : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        accountingEntities db;
        ClsTblBox clsTbBox;
        ClsTblAccount clsTbAccount;
        ClsTblEmployee clsTbEmployee;
        ClsTblEntryMain clsTbEntryMain;
        ClsTblEntrySub clsTbEntrySub;
        ClsTblCurrency clsTbCurrency;
        tblEntryMain tbEntMain;
        tblEntrySub tbEntSubMain;
        IList<tblEntrySub> tbEntrySubList;

        private readonly UCempVchrExtra ucEmpVchrTip;
        private readonly EntryType entryType;
        private bool isNew;
        private int entId, entNoOld, boxNo;
        private byte currencyId;
        private long boxAccNo, toAccountNo;
        private string boxAccName, toAccountName;

        public formAddEmpVchrExtra(UCempVchrExtra ucEmpVchrTip, EntryType entryType, ClsTblEmployee clsTbEmployee, ClsTblEntryMain clsTbEntryMain, ClsTblEntrySub clsTbEntrySub, int entId = 0)
        {
            this.entId = entId;
            this.entryType = entryType;
            this.ucEmpVchrTip = ucEmpVchrTip;

            InitializeComponent();
            InitObjects();
            InitDefaultData();
            InitData();
            InitEvents();
        }

        private void InitEvents()
        {
            entDescTextEdit.EditValueChanging += EntDescTextEdit_EditValueChanging;
            entBoxNoTextEdit.EditValueChanged += EntBoxNoTextEdit_EditValueChanged;
            entToAccountTextEdit.EditValueChanged += EntToAccountTextEdit_EditValueChanged;

            gridControl1.ProcessGridKey += GridControl1_ProcessGridKey;
            gridView1.CellValueChanged += GridView1_CellValueChanged;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;

            repoItemSLEemp.EditValueChanged += RepoItemSLEemp_EditValueChanged;
            repoItemTextEditDebit.EditValueChanged += RepoItemTextEditDebit_EditValueChanged;
        }

        private void InitData()
        {
            if (this.entId == 0)
            {
                this.isNew = true;
                InitNewObj();
            }
            else
            {
                this.isNew = false;
                this.tbEntMain = this.clsTbEntryMain.GetEntryMainObjById(this.entId);
                this.tbEntSubMain = this.clsTbEntrySub.GetEntrySubObjByEntNoNdEntBoxNoWhereEntMainIs1(this.tbEntMain.entNo, (int)this.tbEntMain.entBoxNo);
                this.entNoOld = this.tbEntMain.entNo;

                tblEntryMainBindingSource.DataSource = this.tbEntMain;
                db.tblEntryMains.Attach(tblEntryMainBindingSource.Current as tblEntryMain);

                var tbEntSubList = this.clsTbEntrySub.GetEntrySubDataByEntNoNdEntBoxNoWhereEntMainIs2(this.tbEntMain.entNo, (int)this.tbEntMain.entBoxNo);
                foreach (var tbEntSub in tbEntSubList) db.tblEntrySubs.Attach(tbEntSub);
                tblEntrySubBindingSource.DataSource = tbEntSubList;

                UpdateProgrsesBarDesc((this.tbEntMain.entDesc != null) ? this.tbEntMain.entDesc.Length : 0);

                var tbEntSubAcc = tbEntSubList.FirstOrDefault();
                this.toAccountNo = (long)tbEntSubAcc.entAccNo;
                this.toAccountName = tbEntSubAcc.entAccName;
                entToAccountTextEdit.EditValue = tbEntSubAcc.entAccNo;
                SetEditFormProperties();
            }
        }

        private void SetEditFormProperties()
        {
            bbiReset.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
        }

        private void InitNewObj()
        {
            this.tbEntMain = new tblEntryMain()
            {
                entDate = DateTime.Now,
                entUserId = Session.CurrentUser.id,
                entBrnId = Session.CurBranch.brnId,
                entStatus = (byte)this.entryType,
            };
            tblEntryMainBindingSource.DataSource = this.tbEntMain;
        }

        private void InitObjects()
        {
            db = new accountingEntities();
            this.clsTbBox = new ClsTblBox();
            this.clsTbAccount = new ClsTblAccount();
            this.clsTbCurrency = new ClsTblCurrency();
            this.clsTbEmployee = new ClsTblEmployee();
            this.clsTbEntryMain = new ClsTblEntryMain(this.entryType);
            this.clsTbEntrySub = new ClsTblEntrySub(this.entryType);
        }

        private void InitDefaultData()
        {
            this.Text += $"{ClsEntryStatus.GetString((byte)this.entryType)}";
            this.clsTbBox.InitBoxLookupEditBoxNameDispMbr(entBoxNoTextEdit);
            this.clsTbAccount.InitAccountLookupEdit(entToAccountTextEdit);

            repoItemSLEemp.DataSource = this.clsTbEmployee.GetEemployeeListByCurId(1);
            entToAccountTextEdit.Properties.DataSource = this.clsTbAccount.GetAccountListByCategoeryNdCurId(3, 1);
        }

        private void GridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (!this.isNew) return;
            if (e.KeyCode != Keys.Delete) return;

            gridView1.DeleteSelectedRows();
            e.Handled = true;
        }

        private void RepoItemTextEditDebit_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit editor = sender as TextEdit;
            if (editor?.EditValue == null) return;

            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.FocusedColumn, editor.EditValue);
            gridView1.UpdateTotalSummary();
        }

        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colentCusNo) gridView1.UpdateCurrentRow();
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == colentCurrency.FieldName)
                e.DisplayText = this.clsTbCurrency.GetCurrencyNameById(Convert.ToByte(e.Value));
        }

        private void EntDescTextEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            UpdateProgrsesBarDesc();
        }

        private void UpdateProgrsesBarDesc()
        {
            UpdateProgrsesBarDesc(entDescTextEdit.Text.Length);
        }

        private void UpdateProgrsesBarDesc(int value)
        {
            progressBarControl1.EditValue = value;
            ItemForprogressBar.Text = $"{entDescTextEdit.Properties.MaxLength - value}";
        }

        private void EntToAccountTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;

            this.toAccountNo = Convert.ToInt64(editor.GetColumnValue("accNo"));
            this.toAccountName = Convert.ToString(editor.GetColumnValue("accName"));
        }

        private void EntBoxNoTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;

            var tbBox = editor.GetSelectedDataRow() as tblAccountBox;
            if (tbBox == null) return;

            this.boxNo = tbBox.boxNo;
            this.boxAccNo = tbBox.boxAccNo;
            this.boxAccName = tbBox.boxName;
            this.currencyId = Convert.ToByte(tbBox.boxCurrency);

            SetEntryMainObjData(tbBox.boxNo);
        }

        private void SetEntryMainObjData(int boxNo)
        {
            this.tbEntMain.entBoxNo = boxNo;
            this.tbEntMain.entCurrency = this.currencyId;

            if (!this.isNew) return;
            this.tbEntMain.entNo = this.clsTbEntryMain.GetNewEntNoByBoxNo(boxNo);
        }

        private void RepoItemSLEemp_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit editor = sender as SearchLookUpEdit;
            if (editor?.EditValue == null) return;

            var tbEmployee = editor.Properties.View.GetFocusedRow() as tblEmployee;
            if (tbEmployee == null) return;

            gridView1.SetFocusedRowCellValue(colentCurrency, Convert.ToByte(tbEmployee.empCurrency));
            gridView1.SetFocusedRowCellValue(colentCusName, tbEmployee.empName);
        }

        private bool ValidateData()
        {
            if (!dxValidationProvider1.Validate()) return false;
            if (!ValidateGridData()) return false;
            if (!ValidateEntryNo()) return false;

            return true;
        }

        private bool SaveData()
        {
            SaveGridToList();
            SaveEntryMain();
            SaveEntrySub();

            return true;
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ValidateData()) return;
            if (!SaveData()) return;
            if (!SaveDB) return;

            string mssg = $"{ClsEntryStatus.GetString((byte)this.entryType)} رقم: {this.tbEntMain.entNo}";
            this.ucEmpVchrTip.SetRefreshDialogList(mssg, this.tbEntMain.id, this.isNew);
            DialogResult = DialogResult.OK;
        }

        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InitNewObj();
            UpdateProgrsesBarDesc();
            tblEntrySubBindingSource.DataSource = null;
            tblEntrySubBindingSource.DataSource = typeof(tblEntrySub);
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void SaveEntryMain()
        {
            UpdateEntryMainTotal();

            if (!this.isNew) return;
            db.tblEntryMains.Add(this.tbEntMain);
        }

        private void UpdateEntryMainTotal()
        {
            this.tbEntMain.entAmount = this.tbEntrySubList.Sum(x => Convert.ToDouble(x.entDebit));
        }

        private void SaveEntrySub()
        {
            if (this.isNew)
            {
                SaveEntrySubMainRow();
                db.tblEntrySubs.AddRange(this.tbEntrySubList);
            }
            else
            {
                UpdateEntrySubGrid();
                UpdateEntrySubMainRow();
            }
        }

        private void SaveEntrySubMainRow()
        {
            db.tblEntrySubs.Add(new tblEntrySub()
            {
                entBoxNo = this.boxNo,
                entAccNo = this.boxAccNo,
                entAccName = this.boxAccName,
                entNo = this.tbEntMain.entNo,
                entDesc = this.tbEntMain.entDesc,
                entCredit = this.tbEntMain.entAmount,
                entCurrency = this.tbEntMain.entCurrency,
                entDate = entDateDateEdit.DateTime,
                entView = 1,
                entEqfal = 2,
                entIsMain = 1,
                entBrnId = Session.CurBranch.brnId,
                entStatus = (byte)this.entryType,
            });
        }

        private void UpdateEntrySubMainRow()
        {
            db.tblEntrySubs.Attach(this.tbEntSubMain);
            this.tbEntSubMain.entBoxNo = this.boxNo;
            this.tbEntSubMain.entAccNo = this.boxAccNo;
            this.tbEntSubMain.entAccName = this.boxAccName;
            this.tbEntSubMain.entNo = this.tbEntMain.entNo;
            this.tbEntSubMain.entDesc = this.tbEntMain.entDesc;
            this.tbEntSubMain.entDate = this.tbEntMain.entDate;
            this.tbEntSubMain.entCredit = this.tbEntMain.entAmount;
        }

        private void UpdateEntrySubGrid()
        {
            for (short i = 0; i < gridView1.DataRowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, colentCusNo) == null) continue;

                gridView1.SetRowCellValue(i, colentBoxNo, this.boxNo);
                gridView1.SetRowCellValue(i, colentNo, this.tbEntMain.entNo);
                gridView1.SetRowCellValue(i, colentAccNo, this.toAccountNo);
                gridView1.SetRowCellValue(i, colentAccName, this.toAccountName);
                gridView1.SetRowCellValue(i, colentDate, entDateDateEdit.DateTime.Date);
            }
        }

        private void SaveGridToList()
        {
            this.tbEntrySubList = new List<tblEntrySub>();

            for (short i = 0; i < gridView1.DataRowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, colentCusNo) == null) continue;

                var tbEntSub = gridView1.GetRow(i) as tblEntrySub;
                if (tbEntSub == null) continue;

                tbEntSub.entBoxNo = this.boxNo;
                tbEntSub.entNo = this.tbEntMain.entNo;
                tbEntSub.entAccNo = this.toAccountNo;
                tbEntSub.entAccName = this.toAccountName;
                tbEntSub.entDate = entDateDateEdit.DateTime;
                tbEntSub.entView = 1;
                tbEntSub.entEqfal = 1;
                tbEntSub.entIsMain = 2;
                tbEntSub.entBrnId = Session.CurBranch.brnId;
                tbEntSub.entStatus = (byte)this.entryType;

                this.tbEntrySubList.Add(tbEntSub);
            }
        }

        private void UpdateGrid()
        {
            gridView1.FocusedColumn = colentStatus;
            gridView1.UpdateCurrentRow();
        }

        private bool ValidateGridData()
        {
            UpdateGrid();
            bool isValid = (gridView1.DataRowCount == 0) ? false : true;
            if (!isValid) ClsXtraMssgBox.ShowError((!MySetting.GetPrivateSetting.LangEng ?
                "يجب إدخال بيانات الجدول أولاً!" : "Sorry, grid data can not be empty!"));

            return isValid;
        }

        private bool ValidateEntryNo()
        {
            bool isEntNoFound = false;
            if (this.isNew) isEntNoFound = this.clsTbEntryMain.IsEntryNoFound(this.tbEntMain.entNo);
            if (!this.isNew && this.tbEntMain.entNo != this.entNoOld) isEntNoFound = this.clsTbEntryMain.IsEntryNoFound(this.tbEntMain.entNo);
            if (isEntNoFound) ClsXtraMssgBox.ShowError($"عذرا لقد تم إستخدام رقم السند: {this.tbEntMain.entNo}!");

            return !isEntNoFound;
        }

        private bool SaveDB => ClsSaveDB.Save(db, LogHelper.GetLogger());
    }
}