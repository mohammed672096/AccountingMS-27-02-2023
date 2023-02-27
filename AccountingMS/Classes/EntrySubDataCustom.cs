using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingMS.Classes
{
  public  class EntrySubDataCustom
    {
        public bool ValidateReportEntryVocherCustomFile()
        {
            if (File.Exists(ClsPath.ReportEntryVocherCustomFile)) return true;
            DevExpress.XtraEditors.XtraMessageBox.Show((!MySetting.GetPrivateSetting.LangEng) ? "عذرا لم يتم العثور على ملف التقرير المخصص" : "Sorry could not find custom report file");
            return false;
        }
        public List<EntrySubDataCustom> GetEntrySubToList(List<tblEntrySub> entrySubs)
        {
            List<EntrySubDataCustom> entylist = new List<EntrySubDataCustom>();
            entrySubs.ForEach(x => entylist.Add(new EntrySubDataCustom
            {
                entAccName = x.entAccName,
                entAccNo = x.entAccNo,
                entBoxNo = x.entBoxNo,
                entCredit = x.entCredit,
                entCreditFrgn = x.entCreditFrgn,
                entCurChange = x.entCurChange,
                entCurrency = new ClsTblCurrency().GetCurrencyNameById(x.entCurrency.Value),
                entCusName = x.entCusName,
                entCusNo = x.entCusNo,
                entDebit = x.entDebit,
                entDebitFrgn = x.entDebitFrgn,
                entDesc = x.entDesc,
                entInvoDate = x.entInvoDate,
                entTaxNumber = x.entTaxNumber,
                entTaxPercent = x.entTaxPercent,
                entTaxPrice = x.entTaxPrice,
                invoNum = x.invoNum,
                supplyName = x.supplyName,
            }
            ));
            return entylist;
        }
        [DisplayName("رقم الحساب")]
        public Nullable<long> entAccNo { get; set; }
        [DisplayName("اسم الحساب")]
        public string entAccName { get; set; }
        [DisplayName("الصندوق")]
        public Nullable<int> entBoxNo { get; set; }
        [DisplayName("البيان")]
        public string entDesc { get; set; }
        [DisplayName("المبلغ - مدين")]
        public Nullable<double> entDebit { get; set; }
        [DisplayName("المبلغ - دائن")]
        public Nullable<double> entCredit { get; set; }
        [DisplayName("مدين اجنبي")]
        public Nullable<double> entDebitFrgn { get; set; }
        [DisplayName("دائن اجنبي")]
        public Nullable<double> entCreditFrgn { get; set; }
        [DisplayName("نسبة الضريبة")]
        public Nullable<byte> entTaxPercent { get; set; }
        [DisplayName("الضريبة")]
        public Nullable<double> entTaxPrice { get; set; }
        [DisplayName("العملة")]
        public string entCurrency { get; set; }
        [DisplayName("سعر الصرف")]
        public Nullable<short> entCurChange { get; set; }
        [DisplayName("رقم العميل")]
        public Nullable<int> entCusNo { get; set; }
        [DisplayName("العميل")]
        public string entCusName { get; set; }
        [DisplayName("الرقم الضريبي")]
        public string entTaxNumber { get; set; }
        [DisplayName("رقم الفاتورة")]
        public string invoNum { get; set; }
        [DisplayName("المورد")]
        public string supplyName { get; set; }
        [DisplayName("تاريخ الفاتورة")]
        public Nullable<System.DateTime> entInvoDate { get; set; }
    }
}
