using DevExpress.LookAndFeel;
using DevExpress.XtraLayout.Utils;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace PosFinalCost.Forms
{
    public partial class formPurchaseSaleShortcuts : DevExpress.XtraEditors.XtraForm
    {
        private readonly dynamic _form;
        private byte type;
        private int rowHandle;

        public formPurchaseSaleShortcuts(dynamic form, byte type, int rowHandle, double quantity = 0, decimal price = 0)
        {
            SetLanguage();
            InitializeComponent();
            InitButtonsLayout();
            _form = form;

            this.type = type;
            this.rowHandle = rowHandle;

            if (type == 1)
                InitQuantityData(quantity);
            else
                InitPriceData(price);
        }

        private void InitButtonsLayout()
        {
            btnSave.LookAndFeel.UseDefaultLookAndFeel = false;
            btnSave.LookAndFeel.Style = LookAndFeelStyle.UltraFlat;
            btnSave.StyleController = null;
            btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            btnCancel.LookAndFeel.Style = LookAndFeelStyle.UltraFlat;
            btnCancel.StyleController = null;
        }

        private void InitQuantityData(double quantity)
        {
            itemForQuantity.Visibility = LayoutVisibility.Always;
            textEditQuantity.EditValue = quantity;
            textEditQuantity.Focus();
        }

        private void InitPriceData(decimal price)
        {
            itemForPrice.Visibility = LayoutVisibility.Always;
            textEditPrice.EditValue = price;
            textEditPrice.Focus();
        }

        private void UpdateData()
        {
            this.Close();

            if (this.type == 1)
                _form.SetProductQunatity(this.rowHandle, Convert.ToDouble(textEditQuantity.EditValue));
            else
                _form.SetProductPrice(this.rowHandle, Convert.ToDouble(textEditPrice.EditValue));
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void formPurchaseSaleShortcuts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                UpdateData();
            else if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void SetLanguage()
        {
            if (!Program.My_Setting.LangEng)
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
            else
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}