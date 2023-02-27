using System;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formSupplyPricrTrans : DevExpress.XtraEditors.XtraForm
    {
        public decimal Price { get; set; }

        public formSupplyPricrTrans()
        {
            InitializeComponent();
            this.Load += FormSupplyPricrTrans_Load;
        }

        private void FormSupplyPricrTrans_Load(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PerformAction();
        }

        private void PerformAction()
        {
            if (!dxValidationProvider1.Validate()) return;

            CalculatePrice();

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CalculatePrice()
        {
            this.Price = Convert.ToDecimal(textEditPrice.EditValue) / Convert.ToDecimal(textEditQuan.EditValue);
        }

        private void formSupplyPricrTrans_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            PerformAction();
        }
    }
}