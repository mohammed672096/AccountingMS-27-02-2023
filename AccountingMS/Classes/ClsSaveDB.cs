using DevExpress.XtraEditors;
using System;
using System.Data.Entity.Validation;
using System.Linq;

namespace AccountingMS
{
    public class ClsSaveDB
    {
        public static bool Save(accountingEntities db, log4net.ILog log)
        {
            ClsThreadCulture.ChangeCultureEn();
            try
            {
                db.SaveChanges();
                ClsThreadCulture.ChangeCultureDefault();
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                var fullErrorMessage = string.Join("; ", errorMessages);
                var newMessage = string.Concat(ex.Message, "\n  The validation errors are: ", fullErrorMessage);
                log.Error($"StartClsSaveDBException Date : {DateTime.Now:dd-MM-yyyy HH:mm:ss} \n  {newMessage} \nEndClsSaveDBException Date : {DateTime.Now:dd-MM-yyyy HH:mm:ss} \n");
                Console.WriteLine($"StartClsSaveDBException Date : {DateTime.Now:dd-MM-yyyy HH:mm:ss} \n  {newMessage} \nEndClsSaveDBException Date : {DateTime.Now:dd-MM-yyyy HH:mm:ss} \n");
                
                ClsThreadCulture.ChangeCultureDefault();
                XtraMessageBox.Show("عذرا حدث خطاء في حفظ البيانات! يرجى مراجعة قسم الصيانة.");
                return false;
            }
        }
    }
}
