using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
using AccountingMS.Classes;
namespace AccountingMS.Model
{
    [DisplayName("يوميات الصناديق")]
    public partial class DrawerPeriod : BaseNotifyPropertyChangedModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ReadOnly(true)]
        [Display(Name = "كود", GroupName = "البيانات")]
        public int ID { get; set; }


        private DateTime periodStart;
        [Display(Name = "تاريخ الفتح")]
        //[Required(ErrorMessageResourceName = nameof(Classes.LangResource.ErrorCantBeEmpry), ErrorMessageResourceType = typeof(Classes.LangResource))]
        public DateTime PeriodStart
        {
            get { return periodStart; }
            set { SetProperty(ref periodStart, value); }
        }
        private DateTime? periodEnd;
        [Display(Name = "تاريخ الاغلاق")]
        public DateTime? PeriodEnd
        {
            get { return periodEnd; }
            set { SetProperty(ref periodEnd, value); }
        }

        private double opningBalance;
        [Display(Name = "رصيد بدايه")]
        public double OpeningBalance
        {
            get { return opningBalance; }
            set { SetProperty(ref opningBalance, value); }
        }


        private double closingBalance;
        [Display(Name = "رصيد نهايه")]
        public double ClosingBalance
        {
            get { return closingBalance; }
            set { SetProperty(ref closingBalance, value); }
        }


        private double actualBalance;
        [Display(Name = "رصيد فعلي")]
        public double ActualBalance
        {
            get { return actualBalance; }
            set { SetProperty(ref actualBalance, value); }
        }

        [Display(Name = "عجز/ذياده")]
        public double BalanceDifference { get => actualBalance - closingBalance; }


        private int? differenceAccountID;
        [Display(Name = "حساب تسويه العجز/الذياده")]
        //  [RequiredIf(nameof(BalanceDifference) , 0D , true, ErrorMessageResourceName = nameof(Classes.LangResource.ErrorCantBeEmpry), ErrorMessageResourceType = typeof(Classes.LangResource))]
        public int? DifferenceAccountID
        {
            get { return differenceAccountID; }
            set { SetProperty(ref differenceAccountID, value); }
        }

        private int periodUserID;
        [Display(Name = "مستخدم الفتره")]
        //[Required(ErrorMessageResourceName = nameof(Classes.LangResource.ErrorCantBeEmpry), ErrorMessageResourceType = typeof(Classes.LangResource))]
        public int PeriodUserID
        {
            get { return periodUserID; }
            set { SetProperty(ref periodUserID, value); }
        }

        private int? closingPeriodUserID;
        [Display(Name = "مستخدم الاغلاق")]
        //[RequiredIf(nameof(PeriodEnd), null, true, ErrorMessageResourceName = nameof(Classes.LangResource.ErrorCantBeEmpry), ErrorMessageResourceType = typeof(Classes.LangResource))]
        public int? ClosingPeriodUserID
        {
            get { return closingPeriodUserID; }
            set { SetProperty(ref closingPeriodUserID, value); }
        }




        private tblBranch branch;
        [Display(Name = "")]
        public tblBranch Branch
        {
            get { return branch; }
            set { SetProperty(ref branch, value); }
        }

        private int branchID;
        [Display(Name = "الفرع")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "هذا الحقل مطلوب")]
        public int BranchID
        {
            get { return branchID; }
            set { SetProperty(ref branchID, value); }
        }



        private int drawerID;
        [Display(Name = "الصندوق")]
        //[Required(ErrorMessageResourceName = nameof(Classes.LangResource.ErrorCantBeEmpry), ErrorMessageResourceType = typeof(Classes.LangResource))]
        public int DrawerID
        {
            get { return drawerID; }
            set { SetProperty(ref drawerID, value); }
        }



        private int? closingDrawerID;
        [Display(Name = "صندوق الاغلاق")]
        //[RequiredIf(nameof(TransferdBalance), 0D, true, ErrorMessageResourceName = nameof(Classes.LangResource.ErrorCantBeEmpry), ErrorMessageResourceType = typeof(Classes.LangResource))]
        public int? ClosingDrwerID
        {
            get { return closingDrawerID; }
            set { SetProperty(ref closingDrawerID, value); }
        }

        private double transferdBalance;
        [Display(Name = "رصيد محول")]
        public double TransferdBalance
        {
            get { return transferdBalance; }
            set { SetProperty(ref transferdBalance, value); }
        }



        private double remainingBalance;
        [Display(Name = "رصيد متبقي")]
        public double RemainingBalance
        {
            get { return remainingBalance; }
            set { SetProperty(ref remainingBalance, value); }
        }




        [Display(Name = "مغلقه")]
        public bool IsClosed
        {
            get => PeriodEnd.HasValue;

        }


        [Display(Name = "ملخص عميات المده")]
        public BindingList<DrawerPeriodTransSummeryItem> Summery { get; set; }



    }
    [DisplayName("ملخص يوميات الصندوق")]
    public partial class DrawerPeriodTransSummeryItem : BaseNotifyPropertyChangedModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ReadOnly(true)]
        public int ID { get; set; }


        public DrawerPeriod DrawerPeriod { get; set; }
        public int DrawerPeriodID { get; set; }


        //[Display(Name = "نوع العمليه")]
        //public SystemProcess ProcessType { get; set; }

        private int processCount;
        [Display(Name = "العدد")]
        public int ProcessCount
        {
            get { return processCount; }
            set { SetProperty(ref processCount, value); }
        }

        private double processSum;
        [Display(Name = "الاجمالي")]
        public double ProcessSum
        {
            get { return processSum; }
            set { SetProperty(ref processSum, value); }
        }




    }
}
