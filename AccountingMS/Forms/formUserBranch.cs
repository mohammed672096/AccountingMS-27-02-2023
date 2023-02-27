using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formUserBranch : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblUser clsTbUser = null;
        ClsTblBranch clsTbBranch = null;
        ClsTblUserBranch clsTbUserBranch = null;

        private short usrId;

        public formUserBranch()
        {
            InitializeComponent();

            this.Load += FormUserBranch_Load;
            userNameTextEdit.EditValueChanged += UserNameTextEdit_EditValueChanged;
        }

        private async void FormUserBranch_Load(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);

            await Task.Run(() => InitDataAsync());

            tblUserBindingSource.DataSource = this.clsTbUser.GetUserListNoAdmin.ToList();
            tblBranchBindingSource.DataSource = this.clsTbBranch.GetBranchList();

            flyDialog.WaitForm(this, 0);
            userNameTextEdit.EditValue = null;
        }

        private async Task InitDataAsync()
        {
            IList<Task> taskList = new List<Task>();
            taskList.Add(Task.Run(() => this.clsTbUser = new ClsTblUser()));
            taskList.Add(Task.Run(() => this.clsTbBranch = new ClsTblBranch()));
            taskList.Add(Task.Run(() => this.clsTbUserBranch = new ClsTblUserBranch()));

            await Task.WhenAll(taskList);
        }

        private void UserNameTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;

            this.usrId = Convert.ToInt16(editor.EditValue);
            SetUserBranhcData(Convert.ToInt16(editor.EditValue));
        }

        private void SetUserBranhcData(short usrId)
        {
            for (short i = 0; i < gridView1.DataRowCount; i++)
            {
                if (this.clsTbUserBranch.IsUserBranchFound(usrId, Convert.ToInt16(gridView1.GetRowCellValue(i, colbrnId))))
                    gridView1.SelectRow(i);
                else
                    gridView1.UnselectRow(i);
            }
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            if (!ValidateBranchGrid()) return;

            flyDialog.WaitForm(this, 1);

            if (!SaveData()) return;
            this.clsTbUserBranch = new ClsTblUserBranch();

            flyDialog.WaitForm(this, 0);

            string mssg = $"صلاحيات فروع المستخدم: {this.clsTbUser.GetUserNameById(this.usrId)}";
            flyDialog.ShowDialogForm(this, mssg);


        }

        private bool SaveData()
        {
            var tbUserBranchList = new List<tblUserBranch>();

            for (short i = 0; i < gridView1.DataRowCount; i++)
            {
                if (gridView1.IsRowSelected(i))
                    tbUserBranchList.Add(new tblUserBranch()
                    {
                        usrId = this.usrId,
                        brnId = Convert.ToInt16(gridView1.GetRowCellValue(i, colbrnId))
                    });
            }

            return this.clsTbUserBranch.Save(tbUserBranchList, this.usrId);
        }

        private bool ValidateBranchGrid()
        {
            bool isValid = gridView1.GetSelectedRows().Count() >= 1 ? true : false;

            if (!isValid) ClsXtraMssgBox.ShowError("عذراَ يجب إختيار صلاحيات الفروع للمستخدم أولاً");

            return isValid;
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
