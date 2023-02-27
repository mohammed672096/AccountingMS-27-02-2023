using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class UCtaxDeclaration : XtraUserControl
    {
        ComponentFlyoutDialog flyDailog = new ComponentFlyoutDialog();
        IEnumerable<tblSupplyMain> tbSupplyMainList;
        IEnumerable<tblEntrySub> tblEntrySubList;
        List<tblTaxAccount> tbTaxAccountList = new List<tblTaxAccount>();
        ClsTblBranch ClsTblBranch = new ClsTblBranch();
        public UCtaxDeclaration()
        {
            InitializeComponent();
            if (Session.CurrentUser.id == 1)
            {
                ItemForBranch.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                var tbBranchList = ClsTblBranch.GetBranchList();
                tblBranch bra = new tblBranch { brnNo = 0, brnName = "كل الفروع" };
                tbBranchList.Insert(0, bra);
                tblBranchBindingSource.DataSource = tbBranchList;
            }
            TaxDeclaration declaration = new TaxDeclaration();
            declaration.BranchID = Session.CurBranch.brnId;
            declaration.FromDate = Session.CurrentYear.fyDateStart.Date;
            declaration.ToDate = DateTime.Now;

            taxDeclarationBindingSource.DataSource = declaration;
            InitData();
            InitTextEdit();
            textEditDateEnd.DateTime = DateTime.Now;
            Console.WriteLine($"ribbonPageIndes : {ribbonControl.Pages.IndexOf(ribbonPage1)}, count : {ribbonControl.Pages.Count}");
            new ClsUserControlValidation(this, UserControls.TaxDecaration);
        }
        private async Task InitObjects()
        {
            IList<Task> taskList = new List<Task>();
            taskList.Add(Task.Run(() => this.tbSupplyMainList = new ClsTblSupplyMain().GetSupplyMainList));
            taskList.Add(Task.Run(() => this.tblEntrySubList = new ClsTblEntrySub().GetEntrySubList()));
            await Task.WhenAll(taskList);
        }
        private async void InitData()
        {
            await InitObjects();
            TaxDeclaration declaration = taxDeclarationBindingSource.Current as TaxDeclaration;
            this.tbSupplyMainList = (Session.CurrentUser.id == 1 && declaration.BranchID == 0) ? this.tbSupplyMainList : this.tbSupplyMainList.Where(x => x.supBrnId == declaration.BranchID);
            this.tblEntrySubList = (Session.CurrentUser.id == 1 && declaration.BranchID == 0) ? tblEntrySubList : tblEntrySubList.Where(x => x.entBrnId == declaration.BranchID);
            using (accountingEntities db = new accountingEntities())
            {
                tbTaxAccountList = db.tblTaxAccounts.ToList();
                declaration.Code = (db.TaxDeclarations.AsEnumerable()?.LastOrDefault()?.Code ?? 0) + 1;
            }
            CalculateTax();
        }
        private void InitTextEdit()
        {
            foreach (Control c in this.dataLayoutControl1.Controls)
            {
                if (c is TextEdit)
                {
                    if (c.Name == "textEditDateStart" || c.Name == "textEditDateEnd"
                        || c.Name == "textEditDesc" || c.Name == "textEdit1" || c.Name == "lookUpEdit1") continue;
                    c.Text = "0.00";
                    ((TextEdit)c).Properties.DisplayFormat.FormatString = "n2";
                    ((TextEdit)c).Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    ((TextEdit)c).Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
                    ((TextEdit)c).Properties.MaskSettings.Set("mask", "n2");
                }
            }
        }
        private void CalculateTax()
        {
            var declaration = taxDeclarationBindingSource.Current as TaxDeclaration;
            declaration.Sales = 0;
            declaration.SalesReturn = 0;
            declaration.SalesTax = 0;
            declaration.Purchase = 0;
            declaration.PurchaseReturn = 0;
            declaration.PurchaseTax = 0;

            foreach (var tbSupplyMain in this.tbSupplyMainList)
            {
                if (Convert.ToDateTime(tbSupplyMain.supDate).Date > textEditDateEnd.DateTime.Date) break;
                if (Convert.ToByte(tbSupplyMain.supTaxPercent) < 1) continue;


                if (tbSupplyMain.supDate >= textEditDateStart.DateTime.Date)
                {
                    if ((tbSupplyMain.supStatus == 3 || tbSupplyMain.supStatus == 7) && tbSupplyMain.supTaxPrice > 0)
                    {
                        declaration.Purchase += Convert.ToDouble(tbSupplyMain.supTotal - ((tbSupplyMain.supDscntAmount as double?) ?? 0));
                        declaration.PurchaseTax += Convert.ToDouble(tbSupplyMain.supTaxPrice);
                    }
                    else if ((tbSupplyMain.supStatus == 9 || tbSupplyMain.supStatus == 10) && tbSupplyMain.supTaxPrice > 0)
                    {
                        declaration.PurchaseReturn += Convert.ToDouble(tbSupplyMain.supTotal - ((tbSupplyMain.supDscntAmount as double?) ?? 0));
                        declaration.PurchaseTax -= Convert.ToDouble(tbSupplyMain.supTaxPrice);
                    }
                    else if ((tbSupplyMain.supStatus == 4 || tbSupplyMain.supStatus == 8) && tbSupplyMain.supTaxPrice > 0)
                    {
                        declaration.Sales += Convert.ToDouble(tbSupplyMain.supTotal - ((tbSupplyMain.supDscntAmount as double?) ?? 0));
                        declaration.SalesTax += Convert.ToDouble(tbSupplyMain.supTaxPrice);
                    }
                    else if ((tbSupplyMain.supStatus == 11 || tbSupplyMain.supStatus == 12) && tbSupplyMain.supTaxPrice > 0)
                    {
                        declaration.SalesReturn += Convert.ToDouble(tbSupplyMain.supTotal - ((tbSupplyMain.supDscntAmount as double?) ?? 0));
                        declaration.SalesTax -= Convert.ToDouble(tbSupplyMain.supTaxPrice);
                    }
                }
            }

            if (tbTaxAccountList == null) return;
            using (var db = new accountingEntities())
            {
                //var tbEntryList = db.tblEntrySubs.Where(x => x.entDate >= textEditDateStart.DateTime.Date &&
                //   x.entDate <= textEditDateEnd.DateTime.Date && x.entAccName != null && x.entAccName.StartsWith("ضريبة")).ToList();

                //foreach (var x in tbEntryList)
                //{
                //    if (this.type == SupplyType.SalesPhase && Convert.ToDouble(x.entCredit) > 0)
                //    {
                //        var obj = InitObj(x, Convert.ToDouble(x.entCredit));
                //        if (obj != null)
                //            tbCustomSupplyList.Add(obj);
                //    }
                //    if (this.type == SupplyType.PurchasePhase && Convert.ToDouble(x.entDebit) > 0)
                //        tbCustomSupplyList.Add(InitObj(x, Convert.ToDouble(x.entDebit)));
                //}

                db.tblEntryMains.Where(x => x.entDate <= textEditDateEnd.DateTime
                && x.entDate >= textEditDateStart.DateTime && (x.entStatus == 1 || x.entStatus == 4)).ToList().ForEach(x =>
                {
                    double tax = Convert.ToDouble(this.tblEntrySubList.Where(y => y.entNo == x.entNo && y.entDebit is double debit && debit > 0
                  && tbTaxAccountList.Any(c => c.taxAccNo == y.entAccNo)).Sum(w => w.entDebit));
                    declaration.Purchase += (tax / (Convert.ToDouble(MySetting.GetPrivateSetting.taxDefault) / 100));
                    declaration.PurchaseTax += tax;
                });
            }
            textEditPurchaseTotal.EditValue = declaration.Purchase;
            textEditPurchaseRtrnTotal.EditValue = declaration.PurchaseReturn;
            textEditPurchaseTaxTotal.EditValue = declaration.PurchaseTax;
            textEditSaleTotal.EditValue = declaration.Sales;
            textEditSaleRtrnTotal.EditValue = declaration.SalesReturn;
            textEditSaleTaxTotal.EditValue = declaration.SalesTax;

            textEditCurrentTax.EditValue = declaration.SalesTax - declaration.PurchaseTax;
        }

        private void barButtonItemCalculateTax_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InitData();

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            (new rpt_TaxDeclaration()).ShowRibbonPreviewDialog();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InitTextEdit();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            flyDailog.WaitForm(this, 1);
            var frm = new formTaxSetting(this); frm.Show();
            flyDailog.WaitForm(this, 0, frm);
        }

        public void RefreshListDialog(string messaage)
        {
            flyDailog.ShowDialogUC(this, messaage);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox
                .Show(
                text: "هل تريد حفظ هذا الاقرار الضريبي",
                caption: "تاكيد الحفظ",
                buttons: MessageBoxButtons.YesNo, icon: MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (accountingEntities db = new accountingEntities())
                {
                    TaxDeclaration declaration = taxDeclarationBindingSource.Current as TaxDeclaration;
                    if (db.TaxDeclarations.Any(x => x.Code == declaration.Code))
                    {
                        XtraMessageBox.Show(text: "رقم الاقرار موجود بالفعل");
                        return;
                    }
                    db.TaxDeclarations.Add(declaration);
                    db.SaveChanges();
                    XtraMessageBox.Show(text: "تم الحفظ بنجاح");
                }

            }
        }
    }
}
