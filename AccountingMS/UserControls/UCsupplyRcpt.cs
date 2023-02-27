using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace AccountingMS
{
    public partial class UCsupplyRcpt : XtraUserControl
    {
        accountingEntities db = new accountingEntities();
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();

        private dynamic tbSupplySub;

        private void UCsupplyRcpt_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void InitData()
        {
            var q1 = from supMain in db.tblSupplyMains
                     where supMain.supBrnId == Session.CurBranch.brnId && supMain.supStatus == 1
                     select supMain;

            this.tbSupplySub = db.tblSupplySubs.Where(x => x.supBrnId == Session.CurBranch.brnId).ToList();
            bindingSource1.DataSource = q1.ToList();
            bsiRecordsCount.Caption = "RECORDS : " + bindingSource1.Count;
        }

        public UCsupplyRcpt()
        {
            InitializeComponent();
            //gridView.OptionsDetail.DetailMode = DetailMode.Embedded;

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
            BindingList<tblSupplySub> childlist = new BindingList<tblSupplySub>();
            int supNo = Convert.ToInt32(gridView.GetFocusedRowCellValue("supNo"));

            foreach (var supplySub in this.tbSupplySub)
            {
                if (supplySub.supNo == supNo)
                    childlist.Add(supplySub);
            }
            e.ChildList = childlist;
            gridView1.ViewCaption = "أمر توريد مخزني رقم: " + supNo;
        }
        private void GridView_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Level1";
        }

        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            //flyDialog.WaitForm(this, 1);
            //new formAddSupplyRcpt(null, null, this, this.su).Show();
            //flyDialog.WaitForm(this, 0);
        }

        public void RefreshListDialog(string name, bool isNew)
        {
            if (name != null)
                flyDialog.ShowDialogUC(this, name);

            InitData();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            ArrayList list = new ArrayList();

            for (short i = 0; i < gridView.SelectedRowsCount; i++)
            {
                if (gridView.GetSelectedRows()[i] >= 0)
                {
                    list.Add(Convert.ToInt32(gridView.GetRowCellValue(gridView.GetSelectedRows()[i], gridView.Columns[0])));
                }
            }

            for (short i = 0; i < list.Count; i++)
                XtraMessageBox.Show(list.ToString());

            list.Clear();
        }

    }
}
