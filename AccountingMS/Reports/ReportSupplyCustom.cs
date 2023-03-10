using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;


namespace AccountingMS
{
    public partial class ReportSupplyCustom : DevExpress.XtraReports.UI.XtraReport
    {
        ClsTblUser clsTbUser = new ClsTblUser();
        ClsTblCurrency clsTbCurrency = new ClsTblCurrency();
        ClsTblPrdPriceMeasurment clsTbPrdMsur;
        ItblSupplyMainCustom itbSupplyMainCustom;
        ItblSupplyMain itbSupplyMain;
        IEnumerable<tblSupplySub> tbSupplySubList;

        ClsTblProduct clsTblProduct;
        tblSupplyMain tbSupplyMain;
        List<tblSupplySub> tbSupplyOrderSubList = new List<tblSupplySub>();
        tblOrderMain orderMain;
        IEnumerable<tblOrderSub> OrderSubList;
        private string barcodeText = null;
        tblBranch tbBranch;
        tblCustomer tbCustomer;

        public ReportSupplyCustom()
        {
            InitializeComponent();
            InitDesignerDataCustom();
        }

        public ReportSupplyCustom(tblSupplyMain tbSupplyMain = null, IEnumerable<tblSupplySub> tbSupplySubList = null)
        {
            this.itbSupplyMain = tbSupplyMain;
            this.itbSupplyMain.reprID = tbSupplyMain.reprID;
            this.tbSupplySubList = tbSupplySubList;
            this.clsTbPrdMsur = new ClsTblPrdPriceMeasurment();

            InitializeComponent();
            InitRprtCustomLayout();
            //InitDesignerData();
            InitData();
            InitBarCodeText();
            //InitQRCode();
        }
        public ReportSupplyCustom(tblOrderMain tbOrderMain = null, IEnumerable<tblOrderSub> tbOrderSubList = null)
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
            this.itbSupplyMainCustom.supTotal = this.itbSupplyMainCustom.supTotalFinal - this.itbSupplyMainCustom.supTaxPrice.Value;
            this.itbSupplyMainCustom.supStatus = orderMain.ordStatus;
            this.itbSupplyMainCustom.id = orderMain.ordId;
            this.itbSupplyMainCustom.repName = new ClsTblRepresentitive().GetRepList.FirstOrDefault(x => x.id == this.itbSupplyMain.reprID)?.repName;
            if (tbBranch != null)
            {
                TLVCls tlv = new TLVCls(tbBranch.brnName.ToString(),
                    tbBranch.brnTaxNo.ToString(), ((orderMain.ordDate as DateTime?) ?? DateTime.Now),
                    Convert.ToDouble(this.itbSupplyMainCustom.supTotalFinal), Convert.ToDouble(this.itbSupplyMainCustom.supTaxPrice));
                xrBarCode1.Text = tlv.ToBase64();
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
                //itbSupplySubList.ElementAt(i).subNoPacks = this.tbSupplySubList.ElementAt(i).subNoPacks;
            }
            DetailReport.DataSource = itbSupplySubList;
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
            InitSupplyMainData();
            InitSupplySubData();
            InitCustomerData();
        }
        private void InitSupplyMainData()
        {
            this.itbSupplyMainCustom = this.itbSupplyMain as ItblSupplyMainCustom;
            this.itbSupplyMainCustom.supStatusStr = tbCustomer == null ? ClsSupplyStatus.GetString(this.itbSupplyMain.supStatus).Replace("مبيعات", "ضريبة") + " مبسطة " : ClsSupplyStatus.GetString(this.itbSupplyMain.supStatus);
            this.itbSupplyMainCustom.supIsCashStr = ClsSupplyStatus.GetPaymentString(this.itbSupplyMain.supIsCash);
            this.itbSupplyMainCustom.supUserIdStr = this.clsTbUser.GetUserNameById(this.itbSupplyMain.supUserId);
            this.itbSupplyMainCustom.supCurrencyStr = this.clsTbCurrency.GetCurrencyNameById(Convert.ToByte(this.itbSupplyMain.supCurrency));
            this.itbSupplyMainCustom.supTotalPrice = this.itbSupplyMainCustom.supTotal - Convert.ToDouble(this.itbSupplyMainCustom.supDscntAmount);
            this.itbSupplyMainCustom.supTotalFinal = (this.itbSupplyMain.supTotal + Convert.ToDouble(this.itbSupplyMain.supTaxPrice)) - Convert.ToDouble(this.itbSupplyMain.supDscntAmount);
            this.itbSupplyMainCustom.Notes = this.itbSupplyMain.Notes;
            this.itbSupplyMainCustom.PoNumber = this.itbSupplyMain.PoNumber;
            
            this.itbSupplyMainCustom.repName = new ClsTblRepresentitive().GetRepList.FirstOrDefault(x => x.id == this.itbSupplyMainCustom.reprID)?.repName;

            this.itbSupplyMainCustom.reprID = this.itbSupplyMain.reprID;
            this.itbSupplyMainCustom.PeriodFrome = this.itbSupplyMain.PeriodFrome;
            this.itbSupplyMainCustom.PeriodTo = this.itbSupplyMain.PeriodTo;
            this.itbSupplyMainCustom.RegistrationNumber = this.itbSupplyMain.RegistrationNumber;
            this.itbSupplyMainCustom.PaymentTeam = this.itbSupplyMain.PaymentTeam;
            this.itbSupplyMainCustom.DeliveryDate = this.itbSupplyMain.DeliveryDate;
            this.itbSupplyMainCustom.ShippingDate = this.itbSupplyMain.ShippingDate;
            this.itbSupplyMainCustom.FieldNumber = this.itbSupplyMain.FieldNumber;
            if (itbSupplyMain.supIsCash == 1)
                this.itbSupplyMainCustom.paidCash = (double)this.itbSupplyMainCustom.supTotalFinal;
            else
                this.itbSupplyMainCustom.paidCash = ((this.itbSupplyMain.paidCash as double?) ?? 0) + Convert.ToDouble((this.itbSupplyMain.supBankAmount as double?) ?? 0);
            this.itbSupplyMainCustom.remin = Convert.ToDouble(this.itbSupplyMainCustom.supTotalFinal) - (this.itbSupplyMainCustom.paidCash);
            itbSupplyMainCustom.NetTextAr = new ToWord(this.itbSupplyMainCustom.supTotalFinal).ConvertToArabic();
            itbSupplyMainCustom.TaxAsTextAr = new ToWord(this.itbSupplyMainCustom.supTaxPrice ?? 0).ConvertToArabic();
            itbSupplyMainCustom.NetTextEn = new ToWord(this.itbSupplyMainCustom.supTotalFinal).ConvertToEnglish();
            itbSupplyMainCustom.TaxAsTextEn = new ToWord(this.itbSupplyMainCustom.supTaxPrice ?? 0).ConvertToEnglish();
            itbSupplyMainCustom.DueDate = itbSupplyMain.DueDate;
            ICollection<ItblSupplyMainCustom> itbSupplyMainCList = new Collection<ItblSupplyMainCustom>() { this.itbSupplyMainCustom };
            this.DataSource = itbSupplyMainCList;
        }

        private void InitSupplySubData()
        {
            ConvertSubTotal();

            var itbSupplySubList = this.tbSupplySubList.Select(x => x as ItblSupplySub).ToList();
            //var itbSupplySubList = this.tbSupplySubList.ConvertAll(x => x as ItblSupplySub);
            for (short i = 0; i < itbSupplySubList.Count(); i++)
                itbSupplySubList.ElementAt(i).supMsur = this.clsTbPrdMsur.GetPrdPriceMsurNameById(Convert.ToInt32(this.tbSupplySubList.ElementAt(i).supMsur));

            DetailReport.DataSource = itbSupplySubList;
        }

        private void InitCustomerData()
        {
             if (tbCustomer != null)
            { 
                Int64.TryParse(tbCustomer.custTaxNo, out Int64 taxNo);
                this.itbSupplyMainCustom.custNo = tbCustomer.custNo;
                this.itbSupplyMainCustom.custName = tbCustomer.custName;
                this.itbSupplyMainCustom.custAddress = tbCustomer.custAddress;
                this.itbSupplyMainCustom.custPhnNo = tbCustomer.custPhnNo;
                this.itbSupplyMainCustom.custTaxNo = tbCustomer.custTaxNo;
                this.itbSupplyMainCustom.supStatusStr = taxNo == 0 ? ClsSupplyStatus.GetString(this.itbSupplyMain.supStatus).Replace("مبيعات", "ضريبة") + " مبسطة" : ClsSupplyStatus.GetString(this.itbSupplyMain.supStatus).Replace("مبيعات", "ضريبية");

                this.itbSupplyMainCustom.custNameEn = tbCustomer.custNameEn;
                this.itbSupplyMainCustom.custAddressEn = tbCustomer.custAddressEn;
                this.itbSupplyMainCustom.CommercialRegister = tbCustomer.CommercialRegister;
                this.itbSupplyMainCustom.PostalCode = tbCustomer.PostalCode;
                this.itbSupplyMainCustom.CustCountry = tbCustomer.custCountry;
                this.itbSupplyMainCustom.CustCountryEn = tbCustomer.custCountryEn;
                this.itbSupplyMainCustom.cusBuildingNo = tbCustomer.cusBuildingNo;
                this.itbSupplyMainCustom.cusAddNo = tbCustomer.cusAddNo;
                this.itbSupplyMainCustom.cusAnotherID = tbCustomer.cusAnotherID;
                this.itbSupplyMainCustom.cusDistrict = tbCustomer.cusDistrict;
                this.itbSupplyMainCustom.cusDistrictEn = tbCustomer.cusDistrictEn;
                this.itbSupplyMainCustom.custCity = tbCustomer.custCity;
                this.itbSupplyMainCustom.custCityEn = tbCustomer.custCityEn;
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
             tbBranch = db.tblBranches.AsQueryable().Where(x => x.brnId == Session.CurBranch.brnId).FirstOrDefault();
            if (tbBranch == null) return;
            String Seller = tbBranch.brnName;
            String VatNo = tbBranch.brnTaxNo;
            DateTime dTime = this.itbSupplyMain.supDate.Value;
            double total = (this.itbSupplyMain.supTotal + Convert.ToDouble(this.itbSupplyMain.supTaxPrice))
                - Convert.ToDouble(this.itbSupplyMain.supDscntAmount);
            Double Total = Convert.ToDouble(total);
            Double Tax = Convert.ToDouble(this.itbSupplyMain.supTaxPrice);

            TLVCls tlv = new TLVCls(Seller, VatNo, dTime, Total, Tax);
            xrBarCode1.Text = tlv.ToBase64();
            //InitBarCodeBranchData();
            ////InitBarCodeSupplierData();
            ////InitBarCodeCustomerData();
            //InitBarCodeMainData();
        }
        private void InitBranchData()
        {
            using var db = new accountingEntities();
            tbBranch = db.tblBranches.Where(x => x.brnId == Session.CurBranch.brnId).AsQueryable().AsNoTracking().FirstOrDefault();
            if (tbBranch == null) return;

            var itbBranchCustom = tbBranch as ItblBranchCustom;
            if (itbBranchCustom == null) return;

            tblBranchBindingSource.DataSource = itbBranchCustom;
        }
        private void InitBarCodeBranchData()
        {
            using var db = new accountingEntities();

            var tbBranch = db.tblBranches.AsQueryable().Where(x => x.brnId == Session.CurBranch.brnId).FirstOrDefault();
            if (tbBranch == null) return;

            //this.barcodeText = $"{tbBranch?.brnName}\n{tbBranch?.brnAddress}\n";
            this.barcodeText = $"{tbBranch?.brnName}\n";
            this.barcodeText += $"الرقم الضريبي: {tbBranch?.brnTaxNo}\n\n";

        }

        private void InitBarCodeSupplierData()
        {
            if (Convert.ToInt32(this.itbSupplyMain.supCustSplId) == 0) return;
            if (this.itbSupplyMain.supStatus == 4 || this.itbSupplyMain.supStatus == 8 ||
                this.itbSupplyMain.supStatus == 11 || this.itbSupplyMain.supStatus == 12) return;
            Console.WriteLine($"===============inisdeInitBarCodeSupplierData");

            using var db = new accountingEntities();

            var tbSupplier = db.tblSuppliers.AsQueryable().Where(x => x.id == this.itbSupplyMain.supCustSplId).FirstOrDefault();
            if (tbSupplier == null) return;

            this.barcodeText += $"إسم المور: {tbSupplier?.splName}\n";
            if (!string.IsNullOrWhiteSpace(tbSupplier?.splTaxNo))
                this.barcodeText += $"الرقم الضريبي: {tbSupplier?.splTaxNo}\n";
        }

        private void InitBarCodeCustomerData()
        {
            if (Convert.ToInt32(this.itbSupplyMain.supCustSplId) == 0) return;
            if (this.itbSupplyMain.supStatus == 3 || this.itbSupplyMain.supStatus == 7 ||
                this.itbSupplyMain.supStatus == 9 || this.itbSupplyMain.supStatus == 10) return;
            Console.WriteLine($"============insideInitBarCodeCustomerData");

            if (!string.IsNullOrWhiteSpace(this.itbSupplyMainCustom?.custName))
                this.barcodeText += $"إسم العميل: {this.itbSupplyMainCustom?.custName}\n";
            if (!string.IsNullOrWhiteSpace(this.itbSupplyMainCustom?.custTaxNo))
                this.barcodeText += $"الرقم الضريبي: {this.itbSupplyMainCustom?.custTaxNo}\n";
        }

        private void InitBarCodeMainData()
        {
            //this.barcodeText += $"رقم الفاتورة: {this.itbSupplyMain.supNo}\n";
            this.barcodeText += $"{this.itbSupplyMain.supDate:yyyy-M-d h:m tt}\n\n";
            this.barcodeText += $"المبلغ: {this.itbSupplyMain.supTotal:n2}\n";
            if (Convert.ToDouble(this.itbSupplyMain.supDscntAmount) > 0)
                this.barcodeText += $"الخصم: {this.itbSupplyMain.supDscntAmount:n2}\n";
            this.barcodeText += $"الضريبة: {this.itbSupplyMain.supTaxPrice:n2}\n";

            double total = (this.itbSupplyMain.supTotal + Convert.ToDouble(this.itbSupplyMain.supTaxPrice))
                - Convert.ToDouble(this.itbSupplyMain.supDscntAmount);
            this.barcodeText += $"الإجمالي: {total:n2}";
        }

        private void InitDesignerDataCustom()
        {
            InitBranchData();
            InitSupplyMainCustom();
            InitSupplySubCustom();
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
                custNameEn = "Hammoud",
                custPhnNo = "78946125",
                custAddress = "الاصبحي سوق المقالح",
                custAddressEn = "Al Asbahi Al Maqaleh Market",
                custTaxNo = "428635",
                CommercialRegister = "ر س 145877",
                PostalCode = "ر س 145877"
            };
            tblSupplyMainBindingSource.DataSource = this.itbSupplyMainCustom;
        }

        private void InitSupplySubCustom()
        {
            tblSupplySubBindingSource.DataSource = new tblSupplySubCustom()
            {
                supPrdNo = "123",
                supPrdName = $"إسم الصنف",
                supMsur = "حبه",
                supQuanMain = 1,
                supPrice = 200,
                supSalePrice = 200,
                supTaxPrice = 10,
                supDebit = 210,
                subNoPacks = 0
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
                });
            this.tbSupplySubList = tbSupplySubList;
        }
    }
}
