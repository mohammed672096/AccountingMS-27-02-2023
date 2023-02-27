using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.Linq;
using System.Windows.Forms;

namespace AccountingMS
{
    class ClsUserRoleValidation
    {
        ClsTblControl clsTbControl;
        ClsTblUserControl clsTbUserControl;
        ClsTblRoleControl clsTbRoleControl;

        private readonly FormMain _formMain;
        public ClsUserRoleValidation(FormMain formMain)
        {
            _formMain = formMain;
            InitObjects();
            SetBarButtonVisibility();
        }
        private byte _ucNo;
        private dynamic _userControl;

        public ClsUserRoleValidation(dynamic userControl, UserControls ucNo)
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
            this.clsTbUserControl = new ClsTblUserControl();
            this.clsTbRoleControl = new ClsTblRoleControl();
        }
        private void SetBarButtonVisibility()
        {
            foreach (var control in _formMain.ribbonControl.Manager.Items)
                if (control is BarButtonItem bbi && !string.IsNullOrEmpty(bbi.Name))
                {
                    if (bbi.Name == "skinDropDownButtonItem1" || bbi.Name == "skinPaletteRibbonGalleryBarItem1" || bbi.Name == "btnUCmain") continue;
                    if (ValidateIrregularControls(bbi)) continue;
                    bbi.Visibility = this.clsTbRoleControl.GetButtonVisibilityByRoleIdNducNo(Session.RoleId,this.clsTbUserControl.GetUserControlNoByName(bbi.Name));
                }
        }

        private bool ValidateIrregularControls(BarButtonItem bbi)
        {
            if (bbi.Name.StartsWith("barButtonItemRprt"))
            {
                bbi.Visibility = this.clsTbRoleControl.GetButtonVisibilityByRoleIdNdControlId(Session.RoleId,
                    this.clsTbControl.GetControlIdByNameNducNo(bbi.Name, 35));
                return true;
            }
            switch (bbi.Name)
            {
                case "barButtonItemAccountOpening":
                    bbi.Visibility = this.clsTbRoleControl.GetButtonVisibilityByRoleIdNdControlId(Session.RoleId,
                        this.clsTbControl.GetControlIdByNameNducNo(bbi.Name, (byte)UserControls.OpeningAccounts));
                    return true;
                case "barButtonItemFinancialYear":
                    bbi.Visibility = this.clsTbRoleControl.GetButtonVisibilityByRoleIdNdControlId(Session.RoleId,
                        this.clsTbControl.GetControlIdByNameNducNo(bbi.Name, (byte)UserControls.FinancialYear));
                    return true;
                case "barButtonItemDefaultSettings":
                    bbi.Visibility = this.clsTbRoleControl.GetButtonVisibilityByRoleIdNdControlId(Session.RoleId,
                        this.clsTbControl.GetControlIdByNameNducNo(bbi.Name, (byte)UserControls.DefaultSettings));
                    return true;
                case "barButtonItemControlPanel":
                    bbi.Visibility = this.clsTbRoleControl.GetButtonVisibilityByRoleIdNdControlId(Session.RoleId,
                        this.clsTbControl.GetControlIdByNameNducNo(bbi.Name, (byte)UserControls.ControlPanel));
                    return true;
            };
            return false;
        }
        private void SetButtonsVisibility()
        {
            if (_userControl is Form)
            {
                foreach (var control in _userControl?.layoutControl1?.Controls)
                    if (control is SimpleButton bbi && !string.IsNullOrEmpty(bbi.Name) &&GetControlIdByNameNducNo(bbi.Name, _ucNo) is short ControlID && ControlID > 0)
                        bbi.Enabled = GetButtonVisibilityByRoleIdNdControlId(Session.RoleId, ControlID);
            }
            else
            {
                foreach (var control in _userControl?.bindingNavigator11?.Items)
                    if (control is ToolStripButton bbi && !string.IsNullOrEmpty(bbi.Name) &&GetControlIdByNameNducNo(bbi.Name, _ucNo) is short ControlID && ControlID > 0)
                        bbi.Visible = GetButtonVisibilityByRoleIdNdControlId(Session.RoleId, ControlID);
            }
        }
        public bool GetButtonVisibilityByRoleIdNdControlId(short roleId, short controlId) =>
        (Session.RoleControls.Any(x => x.fkRoleId == roleId && x.fkControlId == controlId));
        public BarItemVisibility GetButtonVisibilityByRoleIdNducNo(short roleId, byte ucNo) => (Session.RoleControls.Any(x => x.fkRoleId == roleId && x.fkucNo == ucNo)) ? BarItemVisibility.Always : BarItemVisibility.Never;
        public short GetControlIdByNameNducNo(string cntName, byte ucNo) =>
         (from c in Session.tblControl
          //join cd in Session.ControlDatas on c.ControlDataID equals cd.ID
          where c.cntucNo == ucNo && c.cntName == cntName
          select c.cntId).ToList().FirstOrDefault();
    }
}
