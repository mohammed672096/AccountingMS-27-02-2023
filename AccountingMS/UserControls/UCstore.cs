using AccountingMS.Forms;
using DevExpress.Data.ODataLinq.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class UCstore : XtraUserControl
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblProduct clsTbProduct;
        ClsTblPrdPriceMeasurment clsTbPrdPriceMsur;
        ClsTblBarcode clsTbBarcode;

        private readonly FormMain _fromMain;
        private string flyDialogMssg;
        private bool isNew, isDelete = false, isDoubleClick = true;

        public UCstore(FormMain formMain)
        {
            InitializeComponent();
            GetResourcesAndInitData();
            _fromMain = formMain;
            new ClsUserControlValidation(this, UserControls.Store);

            gridView.OptionsDetail.DetailMode = DetailMode.Embedded;
            gridView.MasterRowGetRelationCount += GridView_MasterRowGetRelationCount;
            gridView.MasterRowEmpty += GridView_MasterRowEmpty;
            gridView.MasterRowGetChildList += GridView_MasterRowGetChildList;
            gridView.MasterRowGetRelationName += GridView_MasterRowGetRelationName;
            gridView.Click += GridView_Click;
            gridView.DoubleClick += GridView_DoubleClick;
            gridView2.CustomColumnDisplayText += GridView2_CustomColumnDisplayText;
            gridView2.DoubleClick += GridView2_DoubleClick;
            gridView.KeyDown += GridView_KeyDown;
            repositoryItemTextEditBarcodeNo.KeyDown += RepositoryItemTextEditBarcodeNo_KeyDown;
        }

        private void GridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == colprdStatus.FieldName) e.DisplayText = (Convert.ToByte(e.Value)) switch
            {
                1 => "صنف سلعي",
                2 => "صنف خدمي",
                3 => "ميزان إلكتروني",
                4 => "صنف صناعي",
                5 => "صنف صناعي ميزان",
                _ => null
            };
        }

        protected internal async void RefreshData()
        {
          await  InitData();
        }
        ClsTblGroupStr clsTblGroupStr;
        private async Task InitData()
        {
            IList<Task> taskList = new List<Task>();
            taskList.Add(Task.Run(() => this.clsTbProduct = new ClsTblProduct()));
            taskList.Add(Task.Run(() => this.clsTbPrdPriceMsur = new ClsTblPrdPriceMeasurment()));
            taskList.Add(Task.Run(() => this.clsTbBarcode = new ClsTblBarcode()));
            taskList.Add(Task.Run(() => this.clsTblGroupStr = new ClsTblGroupStr()));
            await Task.WhenAll(taskList);

            tblGroupStrBindingSource.DataSource = clsTblGroupStr.GetGroupList;
            bsiRecordsCount.Caption = _resource.GetString("count") + tblGroupStrBindingSource.Count;
            tblGroupStr gr = new tblGroupStr();
            new ClsTblBranch().InitRepositoryItemBranchLookupEdit(gridControl, nameof(gr.grpBrnId));
        }
        //private void InitData()
        //{
        //    this.clsTbProduct = new ClsTblProduct();
        //    this.clsTbPrdPriceMsur = new ClsTblPrdPriceMeasurment();
        //    this.clsTbBarcode = new ClsTblBarcode();

        //    tblGroupStrBindingSource.DataSource = new ClsTblGroupStr().GetGroupList;
        //    bsiRecordsCount.Caption = _resource.GetString("count") + tblGroupStrBindingSource.Count;
        //}

        private void GridView_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void GridView_MasterRowEmpty(object sender, MasterRowEmptyEventArgs e)
        {
            e.IsEmpty = false;
        }

        private void GridView_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            var grpId = Convert.ToInt32(gridView.GetFocusedRowCellValue(colgrpId));
            var prWhithUnit= (from d in Session.Products.Where(x => x.prdGrpNo == grpId)
                              select new
                              {
                                  d.id,
                                  d.prdNo,
                                  d.prdName,
                                  d.prdNameEng,
                                  d.prdStatus,
                              }).ToList();
            e.ChildList = prWhithUnit;
           
        }

        private void GridView_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Level1";
        }

        private void GridView_Click(object sender, EventArgs e)
        {
            this.isDoubleClick = true;
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            if (!this.isDoubleClick) return;
            flyDialog.WaitForm(this, 1);
            using (formAddGroupStr frm = new formAddGroupStr(this, tblGroupStrBindingSource.Current as tblGroupStr))
            {
                flyDialog.WaitForm(this, 0);
                if (frm.ShowDialog() == DialogResult.OK) RefreshListDialog();
            }
        }

        private void GridView2_DoubleClick(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            var idData = view.GetFocusedRowCellValue("id");
            if (idData == null) return;
            flyDialog.WaitForm(this, 1);


            var db = new accountingEntities();
            int ProductID = Convert.ToInt32(idData);
            var product = db.tblProducts.Single(x => x.id == ProductID);
            using (formAddProduct frm = new formAddProduct(this, product))
            {
                flyDialog.WaitForm(this, 0);
                if (frm.ShowDialog() == DialogResult.OK) RefreshListDialog();
            }
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            InitUCstoreData();
            flyDialog.WaitForm(this, 0);
        }

        private void InitUCstoreData()
        {
            UCstoreData ucStoreData = new UCstoreData();
            ucStoreData.Dock = DockStyle.Fill;
            ucStoreData.ribbonControl.StatusBar.Hide();
            ucStoreData.Height = Convert.ToInt32(ClientSize.Height * 0.75);
            InitFlyoutDialog(ucStoreData);
        }

        private void InitFlyoutDialog(UCstoreData ucStoreData)
        {
            FlyoutCommand flyoutCommand = new FlyoutCommand()
            {
                Text = (!MySetting.GetPrivateSetting.LangEng) ? "إغلاق" : "Close",
                Result = DialogResult.Yes,
            };
            FlyoutAction flyoutAction = new FlyoutAction();
            flyoutAction.Commands.Add(flyoutCommand);

            FlyoutDialog dialog = new FlyoutDialog(_fromMain, flyoutAction, ucStoreData)
            {
                RightToLeft = (!MySetting.GetPrivateSetting.LangEng) ? RightToLeft.Yes : RightToLeft.No,
                RightToLeftLayout = (!MySetting.GetPrivateSetting.LangEng) ? true : false
            };
            flyDialog.WaitForm(this, 0);

            if (dialog.ShowDialog() == DialogResult.Yes) dialog.Close();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            using (formAddGroupStr frm = new formAddGroupStr(this, null))
            {
                flyDialog.WaitForm(this, 0);
                if (frm.ShowDialog() == DialogResult.OK) RefreshListDialog();
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            using (formAddProduct frm = new formAddProduct(this, null))
            {
                flyDialog.WaitForm(this, 0);
                if (frm.ShowDialog() == DialogResult.OK) RefreshListDialog();
            }
        }

        private async void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            await InitData();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            GridView view = sender as GridView;

            string level = view.ChildGridLevelName;
            XtraMessageBox.Show(level);
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            var frm = new ReportForm(ReportType.Store);
            frm.Show();
            flyDialog.WaitForm(this, 0, frm);
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            new formBarcode().ShowDialog();
            flyDialog.WaitForm(this, 0);
        }

        private void bbiReplicatedBarcode_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            using var form = new FormPrdBarcodeDuplicate(this);
            flyDialog.WaitForm(this, 0);

            if (form.ShowDialog() == DialogResult.OK) RefreshListDialog();
        }

        private void RepositoryItemTextEditBarcodeNo_KeyDown(object sender, KeyEventArgs e)
        {
            TextEdit editor = sender as TextEdit;
            if (editor?.EditValue == null) return;

            if (e.KeyData == Keys.Enter)
            {
                if (string.IsNullOrEmpty(editor.Text)) return;
                SearchProduct(editor.Text);
                editor.EditValue = null;
                bbiBarcodeNo.EditValue = null;
                editor.Focus();
                e.Handled = true;
            }
        }

        private bool ValidateBarcodeNo(string barcode, out int prdMsurId)
        {
            var tbBarcode = this.clsTbBarcode.GetBarcodeObjByNo(barcode);
            bool isValid = tbBarcode != null ? true : false;
            prdMsurId = tbBarcode != null ? tbBarcode.brcPrdMsurId : 0;

            if (!isValid)
            {
                flyDialog.WaitForm(this, 0);
                XtraMessageBox.Show(_resource.GetString("PrdNotFoundMssg"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isValid;
        }

        private void SearchProduct(string barcodeNo)
        {
            flyDialog.WaitForm(this, 1);

            if (!ValidateBarcodeNo(barcodeNo, out int prdMsurId)) return;

            var tbPrdPriceMsur = this.clsTbPrdPriceMsur.GetPrdPriceMsurById(prdMsurId);

            if (tbPrdPriceMsur == null)
            {
                flyDialog.WaitForm(this, 0);
                XtraMessageBox.Show(_resource.GetString("PrdNotFoundMssg"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tblProduct tbProduct = this.clsTbProduct.ChickDataProduct(this.clsTbProduct.GetPrdObjByPrdId(tbPrdPriceMsur.ppmPrdId), tbPrdPriceMsur, barcodeNo);
            if (tbProduct == null)
            {
                flyDialog.WaitForm(this, 0);
                XtraMessageBox.Show(_resource.GetString("PrdNotFoundMssg"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (formAddProduct frm = new formAddProduct(this, tbProduct))
            {
                flyDialog.WaitForm(this, 0);
                if (frm.ShowDialog() == DialogResult.OK) RefreshListDialog();
            }
        }

        private void GridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                flyDialog.WaitForm(this, 1);
                using var form = new FormPrdBarcodeDuplicate(this);
                flyDialog.WaitForm(this, 0);

                if (form.ShowDialog() == DialogResult.OK) RefreshListDialog();
            }
        }

        private async void RefreshListDialog()
        {
            RefreshGridView();

            if (this.isDelete) flyDialog.ShowDialogUCCustomdMsg(this, this.flyDialogMssg);
            else if (this.isNew) flyDialog.ShowDialogUC(this, this.flyDialogMssg);
            else flyDialog.ShowDialogUCUpdMsg(this, this.flyDialogMssg);

            this.isDelete = false;
            this.isDoubleClick = false;

           await InitData();
        }

        private void RefreshGridView()
        {
            gridView.RefreshData();
            gridView2.RefreshData();

            gridView.ClearColumnsFilter();
            gridView2.ClearColumnsFilter();
        }

        public void SetRefreshListDialog(string mssg, bool isNew, bool isDelete = false)
        {
            this.isNew = isNew;
            this.isDelete = isDelete;
            this.flyDialogMssg = mssg;
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frm_BarcodeTemplates().ShowDialog();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frm_PrintItemBarcode().ShowDialog();
        }

        private async void GetResourcesAndInitData()
        {
            if (!MySetting.GetPrivateSetting.LangEng)
            {
                _ci = new CultureInfo("ar");
                _resource = new ComponentResourceManager(typeof(Language.StoreMangmentNotificationAr));
            }
            else
            {
                _ci = new CultureInfo("en");
                _resource = new ComponentResourceManager(typeof(Language.UCstoreEn));
            }

            if (MySetting.GetPrivateSetting.LangEng) EnglishTranslation();
            await InitData();
        }

        private void EnglishTranslation()
        {
            this.RightToLeft = RightToLeft.No;
            gridControl.RightToLeft = RightToLeft.No;

            foreach (var control in ribbonControl.Manager.Items)
            {
                if (control is BarButtonItem)
                {
                    BarButtonItem c = control as BarButtonItem;
                    _resource.ApplyResources(c, c.Name, _ci);
                }
            }
            foreach (GridColumn c in gridView.Columns)
                _resource.ApplyResources(c, c.Name, _ci);
            foreach (GridColumn c in gridView2.Columns)
                _resource.ApplyResources(c, c.Name, _ci);

            _resource.ApplyResources(ribbonPage1, ribbonPage1.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup1, ribbonPageGroup1.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup2, ribbonPageGroup2.Name, _ci);
            _resource.ApplyResources(ribbonPageGroup3, ribbonPageGroup3.Name, _ci);
        }
    }
}
