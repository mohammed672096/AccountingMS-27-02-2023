using PosFinalCost.Classe;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PosFinalCost
{
    class ClsGridLookupEdit
    {
        public GridView gridView;
        public GridLookUpEdit gridEdit;
        MyFunaction clsAppearance = new MyFunaction();
        public ClsGridLookupEdit(IList<GridColumn> gridColumnsList, BindingSource bindingSource)
        {
            InitObjects();
            InitGridLookUpEdit(bindingSource);
            InitGridLookUpEditView(gridColumnsList);
        }
        public ClsGridLookupEdit(GridLookUpEdit gEdit, string ValueNo, string FieName, string NameTable)
        {
            gridEdit = gEdit;
            this.gridView = gEdit.Properties.View;// new GridView();
            IList<GridColumn> gridColumnList = new List<GridColumn> {
                new GridColumn() { FieldName =ValueNo, Caption = $"رقم {NameTable}" },
                new GridColumn() { FieldName = FieName, Caption = $"إسم {NameTable}" }
            };
            InitGridLookUpEdit();
            InitGridLookUpEditView(gridColumnList.Where(x => x.FieldName != "id").ToList());
            clsAppearance.AppearanceGridView(gridView);
            gridView.OptionsView.ShowAutoFilterRow = true;
        }
        private void InitObjects()
        {
            this.gridView = new GridView();
            this.gridEdit = new GridLookUpEdit();
        }
        private void InitGridLookUpEdit()
        {
            this.gridEdit.Properties.DisplayMember = "";
            this.gridEdit.Properties.ValueMember = "";
            this.gridEdit.Properties.PopupView = this.gridView;
            this.gridEdit.Properties.PopupSizeable = true;
            this.gridEdit.Properties.ShowPopupShadow = true;
            this.gridEdit.Properties.TextEditStyle = TextEditStyles.Standard;
            this.gridEdit.Properties.AcceptEditorTextAsNewValue = DefaultBoolean.True;
            this.gridEdit.Properties.Appearance.TextOptions.Trimming = Trimming.EllipsisPath;
            this.gridEdit.Properties.Appearance.Options.UseTextOptions = true;
        }
        private void InitGridLookUpEdit(BindingSource bindingSource)
        {
            this.gridEdit.Properties.DataSource = bindingSource;
            this.gridEdit.Properties.DisplayMember = "";
            this.gridEdit.Properties.ValueMember = "";
            this.gridEdit.Properties.PopupView = this.gridView;
            this.gridEdit.Properties.PopupSizeable = true;
            this.gridEdit.Properties.ShowPopupShadow = true;
            this.gridEdit.Properties.TextEditStyle = TextEditStyles.Standard;
            this.gridEdit.Properties.AcceptEditorTextAsNewValue = DefaultBoolean.True;
            this.gridEdit.Properties.Appearance.TextOptions.Trimming = Trimming.EllipsisPath;
            this.gridEdit.Properties.Appearance.Options.UseTextOptions = true;
        }
        private void InitGridLookUpEditView(IList<GridColumn> gridColumnList)
        {
            this.gridView.FocusRectStyle = DrawFocusRectStyle.RowFocus;

            this.gridView.Appearance.HeaderPanel.FontStyleDelta = FontStyle.Bold;
            this.gridView.Appearance.HeaderPanel.ForeColor = Color.Black;
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;

            this.gridView.OptionsFind.AlwaysVisible = true;
            this.gridView.OptionsFind.AllowFindPanel = true;
            this.gridView.OptionsFind.ShowFindButton = true;

            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;

            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView.OptionsSelection.CheckBoxSelectorColumnWidth = 30;

            for (short i = 0; i < gridColumnList.Count; i++)
                this.gridView.Columns.Add(InitColumnProperties(gridColumnList[i], i));
        }

        private GridColumn InitColumnProperties(GridColumn column, int visibleIndex)
        {
            column.VisibleIndex = ++visibleIndex;
            column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
            column.AppearanceCell.Options.UseTextOptions = true;
            return column;
        }

    }

}