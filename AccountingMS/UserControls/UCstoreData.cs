using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class UCstoreData : DevExpress.XtraEditors.XtraUserControl
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblStore clsTbStore;
        tblStore tbStore;

        private bool isNew;

        private void UCstoreData_Load(object sender, EventArgs e)
        {
            SetSplitterProperties(true);
            new ClsTblBranch().InitBranchLookupEdit(layoutControlGroupStoreObj, tblStoreObjBindingSource, "strBrnId");
        }

        public UCstoreData()
        {
            InitializeComponent();
            InitData();

            this.Load += UCstoreData_Load;
        }

        private void InitData()
        {
            this.clsTbStore = new ClsTblStore();
            tblStoreBindingSource.DataSource = this.clsTbStore.GetStoreList;
            bsiRecordsCount.Caption = ((!MySetting.GetPrivateSetting.LangEng) ? "العدد : " : "RECORDS") + tblStoreBindingSource.Count;
            tblStore gr = new tblStore();
            new ClsTblBranch().InitRepositoryItemBranchLookupEdit(gridControl, nameof(gr.strBrnId));
        }

        private void BbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            InitNewStrObj();
            EnableDataLayoutControl();
            SetSplitterProperties(false);
        }

        private void BbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsBindingSource.Validate(tblStoreBindingSource)) return;
            UpdateCurrentObj();
            SetSplitterProperties(false);
        }

        private void BbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            InitData();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!SaveData()) return;
            string mssg = (!MySetting.GetPrivateSetting.LangEng) ? $"تم حفظ بيانات المخزن: {this.tbStore.strName} بنجاح!" : $"{this.tbStore.strName} data saved successfully!:";
            flyDialog.ShowDialogUCCustomdMsg(this, mssg);

            SetSplitterProperties(true);
            Reset();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

      
        private bool SaveData()
        {
            if (!dxValidationProvider1.Validate()) return false;
            if (this.isNew)
                return this.clsTbStore.Add(tblStoreObjBindingSource.Current as tblStore);
            else return this.clsTbStore.Attach(tblStoreObjBindingSource.Current as tblStore);
        }
        private void InitNewStrObj()
        {
            this.isNew = true;
            this.tbStore = new tblStore()
            {
                strNo = this.clsTbStore.GetNewStoreNo(),
                strBrnId = Session.CurBranch.brnId,
                strStatus = 1
            };
            SetObjLayoutGroupHeaderText();
            tblStoreObjBindingSource.DataSource = this.tbStore;
        }

        private void UpdateCurrentObj()
        {
            this.isNew = false;
            this.tbStore = tblStoreBindingSource.Current as tblStore;
            this.clsTbStore.Attach(this.tbStore);

            SetObjLayoutGroupHeaderText();
            EnableDataLayoutControl();
            tblStoreObjBindingSource.DataSource = this.tbStore;
        }

        private void Reset()
        {
            ResetObjData();
            InitData();
        }

        private void ResetObjData()
        {
            this.tbStore = null;
            dataLayoutControl1.Enabled = false;
            tblStoreObjBindingSource.DataSource = typeof(tblStore);

            RemoveValidationError();
            RestObjLayoutGroupHeaderText();
            gridControl.Focus();
        }

        private void EnableDataLayoutControl()
        {
            dataLayoutControl1.Enabled = true;
            strNameTextEdit.Focus();
        }

        private void RemoveValidationError()
        {
            IList<Control> invalidControls = dxValidationProvider1.GetInvalidControls().ToList();
            foreach (Control control in dxValidationProvider1.GetInvalidControls().ToList())
                dxValidationProvider1.RemoveControlError(control);
        }

        private void SetSplitterProperties(bool isCollapsed)
        {
            splitContainerControl1.SplitterPosition = Convert.ToInt32(this.Width * 0.75);
            splitContainerControl1.Collapsed = isCollapsed;
        }

        private void SetObjLayoutGroupHeaderText()
        {
            layoutControlGroupStoreObj.Text = (this.isNew) ? "إضافة مخزن جديد" : $"تعديل بيانات المخزن : {this.tbStore.strName}";
        }

        private void RestObjLayoutGroupHeaderText()
        {
            layoutControlGroupStoreObj.Text = "بيانات المخزن";
        }
    }
}
