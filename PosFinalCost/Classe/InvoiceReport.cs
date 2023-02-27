using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosFinalCost.Classe
{
    public class InvoiceReport
    {
        public InvoiceReport(SupplyMain suppMain)
        {
            Customer customer= suppMain.CustId!=null?Session.Customers.FirstOrDefault(x => x.ID == suppMain.CustId):null;
            Branch branch= Session.CurrentBranch;
            ToWord toWordNet = new ToWord(suppMain.Net);
            ToWord toWordTax = new ToWord(suppMain.TaxPrice);
            SupplyMainData = new SupplyMainCustom
            {
                Desc = suppMain.Desc,
                DscntAmount =suppMain.DscntAmount,
                DscntPercent = suppMain.DscntPercent,
                DueDate = suppMain.DueDate,
                IsCash = suppMain.IsCash==1? (!Program.My_Setting.LangEng ? "نقدا" : "Cash"): (!Program.My_Setting.LangEng ? "اجل" : "Credit"),
                BankAmount = suppMain.BankAmount,
                CarType = suppMain.CarType,
                CounterNumber = suppMain.CounterNumber,
                //Currency = Session.Currencies?.FirstOrDefault(x => x.ID == suppMain.Currency)?.Name,
                Date = suppMain.Date,
                No = suppMain.No,
                Net = suppMain.Net,
                //NetTextAr = toWordNet.ConvertToArabic(),
                //TaxAsTextAr = toWordTax.ConvertToArabic(),
                //NetTextEn = toWordNet.ConvertToEnglish(),
                //TaxAsTextEn = toWordTax.ConvertToEnglish(),
                Notes = suppMain.Notes,
                TaxPrice = suppMain.TaxPrice,
                paidCash =suppMain.paidCash,
                PlateNumber = suppMain.PlateNumber,
                PoNumber = suppMain.PoNumber,
                RefNo = suppMain.RefNo,
                Status = ClsSupplyStatus.GetString(suppMain.Status, string.IsNullOrEmpty(customer?.TaxNo), false),
                TaxPercent = suppMain.TaxPercent,
                TotalAfterDiscount = suppMain.TotalAfterDiscount,
                Total = suppMain.Total,
                UserIdStr = Session.CurrentUser.Name,// Session.UserTbls.Where(x => x.ID == suppMain.UserId).Select(x => x.Name).FirstOrDefault(),
                QRCode = new TLVCls(suppMain).ToBase64(),
                TotalPaid = suppMain.TotalPaid,
                Remin = suppMain.Remin,
            };
            CustomerData = customer != null ? new CustomerCustom
            {
                AddNo = customer.AddNo,
                Address = customer.Address,
                AddressEn = customer.AddressEn,
                AnotherID = customer.AnotherID,
                //BankData = (Session.Banks?.FirstOrDefault(x => x.ID == customer.BankId) is Bank b && b != null) ? new BankCustom
                //{
                //    AccIBAN = b.AccIBAN,
                //    AccNoInBank = b.AccNoInBank,
                //    Name = b.Name,
                //    NameEn = b.NameEn,
                //    SwiftCode = b.SwiftCode
                //} : null,
                BuildingNo = customer.BuildingNo,
                City = customer.City,
                CityEn = customer.CityEn,
                CommercialRegister = customer.CommercialRegister,
                CommercialRegisterEn = customer.CommercialRegister,
                Country = customer.Country,
                CountryEn = customer.CountryEn,
                District = customer.District,
                DistrictEn = customer.DistrictEn,
                Name = customer.Name,
                NameEn = customer.NameEn,
                No = customer.No,
                PhnNo = customer.PhnNo,
                PostalCode = customer.PostalCode,
                TaxNo = customer.TaxNo,
            } : null;
            BranchData = new BranchCustom
            {
                Address = branch.Address,
                Email = branch.Email,
                AddressEn = branch.AddressEn,
                FaxNo = branch.FaxNo,
                Image = branch.Image,
                MailBox = branch.MailBox,
                Name = branch.Name,
                NameEn = branch.NameEn,
                No = branch.No,
                Notes = branch.Notes,
                PhnNo = branch.PhnNo,
                TaxNo = branch.TaxNo,
                TradeNo = branch.TradeNo,
            };
            //Console.WriteLine($"===============InvoiceReport2 = {DateTime.Now.ToString("yy-MM-dd-hh-mm-ss-ffffff")}");
        }
        //double GetTowDigit(double? value) => value==null?0: Convert.ToDouble($"{value:n2}");
        private async void GetAsynData(SupplyMain suppMain, Customer customer, Branch branch)
        {
            //IList<Task> taskList = new List<Task>();
            //taskList.Add(Task.Run(() => SupplyMainData = new SupplyMainCustom
            //{
            //    Desc = suppMain.Desc,
            //    DscntAmount = GetTowDigit(suppMain.DscntAmount),
            //    DscntPercent = GetTowDigit(suppMain.DscntPercent),
            //    DueDate = suppMain.DueDate,
            //    IsCash = ClsSupplyStatus.GetPaymentString(suppMain.IsCash),
            //    BankAmount = GetTowDigit(suppMain.BankAmount),
            //    CarType = suppMain.CarType,
            //    CounterNumber = suppMain.CounterNumber,
            //    Currency = Session.Currencies.Where(x => x.ID == suppMain.Currency).Select(x => x.Name).FirstOrDefault(),
            //    Date = suppMain.Date,
            //    No = suppMain.No,
            //    Net = GetTowDigit(suppMain.Net),
            //    NetTextAr = new ToWord(suppMain.Net).ConvertToArabic(),
            //    TaxAsTextAr = new ToWord(suppMain.TaxPrice).ConvertToArabic(),
            //    NetTextEn = new ToWord(suppMain.Net).ConvertToEnglish(),
            //    TaxAsTextEn = new ToWord(suppMain.TaxPrice).ConvertToEnglish(),
            //    Notes = suppMain.Notes,
            //    TaxPrice = GetTowDigit(suppMain.TaxPrice),
            //    paidCash = GetTowDigit(suppMain.paidCash),
            //    PlateNumber = suppMain.PlateNumber,
            //    PoNumber = suppMain.PoNumber,
            //    RefNo = suppMain.RefNo,
            //    Status = ClsSupplyStatus.GetString(suppMain.Status, string.IsNullOrEmpty(customer?.TaxNo), false),
            //    TaxPercent = suppMain.TaxPercent,
            //    TotalAfterDiscount = GetTowDigit(suppMain.TotalAfterDiscount),
            //    Total = GetTowDigit(suppMain.Total),
            //    UserIdStr = Session.UserTbls.Where(x => x.ID == suppMain.UserId).Select(x => x.Name).FirstOrDefault(),
            //    QRCode = new TLVCls(suppMain).ToBase64(),
            //    TotalPaid = GetTowDigit(suppMain.TotalPaid),
            //    Remin = GetTowDigit(suppMain.Remin),
            //}));
            //taskList.Add(Task.Run(() => CustomerData = customer != null ? new CustomerCustom
            //{
            //    AddNo = customer.AddNo,
            //    Address = customer.Address,
            //    AddressEn = customer.AddressEn,
            //    AnotherID = customer.AnotherID,
            //    BankData = (Session.Banks?.FirstOrDefault(x => x.ID == customer.BankId) is Bank b && b != null) ? new BankCustom
            //    {
            //        AccIBAN = b.AccIBAN,
            //        AccNoInBank = b.AccNoInBank,
            //        Name = b.Name,
            //        NameEn = b.NameEn,
            //        SwiftCode = b.SwiftCode
            //    } : null,
            //    BuildingNo = customer.BuildingNo,
            //    City = customer.City,
            //    CityEn = customer.CityEn,
            //    CommercialRegister = customer.CommercialRegister,
            //    CommercialRegisterEn = customer.CommercialRegister,
            //    Country = customer.Country,
            //    CountryEn = customer.CountryEn,
            //    District = customer.District,
            //    DistrictEn = customer.DistrictEn,
            //    Name = customer.Name,
            //    NameEn = customer.NameEn,
            //    No = customer.No,
            //    PhnNo = customer.PhnNo,
            //    PostalCode = customer.PostalCode,
            //    TaxNo = customer.TaxNo,
            //} : null));
            //taskList.Add(Task.Run(() => BranchData = new BranchCustom
            //{
            //    Address = branch.Address,
            //    Email = branch.Email,
            //    AddressEn = branch.AddressEn,
            //    FaxNo = branch.FaxNo,
            //    Image = branch.Image,
            //    MailBox = branch.MailBox,
            //    Name = branch.Name,
            //    NameEn = branch.NameEn,
            //    No = branch.No,
            //    Notes = branch.Notes,
            //    PhnNo = branch.PhnNo,
            //    TaxNo = branch.TaxNo,
            //    TradeNo = branch.TradeNo,
            //}));
            //await Task.WhenAll(taskList);
        }
        [DisplayName("الفاتورة")]
        public SupplyMainCustom SupplyMainData { get; set; }
        [DisplayName("العميل")]
        public CustomerCustom CustomerData { get; set; }
        [DisplayName("الفرع")]
        public BranchCustom BranchData { get; set; }
    
    }
    public class SupplyMainCustom
    {
        [Category("SupplyMain")]
        [DisplayName("رقم الفاتورة")]
        public int No { get; set; }
        [DisplayName("تاريخ الفاتورة")]
        public DateTime? Date { get; set; }
        [DisplayName("تاريخ الاستحقاق")]
        public DateTime? DueDate { get; set; }
        [DisplayName("المستخدم")]
        public string UserIdStr { get; set; }
        [DisplayName("طريقة الدفع")]
        public string IsCash { get; set; }
        [DisplayName("نوع الفاتورة")]
        public string Status { get; set; }
        [DisplayName("البيان")]
        public string Desc { get; set; }
        [DisplayName("رقم المرجع")]
        public string RefNo { get; set; }
        [DisplayName("العملة")]
        public string Currency { get; set; }
        [DisplayName("نوع السيارة")]
        public string CarType { get; set; }
        [DisplayName("رقم اللوحة")]
        public string PlateNumber { get; set; }
        [DisplayName("رقم العداد")]
        public string CounterNumber { get; set; }
        [DisplayName("رقم امر الشراء")]
        public string PoNumber { get; set; }
        [DisplayName("ملاحظات")]
        public string Notes { get; set; }
        [DisplayName("الإجمالي قبل الخصم")]
        public double Total { get; set; }
        [DisplayName("نسبة الخصم")]
        public double DscntPercent { get; set; }
        [DisplayName("الخصم")]
        public double DscntAmount { get; set; }
        [DisplayName("نسبة الضريبة")]
        public byte? TaxPercent { get; set; }
        [DisplayName("إجمالي الضريبة")]
        public double TaxPrice { get; set; }
        [DisplayName("الضريبه نصا عربي")]
        public string TaxAsTextAr { get; set; }
        [DisplayName("الضريبه نصا انجليزي")]
        public string TaxAsTextEn { get; set; }
        [DisplayName("الإجمالي بعد الخصم")]
        public double? TotalAfterDiscount { get; set; }
        [DisplayName("الإجمالي النهائي")]
        public double Net { get; set; }
        [DisplayName("الصافي نصا عربي")]
        public string NetTextAr { get; set; }
        [DisplayName("الصافي نصا انجليزي")]
        public string NetTextEn { get; set; }
        [DisplayName("المدفوع نقدا")]
        public double paidCash { get; set; }
        [DisplayName("المدفوع شبكة")]
        public double BankAmount { get; set; }
        [DisplayName("إجمالي المدفوع")]
        public double TotalPaid { get; set; }
        [DisplayName("المتبقي")]
        public double Remin { get; set; }
        [DisplayName("الباركود QRCode")]
        public string QRCode { get; set; }
    }
    public class CustomerCustom
    {
        [Category("Customer")]
        [DisplayName("إسم العميل")]
        public string Name { get; set; }
        [DisplayName("إسم العميل انجليزي")]
        public string NameEn { get; set; }
        [DisplayName("عنوان العميل")]
        public string Address { get; set; }
        [DisplayName("عنوان العميل انجليزي")]
        public string AddressEn { get; set; }
        [DisplayName("المدينة")]
        public string City { get; set; }
        [DisplayName("المدينة انجليزي")]
        public string CityEn { get; set; }
        [DisplayName("رقم العميل")]
        public int No { get; set; }
        [DisplayName("رقم المبنى")]
        public string BuildingNo { get; set; }
        [DisplayName("الرقم الإضافي")]
        public string AddNo { get; set; }
        [DisplayName("معرف آخر")]
        public string AnotherID { get; set; }
        [DisplayName("الحي")]
        public string District { get; set; }
        [DisplayName("الحي انجليزي")]
        public string DistrictEn { get; set; }
        [DisplayName("رقم هاتف العميل")]
        public string PhnNo { get; set; }
        [DisplayName("رقم العميل الضريبي")]
        public string TaxNo { get; set; }
        [DisplayName("رقم السجل التجاري")]
        public string CommercialRegister { get; set; }
        [DisplayName("رقم السجل انجليزي")]
        public string CommercialRegisterEn { get; set; }
        [DisplayName("الرمز البريدي")]
        public string PostalCode { get; set; }
        [DisplayName("البلد")]
        public string Country { get; set; }
        [DisplayName("البلد انجليزي")]
        public string CountryEn { get; set; }
        [DisplayName("بيانات البنك")]
        public BankCustom BankData { get; set; }
    }
    public class BankCustom
    {
        [Category("Bank")]
        [DisplayName("اسم البنك")]
        public string Name { get; set; }
        [DisplayName("اسم البنك انجليزي")]
        public string NameEn { get; set; }
        [DisplayName("رقم الحساب البنكي")]
        public string AccNoInBank { get; set; }
        [DisplayName("IBAN البنك")]
        public string AccIBAN { get; set; }
        [DisplayName("Swift Code")]
        public string SwiftCode { get; set; }
    }
    public class BranchCustom
    {
        [DisplayName("الشعار")]
        public byte[] Image { get; set; }
        [DisplayName("رقم الفرع")]
        public short No { get; set; }
        [DisplayName("الرسالة الترحيبية")]
        public string Notes { get; set; }
        [DisplayName("إسم الفرع")]
        public string Name { get; set; }
        [DisplayName("إسم الفرع اجنبي")]
        public string NameEn { get; set; }
        [DisplayName("العنوان")]
        public string Address { get; set; }
        [DisplayName("العنوان اجنبي")]
        public string AddressEn { get; set; }
        [DisplayName("البريد الإلكتروني")]
        public string Email { get; set; }
        [DisplayName("رقم الهاتف")]
        public string PhnNo { get; set; }
        [DisplayName("رقم الفاكس")]
        public string FaxNo { get; set; }
        [DisplayName("رقم صندوق البريد")]
        public string MailBox { get; set; }
        [DisplayName("الرقم الضريبي")]
        public string TaxNo { get; set; }
        [DisplayName("رقم السجل التجاري")]
        public string TradeNo { get; set; }
    }
}
