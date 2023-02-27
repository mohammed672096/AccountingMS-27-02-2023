using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassib.Common
{
    public enum WindowActions
    {
        [Display(Name = "اضافه")]
        Add = 2,
        [Display(Name = "تعديل")]
        Edit = 4,
        [Display(Name = "حذف")]
        Delete = 8,
        [Display(Name = "طباعه")]
        Print = 16,
        [Display(Name = "اظهار")]
        Show = 32,
        [Display(Name = "فتح")]
        Open = 64,
        [Display(Name = "الكل")]
        All = Add | Edit | Delete | Print | Show | Open
    };

    public enum TransactionState
    {
        [Display(Name = "غير مرحل")]
        NotPosted =0,
        [Display(Name = "محجوز")]
        Reserved =1,
        [Display(Name = "مرحل")]
        Posted=2,
    };

   
}
