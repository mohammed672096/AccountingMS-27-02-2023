using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosFinalCost.Classe
{
    public class EntrySubCustom
    {
        public bool ValidateReportEntryVocherCustomFile()
        {
            if (File.Exists(ClsPath.ReportEntryVocher)) return true;
            DevExpress.XtraEditors.XtraMessageBox.Show((!Program.My_Setting.LangEng) ? "عذرا لم يتم العثور على ملف التقرير المخصص" : "Sorry could not find custom report file");
            return false;
        }
        public List<EntrySubCustom> GetEntrySubToList(List<EntrySub> entrySubs)
        {
            List<EntrySubCustom> entylist = new List<EntrySubCustom>();
            entrySubs.ForEach(x => {
                Customer customer = Session.Customers?.FirstOrDefault(c => c.ID == x.CustomerID);
                entylist.Add(new EntrySubCustom
                {
                    AccNo = x.AccNo,
                    CurChange = x.CurChange,
                    Currency = Session.Currencies?.Where(c => c.ID == x.Currency).Select(x => x.Name)?.FirstOrDefault(),
                    DainFrgn = x.DainFrgn,
                    CustomerID = x.CustomerID,
                    Dain = x.Dain,
                    Madin = x.Madin,
                    MadinFrgn = x.MadinFrgn,
                    Name = customer?.Name,
                    Notes = x.Notes,
                });
            });
           
            return entylist;
        }
        [DisplayName("رقم الحساب")]
        public Nullable<long> AccNo { get; set; }
        [DisplayName("البيان")]
        public string Notes { get; set; }
        [DisplayName("المبلغ - مدين")]
        public Nullable<double> Madin { get; set; }
        [DisplayName("المبلغ - دائن")]
        public Nullable<double> Dain { get; set; }
        [DisplayName("مدين اجنبي")]
        public Nullable<double> MadinFrgn { get; set; }
        [DisplayName("دائن اجنبي")]
        public Nullable<double> DainFrgn { get; set; }
        [DisplayName("العملة")]
        public string Currency { get; set; }
        [DisplayName("سعر الصرف")]
        public Nullable<short> CurChange { get; set; }
        [DisplayName("رقم العميل")]
        public Nullable<int> CustomerID { get; set; }
        [DisplayName("اسم العميل")]
        public string Name { get; set; }
}
}
