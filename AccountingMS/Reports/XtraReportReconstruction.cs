﻿using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace AccountingMS.Reports
{
    public partial class XtraReportReconstruction : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportReconstruction()
        {
            InitializeComponent();

            new ClsReportHeaderData(this);
        }

    }
}
