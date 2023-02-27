using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace PosFinalCost.Classe
{
    class ClsUserRoleValidation
    {
        ClsUserTblControl clsTbUserControl;
        private readonly FormMain _formMain;
        public ClsUserRoleValidation(FormMain formMain)
        {
            _formMain = formMain;
            InitObjects();
            //if (Session.CurrentUser.ID == 1) return;
            SetBarButtonVisibility();
        }
        private byte _ucNo;
        private dynamic _userControl;

        public ClsUserRoleValidation(dynamic userControl, UserControls ucNo)
        {
            if (Session.CurrentUser.ID == 1) return;
            _ucNo = (byte)ucNo;
            _userControl = userControl;
            InitObjects();
            SetButtonsVisibility();
        }
        private void InitObjects()
        {
            this.clsTbUserControl = new ClsUserTblControl();
        }
        private void SetBarButtonVisibility()
        {
            foreach (var control in _formMain.ribbonControl.Manager.Items)
                if (control is BarButtonItem bbi && !string.IsNullOrEmpty(bbi.Name))
                {
                    if (bbi.Name == "skinDropDownButtonItem1" || bbi.Name == "skinPaletteRibbonGalleryBarItem1" || bbi.Name == "btnUCmain") continue;
                    if (ValidateIrregularControls(bbi)) continue;
                    bbi.Visibility = this.clsTbUserControl.GetButtonVisibilityByRoleIdNducNo(Session.CurrentUser.RoleID.GetValueOrDefault(),
                        this.clsTbUserControl.GetUserControlNoByName(bbi.Name));
                }
        }

        private bool ValidateIrregularControls(BarButtonItem bbi)
        {
            if (bbi.Name.StartsWith("barButtonItemRprt"))
            {
                //bbi.Visibility = this.clsTbUserControl.GetButtonVisibilityByRoleIdNdControlId(Session.CurrentUser.RoleID.GetValueOrDefault(),
                //    this.clsTbUserControl.GetControlIdByNameNducNo(bbi.Name, 35));
                return true;
            }
            //switch (bbi.Name)
            //{
            //    case "barButtonItemAccountOpening":
            //        bbi.Visibility = this.clsTbRoleControl.GetButtonVisibilityByRoleIdNdControlId(Session.RoleID,
            //            this.clsTbControl.GetControlIdByNameNducNo(bbi.Name, (byte)UserControls.OpeningAccounts));
            //        return true;
            //    case "barButtonItemFinancialYear":
            //        bbi.Visibility = this.clsTbRoleControl.GetButtonVisibilityByRoleIdNdControlId(Session.RoleID,
            //            this.clsTbControl.GetControlIdByNameNducNo(bbi.Name, (byte)UserControls.FinancialYear));
            //        return true;
            //    case "barButtonItemDefaultSettings":
            //        bbi.Visibility = this.clsTbRoleControl.GetButtonVisibilityByRoleIdNdControlId(Session.RoleID,
            //            this.clsTbControl.GetControlIdByNameNducNo(bbi.Name, (byte)UserControls.DefaultSettings));
            //        return true;
            //    case "barButtonItemControlPanel":
            //        bbi.Visibility = this.clsTbRoleControl.GetButtonVisibilityByRoleIdNdControlId(Session.RoleID,
            //            this.clsTbControl.GetControlIdByNameNducNo(bbi.Name, (byte)UserControls.ControlPanel));
            //        return true;
            //};
            return false;
        }
      
        private void SetButtonsVisibility()
        {
            if(_userControl is Form)
            {
                foreach (var control in _userControl?.layoutControl1?.Controls)
                    if (control is SimpleButton bbi && !string.IsNullOrEmpty(bbi.Name) && this.clsTbUserControl.GetControlIdByNameNducNo(bbi.Name, _ucNo) is short ControlID && ControlID > 0)
                        bbi.Enabled = this.clsTbUserControl.GetButtonVisibilityByRoleIdNdControlId(Session.CurrentUser.RoleID.GetValueOrDefault(), ControlID);
            }
            else
            {
                foreach (var control in _userControl?.bindingNavigator11?.Items)
                    if (control is ToolStripButton bbi && !string.IsNullOrEmpty(bbi.Name) && this.clsTbUserControl.GetControlIdByNameNducNo(bbi.Name, _ucNo) is short ControlID && ControlID > 0)
                        bbi.Visible = this.clsTbUserControl.GetButtonVisibilityByRoleIdNdControlId(Session.CurrentUser.RoleID.GetValueOrDefault(), ControlID);
            }
        }
    }
}
