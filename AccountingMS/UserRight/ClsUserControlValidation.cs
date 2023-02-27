using DevExpress.XtraBars;

namespace AccountingMS
{
    class ClsUserControlValidation
    {
        ClsTblControl clsTbControl;
        ClsTblRoleControl clsTbRoleControl;

        private byte _ucNo;
        private dynamic _userControl;

        public ClsUserControlValidation(dynamic userControl, UserControls ucNo)
        {
            if (Session.CurrentUser.id == 1) return;
            _ucNo = (byte)ucNo;
            _userControl = userControl;
            InitObjects();
            SetButtonsVisibility();
        }

        private void InitObjects()
        {
            this.clsTbControl = new ClsTblControl();
            this.clsTbRoleControl = new ClsTblRoleControl();
        }

        private void SetButtonsVisibility()
        {
            foreach (var control in _userControl?.ribbonControl?.Manager?.Items)
                if (control is BarButtonItem bbi && !string.IsNullOrEmpty(bbi.Name))
                    bbi.Visibility = this.clsTbRoleControl.GetButtonVisibilityByRoleIdNdControlId(Session.RoleId,
                        this.clsTbControl.GetControlIdByNameNducNo(bbi.Name, _ucNo));
        }
    }
}
