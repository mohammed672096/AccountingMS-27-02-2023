using DevExpress.XtraBars;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace AccountingMS
{
    public partial class UCsupplyVocher : DevExpress.XtraEditors.XtraUserControl
    {
        accountingEntities db = new accountingEntities();
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();

        private dynamic tbSupplySub;

        private void UCstoreVocher_Load(object sender, EventArgs e)
        {
            InitData();
        }
        private void InitData()
        {
            var q1 = from supMain in db.tblSupplyMains
                     where supMain.supBrnId == Session.CurBranch.brnId && supMain.supStatus == 2
                     select supMain;

            bindingSource1.DataSource = q1.ToList();
            tbSupplySub = db.tblSupplySubs.Where(x => x.supBrnId == Session.CurBranch.brnId).ToList();
            bsiRecordsCount.Caption = "RECORDS : " + bindingSource1.Count;
        }
        public UCsupplyVocher()
        {
            InitializeComponent();
            gridView.MasterRowGetRelationCount += GridView_MasterRowGetRelationCount;
            gridView.MasterRowEmpty += GridView_MasterRowEmpty;
            gridView.MasterRowGetChildList += GridView_MasterRowGetChildList;
            gridView.MasterRowGetRelationName += GridView_MasterRowGetRelationName;
        }

        private void GridView_MasterRowGetRelationCount(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }
        private void GridView_MasterRowEmpty(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs e)
        {
            e.IsEmpty = false;
        }
        private void GridView_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            BindingList<tblSupplySub> childList = new BindingList<tblSupplySub>();
            int supNo = Convert.ToInt32(gridView.GetFocusedRowCellValue("supNo"));

            foreach (var supplySub in tbSupplySub)
            {
                if (supplySub.supNo == supNo && supplySub.supStatus == 2)
                    childList.Add(supplySub);
            }
            e.ChildList = childList;
            gridView1.ViewCaption = "أمر صرف مخزني رقم: " + supNo;
        }
        private void GridView_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Level1";
        }

        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        public void RefreshListDialog(string name, bool isNew)
        {
            if (isNew)
                flyDialog.ShowDialogUC(this, name);
            else
                flyDialog.ShowDialogUCUpdMsg(this, name);

            InitData();
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            //flyDialog.WaitForm(this, 1);
            //new formAddSupplyVoucher(null, null, this, (SupplyType)1).Show();
            //flyDialog.WaitForm(this, 0);
        }
    }
}
