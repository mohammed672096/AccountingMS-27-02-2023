using System;
using System.Windows.Forms;

namespace PosFinalCost.Forms
{
    public partial class FormSetCashInvoice : Form
    {

        public decimal Paid
        {
            get { return spinEditPaid.Value; }
            set { spinEditPaid.Value = value; }
        }
        public decimal UnPaid
        {
            get { return spinEditUnPaid.Value; }
            set { spinEditUnPaid.Value = value; }
        }
        public decimal Net
        {
            get { return spinEditNet.Value; }
            set { spinEditNet.Value = value; }
        }
        public bool IsEscape { get; set; }

        public FormSetCashInvoice()
        {
            InitializeComponent();
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                simpleButton2_Click(null, null);
            else if (keyData == Keys.Enter)
                simpleButton1_Click(null, null);

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void FormSetCashInvoice_Load(object sender, EventArgs e)
        {
            Paid = Net;
        }

        private void spinEditPaid_EditValueChanged(object sender, EventArgs e)
        {
            UnPaid = Paid - Net;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Paid = 0;
            IsEscape = true;
            Close();

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
