using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Hassib.Common;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using AccountingMS;
using DevExpress.XtraEditors.Controls;

namespace AccountingMS
{
    public partial class SalaryExtensionView : MasterView
    {

        private static SalaryExtensionView instance;
        public static SalaryExtensionView Instance { get { if (instance == null || instance.IsDisposed == true) instance = new SalaryExtensionView(); return instance; } }


        accountingEntities context;
        public SalaryExtension Extension { get =>salaryExtensionBindingSource.Current as SalaryExtension; set => salaryExtensionBindingSource.DataSource = value; }

        public SalaryExtensionView()
        {
            InitializeComponent();
            DisableValidation(dataLayoutControl1);
            context = new accountingEntities();
            tblCurrencyBindingSource.DataSource = context.tblCurrencies.ToList();
            gridView1.AddEditButton(RepositoryItemButtonEdit1_Click);
            gridView1.SetAlternatingColors();
            this.Shown += SalaryExtensionView_Shown;
        }
        //public RadioGroupItem[] calculationMethod ={
        //        new RadioGroupItem() { Value = (int)DiscountType.OnProduct  , Description  =(MySetting.GetPrivateSetting.LangEng)?"merit":"استحقاق" },
        //        new RadioGroupItem() { Value = (int)DiscountType.OnInvoice  , Description  =(MySetting.GetPrivateSetting.LangEng)?"subtraction":"استقطاع" },

        //};

        private void SalaryExtensionView_Shown(object sender, EventArgs e)
        {
            if (Extension == null)
                New();
        }


        private void RepositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            SalaryExtension row = gridView1.GetRow(gridView1.FocusedRowHandle) as SalaryExtension;
            if (row != null)
                GoTo(row.id);
        }
        public void GoTo(int id)
        {
            var sourceDepr = context.SalaryExtensions.SingleOrDefault(x => x.id == id);
            if (sourceDepr != null)
            {
                Extension = sourceDepr;
                DataChanged = false;
                IsNew = false;
            }
            else
            {
                XtraMessageBox.Show("المستند غير موجود ");
            }
        }

        public override void New()
        {
            Extension = new SalaryExtension() { };
            base.New();
        }

        void SetExtension()
        {

            Extension.name = nameTextEdit.Text ;
            Extension.CalculationType = CalculationTypeTextEdit.EditValue.ToString();
            Extension.Status = StatusTextEdit.EditValue.ToString();
            Extension.MainAccount = Convert.ToInt32(MainAccountTextEdit.EditValue);

        }
        public override void Save()
        {
            //EnableValidation(dataLayoutControl1);
            //if (this.ValidateChildren() == false)
            //    return;
            //DisableValidation(dataLayoutControl1);
            SetExtension();
            context.SalaryExtensions.AddOrUpdate(Extension);
            context.SaveChanges();
            base.Save();
            RefreshData();
        }
        public override void RefreshData()
        {
            gridControl1.DataSource = context.SalaryExtensions.ToList();
            base.RefreshData();
        }
        public override void Delete()
        {
            context.SalaryExtensions.Remove(Extension);
            context.SaveChanges();
            base.Delete();
            New();
            RefreshData();
        }

        private void SalaryExtensionView_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            //CalculationTypeImageComboBoxEdit.Properties.Items.AddRange(calculationMethod);
            //CalculationTypeImageComboBoxEdit.SelectedIndex = 0;
        }
    }
}
