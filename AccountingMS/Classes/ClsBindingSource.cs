using System.Windows.Forms;

namespace AccountingMS
{
    public static class ClsBindingSource
    {
        public static bool Validate(BindingSource bindingSource)
        {
            if (bindingSource.Count >= 1) return true;

            ClsXtraMssgBox.ShowError("عذرا لا يوجد بيانات!");
            return false;
        }
    }
}
