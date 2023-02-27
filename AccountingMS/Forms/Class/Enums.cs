using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassib.HR
{
 

    public enum GenderType
    {
        [Display(Name = "ذكر")]
        Male,

        [Display(Name = "أنثى")]
        Female,


    }

    public enum MaritalStatus
    {
        [Display(Name = "اعزب")]
        Single,

        [Display(Name = "متزوج")]
        Married,


    }


    public enum MilitarilyStatus
    {
        [Display(Name = "اعفاء")]
        Exemption,

        [Display(Name = "مؤجل")]
        Delayed,

        [Display(Name = "مؤدى")]
        Completion,
    }
    public enum ContractTypes
    {
        [Display(Name = "مؤقت")]
        Temporary,

        [Display(Name = "دائم")]
        Peremenant,
    }
    public enum EType
    {
        [Display(Name = "وقت اضافى")]
        Overtime,

        [Display(Name = "تاخير")]
        Delay,


    }



    public enum EMethod
    {
        [Display(Name = "الدقيقة")]
        Minute,

        [Display(Name = "الفترة")]
        Period,


    }

    public enum EStatus
    {
        [Display(Name = "معطل")]
        Inactive,

        [Display(Name = "نشط")]
        Active,


    }




    public enum ExtensionType
    {
        [Display(Name = "استحقاق")]
        Benefit,

        [Display(Name = "استقطاع")]
        Deduction,


    }




    public enum ECalculationType
    {
        [Display(Name = "مبلغ ثابت")]
        FixedAmount,

        [Display(Name = "معادلة")]
        Equation,


    }

    public enum ESalaryPeriod
    {
        [Display(Name = "اسبوع")]
        Week,

        [Display(Name = "اسبوعين")]
        TwoWeek,

        [Display(Name = "شهر")]
        Month,
        [Display(Name = "بالقطعة")]
        Piece,
    }


    public enum ESalaryCalculation
    {
        [Display(Name = "قيمة ثابتة")]
        FixedAmount,

        [Display(Name = "معادلة")]
        Equation,


    }

}
