using AccountingMS.Classes;
using DevExpress.Utils;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formAddProduct : DevExpress.XtraEditors.XtraForm
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblProduct clsTbProduct;
        ClsTblPrdPriceMeasurment clsTbPrdMsur;
        ClsTblBarcode clsTbBarcode;
        ClsTblPrdManufacture clsTbPrdMan;
        FlyoutPanel flyoutPanel;
        UCprdManufacture ucPrdMan;

        private readonly UCstore _ucStore;
        private byte ppmCount;
        private double tax;
        private bool isRefreshData = false, isPhasedInvociesFound = false, isWeight = false, isManufacture = false;
        protected internal bool isNew;
        protected internal IList<tblPrdManufacture> tbPrdManList, tbPrdManListOld;
        ClsAppearance GetAppearance = new ClsAppearance();
        private async void FormAddProduct_Load(object sender, EventArgs e)
        {
            InitSize();
            await Task.Run(() => InitPrdManufactureFlyoutPanel());
            await Task.Run(() => InitPrdManufactureData());
            btnDelete.Visible = (this.isNew) ? false:true;
            GetAppearance.layoutAppearanceGroup(layoutControlGroupPPM1); 
            GetAppearance.layoutAppearanceGroup(layoutControlGroupPPM2Main);
            GetAppearance.layoutAppearanceGroup(layoutControlGroupPPM3Main); 
            GetAppearance.LayoutAppearance(layoutControlGroupStore);
            GetAppearance.LayoutAppearance(layoutControlGroup9);
            GetAppearance.LayoutAppearance(layoutControlGroup3, bindingNavigator11);
           }
        public static List<ValueAndID> ProdTypeList = new List<ValueAndID>() {
                new ValueAndID() { ID = (byte)ProductType.Mechinary , Name  =MySetting.GetPrivateSetting.LangEng?"Commodity":"سلعي" },
                new ValueAndID() { ID = (byte)ProductType.WeightBarcode , Name  =MySetting.GetPrivateSetting.LangEng?"Electronic Scale":"ميزان إلكتروني" },
                new ValueAndID() { ID = (byte)ProductType.Manufacture , Name  =MySetting.GetPrivateSetting.LangEng?"Industrial":"صناعي" },
                new ValueAndID() { ID = (byte)ProductType.ManWeight , Name  =MySetting.GetPrivateSetting.LangEng?"Industrial Scale":"صناعي ميزان" },
                new ValueAndID() { ID = (byte)ProductType.Service , Name  =MySetting.GetPrivateSetting.LangEng?"Service":"خدمي" },
        }; 
        private void SetEditProperties()
        {
            if (CurrProduct == null) return;
            prdStrIdLookUpEdit.ReadOnly = (CurrProductQ?.prdStrId??0) != 0&&!this.isNew;
            ItemForprdStatus.Enabled = (CurrProduct.prdStatus == (byte)ProductType.Service) ? false : true;
            prdStatusTextEdit.Properties.Items[0].Enabled = (CurrProduct.prdStatus < 4);
            prdStatusTextEdit.Properties.Items[1].Enabled = (CurrProduct.prdStatus < 4);
            prdStatusTextEdit.Properties.Items[2].Enabled = (CurrProduct.prdStatus >= 4);
            prdStatusTextEdit.Properties.Items[3].Enabled = (CurrProduct.prdStatus >= 4);
            prdStatusTextEdit.Properties.Items[4].Enabled = false;
        }

        private void SetProperties()
        {
            if (CurrProduct == null) return;
            
            this.Height = (CurrProduct.prdStatus == (byte)ProductType.Service) ? 400 : MySetting.GetPrivateSetting.formAddProductH;
            this.isWeight = (CurrProduct.prdStatus == (byte)ProductType.WeightBarcode || CurrProduct.prdStatus == (byte)ProductType.ManWeight);
            this.isManufacture = (CurrProduct.prdStatus == (byte)ProductType.Manufacture || CurrProduct.prdStatus == (byte)ProductType.ManWeight);
            if (tbPPM1 != null)
            {
                tbPPM1.ppmWeight = this.isWeight;
                tbPPM1.ppmManufacture = this.isManufacture;
                if (tbPPM2 != null)
                {
                    tbPPM2.ppmWeight = this.isWeight;
                    tbPPM2.ppmManufacture = this.isManufacture;
                    if (tbPPM3 != null)
                    {
                        tbPPM3.ppmWeight = this.isWeight;
                        tbPPM3.ppmManufacture = this.isManufacture;
                    }
                }
            }

            //bsiSalTaxPriceString.Visibility = (prdStatusTextEdit.SelectedIndex == 4) ? BarItemVisibility.Never : BarItemVisibility.Always;

            ItemForppmPrice.Visibility = this.isManufacture ? LayoutVisibility.Never : LayoutVisibility.Always;
            layoutControlGroup9.Visibility = CurrProduct.prdStatus == (byte)ProductType.Service ? LayoutVisibility.Never : LayoutVisibility.Always;
            labelShowPrdManufacture.Visibility =this.isManufacture? LayoutVisibility.Always : LayoutVisibility.Never;
            layoutControlGroupPPM2Main.Enabled =this.isManufacture? false : true;
            layoutControlGroupPPM3Main.Enabled = this.isManufacture ? false : true;
        }
        void autoBarcode(BindingSource bindingSource, int M=1)
        {
            if (MySetting.DefaultSetting.AutoBarcode == false || bindingSource.Count > 0) return;
            var maxbarcod = Session.tblBarcode.Where(x => long.TryParse(x.brcNo, out long m));
            long barcodeauto = maxbarcod.Count() > 0 ? maxbarcod.Max(x => long.Parse(x.brcNo)) + 1 : 1;
            switch (M)
            {
                case 2 when (BarcodeList1?.Count == 1&& BarcodeList1?.FirstOrDefault()?.brcNo == barcodeauto.ToString()):
                        barcodeauto++;
                    break;
                case 3 when (BarcodeList2?.Count == 1 && BarcodeList2?.FirstOrDefault()?.brcNo == barcodeauto.ToString()):
                    barcodeauto++;
                    break;
                case 3 when (BarcodeList1?.Count == 1 && BarcodeList1?.FirstOrDefault()?.brcNo == barcodeauto.ToString()):
                    barcodeauto+=2;
                    break;
            }
            bindingSource.DataSource = new tblBarcode
            {
                brcBrnId = Session.CurBranch.brnId,
                brcNo = barcodeauto.ToString(),
            };
        }
        private void InitObjects()
        {
            this.clsTbProduct = new ClsTblProduct();
            this.clsTbPrdMsur = clsTbPrdMsur??new ClsTblPrdPriceMeasurment();
            this.clsTbBarcode = clsTbBarcode ?? new ClsTblBarcode();
        }
        public formAddProduct(UCstore ucStore, tblProduct obj)
        {
            _ucStore = ucStore;
            InitializeComponent();
            new ClsTblGroupStr().GroupNoLookkUpEdit(prdGrpNoLookUpEdit);
            var Stor = new ClsTblStore().GetStoreList.ToList();
            if (!Stor.Any(x => x.id == 0))
                Stor.Insert(0, new tblStore {strName="كل المخازن",strNo=0,id=0 });
            prdStrIdLookUpEdit.IntializeData(Stor);
            prdStatusTextEdit.Properties.Items.AddRange((from s in ProdTypeList select new RadioGroupItem() { Description = s.Name, Value = s.ID }).ToArray());
            this.tax = MySetting.GetPrivateSetting.taxDefault;
            InitObjects();
            GetResources();
            InitData(obj);
            InitEvents();
            dataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
          
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
            if (!ValidateBarcodeNo(barcodeNo, out int prdMsurId)) return;
            var tbPrdPriceMsur = this.clsTbPrdMsur.GetPrdPriceMsurById(prdMsurId);
            if (tbPrdPriceMsur == null)
            {
                XtraMessageBox.Show(_resource.GetString("PrdNotFoundMssg"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tblProduct tbProduct = this.clsTbProduct.ChickDataProduct(this.clsTbProduct.GetPrdObjByPrdId(tbPrdPriceMsur.ppmPrdId), tbPrdPriceMsur, barcodeNo);
            if (tbProduct == null)
            {
                XtraMessageBox.Show(_resource.GetString("PrdNotFoundMssg"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            InitData(tbProduct);

        }
        private void InitEvents()
        {
            this.Load += this.FormAddProduct_Load;
            this.KeyDown += formAddProduct_KeyDown;
            this.FormClosing += FormAddProduct_FormClosing;

            layoutControlGroupPPM2Main.CustomButtonClick += LayoutControlGroupPPM2_CustomButtonClick;
            layoutControlGroupPPM3Main.CustomButtonClick += LayoutControlGroupPPM3_CustomButtonClick;

            prdGrpNoLookUpEdit.EditValueChanged += PrdGrpNoLookUpEdit_EditValueChanged;
            prdStatusTextEdit.EditValueChanged += PrdStatusTextEdit_EditValueChanged;
            prdSaleTaxCheckEdit.CheckedChanged += PrdSaleTaxCheckEdit_CheckedChanged;
            prdPriceTaxCheckEdit.CheckedChanged += PrdPriceTaxCheckEdit_CheckedChanged;
            ppmSalePriceTextEdit1.EditValueChanging += PpmSalePriceTextEdit1_EditValueChanging;
            ppmSalePriceTextEdit2.EditValueChanging += PpmSalePriceTextEdit2_EditValueChanging;
            ppmSalePriceTextEdit3.EditValueChanging += PpmSalePriceTextEdit3_EditValueChanging;

            ppmConversionTextEdit2.EditValueChanging += PpmConversionTextEdit2_EditValueChanging;
            ppmConversionTextEdit3.EditValueChanging += PpmConversionTextEdit3_EditValueChanging;
            gridControlBarcode1.ProcessGridKey += GridControlBarcode_ProcessGridKey;
            gridControlBarcode2.ProcessGridKey += GridControlBarcode_ProcessGridKey;
            gridControlBarcode2.ProcessGridKey += GridControlBarcode_ProcessGridKey;
            TextBarcodeNo.KeyDown += TextBarcodeNo_KeyDown;
            btnClose.Click += BbiClose_Click;
            btnDelete.Click += BtnDelete_Click;
            btnSave.Click += BbiSave_Click;
            btnSaveAndClose.Click += BtnSaveAndClose_Click;
            btnSaveAndNew.Click += BbiSaveAndNew_Click;
            btnSaveAndPrint.Click += BtnSaveAndPrint_Click;
            this.FormClosed += FormAddProduct_FormClosed;
            ppmDefaultCheckEdit.EditValueChanged += PpmDefaultCheckEdit_EditValueChanged;
            ppmDefaultCheckEdit2.EditValueChanged += PpmDefaultCheckEdit_EditValueChanged;
            ppmDefaultCheckEdit3.EditValueChanged += PpmDefaultCheckEdit_EditValueChanged;
        }

        private void PpmSalePriceTextEdit1_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (this.isNew)
                ppmMinSalePriceTextEdit1.EditValue = e.NewValue;
            SetBsiSaleTaxPrice(labelControlPrice1, e.NewValue);
            //tbPPM1.ppmSalePrice =Convert.ToDouble(e.NewValue);
            //if (layoutControlGroupPPM2Sub.Enabled && tbPPM2 != null)
            //{
            //    ppmSalePriceTextEdit2.EditValue = (tbPPM1?.ppmSalePrice ?? 0) / (tbPPM2?.ppmConversion ?? 1);
            //    if (layoutControlGroupPPM3Sub.Enabled && tbPPM3 != null)
            //        ppmSalePriceTextEdit3.EditValue = (tbPPM2?.ppmSalePrice ?? 0) / (tbPPM3?.ppmConversion ?? 1);
            //}
        }
      
        private void PpmSalePriceTextEdit2_EditValueChanging(object sender, ChangingEventArgs e)
        {
            SetBsiSaleTaxPrice(labelControlPrice2, e.NewValue);
        }

        private void PpmSalePriceTextEdit3_EditValueChanging(object sender, ChangingEventArgs e)
        {
            SetBsiSaleTaxPrice(labelControlPrice3, e.NewValue);
        }
       
        void SetDefult(CheckEdit checkEdit,bool n,bool s)
        {
            if (!n) return;
            checkEdit.EditValue = !s;
            checkEdit.Enabled = true;
        }
        private void PpmDefaultCheckEdit_EditValueChanged(object sender, EventArgs e)
        {
            CheckEdit checkEdit = sender as CheckEdit;
            if (!this.IsActive) return;
            if (checkEdit.EditValue is bool s&&s)
            {
                if (checkEdit.Name == ppmDefaultCheckEdit.Name)
                {
                    SetDefult(ppmDefaultCheckEdit2, (tbPPM2 != null), s);
                    SetDefult(ppmDefaultCheckEdit3, (tbPPM3 != null), s);
                }
                else if (checkEdit.Name == ppmDefaultCheckEdit2.Name)
                {
                    SetDefult(ppmDefaultCheckEdit, (tbPPM1 != null), s);
                    SetDefult(ppmDefaultCheckEdit3, (tbPPM3 != null), s);
                }
                else if (checkEdit.Name == ppmDefaultCheckEdit3.Name)
                {
                    SetDefult(ppmDefaultCheckEdit, (tbPPM1 != null), s);
                    SetDefult(ppmDefaultCheckEdit2, (tbPPM2 != null), s);
                }
                checkEdit.Enabled = false;
            }
            
        }

        private void PrdStatusTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            CurrProduct.prdStatus= (byte)prdStatusTextEdit.EditValue;
            SetProperties();
            ShowPrdManufactureControl(this.isNew);
        }

        private void TextBarcodeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(TextBarcodeNo.Text))
            {
                try
                {
                    SearchProduct(TextBarcodeNo.Text);
                    TextBarcodeNo.Clear();
                    TextBarcodeNo.Focus();
                }
                catch (Exception)
                {
                    TextBarcodeNo.Clear();
                    return;
                }
            }
        }

      
        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (!ConfirmDelete()) return;
            if (!ValidatePrdData()) return;
            if (!DeletePrdData()) return;
            await RefrechAllDataProduct();
            _ucStore.SetRefreshListDialog($"تم حذف الصنف: {CurrProduct.prdName} بنجاح!", this.isNew, true);
            DialogResult = DialogResult.OK;
        }

        private void BtnSaveAndPrint_Click(object sender, EventArgs e)
        {
            CloseAfterSave = false;
            btnSave.PerformClick();
            var frm = new Forms.frm_PrintItemBarcode(new List<int>() { CurrProduct.id });
            frm.ShowDialog();
        }

        private void BtnSaveAndClose_Click(object sender, EventArgs e)
        {
            CloseAfterSave = true;
            btnSave.PerformClick();
        }

        private void BbiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BbiSave_Click(object sender, EventArgs e)
        {
            if (!SaveData()) return;
            AddDataToSession();
            //if (_ucStore != null) await RefrechAllDataProduct();
            if (_ucStore != null && CloseAfterSave)
            {
                this.Close();
                _ucStore.SetRefreshListDialog(_resource.GetString("prdSuccessMssg") + prdNameTextEdit.Text, this.isNew);
                DialogResult = DialogResult.OK;
            }
            else if (CloseAfterSave)
                this.Close();
            else
            {
                flyDialog.ShowDialogFormLayoutControl(this, _resource.GetString("prdSuccessMssg") + prdNameTextEdit.Text, this.isNew);
                this.prdNoOld = CurrProduct.prdNo;
                this.grpIdOld = CurrProduct.prdGrpNo;
                this.isNew = false;
            }
        }
        private void BbiSaveAndNew_Click(object sender, EventArgs e)
        {
            if (!SaveData()) return;
            AddDataToSession();
        //    await RefrechAllDataProduct();
            flyDialog.ShowDialogForm(this, _resource.GetString("prdSuccessMssg"));
            ResetData();
            prdGrpNoLookUpEdit.Focus();
            SetPPMLayoutGroupButtons(layoutControlGroupPPM3Main, layoutControlGroupPPM3Sub, 1, 3);
            SetPPMLayoutGroupButtons(layoutControlGroupPPM2Main, layoutControlGroupPPM2Sub, 1, 2);
            InitNewObject();
            this.isRefreshData = true;
        }
        bool CloseAfterSave = false;
      
     
        tblProduct CurrProduct => tblProductsBindingSource.Current as tblProduct;
        tblPrdPriceMeasurment tbPPM1 => tblPrdPriceMeasurmentBindingSource1.Current as tblPrdPriceMeasurment;
        tblPrdPriceMeasurment tbPPM2 => tblPrdPriceMeasurmentBindingSource2.Current as tblPrdPriceMeasurment;
        tblPrdPriceMeasurment tbPPM3 => tblPrdPriceMeasurmentBindingSource3.Current as tblPrdPriceMeasurment;
        tblProductQunatity CurrProductQ => tblProductQunatityBindingSource.Current as tblProductQunatity;
        IList<tblBarcode> BarcodeList1 => tblBarcodeBindingSource1.List as IList<tblBarcode>;
        IList<tblBarcode> BarcodeList2 => tblBarcodeBindingSource2.List as IList<tblBarcode>;
        IList<tblBarcode> BarcodeList3 => tblBarcodeBindingSource3.List as IList<tblBarcode>;
        private void InitData(tblProduct obj)
        {
            if (obj == null)
                InitNewObject();
            else
            {
                this.isNew = false;
                this.prdNoOld = obj.prdNo;
                this.grpIdOld = obj.prdGrpNo;
                tblProductsBindingSource.DataSource = obj;
                InitPQuantityData();
                InitPPMData();
                if (new ClsTblProductQtyOpn().IsPrdQuanOpnFoundByPrdId(CurrProduct.id))
                    ItemForprdGrpNo.Enabled = false;
                SetEditProperties();
            }
        }
        private void InitNewObject()
        {
            InitPrdObject();
            InitPrdQuantity();
            InitPrdMsurObjects(1);
            btnSaveAndNew.Visible =true;
            this.isNew = true;
        }
        private void InitPrdQuantity()
        {
            tblProductQunatity tbProductQuantity = new tblProductQunatity()
            {
                prdStrId = MySetting.DefaultSetting.defaultStrId,
                prdQuantity = 0,
                prdSubQuantity = 0,
                prdSubQuantity3 = 0,
                prdBrnId = Session.CurBranch.brnId,
                prdStatus = CurrProduct.prdStatus
            };
            tblProductQunatityBindingSource.DataSource = tbProductQuantity;
        }
        private void InitPrdObject()
        {
            tblProduct Product = new tblProduct()
            {
                prdPriceTax = MySetting.DefaultSetting.prdPriceTax,
                prdBrnId = Session.CurBranch.brnId,
                prdStatus = 1,
                prdPurchaseTax = false,
                Suspended = false,

            };
            tblProductsBindingSource.DataSource = Product;
        }
        private void InitPrdMsurObjects(byte ppmStatus)
        {
            tblPrdPriceMeasurment tbPPM = new tblPrdPriceMeasurment()
            {
                ppmDefault = (ppmStatus == 1 ? true : false),
                ppmBrnId = Session.CurBranch.brnId,
                ppmStatus = (byte)(ppmStatus > 0 && ppmStatus <= 3 ? ppmStatus : 1),
                ppmManufacture = false,
                ppmWeight = false,
            };
            switch (tbPPM.ppmStatus)
            {
                case 1:
                    tbPPM.ppmConversion = 1;
                    tblPrdPriceMeasurmentBindingSource1.DataSource = tbPPM;
                    autoBarcode(tblBarcodeBindingSource1);
                    ppmDefaultCheckEdit.Enabled = !tbPPM1.ppmDefault;
                    break;
                case 2:
                    tblPrdPriceMeasurmentBindingSource2.DataSource = tbPPM;
                    autoBarcode(tblBarcodeBindingSource2,2);
                    ppmDefaultCheckEdit2.Enabled = !tbPPM2.ppmDefault;
                    break;
                case 3:
                    tblPrdPriceMeasurmentBindingSource3.DataSource = tbPPM;
                    autoBarcode(tblBarcodeBindingSource3,3);
                    ppmDefaultCheckEdit3.Enabled = !tbPPM3.ppmDefault;
                    break;
            }
        }
        private void PpmConversionTextEdit2_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (!double.TryParse(e.NewValue?.ToString(), out double conversionRate) || conversionRate == 0) return;
            if (ppmPriceTextEdit1.EditValue is double price)
                ppmPriceTextEdit2.EditValue = price * conversionRate;
        }

        private void PpmConversionTextEdit3_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (!double.TryParse(e.NewValue?.ToString(), out double conversionRate) || conversionRate == 0) return;
            if (ppmPriceTextEdit1.EditValue is double price)
                ppmPriceTextEdit3.EditValue = price * conversionRate;
        }
        private void SetBsiSaleTaxPrice(LabelControl bsiSaleTaxPrice, object newValue)
        {
            if (newValue == null) return;
            if (string.IsNullOrEmpty(newValue.ToString()))
            {
                bsiSaleTaxPrice.Text = null;
                return;
            }
            double price = Convert.ToDouble(newValue);
            if(!CurrProduct.prdPriceTax)
            bsiSaleTaxPrice.Text = $"{price + (price * (this.tax / 100)):n2}";
            else bsiSaleTaxPrice.Text = $"{price:n2}";
        }

        private void InitPQuantityData()
        {
            if (Session.ProductQunatities?.FirstOrDefault(x => x.prdId == CurrProduct?.id&&Session.tblStore.Where(y=>y.strBrnId== Session.CurBranch.brnId).Any(y=>y.id== x.prdStrId)) is tblProductQunatity qunatity && qunatity != null)
                tblProductQunatityBindingSource.DataSource = qunatity;
        }

        private void InitPPMData()
        {
            IEnumerable<tblPrdPriceMeasurment> tbPPMList = Session.tblPrdPriceMeasurment?.Where(x => x.ppmPrdId == ((CurrProduct?.id) ?? 0)).ToList();
            this.ppmCount = (byte)tbPPMList.Count();
            if (tbPPMList == null) return;
            if (tbPPMList.Count() == 0) return;
            tblPrdPriceMeasurmentBindingSource1.DataSource = tbPPMList.FirstOrDefault(x => x.ppmStatus == 1);
            if (tbPPM1 != null)
            {
                InitBarcodeData(tblBarcodeBindingSource1, tbPPM1.ppmId);
                ppmDefaultCheckEdit.Enabled = !tbPPM1.ppmDefault;
            }
            SetBsiSaleTaxPrice(labelControlPrice1, tbPPM1.ppmSalePrice);
            if (this.ppmCount == 1) return;
                tblPrdPriceMeasurmentBindingSource2.DataSource = tbPPMList.FirstOrDefault(x => x.ppmStatus == 2);
            if (tbPPM2 != null)
            {
                InitPPMLayoutGroup(layoutControlGroupPPM2Main, layoutControlGroupPPM2Sub, tbPPM2.ppmDefault, 2);
                SetPriceProperties(ItemForppmPrice1);
                InitBarcodeData(tblBarcodeBindingSource2, tbPPM2.ppmId);
                SetBsiSaleTaxPrice(labelControlPrice2, tbPPM2.ppmSalePrice);
                ppmDefaultCheckEdit2.Enabled = !tbPPM2.ppmDefault;
            }
            if (this.ppmCount == 2) return;
            tblPrdPriceMeasurmentBindingSource3.DataSource = tbPPMList.FirstOrDefault(x => x.ppmStatus == 3);
            if (tbPPM3 != null)
            {
                InitPPMLayoutGroup(layoutControlGroupPPM3Main, layoutControlGroupPPM3Sub, tbPPM3.ppmDefault, 3);
                SetPriceProperties(ItemForppmPrice2);
                InitBarcodeData(tblBarcodeBindingSource3, tbPPM3.ppmId);
                SetBsiSaleTaxPrice(labelControlPrice3, tbPPM3.ppmSalePrice);
                ppmDefaultCheckEdit3.Enabled = !tbPPM3.ppmDefault;
            }
        }

        private void InitBarcodeData(BindingSource tblBarcodeBindingSource, int ppmId)
        {
            tblBarcodeBindingSource.DataSource = Session.tblBarcode?.Where(x => x.brcPrdMsurId == ppmId).ToList();
        }

        private void SetPriceProperties(LayoutControlItem itemForppmPrice)
        {
            //itemForppmPrice.Enabled = false;
            //itemForppmPrice.Visibility = LayoutVisibility.Always;
        }

        private void InitPPMLayoutGroup(LayoutControlGroup layoutGroupMain, LayoutControlGroup layoutGroupSub,bool ppmDefault, byte ppmStatus)
        {
            layoutGroupSub.Enabled = true;
            layoutGroupMain.CustomHeaderButtons[0].Properties.Visible = false;
            layoutGroupMain.HeaderButtonsLocation = GroupElementLocation.AfterText;
        }

        private void PrdSaleTaxCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            labelControlPrice11.Visible = !prdSaleTaxCheckEdit.Checked;
        }

        private void PrdPriceTaxCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (this.IsActive)
                SaveTaxSettings();
            if(tbPPM1!=null)
            SetBsiSaleTaxPrice(labelControlPrice1, tbPPM1.ppmSalePrice);
            if (tbPPM2 != null)
                SetBsiSaleTaxPrice(labelControlPrice2, tbPPM2.ppmSalePrice);
            if (tbPPM3 != null)
                SetBsiSaleTaxPrice(labelControlPrice3, tbPPM3.ppmSalePrice);
        }

        private void SaveTaxSettings()
        {
            MySetting.DefaultSetting.prdPriceTax = prdPriceTaxCheckEdit.Checked;
            MySetting.WriterSettingPublic();
        }

     

        private void InitPrdManufactureFlyoutPanel()
        {
            if (!this.isNew && CurrProduct?.prdStatus < 4) return;

            this.tbPrdManList = new List<tblPrdManufacture>();
            this.clsTbPrdMan = new ClsTblPrdManufacture();

            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(delegate
                {
                    InitFlyoutControls();
                }));
            else
                InitFlyoutControls();
        }

        private void InitFlyoutControls()
        {
            this.ucPrdMan = new UCprdManufacture(this, this.clsTbProduct, this.clsTbPrdMsur) { Dock = DockStyle.Fill };

            this.flyoutPanel = new FlyoutPanel() { OwnerControl = this };
            this.flyoutPanel.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Center;
            this.flyoutPanel.Options.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Slide;
            this.flyoutPanel.Controls.Add(this.ucPrdMan);
            this.flyoutPanel.AnimationRate = 60;
        }

        private void InitPrdManufactureData()
        {
            if (this.isNew || CurrProduct?.prdStatus < 4) return;

            var tbPrdManList = this.clsTbPrdMan.GetPrdManListByPrdId(CurrProduct?.id??0);

            this.tbPrdManList = tbPrdManList;
            this.tbPrdManListOld = tbPrdManList;
        }

        private void ShowPrdManufactureControl(bool showManPrd)
        {
            if (!showManPrd) return;
            if (!this.isNew && this.tbPrdManListOld == null) return;
            if (prdStatusTextEdit.SelectedIndex != 2 && prdStatusTextEdit.SelectedIndex != 3) return;

            this.flyoutPanel.Size = new System.Drawing.Size(this.Width - 50, this.Height - 200);
            this.flyoutPanel.ShowPopup();

            this.ucPrdMan.InitPrdManData();
            this.ucPrdMan.SetSelectedRows();
            this.Enabled = false;
        }

        private void labelShowPrdManufacture_Click(object sender, EventArgs e)
        {
            ShowPrdManufactureControl(true);
        }

        protected internal void HideFlyoutPanel()
        {
            this.flyoutPanel.HidePopup();
            this.Enabled = true;
        }

        protected internal void SetPrdManSalePrice()
        {
            double salePrice = 0;
            foreach (var tbPrdMan in this.tbPrdManList)
                salePrice += this.clsTbPrdMsur.GetPrdPriceMsurSalePrice(tbPrdMan.manPrdMsurId) * tbPrdMan.manQuan;

            ppmSalePriceTextEdit1.EditValue = salePrice;
        }

        private void LayoutControlGroupPPM2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            SetPPMLayoutGroupButtons(layoutControlGroupPPM2Main, layoutControlGroupPPM2Sub, (byte)e.Button.Properties.GroupIndex, 2);
            //ppmDefaultCheckEdit.Enabled = layoutControlGroupPPM2Sub.Enabled;
        }
        private void LayoutControlGroupPPM3_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            SetPPMLayoutGroupButtons(layoutControlGroupPPM3Main, layoutControlGroupPPM3Sub, (byte)e.Button.Properties.GroupIndex, 3);
        }

        private void SetPPMLayoutGroupButtons(LayoutControlGroup layoutGroupMain, LayoutGroup layoutGroupSub, byte val, byte validationVal)
        {
            if (val == 0 && validationVal == 3 && !layoutControlGroupPPM2Sub.Enabled)
            {
                XtraMessageBox.Show(_resource.GetString("PPM2ErrMssg"));
                return;
            }

            switch (val)
            {
                case 0:
                    InitPrdMsurObjects(validationVal);
                    layoutGroupSub.Enabled = true;
                    layoutGroupMain.HeaderButtonsLocation = GroupElementLocation.AfterText;
                    layoutGroupMain.CustomHeaderButtons[0].Properties.Visible = false;
                    layoutGroupMain.CustomHeaderButtons[1].Properties.Visible = true;
                    ConditionalValidation(validationVal, true);
                  
                    break;
                case 1:
                    if (validationVal == 2&& tbPPM2!=null)
                    { 
                        if (tbPPM2.ppmDefault)
                        {
                            ppmDefaultCheckEdit.EditValue = true;
                            tbPPM1.ppmDefault = true;
                        }
                        tblPrdPriceMeasurmentBindingSource2.DataSource = typeof(tblPrdPriceMeasurment);
                        tblBarcodeBindingSource2.DataSource = typeof(tblBarcode);
                        if(layoutControlGroupPPM3Sub.Enabled&& layoutGroupMain.CustomHeaderButtons[1].Properties.Visible)
                            SetPPMLayoutGroupButtons(layoutControlGroupPPM3Main, layoutControlGroupPPM3Sub,1, 3);
                    }
                    else if (validationVal == 3&& tbPPM3!=null)
                    {
                        if (tbPPM3.ppmDefault)
                        {
                            ppmDefaultCheckEdit2.EditValue = true;
                            tbPPM2.ppmDefault = true;
                        }
                        tblPrdPriceMeasurmentBindingSource3.DataSource = typeof(tblPrdPriceMeasurment);
                        tblBarcodeBindingSource3.DataSource = typeof(tblBarcode);
                    }
                    layoutGroupSub.Enabled = false;
                    layoutGroupMain.HeaderButtonsLocation = GroupElementLocation.AfterText;
                    layoutGroupMain.CustomHeaderButtons[0].Properties.Visible = true;
                    layoutGroupMain.CustomHeaderButtons[1].Properties.Visible = false;
                    ConditionalValidation(validationVal, false);
                    break;
                
            }
        }

        private void ConditionalValidation(byte val, bool isVlidation)
        {
            ConditionValidationRule conditionValidationRule = new ConditionValidationRule();
            conditionValidationRule.ConditionOperator = ConditionOperator.IsNotBlank;
            conditionValidationRule.ErrorText = _resource.GetString("fieldErrMssg");

            if (!isVlidation)
                conditionValidationRule = null;

            switch (val)
            {
                case 2:
                    dxValidationProvider1.SetValidationRule(ppmMsurNameTextEdit2, conditionValidationRule);
                    dxValidationProvider1.SetValidationRule(ppmPriceTextEdit2, conditionValidationRule);
                    dxValidationProvider1.SetValidationRule(ppmSalePriceTextEdit2, conditionValidationRule);
                    dxValidationProvider1.SetValidationRule(ppmMinSalePriceTextEdit2, conditionValidationRule);
                    dxValidationProvider1.SetValidationRule(ppmConversionTextEdit2, conditionValidationRule);
                    break;
                case 3:
                    dxValidationProvider1.SetValidationRule(ppmMsurNameTextEdit3, conditionValidationRule);
                    dxValidationProvider1.SetValidationRule(ppmPriceTextEdit3, conditionValidationRule);
                    dxValidationProvider1.SetValidationRule(ppmSalePriceTextEdit3, conditionValidationRule);
                    dxValidationProvider1.SetValidationRule(ppmMinSalePriceTextEdit3, conditionValidationRule);
                    dxValidationProvider1.SetValidationRule(ppmConversionTextEdit3, conditionValidationRule);
                    break;
            }
        }

        private void PrdGrpNoLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;
            if (Convert.ToInt32(editor.EditValue) == 0) return;

            int grpId = Convert.ToInt32(editor.GetColumnValue("id"));
            string productNo = (!this.isNew && this.grpIdOld == grpId) ? this.prdNoOld :
                editor.GetColumnValue("grpNo").ToString() + "-" +clsTbProduct.GetNewProductdNo(grpId);

            CurrProduct.prdNo = productNo;
            CurrProduct.prdGrpNo = grpId;

            this.grpAccNo = Convert.ToInt64(editor.GetColumnValue("grpAccNo"));
            this.grpName = Convert.ToString(editor.GetColumnValue("grpName"));

            prdNoTextEdit.EditValue = productNo;
        }
        void AddDataToSession()
        {
            if (Session.Products.Any(x => x.id == CurrProduct.id))
                Session.Products.Remove(Session.Products.FirstOrDefault(x => x.id == CurrProduct.id));
            if ((CurrProduct?.id ?? 0) > 0)
                Session.Products.Add(CurrProduct);
            if (Session.ProductQunatities.Any(x => x.id == CurrProductQ?.id))
                Session.ProductQunatities.Remove(Session.ProductQunatities.FirstOrDefault(x => x.id == CurrProductQ?.id));
            if ((CurrProductQ?.id ?? 0) > 0)
                Session.ProductQunatities.Add(CurrProductQ);
            AddPriceMeasurmentToSession(tbPPM1);
            AddPriceMeasurmentToSession(tbPPM2);
            AddPriceMeasurmentToSession(tbPPM3);
        }
        void AddPriceMeasurmentToSession(tblPrdPriceMeasurment priceMeas)
        {
            if (priceMeas == null) return;
            if (Session.tblPrdPriceMeasurment.Any(x => x.ppmId == priceMeas.ppmId))
                Session.tblPrdPriceMeasurment.Remove(Session.tblPrdPriceMeasurment.FirstOrDefault(x => x.ppmId == priceMeas.ppmId));
            if ((priceMeas?.ppmId ?? 0) > 0)
                Session.tblPrdPriceMeasurment.Add(priceMeas);

            IList<tblBarcode> BarcodeList;
            if (priceMeas.ppmStatus == 3) BarcodeList = BarcodeList3;
            else if (priceMeas.ppmStatus == 2) BarcodeList = BarcodeList2;
            else BarcodeList = BarcodeList1;
            BarcodeList.Where(x => !string.IsNullOrWhiteSpace(x.brcNo)).ToList().ForEach(x =>
            {
                if (Session.tblBarcode.Any(y => y.id == x.id))
                    Session.tblBarcode.Remove(Session.tblBarcode.FirstOrDefault(y => y.id == x.id));
                if ((x?.id ?? 0) > 0)
                    Session.tblBarcode.Add(x);
            });
        }
        void SaveProductData(accountingEntities db)
        {
            if (db.tblProducts.Any(x => x.id == CurrProduct.id))
            {
                var Baseitem = db.tblProducts.Find(CurrProduct.id);
                db.Entry(Baseitem).CurrentValues.SetValues(CurrProduct);
            }
            else
                db.tblProducts.Add(CurrProduct);
            db.SaveChanges();
            
        }
        void SaveProductQData(accountingEntities db)
        {
            if ((CurrProductQ?.prdStrId??0) == 0)
            {
               
                Session.tblStore.ForEach(y=>
                {
                    if (!db.tblProductQunatities.Any(x => x.prdStrId == y.id&& x.prdId == CurrProduct.id))
                    {
                        db.tblProductQunatities.Add(new tblProductQunatity()
                        {
                            prdStrId = y.id,
                            prdQuantity = 0,
                            prdSubQuantity = 0,
                            prdSubQuantity3 = 0,
                            prdBrnId = y.strBrnId,
                            prdStatus = CurrProduct.prdStatus ,
                            prdId= CurrProduct.id
                        });
                    }
                    //else
                    //{
                    //    var prQ = db.tblProductQunatities.FirstOrDefault(x => x.prdStrId == y.id && x.prdId == CurrProduct.id);
                    //    var Baseitem = db.tblProductQunatities.Find(prQ.id);
                    //    db.Entry(Baseitem).CurrentValues.SetValues(CurrProductQ);
                    //}
                });
            }
            else
            {
                if (db.tblProductQunatities.Any(x => x.id == CurrProductQ.id))
                {
                    var Baseitem = db.tblProductQunatities.Find(CurrProductQ.id);
                    db.Entry(Baseitem).CurrentValues.SetValues(CurrProductQ);
                }
                else
                {
                    if (CurrProductQ == null) InitPrdQuantity();
                    CurrProductQ.prdId = CurrProduct.id;
                    CurrProductQ.prdStatus = CurrProduct.prdStatus;
                    db.tblProductQunatities.Add(CurrProductQ);
                }
            }
        }
        void SavePrdPriceMeasurmentData(tblPrdPriceMeasurment priceMeas,accountingEntities db)
        {
            priceMeas.ppmPrdId = CurrProduct.id;
            if (db.tblPrdPriceMeasurments.Any(x => x.ppmId == priceMeas.ppmId))
            {
                var Baseitem = db.tblPrdPriceMeasurments.Find(priceMeas.ppmId);
                db.Entry(Baseitem).CurrentValues.SetValues(priceMeas);
            }
            else db.tblPrdPriceMeasurments.Add(priceMeas);
            db.SaveChanges();
            if (CurrProduct.prdStatus == 2) return;
            IList<tblBarcode> BarcodeList;
            if (priceMeas.ppmStatus == 3) BarcodeList = BarcodeList3;
            else if (priceMeas.ppmStatus == 2) BarcodeList = BarcodeList2;
            else  BarcodeList = BarcodeList1;
            BarcodeList.Where(x => !string.IsNullOrWhiteSpace(x.brcNo)).ToList().ForEach(x =>
            {
                x.brcPrdMsurId = priceMeas.ppmId;
                x.brcBrnId = priceMeas.ppmBrnId ?? Session.CurBranch.brnId;
                if (db.tblBarcode.Any(y => y.id == x.id))
                {
                    var Baseitem = db.tblBarcode.Find(x.id);
                    db.Entry(Baseitem).CurrentValues.SetValues(x);
                    //SaveBarcodeData(db.tblBarcode.FirstOrDefault(y => y.id == x.id), x);
                }
                else db.tblBarcode.Add(x);
            });
        }
        void SaveManuFactory(accountingEntities db)
        {
            this.tbPrdManList.ToList().ForEach(x =>
            {
                x.manPrdId = CurrProduct.id;
                if (db.tblPrdManufactures.Any(y => y.id == x.id))
                {
                    var man=db.tblPrdManufactures.FirstOrDefault(y => y.id == x.id);
                    man.id = x.id;
                    man.manPrdId = x.manPrdId;
                    man.manPrdMsurId = x.manPrdMsurId;
                    man.manPrdSubId = x.manPrdSubId;
                    man.manQuan = x.manQuan;
                }
                else db.tblPrdManufactures.Add(x);
            });
           
        }
        void UpdatePhasedInvociesFound(accountingEntities db)
        {
            if (this.isNew|| CurrProduct.prdGrpNo == this.grpIdOld) return;
            var sub = db.tblSupplySubs.Where(x => x.supDate >= Session.CurrentYear.fyDateStart && x.supDate <= Session.CurrentYear.fyDateEnd && x.supPrdId == CurrProduct.id
               && (x.supStatus == 7 || x.supStatus == 8 || x.supStatus == 10 || x.supStatus == 12)).ToList();
                sub.ForEach(y =>
                {
                    y.supStatus = GetUnPhasedStatus(y.supStatus);
                    y.supAccNo = this.grpAccNo;
                    y.supAccName = "مخزون " + (this.grpName ?? prdGrpNoLookUpEdit.Properties.GetDisplayText(prdGrpNoLookUpEdit.EditValue));
                    y.supPrdNo = CurrProduct.prdNo;
                    if (this.isPhasedInvociesFound)
                    {
                        if (db.tblSupplyMains.FirstOrDefault(x => x.id == y.supNo) is tblSupplyMain supplyMain && supplyMain != null && supplyMain.supStatus != y.supStatus)
                        {
                            supplyMain.supStatus = y.supStatus;
                            db.tblSupplySubs.Where(x => x.supNo == supplyMain.id).ToList().ForEach(a => a.supStatus = y.supStatus);
                        }
                        var tbAssetList = db.tblAssets.AsQueryable().Where(x => x.asBrnId == y.supBrnId && x.asDate >= Session.CurrentYear.fyDateStart && x.asDate <= Session.CurrentYear.fyDateEnd && x.asEntId == y.supNo && x.asStatus >= 5 && x.asStatus <= 8);
                        if (tbAssetList != null) db.tblAssets.RemoveRange(tbAssetList);
                    }
                });
        }
        private bool SaveData()
        {
            if (!ValidateData()) return false;

            using (var db = new accountingEntities())
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    flyDialog.WaitForm(this, 1);
                    UpdatePhasedInvociesFound(db);
                    SaveProductData(db);
                    SaveProductQData(db);
                    SavePrdPriceMeasurmentData(tbPPM1, db);
                    if (layoutControlGroupPPM2Sub.Enabled && CurrProduct.prdStatus != 2)
                    {
                        //if (tbPPM2.ppmConversion is double con && con != 0)
                        //    tbPPM2.ppmPrice = (tbPPM1.ppmPrice ?? 0) * con;

                        SavePrdPriceMeasurmentData(tbPPM2, db);
                        if (layoutControlGroupPPM3Sub.Enabled)
                        {
                            //if (tbPPM3.ppmConversion is double con2 && con2 != 0)
                            //    tbPPM3.ppmPrice = (tbPPM2.ppmPrice ?? 0) * con2;
                            SavePrdPriceMeasurmentData(tbPPM3, db);
                        }
                    }
                    if (CurrProduct.prdStatus == 4 || CurrProduct.prdStatus == 5)
                        SaveManuFactory(db);
                    db.SaveChanges();
                    transaction.Commit();
                   
                    flyDialog.WaitForm(this, 0);

                    return true;
                }
                catch (Exception ex)
                {
                    flyDialog.WaitForm(this, 0);
                    transaction.Rollback();
                    new ExceptionLogger(ex, "formAddProduct-UpdatePhasedInvoices2", true);
                    return false;
                }
            }
        }
        private bool ValidateData()
        {
            if (!dxValidationProvider1.Validate()) return false;
            if (!ValidateGrpNo()) return false;
            if (!ValidatePrdNo()) return false;
            if (!ValidateBarcode()) return false;
            if (!ValidateBarcodeNo()) return false;
            if (!ValidateDefaultStrId()) return false;
            if (!ValidateManufacturedProducts()) return false;

            return true;
        }
        private int  grpIdOld;
        private long grpAccNo;
        private string grpName = null;
        private string prdNoOld;
        private bool ValidateGrpNo()
        {
            if (this.isNew) return true;
            if (CurrProduct.prdGrpNo == this.grpIdOld) return true;

            bool isValid = true;
            bool isPrdPhaseFound = IsPrdFoundPhased(CurrProduct.id);
            this.isPhasedInvociesFound = false;

            if (isPrdPhaseFound)
            {
                string mssg = "سيقوم النظام بإلغاء الفواتير المرحلة للصنف. \n\nهل تريد المتابعة؟";
                isValid = ClsXtraMssgBox.ShowWarningYesNo(mssg) == DialogResult.Yes ? true : false;

                this.isPhasedInvociesFound = isValid;
            }

            return isValid;
        }
        public async Task RefrechAllDataProduct()
        {
            IList<Task> taskList = new List<Task>();
            taskList.Add(Task.Run(() => Session.GetDataProducts()));
            if (CurrProduct.prdStatus != 2)
            {
                taskList.Add(Task.Run(() => Session.GetDataBarcodes()));
                taskList.Add(Task.Run(() => Session.GetDataPrdMeasurments()));
            }
            if (CurrProduct.prdStatus == 4 || CurrProduct.prdStatus == 5)
                taskList.Add(Task.Run(() => Session.GetDataPrdManufacture()));
            taskList.Add(Task.Run(() => Session.GetDataProductQunatities()));
            taskList.Add(Task.Run(() => Session.GetDataProductPrices()));
            await Task.WhenAll(taskList);
        }
        bool IsPrdFoundPhased(int prdId)
        {
            using (var db = new accountingEntities())
                return db.tblSupplySubs.AsNoTracking().Any(x =>x.supDate >= Session.CurrentYear.fyDateStart 
                && x.supDate <= Session.CurrentYear.fyDateEnd && x.supPrdId == prdId 
                && (x.supStatus == 7 || x.supStatus == 8 ||x.supStatus == 10 || x.supStatus == 12));
        }
   
        private bool ValidateManufacturedProducts()
        {
            if (CurrProduct.prdStatus != (byte)ProductType.Manufacture) return true;
            bool isValid = (this.tbPrdManList?.Count >= 1) ? true : false;
            if (!isValid) ClsXtraMssgBox.ShowError("عذرا يجب إختيار مكونات الصنف أولاً!");
            return isValid;
        }

        private byte GetUnPhasedStatus(byte supStatus)
        {
            return ((SupplyType)supStatus) switch
            {
                SupplyType.PurchasePhase => (byte)SupplyType.Purchase,
                SupplyType.PurchasePhaseRtrn => (byte)SupplyType.PurchaseRtrn,
                SupplyType.SalesPhase => (byte)SupplyType.Sales,
                SupplyType.SalesPhaseRtrn => (byte)SupplyType.SalesRtrn,
                _ => supStatus
            };
        }

      

        private void ResetData()
        {
            ResetBarcode(tblBarcodeBindingSource1);
            ResetBarcode(tblBarcodeBindingSource2);
            ResetBarcode(tblBarcodeBindingSource3);
        }

        private void ResetBarcode(BindingSource tblBarcodeBindingSource)
        {
            tblBarcodeBindingSource.DataSource = null;
            tblBarcodeBindingSource.DataSource = typeof(tblBarcode);
        }

        private bool DeletePrdData()
        {
            using (var db=new accountingEntities())
            {
                if(db.tblProducts.Any(x=>x.id==CurrProduct.id))
                db.tblProducts.Remove(db.tblProducts.FirstOrDefault(x => x.id == CurrProduct.id));
                if (db.tblPrdPriceMeasurments.Any(x => x.ppmPrdId == CurrProduct.id))
                {
                    var tbPrdMsurList = db.tblPrdPriceMeasurments.Where(x => x.ppmPrdId == CurrProduct.id).ToList();
                    foreach (var item in tbPrdMsurList)
                        if(db.tblBarcode.Any(y => item.ppmId == y.brcPrdMsurId))
                            db.tblBarcode.RemoveRange(db.tblBarcode.Where(y => item.ppmId == y.brcPrdMsurId));
                    db.tblPrdPriceMeasurments.RemoveRange(tbPrdMsurList);
                }
                if (db.tblProductQunatities.Any(x => x.prdId == CurrProduct.id))
                    db.tblProductQunatities.RemoveRange(db.tblProductQunatities.Where(x => x.prdId == CurrProduct.id));
                if (db.tblPrdPriceQuans.Any(x => x.prPrdId == CurrProduct.id))
                    db.tblPrdPriceQuans.RemoveRange(db.tblPrdPriceQuans.Where(x => x.prPrdId == CurrProduct.id));

                if (db.tblPrdManufactures.Any(x => x.manPrdId == CurrProduct.id))
                    db.tblPrdManufactures.RemoveRange(db.tblPrdManufactures.Where(x => x.manPrdId == CurrProduct.id));
                return ClsSaveDB.Save(db, LogHelper.GetLogger());
            }
        }

        private bool ConfirmDelete()
        {
            return (ClsXtraMssgBox.ShowWarningYesNo($"هل أنت متاكد من حذف الصنف: {CurrProduct.prdName}؟") == DialogResult.Yes) ? true : false;
        }

        private bool ValidatePrdData()
        {
            using (var db=new accountingEntities())
            {
                bool isFound = db.tblSupplySubs.Any(x => x.supPrdId == CurrProduct.id);
                if (!ValidateMssg(isFound, "فواتير مترتبه على الصنف")) return false;

                isFound = db.tblProductQtyOpns.Any(x => x.qtyPrdId == CurrProduct.id);
                if (!ValidateMssg(isFound, "رصيد إفتتاحي لصنف")) return false;
                return true;
            }
        }

        private bool ValidateMssg(bool isFound, string mssg)
        {
            if (!isFound) return true;
            ClsXtraMssgBox.ShowError($"عذرا لا يمكن حذف الصنف بسبب وجود {mssg}!");
            return false;
        }

        private bool ValidateDefaultStrId()
        {
            bool isValid = (((CurrProductQ?.prdStrId)??0) < 0) ? false : true;
            if (!isValid)
            {
                string mssg = (!MySetting.GetPrivateSetting.LangEng) ? "عذراً يجب إختيار المخزن أولاً" : "Please select store first";
                XtraMessageBox.Show(mssg);
            }
            return isValid;
        }
    
        private bool ValidatePrdNo()
        {
            bool isValid = true;
            if (this.isNew && this.clsTbProduct.ValidatePrdNo(CurrProduct.prdNo)) isValid = false;
            if (!this.isNew && this.prdNoOld != CurrProduct.prdNo && this.clsTbProduct.ValidatePrdNo(CurrProduct.prdNo)) isValid = false;
            if (!isValid) XtraMessageBox.Show((!MySetting.GetPrivateSetting.LangEng) ? "عذرا رقم الصنف موجود مسبقا!" : "Sorry product number already exist!");

            return isValid;
        }

        private bool ValidateBarcode()
        {
            if (CurrProduct.prdStatus == 2) return true;
            UpdateBarcodeFocus();

            if (!ValidateBarcodeCount(gridViewBarcode1, "1")) return false;
            if (layoutControlGroupPPM2Sub.Enabled && !ValidateBarcodeCount(gridViewBarcode2, "2")) return false;
            if (layoutControlGroupPPM3Sub.Enabled && !ValidateBarcodeCount(gridViewBarcode3, "3")) return false;

            return true;
        }

        private void UpdateBarcodeFocus()
        {
            UpdateBarcodeFocus(gridViewBarcode1);
            if (layoutControlGroupPPM2Sub.Enabled) UpdateBarcodeFocus(gridViewBarcode2);
            if (layoutControlGroupPPM3Sub.Enabled) UpdateBarcodeFocus(gridViewBarcode3);
        }

        private void UpdateBarcodeFocus(GridView gridViewBarcode)
        {
            gridViewBarcode.PostEditor();
            gridViewBarcode.UpdateCurrentRow();
        }

        private bool ValidateBarcodeCount(GridView gridViewBarcode, string mssg)
        {
            for (short i = 0; i < gridViewBarcode.DataRowCount; i++)
                if (string.IsNullOrWhiteSpace(Convert.ToString(gridViewBarcode.GetRowCellValue(i, "brcNo"))))
                    gridViewBarcode.DeleteRow(i);

            bool isValid = gridViewBarcode?.DataRowCount > 0 ? true : false;

            if (!isValid) ClsXtraMssgBox.ShowError($"عذرا يجب إدخال رقم الباركود في وحدة القياس {mssg}");

            return isValid;
        }

        private bool ValidateBarcodeNo()
        {
            if (CurrProduct.prdStatus == 2) return true;

            if (!ValidateGridBarcodeNo(gridViewBarcode1, gridControlBarcode1)) return false;
            if (!ValidateGridBarcodeNo(gridViewBarcode2, gridControlBarcode2)) return false;
            if (!ValidateGridBarcodeNo(gridViewBarcode3, gridControlBarcode3)) return false;

            return true;
        }

        private bool ValidateGridBarcodeNo(GridView gridViewBarcode, GridControl gridControl)
        {
            for (short i = 0; i < gridViewBarcode.DataRowCount; i++)
            {
                var tbBarcode = gridViewBarcode.GetRow(i) as tblBarcode;

                if (tbBarcode == null) continue;
                if (tbBarcode.id != 0) continue;
                if (string.IsNullOrWhiteSpace(tbBarcode.brcNo)) continue;
                if (!IsBarcodeNoFound(tbBarcode)) continue;

                gridControl.Focus();
                gridViewBarcode.FocusedRowHandle = i;
                return false;
            }
            return true;
        }

        private bool IsBarcodeNoFound(tblBarcode tbBarcode)
        {
            bool isFound = this.clsTbBarcode.IsBarcodeNoFoundByNoNdMsurId(tbBarcode.brcNo, tbBarcode.brcPrdMsurId);
            if (isFound) ClsXtraMssgBox.ShowError(string.Format(_resource.GetString("BarcodeNoFoundMssg"), tbBarcode.brcNo));
            else
            {
                List<tblBarcode> bar = (tblBarcodeBindingSource1.List as IList<tblBarcode>).ToList();
                bar.AddRange(tblBarcodeBindingSource2.List as IList<tblBarcode>);
                bar.AddRange(tblBarcodeBindingSource3.List as IList<tblBarcode>);
                isFound = bar.Count(x => x.brcNo == tbBarcode.brcNo) > 1;
                if (isFound) ClsXtraMssgBox.ShowError(string.Format(_resource.GetString("BarcodeNoFoundInToUnitMssg"), tbBarcode.brcNo));
            }
            return isFound;
        }

        private void GridControlBarcode_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Delete) return;

            GridControl grid = sender as GridControl;
            if (grid == null) return;

            GridView view = grid.FocusedView as GridView;
            if (view == null) return;

            var tbBarcode = view.GetRow(view.FocusedRowHandle) as tblBarcode;

            if (tbBarcode == null) return;
            if (!ConfirmMssg(tbBarcode)) return;

            view.DeleteRow(view.FocusedRowHandle);
            if (tbBarcode.id != 0) this.clsTbBarcode.Remove(tbBarcode);
        }

        private bool ConfirmMssg(tblBarcode tbBarcode)
        {
            if (tbBarcode.id == 0) return true;

            bool isConfirmed = ClsXtraMssgBox.ShowWarningYesNo($"هل أنت متأكد من حذف الباركود رقم: {tbBarcode.brcNo}؟") == DialogResult.Yes ? true : false;

            return isConfirmed;
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
     
        private void ppmMsurNameTextEdit1_Enter(object sender, EventArgs e)
        {
            var edit = sender as BaseEdit;
            edit.LookAndFeel.UseDefaultLookAndFeel = false;
            edit.BackColor = Color.Yellow;
        }

        private void ppmMsurNameTextEdit1_Leave(object sender, EventArgs e)
        {
            var edit = sender as BaseEdit;
            edit.LookAndFeel.UseDefaultLookAndFeel = true;
            edit.BackColor = Color.White;
        }

        private void formAddProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (spinEdit2.ContainsFocus)
                    SetFocusToGrid(gridControlBarcode1, gridViewBarcode1);
                if (ppmBatchPriceTextEdit2.ContainsFocus)
                    SetFocusToGrid(gridControlBarcode2, gridViewBarcode2);
                if (ppmBatchPriceTextEdit3.ContainsFocus)
                    SetFocusToGrid(gridControlBarcode3, gridViewBarcode3);
            }
        }

        private void SetFocusToGrid(GridControl gridControlBarcode, GridView gridViewBarcode)
        {
            gridControlBarcode.Focus();
            gridViewBarcode.Focus();
            gridViewBarcode.AddNewRow();
        }

        private void InitSize()
        {
            this.Height = MySetting.GetPrivateSetting.formAddProductH;
            this.Width = MySetting.GetPrivateSetting.formAddProductW;
        }

        private void FormAddProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (prdStatusTextEdit.SelectedIndex == 4) return;
            MySetting.GetPrivateSetting.formAddProductH = this.Height;
            MySetting.GetPrivateSetting.formAddProductW = this.Width;
            MySetting.WriterSettingXml();
        }
        private void FormAddProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_ucStore != null && this.isRefreshData) _ucStore.RefreshData();
        }
       

        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng)
            {
                _ci = new CultureInfo("ar");
                _resource = new ComponentResourceManager(typeof(Language.StoreMangmentNotificationAr));
            }
            else
            {
                _ci = new CultureInfo("en");
                _resource = new ComponentResourceManager(typeof(Language.formAddProductEn));
            }

            if (MySetting.GetPrivateSetting.LangEng) EnglishTranslation();
        }

        private void EnglishLayout()
        {
            dataLayoutControl1.BeginUpdate();
            dataLayoutControl1.RightToLeft = RightToLeft.No;
            dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = false;
            dataLayoutControl1.EndUpdate();
            layoutControl1.BeginUpdate();
            layoutControl1.RightToLeft = RightToLeft.No;
            layoutControl1.OptionsView.RightToLeftMirroringApplied = false;
            layoutControl1.EndUpdate();
            
            dataLayoutControl2.BeginUpdate();
            dataLayoutControl2.RightToLeft = RightToLeft.No;
            dataLayoutControl2.OptionsView.RightToLeftMirroringApplied = false;
            dataLayoutControl2.EndUpdate();

            this.RightToLeft = RightToLeft.No;
        }

        private void EnglishTranslation()
        {
            EnglishLayout();

            foreach (LayoutControlItem grp in layoutControlGroupPPM1.Items)
                _resource.ApplyResources(grp, grp.Name, _ci);
            foreach (LayoutControlItem grp in layoutControlGroupPPM2Sub.Items)
                _resource.ApplyResources(grp, grp.Name, _ci);
            foreach (LayoutControlItem grp in layoutControlGroupPPM3Sub.Items)
                _resource.ApplyResources(grp, grp.Name, _ci);
            foreach (LayoutControlItem item in layoutControlGroup3.Items)
                _resource.ApplyResources(item, item.Name, _ci);
            foreach (var control in bindingNavigator11.Items)
                if (control is ToolStripItem c)
                    _resource.ApplyResources(c, c.Name, _ci);
            layoutControlGroupStore.Items.Where(x => x is LayoutControlItem).ForEach(x => _resource.ApplyResources(x, x.Name, _ci));

            
            _resource.ApplyResources(layoutControlGroup3, layoutControlGroup3.Name, _ci);
            _resource.ApplyResources(layoutControlGroup9, layoutControlGroup9.Name, _ci);
            _resource.ApplyResources(prdPurchaseTaxCheckEdit, prdPurchaseTaxCheckEdit.Name, _ci);
            prdGrpNoLookUpEdit.Properties.Columns[0].Caption = _resource.GetString("colGrpNo");
            prdGrpNoLookUpEdit.Properties.Columns[1].Caption = _resource.GetString("colGrpName");

            layoutControlGroupPPM2Main.CustomHeaderButtons[0].Properties.Caption = _resource.GetString("layoutControlGroupPPM2.CustomHeaderButtons");
            layoutControlGroupPPM2Main.CustomHeaderButtons[1].Properties.Caption = _resource.GetString("layoutControlGroupPPM2.CustomHeaderButtons12");
            layoutControlGroupPPM3Main.CustomHeaderButtons[0].Properties.Caption = _resource.GetString("layoutControlGroupPPM3.CustomHeaderButtons");
            layoutControlGroupPPM3Main.CustomHeaderButtons[1].Properties.Caption = _resource.GetString("layoutControlGroupPPM3.CustomHeaderButtons12");
            ItemForprdStatus.Text = _resource.GetString("ItemForprdStatus");
            prdSaleTaxCheckEdit.Text = _resource.GetString("prdSaleTaxCheckEdit");
            SuspendedCheckEdit.Text = _resource.GetString("SuspendedCheckEdit");
            ppmDefaultCheckEdit.Text = _resource.GetString("ppmDefaultCheckEdit");
            ppmDefaultCheckEdit2.Text = _resource.GetString("ppmDefaultCheckEdit2");
            ppmDefaultCheckEdit3.Text = _resource.GetString("ppmDefaultCheckEdit3");
            prdPurchaseTaxCheckEdit.Text = _resource.GetString("prdPurchaseTaxCheckEdit");
            prdPriceTaxCheckEdit.Text = _resource.GetString("prdPriceTaxCheckEdit");
            layoutControlItem2.Text = _resource.GetString("layoutControlItem2");
            layoutControlItem3.Text = _resource.GetString("layoutControlItem3");
            layoutControlGroupPPM2Main.Text = _resource.GetString("layoutControlGroupPPM2Main");
            layoutControlGroupPPM3Main.Text = _resource.GetString("layoutControlGroupPPM3Main");
            layoutControlGroupStore.Text = _resource.GetString("layoutControlGroupStore");
            layoutControlGroupPPM1.Text = _resource.GetString("layoutControlGroupPPM1");
            prdStatusTextEdit.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Default;

            this.Text = _resource.GetString("this.Text");
        }
    }
}
