using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Utils;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using DevExpress.XtraEditors.Repository;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.CompilerServices;
using Microsoft.Win32;
using System.Data.Sql;
using DevExpress.Data.Helpers;
using DevExpress.Utils.Extensions;
using DevExpress.ChartRangeControlClient.Core;

namespace PosFinalCost.Classe
{
    static class MyTools
    {
        public static List<string> GetListPrinter => (from p in (new ManagementObjectSearcher("SELECT * from Win32_Printer").Get().Cast<object>())
                                                      select ((ManagementObject)p).GetPropertyValue("Name").ToString()).ToList();
        //public static List<string> GetListPrinter()
        //{
        //    List<string> Printer_List = new List<string>();
        //    var printerQuery = new ManagementObjectSearcher("SELECT * from Win32_Printer");
        //    var g= (from p in (new ManagementObjectSearcher("SELECT * from Win32_Printer").Get().Cast<object>())
        //            select ((ManagementObject)p).GetPropertyValue("Name").ToString()).ToList();
        //    foreach (var printer in printerQuery.Get())
        //        Printer_List.Add(printer.GetPropertyValue("Name").ToString());
        //    //Printer_List.Add("الطابعة الافتراضية");
        //    return Printer_List;
        //}
        static object data;
        public static BaseEdit GetPropertyControl(string propName, GetColumnForTableResult propertyValue)
        {
            UserSettingsProfile ins;
            BaseEdit edit = null;
            switch (propertyValue.user_type_id)
            {

                case 104:
                    edit = new ToggleSwitch();
                    ((ToggleSwitch)edit).Properties.OnText = Program.My_Setting.LangEng ? "On" : "نعم";
                    ((ToggleSwitch)edit).Properties.OffText = Program.My_Setting.LangEng ? "Off" : "لا";
                    break;
                case 56:
                    switch (propName)
                    {
                        case nameof(ins.DefaultStore):
                            data = Session.Stores;
                            break;
                        case nameof(ins.DefaultBox):
                            data = Session.Boxes;
                            break;
                        case nameof(ins.DefaultCustomer):
                            data = Session.Customers;
                            break;
                        case nameof(ins.DefaultBank):
                            data = Session.Banks;
                            break;
                        case nameof(ins.DefaultBranch):
                            data = Session.Branches;
                            break;
                    }
                    if (data != null)
                    {
                        edit = new LookUpEdit();
                        ((LookUpEdit)edit).IntializeData(data);
                    }
                    break;
                case 231:
                    switch (propName)
                    {
                        case nameof(ins.DefaultSalesPrinterName):
                            edit = new LookUpEdit();
                            ((LookUpEdit)edit).Properties.DataSource = GetListPrinter;
                            break;
                        default:
                            edit = new TextEdit();
                            break;
                    }
                    break;
                case 48:
                case 52:
                    switch (propName)
                    {
                        case nameof(ins.DefaultPayMethodInSales):
                            edit = new RadioGroup();
                            foreach (var item in MyTools.PayMethodsList)
                                ((RadioGroup)edit).Properties.Items.Add(new RadioGroupItem() { Description = item.Name, Value = item.ID });
                            ((RadioGroup)edit).AutoSizeInLayoutControl = true;
                            break;
                        case nameof(ins.ReadMode):
                            edit = new RadioGroup();
                            foreach (var item in MyTools.ReadModeList)
                                ((RadioGroup)edit).Properties.Items.Add(new RadioGroupItem() { Description = item.Name, Value = item.ID });
                            ((RadioGroup)edit).AutoSizeInLayoutControl = true;
                            break;
                        case nameof(ins.InvoicePrintMode):
                            edit = new RadioGroup();
                            foreach (var item in MyTools.PrintModeList)
                                ((RadioGroup)edit).Properties.Items.Add(new RadioGroupItem() { Description = item.Name, Value = item.ID });
                            ((RadioGroup)edit).AutoSizeInLayoutControl = true;
                            break;
                        case nameof(ins.PrintFileMode):
                            edit = new RadioGroup();
                            foreach (var item in MyTools.PrintFileModeList)
                                ((RadioGroup)edit).Properties.Items.Add(new RadioGroupItem() { Description = item.Name, Value = item.ID });
                            ((RadioGroup)edit).AutoSizeInLayoutControl = true;
                            break;
                        case nameof(ins.DefaultPrintPaper):
                            edit = new RadioGroup();
                            foreach (var item in MyTools.PrintPaperList)
                                ((RadioGroup)edit).Properties.Items.Add(new RadioGroupItem() { Description = item.Name, Value = item.ID });
                            ((RadioGroup)edit).AutoSizeInLayoutControl = true;
                            break;
                        case nameof(ins.defaultSalePriceFloar):
                        case nameof(ins.tsDefaultSalePriceAndBuy):
                            edit = new RadioGroup();
                            foreach (var item in MyTools.WarningLevelsList)
                                ((RadioGroup)edit).Properties.Items.Add(new RadioGroupItem() { Description = item.Name, Value = item.ID });
                            ((RadioGroup)edit).AutoSizeInLayoutControl = true;
                            break;
                        case nameof(ins.ValueCodeLength):
                        case nameof(ins.BarcodeLength):
                        case nameof(ins.ProductCodeLength):
                            edit = new SpinEdit();
                            ((SpinEdit)edit).Properties.Increment = 1;
                            ((SpinEdit)edit).Properties.MaxValue = 10000;
                            break;
                        case nameof(ins.DivideValueBy):
                            edit = new ComboBoxEdit();
                            ((ComboBoxEdit)edit).Properties.Items.AddRange(new int[] { 1, 10, 100, 1000, 10000 });
                            break;
                    }
                    break;
                case 62:
                    switch (propName)
                    {
                        case nameof(ins.MaxDiscountInInvoice):
                        case nameof(ins.taxDefault):
                            edit = new SpinEdit();
                            ((SpinEdit)edit).Properties.Increment = 0.01m;
                            ((SpinEdit)edit).Properties.Mask.EditMask = "p";
                            ((SpinEdit)edit).Properties.Mask.UseMaskAsDisplayFormat = true;
                            ((SpinEdit)edit).Properties.MaxValue = 1;
                            break;
                    }
                    break;
                default:
                    edit = new TextEdit();
                    break;
            }
            if (edit == null) edit = new TextEdit();
            if (edit != null)
            {
                edit.Name = propName;
                edit.Properties.NullText = "";
            }
            edit.ReadOnly = true;
            return edit;
        }

        static LayoutControlItem LayoutItem;
        #region MyLayoutControlGroupAndItem
        public static LayoutControlItem MyLayoutItem(Control control)
        {
            LayoutItem = new LayoutControlItem();
            LayoutItem.Control = control;
            return LayoutItem;
        }
        #endregion
        public static bool VisibilityItem(LayoutControlItem liName)
        {
            if (liName.Control.Name == "ID")
            {
                liName.Visibility = LayoutVisibility.Never;
                return true;
            }
            else if (liName.Control.Name == "UserID" | liName.Control.Name == "EnterTime")
            {
                ((BaseEdit)liName.Control).ReadOnly = true;
                return false;
            }
            return false;
        }
       public static void IntializeData(this RepositoryItemLookUpEditBase repo, object dataSource, GridColumn column, GridControl grid)
        {
            IntializeData(repo, dataSource, column, grid, "Name", "ID");
        }
        public static void IntializeData(this RepositoryItemLookUpEditBase repo, object dataSource, GridColumn column, GridControl grid, string displayMember, string valueMember)
        {
            if (repo == null)
                repo = new RepositoryItemLookUpEdit();
            repo.DataSource = dataSource;
            repo.DisplayMember = displayMember;
            repo.ValueMember = valueMember;
            repo.NullText = "";
            column.ColumnEdit = repo;
            if (grid != null)
                grid.RepositoryItems.Add(repo);
        }
        public static void IntializeData(this RepositoryItemSearchLookUpEdit repo, object dataSource)
        {
            IntializeData(repo, dataSource, "Name", "ID");
        }
        public static void IntializeData(this RepositoryItemSearchLookUpEdit repoPrdNo, object dataSource, string displayMember, string valueMember)
        {
            repoPrdNo.DataSource = dataSource;
            repoPrdNo.DisplayMember = displayMember;
            repoPrdNo.Name = "repoPrdNo";
            repoPrdNo.NullText = "";
            repoPrdNo.ValueMember = valueMember;
        }
        public static void IntializeData(this LookUpEdit lkp, object dataSource)
        {
            lkp.IntializeData(dataSource, "Name", "ID");
        }

        public static object GetTablName(object dataSource)
        {
            string FullName = dataSource.GetType().FullName;
            if (FullName.Contains("PosFinalCost.Branch"))
            {
                Tablname = "الفرع";
                return ((List<Branch>)dataSource).Select(x => new { ID = x.ID, Name = x.No + " - " + x.Name });
            }
            else if (FullName.Contains("PosFinalCost.StoreTbl"))
            {
                Tablname = "المخزن";
                return ((List<StoreTbl>)dataSource).Select(x => new { ID = x.ID, Name = x.No + " - " + x.Name });
            }
            else if (FullName.Contains("PosFinalCost.UserTbl"))
            {
                Tablname = "المستخدم";
                return ((List<UserTbl>)dataSource).Select(x => new { ID = x.ID, Name = x.Name });
            }
            else if (FullName.Contains("PosFinalCost.Bank"))
            {
                Tablname = "البنك";
                return ((List<Bank>)dataSource).Select(x => new { ID = x.ID, Name = x.No + " - " + x.Name, Currencie = x.Currency });
            }
            else if (FullName.Contains("PosFinalCost.Box"))
            {
                Tablname = "الصندوق";
                return ((List<Box>)dataSource).Select(x => new { ID = x.ID, Name = x.No + " - " + x.Name, Currencie = x.Currency });
            }
            else if (FullName.Contains("PosFinalCost.Customer"))
            {
                Tablname = "العميل";
                return ((List<Customer>)dataSource).Select(x => new { ID = x.ID, Name = x.No + " - " + x.Name, PhnNo = x.PhnNo, Currency = x.Currency });
            }
            else if (FullName.Contains("PosFinalCost.Currency"))
            {
                Tablname = "العمله";
                return ((List<Currency>)dataSource).Select(x => new { ID = x.ID, Name = x.Name, Change = x.Change });
            }
            else return dataSource;
        }

        static string Tablname;
        public static void IntializeData(this LookUpEdit lkp, object dataSource, string displayMember, string valueMember)
        {
            lkp.Properties.DataSource = GetTablName(dataSource);
            lkp.Properties.DisplayMember = displayMember;
            lkp.Properties.ValueMember = valueMember;
            lkp.Properties.Columns.Clear();
            lkp.Properties.Columns.AddRange(new LookUpColumnInfo[] {
            new LookUpColumnInfo("Name", Tablname)/*,new LookUpColumnInfo("Caption", Tablname)*/});
        }

        public static void IntializeData(this SearchLookUpEdit lkp, object dataSource)
        {
            lkp.IntializeData(dataSource, "Name", "ID");
        }

        public static void IntializeData(this SearchLookUpEdit lkp, object dataSource, string displayMember, string valueMember)
        {
            lkp.Properties.DataSource = GetTablName(dataSource);
            lkp.Properties.DisplayMember = displayMember;
            lkp.Properties.ValueMember = valueMember;
        }
        public static void IntializeData(this GridLookUpEdit lkp, object dataSource)
        {
            lkp.IntializeData(dataSource, "Name", "ID");
        }
        public static void IntializeData(this GridLookUpEdit lkp, object dataSource, string displayMember, string valueMember)
        {
            lkp.Properties.DataSource = dataSource;
            lkp.Properties.DisplayMember = displayMember;
            lkp.Properties.ValueMember = valueMember;

        }
        public static void BindToDataSource(this LookUpEdit lookUpEdit, object dataSource)
        {
            lookUpEdit.IntializeData(dataSource, "Name", "ID");
        }
        public class ValueAndID
        {
            public object ID { get; set; }
            public string Name { get; set; }
        }
        public static List<ValueAndID> ProductTypesList = new List<ValueAndID>() {
                new ValueAndID() { ID = 0, Name  ="مخزني" },
                new ValueAndID() { ID = 1, Name  ="خدمي" }

        };
        public static List<ValueAndID> l1;
        static List<ValueAndID> l2;
        public static async void AllBoxesAndBanks()
        {
            IList<Task> taskList = new List<Task>();
            taskList.Add(Task.Run(() => l1= (from b in Session.Banks
                                             select new ValueAndID
                                             {
                                                 ID = b.AccNo,
                                                 Name = b.Name,
                                             }).ToList()));
            taskList.Add(Task.Run(() => l2= (from b in Session.Boxes
                                             select new ValueAndID
                                              {
                                                  ID = b.AccNo,
                                                  Name = b.Name,
                                              }).ToList()));
            taskList.Add(Task.Run(() => Session.GetDataBoxes()));
            await Task.WhenAll(taskList);
            l1.AddRange(l2);
        }

        public static List<ValueAndID> InvoiceTypesList = new List<ValueAndID>() {
                new ValueAndID() { ID = (int)InvoiceType.Purchase , Name  ="مشتريات" },
                new ValueAndID() { ID = (int)InvoiceType.Sales  , Name  ="مبيعات" },
                new ValueAndID() { ID = (int)InvoiceType.PurchaseReturn  , Name  ="مردود مشتريات" },
                new ValueAndID() { ID = (int)InvoiceType.SalesReturn  , Name  ="مردود مبيعات" },
        };
        public static List<ValueAndID> EntryTypesList = new List<ValueAndID>() {
                new ValueAndID() { ID = (byte)EntryType.EntryVoucher, Name = "سند صرف",},
                new ValueAndID() { ID = (byte)EntryType.DailyEntry  , Name  ="قيد يومي" },
                new ValueAndID() { ID = (byte)EntryType.EntryReceipt  , Name  ="سند قبض" },
        };
        public static string EntryStatus(byte type) => EntryTypesList.FirstOrDefault(x => (byte)x.ID == type).Name;
        public static string EntryPayMethodType(byte type) =>Program.My_Setting.LangEng? type == 1 ? "Cash" : "Card" : type ==1?"نقدا":"شبكة";
        public static List<ValueAndID> ReadModeList = new List<ValueAndID>() {
                new ValueAndID() { ID =  (byte)ReadModeType.Price, Name  ="سعر" },
                new ValueAndID() { ID =  (byte)ReadModeType.Weight, Name  ="وزن" }

        };
      
        public static List<ValueAndID> PrintModeList = new List<ValueAndID>() {
                new ValueAndID() { ID =  (byte)PrintMode.Direct, Name  ="طباعة مباشرة" },
                new ValueAndID() { ID =  (byte)PrintMode.ShowPreview, Name  ="استعراض قبل الطباعه" }
        }; 
        public static List<ValueAndID> PrintFileModeList = new List<ValueAndID>() {
                new ValueAndID() { ID =  (byte)PrintMode.Direct, Name  ="حفظ الملف مباشرة" },
                new ValueAndID() { ID =  (byte)PrintMode.ShowPreview, Name  ="السماح بتحديد مسار الحفظ" }
        };

        public static List<ValueAndID> PrintPaperList = new List<ValueAndID>() {
                new ValueAndID() { ID =  (byte)PrintPaperType.Cashier, Name  ="كاشير" },
                new ValueAndID() { ID =  (byte)PrintPaperType.A4, Name  ="A4" }
        };
       
        public static List<ValueAndID> PayMethodsList = new List<ValueAndID>() {
                new ValueAndID() { ID = (byte)PayMethods.Cash , Name  ="نقدي" },
                new ValueAndID() { ID = (byte)PayMethods.Credit , Name  ="اجل" },
                //new ValueAndID() { ID = (byte)PayMethods.Carde , Name  ="شبكه" }
        };
        public static List<ValueAndID> PrintFileTypeList = new List<ValueAndID>() {
                new ValueAndID() { ID = (byte)PrintFileType.Printer , Name  ="طباعة" },
                new ValueAndID() { ID = (byte)PrintFileType.PDF , Name  ="PDF" },
                new ValueAndID() { ID = (byte)PrintFileType.Xlsx , Name  ="Xlsx" }
        }; 

        public static List<ValueAndID> UserTypeList = new List<ValueAndID>() {
                new ValueAndID() { ID = (int)UserType.Admin , Name  ="مدير نظام" },
                new ValueAndID() { ID = (int)UserType.User  , Name  ="دخول مخصص" }
        };
     
        public static List<ValueAndID> LanguagList = new List<ValueAndID>() {
                new ValueAndID() { ID = (byte)LanguagType.Arabic , Name  ="عربي" },
                new ValueAndID() { ID = (byte)LanguagType.English  , Name  ="English" }
        };

        

        public static List<ValueAndID> WarningLevelsList = new List<ValueAndID>() {
                new ValueAndID() { ID = (short)WarningLevels.DoNotEnteript  , Name  ="عدم التداخل" },
                new ValueAndID() { ID = (short)WarningLevels.ShowWarning  , Name  ="تحذير" },
                new ValueAndID() { ID = (short)WarningLevels.Prevent  , Name  ="منع" },
        };

     
        public static int FindRowHandelByRowObject(this GridView view, object row)
        {
            if (row != null)
            {
                for (int i = 0; i < view.DataRowCount; i++)
                {
                    if (row.Equals(view.GetRow(i)))
                        return i;
                }
            }
            return DevExpress.XtraGrid.GridControl.InvalidRowHandle;
        }
        public static bool IsTextVailde(this TextEdit txt)
        {
            if (txt.Text.Trim() == string.Empty)
            {
                //txt.ErrorText = frm_Master.ErrorText;
                return false;
            }
            return true;
        }
        public static bool IsEditValueValid(this LookUpEditBase lkp)
        {
            if (lkp.IsEditValueOfTypeInt() == false)
            {
                //lkp.ErrorText = frm_Master.ErrorText;
                return false;
            }
            return true;
        }

        public static bool IsEditValueValidAndNotZero(this LookUpEditBase lkp)
        {
            if (lkp.IsEditValueOfTypeInt() == false || Convert.ToInt32(lkp.EditValue) == 0)
            {
                //lkp.ErrorText = frm_Master.ErrorText;
                return false;
            }
            return true;
        }
        public static bool IsDateVailde(this DateEdit dt)
        {
            if (dt.DateTime.Year < 1950)
            {
                //dt.ErrorText = frm_Master.ErrorText;
                return false;
            }
            return true;
        }
        public static bool IsEditValueOfTypeInt(this LookUpEditBase edit)
        {
            var val = edit.EditValue;
            return (val is int || val is byte);
        }
        public static string GetNextNumberInString(string Number)
        {
            if (Number == string.Empty || Number == null)
                return "1";
            string str1 = "";
            foreach (Char c in Number)
                str1 = char.IsDigit(c) ? str1 + c.ToString() : "";
            if (str1 == string.Empty)
                return Number + "1";
            string str2 = str1.Insert(0, "1");
            str2 = (Convert.ToInt64(str2) + 1).ToString();
            string str3 = str2[0] == '1' ? str2.Remove(0, 1) : str2.Remove(0, 1).Insert(0, "1");
            int indx = Number.LastIndexOf(str1);
            Number = Number.Remove(indx);
            Number = Number.Insert(indx, str3);
            return Number;

        }
        public static T FromByteArray<T>(byte[] data)
        {
            if (data == null)
                return default(T);
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream(data))
            {
                object obj = formatter.Deserialize(stream);
                return (T)obj;
                //return  (T)formatter.Deserialize(stream);
            };
        }
        public static byte[] ToByteArray<T>(T obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, obj);
                return stream.ToArray();
            };
        }

        public static string GetCallerName([CallerMemberName] string callerName = "")
        {
            return callerName;
        }
    }
}
