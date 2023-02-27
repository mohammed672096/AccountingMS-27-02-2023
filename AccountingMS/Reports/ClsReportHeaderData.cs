using DevExpress.XtraReports.UI;
using System;
using System.Drawing;
using System.IO;

namespace AccountingMS
{
    class ClsReportHeaderData
    {
        private readonly dynamic report;

        public ClsReportHeaderData(XtraReport xrReport)
        {
            this.report = xrReport;
            InitBranchData();
            HideFooterLabels();
        }

        private void InitBranchData()
        {
            tblBranch tbBranch = new ClsTblBranch().GetBranchDataById(Session.CurBranch.brnId);

            this.report.xrLabelBranchName.Text = tbBranch.brnName;
            this.report.xrLabelBranchNameEn.Text = tbBranch.brnNameEn;
            this.report.xrLabelBranchAddress.Text = tbBranch.brnAddress;
            this.report.xrLabelBranchAddressEn.Text = tbBranch.brnAddressEn;
            this.report.xrLabelBranchPhnNo1.Text = "رقم التلفون : " + tbBranch.brnPhnNo;
            this.report.xrLabelBranchPhnNo2.Text = "Phone No. : " + tbBranch.brnPhnNo;
            this.report.xrLabelBranchFaxNo1.Text = "رقم الفاكس : " + tbBranch.brnFaxNo;
            this.report.xrLabelBranchFaxNo2.Text = "Fax No. : " + tbBranch.brnFaxNo;
            this.report.xrLabelBranchMailBox1.Text = "الرقم الضريبي : " + tbBranch.brnTaxNo;
            this.report.xrLabelBranchMailBox2.Text = "Tax No. : " + tbBranch.brnTaxNo;

            try
            {

                this.report.TopMargin.HeightF += 25;
                XRLabel xrLabelBranchTrade1 = new XRLabel();
                XRLabel xrLabelBranchTrade2 = new XRLabel();
                xrLabelBranchTrade1.AutoWidth = true;
                xrLabelBranchTrade2.AutoWidth = true;

                xrLabelBranchTrade1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
                xrLabelBranchTrade2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
                xrLabelBranchTrade1.WordWrap = false;
                xrLabelBranchTrade2.WordWrap = false;

                xrLabelBranchTrade2.Text = "Trad No. : " + tbBranch.brnTradeNo;
                xrLabelBranchTrade1.Text = "السجل التجاري. : " + tbBranch.brnTradeNo;


                this.report.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[]
                { xrLabelBranchTrade1  , xrLabelBranchTrade2 });

                xrLabelBranchTrade2.LocationF = new PointF(this.report.xrLabelBranchMailBox2.LocationF.X, this.report.xrLabelBranchMailBox2.LocationF.Y + 25);
                xrLabelBranchTrade1.LocationF = new PointF(this.report.xrLabelBranchMailBox1.LocationF.X, this.report.xrLabelBranchMailBox1.LocationF.Y + 25);
                this.report.xrLine5.LocationF = new PointF(this.report.xrLine5.LocationF.X, this.report.xrLine5.LocationF.Y + 25);

            }
            catch (Exception)
            {

         //       throw;
            }




            LoadImage();
            SetLabelsVisibility(tbBranch);
        }

    
        private void LoadImage()
        {
            this.report.xrPictureBoxBranch.Image = new ClsTblBranchImg().GetBitmapLogImage();
        }

        private void SetLabelsVisibility(tblBranch tbBranch)
        {
            this.report.xrLabelBranchName.Visible = (!string.IsNullOrWhiteSpace(tbBranch.brnName)) ? true : false;
            this.report.xrLabelBranchNameEn.Visible = (!string.IsNullOrWhiteSpace(tbBranch.brnNameEn)) ? true : false;
            this.report.xrLabelBranchAddress.Visible = (!string.IsNullOrWhiteSpace(tbBranch.brnAddress)) ? true : false;
            this.report.xrLabelBranchAddressEn.Visible = (!string.IsNullOrWhiteSpace(tbBranch.brnAddressEn)) ? true : false;
            this.report.xrLabelBranchPhnNo1.Visible = (!string.IsNullOrWhiteSpace(tbBranch.brnPhnNo)) ? true : false;
            this.report.xrLabelBranchPhnNo2.Visible = (!string.IsNullOrWhiteSpace(tbBranch.brnPhnNo)) ? true : false;
            this.report.xrLabelBranchFaxNo1.Visible = (!string.IsNullOrWhiteSpace(tbBranch.brnFaxNo)) ? true : false;
            this.report.xrLabelBranchFaxNo2.Visible = (!string.IsNullOrWhiteSpace(tbBranch.brnFaxNo)) ? true : false;
            this.report.xrLabelBranchMailBox1.Visible = (!string.IsNullOrWhiteSpace(tbBranch.brnTaxNo)) ? true : false;
            this.report.xrLabelBranchMailBox2.Visible = (!string.IsNullOrWhiteSpace(tbBranch.brnTaxNo)) ? true : false;
        }

        private void HideFooterLabels()
        {
            try
            {
                this.report.xrLabel16.Visible = false;
                this.report.xrLabel22.Visible = false;
                this.report.xrPictureBox1.Visible = false;
            }
            catch (Exception)
            {

            }
        }
    }
}