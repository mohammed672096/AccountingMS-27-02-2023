using DevExpress.XtraGrid.Views.Grid;
using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblCustomer
    {
        public ClsTblCustomer()
        {
            Session.GetDataCustomers();
        }

        public List<tblCustomer> GetCustomersList() => Session.Customers;

        public List<tblCustomer> GetTblCustomerListByCurrencyId(byte curId)
        {
            return Session.Customers.Where(x => x.custCurrency == curId).ToList();
        }

        public tblCustomer GetCustomerObjById(int custId)
        {
            return Session.Customers.FirstOrDefault(x => x.id == custId);
        }

        public string GetCustomerNameById(int cstId)
        {
            return Session.Customers.FirstOrDefault(x => x.id == cstId)?.custName;
        }
        public string GetCustomerNameByAccNo(long accNo)
        {
            return Session.Customers.FirstOrDefault(x => x.custAccNo == accNo)?.custName;
        }

        public void InitCustomerRepositoryLookupEdit(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit custNoLookUp)
        {
            custNoLookUp.DataSource = Session.Customers.Where(x => x.custBrnId == Session.CurBranch.brnId);
            custNoLookUp.DisplayMember = "custNo";
            custNoLookUp.ValueMember = "custNo";

            custNoLookUp.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("custNo", "رقم العميل", 11, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("custName", "إسم العميل", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
        }
        public void InitCustomerRepositoryLookupEdit(DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit custNoLookUp, string ValueMember = "custNo", string DisplayMember = "custNo")
        {

            custNoLookUp.DataSource = Session.Customers.Where(x => x.custBrnId == Session.CurBranch.brnId);
            custNoLookUp.DisplayMember = DisplayMember;
            custNoLookUp.ValueMember = ValueMember;
            custNoLookUp.NullText = "";
            custNoLookUp.ValidateOnEnterKey = true;
            custNoLookUp.ImmediatePopup = true;
            custNoLookUp.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            custNoLookUp.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;

            var view = custNoLookUp.View;
            view.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
            view.OptionsSelection.UseIndicatorForSelection = true;
            view.OptionsView.ShowAutoFilterRow = true;
            view.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;

            view.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[]
            {
                new DevExpress.XtraGrid.Columns.GridColumn()
                {
                    FieldName = "custAccNo",
                    Caption =  "رقم الحساب",
                    Visible = true,
                    VisibleIndex = 1
                },
                new DevExpress.XtraGrid.Columns.GridColumn()
                {
                    FieldName = "custNo",
                    Caption =  "رقم العميل",
                    Visible = true,
                    VisibleIndex = 1
                },
                  new DevExpress.XtraGrid.Columns.GridColumn()
                {
                    FieldName = "custName",
                    Caption =  "إسم العميل",   Visible = true,
                    VisibleIndex = 1
                }
            });
        }
    }
}
