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
using PosFinalCost.Classe;
using System.Globalization;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraLayout;
using DevExpress.Utils.Extensions;
using DevExpress.XtraLayout.Utils;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using PosFinalCost.Forms;
using System.Transactions;

namespace PosFinalCost
{
    public partial class UC_DrawerPeriod : UC_Master
    {
        string TableName = "DrawerPeriod";
        public UC_DrawerPeriod(bool NewPeriod)
        {
            InitializeComponent();
            IsNew = NewPeriod;
            bindingNavigator11.BindingSource = drawerPeriodBindingSource;
            myFunaction.layoutAppearanceGroup(lyc_OpeningGroup, bindingNavigator11);
            myFunaction.AppearanceGridView(gridView1);
            myFunaction.AppearanceGridView(searchLookUpEdit1View);
        }
        MyFunaction myFunaction = new MyFunaction();
        public override void RefreshData()
        {
            TextReadOnly(true);
            using (var db = new PosDBDataContext(Program.ConnectionString))
                OpenNowtextEdit.Properties.DataSource = db.DrawerPeriods.AsNoTracking().Where(x => (x.Status ?? false)==false).ToList();
            BranchIDTextEdit.IntializeData(Session.Branches);
            DrawerIDTextEdit.IntializeData(Session.Boxes);
            PeriodUserIDTextEdit.IntializeData(Session.UserTbls);
            ClosingPeriodUserIDTextEdit.IntializeData(Session.UserTbls);
            ClosingDrwerIDTextEdit.IntializeData(Session.Boxes);
            //DifferenceAccountIDTextEdit.Properties.DataSource = (Session.Accounts.Where(ac=> ac.accType == 2).Select(x=> new { ID = x.id,Name = x.accNo + " - " + x.accName })).ToList();
            base.RefreshData();
        }
        void SetOpeningBalance()
        {
            if (CurrPeriod.PeriodUserID != 0&& boxAcc?.AccNo!=0)
            {
                using (var db = new PosDBDataContext(Program.ConnectionString))
                    CurrPeriod.OpeningBalance = db.GetOpeningBalance(CurrPeriod.PeriodStart, CurrPeriod.DrawerID, CurrPeriod.PeriodUserID, CurrPeriod.BranchID)?.FirstOrDefault()?.Column1??0;
            }
        }
        public override void New()
        {
            DrawerPeriod CurrPeriod = new DrawerPeriod();
            CurrPeriod.PeriodUserID = Session.CurrentUser.ID;
            CurrPeriod.PeriodStart = DateTime.Now;
            CurrPeriod.DrawerID=Convert.ToInt16(Session.CurrSettings.DefaultBox);
            CurrPeriod.BranchID = Session.CurrentBranch.ID;
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
                bindingNavigator11.MoveFirstItem = Movefirst;
                bindingNavigator11.MovePreviousItem = Moveprevious;
                bindingNavigator11.MoveNextItem = Movenext;
                bindingNavigator11.MoveLastItem = Movelast;
            }
            else bindingNavigator11.MoveFirstItem = bindingNavigator11.MovePreviousItem =
                 bindingNavigator11.MoveNextItem = bindingNavigator11.MoveLastItem = null;
            Movefirst.Enabled = Moveprevious.Enabled = Movenext.Enabled = Movelast.Enabled = state;
            base.EnableOrDisyble(state);
        }
        public override void Delete()
        {
           if (CurrPeriod == null) return;
            if (ClsXtraMssgBox.ShowWarningYesNo($"هل انت متاكد من حذف يومية الصندوق رقم {CurrPeriod.ID}؟") == DialogResult.Yes)
            {
                using (var dbLocal = new PosDBDataContext(Program.ConnectionString))
                {
                    var p = dbLocal.DrawerPeriods.FirstOrDefault(x => x.ID == CurrPeriod.ID);
                    if (p != null)
                    {
                        dbLocal.DrawerPeriods.DeleteOnSubmit(p);
                        //var asse = dbLocal.tblAssets.Where(x => x.asEntId == CurrPeriod.ID && x.asStatus == (byte)AssetType.UnderSettlement).ToList();
                        //if (asse.Count > 0)
                        //    dbLocal.tblAssets.RemoveRange(asse);
                        dbLocal.SubmitChanges();
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
            PeriodEndDateEdit.ReadOnly = true;
            PeriodEndDateEdit.DateTime = DateTime.Now;
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
            using (var db=new PosDBDataContext(Program.ConnectionString))
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
                db.DrawerPeriods.InsertOnSubmit(CurrPeriod);
                db.SubmitChanges();
                XtraMessageBox.Show(text: " تم فتح الفتره  بنجاح", caption: "", icon: MessageBoxIcon.Information, buttons: MessageBoxButtons.OK);
                Reset();
            }
            OpenPeriodButton.Enabled = false;
        }

        private void searchLookUpEdit1View_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value == null) return;
            if (e.Column.FieldName == colBranchID.FieldName && e.Value is short b && b != 0)
                e.DisplayText = Session.Branches.FirstOrDefault(x=>x.ID==b)?.Name;
            else if ((e.Column.FieldName == colPeriodUserID.FieldName|| e.Column.FieldName == colClosingPeriodUserID.FieldName) && e.Value is short u && u != 0)
                e.DisplayText = Session.UserTbls.FirstOrDefault(x => x.ID == u)?.Name;
            else if ((e.Column.FieldName == colDrawerID.FieldName|| e.Column.FieldName == colClosingDrwerID.FieldName) && e.Value is short d && d != 0)
                e.DisplayText = Session.Boxes.FirstOrDefault(x => x.ID == d)?.Name;
        }
        
        private void OpenNowtextEdit_EditValueChanged(object sender, EventArgs e)
        {
            var drp = OpenNowtextEdit.GetSelectedDataRow() as DrawerPeriod;
            if (drp == null) return;
            Reset();
            drawerPeriodBindingSource.DataSource = drp;
            GetMovePeriod();
            CurrPeriod.PeriodEnd = DateTime.Now;
            PeriodEndDateEdit.DateTime = DateTime.Now;
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
        List<BoxSummary> GetBoxSummaryFromInvoice()
        {
            using (var db = new PosDBDataContext(Program.ConnectionString))
            {
                var AllInvo = (from a in db.SupplyMains.AsNoTracking().Where(x => x.Date >= CurrPeriod.PeriodStart &&x.BoxId== CurrPeriod.DrawerID
                               && x.BrnId == CurrPeriod.BranchID && x.UserId == CurrPeriod.PeriodUserID && x.Status <= 12 && x.IsCash == 1).ToList()
                               select new
                               {
                                   a.No,
                                   a.Status,
                                   supBankAmount = a.BankAmount* PlusOrMinus((SupplyType)a.Status),
                                   paidCash = (a.Net - a.BankAmount) * PlusOrMinus((SupplyType)a.Status),
                                   a.Date,
                                   a.Net,
                               }).ToList();

                return (from a in AllInvo
                        group a by a.Status into s
                        select new BoxSummary
                        {
                            Count = s.Count(),
                            paidCash = s.Sum(x => x.paidCash),
                            BankAmount = s.Sum(x => x.supBankAmount),
                            Type = ClsSupplyStatus.GetString(s.Key,false,true),
                            SummaryDetails = (from s1 in s
                                              select new SummaryDetail
                                              {
                                                  No = s1.No,
                                                  OperType = ClsSupplyStatus.GetString(s.Key, false, true),
                                                  Date = ((DateTime)s1.Date).ToString("G"),
                                                  Net = Convert.ToDouble(s1.Net.ToString("n2")),
                                              }).ToList()
                        }).ToList();
            }
        }
        List<BoxSummary> GetBoxSummaryFromEntry()
        {
            if (boxAcc == null) return null;
            using (var db = new PosDBDataContext(Program.ConnectionString))
            {
                var AllEntry = (from a in db.EntryMains.AsNoTracking().Where(x => x.Date >= CurrPeriod.PeriodStart && x.BranchID == CurrPeriod.BranchID && x.UserID == CurrPeriod.PeriodUserID && x.Status <= 12).ToList()
                              join s in db.EntrySubs.AsNoTracking().Where(x =>x.AccNo == boxAcc.AccNo) on (a.ID) equals (s.ParentID)
                               select new
                               {
                                   a.No,
                                   a.Status,
                                   BankAmount =0,
                                   paidCash = Convert.ToDouble(((s.Madin ?? 0) - (s.Dain ?? 0)).ToString("n2")),
                                   a.Date,
                               }).ToList();

                return (from a in AllEntry
                        group a by a.Status into s
                        select new BoxSummary
                        {
                            Count = s.Count(),
                            paidCash = s.Sum(x => x.paidCash),
                            BankAmount = s.Sum(x => x.BankAmount),
                            Type = ClsEntryStatus.GetString((EntryType)s.Key),
                            SummaryDetails = (from s1 in s
                                              select new SummaryDetail
                                              {
                                                  No = s1.No,
                                                  OperType = ClsEntryStatus.GetString((EntryType)s.Key),
                                                  Date = ((DateTime)s1.Date).ToString("G"),
                                                  Net = Convert.ToDouble(s1.paidCash.ToString("n2")),
                                              }).ToList()
                        }).ToList();
            }
        }
        List<BoxSummary> BoxSummaryInvoice = new List<BoxSummary>();
        List<BoxSummary> BoxSummaryEntry = new List<BoxSummary>();
        void GetMovePeriod()
        {
            if (CurrPeriod.PeriodUserID == 0||CurrPeriod.DrawerID==0) return;
            BoxSummaryInvoice?.Clear();
            BoxSummaryEntry?.Clear();
            BoxSummaryInvoice = GetBoxSummaryFromInvoice();
            BoxSummaryEntry = GetBoxSummaryFromEntry();
            if(BoxSummaryEntry?.Count>0)
            BoxSummaryInvoice.AddRange(BoxSummaryEntry);

            gridControl1.DataSource = BoxSummaryInvoice;
            CurrPeriod.ClosingBalance = CurrPeriod.OpeningBalance + BoxSummaryInvoice.Sum(x => x.paidCash);
            CurrPeriod.AmountBank = BoxSummaryInvoice.Sum(x => x.BankAmount);
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
                CurrPeriod.PeriodEnd = DateTime.Now;
                PeriodEndDateEdit.DateTime = DateTime.Now;
                //XtraMessageBox.Show(text: " حدد تاريخ الاغلاق ", caption: "", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);
                //return true;
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
        return false;
        }
        double PlusOrMinus(SupplyType supplyType) => (supplyType) switch
        {
            SupplyType.Sales => 1,
            SupplyType.SalesRtrn => -1,
            SupplyType.Purchase => -1,
            SupplyType.PurchaseRtrn => 1,
        };
        Box boxAcc => Session.Boxes.FirstOrDefault(x => x.ID == CurrPeriod?.DrawerID);
        Box boxCloseAcc => Session.Boxes.FirstOrDefault(x => x.ID == CurrPeriod?.ClosingDrwerID);
        private void ClosePeriodButton_Click(object sender, EventArgs e)
        {
            if (ValidatValue()) return;
            using (var db = new PosDBDataContext(Program.ConnectionString))
            {
                try
                {
                    CurrPeriod.Status = true;
                    db.DrawerPeriods.DeleteAllOnSubmit(db.DrawerPeriods.Where(x => x.ID == CurrPeriod.ID));
                    db.DrawerPeriods.InsertOnSubmit(CurrPeriod);
                    db.SubmitChanges();
                    XtraMessageBox.Show(text: $" تم اغلاق الفتره رقم {CurrPeriod.ID } بنجاح", caption: "", icon: MessageBoxIcon.Information, buttons: MessageBoxButtons.OK);
                    ClosePeriodButton.Enabled = false;
                    DrawerPeriod Period = myFunaction.GetCopyOfDrawerPeriod(CurrPeriod);
                    Task.Run(() => PrintDrawer(Period));
                    if (Program.My_Setting.SendBoxDailyToServerOnSave)
                    {
                        if (SendDataDrawerToMain(CurrPeriod))
                        {
                            CurrPeriod.SendToserver = true;
                            db.SubmitChanges();
                        }
                    }
                }
                catch (Exception ex)
                {
                    ClsXtraMssgBox.ShowError(ex.Message);
                    return;
                }
            }
        }
        void PrintDrawer(DrawerPeriod Period)
        {
            ReportDrawerCashier rep = new ReportDrawerCashier(Period);
            rep.RequestParameters = false;
            rep.DisplayName = "يومية صندوق كاشير";
            myFunaction.PrintFile(PrintFileType.Printer,rep);
            //rep.Print();
            //new ReportForm(rep).ShowDialog();
        }
        bool SendDataDrawerToMain(DrawerPeriod drawerPeriod)
        {
            bool isSaved = false;
            try
            {
                MyFunaction myFunaction = new MyFunaction();
                if (Database.Exists(myFunaction.ConnectionString_AccDB()))
                {
                    using (var db = new AccDBDataContext(myFunaction.ConnectionString_AccDB()))
                    {

                        var accDra = myFunaction.GetCopyOfCurrentDrawerPeriod(drawerPeriod);
                        db.AccDrawerPeriods.InsertOnSubmit(accDra);
                        db.SubmitChanges();
                        isSaved = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ClsXtraMssgBox.ShowError(ex.Message);
                return false;
            }
            return isSaved;
        }
        private void RemainingBalanceTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (CurrPeriod == null) return;
            double rem = Convert.ToDouble(RemainingBalanceTextEdit.EditValue);
            CurrPeriod.RemainingBalance = rem;
            CurrPeriod.TransferdBalance = CurrPeriod.ActualBalance - rem;
            TransferdBalanceTextEdit.EditValue = CurrPeriod.TransferdBalance;
        }

        private void DrawerIDTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (DrawerIDTextEdit.EditValue == null) return;
            if (DrawerIDTextEdit.EditValue is short d && d>0)
            {
                OpenNowtextEdit.EditValue = null;
                CurrPeriod.DrawerID = d;
                SetOpeningBalance();
                GetMovePeriod();
            }
        }
    }
}
