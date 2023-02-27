using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblSupplier
    {
        public ClsTblSupplier()
        {
            Session.GetDataSuppliers();
        }

        public List<tblSupplier> GetSuppliersList() => Session.Suppliers;

        public List<tblSupplier> GetTblSupplierListByCurrencyId(byte curId)
        {
            return (from a in Session.Suppliers
                    where a.splCurrency == curId
                    select a).ToList();
        }

        public tblSupplier GetSupplierObjById(int splId)
        {
            return Session.Suppliers.FirstOrDefault(x => x.id == splId);
        }

        public tblSupplier GetSupplierObjByAccNo(long accNo)
        {
            return Session.Suppliers.Where(x => x.splAccNo == accNo).FirstOrDefault() ?? null;
        }

        public string GetSupplierNameById(int splId)
        {
            return Session.Suppliers.FirstOrDefault(x => x.id == splId)?.splName;
        }

        public string GetSupplierTaxDeclarationNoById(int splId)
        {
            return Session.Suppliers.FirstOrDefault(x => x.id == splId)?.splTaxNo;

        }
        public void InitCustomerRepositoryLookupEdit(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit custNoLookUp)
        {
            custNoLookUp.DataSource = Session.Suppliers.Where(x => x.splBrnId == Session.CurBranch.brnId);
            custNoLookUp.DisplayMember = "splNo";
            custNoLookUp.ValueMember = "splNo";
            custNoLookUp.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("splNo", "رقم المورد", 11, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("splName", "إسم المورد", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("splTaxNo", "الرقم الضريبي", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
        }
        public void InitCustomerRepositoryLookupEdit(DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit custNoLookUp)
        {
            custNoLookUp.DataSource = Session.Suppliers.Where(x => x.splBrnId == Session.CurBranch.brnId);
            custNoLookUp.DisplayMember = "splNo";
            custNoLookUp.ValueMember = "splNo";

            var view = custNoLookUp.View;
            view.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[]
            {
                new DevExpress.XtraGrid.Columns.GridColumn()
                {
                    FieldName = "splNo",
                    Caption =  "رقم المورد",
                    Visible = true,
                    VisibleIndex = 1
                },
                  new DevExpress.XtraGrid.Columns.GridColumn()
                {
                    FieldName = "splName",
                    Caption =  "إسم المورد",   Visible = true,
                    VisibleIndex = 1
                },
                  new DevExpress.XtraGrid.Columns.GridColumn()
                {
                    FieldName = "splTaxNo",
                    Caption =  "الرقم الضريبي",   Visible = true,
                    VisibleIndex = 1
                }
            });

            //       custNoLookUp.View .Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            //       new DevExpress.XtraEditors.Controls.LookUpColumnInfo("custNo", "رقم العميل", 11, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Near),
            //       new DevExpress.XtraEditors.Controls.LookUpColumnInfo("custName", "إسم العميل", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            //
            //   
        }

    }
}
