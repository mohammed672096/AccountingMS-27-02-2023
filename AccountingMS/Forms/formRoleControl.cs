using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formRoleControl : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ComponentFlyoutDialog flyDailog = new ComponentFlyoutDialog();
        ClsTblRole clsTbRole = new ClsTblRole();
        ClsTblControl clsTbControl = new ClsTblControl();
        ClsTblUserControl clsTbUserControl = new ClsTblUserControl();
        ClsTblRoleControl clsTbRoleControl = new ClsTblRoleControl();
        ICollection<tblRoleControl> tbRoleControlList;
        IEnumerable<tblRoleControl> tbRoleControlListOld;

        private readonly UCuserRight _ucUserRight;
        private bool isNew = true;
        private short roleId;

        enum SwitchTask { addNew, update, unCheckAll }

        public formRoleControl(UCuserRight ucUserRight)
        {
            InitializeComponent();
            GetResources();
            InitData();
            InitLayoutTabChecklist();
            _ucUserRight = ucUserRight;

            textEditRoleId.EditValueChanged += TextEditRoleId_EditValueChanged;
        }

        private void InitData()
        {
            tblRoleBindingSource.DataSource = this.clsTbRole.GetRoleList;
        }

        private void InitLayoutTabChecklist()
        {
            foreach (var tbUserControl in this.clsTbUserControl.GetUserControlList)
                tabbedControlGroup1.AddTabPage(InitLayoutControlGroup(tbUserControl.ucNo, tbUserControl.ucCaption, tbUserControl.ucCaptionEn));
          //  var li = this.clsTbUserControl.GetUserControlList.ToList();
          //  var ch = (from u in li
          //            select new CheckedListBoxControl
          //            {
          //                Name = u.ucNo.ToString(),
          //                DataSource = this.clsTbControl.GetControlListByUCNo(u.ucNo).ToList(),
          //                DisplayMember = (!MySetting.GetPrivateSetting.LangEng) ? "cntCaption" : "cntCaptionEn",
          //                ValueMember = "cntId",
          //                CheckOnClick = true
          //            }).ToList();
          //  var itm = (from u in li
          //             select new LayoutControlItem
          //             {
          //                 Name = u.ucNo.ToString(),
          //                 Control = ch.FirstOrDefault(x=>x.Name==u.ucNo.ToString())
          //             });
          //  List<LayoutControlGroup> co = (from u in li
          //                                 select new LayoutControlGroup
          //                                 {
          //                                     Name = u.ucNo.ToString(),
          //                                     Text = (!MySetting.GetPrivateSetting.LangEng) ? u.ucCaption : u.ucCaptionEn,
          //                                     //Items = itm.Where(x=>x.Name==u.ucNo.ToString()).ToList()
          //                                 }).ToList();
          //co.ForEach(x =>
          //  {
          //      x.Add(itm.FirstOrDefault(y => y.Name == x.Name));
          //      tabbedControlGroup1.AddTabPage(x);
          //  });
            tabbedControlGroup1.SelectedTabPageIndex = 0;
        }

        private LayoutControlGroup InitLayoutControlGroup(byte ucNo, string ucCaption, string ucCaptionEn)
        {
            LayoutControlGroup layoutControlGroup = new LayoutControlGroup
            {
                Name = ucNo.ToString(),
                Text = (!MySetting.GetPrivateSetting.LangEng) ? ucCaption : ucCaptionEn
            };
            layoutControlGroup.Add(InitLayoutControlItem(ucNo, ucCaption));

            return layoutControlGroup;
        }

        private BaseLayoutItem InitLayoutControlItem(byte ucNo, string ucCaption)
        {
            return new LayoutControlItem
            {
                Name = ucNo.ToString(),
                Control = InitCheckListBox(ucNo)
            };
        }

        private Control InitCheckListBox(byte ucNo)
        {
            return new CheckedListBoxControl
            {
                Name = ucNo.ToString(),
                DataSource = this.clsTbControl.GetControlListByUCNo(ucNo),
                DisplayMember = (!MySetting.GetPrivateSetting.LangEng) ? "cntCaption" : "cntCaptionEn",
                ValueMember = "cntId",
                CheckOnClick = true
            };
        }

        private void TextEditRoleId_EditValueChanged(object sender, EventArgs e)
        {
            this.roleId = Convert.ToInt16(textEditRoleId.EditValue);
            CheckIfNew();
        }

        private void CheckIfNew()
        {
            this.isNew = this.clsTbRoleControl.CheckRoleControlIsNewByRoleId(this.roleId);

            if (this.isNew) UncheckAll();
            else SetCheckedListBox();
        }

        private void UncheckAll()
        {
            foreach (var checkedListBox in GetCheckListBoxRoleControl())
                checkedListBox.UnCheckAll();
        }

        private void SetCheckedListBox()
        {
            flyDailog.WaitForm(this, 1);
            this.tbRoleControlListOld = this.clsTbRoleControl.GetRoleControlListByRolId(this.roleId);

            foreach (var checkedListBox in GetCheckListBoxRoleControl())
                for (short i = 0; i < checkedListBox.ItemCount; i++)
                    checkedListBox.SetItemChecked(i, this.clsTbRoleControl.GetCheckState(Convert.ToInt16(checkedListBox.GetItemValue(i))));

            flyDailog.WaitForm(this, 0);
        }

        private IEnumerable<CheckedListBoxControl> GetCheckListBoxRoleControl()
        {
            ICollection<CheckedListBoxControl> checkedListBoxList = new Collection<CheckedListBoxControl>();

            foreach (BaseLayoutItem baseLayoutItem in dataLayoutControl1.Items)
                if (baseLayoutItem is LayoutControlItem item)
                    if (item.Control is CheckedListBoxControl checkedListBox)
                        checkedListBoxList.Add(checkedListBox);

            return checkedListBoxList;
        }

        private void SaveRoleControlToList()
        {
            this.tbRoleControlList = new Collection<tblRoleControl>();
            foreach (var checkedListBox in GetCheckListBoxRoleControl())
                for (short i = 0; i < checkedListBox.ItemCount; i++)
                    if (checkedListBox.GetItemChecked(i))
                        this.tbRoleControlList.Add(CreateTblRoleControlObj(Convert.ToByte(checkedListBox.Name),
                            Convert.ToInt16(checkedListBox.GetItemValue(i))));
        }

        private tblRoleControl CreateTblRoleControlObj(byte ucNo, short controlId)
        {
            return new tblRoleControl()
            {
                fkRoleId = this.roleId,
                fkucNo = ucNo,
                fkControlId = controlId
            };
        }

        private bool SaveData()
        {
            SaveRoleControlToList();
            return (this.isNew) ? this.clsTbRoleControl.AddList(this.tbRoleControlList) :
                this.clsTbRoleControl.UpdateList(this.tbRoleControlListOld, this.tbRoleControlList);
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            if (!SaveData()) return;

            string mssg = (this.isNew) ? "تم حفظ إذن الصلاحية: " : "تم تعديل بيانات إذن الصلاحية: ";
            mssg += textEditRoleId.Properties.GetDisplayText(textEditRoleId.EditValue) + " بنجاح.";
            _ucUserRight.SetRefreshListDialog(mssg);
            DialogResult = DialogResult.OK;
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = false;
            tabbedControlGroup1.TextLocation = DevExpress.Utils.Locations.Left;
            tabbedControlGroup1.AppearanceTabPage.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            tabbedControlGroup1.AppearanceTabPage.HeaderActive.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            tabbedControlGroup1.AppearanceTabPage.HeaderHotTracked.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;

            _ci = new CultureInfo("en");
            _resource = new ComponentResourceManager(typeof(Language.formRoleControlEn));

            _resource.ApplyResources(mainRibbonPageGroup, mainRibbonPageGroup.Name);
            _resource.ApplyResources(bbiSave, bbiSave.Name);
            _resource.ApplyResources(bbiClose, bbiClose.Name);
            _resource.ApplyResources(layoutControlGroup2, layoutControlGroup2.Name);
            _resource.ApplyResources(layoutControlGroup3, layoutControlGroup3.Name);
            _resource.ApplyResources(layoutControlItem1, layoutControlItem1.Name);
            textEditRoleId.Properties.Columns[0].Caption = _resource.GetString("textEditRoleId.Properties.Columns1");

            this.Text = _resource.GetString("$this.Text");
        }
    }
}
