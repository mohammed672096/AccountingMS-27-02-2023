//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccountingMS.Language {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class EmployeesNotificationAr {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal EmployeesNotificationAr() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AccountingMS.Language.EmployeesNotificationAr", typeof(EmployeesNotificationAr).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to العدد : .
        /// </summary>
        internal static string count {
            get {
                return ResourceManager.GetString("count", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to عذرا لا يمكن حذف الموظف : {0} ، يرجى حذف القيود المترتبه عليه أولا!.
        /// </summary>
        internal static string delEmpErrorMssg {
            get {
                return ResourceManager.GetString("delEmpErrorMssg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to هل انت متاكد من حذف الموظف : {0} ؟.
        /// </summary>
        internal static string delEmpMssg {
            get {
                return ResourceManager.GetString("delEmpMssg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to تم حذف الموظف {0} : بنجاح..
        /// </summary>
        internal static string delEmpSuccessMssg {
            get {
                return ResourceManager.GetString("delEmpSuccessMssg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to هل انت متاكد من حذف سند صرف موظفين رقم : {0}؟.
        /// </summary>
        internal static string delEntMssg {
            get {
                return ResourceManager.GetString("delEntMssg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to تم حذف سند صرف موظفين رقم : {0} بنجاح..
        /// </summary>
        internal static string delEntSuccessMssg {
            get {
                return ResourceManager.GetString("delEntSuccessMssg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to الموظف : .
        /// </summary>
        internal static string employee {
            get {
                return ResourceManager.GetString("employee", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to عذرا لقد تم إستخدام السند رقم {0} مسبقا..
        /// </summary>
        internal static string entErrorMssg {
            get {
                return ResourceManager.GetString("entErrorMssg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to سند صرف موظفين رقم :  {0}.
        /// </summary>
        internal static string entSuccessMssg {
            get {
                return ResourceManager.GetString("entSuccessMssg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to هل انت متاكد من ترحيل سندات صرف الموظفين؟.
        /// </summary>
        internal static string phaseMssg {
            get {
                return ResourceManager.GetString("phaseMssg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to تم ترحيل سندات صرف الموظفين بنجاح.
        /// </summary>
        internal static string phaseSuccessMssg {
            get {
                return ResourceManager.GetString("phaseSuccessMssg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to هل تريد طباعة السند رقم : {0}؟.
        /// </summary>
        internal static string printMssg {
            get {
                return ResourceManager.GetString("printMssg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to عذرا هناك خطاء في المبالغ التي ادخلتها.
        /// </summary>
        internal static string validateAmountMssg {
            get {
                return ResourceManager.GetString("validateAmountMssg", resourceCulture);
            }
        }
    }
}
