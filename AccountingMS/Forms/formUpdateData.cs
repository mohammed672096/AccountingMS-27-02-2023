using DevExpress.DataProcessing;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.Design;
using Microsoft.PointOfService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formUpdateData : DevExpress.XtraEditors.XtraForm
    {
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblSupplyMain clsTbSupplyMain;
        ClsTblSupplySub clsTbSupplySub;

        log4net.ILog log = LogHelper.GetLogger();
        IList<tblStore> tbStoreList;
        IList<tblGroupStr> tbGroupList;

        public formUpdateData()
        {
            InitializeComponent();
            dateEditFixSupplyMainTotalToDt.EditValue = DateTime.Now;

            this.Load += FormUpdateData_Load;
        }

        private async void FormUpdateData_Load(object sender, EventArgs e)
        {
            await Task.Run(() => InitBranchData());
            textEditFromBranch.EditValue = Session.CurBranch.brnId;
            dateEditResetPrdQuanToDate.DateTime = DateTime.Now;
        }

        private void InitBranchData()
        {
            accountingEntities db = new accountingEntities();
            this.tbStoreList = db.tblStores.ToList();
            this.tbGroupList = db.tblGroupStrs.ToList();

            tblBranchBindingSource.DataSource = new ClsTblBranch().GetBranchList();
        }

        private void InitSupplyObjects()
        {
            this.clsTbSupplyMain = new ClsTblSupplyMain();
            this.clsTbSupplySub = new ClsTblSupplySub();
        }

        private bool BindUserId()
        {
            flyDialog.WaitForm(this, 1);
            InitSupplyObjects();

            foreach (var tbSupplyMain in this.clsTbSupplyMain.GetSupplyMainList)
                foreach (var tbSupplySub in this.clsTbSupplySub.GetSupplySubListBySupId(tbSupplyMain.id))
                    tbSupplySub.supUserId = tbSupplyMain.supUserId;

            flyDialog.WaitForm(this, 0);

            return this.clsTbSupplySub.SaveDB();
        }

        private void BtnBindSupplyUserId_Click(object sender, EventArgs e)
        {
            if (BindUserId()) DialogResult = DialogResult.OK;
        }

        private void BtnUpdateSupplyNo_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            InitSupplyObjects();
            UpdateSupplyData((byte)SupplyType.Purchase, (byte)SupplyType.PurchasePhase, (byte)SupplyType.PurchaseDel);
            UpdateSupplyData((byte)SupplyType.PurchaseRtrn, (byte)SupplyType.PurchasePhaseRtrn, (byte)SupplyType.PurchaseRtrnDel);
            UpdateSupplyData((byte)SupplyType.Sales, (byte)SupplyType.SalesPhase, (byte)SupplyType.SalesDel);
            UpdateSupplyData((byte)SupplyType.SalesRtrn, (byte)SupplyType.SalesPhaseRtrn, (byte)SupplyType.SalesRtrnDel);
            flyDialog.WaitForm(this, 0);

            if (this.clsTbSupplyMain.SaveDB()) DialogResult = DialogResult.OK;
        }

        private void btnUpdateSupplyNo0_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            InitSupplyObjects();
            UpdateSupplyData0((byte)SupplyType.Purchase, (byte)SupplyType.PurchasePhase, (byte)SupplyType.PurchaseDel);
            UpdateSupplyData0((byte)SupplyType.PurchaseRtrn, (byte)SupplyType.PurchasePhaseRtrn, (byte)SupplyType.PurchaseRtrnDel);
            UpdateSupplyData0((byte)SupplyType.Sales, (byte)SupplyType.SalesPhase, (byte)SupplyType.SalesDel);
            UpdateSupplyData0((byte)SupplyType.SalesRtrn, (byte)SupplyType.SalesPhaseRtrn, (byte)SupplyType.SalesRtrnDel);
            flyDialog.WaitForm(this, 0);

            if (this.clsTbSupplyMain.SaveDB()) DialogResult = DialogResult.OK;
        }

        private async void btnUpdateSupplyNoFrom_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);

            await Task.Run(() => this.clsTbSupplyMain = new ClsTblSupplyMain());
            int supNo = Convert.ToInt32(textEditSupplyNo.EditValue);

            await Task.Run(() => UpdateSupplyDataFrom((byte)SupplyType.Purchase, (byte)SupplyType.PurchasePhase, (byte)SupplyType.PurchaseDel, supNo));
            await Task.Run(() => UpdateSupplyDataFrom((byte)SupplyType.PurchaseRtrn, (byte)SupplyType.PurchasePhaseRtrn, (byte)SupplyType.PurchaseRtrnDel, supNo));
            await Task.Run(() => UpdateSupplyDataFrom((byte)SupplyType.Sales, (byte)SupplyType.SalesPhase, (byte)SupplyType.SalesDel, supNo));
            await Task.Run(() => UpdateSupplyDataFrom((byte)SupplyType.SalesRtrn, (byte)SupplyType.SalesPhaseRtrn, (byte)SupplyType.SalesRtrnDel, supNo));

            if (await Task.Run(() => this.clsTbSupplyMain.SaveDB())) DialogResult = DialogResult.OK;
            flyDialog.WaitForm(this, 0);
        }

        private void UpdateSupplyData(byte status1, byte status2, byte status3)
        {
            UpdateSupplyNo(InitSupplyData(1, status1, status2, status3));
            UpdateSupplyNo(InitSupplyData(2, status1, status2, status3));
        }

        private void UpdateSupplyData0(byte status1, byte status2, byte status3)
        {
            UpdateSupplyNo0(InitSupplyData(1, status1, status2, status3), 1, status1, status2, status3);
            UpdateSupplyNo0(InitSupplyData(2, status1, status2, status3), 2, status1, status2, status3);
        }

        private async Task UpdateSupplyDataFrom(byte status1, byte status2, byte status3, int supNo)
        {
            await Task.Run(() => UpdateSupplyNoFrom(InitSupplyData(1, status1, status2, status3), supNo));
            await Task.Run(() => UpdateSupplyNoFrom(InitSupplyData(2, status1, status2, status3), supNo));
        }

        private IEnumerable<IOrderedEnumerable<tblSupplyMain>> InitSupplyData(byte isCash, byte status1, byte status2, byte status3)
        {
            var tbSupplyMainList = this.clsTbSupplyMain.GetSupplyMainList.Where(x => x.supIsCash == isCash &&
                (x.supStatus == status1 || x.supStatus == status2 || x.supStatus == status3)).GroupBy(x => (isCash == 1) ? x.supAccNo : x.supIsCash)
                .Select(x => x.OrderBy(y => y.supDate)).ToList();
            return tbSupplyMainList;
        }

        private void UpdateSupplyNo(IEnumerable<IOrderedEnumerable<tblSupplyMain>> tbSupplyMainList)
        {
            foreach (var tbSupplyGroup in tbSupplyMainList)
                for (int i = 0; i < tbSupplyGroup.Count(); i++)
                    tbSupplyGroup.ElementAt(i).supNo = i + 1;
        }

        private async Task UpdateSupplyNoFrom(IEnumerable<IOrderedEnumerable<tblSupplyMain>> tbSupplyMainList, int supNo)
        {
            foreach (var tbSupplyGroup in tbSupplyMainList)
                foreach (var tbSupply in tbSupplyGroup.Where(x => x.supNo >= supNo).ToList())
                    await Task.Run(() => tbSupply.supNo = supNo++);
        }

        private void UpdateSupplyNo0(IEnumerable<IOrderedEnumerable<tblSupplyMain>> tbSupplyMainList, byte isCash, byte status1, byte status2, byte status3)
        {
            foreach (var tbSupplyGroup in tbSupplyMainList)
                for (int i = 0; i < tbSupplyGroup.Count(); i++)
                    if (tbSupplyGroup.ElementAt(i).supNo == 0)
                    {
                        int supNo = tbSupplyGroup.ElementAt(i - 1).supNo;

                        do supNo += 1;
                        while (this.clsTbSupplyMain.IsSupNoFound((isCash == 1 ? tbSupplyGroup.ElementAt(i).supAccNo : 0), status1, status2, supNo));

                        tbSupplyGroup.ElementAt(i).supNo = supNo;
                    }
        }

        private void BtnBindSupplyDiscount_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            BindDiscountInvoices();
            flyDialog.WaitForm(this, 0);

            if (this.clsTbSupplySub.SaveDB()) DialogResult = DialogResult.OK;
        }

        private void BindDiscountInvoices()
        {
            foreach (var tbSupplyMain in this.clsTbSupplyMain.GetSupplyMainListSale())
                if (tbSupplyMain.supDscntPercent > 0)
                    foreach (var tbSupplySub in this.clsTbSupplySub.GetSupplySubListBySupId(tbSupplyMain.id))
                        tbSupplySub.supDscntPercent = tbSupplyMain.supDscntPercent;
        }

        private void BtnReserPrdQuantity_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            bool save;
            using (var db = new accountingEntities())
            {
                save = db.ResetPrdQuan() > 0;
            }
            flyDialog.WaitForm(this, 0);
            if (save)
                DialogResult = DialogResult.OK;
        }

        private void BtnResetPrdPriceMsur_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            using (accountingEntities db = new accountingEntities())
            {
                bool sav = false;
                var tbPrdMsur = db.tblPrdPriceMeasurments.AsQueryable().Where(x => x.ppmBrnId == Session.CurBranch.brnId && string.IsNullOrWhiteSpace(x.ppmMsurName));
                if (tbPrdMsur != null)
                {
                    db.tblPrdPriceMeasurments.RemoveRange(tbPrdMsur);
                    ClsSaveDB.Save(db, LogHelper.GetLogger());
                    sav = true;
                }
                flyDialog.WaitForm(this, 0);
                if (sav) DialogResult = DialogResult.OK;
            }
        }

        private void BtnDeleteSupplyInvoicesTotal0_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            InitSupplyObjects();

            foreach (var tbSupplyMain in this.clsTbSupplyMain.GetSupplyMainList)
                if (tbSupplyMain.supTotal == 0)
                {
                    this.clsTbSupplyMain.DeleteVoid(tbSupplyMain);
                    this.clsTbSupplySub.DeleteRecordsBySupplyMainId(tbSupplyMain.id);
                }
            flyDialog.WaitForm(this, 0);
            DialogResult = DialogResult.OK;
        }

        private void btnAddPrdPriceQuan_Click(object sender, EventArgs e)
        {
            //flyDialog.WaitForm(this, 1);
            //ClsTblProductQunatity clsTbPrdQuant = new ClsTblProductQunatity();
            //ClsTblPrdPriceMeasurment clsTbPrdMsur = new ClsTblPrdPriceMeasurment();

            //if (!AddPrdPriceQuan1(clsTbPrdQuant, clsTbPrdMsur)) return;
            //if (!AddPrdPriceQuan2(clsTbPrdQuant, clsTbPrdMsur)) return;
            //if (!AddPrdPriceQuan3(clsTbPrdQuant, clsTbPrdMsur)) return;

            //DialogResult = DialogResult.OK;
            //flyDialog.WaitForm(this, 0);
        }

        //private bool AddPrdPriceQuan1(ClsTblProductQunatity clsTbPrdQuant, ClsTblPrdPriceMeasurment clsTbPrdMsur)
        //{
        //    ClsPrdPriceQuanOperations clsPrdPriceQuanOpr = new ClsPrdPriceQuanOperations(new ClsTblPrdPriceQuan(), clsTbPrdMsur);
        //    var tbPrdQuanList = new List<ClsProductQuantList>();

        //    foreach (var tbPrdQuan in clsTbPrdQuant.GetPrdQuantityList)
        //        tbPrdQuanList.Add(new ClsProductQuantList()
        //        {
        //            prdId = tbPrdQuan.prdId,
        //            prdPriceMsurId = clsTbPrdMsur.GetPrdPriceMsurIdByPrdIdNdStatus(tbPrdQuan.prdId, 1),
        //            prdPrice = clsTbPrdMsur.GetPrdPriceMsurPriceByPrdIdNdStatus(tbPrdQuan.prdId, 1),
        //            prdQuantity = Convert.ToDouble(tbPrdQuan.prdQuantity),
        //        });

        //    return clsPrdPriceQuanOpr.AddNewPrdQuantity(tbPrdQuanList);
        //}

        //private bool AddPrdPriceQuan2(ClsTblProductQunatity clsTbPrdQuant, ClsTblPrdPriceMeasurment clsTbPrdMsur)
        //{
        //    ClsPrdPriceQuanOperations clsPrdPriceQuanOpr = new ClsPrdPriceQuanOperations(new ClsTblPrdPriceQuan(), clsTbPrdMsur);
        //    var tbPrdQuanList = new List<ClsProductQuantList>();

        //    foreach (var tbPrdQuan in clsTbPrdQuant.GetPrdQuantityList)
        //        if (tbPrdQuan.prdSubQuantity > 0) tbPrdQuanList.Add(new ClsProductQuantList()
        //        {
        //            prdId = tbPrdQuan.prdId,
        //            prdPriceMsurId = clsTbPrdMsur.GetPrdPriceMsurIdByPrdIdNdStatus(tbPrdQuan.prdId, 2),
        //            prdPrice = clsTbPrdMsur.GetPrdPriceMsurPriceByPrdIdNdStatus(tbPrdQuan.prdId, 1),
        //            prdQuantity = Convert.ToDouble(tbPrdQuan.prdSubQuantity),
        //        });

        //    return clsPrdPriceQuanOpr.AddNewPrdQuantity(tbPrdQuanList);
        //}

        //private bool AddPrdPriceQuan3(ClsTblProductQunatity clsTbPrdQuant, ClsTblPrdPriceMeasurment clsTbPrdMsur)
        //{
        //    ClsPrdPriceQuanOperations clsPrdPriceQuanOpr = new ClsPrdPriceQuanOperations(new ClsTblPrdPriceQuan(), clsTbPrdMsur);
        //    var tbPrdQuanList = new List<ClsProductQuantList>();

        //    foreach (var tbPrdQuan in clsTbPrdQuant.GetPrdQuantityList)
        //        if (tbPrdQuan.prdSubQuantity3 > 0) tbPrdQuanList.Add(new ClsProductQuantList()
        //        {
        //            prdId = tbPrdQuan.prdId,
        //            prdPriceMsurId = clsTbPrdMsur.GetPrdPriceMsurIdByPrdIdNdStatus(tbPrdQuan.prdId, 3),
        //            prdPrice = clsTbPrdMsur.GetPrdPriceMsurPriceByPrdIdNdStatus(tbPrdQuan.prdId, 1),
        //            prdQuantity = Convert.ToDouble(tbPrdQuan.prdSubQuantity3),
        //        });

        //    return clsPrdPriceQuanOpr.AddNewPrdQuantity(tbPrdQuanList);
        //}

        private void btnUpdateAssetEntNo_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            ClsTblAsset clsTbAsset = new ClsTblAsset();
            ClsTblEntrySub clsTbEntSub = new ClsTblEntrySub();
            ClsTblSupplyMain clsTbSupplyMain = new ClsTblSupplyMain();

            foreach (var tbAsset in clsTbAsset.GetAssetList)
                if (tbAsset.asStatus >= 2 && tbAsset.asStatus <= 9) tbAsset.asEntNo = (tbAsset.asStatus) switch
                {
                    _ when tbAsset.asStatus <= 4 || tbAsset.asStatus == 9 => clsTbEntSub.GetEntNoById(tbAsset.asEntId),
                    _ when tbAsset.asStatus <= 8 => clsTbSupplyMain.GetSupplyNoById(tbAsset.asEntId),
                    _ => 0
                };

            if (clsTbAsset.Save) DialogResult = DialogResult.OK;
            flyDialog.WaitForm(this, 0);
        }

        private void btnUpdatePrdGrpNo_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            ClsTblProduct clsTbProduct = new ClsTblProduct();
            using (var db = new accountingEntities())
            {
                foreach (var tbProduct in db.tblProducts.Where(x => x.prdBrnId == Session.CurBranch.brnId))
                    if (int.TryParse(tbProduct.prdNo.Substring(0, tbProduct.prdNo.IndexOf("-")), out int prdGrpNo))
                        if (prdGrpNo != db.tblGroupStrs.FirstOrDefault(x => x.id == tbProduct.prdGrpNo)?.grpNo)
                            tbProduct.prdNo = clsTbProduct.GetNewProductdNo(tbProduct.prdGrpNo);
                if (ClsSaveDB.Save(db, LogHelper.GetLogger())) DialogResult = DialogResult.OK;
            }
            flyDialog.WaitForm(this, 0);
        }

        private void btnResetPrdNo_Click(object sender, EventArgs e)
        {
            //flyDialog.WaitForm(this, 1);
            //ClsTblGroupStr clsTbGroup = new ClsTblGroupStr();
            //ClsTblProduct clsTbProduct = new ClsTblProduct();

            //var tbPrdList = clsTbProduct.GetProductList;
            //for (short i = 0; i < tbPrdList.Count(); i++)
            //    tbPrdList.ElementAt(i).prdNo = $"{20000 + i}";

            //if (!clsTbProduct.SaveDB) return;

            //var tbPrdGroupList = tbPrdList.GroupBy(x => x.prdGrpNo, (key, grp) => grp.OrderBy(x => x.id)).ToList();
            //foreach (var tbPrdGroup in tbPrdGroupList)
            //    for (short i = 0; i < tbPrdGroup.Count(); i++)
            //        tbPrdGroup.ElementAt(i).prdNo = $"{clsTbGroup.GetGroupNoById(tbPrdGroup.ElementAt(i).prdGrpNo)}-{i + 1}";

            //if (!clsTbProduct.SaveDB) return;

            //ClsTblSupplySub clsTbSupplySub = new ClsTblSupplySub();
            //foreach (var tbSupplySub in clsTbSupplySub.GetSupplySubList)
            //    tbSupplySub.supPrdNo = clsTbProduct.GetPrdNoById(Convert.ToInt32(tbSupplySub.supPrdId));

            //if (clsTbSupplySub.SaveDB()) DialogResult = DialogResult.OK;
            //flyDialog.WaitForm(this, 0);

            flyDialog.WaitForm(this, 1);
            ClsTblGroupStr clsTbGroup = new ClsTblGroupStr();
            ClsTblProduct clsTbProduct = new ClsTblProduct();

            using (var db = new accountingEntities())
            {
                int i, g = 0;
                db.tblGroupStrs.AsNoTracking().Where(y => y.grpBrnId == Session.CurBranch.brnId).ForEach(y =>
                {
                    g = y.grpNo;
                    i = 1;
                    db.tblProducts.Where(x => x.prdBrnId == Session.CurBranch.brnId && x.prdGrpNo == y.id).ForEach(x =>
                    {
                        x.prdNo = $"{g}-{i}";
                        db.tblSupplySubs.Where(a => a.supPrdId == x.id).ForEach(a => a.supPrdNo = x.prdNo);
                        i++;
                    });
                });

                //ClsTblSupplySub clsTbSupplySub = new ClsTblSupplySub();
                //foreach (var tbSupplySub in clsTbSupplySub.GetSupplySubList)
                //    tbSupplySub.supPrdNo = clsTbProduct.GetPrdNoById(Convert.ToInt32(tbSupplySub.supPrdId));

                if (ClsSaveDB.Save(db, LogHelper.GetLogger())) DialogResult = DialogResult.OK;
            }
            flyDialog.WaitForm(this, 0);
        }

        private void btnFixSupplySubPrdPrice_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            ClsTblAsset clsTbAsset = new ClsTblAsset();
            ClsTblProduct clsTbProduct = new ClsTblProduct();
            ClsTblGroupStr clsTbGroup = new ClsTblGroupStr();
            ClsTblSupplySub clsTbSupplySub = new ClsTblSupplySub();
            ClsTblPrdPriceMeasurment clsTbPrdMsur = new ClsTblPrdPriceMeasurment();
            DateTime dt = dateEditFixSupplySubPrdPrice.DateTime.Date;
            int grpId;
            long grpCostAcc, grpCostRtrnAcc;

            var tbSupplySubList = clsTbSupplySub.GetSupplySubSalesNdRtrnList().Where(x => x.supDate >= dt).ToList();
            foreach (var tbSupplySub in tbSupplySubList)
            {
                if (clsTbProduct.IsServicePrd(Convert.ToInt32(tbSupplySub.supPrdId))) continue;
                tbSupplySub.supPrice = clsTbPrdMsur.GetPrdPriceMsutPriceById(Convert.ToInt32(tbSupplySub.supMsur));

                if (!clsTbAsset.IsSupplyIdFound(tbSupplySub.supNo)) continue;
                grpId = clsTbProduct.GetPrdGroupIdByPrdId(Convert.ToInt32(tbSupplySub.supPrdId));
                grpCostAcc = clsTbGroup.GetGroupCostAccNoById(grpId); grpCostRtrnAcc = clsTbGroup.GetGroupCostRtrnAccNoById(grpId);

                foreach (var tbAsset in clsTbAsset.GetAssetSupplyListByEntId(tbSupplySub.supNo))
                    if (tbAsset.asAccNo == tbSupplySub.supAccNo || tbAsset.asAccNo == grpCostAcc || tbAsset.asAccNo == grpCostRtrnAcc)
                        if (Convert.ToDouble(tbAsset.asDebit) > 0) tbAsset.asDebit = GetSupplyPrdAmount(tbSupplySub.supPrice, tbSupplySub.supQuanMain);
                        else if (Convert.ToDouble(tbAsset.asCredit) > 0) tbAsset.asCredit = GetSupplyPrdAmount(tbSupplySub.supPrice, tbSupplySub.supQuanMain);
            }

            if (clsTbSupplySub.SaveDB() && clsTbAsset.Save) DialogResult = DialogResult.OK;
            flyDialog.WaitForm(this, 0);
        }

        private double GetSupplyPrdAmount(double? supPrice, double? supQuanMain)
        {
            return Convert.ToDouble(supPrice) * Convert.ToDouble(supQuanMain);
        }

        private void btnAddSupplyMainData_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            accountingEntities db = new accountingEntities();
            var tbSupplyMainList = db.tblSupplyMains.ToList();

            for (short i = 0; i < 2; i++)
                foreach (var tbSupplyMain in tbSupplyMainList)
                    db.tblSupplyMains.Add(new tblSupplyMain()
                    {
                        supNo = tbSupplyMain.supNo,
                        supAccNo = tbSupplyMain.supAccNo,
                        supAccName = tbSupplyMain.supAccName,
                        supDesc = tbSupplyMain.supDesc,
                        supRefNo = tbSupplyMain.supRefNo,
                        supTotal = tbSupplyMain.supTotal,
                        supTaxPercent = tbSupplyMain.supTaxPercent,
                        supTaxPrice = tbSupplyMain.supTaxPrice,
                        supDscntAmount = tbSupplyMain.supDscntAmount,
                        supDscntPercent = tbSupplyMain.supDscntPercent,
                        supCurrency = tbSupplyMain.supCurrency,
                        supCurrencyChng = tbSupplyMain.supCurrencyChng,
                        supBankAmount = tbSupplyMain.supBankAmount,
                        supDate = tbSupplyMain.supDate,
                        supCustSplId = tbSupplyMain.supCustSplId,
                        supEqfal = tbSupplyMain.supEqfal,
                        supUserId = tbSupplyMain.supUserId,
                        supBrnId = tbSupplyMain.supBrnId,
                        supStatus = tbSupplyMain.supStatus,
                        supStrId = tbSupplyMain.supStrId,
                        supBankId = tbSupplyMain.supBankId,
                        supIsCash = tbSupplyMain.supIsCash,
                        supTotalFrgn = tbSupplyMain.supTotalFrgn,
                    });


            if (ClsSaveDB.Save(db, LogHelper.GetLogger())) DialogResult = DialogResult.OK;
            flyDialog.WaitForm(this, 1);
        }

        private void btnChangeEmpEntryCustNo_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);

            ClsTblEmployee clsTbEmployee = new ClsTblEmployee();
            ClsTblEntrySub clsTbEntrySub = new ClsTblEntrySub();

            foreach (var tbEntrySub in clsTbEntrySub.GetEntrySubList().Where(x => x.entStatus >= 9 && x.entStatus <= 12).ToList())
                if (Convert.ToInt32(tbEntrySub.entCusNo) > 0) tbEntrySub.entCusNo = clsTbEmployee.GetEmployeeIdByAccNo(Convert.ToInt64(tbEntrySub.entCusNo));

            if (clsTbEntrySub.SaveDB()) DialogResult = DialogResult.OK;
            flyDialog.WaitForm(this, 0);
        }

        private async void btnAddPrdQuanFromTblOpn_Click(object sender, EventArgs e)
        {
            //flyDialog.WaitForm(this, 1);

            //ClsTblProductQunatity clsTbPrdQuan = null;
            //ClsTblProductQtyOpn clsTbPrdQuanOpn = null;
            //ClsTblPrdPriceMeasurment clsTbPrdMsur = null;

            //IList<Task> taskList = new List<Task>();
            //taskList.Add(Task.Run(() => clsTbPrdQuan = new ClsTblProductQunatity()));
            //taskList.Add(Task.Run(() => clsTbPrdQuanOpn = new ClsTblProductQtyOpn()));
            //taskList.Add(Task.Run(() => clsTbPrdMsur = new ClsTblPrdPriceMeasurment()));
            //await Task.WhenAll(taskList);

            //foreach (var tbPrdQuanOpn in clsTbPrdQuanOpn.GetProductQtyOpnList)
            //{
            //    var tbPrdQuan = await Task.Run(() => clsTbPrdQuan.GetPrdQuantityObjByPrdId(tbPrdQuanOpn.qtyPrdId));
            //    byte msurStatus = await Task.Run(() => clsTbPrdMsur.GetPrdPriceMsurStatus(tbPrdQuanOpn.qtyPrdMsurId));

            //    await Task.Run(() =>
            //    {
            //        if (msurStatus == 1) tbPrdQuan.prdQuantity = tbPrdQuanOpn.qtyQuantity;
            //        else if (msurStatus == 2) tbPrdQuan.prdSubQuantity = tbPrdQuanOpn.qtyQuantity;
            //        else if (msurStatus == 3) tbPrdQuan.prdSubQuantity3 = tbPrdQuanOpn.qtyQuantity;
            //    });
            //}

            //if (await Task.Run(() => clsTbPrdQuan.Save)) DialogResult = DialogResult.OK;
            //flyDialog.WaitForm(this, 0);
        }

        private async void btnFixPrdQuanOpnPrice_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);

            using (var db=new accountingEntities())
            {
                foreach (var tbPrdQuanOpn in db.tblProductQtyOpns)
                    tbPrdQuanOpn.qtyPrice = (db.tblPrdPriceMeasurments.FirstOrDefault(x => x.ppmId == tbPrdQuanOpn.qtyPrdMsurId)?.ppmPrice) ?? 0;

                if (await Task.Run(() => ClsSaveDB.Save(db, LogHelper.GetLogger()))) DialogResult = DialogResult.OK;
            }
          
            flyDialog.WaitForm(this, 1);
        }

        private async void btnDeleteAssetPrdQuanOpn_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);

            ClsTblAsset clsTbAsset = null;
            await Task.Run(() => clsTbAsset = new ClsTblAsset());

            if (await Task.Run(() => clsTbAsset.DeleteAssetPrdQuanOpnAll())) DialogResult = DialogResult.OK;
            flyDialog.WaitForm(this, 0);
        }

        private async void btnAddAssetPrdQuanOpn_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);

            accountingEntities db = null;
            ClsTblGroupStr clsTbGroup = null;
            ClsTblProduct clsTbProduct = null;
            ClsTblProductQtyOpn clsTbPrdQuanOpn = null;

            IList<Task> taskList = new List<Task>();
            taskList.Add(Task.Run(() => db = new accountingEntities()));
            taskList.Add(Task.Run(() => clsTbGroup = new ClsTblGroupStr()));
            taskList.Add(Task.Run(() => clsTbProduct = new ClsTblProduct()));
            taskList.Add(Task.Run(() => clsTbPrdQuanOpn = new ClsTblProductQtyOpn()));
            await Task.WhenAll(taskList);

            foreach (var tbPrdQuanOpn in clsTbPrdQuanOpn.GetProductQtyOpnList)
            {
                int grpId = await Task.Run(() => clsTbProduct.GetPrdGroupIdByPrdId(tbPrdQuanOpn.qtyPrdId));

                await Task.Run(() => db.tblAssets.Add(new tblAsset()
                {
                    asEntId = tbPrdQuanOpn.qtyPrdMsurId,
                    asAccNo = clsTbGroup.GetGroupAccNoById(grpId),
                    asAccName = clsTbGroup.GetGroupNameById(grpId),
                    asDebit = (Convert.ToDouble(tbPrdQuanOpn.qtyQuantity) * tbPrdQuanOpn.qtyPrice),
                    asDate = tbPrdQuanOpn.qtyDate,
                    asBrnId = Session.CurBranch.brnId,
                    asUserId = Session.CurrentUser.id,
                    asView = 1,
                    asStatus = 10
                }));
            }

            if (await Task.Run(() => ClsSaveDB.Save(db, LogHelper.GetLogger()))) DialogResult = DialogResult.OK;
            flyDialog.WaitForm(this, 0);
        }

        private async void btnAddPrdPriceQuanFromPrdQuanOpn_Click(object sender, EventArgs e)
        {
            //flyDialog.WaitForm(this, 1);

            //ClsTblPrdPriceQuan clsTbPrdPrQuan = null;
            //ClsTblPrdPriceMeasurment clsTbPrdMsur = null;
            //ClsTblProductQtyOpn clsTbPrdQuanOpn = null;
            //ClsPrdPriceQuanOperations clsPrdPrQuanOpr = null;

            //IList<Task> taskList = new List<Task>();
            //taskList.Add(Task.Run(() => clsTbPrdPrQuan = new ClsTblPrdPriceQuan()));
            //taskList.Add(Task.Run(() => clsTbPrdMsur = new ClsTblPrdPriceMeasurment()));
            //taskList.Add(Task.Run(() => clsTbPrdQuanOpn = new ClsTblProductQtyOpn()));
            //await Task.WhenAll(taskList);
            //await Task.Run(() => clsPrdPrQuanOpr = new ClsPrdPriceQuanOperations(clsTbPrdPrQuan, clsTbPrdMsur));

            //var clsPrdQuanList = (from tbPrdQuanOpn in clsTbPrdQuanOpn.GetProductQtyOpnList
            //                      select new ClsProductQuantList()
            //                      {
            //                          prdId = tbPrdQuanOpn.qtyPrdId,
            //                          prdPrice = tbPrdQuanOpn.qtyPrice,
            //                          prdPriceMsurId = tbPrdQuanOpn.qtyPrdMsurId,
            //                          prdQuantity = tbPrdQuanOpn.qtyQuantity
            //                      }).ToList();

            //if (await Task.Run(() => clsPrdPrQuanOpr.AddNewPrdQuantity(clsPrdQuanList))) DialogResult = DialogResult.OK;
            //flyDialog.WaitForm(this, 0);
        }

        private async void btnUpdatePrdQuanNdPrdPrQuanFromSupplySub_Click(object sender, EventArgs e)
        {
            //flyDialog.WaitForm(this, 1);

            //ClsTblSupplySub clsTbSupplySub = null;
            //ClsTblPrdPriceQuan clsTbPrdPrQuan = null;
            //ClsTblPrdPriceMeasurment clsTbPrdMsur = null;
            //ClsPrdQuantityOperations clsPrdQuanOpr = null;
            //ClsPrdPriceQuanOperations clsPrdPrQuanOpr = null;

            //IList<Task> taskList = new List<Task>();
            //taskList.Add(Task.Run(() => clsTbSupplySub = new ClsTblSupplySub()));
            //taskList.Add(Task.Run(() => clsTbPrdPrQuan = new ClsTblPrdPriceQuan()));
            //taskList.Add(Task.Run(() => clsTbPrdMsur = new ClsTblPrdPriceMeasurment()));
            //taskList.Add(Task.Run(() => clsPrdQuanOpr = new ClsPrdQuantityOperations()));
            //await Task.WhenAll(taskList);
            //await Task.Run(() => clsPrdPrQuanOpr = new ClsPrdPriceQuanOperations(clsTbPrdPrQuan, clsTbPrdMsur));

            //var clsPrdQuanAddList = InitPrdQuanList(clsTbSupplySub, (byte)SupplyType.Purchase, (byte)SupplyType.PurchasePhase, (byte)SupplyType.SalesRtrn, (byte)SupplyType.SalesPhaseRtrn);
            //var clsPrdQuanDeductList = InitPrdQuanList(clsTbSupplySub, (byte)SupplyType.PurchaseRtrn, (byte)SupplyType.PurchasePhaseRtrn, (byte)SupplyType.Sales, (byte)SupplyType.SalesPhase);

            //if (await Task.Run(() => clsPrdQuanOpr.AddPrdQuantity(clsPrdQuanAddList) && clsPrdPrQuanOpr.AddNewPrdQuantity(clsPrdQuanAddList) && clsPrdQuanOpr.DeductPrdQuantity(clsPrdQuanDeductList) && clsPrdPrQuanOpr.DeductPrdQuantity(clsPrdQuanDeductList)))
            //    DialogResult = DialogResult.OK;

            //flyDialog.WaitForm(this, 0);
        }

        private IList<ClsProductQuantList> InitPrdQuanList(ClsTblSupplySub clsTbSupplySub, byte status1, byte status2, byte status3, byte status4)
        {
            return (from tbSupplySub in clsTbSupplySub.GetSupplySubList
                    where tbSupplySub.supStatus == status1 || tbSupplySub.supStatus == status2 || tbSupplySub.supStatus == status3 || tbSupplySub.supStatus == status4
                    select new ClsProductQuantList()
                    {
                        prdId = Convert.ToInt32(tbSupplySub.supPrdId),
                        prdPrice = Convert.ToDouble(tbSupplySub.supPrice),
                        prdPriceMsurId = Convert.ToInt32(tbSupplySub.supMsur),
                        prdQuantity = Convert.ToDouble(tbSupplySub.supQuanMain),
                        prdStrId = MySetting.DefaultSetting.defaultStrId
                    }).ToList();
        }

        private async void btnFixEntryStatus_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);

            ClsTblEntryMain clsTbEntMain = null;
            ClsTblEntrySub clsTbEntSub = null;

            IList<Task> taskList = new List<Task>();
            taskList.Add(Task.Run(() => clsTbEntMain = new ClsTblEntryMain()));
            taskList.Add(Task.Run(() => clsTbEntSub = new ClsTblEntrySub()));
            await Task.WhenAll(taskList);

            foreach (var tbEntMain in clsTbEntMain.GetEntMainList().Where(x => x.entStatus <= 6).ToList())
            {
                byte status1 = tbEntMain.entStatus;
                byte status2 = (tbEntMain.entStatus) switch { 1 => 4, 2 => 5, 3 => 6, 4 => 1, 5 => 2, 6 => 3 };
                var tbEntSubList = await Task.Run(() => clsTbEntSub.GetEntrySubList().Where(x => x.entBoxNo == tbEntMain.entBoxNo && x.entNo == tbEntMain.entNo && (x.entStatus == status1 || x.entStatus == status2)).ToList());

                foreach (var tbEntSub in tbEntSubList) tbEntSub.entStatus = tbEntMain.entStatus;
            }

            if (await Task.Run(() => clsTbEntSub.SaveDB())) DialogResult = DialogResult.OK;
            flyDialog.WaitForm(this, 1);
        }

        private async void btnResetPrdPriceQuan_Click(object sender, EventArgs e)
        {
            //flyDialog.WaitForm(this, 1);

            //await new ClsResetPrdPriceQuan().ResetPriceQuan();

            //DialogResult = DialogResult.OK;
            //flyDialog.WaitForm(this, 0);
        }

        private void btnRestorePrdQuantity_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            using (var db=new accountingEntities())
            {
                db.CalculatePrdQuan();
               Session.GetDataProductQunatities();
            }
            flyDialog.WaitForm(this, 0);
            DialogResult = DialogResult.OK;
        }

        private async void btnFixSupplyMainTotal_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);

            ClsTblSupplyMain clsTbSupplyMain = null;
            await Task.Run(() => clsTbSupplyMain = new ClsTblSupplyMain());

            DateTime dtFrm = dateEditFixSupplyMainTotalFrmDt.DateTime.Date;
            DateTime dtTo = dateEditFixSupplyMainTotalToDt.DateTime.Date;
            using (var db=new accountingEntities())
            {
                foreach (var tbSupplyMain in clsTbSupplyMain.GetSupplyMainListSaleByDtStartEnd(dtFrm, dtTo))
                {
                    var sup = db.tblSupplyMains.FirstOrDefault(x => x.id == tbSupplyMain.id);
                    sup.supTotal += Convert.ToDouble(sup.supDscntAmount);
                    await Task.Run(() => tbSupplyMain.supTotal += Convert.ToDouble(tbSupplyMain.supDscntAmount));
                }
                if (await Task.Run(() => !ClsSaveDB.Save(db, LogHelper.GetLogger()))) return;
            }
            flyDialog.WaitForm(this, 0);
            DialogResult = DialogResult.OK;
        }

        private async void btnAddTblProductQuantityData_Click(object sender, EventArgs e)
        {
            //flyDialog.WaitForm(this, 1);

            //bool isFound;
            //ClsTblProduct clsTbProduct = null;
            //ClsTblProductQunatity clsTbPrdQuan = null;

            //IList<Task> taskList = new List<Task>();
            //taskList.Add(Task.Run(() => clsTbProduct = new ClsTblProduct()));
            //taskList.Add(Task.Run(() => clsTbPrdQuan = new ClsTblProductQunatity()));
            //await Task.WhenAll(taskList);


            //await Task.Run(() =>
            //{
            //    clsTbProduct.GetProductList.ForEach(x =>
            //    {
            //        isFound = clsTbPrdQuan.IsPrdQuantityFound(x.id);

            //        if (!isFound)
            //            clsTbPrdQuan.Add(new tblProductQunatity()
            //            {
            //                prdId = x.id,
            //                prdBrnId = x.prdBrnId,
            //                prdStrId = MySetting.DefaultSetting.defaultStrId,
            //                prdQuantity = 0,
            //                prdSubQuantity = 0,
            //                prdSubQuantity3 = 0,
            //                prdStatus = 1
            //            });
            //    });
            //});

            //if (await Task.Run(() => clsTbPrdQuan.Save)) DialogResult = DialogResult.OK;
            //flyDialog.WaitForm(this, 1);
        }

        private async void btnCopyProductsDataBranch_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            if (!ValidateBranchData(out short brnTo, out short brnFrom, out short strId, out int grpId)) return;

            IList<tblProduct> tbProductList = new List<tblProduct>();
            IList<tblPrdPriceMeasurment> tbPrdMsurList = null;

            accountingEntities db = new accountingEntities();

            tbProductList = db.tblProducts.Where(x => x.prdBrnId == brnFrom).ToList();
            tbPrdMsurList = db.tblPrdPriceMeasurments.Where(x => x.ppmBrnId == brnFrom).ToList();

            IList<tblProduct> tbProductTmpList = new List<tblProduct>();

            await Task.Run(() =>
            {
                tbProductList.ForEach(x =>
                {
                    var tbPrd = x.ShallowCopy();
                    tbPrd.prdGrpNo = grpId;
                    tbPrd.prdBrnId = brnTo;
                    tbProductTmpList.Add(tbPrd);
                });
            });

            db.tblProducts.AddRange(tbProductTmpList);
            if (await Task.Run(() => !ClsSaveDB.Save(db, LogHelper.GetLogger()))) return;

            int prdCount = 0;
            await Task.Run(() =>
            {
                var tbProductListNew = db.tblProducts.Where(x => x.prdBrnId == brnTo).ToList();
                IList<tblProductQunatity> tbPrdQuanTmp = new List<tblProductQunatity>();
                IList<tblPrdPriceMeasurment> tbPrdMsurTmpList = new List<tblPrdPriceMeasurment>();

                tbProductListNew.ForEach(x =>
                {
                    ++prdCount;

                    int prdId = tbProductList.Where(y => y.prdNo == x.prdNo).Select(y => y.id).FirstOrDefault();
                    x.prdNo = $"{this.grpNo}-{prdCount}";

                    var tbPrdQuan = new tblProductQunatity()
                    {
                        prdId = x.id,
                        prdStrId = strId,
                        prdBrnId = brnTo,
                        prdQuantity = 0,
                        prdSubQuantity = 0,
                        prdSubQuantity3 = 0,
                        prdStatus = x.prdStatus
                    };
                    tbPrdQuanTmp.Add(tbPrdQuan);

                    foreach (var tbPrdMsurTmp in tbPrdMsurList.Where(y => y.ppmPrdId == prdId).ToList())
                    {
                        var tbPrdMsur = tbPrdMsurTmp.ShallowCopy();
                        tbPrdMsur.ppmPrdId = x.id;
                        tbPrdMsur.ppmBrnId = brnTo;
                        db.tblPrdPriceMeasurments.Add(tbPrdMsur);
                        db.SaveChanges();
                        var barcode = db.tblBarcode.Where(x => x.brcPrdMsurId == tbPrdMsurTmp.ppmId).ToList();
                        foreach (var item in barcode)
                        {
                            item.brcPrdMsurId = tbPrdMsur.ppmId;
                            item.brcBrnId = tbPrdMsur.ppmBrnId.Value;
                            db.tblBarcode.Add(item);
                            db.SaveChanges();

                        }
                    }
                });
                // db.tblPrdPriceMeasurments.AddRange(tbPrdMsurTmpList);
                db.tblProductQunatities.AddRange(tbPrdQuanTmp);
            });
            db.SaveChanges();

            if (await Task.Run(() => ClsSaveDB.Save(db, LogHelper.GetLogger()))) DialogResult = DialogResult.OK;
            flyDialog.WaitForm(this, 0);
        }

        private bool ValidateBranchData(out short brnTo, out short brnFrom, out short strId, out int grpId)
        {
            strId = 0;
            grpId = 0;
            brnFrom = 0;

            bool isValid = (!short.TryParse(textEditToBranch.EditValue.ToString(), out brnTo) || brnTo == 0) ||
                (!short.TryParse(textEditFromBranch.EditValue.ToString(), out brnFrom) || brnFrom == 0) ||
                (!short.TryParse(textEditStrId.EditValue.ToString(), out strId) || strId == 0) ||
                (!int.TryParse(textEditGrpId.EditValue.ToString(), out grpId) || grpId == 0) ? false : true;

            if (!isValid)
            {
                flyDialog.WaitForm(this, 0);
                ClsXtraMssgBox.ShowError("يجب تحديد خانت من فرع، إلى فرع، إلى مخزن، إلى مجموعه أولاً!");
            }

            return isValid;
        }

        private void textEditToBranch_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;

            short brnId = Convert.ToInt16(editor.EditValue);

            tblStoreBindingSource.DataSource = this.tbStoreList.Where(x => x.strBrnId == brnId).ToList();
            tblGroupStrBindingSource.DataSource = this.tbGroupList.Where(x => x.grpBrnId == brnId).ToList();
        }

        private int grpNo;
        private void textEditGrpId_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;

            var tbGroup = editor?.GetSelectedDataRow() as tblGroupStr;
            this.grpNo = tbGroup.grpNo;
        }

        private async void btnLinkAccountsWithBranch_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            accountingEntities db = new accountingEntities();

            var tbAccountLIst = await Task.Run(() => db.tblAccounts.ToList());
            //var tbAccountLIst = await Task.Run(() => db.tblAccounts.Where(x => x.accType == 2).ToList());

            await Task.Run(() =>
            {
                tbAccountLIst.ForEach(x =>
                {
                    x.accBrnId = Session.CurBranch.brnId;
                });
            });

            if (await Task.Run(() => ClsSaveDB.Save(db, LogHelper.GetLogger()))) DialogResult = DialogResult.OK;
            flyDialog.WaitForm(this, 0);
        }

        private async void btnLinkDfltAccountsWithBrnId_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            accountingEntities db = new accountingEntities();

            var tbDfltAccount = await Task.Run(() => db.tblDefaultAccounts.ToList());

            await Task.Run(() =>
            {
                tbDfltAccount.ForEach(x =>
                {
                    x.dfltBrnId = Session.CurBranch.brnId;
                });
            });

            if (await Task.Run(() => ClsSaveDB.Save(db, LogHelper.GetLogger()))) DialogResult = DialogResult.OK;
            flyDialog.WaitForm(this, 0);
        }

        private async void btnResetTblPrdPriceQuan_Click(object sender, EventArgs e)
        {
            //flyDialog.WaitForm(this, 1);

            //IList<Task> taskList = new List<Task>();
            //ClsTblPrdPriceQuan clsTbPrdPriceQuan = null;

            //taskList.Add(Task.Run(() => clsTbPrdPriceQuan = new ClsTblPrdPriceQuan()));
            //await Task.WhenAll(taskList);

            //await Task.Run(() =>
            //{
            //    clsTbPrdPriceQuan.GetPrdPiceQuanList.ForEach(x =>
            //    {
            //        x.prQuantity1 = 0;
            //        x.prQuantity2 = 0;
            //        x.prQuantity3 = 0;
            //    });
            //});

            //if (await Task.Run(() => clsTbPrdPriceQuan.SaveDB)) DialogResult = DialogResult.OK;
            //flyDialog.WaitForm(this, 0);
        }

        private void btnOpenCashDrawer_Click(object sender, EventArgs e)
        {
            CashDrawer myCashDrawer;
            PosExplorer explorer;

            try
            {
                explorer = new PosExplorer(this);
                DeviceInfo ObjDevicesInfo = explorer.GetDevice("CashDrawer");
                myCashDrawer = (CashDrawer)explorer.CreateInstance(ObjDevicesInfo);

                myCashDrawer.Open();
                myCashDrawer.Claim(1000);
                myCashDrawer.DeviceEnabled = true;
                myCashDrawer.OpenDrawer();
                myCashDrawer.DeviceEnabled = false;
                myCashDrawer.Release();
                myCashDrawer.Close();
            }
            catch (Exception ex)
            {
                ClsXtraMssgBox.ShowError(ex.Message);
            }
        }

        private void btnOpenCashDrawer2_Click(object sender, EventArgs e)
        {
            PosExplorer myExplorer;
            CashDrawer myCashDrawer;

            try
            {
                myExplorer = new PosExplorer(this);
                DeviceInfo device = myExplorer.GetDevice("CashDrawer", "WASPCD");
                myCashDrawer = (CashDrawer)myExplorer.CreateInstance(device);

                myCashDrawer.Open();
                myCashDrawer.Claim(1000);
                myCashDrawer.DeviceEnabled = true;
                myCashDrawer.OpenDrawer();
                myCashDrawer.DeviceEnabled = false;
                myCashDrawer.Release();
                myCashDrawer.Close();
            }
            catch (Exception ex)
            {
                ClsXtraMssgBox.ShowError(ex.Message);
            }
        }

        private async void btnInvoicesFromBrnToBrn_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            if (!ValidateInvoiceData(out short brnTo, out short brnFrom, out int invNo)) return;

            accountingEntities db = new accountingEntities();
            IList<Task> taskList = new List<Task>();
            IList<tblSupplyMain> tbSupplyMainList = null;
            IList<tblSupplyMain> tbSupplyMainListBrnTo = null;
            IList<tblSupplySub> tbSupplySubList = null;

            await (Task.Run(() => tbSupplyMainList = db.tblSupplyMains.Where(x => x.supBrnId == brnFrom &&
                (x.supStatus == 4 || x.supStatus == 8)).ToList()));
            await (Task.Run(() => tbSupplySubList = db.tblSupplySubs.Where(x => x.supBrnId == brnFrom &&
                (x.supStatus == 4 || x.supStatus == 8)).ToList()));
            await (Task.Run(() => tbSupplyMainListBrnTo = db.tblSupplyMains.Where(x => x.supBrnId == brnTo &&
                (x.supStatus == 4 || x.supStatus == 8)).ToList()));
            Console.WriteLine("============beforeWhenAll");
            Console.WriteLine("============AfterWhenAll");


            int invNoMax = (tbSupplyMainListBrnTo.Count > 0) ? tbSupplyMainListBrnTo.Max(x => x.supNo) : 0;
            invNo = (invNoMax > invNo) ? invNoMax + 10 : invNo;
            int invNoTmp = invNo;
            //invNo = ((int)invNoMax > invNo) ? (int)invNoMax + 10 : invNo;
            Console.WriteLine($"=========invNoMax = {invNoMax}, invNo = {invNo}");

            IList<tblSupplyMain> tbSupplyMainListTmp = new List<tblSupplyMain>();

            await Task.Run(() =>
            {
                tbSupplyMainList.ForEach(x =>
                {
                    var tbSupplyMain = x.ShallowCopy();
                    tbSupplyMain.supNo = invNo++;
                    tbSupplyMain.supBrnId = brnTo;

                    tbSupplyMainListTmp.Add(tbSupplyMain);
                });
            });

            db.tblSupplyMains.AddRange(tbSupplyMainListTmp);
            if (await Task.Run(() => !ClsSaveDB.Save(db, LogHelper.GetLogger()))) return;

            db = new accountingEntities();
            var tbSupplyMainList2 = db.tblSupplyMains.Where(x => x.supBrnId == brnTo && x.supNo >= invNoTmp &&
                (x.supStatus == 4 || x.supStatus == 8)).ToList();

            int count = 0;
            IList<tblSupplySub> tbSupplySubListTmp = new List<tblSupplySub>();

            await Task.Run(() =>
            {
                tbSupplyMainList2.ForEach(x =>
                {
                    var tbSupplyMainOld = tbSupplyMainList.ElementAt(count);

                    tbSupplySubList.Where(y => y.supNo == tbSupplyMainOld.id).ForEach(z =>
                    {
                        var tbSupplySub = z.ShallowCopy();
                        tbSupplySub.supNo = x.id;
                        tbSupplySub.supBrnId = brnTo;

                        tbSupplySubListTmp.Add(tbSupplySub);
                    });

                    ++count;
                });
            });

            db.tblSupplySubs.AddRange(tbSupplySubListTmp);
            if (await Task.Run(() => !ClsSaveDB.Save(db, LogHelper.GetLogger()))) return;

            DialogResult = DialogResult.OK;
            flyDialog.WaitForm(this, 0);
        }

        private bool ValidateInvoiceData(out short brnTo, out short brnFrom, out int invNo)
        {
            brnTo = 0;
            brnFrom = 0;
            invNo = 0;

            bool isValid = (!short.TryParse(textEditFromBranchInv.EditValue.ToString(), out brnFrom) || brnFrom == 0) ||
                (!short.TryParse(textEditToBranchInv.EditValue.ToString(), out brnTo) || brnTo == 0) ||
                (!int.TryParse(textEditInvNo.EditValue.ToString(), out invNo) || invNo == 0) ? false : true;

            if (!isValid)
            {
                flyDialog.WaitForm(this, 0);
                ClsXtraMssgBox.ShowError("يجب تحديد خانت من فرع، إلى فرع، ورقم الفاتورة أولاً!");
            }

            return isValid;
        }



        private async void btnCopyAccounts_Click(object sender, EventArgs e)
        {
            short brnTo = 0;
            short brnFrom = 0;
            if (string.IsNullOrWhiteSpace(lkpFromBranch.Text) || string.IsNullOrWhiteSpace(lkpToBranch.Text))
            {
                ClsXtraMssgBox.ShowError("يجب تحديد خانت من فرع، إلى فرع!");
                return;
            }
            flyDialog.WaitForm(this, 1);
            if (short.TryParse(lkpFromBranch.EditValue.ToString(), out brnFrom) && short.TryParse(lkpToBranch.EditValue.ToString(), out brnTo)) { }
            {
                accountingEntities db = new accountingEntities();
                IList<tblAccount> tbAccountList = null;

                await Task.Run(() => tbAccountList = db.tblAccounts.Where(x => x.accBrnId == brnFrom).ToList());

                try
                {
                    await Task.Run(() =>
                    {
                        tbAccountList.ForEach(x =>
                        {
                            var tbAccount = x.ShallowCopy();
                            tbAccount.accBrnId = brnTo;

                            db.tblAccounts.Add(tbAccount);
                        });
                    });
                }
                catch (Exception ex)
                {
                    ClsXtraMssgBox.ShowError(ex.Message);
                }

                if (await Task.Run(() => ClsSaveDB.Save(db, LogHelper.GetLogger()))) DialogResult = DialogResult.OK;
            }
            flyDialog.WaitForm(this, 0);

        }

        private async void btnResetSupplyDates_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);

            accountingEntities db = new accountingEntities();
            IList<tblSupplyMain> tbSupplyMain = null;
            IList<tblSupplySub> tbSupplySub = null;

            await Task.Run(() => tbSupplyMain = db.tblSupplyMains.Where(x => x.supDate < new DateTime(2020, 7, 1) &&
                (x.supStatus == 4 || x.supStatus == 8)).OrderBy(x => x.supBrnId).ThenBy(x => x.supDate).ToList());
            await Task.Run(() => tbSupplySub = db.tblSupplySubs.ToList());

            int count = 1;
            int listCount = tbSupplyMain.Count();
            double taxTmp = 0;

            await Task.Run(() =>
            {
                tbSupplyMain.ForEach(x =>
                {
                    taxTmp = 0;

                    tbSupplySub.Where(y => y.supNo == x.id).ForEach(z =>
                    {
                        if (Convert.ToByte(z.supTaxPercent) > 0)
                        {
                            z.supTaxPercent = 5;
                            z.supTaxPrice = z.supSalePrice * Convert.ToDouble(z.supQuanMain);
                            z.supTaxPrice = z.supTaxPrice != 0 ? Math.Round((double)z.supTaxPrice * (double)0.05, 2,
                                MidpointRounding.AwayFromZero) : 0;

                            taxTmp += (double)z.supTaxPrice;
                        }
                    });

                    x.supTaxPrice = taxTmp != 0 ? taxTmp : 0;
                    x.supTaxPercent = taxTmp != 0 ? (byte)5 : (byte)0;

                    ClsSaveDB.Save(db, this.log);

                    log.Debug($"{count:#,#} - {listCount:#,#}");
                    count++;
                });
            });

            DialogResult = DialogResult.OK;
            flyDialog.WaitForm(this, 0);
        }

        private async void btnCopyAndDelInv_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);

            accountingEntities db = new accountingEntities();
            IList<Task> taskList = new List<Task>();
            IList<tblSupplyMain> tbSupplyMainListTmp1 = null;
            IList<tblSupplySub> tbSupplySubListTmp1 = null;
            IList<tblSupplyMain> tbSupplyMainList = new List<tblSupplyMain>();
            IList<tblSupplySub> tbSupplySubList = new List<tblSupplySub>();

            await (Task.Run(() => tbSupplyMainListTmp1 = db.tblSupplyMains.Where(x => x.supBrnId == 1 &&
                 x.supDate < new DateTime(2020, 10, 9) && (x.supStatus == 4 || x.supStatus == 8)).OrderBy(x => x.supNo).ToList()));
            await (Task.Run(() => tbSupplySubListTmp1 = db.tblSupplySubs.Where(x => x.supBrnId == 1 &&
                 x.supDate < new DateTime(2020, 10, 9) && (x.supStatus == 4 || x.supStatus == 8)).ToList()));

            await Task.Run(() =>
            {
                tbSupplyMainListTmp1.ForEach(x =>
                {
                    tbSupplyMainList.Add(x.ShallowCopy());
                });

                tbSupplySubListTmp1.ForEach(x =>
                {
                    tbSupplySubList.Add(x.ShallowCopy());
                });
            });

            this.log.Debug($"tbSupplyMainListCount = {tbSupplyMainList.Count}, tbSupplySubListCount  = {tbSupplySubList.Count}");
            var tbSupplyTmp = tbSupplyMainListTmp1.Max(x => x.supNo);
            int invNo = 1;
            DateTime dateTmp = new DateTime(2020, 4, 20, 9, 00, 00);
            DateTime dateTmp2 = dateTmp;
            IList<tblSupplyMain> tbSupplyMainListTmp = new List<tblSupplyMain>();

            double taxPercent = 0;
            DateTime dateTax = new DateTime(2020, 7, 1);

            await Task.Run(() =>
            {
                tbSupplyMainList.ForEach(x =>
                {
                    var tbSupplyMain = x.ShallowCopy();
                    tbSupplyMain.supNo = invNo;
                    tbSupplyMain.supDate = dateTmp;
                    tbSupplyMain.supBrnId = 1;

                    taxPercent = dateTmp < dateTax ? (double)0.05 : (double)0.15;
                    tbSupplyMain.supTaxPercent = Convert.ToByte(taxPercent * 100);
                    tbSupplyMain.supTaxPrice = x.supTotal - Convert.ToDouble(x.supDscntAmount);
                    tbSupplyMain.supTaxPrice = tbSupplyMain.supTaxPrice != 0 ? Math.Round((double)tbSupplyMain.supTaxPrice
                        * taxPercent, 2, MidpointRounding.AwayFromZero) : 0;

                    tbSupplyMainListTmp.Add(tbSupplyMain);

                    ++invNo;
                    dateTmp = dateTmp.AddMinutes(3.6);
                });
            });

            this.log.Debug("FinishedAddSupplyMainToList");

            db.tblSupplyMains.RemoveRange(tbSupplyMainListTmp1);
            this.log.Debug("FinishedRemoveSupplyMainRange");
            db.tblSupplySubs.RemoveRange(tbSupplySubListTmp1);
            this.log.Debug("FinishedRemoveSupplySubRange");

            db.tblSupplyMains.AddRange(tbSupplyMainListTmp);
            this.log.Debug("FinishedAddSupplyMainListToDB");

            if (await Task.Run(() => !ClsSaveDB.Save(db, LogHelper.GetLogger()))) return;
            this.log.Debug("FinishedSaveSupplyMainToDB");

            db = new accountingEntities();
            var tbSupplyMainList2 = db.tblSupplyMains.Where(x => x.supBrnId == 1 && x.supDate < new DateTime(2020, 10, 9)
                 && (x.supStatus == 4 || x.supStatus == 8)).ToList();

            this.log.Debug($"tbSupplyMain2ListCount = {tbSupplyMainList2.Count}, tbSupplyMainListCount = {tbSupplyMainList.Count}, tbSupplySubListCount  = {tbSupplySubList.Count}");
            int count = 0;
            IList<tblSupplySub> tbSupplySubListTmp = new List<tblSupplySub>();

            await Task.Run(() =>
            {
                tbSupplyMainList2.ForEach(x =>
                {
                    var tbSupplyMainOld = tbSupplyMainList[count];

                    tbSupplySubList.Where(y => y.supNo == tbSupplyMainOld.id).ForEach(z =>
                    {
                        var tbSupplySub = z.ShallowCopy();
                        tbSupplySub.supNo = x.id;
                        tbSupplySub.supDate = Convert.ToDateTime(x.supDate).Date;
                        tbSupplySub.supBrnId = 1;

                        taxPercent = x.supDate < dateTax ? (double)0.05 : (double)0.15;
                        tbSupplySub.supTaxPercent = Convert.ToByte(taxPercent * 100);
                        tbSupplySub.supTaxPrice = z.supSalePrice * Convert.ToDouble(z.supQuanMain);
                        tbSupplySub.supTaxPrice = tbSupplySub.supTaxPrice != 0 ? Math.Round((double)tbSupplySub.supTaxPrice *
                            taxPercent, 2, MidpointRounding.AwayFromZero) : 0;

                        tbSupplySubListTmp.Add(tbSupplySub);
                    });

                    ++count;
                });
            });
            this.log.Debug("FinishedAddSupplySubToList");

            db.tblSupplySubs.AddRange(tbSupplySubListTmp);
            this.log.Debug("FinishedAddSupplySubListToDB");

            if (await Task.Run(() => !ClsSaveDB.Save(db, LogHelper.GetLogger()))) return;
            this.log.Debug("FinishedSaveSupplySubToDB");

            DialogResult = DialogResult.OK;
            flyDialog.WaitForm(this, 0);
        }

        private async void BtnCopySupplyRandom_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            if (!ValidateInvoiceData(out short brnTo, out short brnFrom, out int invNo)) return;

            accountingEntities db = new accountingEntities();
            IList<Task> taskList = new List<Task>();
            IList<tblSupplyMain> tbSupplyMainList = null;
            IList<tblSupplyMain> tbSupplyMainListBrnTo = null;
            IList<tblSupplySub> tbSupplySubList = null;
            Random rnd = new Random();

            await (Task.Run(() => tbSupplyMainList = db.tblSupplyMains.Where(x => x.supBrnId == brnFrom &&
                x.supDate < new DateTime(2020, 10, 9) && (x.supStatus == 4 || x.supStatus == 8)).ToList()));
            await (Task.Run(() => tbSupplySubList = db.tblSupplySubs.Where(x => x.supBrnId == brnFrom &&
                (x.supStatus == 4 || x.supStatus == 8)).ToList()));
            await (Task.Run(() => tbSupplyMainListBrnTo = db.tblSupplyMains.Where(x => x.supBrnId == brnTo &&
                (x.supStatus == 4 || x.supStatus == 8)).ToList()));

            int count1 = tbSupplyMainList.Count;
            while (count1 > 1)
            {
                count1--;
                int k = rnd.Next(count1 + 1);
                var tbmp = tbSupplyMainList[k];
                tbSupplyMainList[k] = tbSupplyMainList[count1];
                tbSupplyMainList[count1] = tbmp;
            }

            IList<tblSupplyMain> tbSupplyMainListTmp = new List<tblSupplyMain>();
            int invNoTmp = 1;
            DateTime dateTmp = new DateTime(2020, 4, 20, 9, 00, 00);
            double taxPercent = 0;
            DateTime dateTax = new DateTime(2020, 7, 1);

            await Task.Run(() =>
            {
                tbSupplyMainList.ForEach(x =>
                {
                    var tbSupplyMain = x.ShallowCopy();
                    tbSupplyMain.supNo = invNoTmp++;
                    tbSupplyMain.supDate = dateTmp;
                    tbSupplyMain.supBrnId = brnTo;

                    taxPercent = dateTmp < dateTax ? (double)0.05 : (double)0.15;
                    tbSupplyMain.supTaxPercent = Convert.ToByte(taxPercent * 100);
                    tbSupplyMain.supTaxPrice = x.supTotal - Convert.ToDouble(x.supDscntAmount);
                    tbSupplyMain.supTaxPrice = tbSupplyMain.supTaxPrice != 0 ? Math.Round((double)tbSupplyMain.supTaxPrice
                        * taxPercent, 2, MidpointRounding.AwayFromZero) : 0;

                    tbSupplyMainListTmp.Add(tbSupplyMain);
                    dateTmp = dateTmp.AddMinutes(3.6);
                });
            });

            this.log.Debug("FinishedAddSupplyMainToList");

            db.tblSupplyMains.AddRange(tbSupplyMainListTmp);
            this.log.Debug("FinishedAddSupplyMainListToDB");
            if (await Task.Run(() => !ClsSaveDB.Save(db, LogHelper.GetLogger()))) return;
            this.log.Debug("FinishedSaveSupplyMainToDB");

            db = new accountingEntities();
            var tbSupplyMainList2 = db.tblSupplyMains.Where(x => x.supBrnId == brnTo && x.supDate < new DateTime(2020, 10, 9)
                && (x.supStatus == 4 || x.supStatus == 8)).ToList();

            int count = 0;
            IList<tblSupplySub> tbSupplySubListTmp = new List<tblSupplySub>();

            await Task.Run(() =>
            {
                tbSupplyMainList2.ForEach(x =>
                {
                    var tbSupplyMainOld = tbSupplyMainList[count];

                    tbSupplySubList.Where(y => y.supNo == tbSupplyMainOld.id).ForEach(z =>
                    {
                        var tbSupplySub = z.ShallowCopy();
                        tbSupplySub.supNo = x.id;
                        tbSupplySub.supDate = Convert.ToDateTime(x.supDate).Date;
                        tbSupplySub.supBrnId = brnTo;

                        taxPercent = x.supDate < dateTax ? (double)0.05 : (double)0.15;
                        tbSupplySub.supTaxPercent = Convert.ToByte(taxPercent * 100);
                        tbSupplySub.supTaxPrice = z.supSalePrice * Convert.ToDouble(z.supQuanMain);
                        tbSupplySub.supTaxPrice = tbSupplySub.supTaxPrice != 0 ? Math.Round((double)tbSupplySub.supTaxPrice *
                            taxPercent, 2, MidpointRounding.AwayFromZero) : 0;

                        tbSupplySubListTmp.Add(tbSupplySub);
                    });

                    ++count;
                });
            });

            this.log.Debug("FinishedAddSupplySubToList");

            db.tblSupplySubs.AddRange(tbSupplySubListTmp);
            this.log.Debug("FinishedAddSupplySubListToDB");
            if (await Task.Run(() => !ClsSaveDB.Save(db, LogHelper.GetLogger()))) return;
            this.log.Debug("FinishedSaveSupplySubToDB");

            DialogResult = DialogResult.OK;
            flyDialog.WaitForm(this, 0);
        }

        private async void btnResetTblProductNdTblSupplyWithPrdMsu_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);

            accountingEntities db = new accountingEntities();

            IList<tblProduct> tbProductList = null;
            IList<tblPrdPriceMeasurment> tbPrdMsurList = null;
            IList<tblSupplyMain> tbSupplyMainList = null;
            IList<tblSupplySub> tbSupplySubList = null;
            DateTime dateTmp = new DateTime(2020, 10, 03);

            await Task.Run(() => tbProductList = db.tblProducts.ToList());
            this.log.Debug("Passed tblProduct Query");
            await Task.Run(() => tbPrdMsurList = db.tblPrdPriceMeasurments.ToList());
            this.log.Debug("Passed tblPrdPriceMsur Query");
            await Task.Run(() => tbSupplyMainList = db.tblSupplyMains.Where(x => x.supDate >= dateTmp).ToList());
            this.log.Debug("Passed tblSupplyMain Query");
            await Task.Run(() => tbSupplySubList = db.tblSupplySubs.Where(x => x.supDate >= dateTmp).ToList());
            this.log.Debug("Passed tblSupplySub Query");

            var tbPrdMsurTmpList = tbPrdMsurList.Where(x => !tbProductList.Select(y => y.id).Contains(x.ppmPrdId)).ToList();
            Console.WriteLine($"=================tbPrdMsurTmpList = {tbPrdMsurTmpList.Count}");
            this.log.Debug($"tbPrdMsurTmpList = {tbPrdMsurTmpList.Count}");

            List<tblSupplyMain> tbSupplyMainTmpList = new List<tblSupplyMain>();
            List<tblSupplySub> tbSupplySubTmpList = new List<tblSupplySub>();

            await Task.Run(() =>
            {
                foreach (var tbPrdMsur in tbPrdMsurTmpList)
                {
                    this.log.Debug($"tbPrdMsurId = {tbPrdMsur.ppmId}");
                    var tbSupSubList = tbSupplySubList.Where(x => Convert.ToInt32(x.supMsur) == tbPrdMsur.ppmId).ToList();
                    this.log.Debug($"tbSupSubListCount = {tbSupSubList.Count}");

                    if (tbSupSubList?.Count == 0) continue;
                    tbSupplySubTmpList.AddRange(tbSupSubList);

                    var tbSupSubGrp = tbSupSubList.GroupBy(x => x.supNo).ToList();
                    this.log.Debug($"tbSupSubGrpCount = {tbSupSubGrp.Count}");

                    var tbSupMainList = tbSupplyMainList.Where(x => tbSupSubGrp.Select(y => y.Key).Contains(x.id)).ToList();
                    if (tbSupMainList?.Count != 0)
                        tbSupplyMainTmpList.AddRange(tbSupMainList);
                    this.log.Debug($"SubGrpCount = {tbSupSubGrp.Count}, MainCount = {tbSupMainList}");
                }
            });

            this.log.Debug($"tbSupplyMainTmpListCount = {tbSupplyMainTmpList.Count}");
            this.log.Debug($"tbSupplySubTmpListCount = {tbSupplySubTmpList.Count}");

            if (tbSupplyMainTmpList.Count > 0)
            {
                db.tblSupplyMains.RemoveRange(tbSupplyMainTmpList);
                this.log.Debug("FinishedRemoveSupplyMainTmpListToDb");
            }

            if (tbSupplySubTmpList.Count > 0)
            {
                db.tblSupplySubs.RemoveRange(tbSupplySubTmpList);
                this.log.Debug("FinishedRemoveSupplySubTmpListToDb");
            }

            if (tbPrdMsurTmpList.Count > 0)
            {
                db.tblPrdPriceMeasurments.RemoveRange(tbPrdMsurTmpList);
                this.log.Debug("FinishedRemovePrdMsurTmpListToDb");
            }

            if (await Task.Run(() => ClsSaveDB.Save(db, this.log))) DialogResult = DialogResult.OK;
            flyDialog.WaitForm(this, 0);
        }

        private async void btnAddBaarcodeFromTblPrdMsurToTblBarcode_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);

            accountingEntities db = new accountingEntities();

            IList<tblPrdPriceMeasurment> tbPrdMsurList = await Task.Run(() => db.tblPrdPriceMeasurments.ToList());
            IList<tblBarcode> tbBarcodeList = new List<tblBarcode>();

            await Task.Run(() =>
            {
                tbPrdMsurList.ForEach(x =>
                {
                    if (!string.IsNullOrWhiteSpace(x.ppmBarcode1)) tbBarcodeList.Add(CreateBarocde(x.ppmBarcode1, x));
                    if (!string.IsNullOrWhiteSpace(x.ppmBarcode2)) tbBarcodeList.Add(CreateBarocde(x.ppmBarcode2, x));
                    if (!string.IsNullOrWhiteSpace(x.ppmBarcode3)) tbBarcodeList.Add(CreateBarocde(x.ppmBarcode3, x));
                });
            });

            await Task.Run(() => db.tblBarcode.AddRange(tbBarcodeList));

            if (await Task.Run(() => ClsSaveDB.Save(db, LogHelper.GetLogger()))) DialogResult = DialogResult.OK;
            flyDialog.WaitForm(this, 0);
        }

        private tblBarcode CreateBarocde(string ppmBarcode, tblPrdPriceMeasurment x)
        {
            return new tblBarcode()
            {
                brcNo = ppmBarcode,
                brcPrdMsurId = x.ppmId,
                brcBrnId = Convert.ToInt16(x.ppmBrnId)
            };
        }

        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);


            accountingEntities db = new accountingEntities();
            IList<tblAccount> tbAccountList = null;

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DBUpdate", @"AccountList.json");
            tbAccountList = JsonConvert.DeserializeObject<List<tblAccount>>(File.ReadAllText(path));

            try
            {
                await Task.Run(() =>
                {
                    tbAccountList.ForEach(x =>
                    {
                        var tbAccount = x.ShallowCopy();
                        tbAccount.accBrnId = Session.CurBranch.brnId;
                        db.tblAccounts.Add(tbAccount);
                    });
                });
            }
            catch (Exception ex)
            {
                ClsXtraMssgBox.ShowError(ex.Message);
            }

            if (await Task.Run(() => ClsSaveDB.Save(db, LogHelper.GetLogger()))) DialogResult = DialogResult.OK;
            flyDialog.WaitForm(this, 0);
        }

        private async void btnTransferCustBalance_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);

            accountingEntities db = new accountingEntities();
            IList<(long, string)> listAcc = new List<(long, string)>();
            IList<tblCustomer> tbCustList = null;

            await Task.Run(() => tbCustList = db.tblCustomers.ToList());

            await Task.Run(() =>
            {
                foreach (var tbCustomer in tbCustList)
                    listAcc.Add((tbCustomer.custAccNo, tbCustomer.custName));
            });

            if (await CalculateBalanceAsync(listAcc)) DialogResult = DialogResult.OK;
            flyDialog.WaitForm(this, 0);
        }

        private async void btnTransferSupplierBalance_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);

            accountingEntities db = new accountingEntities();
            IList<(long, string)> listAcc = new List<(long, string)>();
            IList<tblSupplier> tbSupplierList = null;

            await Task.Run(() => tbSupplierList = db.tblSuppliers.ToList());

            await Task.Run(() =>
            {
                foreach (var tbSupplier in tbSupplierList)
                    listAcc.Add((tbSupplier.splAccNo, tbSupplier.splName));
            });

            if (await CalculateBalanceAsync(listAcc)) DialogResult = DialogResult.OK;
            flyDialog.WaitForm(this, 0);
        }

        private async Task<bool> CalculateBalanceAsync(IList<(long, string)> listAcc)
        {
            accountingEntities db = new accountingEntities();
            IList<tblAsset> tbAssetNewList = new List<tblAsset>();
            IList<tblAsset> tbAssetList = null;
            await Task.Run(() => tbAssetList = db.tblAssets.Where(x => x.asBrnId == Session.CurBranch.brnId &&
               x.asDate >= Session.CurrentYear.fyDateStart && x.asDate <= Session.CurrentYear.fyDateEnd).ToList());
            
            await Task.Run(() =>
            {
                foreach (var acc in listAcc)
                {
                    double debit = 0, credit = 0;

                    foreach (var tbAsset in tbAssetList.Where(x => x.asAccNo == acc.Item1).ToList())
                    {
                        debit += Convert.ToDouble(tbAsset.asDebit);
                        credit += Convert.ToDouble(tbAsset.asCredit);
                    }

                    if (debit == credit) continue;
                    if (debit > credit) tbAssetNewList.Add(InitAssetBalance(acc.Item1, acc.Item2,
                        debit - credit, null));
                    if (credit > debit) tbAssetNewList.Add(InitAssetBalance(acc.Item1, acc.Item2,
                        null, credit - debit));
                }
            });

            if (tbAssetNewList?.Count >= 1)
            {
                await Task.Run(() => db.tblAssets.AddRange(tbAssetNewList));
                return await Task.Run(() => ClsSaveDB.Save(db, LogHelper.GetLogger()));
            }

            return true;
        }

        private tblAsset InitAssetBalance(long accNo, string accName, double? debit, double? credit)
        {
            return new tblAsset()
            {
                asAccNo = accNo,
                asAccName = accName,
                asDebit = debit,
                asCredit = credit,
                asDesc = string.Format($"رصيد إفتتاحي {0}", Session.CurrentYear.fyDateStart.AddYears(1).Year),
                asDate = Session.CurrentYear.fyDateStart.AddYears(1),
                asBrnId = Session.CurBranch.brnId,
                asUserId = Session.CurrentUser.id,
                asEntId = 0,
                asEntNo = 0,
                asView = 1,
                asStatus = 1
            };
        }

        private async void btnResetPrdQuanFromDate_Click(object sender, EventArgs e)
        {
            //if (!ValidateDate(dateEditResetPrdQuanFromDate)) return;
            //flyDialog.WaitForm(this, 1);

            //accountingEntities db = new accountingEntities();
            //ClsTblProductQunatity clsTbPrdQuan = null;
            //ClsTblProductQtyOpn clsTbPrdQuanOpn = null;
            //ClsTblPrdPriceMeasurment clsTbPrdMsur = null;
            //ClsPrdQuantityOperations clsPrdQuanOpr = null;
            //ClsTblSupplyMain clsTbSupplyMain = null;
            //ClsTblSupplySub clsTbSupplySub = null;
            ////IList<InventoryBalanceing> tbInvBalance = null;
            ////IList<InventoryBalancingDetail> tbInvBalanceDetail = null;
            //DateTime dt = dateEditResetPrdQuanFromDate.DateTime;

            //IList<Task> taskList = new List<Task>();
            //taskList.Add(Task.Run(() => clsTbPrdQuan = new ClsTblProductQunatity()));
            //taskList.Add(Task.Run(() => clsTbPrdQuanOpn = new ClsTblProductQtyOpn()));
            //taskList.Add(Task.Run(() => clsTbPrdMsur = new ClsTblPrdPriceMeasurment()));
            //taskList.Add(Task.Run(() => clsTbSupplyMain = new ClsTblSupplyMain((byte)0)));
            //taskList.Add(Task.Run(() => clsTbSupplySub = new ClsTblSupplySub()));
            //await Task.WhenAll(taskList);

            //clsPrdQuanOpr = new ClsPrdQuantityOperations(clsTbPrdMsur, clsTbPrdQuan);

            //if (await ResetPrdQuantity(clsTbPrdQuan) != true) return;
            //if (await AddPrdQuanFromPrdQuanOpn(clsTbPrdQuanOpn, clsPrdQuanOpr) != true) return;
            //if (await UpdateSupplyPrdQun(clsTbSupplyMain, clsTbSupplySub, clsPrdQuanOpr, (byte)SupplyType.Purchase,
            //    (byte)SupplyType.PurchasePhase, (byte)SupplyType.SalesRtrn, (byte)SupplyType.SalesPhaseRtrn, true) != true) return;
            //if (await UpdateSupplyPrdQun(clsTbSupplyMain, clsTbSupplySub, clsPrdQuanOpr, (byte)SupplyType.Sales,
            //    (byte)SupplyType.SalesPhase, (byte)SupplyType.PurchaseRtrn, (byte)SupplyType.PurchasePhaseRtrn, false) != true) return;

            //DialogResult = DialogResult.OK;
            //flyDialog.WaitForm(this, 0);
        }

        private bool ValidateDate(DateEdit dateEdit)
        {
            bool isValid = !string.IsNullOrEmpty(dateEdit.Text);
            if (!isValid) ClsXtraMssgBox.ShowError("يجب إدخال التاريخ أولاً!");

            return isValid;
        }


        //private async Task<bool> AddPrdQuanFromPrdQuanOpn(ClsTblProductQtyOpn clsTbPrdQuanOpn, ClsPrdQuantityOperations clsPrdQuanOpr)
        //{
        //    IList<ClsProductQuantList> clsPrdQuanList = new List<ClsProductQuantList>();
        //    DateTime dt = dateEditResetPrdQuanFromDate.DateTime;
        //    int count = 0;

        //    foreach (var tbPrdQuanOpn in clsTbPrdQuanOpn.GetProductQtyOpnList.Where(x => x.qtyDate >= dt))
        //    {
        //        count++;
        //        await Task.Run(() => clsPrdQuanList.Add(new ClsProductQuantList()
        //        {
        //            prdId = tbPrdQuanOpn.qtyPrdId,
        //            prdStrId = tbPrdQuanOpn.qtyStrId,
        //            prdPriceMsurId = tbPrdQuanOpn.qtyPrdMsurId,
        //            prdPrice = tbPrdQuanOpn.qtyPrice,
        //            prdQuantity = tbPrdQuanOpn.qtyQuantity
        //        }));
        //    }
        //    Console.WriteLine($"======opnCount = {count}");

        //    return await Task.Run(() => clsPrdQuanOpr.AddPrdQuantity(clsPrdQuanList, false));
        //}

        //private async Task<bool> UpdateSupplyPrdQun(ClsTblSupplyMain clsTbSupplyMain, ClsTblSupplySub clsTbSupplySub, ClsPrdQuantityOperations clsPrdQuanOpr,
        //    byte status1, byte status2, byte status3, byte status4, bool isIncrease)
        //{
        //    DateTime dtStart = dateEditResetPrdQuanFromDate.DateTime;
        //    DateTime dtEnd = ClsDateConverter.ConvertTime(dateEditResetPrdQuanToDate.DateTime);
        //    int count = 0;
        //    Console.WriteLine($"=========dtStart = {dtStart}, dtEnd = {dtEnd}");

        //    foreach (var tbSupplyMain in clsTbSupplyMain.GetSupplyMainList.Where(x => x.supDate >= dtStart && x.supDate <= dtEnd &&
        //        (x.supStatus == status1 || x.supStatus == status2 || x.supStatus == status3 || x.supStatus == status4)).ToList())
        //    {
        //        count++;
        //        if (isIncrease) await Task.Run(() =>
        //            clsPrdQuanOpr.AddPrdQuantity(clsTbSupplySub.GetSupplySubListBySupId(tbSupplyMain.id),
        //                Convert.ToInt16(tbSupplyMain.supStrId), false));

        //        if (!isIncrease) await Task.Run(() =>
        //            clsPrdQuanOpr.DeductPrdQuantity(clsTbSupplySub.GetSupplySubListBySupId(tbSupplyMain.id),
        //                Convert.ToInt16(tbSupplyMain.supStrId), false));
        //        //if (!isIncrease)
        //        //    clsPrdQuanOpr.DeductPrdQuantity(clsTbSupplySub.GetSupplySubListBySupId(tbSupplyMain.id),
        //        //        Convert.ToInt16(tbSupplyMain.supStrId), false);
        //    }
        //    Console.WriteLine($"======supplyCount = {count}");

        //    return true;
        //}

        private async void btnFixPrdQuanWithInv_Click(object sender, EventArgs e)
        {
            //flyDialog.WaitForm(this, 1);

            //await new ClsResetPrdQuan().ResetQuan();

            //flyDialog.WaitForm(this, 0);
            //DialogResult = DialogResult.OK;
        }

        private async void btnCopyTblInvenotryBalancingToTblInvStore_Click(object sender, EventArgs e)
        {
            if (!ValidateDefaultStrId()) return;
            flyDialog.WaitForm(this, 1);

            ClsTblProduct clsTbProduct = null;
            ClsTblBarcode clsTbBarcode = null;

            List<Task> taskList = new List<Task>()
             {
                 Task.Run(() => clsTbProduct = new ClsTblProduct()),
                 Task.Run(() => clsTbBarcode = new ClsTblBarcode()),
             };
            await Task.WhenAll(taskList);

            using var db = new accountingEntities();

            var tbInvBalancingList = (from listJoin in (from x in db.InventoryBalanceings
                                                        join y in db.InventoryBalancingDetails
                                                        on x.ID equals y.MainID
                                                        select new { Main = x, SubItem = y })
                                      group listJoin by listJoin.Main into listGrp
                                      select listGrp).AsQueryable().AsNoTracking().ToList();

            int invNo = await Task.Run(() => new ClsTblInvStoreMain().GetInvStoreNewNo());
            List<tblInvStoreSub> tbInvSubList;

            foreach (var itemMain in tbInvBalancingList)
            {
                var tbInvMain = await Task.Run(() => InitInvStoreMainObj(invNo++, itemMain.Key.Date));

                db.tblInvStoreMains.Add(tbInvMain);
                await Task.Run(() => ClsSaveDB.Save(db, LogHelper.GetLogger()));

                tbInvSubList = new List<tblInvStoreSub>();

                foreach (var itemY in itemMain)
                {
                    var tbInvSub = await Task.Run(() => InitInvStoreSubObj(tbInvMain.id, itemY.SubItem, clsTbProduct, clsTbBarcode));
                    tbInvSubList.Add(tbInvSub);
                }

                if (tbInvSubList?.Count >= 1) db.tblInvStoreSubs.AddRange(tbInvSubList);
                await Task.Run(() => ClsSaveDB.Save(db, LogHelper.GetLogger()));
            }

            flyDialog.WaitForm(this, 0);
            DialogResult = DialogResult.OK;
        }

        private tblInvStoreMain InitInvStoreMainObj(int invNo, DateTime date)
        {
            return new tblInvStoreMain()
            {
                invNo = invNo,
                invDate = date,
                invStrId = MySetting.DefaultSetting.defaultStrId,
                invBrnId = Session.CurBranch.brnId,
                invStatus = (byte)InvType.Direct,
            };
        }

        private tblInvStoreSub InitInvStoreSubObj(int id, InventoryBalancingDetail subItem, ClsTblProduct clstbProduct, ClsTblBarcode clsTbBarcode)
        {
            var tbInvStoreSub = new tblInvStoreSub()
            {
                invMainId = id,
                invPrdId = subItem.ProductID,
                invPrdMsurId = subItem.UnitID,
                invQuanStr = subItem.Qty,
                invQuanAvl = subItem.RealQty,
                invQuanDefr = (subItem.RealQty - subItem.Qty),
                invPriceAvrg = Convert.ToDouble(subItem.Cost),
                invSalePrice = Convert.ToDouble(subItem.Price),
                invSalePriceTotal = Convert.ToDouble(subItem.TotalPrice),
                invBarcode = clsTbBarcode?.GetFirstBarcodeByPrdMsurId(subItem.UnitID) ?? null,
                invPrdGrpId = clstbProduct?.GetPrdGroupIdByPrdId(subItem.ProductID) ?? 0,
            };

            tbInvStoreSub.invPriceDefr = Math.Round(Convert.ToDouble(tbInvStoreSub.invQuanDefr)
                * tbInvStoreSub.invPriceAvrg, 3, MidpointRounding.AwayFromZero);
            tbInvStoreSub.invPriceTotal = Math.Round(Convert.ToDouble(tbInvStoreSub.invQuanAvl)
                * tbInvStoreSub.invPriceAvrg, 3, MidpointRounding.AwayFromZero);

            return tbInvStoreSub;
        }

        private bool ValidateDefaultStrId()
        {
            bool isValid = Convert.ToInt16(MySetting.DefaultSetting.defaultStrId) == 0 ? false : true;

            if (!isValid) ClsXtraMssgBox.ShowError("يجب تحديد المخزن الإفتراضي أولاً من إعدادات النظام!");

            return isValid;
        }

        private async void btnResetSupplyNo2022_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);

            await Task.Run(() => ResetSupplyNo((byte)SupplyType.Purchase, (byte)SupplyType.PurchasePhase));
            await Task.Run(() => ResetSupplyNo((byte)SupplyType.PurchaseRtrn, (byte)SupplyType.PurchasePhaseRtrn));
            await Task.Run(() => ResetSupplyNo((byte)SupplyType.Sales, (byte)SupplyType.SalesPhase));
            await Task.Run(() => ResetSupplyNo((byte)SupplyType.SalesRtrn, (byte)SupplyType.SalesPhaseRtrn));

            flyDialog.WaitForm(this, 0);
            DialogResult = DialogResult.OK;
        }

        private void ResetSupplyNo(byte status1, byte status2)
        {
            using var db = new accountingEntities();

            var list = db.tblSupplyMains.Where(x => x.supDate >= new DateTime(2022, 1, 1) &&  x.supBrnId == Session.CurBranch.brnId
                && (x.supStatus == status1 || x.supStatus == status2)).OrderBy(x => x.supDate).ToList();

            int supNo = db.tblSupplyMains.Where(x => x.supBrnId == Session.CurBranch.brnId && x.supDate >= new DateTime(2021, 1, 1)
                && x.supDate < new DateTime(2022, 1, 1) && (x.supStatus == status1 || x.supStatus == status2))
                .OrderByDescending(x => x.supNo).Select(x => x.supNo).FirstOrDefault();

            foreach (var x in list) x.supNo = ++supNo;

            ClsSaveDB.Save(db, LogHelper.GetLogger());
        }

        private async void btnResetSupplyAsset_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);

            DateTime fyDtTmpStart = Session.CurrentYear.fyDateStart;
            DateTime fyDtTmpEnd = Session.CurrentYear.fyDateEnd;

            Session.CurrentYear.fyDateStart = new DateTime(2021, 1, 1);
            Session.CurrentYear.fyDateEnd = new DateTime(2023, 1, 1);

            ClsTblSupplySub clsTbSupplySub = new ClsTblSupplySub(SupplyType.AllSupply, false);

            await ResetSupplyAsset(clsTbSupplySub, SupplyType.Sales, 4, 8, 6);
            await ResetSupplyAsset(clsTbSupplySub, SupplyType.SalesRtrn, 11, 12, 8);

            Session.CurrentYear.fyDateStart = fyDtTmpStart;
            Session.CurrentYear.fyDateEnd = fyDtTmpEnd;

            flyDialog.WaitForm(this, 0);
            DialogResult = DialogResult.OK;
        }

        //private void ResetSupplyAsset(ClsTblSupplySub clsTbSupplySub, SupplyType supplyType, byte status1, byte status2,
        private async Task ResetSupplyAsset(ClsTblSupplySub clsTbSupplySub, SupplyType supplyType, byte status1, byte status2,
            byte asStatus)
        {
            using var db = new accountingEntities();

            var listSupply = db.tblSupplyMains.Where(x => x.supDate >= new DateTime(2021, 01, 01) && x.supIsCash == 2 &&
                (x.supStatus == status1 || x.supStatus == status2)).AsQueryable().AsNoTracking().ToList();
            Console.WriteLine($"=======PassedListSupply, Count = {listSupply.Count()}");

            var listAsset = db.tblAssets.Where(x => x.asStatus == asStatus).AsQueryable().ToList();
            listAsset = listAsset.Where(x => listSupply.Any(y => y.id == x.asEntId)).ToList();
            Console.WriteLine($"=======PassedListAsset");

            Console.WriteLine($"\n=========listSupplyCount = {listSupply.Count}, listAssetCount = {listAsset.Count}");

            db.tblAssets.RemoveRange(listAsset);
            Console.WriteLine($"\n=========FinishedRemoveRange");

            ClsSaveDB.Save(db, LogHelper.GetLogger());
            Console.WriteLine($"\n=========FinishedSaveRemoveAsset \n");

            await Task.Run(() => new ClsSupplyTarhel(supplyType).PhaseInvoice(listSupply));
            //new ClsSupplyTarhel(supplyType, clsTbSupplySub).PhaseSales2(listSupply);
            Console.WriteLine($"\n=========FinishedTarhel: {supplyType}");
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            accountingEntities db = new accountingEntities();
            db.Database.ExecuteSqlCommand(@"
declare @year smallint 
Declare YearInvo Cursor FOR Select distinct year(supDate) From tblSupplyMain order by year(supDate)
OPEN YearInvo Fetch YearInvo into @year While @@fetch_status=0 
BEGIN
declare @Id int declare @countId int declare @supNo int declare @BranId smallint
set @countId=1
Declare SaleInvo Cursor FOR Select id From tblSupplyMain 
where (supStatus=4 or supStatus=8 or supStatus=17) and year(supDate)=@year order by supDate
OPEN SaleInvo Fetch SaleInvo into @Id While @@fetch_status=0 BEGIN 
update tblSupplyMain set MainNo=@countId where id=@Id set @countId=@countId+1 
Fetch SaleInvo into @Id END 
Close SaleInvo Deallocate SaleInvo 
set @countId=1
Declare SaleRetuInvo Cursor FOR Select id,supNo,supBrnId From tblSupplyMain 
where (supStatus=11 or supStatus=12 or supStatus=18) and year(supDate)=@year order by supDate
OPEN SaleRetuInvo Fetch SaleRetuInvo into @Id,@supNo,@BranId While @@fetch_status=0 
BEGIN 
select @countId=MainNo from tblSupplyMain where (supStatus=4 or supStatus=8 or supStatus=17) and year(supDate)=@year and supNo=@supNo and supBrnId=@BranId
update tblSupplyMain set MainNo=@countId where id=@Id 
Fetch SaleRetuInvo into @Id,@supNo,@BranId
END 
Close SaleRetuInvo Deallocate SaleRetuInvo
set @countId=1
Declare BuyInvo Cursor FOR Select id From tblSupplyMain where (supStatus=3 or supStatus=7 or supStatus=15) and year(supDate)=@year order by supDate
OPEN BuyInvo Fetch BuyInvo into @Id While @@fetch_status=0 BEGIN 
update tblSupplyMain set MainNo=@countId where id=@Id set @countId=@countId+1 
Fetch BuyInvo into @Id END Close BuyInvo Deallocate BuyInvo
set @countId=1
Declare BuyRetuInvo Cursor FOR Select id,supNo,supBrnId From tblSupplyMain where (supStatus=9 or supStatus=10 or supStatus=16) and year(supDate)=@year order by supDate
OPEN BuyRetuInvo Fetch BuyRetuInvo into @Id,@supNo,@BranId While @@fetch_status=0 BEGIN
select @countId=MainNo from tblSupplyMain where (supStatus=3 or supStatus=7 or supStatus=15) and year(supDate)=@year and supNo=@supNo and supBrnId=@BranId
update tblSupplyMain set MainNo=@countId where id=@Id 
Fetch BuyRetuInvo into @Id,@supNo,@BranId END Close BuyRetuInvo Deallocate BuyRetuInvo Fetch YearInvo into @year END Close YearInvo Deallocate YearInvo");
            flyDialog.WaitForm(this,0);
            DialogResult = DialogResult.OK;
        }

        private void simpleButton21_Click(object sender, EventArgs e)
        {
            //flyDialog.WaitForm(this, 1);
            //using (var db = new accountingEntities())
            //{
            //    db.tblSupplySubs.Where(x => x.supBrnId == Session.CurBranch.brnId && (Math.Round(x.supPrice.Value, 2) > Math.Round(x.supSalePrice.Value, 2))
            //    && (x.supStatus == 4 || x.supStatus == 8) && x.supDate >= Session.CurrentYear.fyDateStart
            //    && x.supDate <= Session.CurrentYear.fyDateEnd).ToList().ForEach(y =>
            //    {
            //        List<tblPrdPriceMeasurment> p = db.tblPrdPriceMeasurments?.Where(x => x.ppmPrdId == y.supPrdId).ToList();
            //        var tbPrdMsur = p?.FirstOrDefault(x => x.ppmId == y.supMsur);
            //        if (tbPrdMsur != null && p != null)
            //        {
            //            var ff = db.tblSupplySubs.Where(x => x.supBrnId == Session.CurBranch.brnId &&
            //          (x.supDate >= Session.CurrentYear.fyDateStart && x.supDate <= Session.CurrentYear.fyDateEnd) && x.supPrdId == tbPrdMsur.ppmPrdId &&
            //          (x.supStatus == 3 || x.supStatus == 7)).OrderByDescending(x => new { x.supDate, x.id }).FirstOrDefault();
            //            if (ff == null)
            //            {
            //                if (tbPrdMsur.ppmStatus == 1)
            //                    y.supPrice = tbPrdMsur.ppmPrice;
            //                else if (tbPrdMsur.ppmStatus == 2)
            //                    y.supPrice = (p.FirstOrDefault(x => x.ppmStatus == 1).ppmPrice / tbPrdMsur.ppmConversion);
            //                else if (tbPrdMsur.ppmStatus == 3)
            //                    y.supPrice = (p.FirstOrDefault(x => x.ppmStatus == 1).ppmPrice / p.FirstOrDefault(x => x.ppmStatus == 2).ppmConversion / tbPrdMsur.ppmConversion);
            //            }
            //            byte state = (p.FirstOrDefault(x => x.ppmId == (ff?.supMsur ?? 0))?.ppmStatus) ?? 0;
            //            if (tbPrdMsur.ppmStatus == state)
            //                y.supPrice = ff?.supPrice;
            //            else if (tbPrdMsur.ppmStatus - state == 1)
            //                y.supPrice = ff?.supPrice / tbPrdMsur.ppmConversion;
            //            else if (tbPrdMsur.ppmStatus == 3 && state == 1)
            //                y.supPrice = (ff?.supPrice / p.FirstOrDefault(x => x.ppmStatus == 2).ppmConversion / tbPrdMsur.ppmConversion);
            //            else if (tbPrdMsur.ppmStatus - state == -1)
            //                y.supPrice = ff?.supPrice * p.FirstOrDefault(x => x.ppmStatus == 2).ppmConversion;
            //            else if (tbPrdMsur.ppmStatus == 1 && state == 3)
            //                y.supPrice = (ff?.supPrice * p.FirstOrDefault(x => x.ppmStatus == 2).ppmConversion * p.FirstOrDefault(x => x.ppmStatus == 3).ppmConversion);

            //        }
            //    });
               
            //    db.SaveChanges();
            //}
            //flyDialog.WaitForm(this, 0);
            //DialogResult = DialogResult.OK;
        }
    }
}