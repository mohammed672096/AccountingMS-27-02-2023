using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace AccountingMS
{
    class ClsTblBranch
    {

        public ClsTblBranch(bool Refrech = false)
        {
            if (Session.Branches.Count <= 0 || Refrech)
                Session.GetDataBranches();
        }
        public List<tblBranch> GetBranchList() => Session.Branches;
        public tblBranch GetBranchDataById(short brnId) => Session.Branches.FirstOrDefault(x => x.brnId == brnId);
        public short GetNewBranchNo() => (short)((Session.Branches?.Max(x => x?.brnNo) ?? 0) + 1);
        public bool IsBranchNoFound(short brnNo) => Session.Branches.Any(x => x.brnNo == brnNo);
        public string GetBranchName(short brnId) => Session.Branches?.FirstOrDefault(x => x.brnId == brnId)?.brnName;

        public void InitBranchLookupEdit(LayoutControlGroup layoutControlGroup, BindingSource bindingSource, string colBrnId)
        {
            // if (MySetting.GetPrivateSetting.EveryBranchOnly) return;
            if (Session.CurrentUser.id != 1) return;
            LookUpEdit BranchLookupEdit = new LookUpEdit();
            BranchLookupEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            BranchLookupEdit.Properties.Appearance.Options.UseTextOptions = true;
            BranchLookupEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            BranchLookupEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("brnId",MySetting.GetPrivateSetting.LangEng? "Branch number":"رقم الفرع", 11, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("brnNo", MySetting.GetPrivateSetting.LangEng? "Branch number":"رقم الفرع", 11, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("brnName",MySetting.GetPrivateSetting.LangEng? "Branch name":"إسم الفرع", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            //if (!Session.Branches.Any(x => x.brnNo == 0))
            //{
            //    tblBranch bra = new tblBranch { brnNo = 0, brnName = "كل الفروع" };
            //    Session.Branches.Insert(0, bra);
            //}

            BranchLookupEdit.Properties.DataSource = Session.Branches;
            BranchLookupEdit.Properties.DisplayMember = "brnName";

            BranchLookupEdit.Properties.NullText = "";
            BranchLookupEdit.Properties.ValueMember = "brnId";
            BranchLookupEdit.DataBindings.Add(new Binding("EditValue", bindingSource, colBrnId, true, DataSourceUpdateMode.OnPropertyChanged));
            LayoutControlItem ItemForbranch = new LayoutControlItem();
            layoutControlGroup.Add(ItemForbranch);
            ItemForbranch.Control = BranchLookupEdit;
            ItemForbranch.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            ItemForbranch.CustomizationFormText = MySetting.GetPrivateSetting.LangEng ? "Branch" : "الفرع:";
            ItemForbranch.Location = new System.Drawing.Point(0, 84);
            ItemForbranch.Name = "ItemForbranch";
            ItemForbranch.Size = new System.Drawing.Size(692, 74);
            ItemForbranch.Text = MySetting.GetPrivateSetting.LangEng ? "Branch:" : "الفرع:";
            ItemForbranch.TextSize = new System.Drawing.Size(94, 23);
        }
        public void InitRepositoryItemBranchLookupEdit(GridControl grid, string BrnId)
        {
            //if (MySetting.GetPrivateSetting.EveryBranchOnly) return;
            if (Session.CurrentUser.id != 1) return;
            RepositoryItemLookUpEdit repo = new RepositoryItemLookUpEdit();
            repo.DataSource = Session.Branches;
            repo.DisplayMember = "brnName";
            repo.ValueMember = "brnId";
            if (grid != null)
                grid.RepositoryItems.Add(repo);
            GridView v = (GridView)grid.MainView;
            GridColumn colBrnId = new GridColumn();
            colBrnId.Name = "BrnId";
            colBrnId.Caption = MySetting.GetPrivateSetting.LangEng ? "Branch" : "الفرع";
            colBrnId.FieldName = BrnId;
            //var col= v.Columns.FirstOrDefault(x => x.Name == colBrnId.Name);
            v.Columns.Remove(v.Columns.FirstOrDefault(x => x.Name == colBrnId.Name));
            //foreach (GridColumn item in v.Columns)
            //{
            //    if (item.Name == colBrnId.Name)
            //    {
            //        v.Columns.Remove(item);
            //        break;
            //    }
            //}
            colBrnId.MinWidth = 27;
            colBrnId.OptionsColumn.ShowInCustomizationForm = false;
            colBrnId.Visible = true;
            //colBrnId.VisibleIndex = 3;
            colBrnId.Width = 180;
            colBrnId.ColumnEdit = repo;
            v.Columns.Add(colBrnId);
        }

    }
}
