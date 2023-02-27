using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraDataLayout;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using AccountingMS.Classes;
using System.Globalization;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraLayout;
using DevExpress.Utils.Extensions;
using DevExpress.XtraLayout.Utils;
using System.Data.Entity;
using static AccountingMS.ClsEntryTarhel;
using System.Data.Entity.Migrations;

namespace AccountingMS
{
    public partial class UC_DrawerPeriod : UC_Master
    {
        string TableName = "DrawerPeriods";
        public UC_DrawerPeriod(bool NewPeriod)
        {
            InitializeComponent();
            IsNew = NewPeriod;
            bindingNavigator.BindingSource = drawerPeriodBindingSource;
            myFunaction.layoutAppearanceGroup(lyc_OpeningGroup, bindingNavigator);
            myFunaction.AppearanceGridView(gridView1);
            myFunaction.AppearanceGridView(searchLookUpEdit1View);
        }
        ClsAppearance myFunaction = new ClsAppearance();
        public override void RefreshData()
        {
            TextReadOnly(true);
            using (var db = new accountingEntities())
                OpenNowtextEdit.Properties.DataSource = db.DrawerPeriods.AsNoTracking().Where(x => (x.Status ?? false)==false).ToList();
            BranchIDTextEdit.IntializeData(Session.Branches);
            DrawerIDTextEdit.IntializeData(Session.Boxes);
            PeriodUserIDTextEdit.IntializeData(Session.tblUser);
            ClosingPeriodUserIDTextEdit.IntializeData(Session.tblUser);
            ClosingDrwerIDTextEdit.IntializeData(Session.Boxes);
            DifferenceAccountIDTextEdit.Properties.DataSource = (Session.Accounts.Where(ac=> ac.accType == 2).Select(x=> new { ID = x.id,Name = x.accNo + " - " + x.accName })).ToList();
            base.RefreshData();
        }
        void SetOpeningBalance()
        {
            if (CurrPeriod.PeriodUserID != 0&& boxAcc?.boxAccNo!=0)
            {
                using (var db = new accountingEntities())
                    CurrPeriod.OpeningBalance = db.GetOpeningBalance(CurrPeriod.PeriodStart, CurrPeriod.DrawerID, CurrPeriod.PeriodUserID, CurrPeriod.BranchID).FirstOrDefault().GetValueOrDefault();
            }
        }
        public override void New()
        {
            DrawerPeriod CurrPeriod = new DrawerPeriod();
            CurrPeriod.PeriodUserID = Session.CurrentUser.id;
            CurrPeriod.PeriodStart = DateTime.Now;
            CurrPeriod.DrawerID=Session.Boxes?.FirstOrDefault(x => x.boxAccNo == MySetting.DefaultSetting.defaultBox)?.id??0;
            CurrPeriod.BranchID = Session.CurBranch.brnId;
            CurrPeriod.Status = false;
            SetOpeningBalance();
            drawerPeriodBindingSource.DataSource = CurrPeriod;
            base.New();
            TextReadOnly(false);
            OpenPeriodButton.Enabled = !btnAddNew.Enabled;
        }
        DrawerPeriod CurrPeriod => drawerPeriodBindingSource.Current as DrawerPeriod;
        public void TextReadOnly(bool state)
        {
                lyc_OpeningGroup.Enabled = IsNew;
            lyc_ClosingGroup.Enabled = !IsNew;
        }

        public override void EnableOrDisyble(bool state)
        {
            if (state)
            {
                bindingNavigator.MoveFirstItem = Movefirst;
                bindingNavigator.MovePreviousItem = Moveprevious;
                bindingNavigator.MoveNextItem = Movenext;
                bindingNavigator.MoveLastItem = Movelast;
            }
            else bindingNavigator.MoveFirstItem = bindingNavigator.MovePreviousItem =
                 bindingNavigator.MoveNextItem = bindingNavigator.MoveLastItem = null;
            Movefirst.Enabled = Moveprevious.Enabled = Movenext.Enabled = Movelast.Enabled = state;
            base.EnableOrDisyble(state);
        }
        public override void Delete()
        {
           if (CurrPeriod == null) return;
            if (ClsXtraMssgBox.ShowWarningYesNo($"هل انت متاكد من حذف يومية الصندوق رقم {CurrPeriod.ID}؟") == DialogResult.Yes)
            {
                using (var dbLocal = new accountingEntities())
                {
                    var p = dbLocal.DrawerPeriods.FirstOrDefault(x => x.ID == CurrPeriod.ID);
                    if (p != null)
                    {
                        dbLocal.DrawerPeriods.Remove(p);
                        var asse = dbLocal.tblAssets.Where(x => x.asEntId == CurrPeriod.ID && x.asStatus == (byte)AssetType.UnderSettlement).ToList();
                        if (asse.Count > 0)
                            dbLocal.tblAssets.RemoveRange(asse);
                        dbLocal.SaveChanges();
                        New();
                    }
                }
                RefreshData();
            }
            base.Delete();
        }

        public override void DataUpdate()
        {
            TextReadOnly(false);
            base.DataUpdate();
        }

        private void UC_DrawerPeriod_Load(object sender, EventArgs e)
        {
            Movefirst.Visible = Moveprevious.Visible = Movenext.Visible = Movelast.Visible
                = toolStripTextBox7.Visible = btnPrint.Visible = btnSave.Visible = toolStripLabel7.Visible = btnUpdate.Visible = false;
            btnAddNew.Visible = IsNew;
            lyc_OpeningGroup.Enabled = IsNew;
            lyc_ClosingGroup.Visibility = IsNew ? LayoutVisibility.Never : LayoutVisibility.Always;
            RefreshData();
            if (IsNew)
                btnAddNew.PerformClick();
            ClosePeriodButton.Enabled = false;
        }
        public override void Reset()
        {
            RefreshData();
            base.Reset();
            OpenPeriodButton.Enabled = !btnAddNew.Enabled;
        }
        private void OpenPeriodButton_Click(object sender, EventArgs e)
        {
            if (CurrPeriod == null) return;

            if (CurrPeriod.DrawerID ==0)
            {
                DrawerIDTextEdit.ErrorText = "ادخل اسم الصندوق";
                return;
            }
            using (var db=new accountingEntities())
            {
                var hasAnotherOpendPeriod = db.DrawerPeriods.Any(x => x.ID != CurrPeriod.ID && x.PeriodEnd == null && (x.DrawerID == CurrPeriod.DrawerID || x.PeriodUserID == CurrPeriod.PeriodUserID));
                if (hasAnotherOpendPeriod)
                {
                    XtraMessageBox.Show(text: "يوجد  فتره مفتوحه لهذا الصندوق او المستخدم مسبقا ولم يتم اغلاقها \n يرجي اغلاق الفتره السابقه اولا", caption: "", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);
                    return;
                }
                var isInotherPeriod = db.DrawerPeriods.Any(x => x.ID != CurrPeriod.ID && x.PeriodEnd > CurrPeriod.PeriodStart && x.PeriodStart < CurrPeriod.PeriodStart);
                if (isInotherPeriod)
                {
                    XtraMessageBox.Show(text: "تاريخ بدايه الفتره التي تحاول فتحها يقع ضمن نطاق زمني لفتره اخري  \n يرجي اختيار تاريخ اخر ", caption: "", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);
                    return;
                }
                db.DrawerPeriods.Add(CurrPeriod);
                db.SaveChanges();
                XtraMessageBox.Show(text: " تم فتح الفتره  بنجاح", caption: "", icon: MessageBoxIcon.Information, buttons: MessageBoxButtons.OK);
                Reset();
            }
            OpenPeriodButton.Enabled = false;
        }

        private void searchLookUpEdit1View_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value == null) return;
            if (e.Column.FieldName == colBranchID.FieldName && e.Value is short b && b != 0)
                e.DisplayText = Session.Branches.FirstOrDefault(x=>x.brnId==b)?.brnName;
            else if ((e.Column.FieldName == colPeriodUserID.FieldName|| e.Column.FieldName == colClosingPeriodUserID.FieldName) && e.Value is short u && u != 0)
                e.DisplayText = Session.tblUser.FirstOrDefault(x => x.id == u)?.userName;
            else if ((e.Column.FieldName == colDrawerID.FieldName|| e.Column.FieldName == colClosingDrwerID.FieldName) && e.Value is short d && d != 0)
                e.DisplayText = Session.Boxes.FirstOrDefault(x => x.id == d)?.boxName;
        }
        
        private void OpenNowtextEdit_EditValueChanged(object sender, EventArgs e)
        {
            var drp = OpenNowtextEdit.GetSelectedDataRow() as DrawerPeriod;
            if (drp == null) return;
            Reset();
            drawerPeriodBindingSource.DataSource = drp;
            GetMovePeriod();
        }

        private void PeriodStartDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (PeriodStartDateEdit.EditValue == null) return;
            if(PeriodStartDateEdit.EditValue is DateTime date)
            {
                OpenNowtextEdit.EditValue = null;
                CurrPeriod.PeriodStart = date;
                SetOpeningBalance();
                GetMovePeriod();
            }
        }
        private void PeriodEndDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (PeriodEndDateEdit.EditValue == null|| CurrPeriod==null) return;
            if (PeriodEndDateEdit.EditValue is DateTime date&&date>CurrPeriod.PeriodStart)
            {
                CurrPeriod.PeriodEnd = date;
                GetMovePeriod();
            }
            
        }
        byte GetSupStatus(tblSupplyMain supplyMain) => ((SupplyType)supplyMain.supStatus)
        switch
        {
            SupplyType.Purchase => 3,
            SupplyType.PurchasePhase => 3,
            SupplyType.Sales => 4,
            SupplyType.SalesPhase => 4,
            SupplyType.SalesRtrn => 11,
            SupplyType.SalesPhaseRtrn => 11,
            SupplyType.PurchaseRtrn => 9,
            SupplyType.PurchasePhaseRtrn => 9,
        };
        byte GetEntryStatus(tblEntryMain entryMain) => ((EntryType)entryMain.entStatus)
        switch
        {
            EntryType.DailyEntry => 1,
            EntryType.EntryPhased => 1,
            EntryType.EntryVoucher => 2,
            EntryType.EntryVoucherPhased => 2,
            EntryType.EntryReceipt => 3,
            EntryType.EntryReceiptPhased => 3,
            EntryType.EmpVoucher => 7,
            EntryType.EmppVoucherPhased => 7,
            EntryType.EmpVoucherOvrTm => 11,
            EntryType.EmpVoucherOvrTmPhased => 11,
            EntryType.EmpVoucherTip => 9,
            EntryType.EmpVoucherTipPhased => 9,
        };
        List<BoxSummary> GetBoxSummaryFromInvoice()
        {
            if (boxAcc == null) return null;
            using (var db = new accountingEntities())
            {
                var AllInvo = (from a in db.tblSupplyMains.AsNoTracking().Where(x => x.supDate >= CurrPeriod.PeriodStart &&(x.supAccNo == boxAcc.boxAccNo||x.supBoxId== CurrPeriod.DrawerID)
                               && x.supBrnId == CurrPeriod.BranchID && x.supUserId == CurrPeriod.PeriodUserID && x.supStatus <= 12 && x.supIsCash == 1).ToList()
                               select new
                               {
                                   a.supNo,
                                   supStatus = GetSupStatus(a),
                                   supBankAmount = (a.supBankAmount ?? 0) * PlusOrMinus((SupplyType)a.supStatus),
                                   paidCash = (a.net - (a.supBankAmount ?? 0)) * PlusOrMinus((SupplyType)a.supStatus),
                                   a.supDate,
                                   a.net,
                               }).ToList();

                return (from a in AllInvo
                        group a by a.supStatus into s
                        select new BoxSummary
                        {
                            Count = s.Count(),
                            paidCash = s.Sum(x => x.paidCash),
                            BankAmount = s.Sum(x => x.supBankAmount),
                            Type = ClsSupplyStatus.GetString(s.Key),
                            SummaryDetails = (from s1 in s
                                              select new SummaryDetail
                                              {
                                                  No = s1.supNo,
                                                  OperType = ClsSupplyStatus.GetString(s.Key),
                                                  Date = ((DateTime)s1.supDate).ToString("G"),
                                                  Net = Convert.ToDouble(s1.net.ToString("n2")),
                                              }).ToList()
                        }).ToList();
            }
        }
        List<BoxSummary> GetBoxSummaryFromAssest()
        {
            if (boxAcc == null) return null;
            using (var db = new accountingEntities())
            {
                return (from a in db.tblAssets.AsNoTracking().Where(x => x.asAccNo == boxAcc.boxAccNo && x.asDate >= CurrPeriod.PeriodStart && x.asUserId == CurrPeriod.PeriodUserID && x.asBrnId == CurrPeriod.BranchID
                              && ((AssetType)x.asStatus == AssetType.CloseDailyBox || (AssetType)x.asStatus == AssetType.OpnAccount || (AssetType)x.asStatus == AssetType.InvSettlement
                              || (AssetType)x.asStatus == AssetType.UnderSettlement || (AssetType)x.asStatus == AssetType.PrdExpirate)).ToList()
                        group a by a.asStatus into s
                        select new BoxSummary
                        {
                            Count = s.Count(),
                            paidCash = s.Sum(x => (x.asDebit ?? 0) - (x.asCredit ?? 0)),
                            BankAmount = 0,
                            Type = ((AssetType)s.Key).GetDescription(),
                            SummaryDetails = (from s1 in s
                                              select new SummaryDetail
                                              {
                                                  No = s1.asEntNo,
                                                  OperType = ((AssetType)s1.asStatus).GetDescription(),
                                                  Date = ((DateTime)s1.asDate).ToString("G"),
                                                  Net = Convert.ToDouble(((s1.asDebit ?? 0) - (s1.asCredit ?? 0)).ToString("n2")),
                                              }).ToList()
                        }).ToList();
            }
        }
        List<BoxSummary> GetBoxSummaryFromEntry()
        {
            if (boxAcc == null) return null;
            using (var db = new accountingEntities())
            {
                var AllEntry = (from a in db.tblEntryMains.AsNoTracking().Where(x => x.entDate >= CurrPeriod.PeriodStart && x.entBrnId == CurrPeriod.BranchID && x.entUserId == CurrPeriod.PeriodUserID && x.entStatus <= 12).ToList()
                              join s in db.tblEntrySubs.AsNoTracking().Where(x =>x.entAccNo == boxAcc.boxAccNo) on (a.entNo,a.entStatus) equals (s.entNo,s.entStatus)
                               select new
                               {
                                   a.entNo,
                                   entStatus = GetEntryStatus(a),
                                   supBankAmount =0,
                                   paidCash = Convert.ToDouble(((s.entDebit ?? 0) - (s.entCredit ?? 0)).ToString("n2")),
                                   a.entDate,
                               }).ToList();

                return (from a in AllEntry
                        group a by a.entStatus into s
                        select new BoxSummary
                        {
                            Count = s.Count(),
                            paidCash = s.Sum(x => x.paidCash),
                            BankAmount = s.Sum(x => x.supBankAmount),
                            Type = ClsEntryStatus.GetString(s.Key),
                            SummaryDetails = (from s1 in s
                                              select new SummaryDetail
                                              {
                                                  No = s1.entNo,
                                                  OperType = ClsEntryStatus.GetString(s.Key),
                                                  Date = ((DateTime)s1.entDate).ToString("G"),
                                                  Net = Convert.ToDouble(s1.paidCash.ToString("n2")),
                                              }).ToList()
                        }).ToList();
            }
        }
        List<BoxSummary> BoxSummaryInvoice = new List<BoxSummary>();
        List<BoxSummary> BoxSummaryAssest = new List<BoxSummary>();
        List<BoxSummary> BoxSummaryEntry = new List<BoxSummary>();
        void GetMovePeriod()
        {
            if (CurrPeriod.PeriodUserID == 0||CurrPeriod.DrawerID==0) return;
            BoxSummaryAssest.Clear();
            BoxSummaryInvoice.Clear();
            BoxSummaryEntry.Clear();
            BoxSummaryAssest = GetBoxSummaryFromAssest();
            BoxSummaryInvoice = GetBoxSummaryFromInvoice();
            BoxSummaryEntry = GetBoxSummaryFromEntry();
            BoxSummaryAssest.AddRange(BoxSummaryInvoice);
            BoxSummaryAssest.AddRange(BoxSummaryEntry);

            gridControl1.DataSource = BoxSummaryAssest;
            CurrPeriod.ClosingBalance = CurrPeriod.OpeningBalance + BoxSummaryAssest.Sum(x => x.paidCash);
            CurrPeriod.AmountBank = BoxSummaryAssest.Sum(x => x.BankAmount);
            ClosingBalanceTextEdit.EditValue = CurrPeriod.ClosingBalance;
                if (!IsNew)
                {
                    ActualBalanceTextEdit.EditValue = ClosingBalanceTextEdit.EditValue;
                    ClosePeriodButton.Enabled = true;
                }
        }

        private void ActualBalanceTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (CurrPeriod == null) return;
            if(ActualBalanceTextEdit.EditValue is double actual)
            {
                CurrPeriod.ActualBalance = actual;
                BalanceDifferenceTextEdit.EditValue = CurrPeriod.ActualBalance - CurrPeriod.ClosingBalance;
            }
        }
        private void AddTblAssetObj()
        {
            this.tbAssetList = new List<tblAsset>();
            if (CurrPeriod.TransferdBalance != 0)
            {
                this.tbAssetList.Add(new tblAsset()
                {
                    asAccNo = boxAcc.boxAccNo,
                    asAccName = boxAcc.boxName,
                    asDate = CurrPeriod.PeriodEnd,
                    asEntId = CurrPeriod.ID,
                    asEntNo = CurrPeriod.ID,
                    asStatus = (byte?)AssetType.CloseDailyBox,
                    asDebit = (CurrPeriod.TransferdBalance < 0) ? Math.Abs(CurrPeriod.TransferdBalance) : 0,
                    asCredit = (CurrPeriod.TransferdBalance > 0) ? Math.Abs(CurrPeriod.TransferdBalance) : 0,
                    asDesc = ("اغلاق يومية صندوق رقم" + CurrPeriod.ID.ToString()),
                    asBrnId = CurrPeriod.BranchID,
                    asUserId =CurrPeriod.PeriodUserID,
                    asView = 1
                });
                this.tbAssetList.Add(new tblAsset()
                {
                    asAccNo = boxCloseAcc.boxAccNo,
                    asAccName = boxCloseAcc.boxName,
                    asDate = CurrPeriod.PeriodEnd,
                    asEntId = CurrPeriod.ID,
                    asEntNo = CurrPeriod.ID,
                    asStatus = (byte?)AssetType.CloseDailyBox,
                    asDebit = (CurrPeriod.TransferdBalance > 0) ? Math.Abs(CurrPeriod.TransferdBalance) : 0,
                    asCredit = (CurrPeriod.TransferdBalance < 0) ? Math.Abs(CurrPeriod.TransferdBalance) : 0,
                    asDesc = ("اغلاق يومية صندوق رقم" + CurrPeriod.ID.ToString()),
                    asBrnId = CurrPeriod.BranchID,
                    asUserId = CurrPeriod.ClosingPeriodUserID,
                    asView = 1
                });
            }

            var BalanceDifference = CurrPeriod.ActualBalance - CurrPeriod.ClosingBalance;
            if (BalanceDifference != 0)
            {
                string statment = "تسويه عجز / زياده ليوميه صندوق" + " رقم " + CurrPeriod.ID;
                this.tbAssetList.Add(new tblAsset()
                {
                    asBrnId = Session.CurBranch?.brnId,
                    asDate = CurrPeriod.PeriodEnd,
                    asStatus = (byte?)AssetType.UnderSettlement,
                    asDesc = statment,
                    asEntId = CurrPeriod.ID,
                    asEntNo = CurrPeriod.ID,
                    asDebit = (BalanceDifference > 0) ? Math.Abs(BalanceDifference) : 0,
                    asCredit = (BalanceDifference < 0) ? Math.Abs(BalanceDifference) : 0,
                    asUserId = CurrPeriod.PeriodUserID,
                    asAccNo = boxAcc.boxAccNo,
                    asAccName = Session.Accounts.FirstOrDefault(x => x.accNo == boxAcc.boxAccNo)?.accName ?? boxAcc.boxName,
                    asView = 1,
                });
                var acc = Session.Accounts.FirstOrDefault(x => x.id == CurrPeriod.DifferenceAccountID);
                this.tbAssetList.Add(new tblAsset()
                {
                    asBrnId = Session.CurBranch?.brnId,
                    asDate = CurrPeriod.PeriodEnd,
                    asStatus = (byte?)AssetType.UnderSettlement,
                    asDesc = statment,
                    asEntId = CurrPeriod.ID,
                    asEntNo = CurrPeriod.ID,
                    asDebit = (BalanceDifference < 0) ? Math.Abs(BalanceDifference) : 0,
                    asCredit = (BalanceDifference > 0) ? Math.Abs(BalanceDifference) : 0,
                    asUserId =CurrPeriod.PeriodUserID,
                    asAccNo = acc.accNo,
                    asAccName = acc.accName,
                    asView = 1,
                });
            }
        }
        List<tblAsset> tbAssetList = new List<tblAsset>();
        bool ValidatValue()
        {
            if ((CurrPeriod.ClosingPeriodUserID ?? 0) == 0)
            {
                XtraMessageBox.Show(text: " حدد مستخدم الاغلاق", caption: "", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);
                return true;
            }
            if ((CurrPeriod.ClosingDrwerID ?? 0) == 0|| boxCloseAcc == null)
            {
                XtraMessageBox.Show(text: " حدد صندوق الاغلاق", caption: "", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);
                return true;
            }
            if (CurrPeriod.PeriodEnd == null)
            {
                XtraMessageBox.Show(text: " حدد تاريخ الاغلاق ", caption: "", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);
                return true;
            }
            if (BalanceDifferenceTextEdit.EditValue is double d && d != 0 && (CurrPeriod.DifferenceAccountID ?? 0) == 0)
            {
                XtraMessageBox.Show(text: "يجب اختيار حساب التسوية بسبب وجود عجز او زياده ", caption: "", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);
                return true;
            }
            if (boxAcc == null)
            {
                XtraMessageBox.Show(text: "يجب تحديد الصندوق عند فتح اليومية", caption: "", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);
                return true;
            }
            else if (!Session.Accounts.Any(x => x.accNo == boxAcc.boxAccNo))
            {
                XtraMessageBox.Show(text: "هذا الصندوق غير مربوط باي حساب في الدليل المحاسبي!!!", caption: "", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);
                return true;
            }
            else if (!Session.Accounts.Any(x => x.accNo == boxCloseAcc.boxAccNo))
            {
                XtraMessageBox.Show(text: " صندوق الاغلاق غير مربوط باي حساب في الدليل المحاسبي!!!", caption: "", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);
                return true;
            }
            if (CurrPeriod.TransferdBalance != 0|| (BalanceDifferenceTextEdit.EditValue is double d1 && d1 != 0))
            {
                using (var db = new accountingEntities())
                {
                    if (db.tblSupplyMains.AsNoTracking().Any(M => M.supDate >= CurrPeriod.PeriodStart && M.supBrnId == CurrPeriod.BranchID && (M.supBoxId == CurrPeriod.DrawerID || M.supAccNo == boxAcc.boxAccNo) && M.supUserId == CurrPeriod.PeriodUserID && (M.supStatus == 4 || M.supStatus == 3 || M.supStatus == 9 || M.supStatus == 11)))
                    {
                        XtraMessageBox.Show(text: "عفو لا يمكن اغلاق الفتره حتى يتم ترحيل كل الفواتير التي تم اضافتها خلال هذه الفترة!!!", caption: "", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);
                        return true;
                    }
                    else if (db.tblEntryMains.AsNoTracking().Any(M => M.entDate >= CurrPeriod.PeriodStart && M.entBoxNo == boxAcc.boxAccNo && M.entBrnId == CurrPeriod.BranchID && M.entUserId== CurrPeriod.PeriodUserID && (M.entStatus == 1 || M.entStatus == 2 || M.entStatus == 3 || M.entStatus == 7 || M.entStatus == 9 || M.entStatus == 11)))
                    {
                        XtraMessageBox.Show(text: "عفو لا يمكن اغلاق الفتره حتى يتم ترحيل كل السندات التي تم اضافتها بواسطة مستخدم الفترة خلال هذه الفترة!!!", caption: "", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);
                        return true;
                    }
                }
            }
                return false;
        }
        double PlusOrMinus(SupplyType supplyType) => (supplyType) switch
        {
            SupplyType.Sales => 1,
            SupplyType.SalesRtrn => -1,
            SupplyType.Purchase => -1,
            SupplyType.PurchaseRtrn => 1,
            SupplyType.SalesPhase => 1,
            SupplyType.SalesPhaseRtrn => -1,
            SupplyType.PurchasePhase => -1,
            SupplyType.PurchasePhaseRtrn => 1,
        };
        tblAccountBox boxAcc => Session.Boxes.FirstOrDefault(x => x.id == CurrPeriod?.DrawerID);
        tblAccountBox boxCloseAcc => Session.Boxes.FirstOrDefault(x => x.id == CurrPeriod?.ClosingDrwerID);
        private void ClosePeriodButton_Click(object sender, EventArgs e)
        {
            if (ValidatValue()) return;
            
            AddTblAssetObj();
            decimal SumDebit = Convert.ToDecimal(tbAssetList?.Sum(x => x.asDebit) ?? 0);
            decimal SumCredit = Convert.ToDecimal(tbAssetList?.Sum(x => x.asCredit) ?? 0);
            if (SumDebit != SumCredit)
            {
                XtraMessageBox.Show(text: "اجمالي المدين لا يساوي اجمالي الدائن", caption: "", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);
                return;
            }
            bool isSaved = false;
            using (var db=new accountingEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        CurrPeriod.Status = true;
                        if (this.tbAssetList.Count > 0)
                            db.tblAssets.AddRange(this.tbAssetList);
                        db.DrawerPeriods.AddOrUpdate(CurrPeriod);
                        db.SaveChanges();
                        transaction.Commit();
                        isSaved = true;
                    }
                    catch (Exception ex)
                    {
                        this.tbAssetList.Clear();
                        transaction.Rollback();
                        ClsXtraMssgBox.ShowError(ex.Message);
                        return;
                    }
                }
            }
            if (isSaved)
            {
                XtraMessageBox.Show(text: $" تم اغلاق الفتره رقم {CurrPeriod.ID } بنجاح", caption: "", icon: MessageBoxIcon.Information, buttons: MessageBoxButtons.OK);
                ClosePeriodButton.Enabled = false;
            }
        }

        private void RemainingBalanceTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (CurrPeriod == null) return;
            double rem = Convert.ToDouble(RemainingBalanceTextEdit.EditValue);
            CurrPeriod.RemainingBalance = rem;
            CurrPeriod.TransferdBalance = CurrPeriod.ActualBalance - rem;
            TransferdBalanceTextEdit.EditValue = CurrPeriod.TransferdBalance;
        }

     
    }
}
