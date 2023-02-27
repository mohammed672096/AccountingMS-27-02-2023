using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblAccount
    {
        ICollection<tblAccount> tbAccountList = new Collection<tblAccount>();

        public ClsTblAccount()
        {
            InitData();
        }
        public class AccountBalance
        {
            public AccountBalance(long AccNumber)
            {
                NewMethod(AccNumber);
            }
            public AccountBalance(long AccNumber, DateTime _dateTime)
            {
                dateTime = _dateTime;
                NewMethod(AccNumber);
            }

            void NewMethod(long AccNumber)
            {
                using (accountingEntities db = new accountingEntities())
                {
                    var assets = db.tblAssets.Where(x => x.asAccNo == AccNumber & x.asBrnId == Session.CurBranch.brnId).AsQueryable();
                    if (dateTime != null && dateTime.Year > 1950)
                        assets = assets.Where(x => x.asDate <= dateTime);

                    assets = assets.Where(x => x.asDate >= Session.CurrentYear.fyDateStart && x.asDate <= Session.CurrentYear.fyDateEnd);
                    Credit = assets.Where(x => x.asAccNo == AccNumber).Sum(x => (double?)x.asCredit) ?? 0;
                    Debit = assets.Where(x => x.asAccNo == AccNumber).Sum(x => (double?)x.asDebit) ?? 0;
                }
            }
            public double Balance { get { return Math.Abs(Debit - Credit); } }
            DateTime dateTime;
            double Credit;
            double Debit;
            public bool IsDebit { get { return (Debit - Credit) > 0; } }
            public string Type
            {
                get
                {
                    var balance = Debit - Credit;
                    if (balance > 0) return MySetting.GetPrivateSetting.LangEng ? "Debit" : "مدين";
                    else if (balance < 0) return MySetting.GetPrivateSetting.LangEng ? "Credit" : "دائن";
                    else return string.Empty;
                }

            }
        }



        public bool CanDelete(tblAccount tbAccount)
        {
            if (tbAccount == null) return false;
            AccountBalance accountBalance = new AccountBalance(tbAccount.accNo);
            if (accountBalance.Balance != 0)
            {
                XtraMessageBox.Show((!MySetting.GetPrivateSetting.LangEng) ?
                              string.Format("لا يمكن حذف الحساب: {0} لوجود ارصدة معلقة", tbAccount.accName) :
                              string.Format("Cannot delete account: {0} due to pending balances", tbAccount.accName), "Info");
                return false;
            }
            return true;
        }
        private void InitData()
        {
            Session.GetDataAccounts();
            if (Session.CurrentUser.id == 1)
                this.tbAccountList = Session.Accounts.AsQueryable().OrderBy(z => z.accNo.ToString()).ToList();
            else
                this.tbAccountList = Session.Accounts.AsQueryable().Where(x => x.accBrnId == Session.CurBranch.brnId || x.accBrnId == 1 | x.accBrnId == 0).OrderBy(z => z.accNo.ToString()).ToList();
        }
        public IEnumerable<tblAccount> GetAccountList => this.tbAccountList.ToList();
        public IEnumerable<tblAccount> GetAccountListWhereLevelNtEqual6() => this.tbAccountList.Where(x => x.accLevel != 6);
        public IEnumerable<tblAccount> GetAccountListByLevel(byte level) => this.tbAccountList.Where(x => x.accLevel == level);
        public class AccountTemp
        {
            public long entAccNo { get { return accNo; } }
            public string entAccName { get { return accName; } }
            public long accNo { get; set; }
            public string accName { get; set; }
            public Nullable<byte> accCurrency { get; set; }
        }
        public IEnumerable<AccountTemp> GetAccountTemp()
        {
            return this.tbAccountList.Where(x => x.accType == 2 && x.accBrnId == Session.CurBranch.brnId).Select(x => new AccountTemp
            {
                accNo = x.accNo,
                accName = x.accName,
                accCurrency = x.accCurrency,
            }).ToList();
        }
        public IEnumerable<tblAccount> GetAccountListType2ByParent(int accParent)
        {
            return this.tbAccountList.Where(x => x.accType == 2 && x.accParent.ToString().StartsWith(accParent.ToString()));
        }
        public IEnumerable<tblAccount> GetAccountListType2()
        {
            return this.tbAccountList.Where(x => x.accType == 2 /*&& x.accBrnId == Session.CurBranch.brnId*/);
        }

        public IEnumerable<tblAccount> GetAccountListType2WhereAccNoNotEqualTo(long accNo)
        {
            return this.tbAccountList.Where(x => x.accType == 2 && x.accNo != accNo /*&& x.accBrnId == Session.CurBranch.brnId*/);
        }

        public IEnumerable<tblAccount> GetAccountListType2LocalCurrency()
        {
            return this.tbAccountList.Where(x => x.accType == 2 && x.accCurrency == 1 /*&& x.accBrnId == Session.CurBranch.brnId*/).OrderBy(x => x.accNo);
        }

        public IEnumerable<tblAccount> GetAccountListType2FrgnCurrency()
        {
            return this.tbAccountList.Where(x => x.accType == 2 && x.accCurrency > 1/* && x.accBrnId == Session.CurBranch.brnId*/).OrderBy(x => x.accNo);
        }

        public IEnumerable<tblAccount> GetAccountListCategoery1nd2()
        {
            return this.tbAccountList.Where(x =>/* x.accBrnId == Session.CurBranch.brnId &&*/ x.accType == 2 && (x.accCat == 1 || x.accCat == 2));
        }

        public IEnumerable<tblAccount> GetAccountListCategoery3nd4()
        {
            return this.tbAccountList.Where(x => /*x.accBrnId == Session.CurBranch.brnId &&*/ x.accType == 2 && (x.accCat == 3 || x.accCat == 4));
        }

        public IEnumerable<tblAccount> GetAccountListCategoery3()
        {
            return this.tbAccountList.Where(x => /*x.accBrnId == Session.CurBranch.brnId && */x.accType == 2 && x.accCat == 3);
        }

        public IEnumerable<tblAccount> GetAccountListByCategoeryNdCurId(byte accCat, byte accCurId)
        {
            return this.tbAccountList.Where(x => /*x.accBrnId == Session.CurBranch.brnId &&*/ x.accType == 2 && x.accCat == accCat && x.accCurrency == accCurId).ToList();
        }

        public tblAccount GetAccountObjById(int accId)
        {
            return this.tbAccountList.FirstOrDefault(x => x.id == accId);
        }

        public tblAccount GetAccountObjByNo(long accNo)
        {
            return this.tbAccountList.FirstOrDefault(x => x.accNo == accNo);
        }

        public long GetAccountNoById(int accId)
        {
            return this.tbAccountList.Where(x => x.id == accId).Select(x => x.accNo).FirstOrDefault();
        }

        public string GetAccountNameByNo(long accNo)
        {
            using (var db = new accountingEntities())
                return db.tblAccounts?.FirstOrDefault(x => x.accNo == accNo)?.accName;
        }
        public string GetAccountNameByNo2(long accNo) => this.tbAccountList?.FirstOrDefault(x => x.accNo == accNo)?.accName;
        public byte GetAccountCategoreyByAccNo(int accNo) => Convert.ToByte(this.tbAccountList?.FirstOrDefault(x => x.accNo == accNo)?.accCat);

        public bool IsAccNoFound(long accNo) => this.tbAccountList.Any(x => x.accNo == accNo);

        public bool UpdateAccNameByAccNo(long accNo, string accName)
        {
            using (accountingEntities db = new accountingEntities())
            {
                if (db.tblAccounts.Any(x => x.accNo == accNo))
                    db.tblAccounts.FirstOrDefault(x => x.accNo == accNo).accName = accName;
                return ClsSaveDB.Save(db, LogHelper.GetLogger());
            }
        }
        public bool DeleteByAccNo(long accNo)
        {
            using (accountingEntities db = new accountingEntities())
            {
                var tbAccount = db.tblAccounts?.FirstOrDefault(x => x.accNo == accNo);
                if (tbAccount == null) return false;
                if (!CanDelete(tbAccount)) return false;
                db.tblAccounts.Remove(tbAccount);
                return ClsSaveDB.Save(db, LogHelper.GetLogger());
            }
        }
        public long GetNewAccNo(string accNo)
        {
            IList<tblAccount> tbAccNoList = this.tbAccountList.Where(x => x.accNo.ToString().StartsWith(accNo)).OrderByDescending(x => x.accNo).ToList();
            int count = tbAccNoList.Count();
            long newAccNo = (count == 1) ? long.Parse(tbAccNoList.FirstOrDefault().accNo + "0001") : tbAccNoList.Select(x => x.accNo).FirstOrDefault() + 1;

            return newAccNo;
        }
        public long GetNewAccNoMain(string accNo)
        {
            IList<tblAccount> tbAccNoList = this.tbAccountList.Where(x => x.accNo.ToString().StartsWith(accNo) & x.accLevel < MySetting.DefaultSetting.dfltAccLevel).OrderByDescending(x => x.accNo).ToList();
            int count = tbAccNoList.Count();
            long newAccNo = 0;
            newAccNo = (count == 1) ? long.Parse(tbAccNoList.FirstOrDefault().accNo + "01") : tbAccNoList.Select(x => x.accNo).FirstOrDefault() + 1;

            return newAccNo;
        }

        public bool Add(DefaultAccType defaultAccType, long accNo, string accName, byte accCurrency, byte accCategorey, short BrnId)
        {
            var def = ClsTblDefaultAccount.tbDefaultAccountList?.FirstOrDefault(x => x?.dflStatus == (byte)defaultAccType && x?.dfltBrnId == BrnId);
            if (def == null) return false;
            using (accountingEntities db = new accountingEntities())
            {
                var acc = new tblAccount()
                {
                    accParent = Convert.ToInt32(GetAccountNoById(def.dflAccNo)),
                    ParentID = def.dflAccNo,
                    accNo = accNo,
                    accName = accName,
                    accCurrency = accCurrency,
                    accCat = accCategorey,
                    accLevel = 6,
                    accType = 2,
                    accBrnId = BrnId,
                    accStatus = 1
                };
                db.tblAccounts.Add(acc);
                if(ClsSaveDB.Save(db, LogHelper.GetLogger()))
                {
                    Session.Accounts.Add(acc);
                    return true;
                }
                return false;
            }
        }



        public void InitAccountLookupEdit(LookUpEdit accountLookupEdit,int accParent=0)
        {
            accountLookupEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("accNo", "رقم الحساب", 40, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("accName", "إسم الحساب", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            if(accParent>0)
            accountLookupEdit.Properties.DataSource = GetAccountListType2ByParent(accParent);
            else accountLookupEdit.Properties.DataSource = GetAccountListType2();
            accountLookupEdit.Properties.ValueMember = "accNo";
            accountLookupEdit.Properties.DisplayMember = "accName";
        }

        public void InitAccountRepositoryLookupEdit(RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit, string valueMember = "accNo", string displayMember = "accName")
        {
            repositoryItemGridLookUpEdit.DataSource = GetAccountTemp();
            repositoryItemGridLookUpEdit.ValueMember = valueMember;
            repositoryItemGridLookUpEdit.DisplayMember = displayMember;
            var view = repositoryItemGridLookUpEdit.View;
            repositoryItemGridLookUpEdit.NullText = "";
            repositoryItemGridLookUpEdit.ValidateOnEnterKey = true;
            repositoryItemGridLookUpEdit.ImmediatePopup = true;
            repositoryItemGridLookUpEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            repositoryItemGridLookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;


            view.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
            view.OptionsSelection.UseIndicatorForSelection = true;
            view.OptionsView.ShowAutoFilterRow = true;
            view.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;

            view.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            new DevExpress.XtraGrid.Columns.GridColumn{ FieldName ="accNo",Caption="رقم الحساب",Visible = true,  VisibleIndex =0},
            new DevExpress.XtraGrid.Columns.GridColumn{ FieldName ="accName",Caption="إسم الحساب",Visible = true,  VisibleIndex = 1 },
            });
        }
        public void InitAccountRepositoryLookupEdit(RepositoryItemLookUpEdit repositoryItemLookUpEdit, string valueMember)
        {
            repositoryItemLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("accNo", "رقم الحساب", 11, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("accName", "إسم الحساب", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            repositoryItemLookUpEdit.DataSource = GetAccountListType2();
            repositoryItemLookUpEdit.ValueMember = valueMember;
            repositoryItemLookUpEdit.DisplayMember = valueMember;
        }

    }
}
