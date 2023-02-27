using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PosFinalCost.Classe;

namespace PosFinalCost.Forms
{
    public partial class FormAddCustomer : DevExpress.XtraEditors.XtraForm
    {
        public FormAddCustomer()
        {
            InitializeComponent();
            this.Load += XtraFormAddCustomer_Load;
        }
        private void InitCustSalePrice()
        {
            custSalePriceTextEdit.Properties.DataSource = ((!Program.My_Setting.LangEng) ? typeof(SalePriceAr) : typeof(SalePriceEn)).ToListEnum();
            custSalePriceTextEdit.Properties.DisplayMember = "Value";
            custSalePriceTextEdit.Properties.ValueMember = "Key";
            custSalePriceTextEdit.Properties.ShowHeader = false;
        }
        public Customer Cus;
        private void XtraFormAddCustomer_Load(object sender, EventArgs e)
        {
            custCurrencyTextEdit.IntializeData(Session.Currencies);
            cusBankIdTextEdit.IntializeData(Session.Banks);
            custCountryTextEdit.Properties.DataSource = Session.Countries;
            custCountryEnTextEdit.Properties.DataSource = Session.Countries;
            InitCustSalePrice();
            customerBindingSource.DataSource = new Customer()
            {
                BrnId = Session.CurrentBranch.ID,
                Currency = Session.LocalCurrency.ID,
            };
        }
        bool IsDataValid()
        {
            if (custNameTextEdit.Text.Trim() == string.Empty)
            {
                custNameTextEdit.ErrorText = "هذا الحقل مطلوب";
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Cus = customerBindingSource.Current as Customer;
            if (IsDataValid() == false)
                return;
            using (var db = new PosDBDataContext(Program.ConnectionString))
            {
                db.Customers.InsertOnSubmit(Cus);
                if (Program.My_Setting.SendCustomerToServerOnSave)
                    new UploadDataToMain().SendCustomerToServer(Cus);
                db.SubmitChanges();
                if (!Session.Customers.Any(v => v.ID == Cus.ID & v.BrnId == Cus.BrnId))
                    Session.Customers.Add(Cus);
            }
            Close();
        }

    }
}