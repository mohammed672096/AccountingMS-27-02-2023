using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    class ClsTblCurrency
    {
        public ClsTblCurrency()
        {
            if (Session.Currencies.Count <= 0)
                Session.GetDataCurrencies();
        }
        public List<tblCurrency> GetCurrencyList => Session.Currencies;
        public string GetCurrencyNameById(byte curId)
        {
            if (curId < 1) return null;
            return Session.Currencies?.FirstOrDefault(x => x.id == curId)?.curName;
        }
        public string GetCurrencySignById(byte curId)
        {
            return Session.Currencies?.FirstOrDefault(x => x.id == curId)?.curSign;
        }

        public short GetCurrencyChangeById(byte curId)
        {
            return Convert.ToInt16(Session.Currencies?.FirstOrDefault(x => x.id == curId)?.curChange);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currencyLookupEdit"></param>
        /// <returns>First Currency</returns>
        public byte InitCurrencyLookupEdit(LookUpEdit currencyLookupEdit)
        {
            currencyLookupEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            currencyLookupEdit.Properties.Appearance.Options.UseTextOptions = true;
            currencyLookupEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            currencyLookupEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("curName", "Name1")});
            currencyLookupEdit.Properties.DataSource = Session.Currencies;
            currencyLookupEdit.Properties.DisplayMember = "curName";
            currencyLookupEdit.Properties.NullText = "";
            currencyLookupEdit.Properties.ShowHeader = false;
            currencyLookupEdit.Properties.ValueMember = "id";
            return FirstCurrency;
        }
        public byte FirstCurrency { get { return Session.Currencies.FirstOrDefault()?.id ?? 0; } }

    }
}
