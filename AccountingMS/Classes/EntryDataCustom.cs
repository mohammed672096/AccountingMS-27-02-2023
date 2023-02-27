using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingMS.Classes
{
    [DisplayName("بيانات التقرير")]
    public class EntryDataCustom
    {
        public EntryDataCustom(tblEntryMain EntryMain,string boxName)
        {
            tblBranch branch = GetBranch();

            var toWord = new ToWord(EntryMain.entAmount);
            EntryData = new tblEntryCustom
            {
                entDesc = EntryMain.entDesc,
                entAmount = Convert.ToDecimal($"{EntryMain.entAmount:n2}"),
                boxName = boxName != "نقدي" ? "" : boxName,
                bankName = boxName == "نقدي" ? "" : boxName,
                entDate = EntryMain.entDate,
                entNo = EntryMain.entNo,
                entRefNo = EntryMain.entRefNo,
                entReverseConstraint = EntryMain.entReverseConstraint,
                entReverseConstraintDate = EntryMain.entReverseConstraintDate,
                entType = ClsEntryStatus.GetString(EntryMain.entStatus),
                entAmountStr= toWord.ConvertToArabic(),
                entAmountStrEng= toWord.ConvertToEnglish()
            };
            BranchData = new tblBranchCustom
            {
                brnAddress = branch.brnAddress,
                brnEmail = branch.brnEmail,
                brnAddressEn = branch.brnAddressEn,
                brnFaxNo = branch.brnFaxNo,
                brnMailBox = branch.brnMailBox,
                brnName = branch.brnName,
                brnNameEn = branch.brnNameEn,
                brnNo = branch.brnNo,
                brnPhnNo = branch.brnPhnNo,
                brnTaxNo = branch.brnTaxNo,
                brnTradeNo = branch.brnTradeNo,
            };
        
        }
        [DisplayName("بيانات المستند")]
        public tblEntryCustom EntryData { get; set; }
        [DisplayName("بيانات الفرع")]
        public tblBranchCustom BranchData { get; set; }
        tblBranch GetBranch()
        {
            using (var db = new accountingEntities())
                return db.tblBranches.FirstOrDefault(x => x.brnId == Session.CurBranch.brnId);
        }
    }
  public  class tblEntryCustom
    {
        [DisplayName("رقم المستند")]
        public int entNo { get; set; }
        [DisplayName("الصندوق")]
        public string boxName { get; set; }
        [DisplayName("البنك")]
        public string bankName { get; set; }
        [DisplayName("البيان")]
        public string entDesc { get; set; }
        [DisplayName("المبلغ")]
        public decimal entAmount { get; set; }
        [DisplayName("المبلغ نصا")]
        public string entAmountStr { get; set; }
        [DisplayName("المبلغ نصا انجليزي")]
        public string entAmountStrEng { get; set; }
        [DisplayName("رقم المرجع")]
        public int? entRefNo { get; set; }
        [DisplayName("نوع المستند")]
        public string entType { get; set; }
        [DisplayName("التاريخ")]
        public DateTime? entDate { get; set; }
        [DisplayName("قيد عكس")]
        public string entReverseConstraint { get; set; }
        [DisplayName("تاريخ قيد عكس")]
        public DateTime? entReverseConstraintDate { get; set; }
    }
}
