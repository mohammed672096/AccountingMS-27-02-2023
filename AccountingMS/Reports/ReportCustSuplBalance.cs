using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    public partial class ReportCustomerSupplierBalance : XtraReport
    {
        ClsTblCustomer clsTbCustomer;
        ClsTblSupplier clsTbSupplier;
        ReportCustomerSupplierBalanceData rprtCustSuplBalanceData;

        private readonly byte status;
        private bool isGroupUnioun;

        public ReportCustomerSupplierBalance(byte status)
        {
            this.status = status;
            InitializeComponent();
            InitData();
            InitObjects();
            InitSupReport();
            InitDefaultData();
        }

        private void InitDefaultData()
        {
            new ClsReportHeaderData(this);
            parameterDtStart.Value = DateTime.Now.Date;
            parameterDtEnd.Value = Session.CurrentYear.fyDateEnd;
            xrtcDate.Text += string.Format((!MySetting.GetPrivateSetting.LangEng) ? $"{DateTime.Now:yyyy/MM/dd}" : $"{DateTime.Now:dd/MM/yyyy}");
        }

        private void InitObjects()
        {
            if (this.status == 1) this.clsTbCustomer = new ClsTblCustomer();
            else this.clsTbSupplier = new ClsTblSupplier();
        }

        private void InitData()
        {
            if (this.status == 1) InitCustomerParameter();
            else InitSupplier();
        }

        private void InitSupplier()
        {
            SetSupplierHeaderText();
            InitSupplierParameter();
            SetSupplierProperties();
        }

        private void SetSupplierProperties()
        {
            parameterShowProfit.Visible = false;
            parameterShowCustDetail.Description = "بيانات المورد :";
        }

        private void InitSupReport()
        {
            this.rprtCustSuplBalanceData = new ReportCustomerSupplierBalanceData(this.status, this.clsTbCustomer, this.clsTbSupplier);
            xrSubreportCustSuplBalanceData.ReportSource = this.rprtCustSuplBalanceData;
            xrSubreportCustSuplBalanceData.ParameterBindings.Add(new ParameterBinding("parameterDtStart", parameterDtStart));
            xrSubreportCustSuplBalanceData.ParameterBindings.Add(new ParameterBinding("parameterDtEnd", parameterDtEnd));
            xrSubreportCustSuplBalanceData.ParameterBindings.Add(new ParameterBinding("parameterCash", parameterCash));
            xrSubreportCustSuplBalanceData.ParameterBindings.Add(new ParameterBinding("parameterShowInvoice", parameterShowInvoice));
            xrSubreportCustSuplBalanceData.ParameterBindings.Add(new ParameterBinding("parameterInvoiceDetail", parameterInvoiceDetail));
            xrSubreportCustSuplBalanceData.ParameterBindings.Add(new ParameterBinding("parameterShowCustDetail", parameterShowCustDetail));
            xrSubreportCustSuplBalanceData.ParameterBindings.Add(new ParameterBinding("parameterShowProfit", parameterShowProfit));
            xrSubreportCustSuplBalanceData.ParameterBindings.Add(new ParameterBinding("parameterShowEntry", parameterShowEntry));
            xrSubreportCustSuplBalanceData.ParameterBindings.Add(new ParameterBinding("parameterCombineSupNdEnt", parameterCombineSupNdEnt));
            xrSubreportCustSuplBalanceData.ParameterBindings.Add(new ParameterBinding("parameterAccId", tblAccountBindingSource, "id"));
            xrSubreportCustSuplBalanceData.ParameterBindings.Add(new ParameterBinding("parameterAccNo", tblAccountBindingSource, "accNo"));
        }

        private void ReportCustomerSupplierBalance_ParametersRequestSubmit(object sender, ParametersRequestEventArgs e)
        {
            this.isGroupUnioun = Convert.ToBoolean(parameterGroupUnioun.Value);

            InitRprtData();
            InitGroupUniuon();
        }

        private void InitRprtData()
        {
            var tbAccountList = new List<tblAccount>();
            if (parameterAccId != null) foreach (var accId in (int[])parameterAccId.Value)
                    tbAccountList.Add(InitAccountData(accId));

            tblAccountBindingSource.DataSource = tbAccountList;
        }

        private void InitGroupUniuon()
        {
            Detail.PageBreak = (this.isGroupUnioun) ? PageBreak.None : PageBreak.AfterBand;
        }

        private tblAccount InitAccountData(int accId) => this.status switch
        {
            1 => InitCustomer(accId),
            2 => InitSupplierData(accId),
            _ => null
        };

        private tblAccount InitCustomer(int accId)
        {
            var tbCustomer = this.clsTbCustomer.GetCustomerObjById(accId);
            return new tblAccount()
            {
                id = accId,
                accNo = tbCustomer.custAccNo,
                accName = tbCustomer.custAccName
            };
        }

        private tblAccount InitSupplierData(int accId)
        {
            var tbSupplier = this.clsTbSupplier.GetSupplierObjById(accId);
            return new tblAccount()
            {
                id = accId,
                accNo = tbSupplier.splAccNo,
                accName = tbSupplier.splName
            };
        }

        private void SetSupplierHeaderText()
        {
            xrlHeader.Text = (!MySetting.GetPrivateSetting.LangEng) ? "تقرير أرصدة الموردين" : "Suppliers Balance Report";
            xrtcBalanceName.Text = (!MySetting.GetPrivateSetting.LangEng) ? "كشف رصيد المورد :" : "Supplier Balance Statement";
        }

        private void InitCustomerParameter()
        {
            this.clsTbCustomer = new ClsTblCustomer();

            DynamicListLookUpSettings listLookUpSettings = new DynamicListLookUpSettings
            {
                DataSource = this.clsTbCustomer.GetCustomersList().OrderBy(x => x.custName).ToList(),
                ValueMember = "id",
                DisplayMember = "custName"
            };
            parameterAccId.LookUpSettings = listLookUpSettings;
        }

        private void InitSupplierParameter()
        {
            this.clsTbSupplier = new ClsTblSupplier();

            DynamicListLookUpSettings listLookUpSettings = new DynamicListLookUpSettings
            {
                DataSource = this.clsTbSupplier.GetSuppliersList(),
                ValueMember = "id",
                DisplayMember = "splName"
            };
            parameterAccId.LookUpSettings = listLookUpSettings;
            parameterAccId.Description = (!MySetting.GetPrivateSetting.LangEng) ? "المورد :" : "Supplier :";
        }
    }
}
