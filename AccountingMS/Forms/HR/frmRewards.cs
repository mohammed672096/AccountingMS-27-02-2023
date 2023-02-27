using DevExpress.XtraEditors;
using Hassib.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS.Forms.HR
{
    public partial class frmRewards : MasterView
    {

        accountingEntities db = new accountingEntities();
        ClsTblBox clsTbBox = new ClsTblBox();
        ClsTblAccount clsTbAccount = new ClsTblAccount();
        ClsTblCurrency clsTbCurrency = new ClsTblCurrency();
        ClsTblCustomer clsTbCustomer = new ClsTblCustomer();
       
        private static frmRewards instance;
        public static frmRewards Instance { get { if (instance == null || instance.IsDisposed == true) instance = new frmRewards(); return instance; } }


        accountingEntities context;
        public Reward reward { get => rewardBindingSource.Current as Reward; set => rewardBindingSource.DataSource = value; }

        public frmRewards()
        {
            InitializeComponent();
            DisableValidation(dataLayoutControl1);
            context = new accountingEntities();
            empidTextEdit.Properties.DataSource = context.tblEmployees.ToList();
            repositoryItemLookUpEdit1.DataSource = context.tblEmployees.ToList();
            gridView1.AddEditButton(RepositoryItemButtonEdit1_Click);
            gridView1.SetAlternatingColors();
            this.Shown += FrmRewards_Shown;
        }

        private void FrmRewards_Shown(object sender, EventArgs e)
        {
            if (reward == null)
                New();
        }
        private void RepositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            Reward row = gridView1.GetRow(gridView1.FocusedRowHandle) as Reward;
            if (row != null)
                GoTo(row.id);
        }
        public void GoTo(int id)
        {
            var sourceDepr = context.Rewards.SingleOrDefault(x => x.id == id);
            if (sourceDepr != null)
            {
                reward = sourceDepr;
                DataChanged = false;
                IsNew = false;
            }
            else
            {
                XtraMessageBox.Show("المستند غير موجود ");
            }
        }

        public override void New()
        {
            reward = new Reward() { };
            base.New();
        }
        public void SetData()
        {
            reward.empid = Convert.ToInt32(empidTextEdit.EditValue);
            reward.dateAncestor = dateAncestorDateEdit.DateTime;
            reward.amount = Convert.ToDouble(amountTextEdit.EditValue);
            reward.reason = reasonTextEdit.Text;
        }
        public override void Save()
        {
            if (empidTextEdit.Text == String.Empty)
            {
                XtraMessageBox.Show("ادخل اسم الموظف أولا ");
                return;
            }
            //EnableValidation(dataLayoutControl1);
            //if (this.ValidateChildren() == false)
            //    return;
            //DisableValidation(dataLayoutControl1);
            SetData();
            //SaveEntrySubData();
            context.Rewards.AddOrUpdate(reward);
            context.SaveChanges();
            base.Save();
            RefreshData();
        }

        //حساب الصندوق
        //private void SaveEntrySubData()
        //{
        //    //this.tbEntMain.entTotalTax = GetTotalTax();//الضريبة
        //    var empyid = db.tblEmployees.Find(Convert.ToInt32(empidTextEdit.EditValue));
        //    var accbox = db.tblAccountBoxes.FirstOrDefault(m => m.id == empyid.empCurrency);
        //    var entmaall = db.tblEntryMains.ToList();
        //    int entma = 0;
        //    if (entmaall.Count() == 0)
        //         entma = 0;
        //    else
        //         entma = db.tblEntryMains.Max(x => x.id);
        //    entma = entma + 1;

        //    tblEntryMain entMain = new tblEntryMain()
        //    {
        //        entNo = entma, // Convert.ToInt32(entNoTextEdit.Text),  //رقم السند
        //        entBoxNo = Convert.ToInt32( textEdit1.EditValue), //رقم الصندوق
        //        entRefNo = 6,                    //رقم الصندوق
        //        entCurrency = Convert.ToByte(accbox.id),                    //رقم الصندوق
        //        entAmount = Convert.ToDouble(amountTextEdit.Text),  //المكافأة
        //        entDate = dateAncestorDateEdit.DateTime, //التاريخ
        //        entDesc = empidTextEdit.Text, //يصرف الى
        //        entTotalTax = 0,
        //        //entCurChange = 0,// (accbox.boxCurrency > 1) ? Convert.ToInt16(entCurrencyChngTextEdit.EditValue) : (short)0, //لو العملة غير ريال
        //        entBrnId = empyid.empBrnId, // الفرع
        //        entStatus = 5
        //    };
        //    db.tblEntryMains.AddOrUpdate(entMain);

        //    tblEntrySub entSubMain = new tblEntrySub()
        //    {

        //        entNo = entma , // Convert.ToInt32(entNoTextEdit.Text),  //رقم السند
        //        entAccNo = empyid.empAccNo,                    //رقم الصندوق
        //        entAccName = accbox.boxName, //اسم الصندوق
        //        entBoxNo = accbox.boxNo, //رقم الصندوق
        //        entCredit = Convert.ToDouble(amountTextEdit.Text),  //المكافأة
        //        entDate = dateAncestorDateEdit.DateTime, //التاريخ
        //        entDesc = empidTextEdit.Text, //يصرف الى
        //        //entTaxPrice = GetTotalTax(),
        //        entCurrency = Convert.ToByte(accbox.id), // رقم العملة
        //        entCurChange = 0,// (accbox.boxCurrency > 1) ? Convert.ToInt16(entCurrencyChngTextEdit.EditValue) : (short)0, //لو العملة غير ريال
        //        entView = 1,
        //        entBrnId = empyid.empBrnId, // الفرع
        //        entIsMain = 1,
        //        entEqfal = 2,
        //        entStatus = 5
        //    };
        //    db.tblEntrySubs.AddOrUpdate(entSubMain);
        //    tblEntrySub entSub = new tblEntrySub()
        //    {

        //        entNo = entma , // Convert.ToInt32(entNoTextEdit.Text),  //رقم السند
        //        entAccNo = empyid.empAccNo,                    //رقم الصندوق
        //        entAccName = accbox.boxName, //اسم الصندوق
        //        entBoxNo = accbox.boxNo, //رقم الصندوق
        //        entDebit = Convert.ToDouble(amountTextEdit.Text),  //المكافأة
        //        entDate = dateAncestorDateEdit.DateTime, //التاريخ
        //        entDesc = empidTextEdit.Text, //يصرف الى
        //        //entTaxPrice = GetTotalTax(),
        //        entCurrency = Convert.ToByte(accbox.id), // رقم العملة
        //        entCurChange = 0,// (accbox.boxCurrency > 1) ? Convert.ToInt16(entCurrencyChngTextEdit.EditValue) : (short)0, //لو العملة غير ريال
        //        entView = 1,
        //        entBrnId = empyid.empBrnId, // الفرع
        //        entIsMain = 1,
        //        entEqfal = 2,
        //        entStatus = 5
        //    };
     
        //    db.tblEntrySubs.AddOrUpdate(entSub);
        //    db.SaveChanges();
        //}




        public override void RefreshData()
        {
            gridControl1.DataSource = context.Rewards.ToList();
            base.RefreshData();
        }
        public override void Delete()
        {
            if (empidTextEdit.Text == String.Empty)
            {
                XtraMessageBox.Show("حدد الاسم التى تريد حذفها ");
                return;
            }
            context.Rewards.Remove(reward);
            context.SaveChanges();
            base.Delete();
            New();
            RefreshData();
        }

        private void frmRewards_Load(object sender, EventArgs e)
        {
           // this.TopMost = true;
        }

       
    }
}