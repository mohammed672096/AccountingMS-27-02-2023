using DevExpress.Data;
using DevExpress.Data.Linq.Helpers;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraReports.UI;
using System;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;

namespace AccountingMS.Forms
{
    public partial class frm_TrialBalance : XtraForm
    {
        public frm_TrialBalance()
        {
            InitializeComponent();
        }


        //void RefreshData()
        //{
        //    if (dateEdit1.DateTime.Year < 1950)
        //        dateEdit1.ErrorText = "*";
        //    if (dateEdit2.DateTime.Year < 1950)
        //        dateEdit2.ErrorText = "*";
        //    if (dateEdit2.DateTime.Year < 1950 || dateEdit1.DateTime.Year < 1950)
        //        return;
        //    using (var db = new accountingEntities())
        //    {
        //        //var BeforeEntries = db.tblEntrySubs.Where(x => DbFunctions.TruncateTime(x.entDate.Value) < dateEdit1.DateTime.Date);
        //        //var TransEntries = db.tblEntrySubs
        //        //    .Where(x => DbFunctions.TruncateTime(x.entDate.Value) >= dateEdit1.DateTime.Date &&
        //        //               DbFunctions.TruncateTime(x.entDate.Value) <= dateEdit2.DateTime.Date);
        //        //var testQ1 = from be in BeforeEntries
        //        //             group be by be.entAccNo into g
        //        //             select new
        //        //             {
        //        //                 ID = g.Key,
        //        //                 Credit = 0D,
        //        //                 Debit = 0D,
        //        //                 BeforeCredit = g.Sum(x => (double?)x.entCredit) ?? 0,
        //        //                 BeforeDebit = g.Sum(x => (double?)x.entDebit) ?? 00,
        //        //             };
        //        var BeforeEntries = db.tblAssets.Where(x => DbFunctions.TruncateTime(x.asDate.Value) < dateEdit1.DateTime.Date);
        //        var TransEntries = db.tblAssets
        //            .Where(x => DbFunctions.TruncateTime(x.asDate.Value) >= dateEdit1.DateTime.Date &&
        //                       DbFunctions.TruncateTime(x.asDate.Value) <= dateEdit2.DateTime.Date);
        //        var testQ1 = from be in BeforeEntries
        //                     group be by be.asAccNo into g
        //                     select new
        //                     {
        //                         ID = g.Key,
        //                         Credit = 0D,
        //                         Debit = 0D,
        //                         BeforeCredit = g.Sum(x => (double?)x.asCredit) ?? 0,
        //                         BeforeDebit = g.Sum(x => (double?)x.asDebit) ?? 00,
        //                     };
        //        var testQ2 = from be in TransEntries
        //                     group be by be.asAccNo into g
        //                     select new
        //                     {
        //                         ID = g.Key,
        //                         Credit = g.Sum(x => (double?)x.asCredit) ?? 0,
        //                         Debit = g.Sum(x => (double?)x.asDebit) ?? 0,
        //                         BeforeCredit = 0D,
        //                         BeforeDebit = 0D,
        //                     };
        //        // testQ1 = testQ1.Concat(testQ2);

        //        var testQ3 = (from t1 in testQ2.ToList()
        //                      group t1 by t1.ID into g
        //                      select new
        //                      {
        //                          ID = g.Key,
        //                          IsParent = false,
        //                          Credit = g.Sum(x => x.Credit),
        //                          Debit = g.Sum(x => x.Debit),
        //                          BeforeCredit = g.Sum(x => x.BeforeCredit),
        //                          BeforeDebit = g.Sum(x => x.BeforeDebit),
        //                      }).ToList();
        //        var ParentAccounts = db.tblAccounts.Select(x => x.accNo).ToList().Where(pa => testQ3.Select(x => x.ID).Contains(pa) == false).ToList();
        //        var testQ4 = (from be in ParentAccounts
        //                      select new
        //                      {
        //                          ID = be,
        //                          IsParent = true,
        //                          Credit = testQ3.AsEnumerable().Where(x => x.ID.ToString().StartsWith(be.ToString())).Sum(x => x.Credit),
        //                          Debit = testQ3.AsEnumerable().Where(x => x.ID.ToString().StartsWith(be.ToString())).Sum(x => x.Debit),
        //                          BeforeCredit = testQ3.AsEnumerable().Where(x => x.ID.ToString().StartsWith(be.ToString())).Sum(x => x.BeforeCredit),
        //                          BeforeDebit = testQ3.AsEnumerable().Where(x => x.ID.ToString().StartsWith(be.ToString())).Sum(x => x.BeforeDebit),
        //                      }).ToList();
        //        var accountsList = db.tblAccounts.Select(x => new { ID = x.accNo, ParentID = x.accParent, Name = x.accName, Level = x.accLevel }).ToList();
        //        testQ4.AddRange(testQ3);
        //        //  var query5 = from t in testQ4

        //        var query5 = from t in testQ4
        //                     from a in accountsList.Where(x => x.ID == t.ID).DefaultIfEmpty()
        //                     select new
        //                     {
        //                         ID = t.ID.ToString(),
        //                         Name = (a != null) ? (".".PadLeft(((a != null) ? a.Level : 0) * 2) + a.Name) : "# Account Is Missing  #",
        //                         level = (a != null) ? a.Level : 0,
        //                         t.IsParent,
        //                         Parent = (a != null) ? a.ParentID.Value : 0,
        //                         Level = (a != null) ? a.Level : 0,
        //                         Credit = Math.Round(t.Credit, 2),
        //                         Debit = Math.Round(t.Debit, 2),
        //                         BeforeCredit = Math.Round(t.BeforeCredit, 2),
        //                         BeforeDebit = Math.Round(t.BeforeDebit, 2),
        //                         TotalCredit = Math.Round(t.Credit + t.BeforeCredit, 2),
        //                         TotalDebit = Math.Round(t.Debit + t.BeforeDebit, 2),
        //                         BalanceCredit = Math.Round((t.Credit + t.BeforeCredit > t.Debit + t.BeforeDebit) ? Math.Abs((t.Credit + t.BeforeCredit) - (t.Debit + t.BeforeDebit)) : 0, 2),
        //                         BalanceDebit = Math.Round((t.Debit + t.BeforeDebit > t.Credit + t.BeforeCredit) ? Math.Abs((t.Debit + t.BeforeDebit) - (t.Credit + t.BeforeCredit)) : 0, 2)
        //                     };
        //        var data = query5.Where(x => x.BeforeCredit > 0 || x.BeforeDebit > 0 || x.Credit > 0 || x.Debit > 0).OrderBy(x => x.ID).ToList();



        //        var viewData = data.Where(x => x.level >= comboBoxEdit1.SelectedIndex + 1);
        //        viewData = viewData.Where(x => x.level <= comboBoxEdit2.SelectedIndex + 1);

        //        if (viewData.Count() == 0)
        //        {
        //            XtraMessageBox.Show("لا يوجد بيانات");
        //            return;

        //        }

        //        gridControl1.DataSource = viewData;


        //        var ChildsOnly = data.Where(x => x.IsParent == false);
        //        var sumCredit = ChildsOnly.Sum(x => (double?)x.Credit) ?? 0;
        //        var sumDebit = ChildsOnly.Sum(x => (double?)x.Debit) ?? 0;
        //        var sumBeforeCredit = ChildsOnly.Sum(x => (double?)x.BeforeCredit) ?? 0;
        //        var sumBeforeDebit = ChildsOnly.Sum(x => (double?)x.BeforeDebit) ?? 0;
        //        var sumTotalCredit = ChildsOnly.Sum(x => (double?)x.TotalCredit) ?? 0;
        //        var sumTotalDebit = ChildsOnly.Sum(x => (double?)x.TotalDebit) ?? 0;
        //        var sumBalanceCredit = ChildsOnly.Sum(x => (double?)x.BalanceCredit) ?? 0;
        //        var sumBalanceDebit = ChildsOnly.Sum(x => (double?)x.BalanceDebit) ?? 0;

        //        IsBeforeBalanced = Math.Abs(sumBeforeCredit - sumBeforeDebit) < 0.1;
        //        IsTranceBalaced = Math.Abs(sumCredit - sumDebit) < 0.1;
        //        IsTotalBalaced = Math.Abs(sumTotalDebit - sumTotalCredit) < 0.1;
        //        IsBalanceBalanced = Math.Abs(sumBalanceCredit - sumBalanceDebit) < 0.1;


        //        gridView1.Columns["Credit"]?.SummaryItem.SetSummary(SummaryItemType.Custom, sumCredit.ToString());
        //        gridView1.Columns["Debit"].SummaryItem.SetSummary(SummaryItemType.Custom, sumDebit.ToString());
        //        gridView1.Columns["BeforeCredit"].SummaryItem.SetSummary(SummaryItemType.Custom, sumBeforeCredit.ToString("{0:0.##}"));
        //        gridView1.Columns["BeforeDebit"].SummaryItem.SetSummary(SummaryItemType.Custom, sumBeforeDebit.ToString());
        //        gridView1.Columns["TotalCredit"].SummaryItem.SetSummary(SummaryItemType.Custom, sumTotalCredit.ToString());
        //        gridView1.Columns["TotalDebit"].SummaryItem.SetSummary(SummaryItemType.Custom, sumTotalDebit.ToString());
        //        gridView1.Columns["BalanceCredit"].SummaryItem.SetSummary(SummaryItemType.Custom, sumBalanceCredit.ToString());
        //        gridView1.Columns["BalanceDebit"].SummaryItem.SetSummary(SummaryItemType.Custom, sumBalanceDebit.ToString());

        //        PrintData = (new[] { new {
        //        IsBeforeBalanced,
        //        IsTranceBalaced,
        //        IsBalanceBalanced,
        //        Data = data .ToList()
        //        } }).ToList();
        //        //----------------- UI
        //        if (IsGridInitialized) return;
        //        IsGridInitialized = true;

        //        gridView1.OptionsView.ShowFooter = true;
        //        int i = 3;
        //        foreach (BandedGridColumn clm in gridView1.Columns)
        //        {
        //            if (clm.FieldName.Contains("Credit") || clm.FieldName.Contains("Debit"))
        //            {
        //                if (clm.FieldName.Contains("Credit"))
        //                    clm.Caption = "دائن";
        //                else if (clm.FieldName.Contains("Debit"))
        //                    clm.Caption = "مدين";

        //                clm.VisibleIndex = i++;
        //                clm.DisplayFormat.FormatString = "N2";
        //                clm.DisplayFormat.FormatType = FormatType.Numeric;
        //                //  clm.SummaryItem.DisplayFormat = "{0:n2}"; 
        //            }
        //        }
        //        gridView1.Appearance.BandPanel.Options.UseTextOptions = true;
        //        gridView1.Appearance.BandPanel.TextOptions.HAlignment = HorzAlignment.Center;
        //        gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
        //        gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;

        //        gridView1.OptionsBehavior.Editable = false;
        //        gridView1.OptionsBehavior.FocusLeaveOnTab = true;
        //        gridView1.OptionsNavigation.EnterMoveNextColumn = true;
        //        gridView1.OptionsView.EnableAppearanceEvenRow = true;
        //        gridView1.OptionsView.RowAutoHeight = true;
        //        gridView1.OptionsView.ShowAutoFilterRow = true;

        //        gridView1.OptionsView.ShowFooter = true;
        //        gridView1.OptionsView.ShowGroupPanel = false;
        //        //gridView1.ScrollStyle = ScrollStyleFlags.None;
        //        gridView1.Columns["ID"].Visible = false;
        //        gridView1.Columns["BeforeCredit"].Visible = false;
        //        gridView1.Columns["BeforeDebit"].Visible = false;
        //        gridView1.Columns["Name"].VisibleIndex = 1;
        //        gridView1.Columns["Name"].Caption = "الحساب";
        //        gridView1.Columns["Level"].VisibleIndex = -1;
        //        var indexColumn = new BandedGridColumn() { Name = "clmIndx", FieldName = "index", Caption = "م", Width = 35, UnboundType = UnboundColumnType.Integer, VisibleIndex = 0 };
        //        gridView1.Columns.Add(indexColumn);
        //        GridBand FirstBand = new GridBand();
        //        FirstBand.Columns.Add(indexColumn);
        //        FirstBand.Columns.Add(gridView1.Columns["ID"]);
        //        FirstBand.Columns.Add(gridView1.Columns["Name"]);
        //        FirstBand.Columns.Add(gridView1.Columns["Level"]);

        //        gridView1.Columns["Name"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;

        //        GridBand BeforeBand = new GridBand() { Name = "BeforeBand", Caption = "سابق", VisibleIndex = 1 };
        //        GridBand TransBand = new GridBand() { Name = "TransBand", Caption = "حركه", VisibleIndex = 2 };
        //        GridBand TotalBand = new GridBand() { Name = "TotalBand", Caption = "اجمالي", VisibleIndex = 3 };
        //        GridBand BalanceBand = new GridBand() { Name = "BalanceBand", Caption = "رصيد", VisibleIndex = 4 };
        //        gridView1.Bands.Clear();
        //        gridView1.Bands.AddRange(new GridBand[] { FirstBand, /*BeforeBand,*/
        //            TransBand, TotalBand, BalanceBand });
        //        BeforeBand.Columns.Add(gridView1.Columns["BeforeCredit"]);
        //        BeforeBand.Columns.Add(gridView1.Columns["BeforeDebit"]);
        //        TransBand.Columns.Add(gridView1.Columns["Credit"]);
        //        TransBand.Columns.Add(gridView1.Columns["Debit"]);
        //        TotalBand.Columns.Add(gridView1.Columns["TotalCredit"]);
        //        TotalBand.Columns.Add(gridView1.Columns["TotalDebit"]);
        //        BalanceBand.Columns.Add(gridView1.Columns["BalanceCredit"]);
        //        BalanceBand.Columns.Add(gridView1.Columns["BalanceDebit"]);
        //        gridView1.CustomColumnDisplayText += gridView1_CustomColumnDisplayText;
        //        gridView1.CustomUnboundColumnData += gridView1_CustomUnboundColumnData;
        //        gridView1.RowStyle += GridView1_RowStyle;
        //        gridView1.CustomDrawFooterCell += GridView1_CustomDrawFooterCell;



        //    }

        //}
        void RefreshData()
        {
            if (dateEdit1.DateTime.Year < 1950)
                dateEdit1.ErrorText = "*";
            if (dateEdit2.DateTime.Year < 1950)
                dateEdit2.ErrorText = "*";
            if (dateEdit2.DateTime.Year < 1950 || dateEdit1.DateTime.Year < 1950)
                return;
            using (var db = new accountingEntities())
            {
                
                var BeforeEntries = db.tblAssets.Where(x => DbFunctions.TruncateTime(x.asDate.Value) < dateEdit1.DateTime.Date);
                var TransEntries = db.tblAssets
                    .Where(x => DbFunctions.TruncateTime(x.asDate.Value) >= dateEdit1.DateTime.Date &&
                               DbFunctions.TruncateTime(x.asDate.Value) <= dateEdit2.DateTime.Date);
                var testQ1 = from be in BeforeEntries
                             group be by be.asAccNo into g
                             select new
                             {
                                 ID = g.Key,
                                 Credit = 0D,
                                 Debit = 0D,
                                 BeforeCredit = g.Sum(x => (double?)x.asCredit) ?? 0,
                                 BeforeDebit = g.Sum(x => (double?)x.asDebit) ?? 00,
                             };
                var testQ2 = from be in TransEntries
                             group be by be.asAccNo into g
                             select new
                             {
                                 ID = g.Key,
                                 Credit = g.Sum(x => (double?)x.asCredit) ?? 0,
                                 Debit = g.Sum(x => (double?)x.asDebit) ?? 0,
                                 BeforeCredit = 0D,
                                 BeforeDebit = 0D,
                             };
                testQ1 = testQ1.Concat(testQ2);

                var testQ3 = (from t1 in testQ1.ToList()
                              group t1 by t1.ID into g
                              select new
                              {
                                  ID = g.Key,
                                  IsParent = false,
                                  Credit = g.Sum(x => x.Credit),
                                  Debit = g.Sum(x => x.Debit),
                                  BeforeCredit = g.Sum(x => x.BeforeCredit),
                                  BeforeDebit = g.Sum(x => x.BeforeDebit),
                              }).ToList();
                var ParentAccounts = db.tblAccounts.Select(x => x.accNo).ToList().Where(pa => testQ3.Select(x => x.ID).Contains(pa) == false).ToList();
                var testQ4 = (from be in ParentAccounts
                              select new
                              {
                                  ID = be,
                                  IsParent = true,
                                  Credit = testQ3.AsEnumerable().Where(x => x.ID.ToString().StartsWith(be.ToString())).Sum(x => x.Credit),
                                  Debit = testQ3.AsEnumerable().Where(x => x.ID.ToString().StartsWith(be.ToString())).Sum(x => x.Debit),
                                  BeforeCredit = testQ3.AsEnumerable().Where(x => x.ID.ToString().StartsWith(be.ToString())).Sum(x => x.BeforeCredit),
                                  BeforeDebit = testQ3.AsEnumerable().Where(x => x.ID.ToString().StartsWith(be.ToString())).Sum(x => x.BeforeDebit),
                              }).ToList();
                var accountsList = db.tblAccounts.Select(x => new { ID = x.accNo, ParentID = x.accParent, Name = x.accName, Level = x.accLevel }).ToList();
                testQ4.AddRange(testQ3);
                //  var query5 = from t in testQ4

                var query5 = from t in testQ4
                             from a in accountsList.Where(x => x.ID == t.ID).DefaultIfEmpty()
                             select new
                             {
                                 ID = t.ID.ToString(),
                                 Name = (a != null) ? (".".PadLeft(((a != null) ? a.Level : 0) * 2) + a.Name) : "# Account Is Missing  #",
                                 level = a?.Level,
                                 t.IsParent,
                                 Parent = (a != null) ? a.ParentID.Value : 0,
                                 Level = (a != null) ? a.Level : 0,
                                 Credit = Math.Round(t.Credit, 2),
                                 Debit = Math.Round(t.Debit, 2),
                                 BeforeCredit = Math.Round(t.BeforeCredit, 2),
                                 BeforeDebit = Math.Round(t.BeforeDebit, 2),
                                 TotalCredit = Math.Round(t.Credit + t.BeforeCredit, 2),
                                 TotalDebit = Math.Round(t.Debit + t.BeforeDebit, 2),
                                 BalanceCredit = Math.Round((t.Credit + t.BeforeCredit > t.Debit + t.BeforeDebit) ? Math.Abs((t.Credit + t.BeforeCredit) - (t.Debit + t.BeforeDebit)) : 0, 2),
                                 BalanceDebit = Math.Round((t.Debit + t.BeforeDebit > t.Credit + t.BeforeCredit) ? Math.Abs((t.Debit + t.BeforeDebit) - (t.Credit + t.BeforeCredit)) : 0, 2)
                             };
                var data = query5.Where(x => x.BeforeCredit > 0 || x.BeforeDebit > 0 || x.Credit > 0 || x.Debit > 0).OrderBy(x => x.ID).ToList();



                var viewData = data.Where(x => x.level >= comboBoxEdit1.SelectedIndex + 1);
                viewData = viewData.Where(x => x.level <= comboBoxEdit2.SelectedIndex + 1);

                if (viewData.Count() == 0)
                {
                    XtraMessageBox.Show("لا يوجد بيانات");
                    return;

                }

                gridControl1.DataSource = viewData;


                var ChildsOnly = data.Where(x => x.IsParent == false);
                var sumCredit = ChildsOnly.Sum(x => (double?)x.Credit) ?? 0;
                var sumDebit = ChildsOnly.Sum(x => (double?)x.Debit) ?? 0;
                var sumBeforeCredit = ChildsOnly.Sum(x => (double?)x.BeforeCredit) ?? 0;
                var sumBeforeDebit = ChildsOnly.Sum(x => (double?)x.BeforeDebit) ?? 0;
                var sumTotalCredit = ChildsOnly.Sum(x => (double?)x.TotalCredit) ?? 0;
                var sumTotalDebit = ChildsOnly.Sum(x => (double?)x.TotalDebit) ?? 0;
                var sumBalanceCredit = ChildsOnly.Sum(x => (double?)x.BalanceCredit) ?? 0;
                var sumBalanceDebit = ChildsOnly.Sum(x => (double?)x.BalanceDebit) ?? 0;

                IsBeforeBalanced = Math.Abs(sumBeforeCredit - sumBeforeDebit) < 0.1;
                IsTranceBalaced = Math.Abs(sumCredit - sumDebit) < 0.1;
                IsTotalBalaced = Math.Abs(sumTotalDebit - sumTotalCredit) < 0.1;
                IsBalanceBalanced = Math.Abs(sumBalanceCredit - sumBalanceDebit) < 0.1;


                gridView1.Columns["Credit"]?.SummaryItem.SetSummary(SummaryItemType.Custom, sumCredit.ToString());
                gridView1.Columns["Debit"].SummaryItem.SetSummary(SummaryItemType.Custom, sumDebit.ToString());
                gridView1.Columns["BeforeCredit"].SummaryItem.SetSummary(SummaryItemType.Custom, sumBeforeCredit.ToString("{0:0.##}"));
                gridView1.Columns["BeforeDebit"].SummaryItem.SetSummary(SummaryItemType.Custom, sumBeforeDebit.ToString());
                gridView1.Columns["TotalCredit"].SummaryItem.SetSummary(SummaryItemType.Custom, sumTotalCredit.ToString());
                gridView1.Columns["TotalDebit"].SummaryItem.SetSummary(SummaryItemType.Custom, sumTotalDebit.ToString());
                gridView1.Columns["BalanceCredit"].SummaryItem.SetSummary(SummaryItemType.Custom, sumBalanceCredit.ToString());
                gridView1.Columns["BalanceDebit"].SummaryItem.SetSummary(SummaryItemType.Custom, sumBalanceDebit.ToString());

                PrintData = (new[] { new {
                IsBeforeBalanced,
                IsTranceBalaced,
                IsBalanceBalanced,
                Data = data .ToList()
                } }).ToList();
                //----------------- UI
                if (IsGridInitialized) return;
                IsGridInitialized = true;

                gridView1.OptionsView.ShowFooter = true;
                int i = 3;
                gridView1.Columns.Where(x=>x.FieldName.Contains("Credit") 
                || x.FieldName.Contains("Debit")).ToList().ForEach(clm =>
                {
                        clm.Caption = clm.FieldName.Contains("Credit")? "دائن": "مدين";
                        clm.VisibleIndex = i++;
                        clm.DisplayFormat.FormatString = "N2";
                        clm.DisplayFormat.FormatType = FormatType.Numeric;
                });
                //foreach (BandedGridColumn clm in gridView1.Columns)
                //{
                //    if (clm.FieldName.Contains("Credit") || clm.FieldName.Contains("Debit"))
                //    {
                //        if (clm.FieldName.Contains("Credit"))
                //            clm.Caption = "دائن";
                //        else if (clm.FieldName.Contains("Debit"))
                //            clm.Caption = "مدين";

                //        clm.VisibleIndex = i++;
                //        clm.DisplayFormat.FormatString = "N2";
                //        clm.DisplayFormat.FormatType = FormatType.Numeric;
                //        //  clm.SummaryItem.DisplayFormat = "{0:n2}"; 
                //    }
                //}
                gridView1.Appearance.BandPanel.Options.UseTextOptions = true;
                gridView1.Appearance.BandPanel.TextOptions.HAlignment = HorzAlignment.Center;
                gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
                gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;

                gridView1.OptionsBehavior.Editable = false;
                gridView1.OptionsBehavior.FocusLeaveOnTab = true;
                gridView1.OptionsNavigation.EnterMoveNextColumn = true;
                gridView1.OptionsView.EnableAppearanceEvenRow = true;
                gridView1.OptionsView.RowAutoHeight = true;
                gridView1.OptionsView.ShowAutoFilterRow = true;

                gridView1.OptionsView.ShowFooter = true;
                gridView1.OptionsView.ShowGroupPanel = false;
                //gridView1.ScrollStyle = ScrollStyleFlags.None;
                gridView1.Columns["ID"].Visible = false;
                gridView1.Columns["Name"].VisibleIndex = 1;
                gridView1.Columns["Name"].Caption = "الحساب";
                gridView1.Columns["Level"].VisibleIndex = -1;
                var indexColumn = new BandedGridColumn() { Name = "clmIndx", FieldName = "index", Caption = "م", Width = 35, UnboundType = UnboundColumnType.Integer, VisibleIndex = 0 };
                gridView1.Columns.Add(indexColumn);
                GridBand FirstBand = new GridBand();
                FirstBand.Columns.Add(indexColumn);
                FirstBand.Columns.Add(gridView1.Columns["ID"]);
                FirstBand.Columns.Add(gridView1.Columns["Name"]);
                FirstBand.Columns.Add(gridView1.Columns["Level"]);

                gridView1.Columns["Name"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;

                GridBand BeforeBand = new GridBand() { Name = "BeforeBand", Caption = "سابق", VisibleIndex = 1 };
                GridBand TransBand = new GridBand() { Name = "TransBand", Caption = "حركه", VisibleIndex = 2 };
                GridBand TotalBand = new GridBand() { Name = "TotalBand", Caption = "اجمالي", VisibleIndex = 3 };
                GridBand BalanceBand = new GridBand() { Name = "BalanceBand", Caption = "رصيد", VisibleIndex = 4 };
                gridView1.Bands.Clear();
                gridView1.Bands.AddRange(new GridBand[] { FirstBand, BeforeBand, TransBand, TotalBand, BalanceBand });
                BeforeBand.Columns.Add(gridView1.Columns["BeforeCredit"]);
                BeforeBand.Columns.Add(gridView1.Columns["BeforeDebit"]);
                TransBand.Columns.Add(gridView1.Columns["Credit"]);
                TransBand.Columns.Add(gridView1.Columns["Debit"]);
                TotalBand.Columns.Add(gridView1.Columns["TotalCredit"]);
                TotalBand.Columns.Add(gridView1.Columns["TotalDebit"]);
                BalanceBand.Columns.Add(gridView1.Columns["BalanceCredit"]);
                BalanceBand.Columns.Add(gridView1.Columns["BalanceDebit"]);
                gridView1.CustomColumnDisplayText += gridView1_CustomColumnDisplayText;
                gridView1.CustomUnboundColumnData += gridView1_CustomUnboundColumnData;
                gridView1.RowStyle += GridView1_RowStyle;
                gridView1.CustomDrawFooterCell += GridView1_CustomDrawFooterCell;



            }

        }
        object PrintData;
        bool IsBeforeBalanced;
        bool IsTranceBalaced;
        bool IsTotalBalaced;
        bool IsBalanceBalanced;
        private void GridView1_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            if ((e.Column.FieldName == "Credit" || e.Column.FieldName == "Debit") && IsTranceBalaced == false)
                e.Appearance.BackColor = Color.Red;
            else
                e.Appearance.BackColor = Color.Green;



            if (e.Column.FieldName.StartsWith("Balance") && IsBalanceBalanced == false)
                e.Appearance.BackColor = Color.Red;
            else
                e.Appearance.BackColor = Color.Green;

            if (e.Column.FieldName.StartsWith("Before") && IsBeforeBalanced == false)
                e.Appearance.BackColor = Color.Red;
            else
                e.Appearance.BackColor = Color.Green;

            if (e.Column.FieldName.StartsWith("Total") && IsTotalBalaced == false)
                e.Appearance.BackColor = Color.Red;
            else
                e.Appearance.BackColor = Color.Green;

            e.Appearance.Options.UseBackColor = true;

        }

        private void GridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {

            var row = gridView1.GetRowCellValue(e.RowHandle, "IsParent");
            if (row != null && row.GetType() == typeof(Boolean))
            {
                if (row.Equals(true))
                {
                    e.Appearance.BackColor = Color.LightGray;
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                    e.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
                    e.HighPriority = true;
                }
            }
        }

        private void GridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {

        }

        private void gridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.ListSourceRowIndex < 0)
                return;
            e.Value = (object)(e.ListSourceRowIndex + 1);
        }
        private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (!(e.DisplayText.Trim() == "0"))
                return;
            e.DisplayText = string.Empty;
        }

        bool IsGridInitialized;

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RefreshData();
        }

        private void frm_TrialBalance_Load(object sender, EventArgs e)
        {
            //  var date = DateTime.Now.AddMonths(-1);
            //  var lastDay = DateTime.DaysInMonth(date.Year, date.Month);
            dateEdit1.EditValue = Session.CurrentYear.fyDateStart;// new DateTime(date.Year, date.Month, 1);
            dateEdit2.EditValue = Session.CurrentYear.fyDateEnd; //new DateTime(date.Year, date.Month, lastDay);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Reports.rpt_GridReport.Print(this.gridControl1, "ميزان المراجعة", " من " + dateEdit1.Text + " الي " + dateEdit2.Text, true );
            rpt_TrialBalance rpt = new rpt_TrialBalance(PrintData, IsBeforeBalanced, IsTranceBalaced, IsBalanceBalanced);
            rpt.ShowRibbonPreview();
        }
    }
}

