using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;


namespace PosFinalCost
{
    public partial class ReportSupplyCustom2 : DevExpress.XtraReports.UI.XtraReport
    {
        ClsTblUser clsTbUser = new ClsTblUser();
        ClsTblCurrency clsTbCurrency = new ClsTblCurrency();
        ClsTblPrdPriceMeasurment clsTbPrdMsur;
        ItblSupplyMainCustom itbSupplyMainCustom;
        ItblSupplyMain itbSupplyMain;
        IEnumerable<tblSupplySub> tbSupplySubList;

        private string barcodeText = null;
        ClsTblProduct clsTblProduct;
        tblSupplyMain tbSupplyMain;
        List<tblSupplySub> tbSupplyOrderSubList = new List<tblSupplySub>();
        tblOrderMain orderMain;
        IEnumerable<tblOrderSub> OrderSubList;
        tblBranch tbBranch;
        public ReportSupplyCustom2()
        {
            InitializeComponent();
            InitDesignerDataCustom();
        }

        public ReportSupplyCustom2(tblSupplyMain tbSupplyMain = null, IEnumerable<tblSupplySub> tbSupplySubList = null)
        {
            this.itbSupplyMain = tbSupplyMain;
            this.tbSupplySubList = tbSupplySubList;
            this.clsTbPrdMsur = new ClsTblPrdPriceMeasurment();

            InitializeComponent();
            InitRprtCustomLayout();
            //InitDesignerData();
            InitData();
            InitBarCodeText();
          //  InitQRCode();
        }
        public ReportSupplyCustom2(tblOrderMain tbOrderMain = null, IEnumerable<tblOrderSub> tbOrderSubList = null)
        {
            this.orderMain = tbOrderMain;
            this.OrderSubList = tbOrderSubList;
            this.clsTbPrdMsur = new ClsTblPrdPriceMeasurment();
            this.clsTblProduct = new ClsTblProduct();
            InitializeComponent();
            InitRprtCustomLayout();
            InitOrderData();
        }
        private void InitOrderData()
        {
            InitBranchData();
            InitBranchImg();
            InitOrderMainData();
            InitOrderSubData();
        }
        private void InitOrderMainData()
        {
            this.tbSupplyMain = new tblSupplyMain();
            this.itbSupplyMainCustom = this.tbSupplyMain as ItblSupplyMainCustom;
            this.itbSupplyMainCustom.supStatusStr = ClsOrderStatus.GetString(orderMain.ordStatus);
            this.itbSupplyMainCustom.supNo = orderMain.ordNo;
            this.itbSupplyMainCustom.supDate = orderMain.ordDate;
            this.itbSupplyMainCustom.supDesc = orderMain.ordDesc;
            this.itbSupplyMainCustom.supBrnId = orderMain.ordBrnId;
            this.itbSupplyMainCustom.supUserId = orderMain.ordUsrId;
            this.itbSupplyMainCustom.supUserIdStr = this.clsTbUser.GetUserNameById(orderMain.ordUsrId);
            this.itbSupplyMainCustom.supCurrencyStr = this.clsTbCurrency.GetCurrencyNameById(Convert.ToByte(clsTbCurrency.FirstCurrency));
            this.itbSupplyMainCustom.supTotalPrice = OrderSubList.Sum(x => x.ordPriceSale.Value);

            this.itbSupplyMainCustom.supTotalFinal = OrderSubList.Sum(x => x.ordTotal.Value);
            this.itbSupplyMainCustom.supTaxPrice = OrderSubList.Sum(x => x.ordTax.Value);
            this.itbSupplyMainCustom.supTotal = OrderSubList.Sum(x => x.ordPriceSale.Value);
            this.itbSupplyMainCustom.supStatus = orderMain.ordStatus;
            this.itbSupplyMainCustom.id = orderMain.ordId;
            if (tbBranch != null)
            {
                TLVCls tlv = new TLVCls(tbBranch.brnName.ToString(),
                    tbBranch.brnTaxNo.ToString(), ((orderMain.ordDate as DateTime?) ?? DateTime.Now),
                    Convert.ToDouble(this.itbSupplyMainCustom.supTotalFinal), Convert.ToDouble(this.itbSupplyMainCustom.supTaxPrice));
                xrBarCode.Text = tlv.ToBase64();
            }
            itbSupplyMainCustom.NetTextAr = new ToWord(this.itbSupplyMainCustom.supTotalFinal).ConvertToArabic();
            itbSupplyMainCustom.TaxAsTextAr = new ToWord(this.itbSupplyMainCustom.supTaxPrice ?? 0).ConvertToArabic();
            itbSupplyMainCustom.NetTextEn = new ToWord(this.itbSupplyMainCustom.supTotalFinal).ConvertToEnglish();
            itbSupplyMainCustom.TaxAsTextEn = new ToWord(this.itbSupplyMainCustom.supTaxPrice ?? 0).ConvertToEnglish();
            ICollection<ItblSupplyMainCustom> itbSupplyMainCList = new Collection<ItblSupplyMainCustom>() { this.itbSupplyMainCustom };
            this.DataSource = itbSupplyMainCList;
        }
        tblSupplySub tbSupplySub;
        private void InitOrderSubData()
        {
            tbSupplyOrderSubList.Clear();
            foreach (var item in OrderSubList)
            {
                tbSupplySub = new tblSupplySub();
                tbSupplySub.id = item.ordId;
                tbSupplySub.supBrnId = item.ordBrnId;
                tbSupplySub.supDate = item.ordDate;
                tbSupplySub.supNo = item.ordMainId;
                tbSupplySub.supMsur = item.ordMsurId;
                tbSupplySub.supPrdId = item.ordPrdId;
                tbSupplySub.supPrdBarcode = item.ordPrdBarcode;
                tbSupplySub.supQuanMain = item.ordQuantity;
                tbSupplySub.supSalePrice = item.ordPriceSale;
                tbSupplySub.supPrice = item.ordPrice;
                tbSupplySub.supTaxPrice = item.ordTax;
                tbSupplySub.supTaxPercent = item.ordTaxPercent;
                tbSupplySub.supPrdName = clsTblProduct.GetPrdNameById(item.ordPrdId);
                tbSupplySub.supPrdNo = clsTblProduct.GetPrdNoById(item.ordPrdId);
                tbSupplySub.supDebit = item.ordTotal;
                tbSupplySub.supDesc = item.ordDesc;
                tbSupplySub.supStatus = item.ordStatus;
                tbSupplyOrderSubList.Add(tbSupplySub);
            }
            var itbSupplySubList = this.tbSupplyOrderSubList.Select(x => x as ItblSupplySub).ToList();
            for (short i = 0; i < itbSupplySubList.Count(); i++)
            {
                itbSupplySubList.ElementAt(i).supMsur =
                  this.clsTbPrdMsur.GetPrdPriceMsurNameById(Convert.ToInt32(this.tbSupplyOrderSubList.ElementAt(i).supMsur));
                // itbSupplySubList.ElementAt(i).subNoPacks = this.tbSupplySubList.ElementAt(i).subNoPacks;
            }
            this.DetailReport.DataSource = itbSupplySubList;
        }
        private void InitRprtCustomLayout()
        {
            this.LoadLayout(ClsPath.ReportSupplyCustomFile);
        }

        private void InitData()
        {
            if (Convert.ToInt32(this.itbSupplyMain.supCustSplId) != 0)
                tbCustomer = new ClsTblCustomer().GetCustomerObjById(Convert.ToInt32(this.itbSupplyMain.supCustSplId));
            InitBranchData();
            InitBranchImg();
            InitSupplyMainData();
            InitSupplySubData();
            InitCustomerData();
        }

        tblCustomer tbCustomer;
        private void InitSupplyMainData()
        {
            this.itbSupplyMainCustom = this.itbSupplyMain as ItblSupplyMainCustom;
            this.itbSupplyMainCustom.supStatusStr = tbCustomer == null ? ClsSupplyStatus.GetString(this.itbSupplyMain.supStatus).Replace("مبيعات", "ضريبة") + " مبسطة " : ClsSupplyStatus.GetString(this.itbSupplyMain.supStatus);
            this.itbSupplyMainCustom.supIsCashStr = ClsSupplyStatus.GetPaymentString(this.itbSupplyMain.supIsCash);
            this.itbSupplyMainCustom.supUserIdStr = this.clsTbUser.GetUserNameById(this.itbSupplyMain.supUserId);
            this.itbSupplyMainCustom.supCurrencyStr = this.clsTbCurrency.GetCurrencyNameById(Convert.ToByte(this.itbSupplyMain.supCurrency));
            this.itbSupplyMainCustom.supTotalPrice = this.itbSupplyMainCustom.supTotal - Convert.ToDecimal(this.itbSupplyMainCustom.supDscntAmount);
            this.itbSupplyMainCustom.supTotalFinal = (this.itbSupplyMain.supTotal + Convert.ToDecimal(this.itbSupplyMain.supTaxPrice)) - Convert.ToDecimal(this.itbSupplyMain.supDscntAmount);
            this.itbSupplyMainCustom.Notes = this.itbSupplyMain.Notes;
            this.itbSupplyMainCustom.PoNumber = this.itbSupplyMain.PoNumber; 
            if (itbSupplyMain.supIsCash == 1)
                this.itbSupplyMainCustom.paidCash = (double)this.itbSupplyMainCustom.supTotalFinal;
            else
                this.itbSupplyMainCustom.paidCash = ((this.itbSupplyMain.paidCash as double?) ?? 0) + Convert.ToDouble((this.itbSupplyMain.supBankAmount as decimal?) ?? 0);
            this.itbSupplyMainCustom.remin = Convert.ToDouble(this.itbSupplyMainCustom.supTotalFinal) - (this.itbSupplyMainCustom.paidCash);
            itbSupplyMainCustom.NetTextAr = new ToWord(this.itbSupplyMainCustom.supTotalFinal).ConvertToArabic();
            itbSupplyMainCustom.TaxAsTextAr = new ToWord(this.itbSupplyMainCustom.supTaxPrice??0).ConvertToArabic();
            itbSupplyMainCustom.NetTextEn = new ToWord(this.itbSupplyMainCustom.supTotalFinal).ConvertToEnglish();
            itbSupplyMainCustom.TaxAsTextEn = new ToWord(this.itbSupplyMainCustom.supTaxPrice??0).ConvertToEnglish();
            ICollection<ItblSupplyMainCustom> itbSupplyMainCList = new Collection<ItblSupplyMainCustom>() { this.itbSupplyMainCustom };
            this.DataSource = itbSupplyMainCList;
        }

        private void InitSupplySubData()
        {
            ConvertSubTotal();
            int count = 0;
            var itbSupplySubList = this.tbSupplySubList.Select(x => x as ItblSupplySub).ToList();

            foreach (var tbSupplySub in itbSupplySubList)
            {
                var tbPrdMsur = this.clsTbPrdMsur.GetPrdPriceMsurById(Convert.ToInt32(this.tbSupplySubList.ElementAt(count++).supMsur));
                if (tbPrdMsur == null) continue;
                var tbPrdMsurList = this.clsTbPrdMsur.GetPrdPriceMsurListByPrdId(Convert.ToInt32(tbSupplySub.supPrdId));

                tbSupplySub.supMsur = tbPrdMsur.ppmMsurName;

                if (tbPrdMsur.ppmStatus == 1)
                {
                    tbSupplySub.supQuanMain1 = tbSupplySub.supQuanMain;

                    var tbPrdMsur2 = tbPrdMsurList.Where(x => x.ppmStatus == 2).FirstOrDefault();
                    if (tbPrdMsur2 != null) { tbSupplySub.supQuanMain2 = tbSupplySub.supQuanMain * (double)tbPrdMsur2?.ppmConversion ?? 0; }

                }

                if (tbPrdMsur.ppmStatus == 2)
                {
                    tbSupplySub.supQuanMain2 = tbSupplySub.supQuanMain;
                    tbSupplySub.supQuanMain1 = tbSupplySub.supQuanMain / (double)tbPrdMsur.ppmConversion ?? 0;
                }
            }

            DetailReport.DataSource = itbSupplySubList;
        }

        private void InitCustomerData()
        {
           
            if (tbCustomer != null)
            {
                this.itbSupplyMainCustom.custNo = tbCustomer.custNo;
                this.itbSupplyMainCustom.custName = tbCustomer.custName;
                this.itbSupplyMainCustom.custAddress = tbCustomer.custAddress;
                this.itbSupplyMainCustom.custPhnNo = tbCustomer.custPhnNo;
                this.itbSupplyMainCustom.custTaxNo = tbCustomer.custTaxNo;
                this.itbSupplyMainCustom.supStatusStr = (Convert.ToInt64(tbCustomer.custTaxNo==""?null: tbCustomer.custTaxNo) == 0) ? ClsSupplyStatus.GetString(this.itbSupplyMain.supStatus).Replace("مبيعات", "ضريبة") + " مبسطة" : ClsSupplyStatus.GetString(this.itbSupplyMain.supStatus).Replace("مبيعات", "ضريبية");

                this.itbSupplyMainCustom.custNameEn = tbCustomer.custNameEn;
                this.itbSupplyMainCustom.custAddressEn = tbCustomer.custAddressEn;
                this.itbSupplyMainCustom.CommercialRegister = tbCustomer.CommercialRegister;
                this.itbSupplyMainCustom.PostalCode = tbCustomer.PostalCode;
                this.itbSupplyMainCustom.CustCountry = tbCustomer.custCountry;
                this.itbSupplyMainCustom.CustCountryEn = tbCustomer.custCountryEn;
                this.itbSupplyMainCustom.custCity = tbCustomer.custCity;
                this.itbSupplyMainCustom.custCityEn = tbCustomer.custCityEn;
                this.itbSupplyMainCustom.cusBuildingNo = tbCustomer.cusBuildingNo;
                this.itbSupplyMainCustom.cusAddNo = tbCustomer.cusAddNo;
                this.itbSupplyMainCustom.cusAnotherID = tbCustomer.cusAnotherID;
                this.itbSupplyMainCustom.cusDistrict = tbCustomer.cusDistrict;
                this.itbSupplyMainCustom.cusDistrictEn = tbCustomer.cusDistrictEn;
                if (Convert.ToInt32(tbCustomer.cusBankId) == 0) return;
                var tblBank = new ClsTblBank().GetTblBankList.FirstOrDefault(b => b.id == Convert.ToInt32(tbCustomer.cusBankId) & b.bankBrnId == tbCustomer.custBrnId);
                if (tblBank != null)
                {
                    this.itbSupplyMainCustom.bankName = tblBank.bankName;
                    this.itbSupplyMainCustom.bankNameEn = tblBank.bankNameEn;
                    this.itbSupplyMainCustom.bankAccIBAN = tblBank.bankAccIBAN;
                    this.itbSupplyMainCustom.AccNoInBank = tblBank.AccNoInBank;
                    this.itbSupplyMainCustom.bankSwiftCode = tblBank.bankSwiftCode;
                }
            }

        }

        private void ConvertSubTotal()
        {
            byte supStatus = this.itbSupplyMain.supStatus;
            if (supStatus == 4 || supStatus == 8 || supStatus == 9 || supStatus == 10)
                foreach (var tbSupplySub in this.tbSupplySubList) tbSupplySub.supDebit = tbSupplySub.supCredit;
        }

        private void InitQRCode()
        {
            foreach (var control in this.AllControls<XRBarCode>())
                control.InitQRCode(this.barcodeText);
        }

        private void InitBarCodeText()
        {
            using var db = new accountingEntities();
            var tbBranch = db.tblBranches.AsQueryable().Where(x => x.brnId == ClsBranchId.BranchId).FirstOrDefault();
            if (tbBranch == null) return;
            String Seller = tbBranch.brnName;
            String VatNo = tbBranch.brnTaxNo;
            DateTime dTime = this.itbSupplyMain.supDate.Value;
            decimal total = (this.itbSupplyMain.supTotal + Convert.ToDecimal(this.itbSupplyMain.supTaxPrice))
                - Convert.ToDecimal(this.itbSupplyMain.supDscntAmount);
            Double Total = Convert.ToDouble(total);
            Double Tax = Convert.ToDouble(this.itbSupplyMain.supTaxPrice);

            TLVCls tlv = new TLVCls(Seller, VatNo, dTime, Total, Tax);
            xrBarCode.Text = tlv.ToBase64();
            //InitBarCodeBranchData();
            //InitBarCodeMainData();
        }

        private void InitBarCodeBranchData()
        {
            using var db = new accountingEntities();

            var tbBranch = db.tblBranches.AsQueryable().Where(x => x.brnId == ClsBranchId.BranchId).FirstOrDefault();
            if (tbBranch == null) return;

            this.barcodeText = $"{tbBranch?.brnName}\n";
            this.barcodeText += $"الرقم الضريبي: {tbBranch?.brnTaxNo}\n\n";
            this.barcodeText += $"{tbBranch?.brnAddress}\n\n";
        }

        private void InitBarCodeMainData()
        {
            this.barcodeText += $"{this.itbSupplyMain.supDate:yyyy-M-d h:m tt}\n\n";
            this.barcodeText += $"المبلغ: {this.itbSupplyMain.supTotal:n2}\n";
            if (Convert.ToDecimal(this.itbSupplyMain.supDscntAmount) > 0)
                this.barcodeText += $"الخصم: {this.itbSupplyMain.supDscntAmount:n2}\n";
            this.barcodeText += $"الضريبة: {this.itbSupplyMain.supTaxPrice:n2}\n";
           

            decimal total = (this.itbSupplyMain.supTotal + Convert.ToDecimal(this.itbSupplyMain.supTaxPrice))
                - Convert.ToDecimal(this.itbSupplyMain.supDscntAmount);
            this.barcodeText += $"الإجمالي: {total:n2}";
        }

        private void InitDesignerDataCustom()
        {
            InitBranchData();
            InitBranchImg();
            InitSupplyMainCustom();
            InitSupplySubCustom();
        }
        private void InitBranchData()
        {
            using var db = new accountingEntities();
             tbBranch = db.tblBranches.Where(x => x.brnId == ClsBranchId.BranchId).AsQueryable().AsNoTracking().FirstOrDefault();
            if (tbBranch == null) return;

            var itbBranchCustom = tbBranch as ItblBranchCustom;
            if (itbBranchCustom == null) return;

            tblBranchBindingSource.DataSource = itbBranchCustom;
        }

        private void InitBranchImg()
        {
            foreach (var control in this.AllControls<XRPictureBox>())
                if (control.Parent is TopMarginBand)
                {
                    InitBranchImg(control);
                    break;
                }
        }

        private void InitBranchImg(XRPictureBox control)
        {
            try
            {
                MemoryStream memoryStream = new MemoryStream(new ClsTblBranchImg().GetBranchImg(ClsBranchId.BranchId));
                if (memoryStream == null) return;

                Bitmap bitmap = new Bitmap(memoryStream);
                control.Image = bitmap;
            }
            catch (Exception ex)
            {
                ClsXtraMssgBox.ShowError(ex.Message);
            }
        }

        private void InitSupplyMainCustom()
        {
            this.itbSupplyMainCustom = new tblSupplyMainCustom()
            {
                supNo = 1,
                supDate = DateTime.Now,
                supDesc = "تصميم فاتورة المبيعات والمشتريات",
                supAccNo = 1145552356,
                supAccName = "إسم الحساب 123",
                supDscntAmount = 100,
                supTaxPrice = 50,
                supTotal = 1000,
                supTotalFinal = 950,
                supCurrencyStr = this.clsTbCurrency.GetCurrencyNameById(1),
                supUserIdStr = this.clsTbUser.GetUserNameById(1),
                supIsCashStr = ClsSupplyStatus.GetPaymentString(1),
                supStatusStr = ClsSupplyStatus.GetString(4),
                custNo = 123,
                custName = "حمود شاص",
                custPhnNo = "78946125",
                custAddress = "الاصبحي سوق المقالح",
                custTaxNo = "428635"
            };
            tblSupplyMainBindingSource.DataSource = this.itbSupplyMainCustom;
        }

        private void InitSupplySubCustom()
        {
            tblSupplySubBindingSource.DataSource = new tblSupplySubCustom2()
            {
                supPrdNo = "123",
                supPrdName = $"إسم الصنف",
                supMsur = "حبه",
                supQuanMain1 = 5,
                supQuanMain2 = 10,
                supPrice = 200,
                supSalePrice = 200,
                supTaxPrice = 10,
                supDebit = 210,
            };
        }

        private void InitDesignerData()
        {
            InitSupplyMain();
            InitSupplySub();
        }

        private void InitSupplyMain()
        {
            this.itbSupplyMain = new tblSupplyMain()
            {
                supNo = 1,
                supDate = DateTime.Now,
                supDesc = "تصميم فاتورة المبيعات والمشتريات",
                supAccNo = 1145552356,
                supAccName = "إسم الحساب 123",
                supDscntAmount = 100,
                supTaxPrice = 50,
                supTotal = 1000,
                supIsCash = 1,
                supCustSplId = 1,
                supCurrency = 1,
                supUserId = 1,
                supBrnId = 1,
                supStatus = 4,
            };
        }

        private void InitSupplySub()
        {
            var tbSupplySubList = new Collection<tblSupplySub>();
            for (short i = 1; i <= 5; i++)
                tbSupplySubList.Add(new tblSupplySub()
                {
                    supPrdNo = i.ToString(),
                    supPrdName = $"الصنف {i}",
                    supMsur = 1,
                    supQuanMain = 1,
                    supPrice = 200,
                    supSalePrice = 200,
                    supTaxPrice = 10,
                    supCredit = 210,
                    subNoPacks=1
                });
            this.tbSupplySubList = tbSupplySubList;
        }
    }
}
