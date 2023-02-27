using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace AccountingMS
{
    class ClsXtraMssgBox
    {
        public static DialogResult ShowError(string mssg)
        {
            ClsThreadCulture.ChangeCultureDefault();
            return XtraMessageBox.Show(mssg, (!MySetting.GetPrivateSetting.LangEng) ? "خطاء" : "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowQuesPrint(string mssg)
        {
            ClsThreadCulture.ChangeCultureDefault();
            return XtraMessageBox.Show(mssg, (!MySetting.GetPrivateSetting.LangEng) ? "طباعة" : "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult ShowErrorYesNo(string mssg)
        {
            ClsThreadCulture.ChangeCultureDefault();
            return XtraMessageBox.Show(mssg, (!MySetting.GetPrivateSetting.LangEng) ? "خطاء" : "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
        }

        public static DialogResult ShowWarningYesNo(string mssg)
        {
            ClsThreadCulture.ChangeCultureDefault();
            return XtraMessageBox.Show(mssg, (!MySetting.GetPrivateSetting.LangEng) ? "تنبيه" : "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
        }

        public static DialogResult ShowWarning(string mssg)
        {
            ClsThreadCulture.ChangeCultureDefault();
            return XtraMessageBox.Show(mssg, (!MySetting.GetPrivateSetting.LangEng) ? "تنبيه" : "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
