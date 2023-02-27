using AccountingMS.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraLayout.Utils;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formPurchaseSaleShortcuts : DevExpress.XtraEditors.XtraForm
    {
        private byte type;
        private int rowHandle;
        UC_AddSaleInvoice userCo;
        public formPurchaseSaleShortcuts(UC_AddSaleInvoice userControl, byte type, int rowHandle, double quantity = 0, double price = 0)
        {
            SetLanguage();
            InitializeComponent();
            InitButtonsLayout();
            userCo = userControl;

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

        private void InitPriceData(double price)
        {
            itemForPrice.Visibility = LayoutVisibility.Always;
            textEditPrice.EditValue = price;
            textEditPrice.Focus();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (userCo != null)
            {
                this.Close();
                if (this.type == 1)
                    userCo.SetProductQunatity(this.rowHandle, Convert.ToDouble(textEditQuantity.EditValue));
                else
                    userCo.SetProductPrice(this.rowHandle, Convert.ToDouble(textEditPrice.EditValue));
            }
        }

        private void formPurchaseSaleShortcuts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (userCo != null)
                {
                    this.Close();
                    if (this.type == 1)
                        userCo.SetProductQunatity(this.rowHandle, Convert.ToDouble(textEditQuantity.EditValue));
                    else
                        userCo.SetProductPrice(this.rowHandle, Convert.ToDouble(textEditPrice.EditValue));
                }
            }
            else if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void SetLanguage()
        {
            if (!MySetting.GetPrivateSetting.LangEng)
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
            else
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}