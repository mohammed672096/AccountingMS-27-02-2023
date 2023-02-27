using AccountingMS.Forms.HR;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class UC_EmpSetting : DevExpress.XtraEditors.XtraUserControl
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        public UC_EmpSetting()
        {
            InitializeComponent();
            InitData();
            new ClsUserControlValidation(this, UserControls.EmpSetting);
        }

        private void TileItem6_ItemClick(object sender, TileItemEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            new ancestorW().Show();
            flyDialog.WaitForm(this, 0);
        }

        private void InitData()
        {
            //tblAccountBanksBindingSource.DataSource = this.clsTbBank.GetTblBankList;
            //bsiRecordsCount.Caption = "RECORDS : " + tblAccountBanksBindingSource.Count;
            //tblAccountBank gr = new tblAccountBank();
            //new ClsTblBranch().InitRepositoryItemBranchLookupEdit(gridControl, nameof(gr.bankBrnId));
        }

        private void TileItem19_ItemClick(object sender, TileItemEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            new formAddEmployee(null, null).Show();
            flyDialog.WaitForm(this, 0);

        }

        private void TileItem20_ItemClick(object sender, TileItemEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            new AttendingLeavingD().Show();
            flyDialog.WaitForm(this, 0);
        }

        private void TileItem2_ItemClick(object sender, TileItemEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            new GroupView().Show();
            flyDialog.WaitForm(this, 0);
        }

        private void TileItem11_ItemClick(object sender, TileItemEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            new AttLogs().Show();
            flyDialog.WaitForm(this, 0);
        }

        private void TileItem31_ItemClick(object sender, TileItemEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            new cashingEmployee().Show();
            flyDialog.WaitForm(this, 0);
        }

        private void TileItem3_ItemClick(object sender, TileItemEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            new DepartmentView().Show();
            flyDialog.WaitForm(this, 0);
        }

        private void TileItem9_ItemClick(object sender, TileItemEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            new FormalHoliday().Show();
            flyDialog.WaitForm(this, 0);
        }

        private void TileItem8_ItemClick(object sender, TileItemEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            new frmDiscounts().Show();
            flyDialog.WaitForm(this, 0);
        }

        private void TileItem7_ItemClick(object sender, TileItemEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            new frmRewards().Show();
            flyDialog.WaitForm(this, 0);
        }

        private void tileItem13_ItemClick(object sender, TileItemEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            new GroupView().Show();
            flyDialog.WaitForm(this, 0);
        }

        private void TileItem4_ItemClick(object sender, TileItemEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            new JobView().Show();
            flyDialog.WaitForm(this, 0);
        }

        private void TileItem12_ItemClick(object sender, TileItemEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            new OfficialVacationView().Show();
            flyDialog.WaitForm(this, 0);
        }

        private void TileItem5_ItemClick(object sender, TileItemEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            new ShiftView().Show();
            flyDialog.WaitForm(this, 0);
        }

        private void TileItem10_ItemClick(object sender, TileItemEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            new AbcenceRegulationView().Show();
            flyDialog.WaitForm(this, 0);
        }

        private void TileItem1_ItemClick(object sender, TileItemEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            new OvertimeAndDelayRegulationView().Show();
            flyDialog.WaitForm(this, 0);
        }

        private void tileItem18_ItemClick(object sender, TileItemEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            new ShiftView().Show();
            flyDialog.WaitForm(this, 0);
        }
    }
}
