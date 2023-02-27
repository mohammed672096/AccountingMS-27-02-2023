using PosFinalCost.Classe;
using CSHARPDLL;
using DevExpress.DataProcessing;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using Timer = System.Windows.Forms.Timer;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTab;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors.DXErrorProvider;

namespace PosFinalCost.Forms
{
    public partial class UC_AddEntry : UserControl
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        Customer tbCustomer;
        FormSearchProduct FormDialogPrdSearch;
        FlyoutDialog flyDialogOrders;
        Box DefaultBoxObject;
        Bank DefaultBankObject;
        Timer ecrTimer = new Timer();
        public bool isNew;
        private readonly EntryType EntryType;
        private bool gridValid = true;
        public UC_AddEntry(EntryMain obj, IEnumerable<EntrySub> subObj, EntryType EntryType)
        {
            this.EntryType = EntryType;
            InitializeComponent();
            new ClsUserRoleValidation(this, UserControls.Sale);
            this.Load += UC_AddEntry_Load;
            DefaultBoxObject = Session.Boxes.FirstOrDefault(x => x.ID == (short)Session.CurrSettings.DefaultBox);
            DefaultBankObject = Session.Banks.FirstOrDefault(x => x.ID == (short)Session.CurrSettings.DefaultBank);
            InitDefaultData();
            InitData(obj, subObj);
            GetResources();
            InitEvents();
            ClsPath.ReLodeCustomContol(this.dataLayConMain, this.Name + this.EntryType);
            ClsPath.ReLodeCustomContol(this.gridView, this.Name + this.EntryType);
        }
        #region Events
        private void UC_AddEntry_Load(object sender, EventArgs e)
        {
            Task.Run(() => InitFlyDialogPrdSrch());
            layoutControlGrooupMain.BestFit();
            SetSettingSales();
            var Su = EntryMainBindingSource.Current as EntryMain;
            Task.Run(() => SetFont());
            ValidationProvider(supNoTextEdit);
            ValidationProvider(PersonTextEdit);
            ValidationProvider(BoxNoLookUpEdit);
            ValidationProvider(textEditPaidCash);
        }
        TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
        public void SetFont()
        {
            this.Invoke(new MethodInvoker(delegate {
                if (Program.My_Setting.SystemFontSale == Program.My_Setting.SystemFont) return;
                Font fontConverter = (Font)converter.ConvertFromString(Program.My_Setting.SystemFontSale);
                this.layoutControlGrooupMain.AppearanceItemCaption.Font = fontConverter;
                dataLayConMain.Items.Where(x => x is LayoutControlItem).ToList().ForEach(y =>
                ((LayoutControlItem)y).Owner.Appearance.Control.Font = fontConverter);
                bindingNavigator11.Font = fontConverter;
                this.gridControl.Views.Where(x => x is GridView).ToList().ForEach(y =>
                ((GridView)y).Appearance.Row.Font = ((GridView)y).Appearance.HeaderPanel.Font = fontConverter);
                reposItemSearchLookCustomer.View.Appearance.Row.Font =
                reposItemSearchLookCustomer.View.Appearance.HeaderPanel.Font =
                repositoryItemSearchLookUpEditAcc.View.Appearance.HeaderPanel.Font =
                repositoryItemSearchLookUpEditAcc.View.Appearance.Row.Font =
                    repositoryItemLookUpEditCusName.AppearanceDropDownHeader.Font =
                repositoryItemLookUpEditCusName.AppearanceDropDown.Font = fontConverter;
            }));

        }
        private void SetSettingSales()
        {
            radioGroupPayMethod.ReadOnly = !Session.CurrSettings.CanChangePayMethod;
        }
        private void InitEvents()
        {
            radioGroupPayMethod.EditValueChanged += RadioGroupPayMethod_EditValueChanged;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
            gridView.CellValueChanging += GridView_CellValueChanging;
            gridView.FocusedColumnChanged += GridView_FocusedColumnChanged;
            gridView.ShowCustomizationForm += GridView_ShowCustomizationForm;
            gridView.HideCustomizationForm += GridView_HideCustomizationForm;
            dataLayConMain.ShowCustomization += DataLayoutControl1_ShowCustomization;
            dataLayConMain.HideCustomization += DataLayoutControl1_HideCustomization;
            gridView.ValidatingEditor += GridView_ValidatingEditor;
            gridView.InvalidRowException += GridView_InvalidRowException;
            btnClose.Click += BbiClose_Click;
            btnPrintPrevious.Click += BbiPrintPrevious_Click;
            btnReset.Click += btnReset_Click;
            btnSave.Click += BbiSave_Click;
            btnSaveAndNew.Click += BbiSaveAndNew_Click;
            btnSaveAndNewNoPrint.Click += bbiSaveAndNewNoPrint_Click;
            //gridView.CustomUnboundColumnData += GridView_CustomUnboundColumnData;
            //repositoryItemSearchLookUpEdit1View.CustomUnboundColumnData += RepositoryItemSearchLookUpEdit1View_CustomUnboundColumnData;
            supCurrTextEdit.EditValueChanged += SupCurrTextEdit_EditValueChanged;
            BoxNoLookUpEdit.EditValueChanged += BoxNoLookUpEdit_EditValueChanged;
        }

        public bool FunClose() => (XtraMessageBox.Show(_resource.GetString("CloseFormMssgEntry"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes);
        private void BbiClose_Click(object sender, EventArgs e)
        {
            if (!FunClose()) return;
            ClsPath.SaveCustomContol(this.gridView, this.Name + this.EntryType);
            ClsPath.SaveCustomContol(this.dataLayConMain, this.Name + this.EntryType);
            if (this.Parent.Parent is XtraTabControl c && c.TabPages.Count() > 1)
                (this.Parent as XtraTabPage).Dispose();
            else
                this.ParentForm.Close();
        }
        private void bbiSaveAndNewNoPrint_Click(object sender, EventArgs e)
        {
            SaveAndNew(false);
        }
        private void BbiSave_Click(object sender, EventArgs e)
        {
            if (!SaveData()) return;
            EntryMain tbEntryMain = GetCurEntryMain();
            string mssg = string.Format(_resource.GetString((this.EntryType == EntryType.EntryReceipt) ? "rcptSuccessMssg" : "vchrSuccessMssg"), tbEntryMain.No);
            Form temp = this.ParentForm;
            if (this.Parent.Parent is XtraTabControl c && c.TabPages.Count() > 1)
            {
                (this.Parent as XtraTabPage).Dispose();
                flyDialog.ShowDialogForm(temp, mssg, this.isNew);
            }
            else
            {
                this.ParentForm.Close();
                flyDialog.ShowDialogForm(((FormEntryMain)temp).parent1, mssg, this.isNew);
            }

        }
        private void BbiSaveAndNew_Click(object sender, EventArgs e)
        {
            SaveAndNew(true);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (Session.CurrSettings.ShowResetMssg)
                if (ClsXtraMssgBox.ShowWarningYesNo("هل أنت متأكد من إعادة التهيئه؟ \nسيتم حذف جميع البيانات!") == DialogResult.No) return;
            ResetData();
        }
    
        private void BbiPrintPrevious_Click(object sender, EventArgs e)
        {
            ShowPrintEntry(true);
        }
        private void BoxNoLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;
            if (editor.GetColumnValue("Name") == null) return;
            var tbEntryMain = GetCurEntryMain();
            tbEntryMain.AccNo = Convert.ToInt64(editor.GetColumnValue("AccNo"));
            tbEntryMain.Currency = Convert.ToByte(editor.GetColumnValue("Currency"));
        }
        EntryMain GetCurEntryMain() => EntryMainBindingSource.Current as EntryMain;
        private void RadioGroupPayMethod_EditValueChanged(object sender, EventArgs e)
        {
            var tbEntryMain = GetCurEntryMain();
            if (tbEntryMain == null || ((radioGroupPayMethod.EditValue as byte?) ?? 0) == 0) return;
            tbEntryMain.PayMethod = (radioGroupPayMethod.EditValue as byte?) ?? 0;
            PayMethod();
        }
      
        private void SupCurrTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;
            if (editor.GetColumnValue("Name") == null) return;
            var tbEntryMain = GetCurEntryMain();
            if (tbEntryMain != null)
            {
                if (tbEntryMain.Currency > 1)
                {
                    tbEntryMain.Currency = Convert.ToByte(editor.GetColumnValue("ID"));
                    tbEntryMain.CurChange = Convert.ToInt16(editor.GetColumnValue("Change"));
                    CurChangeTextEdit.EditValue = editor.GetColumnValue("Change");
                    ItemForCurChange.Enabled = true;
                }
                else
                {
                    tbEntryMain.CurChange = null;
                    CurChangeTextEdit.EditValue = null;
                    ItemForCurChange.Enabled = false;
                }
            }
        }

        private void DataLayoutControl1_HideCustomization(object sender, EventArgs e)
        {
            ClsPath.SaveCustomContol(this.dataLayConMain, this.Name + this.EntryType);
        }
        private void DataLayoutControl1_ShowCustomization(object sender, EventArgs e)
        {
            ((DataLayoutControl)sender).CustomizationForm.Text = "تغيير التصميم";
        }

        #endregion
        #region Function
        private void InitDefaultData()
        {
            customerBindingSource.DataSource = Session.Customers;
            BoxNoLookUpEdit.Properties.DataSource = Session.Boxes;
            BoxNoLookUpEdit.ReadOnly = !Session.CurrSettings.CanChangeBox;
            supCurrTextEdit.IntializeData(Session.Currencies);
        }
        private void InitData(EntryMain obj, IEnumerable<EntrySub> subObj)
        {
            this.isNew = obj == null;
            if (obj == null)
            {
                InitEntryMainObj();
                gridControl.ProcessGridKey += GridControl_ProcessGridKey;
            }
            else
            {
                EntryMainBindingSource.DataSource = obj;
                EntrySubBindingSource.DataSource = subObj;
                DisableItems();
                SetGridProperties();
                EnabledORDisabledUpdate(false);
            }
        }
        public void EnabledORDisabledUpdate(bool Enabled)
        {
            dataLayConMain.OptionsView.IsReadOnly = Enabled ? DevExpress.Utils.DefaultBoolean.False : DevExpress.Utils.DefaultBoolean.True;
            gridView.OptionsBehavior.ReadOnly = !Enabled;
            bindingNavigator11.Enabled = gridView.OptionsBehavior.Editable = Enabled;
        }
        private void InitEntryMainObj()
        {

            EntryMain EntryMain = new EntryMain()
            {
                Date = DateTime.Now,
                PayMethod = (byte)1,
                AccNo = DefaultBoxObject?.AccNo,
                UserID = Session.CurrentUser.ID,
                BranchID = Session.CurrentBranch.ID,
                Status = (byte)EntryType,
                Amount = 0,
                Currency = DefaultBoxObject?.Currency,
            };
            //EntryMain.No = this.EntryType != EntryType.SalesRtrn ? Session.MaxNoInv : 0;
            EntryMainBindingSource.DataSource = EntryMain;
        }
        #endregion

        private void PayMethod()
        {
            var tbEntryMain = GetCurEntryMain();
            if (tbEntryMain != null)
            {
                if (isNew)
                    switch (tbEntryMain.PayMethod)
                    {
                        case 1:
                            ItemForBoxNo.Text = "الصندوق:";
                            BoxNoLookUpEdit.Properties.Columns["No"].Caption = "رقم الصندوق";
                            BoxNoLookUpEdit.Properties.Columns["Name"].Caption = "اسم الصندوق";
                            BoxNoLookUpEdit.Properties.DataSource = Session.Boxes;
                            tbEntryMain.AccNo = DefaultBoxObject.AccNo;
                            tbEntryMain.Currency = DefaultBoxObject.Currency;
                            break;
                        case 2:
                            ItemForBoxNo.Text = "البنك:";
                            BoxNoLookUpEdit.Properties.Columns["No"].Caption = "رقم البنك";
                            BoxNoLookUpEdit.Properties.Columns["Name"].Caption = "اسم البنك";
                            BoxNoLookUpEdit.Properties.DataSource = Session.Banks;
                            tbEntryMain.AccNo = DefaultBankObject.AccNo;
                            tbEntryMain.Currency = DefaultBankObject.Currency;
                            break;
                        default:
                            break;
                    }
            }
        }
     
        private void InitNewRowObject(EntrySub EntrySub, double QuanMain1 = 1)
        {
            EntrySub.Currency = this.tbCustomer.Currency;
            EntrySub.CustomerID = this.tbCustomer.ID;
            EntrySub.AccNo = this.tbCustomer.AccNo;
        }
        EntrySub temp = new EntrySub();
       
        public void InitPrdSrch()
        {
            var pro = FormDialogPrdSearch.gridViewSrchPrd.GetFocusedRow() as Product;
            //if (pro != null)
            //GridView_CellValueChanging(gridView, new CellValueChangedEventArgs(-2147483647, colsupPrdNo, pro.ID));
        }
        private void GridViewSrchPrd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) InitPrdSrch();
            else if (e.KeyCode == Keys.F5) FormDialogPrdSearch.Close();
        }

        private void GridViewSrchPrd_DoubleClick(object sender, EventArgs e)
        {
            InitPrdSrch();
        }
        private void repItemButEditSelectPro_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            InitPrdSrch();
        }
        private void GridView_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                EntrySub row = EntrySubBindingSource.Current as EntrySub;
                if (row == null && e.Column.FieldName != nameof(temp.CustomerID)) return;
                switch (e.Column.FieldName)
                {
                    case nameof(temp.CustomerID):
                        if (row == null || e.RowHandle < 0)
                        {
                            gridView.AddNewRow();
                            gridView.UpdateCurrentRow();
                        }
                        this.tbCustomer = Session.Customers.FirstOrDefault(x => x.ID == ((e.Value as int?) ?? 0));
                        if (!GetData((e.Value as int?) ?? 0)) return;
                        row = EntrySubBindingSource.Current as EntrySub;
                        InitNewRowObject(row);
                        break;
                    //case nameof(temp.DscntPercent):
                    //    row.DscntPercent = double.Parse(e.Value.ToString());
                    //    row.DscntAmount = row.DscntPercent != 0 ? (row.SalePrice * (row.DscntPercent / 100)) * row.QuanMain : 0;
                    //    CalculateAllInGridViewRow(row);
                    //    break;
                    //case nameof(temp.DscntAmount):

                    //    row.DscntAmount = double.Parse(e.Value.ToString());
                    //    row.DscntPercent = row.DscntAmount != 0 ? (row.DscntAmount / (row.SalePrice * row.QuanMain)) * 100 : 0;
                    //    CalculateAllInGridViewRow(row);
                    //    break;
                    //case nameof(temp.Total):
                    //    //if (row.TaxPrice > 0)
                    //    //{
                    //    if (row.SalePrice == 0) return;
                    //    var discount = 1 - ((double.Parse(e.Value.ToString()) / row.QuanMain) / (row.SalePrice * (1 + (row.TaxPercent / 100))));
                    //    row.SalePrice = (row.SalePrice - (row.SalePrice * discount));
                    //    //}
                    //    GridView_CellValueChanging(sender, new CellValueChangedEventArgs(gridView.FocusedRowHandle, colsupSalePrice, row.SalePrice));
                    //    break;
                    default:
                        break;
                }
                gridView.RefreshData();
            }
            catch (Exception ex)
            {

            }
        }
        private void GridView_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (Session.PrdMeasurments == null) return;
            if (e.Column.FieldName == "Msur")
                e.DisplayText = Session.PrdMeasurments.Where(x => x.ID == Convert.ToInt32(e.Value)).Select(x => x.Name).FirstOrDefault();
            else if (e.Column.FieldName == "Currency")
                e.DisplayText = Session.Currencies.Where(x => x.ID == Convert.ToInt16(e.Value)).Select(x => x.Name).FirstOrDefault();
        }


        private void GridView_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            //if (e.FocusedColumn == colMsur && this.tbCustomer.Product != null)
            //    PrdMeasurmentBindingSource.DataSource = Session.PrdMeasurments.Where(x => x.PrdId == this.tbCustomer.Product.ID);
        }

        private void RepositoryItemCalcEdit1SalePrice_CloseUp(object sender, CloseUpEventArgs e)
        {
            if (Convert.ToDecimal(e.Value) > (decimal)999999999999999999.99) e.AcceptValue = false;
        }

        private void GridView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
        bool ValidPrice;
        private void GridView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            e.Valid = ValidPrice;
            return;
            //GridView view = sender as GridView;
            //if (view == null) return;
            //if (Convert.ToDecimal(gridView.GetRowCellValue(e.RowHandle, colsupSalePrice)) > (decimal)999999999999999999.99)
            //{
            //    e.Valid = false;
            //    view.SetColumnError(colsupSalePrice, "المبلغ الذي ادخلته غير صحيح");
            //    e.ErrorText = (!Program.My_Setting.LangEng) ? "عذرا المبلغ الذي ادخلته غير صحيح" : "Sorry wrong input value";
            //    this.gridValid = false;
            //}
            //else
            //    this.gridValid = true;

        }
        private void GridView_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            //if (view?.FocusedColumn == colsupSalePrice)
            //{
            //    if (Convert.ToDecimal(e.Value) > (decimal)99999999999999999.99)
            //    {
            //        this.gridValid = false;
            //        e.Valid = false;
            //        e.ErrorText = (!Program.My_Setting.LangEng) ? "عذرا المبلغ الذي ادخلته غير صحيح" : "Sorry wrong input value";
            //        XtraMessageBox.Show((!Program.My_Setting.LangEng) ? "عذرا المبلغ الذي ادخلته غير صحيح" : "Sorry wrong input value");
            //    }
            //    else this.gridValid = true;
            //}

        }
        private bool GetData(int CustomerID = 0)
        {
            if (CustomerID == 0) return false;
            this.tbCustomer = Session.Customers.FirstOrDefault(x => x.ID == CustomerID);
            return this.tbCustomer != null;
        }
        DXValidationProvider dxValidationProvider = new DXValidationProvider();
        private void ValidationProvider(BaseEdit edit)
        {
            ConditionValidationRule conditionValidationRule1 = new ConditionValidationRule();
            conditionValidationRule1.ConditionOperator = ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "يجب إدخال هذا الحقل!";
            dxValidationProvider.SetValidationRule(edit, conditionValidationRule1);
        }
        private bool SaveData(bool printInvoice = true)
        {
            bool isSaved = false;
            if(!dxValidationProvider.Validate())return false;
            EntryMain tbEntryMain = GetCurEntryMain();
            if (tbEntryMain == null) return false;
            var curList = (EntrySubBindingSource.List as IList<EntrySub>);
            try
            {
                if (curList.Count <= 0)
                {
                    XtraMessageBox.Show(_resource.GetString("GridErrorMssg"));
                    return false;
                }
                if (this.EntryType == EntryType.EntryReceipt)
                {
                    if (tbEntryMain.Amount == 0)
                    {
                        XtraMessageBox.Show((!Program.My_Setting.LangEng) ? "عذرا يجب ان لا تكون قيمة السند 0" : "Sorry invoice amount can not be 0");
                        return false;
                    }
                    double eAmount = tbEntryMain.Amount * ((tbEntryMain.CurChange as short?)??1);
                    if (eAmount != curList.Sum(x => x.Dain))
                    {
                        XtraMessageBox.Show(_resource.GetString("validateAmountMssg"));
                        return false;
                    }
                }
                using (var db = new PosDBDataContext(Program.ConnectionString))
                {
                    if (this.isNew)
                    {
                        Session.GetMaxNoInv(db);
                        var temp = db.EntryMains.Where(x => x.BranchID == Session.CurrentBranch.ID && x.Date >= Session.CurrentYear.DateStart
                                   && x.Date <= Session.CurrentYear.DateEnd && (x.Status == (byte)this.EntryType)).AsQueryable();
                        if (temp.Count() > 0)
                            tbEntryMain.No = temp.Any(x => x.No == tbEntryMain.No) ? temp.Max(x => x.No) + 1 : tbEntryMain.No;
                        db.EntryMains.InsertOnSubmit(tbEntryMain);
                        db.SubmitChanges();
                        curList.ForEach(x =>
                        {
                            x.ParentID = tbEntryMain.ID;
                            x.BranchID = tbEntryMain.BranchID;
                            x.Date = tbEntryMain.Date.GetValueOrDefault();
                            x.Status = tbEntryMain.Status;
                        });
                        db.EntrySubs.InsertAllOnSubmit(curList);
                    }
                    else
                    {
                        db.EntryMains.DeleteOnSubmit(db.EntryMains.FirstOrDefault(x => x.ID == tbEntryMain.ID));
                        db.EntryMains.InsertOnSubmit(tbEntryMain);
                        curList.ForEach(x =>
                        {
                            x.ParentID = tbEntryMain.ID;
                            x.BranchID = tbEntryMain.BranchID;
                            x.Date = tbEntryMain.Date.GetValueOrDefault();
                            x.Status = tbEntryMain.Status;
                            db.EntrySubs.DeleteAllOnSubmit(db.EntrySubs.Where(y => y.ID == x.ID));
                        });
                        db.EntrySubs.InsertAllOnSubmit(curList);
                    }
                    db.SubmitChanges();
                    if (printInvoice)
                        ShowPrintEntry();
                    //Session.GetDataProductQunatities(db);
                    isSaved = true;
                }
            }
            catch (Exception ex)
            {
                ClsXtraMssgBox.ShowError(ex.Message);
                return false;
            }
            //if (Program.My_Setting.SendInvoToServerOnSave && this.isNew)
            //{
            //    List<EntrySub> tbEntrySubList = myFunaction.GetCopyFromEntrySub(curList.ToList());
            //    EntryMain temp = myFunaction.GetCopyFromEntryMain(tbEntryMain);
            //    Task.Run(() => new UploadDataToMain(temp, tbEntrySubList));
            //}
            return isSaved;
        }
        private void SaveAndNew(bool printInvoice)
        {
            if (!SaveData(printInvoice)) return;
            EntryMain tbEntryMain = GetCurEntryMain();
            //string mssg = string.Format(_resource.GetString((this.EntryType == EntryType.Sales) ? "saleSuccessMssg" : "saleRtrnSuccessMssg"), tbEntryMain.No);
            //flyDialog.ShowDialogUC(this, mssg,this.isNew);
            ResetData();
            this.isNew = true;
        }
        MyFunaction myFunaction = new MyFunaction();
        private void bbiPriceOffer_ItemClick(object sender, ItemClickEventArgs e)
        {
            ////flyDialog.WaitForm(this, 1);
            ////this.flyDialogOrders = ClsFlyoutDialog.InitFlyoutDialog(this, new ucOrders(OrderType.PriceOffer, this)
            ////{ Dock = DockStyle.Fill, Height = (ClientSize.Height / 2) + 100 }, ClsOrderStatus.GetStringPlural(5));
            ////flyDialog.WaitForm(this, 0);

            this.flyDialogOrders.MouseCaptureChanged += FlyDialogOrders_MouseCaptureChanged;
            this.flyDialogOrders.Show();

            SetFormState(false);
        }

        private void SetFormState(bool isEnabled)
        {
            ////_formSupplyMain.Enabled = isEnabled;
        }

        private void FlyDialogOrders_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (this.flyDialogOrders.DialogResult != DialogResult.Yes) return;

            SetFormState(true);
            this.flyDialogOrders.Close();
        }
        private void ResetData()
        {
            InitEntryMainObj();
            InitEntrySubGridObj();
            this.gridValid = true;
        }
        private void InitEntrySubGridObj()
        {
            EntrySubBindingSource.DataSource = null;
            EntrySubBindingSource.DataSource = typeof(EntrySub);
        }
        IList<EntrySub> curList;
        private void ShowPrintEntry(bool PrintBefor = false)
        {
            EntryMain tbEntryMain = GetCurEntryMain();
            int No = tbEntryMain != null ? tbEntryMain.No : 0;
            //if (!PrintBefor)
            //    curList = myFunaction.GetCopyFromEntrySub((EntrySubBindingSource.List as IList<EntrySub>).ToList());
            //else
            //{
            //    tbEntryMain = null;
            //    No--;
            //}
            //if (Session.CurrSettings.ShowPrintMssg)
            //    if (ClsXtraMssgBox.ShowQuesPrint(string.Format(_resource.GetString("printMssg"),No)) != DialogResult.Yes) return;
            //if (Session.CurrSettings.InvoicePrintMode == ((byte)PrintMode.Direct))
            //    Task.Run(() => myFunaction.PrintInvoice(No,curList, tbEntryMain));
            //else
            //{
            //    flyDialog.WaitForm(this, 1);
            //    myFunaction.PrintInvoice(No, curList, tbEntryMain);
            //    flyDialog.WaitForm(this, 0);
            //}
        }

        private void GridControl_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (!this.isNew) return;

            switch (e.KeyData)
            {
                case Keys.Delete:
                    DeleteRow();
                    e.Handled = true;
                    break;
                    //case Keys.Enter:
                    //    textEditBarcodeNo.Focus();
                    //    e.Handled = true;
                    //    break;
                    //case Keys.Add:
                    //case Keys.Subtract:
                    //    UpdateQuantity(e);
                    //    break;
            }
        }

        private void DeleteRow()
        {
            gridView.DeleteSelectedRows();
        }

        private void layoutControlGroup8_CustomDrawBackground(object sender, GroupBackgroundCustomDrawEventArgs e)
        {
            e.DefaultDraw();
            e.Graphics.FillRectangle(System.Drawing.Brushes.AliceBlue, e.Bounds);
            e.Handled = true;
        }
        private void DisableItems()
        {
            radioGroupPayMethod.Enabled = false;
        }

        private void SetGridProperties()
        {
            gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
        }
        private void DisableGridColumns(GridColumn column)
        {
            column.OptionsColumn.AllowEdit = false;
            column.OptionsColumn.AllowFocus = false;
            column.OptionsColumn.TabStop = false;
        }
        private void AllowGridColumns(GridColumn column)
        {
            column.OptionsColumn.AllowEdit = true;
            column.OptionsColumn.AllowFocus = true;
            column.OptionsColumn.TabStop = true;
        }

        private void GridView_HideCustomizationForm(object sender, EventArgs e)
        {
            ClsPath.SaveCustomContol(this.gridView, this.Name + this.EntryType);
        }

        private void GridView_ShowCustomizationForm(object sender, EventArgs e)
        {
            ((GridView)sender).CustomizationForm.Text = "تحديد الأعمده";
        }
        private void InitFlyDialogPrdSrch()
        {
            if (this.InvokeRequired) this.Invoke(new MethodInvoker(delegate { InitFlyoutControls(); }));
            else InitFlyoutControls();
        }
        private void InitFlyoutControls()
        {
            this.FormDialogPrdSearch = new FormSearchProduct();
            FormDialogPrdSearch.gridViewSrchPrd.KeyDown += GridViewSrchPrd_KeyDown;
            FormDialogPrdSearch.gridViewSrchPrd.DoubleClick += GridViewSrchPrd_DoubleClick;
            FormDialogPrdSearch.repItemButEditSelectPro.ButtonClick += repItemButEditSelectPro_ButtonClick;
        }
        public void ShowPrdSearchPanel() => this.FormDialogPrdSearch.ShowDialog();
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            DeleteRow();
        }

        private void GetResources()
        {
            if (!Program.My_Setting.LangEng)
            {
                _ci = new CultureInfo("ar");
                _resource = new ComponentResourceManager(typeof(Language.UC_MasterInvoiceAr));
            }
            else
            {
                _ci = new CultureInfo("en");
                _resource = new ComponentResourceManager(typeof(Language.UC_MasterInvEn));
                EnglishTranslation();
            }
            foreach (var control in bindingNavigator11.Items)
                if (control is ToolStripItem c)
                    _resource.ApplyResources(c, c.Name, _ci);
        }
        private void EnglishLayout()
        {
            dataLayConMain.BeginUpdate();
            dataLayConMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataLayConMain.OptionsView.RightToLeftMirroringApplied = false;
            dataLayConMain.EndUpdate();
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        }
        private void EnglishTranslation()
        {
            EnglishLayout();

            try
            {
                foreach (LayoutControlItem item in layoutControlGrooupMain.Items)
                    _resource.ApplyResources(item, item.Name, _ci);
            }
            catch { }


            try
            {
                foreach (GridColumn col in gridView.Columns)
                    _resource.ApplyResources(col, col.Name, _ci);
            }
            catch { }
            try { _resource.ApplyResources(layoutControlGrooupMain, layoutControlGrooupMain.Name, _ci); } catch { }
            try { _resource.ApplyResources(btnSave, btnSave.Name, _ci); } catch { }
            try { _resource.ApplyResources(btnClose, btnClose.Name, _ci); } catch { }

            try { BoxNoLookUpEdit.Properties.Columns[0].Caption = _resource.GetString("colAccNo"); } catch { }
            try { BoxNoLookUpEdit.Properties.Columns[1].Caption = _resource.GetString("colAccName"); } catch { }

            //try { repositoryItemSearchLookUpEditPrdNo.View.Columns[2].Caption = _resource.GetString("colprdName.Caption"); } catch { }
            //this.Text = (this.EntryType == EntryType.Sales) ? _resource.GetString("this.Sale") : _resource.GetString("this.SaleRtrn");
            try { btnReset.Text = _resource.GetString("btnReset"); } catch { }
            try { layoutControlGrooupMain.Text = _resource.GetString("layoutControlGrooupMain"); } catch { }
            try { ItemForPoNumber.Text = _resource.GetString("ItemForPoNumber"); } catch { }
            try { ItemForNotes.Text = _resource.GetString("ItemForNotes"); } catch { }
        }
    }
}
