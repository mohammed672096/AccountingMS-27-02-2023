using AccountingMS.Properties;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.Utils.VisualEffects;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class ucMain : XtraUserControl
    {
        ClsTblSupplyMain clsTbSupplyMain = new ClsTblSupplyMain();
        private readonly FormMain _formMain;
        private IOverlaySplashScreenHandle overlaySplashScreen;
        public ucMain(FormMain formMain)
        {
            _formMain = formMain;
            InitializeComponent();
            InitTileItems();
            if (MySetting.GetPrivateSetting.LangEng) translateEng();
            skinPaletteRibbonGalleryBarItem1.GalleryItemClick += skinPaletteRibbonGalleryBarItem1_GalleryItemClick;
            UserLookAndFeel.Default.StyleChanged += Default_StyleChanged;
            bbiHideMenuCaption.CheckedChanged += bbiHideMenuCaption_CheckedChanged;
            bbiCompactMode.CheckedChanged += BbiCompactMode_CheckedChanged;
            bbiTouchUI.CheckedChanged += bbiTouchUI_CheckedChanged;
            repoItemSpinEditTouchScaleFactor.KeyDown+= repoItemSpinEditTouchScaleFactor_KeyDown;
            repoItemSpinEditTouchScaleFactor.MouseUp += repoItemSpinEditTouchScaleFactor_MouseUp;
        }

        private void skinPaletteRibbonGalleryBarItem1_GalleryItemClick(object sender, GalleryItemClickEventArgs e)
        {
            if (UserLookAndFeel.Default.ActiveSkinName == "The Bezier")
                MySetting.GetPrivateSetting.ApplicationSkinPaletteBezier = e.Item.Caption;
            else
                MySetting.GetPrivateSetting.ApplicationSkinPaletteOffice = e.Item.Caption;
            MySetting.WriterSettingXml();
        }

        private void Default_StyleChanged(object sender, EventArgs e)
        {
            if (UserLookAndFeel.Default.ActiveSkinName == "The Bezier")
                UserLookAndFeel.Default.SetSkinStyle(UserLookAndFeel.Default.ActiveSkinName, MySetting.GetPrivateSetting.ApplicationSkinPaletteBezier);
            else if (UserLookAndFeel.Default.ActiveSkinName == "Office 2019 Colorful")
                UserLookAndFeel.Default.SetSkinStyle(UserLookAndFeel.Default.ActiveSkinName, MySetting.GetPrivateSetting.ApplicationSkinPaletteOffice);

            SaveSkinName();
        }

        private void SaveSkinName()
        {
            MySetting.GetPrivateSetting.ApplicationSkinName = UserLookAndFeel.Default.SkinName;
            MySetting.WriterSettingXml();
        }

        private void bbiHideMenuCaption_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            _formMain.ribbonControl.ShowItemCaptionsInQAT = !bbiHideMenuCaption.Checked;
            MySetting.GetPrivateSetting.hideMenuCaption = !bbiHideMenuCaption.Checked;
            MySetting.WriterSettingXml();
        }

        private void BbiCompactMode_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            this.overlaySplashScreen = SplashScreenManager.ShowOverlayForm(this);
            SetCompactMode();
            MySetting.GetPrivateSetting.compactMode = bbiCompactMode.Checked;
            MySetting.WriterSettingXml();
            this.overlaySplashScreen.Close();
        }

        private void SetCompactMode()
        {
            WindowsFormsSettings.CompactUIMode = (bbiCompactMode.Checked) ? DefaultBoolean.True : DefaultBoolean.False;
        }

        private void bbiTouchUI_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            this.overlaySplashScreen = SplashScreenManager.ShowOverlayForm(this);

            MySetting.GetPrivateSetting.touchUI = bbiTouchUI.Checked;
            MySetting.WriterSettingXml();
            SetTouchUI();

            this.overlaySplashScreen.Close();
        }

        private void repoItemSpinEditTouchScaleFactor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            SpinEdit editor = sender as SpinEdit;
            if (editor?.EditValue == null) return;

            this.overlaySplashScreen = SplashScreenManager.ShowOverlayForm(this);
            (bbiTouchScaleFactor.Links[0] as BarEditItemLink).PostEditor();

            MySetting.GetPrivateSetting.touchScaleFactor = (float)Convert.ToDouble(editor.EditValue);
            MySetting.WriterSettingXml();
            SetTouchScaleFactor();

            this.overlaySplashScreen.Close();
        }

        private void repoItemSpinEditTouchScaleFactor_MouseUp(object sender, MouseEventArgs e)
        {
            (bbiTouchScaleFactor.Links[0] as BarEditItemLink).PostEditor();
            float scaleFactor = (float)Convert.ToDouble(bbiTouchScaleFactor.EditValue);

            if (scaleFactor == MySetting.GetPrivateSetting.touchScaleFactor) return;
            this.overlaySplashScreen = SplashScreenManager.ShowOverlayForm(this);

            MySetting.GetPrivateSetting.touchScaleFactor = scaleFactor;
            MySetting.WriterSettingXml();
            SetTouchScaleFactor();

            this.overlaySplashScreen.Close();
        }

        private void SetTouchUI()
        {
            WindowsFormsSettings.TouchUIMode = (MySetting.GetPrivateSetting.touchUI) ? TouchUIMode.True : TouchUIMode.False;
            SetTouchScaleFactor();
        }

        private void SetTouchScaleFactor()
        {
            WindowsFormsSettings.TouchScaleFactor = MySetting.GetPrivateSetting.touchScaleFactor;
        }

        void translateEng()
        {
            tileItemPurchase.Text = "Purchase";
            tileItemSale.Text = "Sale";
            tileItemPurchaseDel.Text = "Deleted purchases";
            tileItemSaleDel.Text = "Deleted sales";
            tileItemPurchasePhased.Text = "Phase purchases";
            tileItemSalePhased.Text = "Stage sales";
            tileItemPurchaseRtrn.Text = "Refund of purchases";
            tileItemSaleRtrn.Text = "Sales payoff";
            tileItemPurchaseRtrnDel.Text = "Refund of deleted purchases";
            tileItemSaleRtrnDel.Text = "Returned sales deleted";
            tileItemPurchaseRtrnPhased.Text = "Payback of purchases posted";
            tileItemSaleRtrnPhased.Text = "Payback sales stage";
        }
        private void UcMain_Load(object sender, EventArgs e)
        {
            InitChart();
        }

        private void InitChart()
        {
            InitChartData(0, (byte)SupplyType.Purchase, (byte)SupplyType.PurchasePhase, (byte)SupplyType.PurchaseRtrn, (byte)SupplyType.PurchasePhaseRtrn);
            InitChartData(1, (byte)SupplyType.Sales, (byte)SupplyType.SalesPhase, (byte)SupplyType.SalesRtrn, (byte)SupplyType.SalesPhaseRtrn);
        }

        private void InitChartData(byte series, byte status1, byte status2, byte statusRtrn1, byte statusRtrn2)
        {
            var tbSupplySummaryList = this.clsTbSupplyMain.GetSupplyMainList
                .Where(x => x.supStatus == status1 || x.supStatus == status2 || x.supStatus == statusRtrn1 || x.supStatus == statusRtrn2)
                .GroupBy(x => x.supDate.Value.Month, (key, grp) => new tblSupplySummary
                {
                    supDate = new DateTime(Session.CurrentYear.fyDateStart.Year, key, 1),
                    supTotal = grp.Where(x => x.supStatus == status1 || x.supStatus == status2).Sum(x => (x.supTotal + x.supTaxPrice) - x.supDscntAmount),
                    supTotalRtrn = grp.Where(x => x.supStatus == statusRtrn1 || x.supStatus == statusRtrn2).Sum(x => (x.supTotal + x.supTaxPrice) - x.supDscntAmount)
                }).ToList();
            InitSeriesPoints(series, CalculateTotal(tbSupplySummaryList));
        }

        private IEnumerable<tblSupplySummary> CalculateTotal(IEnumerable<tblSupplySummary> tbSupplySummaryList)
        {
            foreach (var tbSupplySummary in tbSupplySummaryList)
                tbSupplySummary.supTotal -= tbSupplySummary.supTotalRtrn;
            return tbSupplySummaryList;
        }

        private void InitSeriesPoints(byte series, IEnumerable<tblSupplySummary> tbSupplyList)
        {
            chartControl1.Series[series].DataSource = tbSupplyList;
            chartControl1.Series[series].ArgumentDataMember = "supDate";
            chartControl1.Series[series].ValueDataMembersSerializable = "supTotal";
        }

        private void InitTileItems()
        {
            try
            {
                InitTileApperance(tileItemPurchase, badgePurchase, this.clsTbSupplyMain.GetSupplyCount((byte)SupplyType.Purchase));
                InitTileApperance(tileItemPurchaseDel, badgePurchaseDel, this.clsTbSupplyMain.GetSupplyCount((byte)SupplyType.PurchaseDel));
                InitTileApperance(tileItemPurchasePhased, badgePurchasePhased, this.clsTbSupplyMain.GetSupplyCount((byte)SupplyType.PurchasePhase));
                InitTileApperance(tileItemPurchaseRtrn, badgePurchaseRtrn, this.clsTbSupplyMain.GetSupplyCount((byte)SupplyType.PurchaseRtrn));
                InitTileApperance(tileItemPurchaseRtrnDel, badgePurchaseRtrnDel, this.clsTbSupplyMain.GetSupplyCount((byte)SupplyType.PurchaseRtrnDel));
                InitTileApperance(tileItemPurchaseRtrnPhased, badgePurchaseRtrnPhased, this.clsTbSupplyMain.GetSupplyCount((byte)SupplyType.PurchasePhaseRtrn));
                InitTileApperance(tileItemSale, badgeSale, this.clsTbSupplyMain.GetSupplyCount((byte)SupplyType.Sales));
                InitTileApperance(tileItemSaleDel, badgeSaleDel, this.clsTbSupplyMain.GetSupplyCount((byte)SupplyType.SalesDel));
                InitTileApperance(tileItemSalePhased, badgeSalePhased, this.clsTbSupplyMain.GetSupplyCount((byte)SupplyType.SalesPhase));
                InitTileApperance(tileItemSaleRtrn, badgeSaleRtrn, this.clsTbSupplyMain.GetSupplyCount((byte)SupplyType.SalesRtrn));
                InitTileApperance(tileItemSaleRtrnDel, badgeSaleRtrnDel, this.clsTbSupplyMain.GetSupplyCount((byte)SupplyType.SalesRtrnDel));
                InitTileApperance(tileItemSaleRtrnPhased, badgeSaleRtrnPhased, this.clsTbSupplyMain.GetSupplyCount((byte)SupplyType.SalesPhaseRtrn));

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message + "عذرا حدث خطاء في الاتصال مع قاعدة البيانات ! يرجى مراجعة قسم الصيانة.");
                Application.Exit();
            }
        }

        private void SetBadgeOffset()
        {
            SetBadgeOffset(badgePurchase, tileItemPurchase, -5, ScaleDPI.ScaleVertical(20));
            SetBadgeOffset(badgePurchaseDel, tileItemPurchaseDel, -5, ScaleDPI.ScaleVertical(20));
            SetBadgeOffset(badgePurchasePhased, tileItemPurchasePhased, -5, ScaleDPI.ScaleVertical(20));
            SetBadgeOffset(badgePurchaseRtrn, tileItemPurchaseRtrn, -5, ScaleDPI.ScaleVertical(20));
            SetBadgeOffset(badgePurchaseRtrnDel, tileItemPurchaseRtrnDel, -5, ScaleDPI.ScaleVertical(20));
            SetBadgeOffset(badgePurchaseRtrnPhased, tileItemPurchaseRtrnPhased, -5, ScaleDPI.ScaleVertical(20));
            SetBadgeOffset(badgeSale, tileItemSale, -5, ScaleDPI.ScaleVertical(20));
            //SetBadgeOffset(badgeSaleDel, tileItemSaleDel, -5, ScaleDPI.ScaleVertical(20));
            SetBadgeOffset(badgeSalePhased, tileItemSalePhased, -5, ScaleDPI.ScaleVertical(20));
            SetBadgeOffset(badgeSaleRtrn, tileItemSaleRtrn, -5, ScaleDPI.ScaleVertical(20));
            //SetBadgeOffset(badgeSaleRtrnDel, tileItemSaleRtrnDel, -5, ScaleDPI.ScaleVertical(20));
            SetBadgeOffset(badgeSaleRtrnPhased, tileItemSaleRtrnPhased, -5, ScaleDPI.ScaleVertical(20));
        }

        private void InitTileApperance(TileItem tileItem, Badge badge, int supplyCount)
        {
            //tileItem.AppearanceItem.Normal.BackColor = CommonColors.GetQuestionColor(LookAndFeel);
            //tileItem.AppearanceItem.Normal.BorderColor = CommonColors.GetQuestionColor(LookAndFeel);
            //tileItem.AppearanceItem.Normal.Font = new Font("Segoe UI", 10);
            //tileItem.ItemSize = TileItemSize.Medium;
            //tileItem.ItemSize = TileItemSize.Wide;
            InitBadge(badge, supplyCount, tileItem);
        }

        private void InitBadge(Badge badge, int supplyCount, TileItem tileItem)
        {
            badge.Properties.BeginUpdate();
            badge.Properties.PaintStyle = BadgePaintStyle.Critical;
            badge.Properties.Location = ContentAlignment.TopRight;
            badge.TargetElement = tileItem;
            badge.Properties.Text = $"{supplyCount:n0}";
            badge.Properties.EndUpdate();
        }

        private void SetBadgeOffset(Badge badge, TileItem tile, int deltaX, int deltaY)
        {
            int delta = ScaleDPI.ScaleSize(tile.ImageOptions.SvgImageSize).Width / 2;
            int x = ((ISupportAdornerElement)tile).Bounds.Width / 2 - delta;
            int y = ((ISupportAdornerElement)tile).Bounds.Height / 2 - delta;
            badge.Properties.Offset = new Point(-x - deltaX, y - deltaY);
        }

        private void TileControlMain_Paint(object sender, PaintEventArgs e)
        {
            SetBadgeOffset();
        }

        private void TileControlMain_ItemClick(object sender, TileItemEventArgs e)
        {
            if (Session.CurrentUser.id != 1) return;

            if (e.Item.Name == tileItemPurchase.Name)
                _formMain.SetUserControl("barButtonItemPurchase");
            else if (e.Item.Name == tileItemPurchaseDel.Name)
                _formMain.SetUserControl("barButtonItemPurchaseDel");
            else if (e.Item.Name == tileItemPurchasePhased.Name)
                _formMain.SetUserControl("barButtonItemPurchaseAll");
            else if (e.Item.Name == tileItemPurchaseRtrn.Name)
                _formMain.SetUserControl("barButtonItemPurchaseRtrn");
            else if (e.Item.Name == tileItemPurchaseRtrnDel.Name)
                _formMain.SetUserControl("barButtonItemPurchaseRtrnDel");
            else if (e.Item.Name == tileItemPurchaseRtrnPhased.Name)
                _formMain.SetUserControl("barButtonItemPurchaseAll");
            else if (e.Item.Name == tileItemSale.Name)
                _formMain.SetUserControl("barButtonItemSale");
            else if (e.Item.Name == tileItemSaleDel.Name)
                _formMain.SetUserControl("barButtonItemSaleDel");
            else if (e.Item.Name == tileItemSalePhased.Name)
                _formMain.SetUserControl("barButtonItemSaleAll");
            else if (e.Item.Name == tileItemSaleRtrn.Name)
                _formMain.SetUserControl("barButtonItemSaleRtrn");
            else if (e.Item.Name == tileItemSaleRtrnDel.Name)
                _formMain.SetUserControl("barButtonItemSaleRtrnDel");
            else if (e.Item.Name == tileItemSaleRtrnPhased.Name)
                _formMain.SetUserControl("barButtonItemSaleAll");
        }
    }
}
