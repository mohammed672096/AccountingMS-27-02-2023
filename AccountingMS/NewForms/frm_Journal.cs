using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Forms 
{
    public partial class frm_Journal : frm_Master 
    {
        public frm_Journal(string JournalID ="")
        {
            InitializeComponent(); 
            comboBoxEdit1.Properties.Items.AddRange(Master.Prossess);
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember  = "Name";
            if (JournalID == "")
                textEdit1.Text = GetNextID().ToString();
            else
                textEdit1.Text = JournalID;
        }
        int GetNextID()
        {
            DAL.ERPDataContext dbs = new DAL.ERPDataContext(Program.setting.con);

            try
            {
                return (int)dbs.Acc_Activities.Max(n => n.ID) + 1;

            }
            catch
            {
                return (int)1;


            }
        }
        public override void RefreshData()
        {
            base.RefreshData();
            lookUpEdit1.Properties.DataSource = CurrentSession.UserAccessbileStores.Select(x=> new { x.ID, x.Name }).ToList();

        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = 
            btn_Save.Enabled = (comboBoxEdit1.SelectedIndex == 20);
        }
        DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

        new void New()
        {
            dateEdit1.DateTime = db.GetSystemDate();
            lookUpEdit1.EditValue = CurrentSession.user.DefaultStore;
            comboBoxEdit1.SelectedIndex = 20;
            textEdit2.Text = textEdit1.Text;
            memoEdit1.Text = ""; 
        }
        DAL.Acc_Activity journal;
        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
             journal = db.Acc_Activities.Where(x => x.ID.ToString() == textEdit1.Text).FirstOrDefault();
            if(journal ==null)
            {
               this.New(); 
            }
            else
            {
                dateEdit1.DateTime = journal.Date;
                lookUpEdit1.EditValue = journal.StoreID;
                comboBoxEdit1.EditValue = journal.Type;
                textEdit2.Text = journal.TypeID;
                memoEdit1.Text = journal.Note;
                textEdit3.Text = db.St_Users.Where(x => x.ID == journal.UserID).Select(x => x.UserName).FirstOrDefault ();
                textEdit6.Text = journal.InsertDate.Value.ToString("yyyy-MM-dd hh:mm tt"); 
                textEdit4.Text = db.St_Users.Where(x => x.ID == journal.LastUpdateUserID).Select(x => x.UserName).FirstOrDefault();
                textEdit5.Text = journal.LastUpdateDate .Value.ToString("yyyy-MM-dd hh:mm tt");

            }
            gridControl1.DataSource = db.Acc_ActivityDetials 
         .Select<Acc_ActivityDetial , Acc_ActivityDetial>((Expression<Func<DAL.Acc_ActivityDetial, DAL.Acc_ActivityDetial>>)(x => x)).
         Where(x => x.AcivityID.ToString() == textEdit1.Text);

        }
    }
}
