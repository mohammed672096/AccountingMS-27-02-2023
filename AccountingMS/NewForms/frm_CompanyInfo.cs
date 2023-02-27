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

namespace ERP.Forms
{
    public partial class frm_CompanyInfo : frm_Master 
    {
        public frm_CompanyInfo()
        {
            InitializeComponent();

        }

        private void frm_CompanyInfo_Load(object sender, EventArgs e)
        {
            btn_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btn_New.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btn_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btn_Print.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            GetData();
        }
        public override void Save()
        {
            if(!CanEdit) { XtraMessageBox.Show(LangResource.CantEditNoPermission, "", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            SetData();
            db.SubmitChanges();
            IsNew = false;
            GetData();
            base.Save();

            var obj = from c in db.St_CompanyInfos where c.ID == 1 select c;
            CurrentSession.Company = obj.First();
            for (int i = 0; i < Application.OpenForms.Count  -1; i++)
            {
                if (Application.OpenForms[i].Name == "frm_Main")
                {
                    Application.OpenForms[i].Text = CurrentSession.Company.CompanyName;
                 //   frm_Main .MainTileControl  .tileControl1.Text = CurrentSession.Company.CompanyName;
                }

            }
        }
        public override void Delete()
        {
           
        }
        public override void Print()
        {
          //  if (CanPerformPrint() == false) return;

        }
        public override void  New()
        {

        }
        DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
        DAL.St_CompanyInfo info = new DAL.St_CompanyInfo();


        void GetData()
        {
            var obj = from c in db.St_CompanyInfos where c.ID == 1 select c; 
            if (obj.Count () == 0)
            {
              info = new DAL.St_CompanyInfo { CompanyName = "", ID = 1 };
                db.St_CompanyInfos.InsertOnSubmit(info);
            }
            else
            {
                info = obj.First();
            }
            txt_CompanyName.Text  = info.CompanyName;
            txt_CompanyCity.Text = info.CompanyCity;
            txt_Address.Text = info.CompanyAddress;
            txt_Phone.Text = info.CompanyPhone;
            txt_Mobile.Text = info.CompanyMobile;
            txt_CBookNumber.Text = info.CompanyCommercialBook;
            txt_TaxCardNumber.Text = info.CompanyTaxCard;
            DateEdit_FYearStart.EditValue = info.CompanyFYearStart;
            DateEdit_FYearEnd.EditValue = info.CompanyFYearEnd;
            try
            {
            pictureEdit_Logo.Image = Master.GetImageFromByte(info.CompanyLogo.ToArray());

            }
            catch { pictureEdit_Logo.Image = null; }



        }
        void SetData()
        {
           info.CompanyName           = txt_CompanyName.Text   ; 
           info.CompanyCity           = txt_CompanyCity.Text   ; 
           info.CompanyAddress        = txt_Address.Text       ; 
           info.CompanyPhone          = txt_Phone.Text         ; 
           info.CompanyMobile         = txt_Mobile.Text        ; 
           info.CompanyCommercialBook = txt_CBookNumber.Text   ; 
           info.CompanyTaxCard =        txt_TaxCardNumber.Text ;
            info.CompanyFYearStart = DateEdit_FYearStart.DateTime;
            info.CompanyFYearEnd = DateEdit_FYearEnd.DateTime;
            if (pictureEdit_Logo.Image != null)
           info.CompanyLogo  =new System.Data.Linq.Binary( Master.GetByteFromImage( pictureEdit_Logo.Image )); 


        }
    }
}