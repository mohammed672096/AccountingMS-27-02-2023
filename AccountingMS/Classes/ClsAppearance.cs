using DevExpress.Utils;
using DevExpress.Utils.Extensions;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraTreeList;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace AccountingMS.Classes
{
    class ClsAppearance
    {
        public void LayoutAppearance(LayoutControlGroup layoutControlGroup, BindingNavigator bindingNavigator = null)
        {
            layoutControlGroup.CustomDrawBackground += LayoutGroupInvo_CustomDrawBackground;
            layoutControlGroup.AppearanceGroup.BorderColor = System.Drawing.Color.PowderBlue;
            layoutControlGroup.AppearanceItemCaption.TextOptions.HAlignment = HorzAlignment.Far;
        }
        public void LayoutAppearanceInvo(LayoutControlGroup layoutControlGroup, BindingNavigator bindingNavigator, Color systemColors)
        {
            layoutControlGroup.CustomDrawBackground += LayoutGroupInvo_CustomDrawBackground;
            layoutControlGroup.AppearanceGroup.BackColor = systemColors;
            if(bindingNavigator!=null)
            bindingNavigator.BackColor = systemColors;
            layoutControlGroup.AppearanceItemCaption.TextOptions.HAlignment = HorzAlignment.Far;
        }
        private void LayoutGroupInvo_CustomDrawBackground(object sender, GroupBackgroundCustomDrawEventArgs e)
        {
            LayoutControlGroup controlGroup = ((LayoutControlGroup)sender);
            e.DefaultDraw();
            e.Graphics.FillRectangle(new SolidBrush(controlGroup.AppearanceGroup.BackColor), e.Bounds);
            e.Handled = true;
        }
        public void layoutAppearanceGroup(LayoutControlGroup layoutControlGroup)
        {
            LayoutAppearance(layoutControlGroup);
            //layoutControlGroup.Parent?.Items?.Where(x => x is LayoutControlGroup).ForEach(x =>
            //{
            //    LayoutAppearance((LayoutControlGroup)x);
            //});
        }
        public void layoutAppearanceGroup(LayoutControlGroup layoutControlGroup, BindingNavigator bindingNavigator = null)
        {
            layoutControlGroup.CustomDrawBackground += LayoutGroup_CustomDrawBackground;
            layoutControlGroup.Parent?.Items?.Where(x => x is LayoutControlGroup).ForEach(x =>
            ((LayoutControlGroup)x).AppearanceGroup.BorderColor = System.Drawing.Color.SteelBlue);
            if (bindingNavigator != null)
            {
                bindingNavigator.Font = (Font)converter.ConvertFromString(MySetting.GetPrivateSetting.SystemFont);
                bindingNavigator.BackColor = System.Drawing.Color.AliceBlue;
            }
            layoutControlGroup.AppearanceItemCaption.TextOptions.HAlignment = HorzAlignment.Far;
        }
        private void LayoutGroup_CustomDrawBackground(object sender, GroupBackgroundCustomDrawEventArgs e)
        {
            e.DefaultDraw();
            e.Graphics.FillRectangle(new SolidBrush(System.Drawing.SystemColors.GradientInactiveCaption), e.Bounds);
            e.Handled = true;
        }
        public void LayoutAppearance(LayoutControl dataLayout)
        {
            dataLayout.Items.Where(x => x is LayoutControlGroup).ToList().ForEach(x => {
                LayoutAppearance((LayoutControlGroup)x);
            });
        }
        public void AppearanceGridView(GridView gridView)
        {
            gridView.Appearance.EvenRow.BackColor = Color.AliceBlue;
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.Appearance.Row.TextOptions.HAlignment = HorzAlignment.Near;
            gridView.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Near;
            gridView.OptionsBehavior.ReadOnly = true;
            gridView.AppearancePrint.Row.TextOptions.HAlignment = HorzAlignment.Near;
            gridView.AppearancePrint.EvenRow.BackColor = Color.AliceBlue;
            //gridView.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.SteelBlue;
            //gridView.Columns.ForEach(x => x.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Far);
            //gridView.AppearancePrint.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Near;
            gridView.Appearance.Empty.BackColor = System.Drawing.Color.AliceBlue;
            gridView.Appearance.FooterPanel.BackColor = System.Drawing.Color.SteelBlue;
        }
        public void AppearanceTreeList(TreeList TreeList)
        {
            TreeList.OptionsBehavior.Editable = false;
            TreeList.OptionsBehavior.PopulateServiceColumns = true;
            TreeList.OptionsView.ShowAutoFilterRow = true;
            //TreeList.Appearance.EvenRow.BackColor = Color.AliceBlue;
            TreeList.OptionsView.EnableAppearanceEvenRow = true;
            TreeList.Appearance.Row.TextOptions.HAlignment = HorzAlignment.Near;
            TreeList.Columns.ForEach(x => x.AppearanceHeader.BackColor = System.Drawing.Color.SteelBlue);
            TreeList.OptionsBehavior.ReadOnly = true;
            TreeList.AppearancePrint.Row.TextOptions.HAlignment = HorzAlignment.Near;
            TreeList.AppearancePrint.EvenRow.BackColor = Color.AliceBlue;
            TreeList.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.SteelBlue;
            TreeList.AppearancePrint.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Near;
            TreeList.Appearance.Empty.BackColor = System.Drawing.Color.AliceBlue;
        }
        TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));

    }
}
