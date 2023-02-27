using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using System.Drawing;
using System.Windows.Forms;

namespace AccountingMS
{
    class ClsFlyoutDialog
    {
        public static void ShowFlyoutDialog(dynamic owner, dynamic userControl, string headerCaption)
        {
            FlyoutCommand flyoutCommand = new FlyoutCommand() { Result = DialogResult.Yes };
            flyoutCommand.Text = (!MySetting.GetPrivateSetting.LangEng) ? "إغلاق" : "Close";

            FlyoutAction flyoutAction = new FlyoutAction() { Caption = headerCaption };
            flyoutAction.Commands.Add(flyoutCommand);

            FlyoutDialog dialog = new FlyoutDialog(owner, flyoutAction, userControl);
            if (dialog.ShowDialog() == DialogResult.Yes) dialog.Close();
        }

        public static FlyoutDialog InitFlyoutDialog(dynamic owner, dynamic control, string headerCaption)
        {
            FlyoutCommand flyCommand = new FlyoutCommand() { Result = DialogResult.Yes };
            flyCommand.Text = (!MySetting.GetPrivateSetting.LangEng) ? "إغلاق" : "Close";

            FlyoutAction flyAction = new FlyoutAction();
            flyAction.Caption = headerCaption;
            flyAction.Commands.Add(flyCommand);

            FlyoutProperties flyProperties = new FlyoutProperties() { ButtonSize = new Size(150, 10) };
            flyProperties.AppearanceButtons.FontSizeDelta = 2;
            flyProperties.AppearanceCaption.FontSizeDelta = 4;
            flyProperties.AppearanceCaption.FontStyleDelta = FontStyle.Bold;

            return new FlyoutDialog(owner, flyAction, control, flyProperties);
        }

        public static void ShowFlyoutWarningMssg(dynamic owner, string mssg)
        {
            FlyoutCommand flyoutCommandYes = new FlyoutCommand()
            {
                Text = (!MySetting.GetPrivateSetting.LangEng) ? "موافق" : "Ok",
                Result = DialogResult.Yes,
            };

            FlyoutAction flyoutAction = new FlyoutAction()
            {
                Caption = "تنبيه",
                Description = mssg
            };
            flyoutAction.Commands.Add(flyoutCommandYes);

            FlyoutProperties flyProperties = new FlyoutProperties() { ButtonSize = new Size(150, 10) };
            flyProperties.AppearanceCaption.Font = new Font("Segoe UI Semibold", 18, FontStyle.Bold);

            new FlyoutDialog(owner, flyoutAction, flyProperties).ShowDialog();
        }

        public static bool ShowFlyoutDialogConfirmMssg(dynamic owner, string caption, string mssg)
        {
            FlyoutCommand flyoutCommandYes = new FlyoutCommand()
            {
                Text = (!MySetting.GetPrivateSetting.LangEng) ? "نعم" : "Yes",
                Result = DialogResult.Yes,
            };
            FlyoutCommand flyoutCommandNo = new FlyoutCommand()
            {
                Text = (!MySetting.GetPrivateSetting.LangEng) ? "لا" : "No",
                Result = DialogResult.No,
            };
            FlyoutAction flyoutAction = new FlyoutAction()
            {
                Caption = caption,
                Description = mssg
            };
            flyoutAction.Commands.Add(flyoutCommandNo);
            flyoutAction.Commands.Add(flyoutCommandYes);

            FlyoutProperties flyProperties = new FlyoutProperties() { ButtonSize = new Size(150, 10) };
            flyProperties.AppearanceCaption.Font = new Font("Segoe UI Semibold", 18, FontStyle.Bold);

            return new FlyoutDialog(owner, flyoutAction, flyProperties).ShowDialog() == DialogResult.Yes ? true : false;
        }
    }
}
