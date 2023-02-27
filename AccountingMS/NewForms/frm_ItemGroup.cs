using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Columns;

namespace ERP.Forms
{
    public partial class frm_ItemGroup : frm_Master 
    {
        DAL.ERPDataContext objDataContext = new DAL.ERPDataContext(Program.setting.con);
      
    
      
        public frm_ItemGroup()
        {
            InitializeComponent();
        }

     
        public override void frm_Load(object sender, EventArgs e)
        {
            base.frm_Load(sender, e);
            FillData();
            treeList1.ParentFieldName = "ParentID";
            treeList1.KeyFieldName = "Number";
            textEdit2.Properties.DisplayMember = "Name";
            textEdit2.Properties.ValueMember = "Number";
            btn_Print.Visibility = BarItemVisibility.Never;


        }

        void FillData()
        {
            var group = from g in objDataContext.Inv_ItemGroups select g;
            treeList1.DataSource = group.ToList();
            textEdit2.Properties.DataSource =  group.ToList();
        }
     
        public override void New()
        {
            if (ChangesMade && !SaveChangedData()) return;
            textEdit1.Text = "";
            IsNew = true;
            textEdit2.EditValue = treeList1.FocusedNode.GetValue("Number");
            ChangesMade = false;
        }
        DAL.Inv_ItemGroup grp = new DAL.Inv_ItemGroup ();
        int GetNewNumber(int? parent)
        {
            try
            {
                return  (int)objDataContext.Inv_ItemGroups.Where(n => n.ParentID == parent).Max(n => n.Number) +1;

            }
            catch
            {
                return (int)parent * 100 + 1;


            }

        }
        public override void Save()
        {
           // if (IsNew && !CanAdd) { XtraMessageBox.Show(LangResource.CantAddNoPermission, "", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
          if (CanSave() == false) return;

            if (textEdit1.Text == string.Empty ) { return;  }
            int nodeID;
            if(IsNew)
             
            {
                DAL.Inv_ItemGroup NewGroup = new DAL.Inv_ItemGroup();
                NewGroup.ParentID = Convert.ToInt32(treeList1.FocusedNode.GetValue("Number"));
                NewGroup.Number = GetNewNumber(NewGroup.ParentID);
                NewGroup.Name = textEdit1.Text;
                objDataContext.Inv_ItemGroups.InsertOnSubmit(NewGroup);
                nodeID = NewGroup.Number;
            }
            else
            {
               grp.Name = textEdit1.Text;
               nodeID = grp.Number;
            }
            if (nodeID == 1) return;
            objDataContext.SubmitChanges();
             
            PartNumber = nodeID.ToString();
            PartName = textEdit1.Text;
            base.Save();

            IsNew = false;
            FillData();
            treeList1.SetFocusedNode(treeList1.FindNodeByFieldValue ("Number",nodeID));
            ChangesMade= false ;
        }
        public override void Delete()
        {
  //if (!CanPerformDelete()) return;
            if (IsNew) return;
            if (treeList1.FocusedNode.GetValue("Number").ToString() == "1") return;
            var items = from i in objDataContext.Inv_Items where i.GroupID == grp.Number select i.ID;
            if (items.Count() > 0)
            {
                XtraMessageBox.Show(LangResource.CantDeleteGroupHasItems, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }  
            if(treeList1.FocusedNode.HasChildren)
            {
                XtraMessageBox.Show(LangResource.CantDeleteGroupHasChild, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Master.AskForDelete(this, IsNew, "Item Group" , grp.Number.ToString()))
            {
                PartNumber =  grp.Number.ToString();
                PartName = textEdit1.Text;
                objDataContext.Inv_ItemGroups.DeleteOnSubmit(grp);
                objDataContext.SubmitChanges();
                base.Delete();
                FillData();
                New();
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            ChangesMade = true; 

        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
           if (e.Node != null)
            {
                grp = objDataContext.Inv_ItemGroups.Single(g => g.Number == Convert.ToInt32(e.Node.GetValue("Number")));
                textEdit1.Text = grp.Name;
                textEdit2.EditValue  = treeList1.FocusedNode.GetValue("ParentID") ;
            }
            IsNew = false; 
            ChangesMade = false;
           
        }

        private void frm_ItemGroup_Load(object sender, EventArgs e)
        {

        }
    }
}