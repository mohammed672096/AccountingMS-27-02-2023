using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace PosFinalCost.Classe
{
    public class EntryDataCustom
    {
        public EntryDataCustom(EntryMain EntryMain)
        {
            Branch branch = Session.Branches?.FirstOrDefault(x=>x.ID== EntryMain.BranchID);
            var toWord = new ToWord(EntryMain.Amount);
            EntryData = new EntryCustom
            {
                Notes = EntryMain.Notes,
                AccName= EntryMain.PayMethod==1?Session.Boxes?.FirstOrDefault(x=>x.AccNo== EntryMain.AccNo).Name:
                Session.Banks?.FirstOrDefault(x => x.AccNo == EntryMain.AccNo).Name,
                AccNo= EntryMain.AccNo,
                PayMethod=MyTools.EntryPayMethodType(EntryMain.PayMethod.GetValueOrDefault()),
                Amount=EntryMain.Amount,
                AmountStr= toWord.ConvertToArabic(),
                AmountStrEng= toWord.ConvertToEnglish(),
                CurChange=EntryMain.CurChange,
                Currency = Session.Currencies?.Where(c => c.ID == EntryMain.Currency).Select(x => x.Name)?.FirstOrDefault(),
                Date=EntryMain.Date,
                EntType=MyTools.EntryStatus(EntryMain.Status),
                FromToPerson=EntryMain.FromToPerson,
                No=EntryMain.No,
                RefNo=EntryMain.RefNo,
            };
            if (branch == null) branch = Session.CurrentBranch;
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

        }
        [DisplayName("بيانات المستند")]
        public EntryCustom EntryData { get; set; }
        [DisplayName("بيانات الفرع")]
        public BranchCustom BranchData { get; set; }
    }
    public class EntryCustom
    {
        [DisplayName("رقم المستند")]
        public int No { get; set; }
        [DisplayName("البيان")]
        public string Notes { get; set; }
        [DisplayName("المبلغ")]
        public double Amount { get; set; }
        [DisplayName("المبلغ نصا")]
        public string AmountStr { get; set; }
        [DisplayName("المستلم")]
        public string FromToPerson { get; set; }
        [DisplayName("طريقة الدفع/الاستلام")]
        public string PayMethod { get; set; }
        [DisplayName("رقم الحساب")]
        public Nullable<long> AccNo { get; set; }
        [DisplayName("اسم الحساب")]
        public string AccName { get; set; }
        [DisplayName("المبلغ نصا انجليزي")]
        public string AmountStrEng { get; set; }
        [DisplayName("رقم المرجع")]
        public int? RefNo { get; set; }
        [DisplayName("نوع المستند")]
        public string EntType { get; set; }
        [DisplayName("التاريخ")]
        public DateTime? Date { get; set; }
        [DisplayName("العملة")]
        public string Currency { get; set; }
        [DisplayName("سعر الصرف")]
        public Nullable<short> CurChange { get; set; }
    }
}
