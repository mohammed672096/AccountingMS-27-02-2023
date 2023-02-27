using AccountingMS.Classes;
using AccountingMS.Forms;
using AccountingMS.Reports;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formDefaultPrinterUser : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsAppearance clsAppearance = new ClsAppearance();
        public formDefaultPrinterUser()
        {
            SetLanguage();
            InitializeComponent();
            SetRTL();
            this.Load += FormDefaultSettings_Load;
            clsAppearance.AppearanceGridView(gridView);
            gridView.OptionsBehavior.ReadOnly = false;
            repItemLookUpEditPrinterName.EditValueChanging += RepItemLookUpEditPrinterName_EditValueChanging;
        }

        private void RepItemLookUpEditPrinterName_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (e.NewValue == null) return;
            if(gridView.FocusedRowObject is tblUser user&& user!=null)
            user.PrinterName = e.NewValue.ToString();
        }

        private void FormDefaultSettings_Load(object sender, EventArgs e)
        {
            tblUserBindingSource.DataSource = Session.tblUser;
            repItemLookUpEditPrinterName.DataSource = Session.ListPrinter;
        }
      
        private void SaveData()
        {
            using (var db = new accountingEntities())
            {   
                var DefaultUser = tblUserBindingSource.List as IList<tblUser>;
                DefaultUser.ToList().ForEach(x =>
                {
                    var Baseitem = db.tblUsers.Find(x.id);
                    db.Entry(Baseitem).CurrentValues.SetValues(x);
                }); 
                if (db.SaveChanges() > 0)
                {
                    ShowSaveMssg();
                    Session.GetDataUserTbls(db);
                    Session.CurrentUser = Session.tblUser.FirstOrDefault(x => x.id == Session.CurrentUser.id);
                }
            }
        }
     
        private void ShowSaveMssg()
        {
            string mssg = (!MySetting.GetPrivateSetting.LangEng) ? "الطابعات الإفتراضيه" : "Default Printer";
            flyDialog.ShowDialogForm(this, mssg);
        }

        private void Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
        }
  
        private void SetLanguage()
        {
            if (!MySetting.GetPrivateSetting.LangEng) Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
            else Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
        }

        private void SetRTL()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;
            dataLayoutControl4.BeginUpdate();
            dataLayoutControl4.RightToLeft = RightToLeft.No;
            dataLayoutControl4.OptionsView.RightToLeftMirroringApplied = false;
            dataLayoutControl4.EndUpdate();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
         
            this.Close();
        }
    }
}