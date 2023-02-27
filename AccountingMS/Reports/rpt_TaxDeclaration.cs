using DevExpress.XtraEditors;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace AccountingMS
{
    public partial class rpt_TaxDeclaration : XtraReport
    {

        accountingEntities db = new accountingEntities();
        ClsTblBranch TblBranch = new ClsTblBranch();
        public rpt_TaxDeclaration()
        {
            SetLanguage();
            InitializeComponent();
            SetRTL();
            new ClsReportHeaderData(this);
        }
        
        private void ReportPurchases_ParametersRequestBeforeShow(object sender, ParametersRequestEventArgs e)
        {
            foreach (ParameterInfo info in e.ParametersInformation)
            {
                if (info.Parameter.Name == "TaxDeclrationID")
                {
                    List<Declaration> data=new List<Declaration>();
                    foreach (var item in db.TaxDeclarations.Select(x =>new {x.ID, x.Code, x.BranchID }).ToList())
                    {
                        if (Session.CurrentUser.id != 1 && (item.BranchID != Session.CurBranch.brnId && item.BranchID != null && item.BranchID != 0)) continue;
                           data.Add(new Declaration{id= item.ID,
                           NOAndBranch= item.Code + " - " + (item.BranchID == null || item.BranchID == 0 ? "كل الفروع" : TblBranch.GetBranchName(item.BranchID.Value)) });
                    }
                    bindingSource1.DataSource =data;
                }
            }
        }
        class Declaration
        {
            public int id { get; set; }
            public string NOAndBranch { get; set; }
        }
        private void ReportPurchases_ParametersRequestSubmit(object sender, ParametersRequestEventArgs e)
        {
            InitData();
        }

        private void InitData()
        {
            var id = Convert.ToInt32(TaxDeclrationID.Value);
            objectDataSource1.DataSource = db.TaxDeclarations.Where(x => x.ID == id).FirstOrDefault();

        }

        private void SetLanguage()
        {
            if (!MySetting.GetPrivateSetting.LangEng) Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
            else Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
        }

        private void SetRTL()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.No;
            this.RightToLeftLayout = RightToLeftLayout.No;
        }
    }
}
