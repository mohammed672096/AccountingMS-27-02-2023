using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formAddBranch : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        accountingEntities db = new accountingEntities();
        ClsTblBranch clsBranch = new ClsTblBranch();
        ClsTblBranchImg clsBranchImg;
        tblBranch tbBranch;
        ClsTblAccount clsTbAccount;
        ClsTblDefaultAccount clsTbDefaultAccount=new ClsTblDefaultAccount();
        private readonly UCbranch _ucBranch;
        private bool isNew;
        private short brnId;
        private short brnNo;
        private byte[] imageBuffer;

        public formAddBranch(UCbranch ucBranch, tblBranch tbBranch)
        {
            InitializeComponent();
            InitData(tbBranch);
            GetResources();
            _ucBranch = ucBranch;
            InitDataSurceForAcc();
            bbiAutoAccNo.CheckedChanged += BbiAutoAccNo_CheckedChanged;
        }
        private void BbiAutoAccNo_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BbiAutoAccNoItemVisibility(bbiAutoAccNo.Checked);
        }
        private void BbiAutoAccNoItemVisibility(bool checkState)
        {
            laConGroupAccDefult.Enabled = !checkState;
            layoutControlGroupAccGro.Enabled = !checkState;
        }
        private void InitDataSurceForAcc()
        {
          
            this.clsTbAccount = new ClsTblAccount();
            var acc = this.clsTbAccount.GetAccountListByLevel(
            Convert.ToByte(MySetting.DefaultSetting.dfltAccLevel - 1)).ToList();

            dflAccNoBox.Properties.DataSource = acc.Where(x => x.accParent == 1111).ToList();
            dflAccNoBank.Properties.DataSource = acc.Where(x => x.accParent == 1112).ToList();
            dflAccNoCustomer.Properties.DataSource = acc.Where(x => x.accParent == 1121).ToList();
            dflAccNoSupplier.Properties.DataSource = acc.Where(x => x.accParent == 2111).ToList();
            dflAccNoEmp.Properties.DataSource = acc;// acc.Where(x => x.accParent == 1161).ToList();
            dflAccNoRep.Properties.DataSource = acc;
            dflAccNoGrp.Properties.DataSource = acc;//acc.Where(x => x.accParent == 1141).ToList();
            dflAccNoSaleRetuCost.Properties.DataSource = acc;// acc.Where(x => x.accParent == 3121).ToList();
            dflAccNoSalesCost.Properties.DataSource = acc;//acc.Where(x => x.accParent == 3121).ToList();
            dflAccNoSaleRetu.Properties.DataSource = acc;//acc.Where(x => x.accParent == 3121).ToList();
            dflAccNoDiscount.Properties.DataSource = acc;// acc.Where(x => x.accParent == 3121).ToList();
            dflAccNoSales.Properties.DataSource = acc;//acc.Where(x => x.accParent == 4111).ToList();

            dflAccNoPur.Properties.DataSource = acc;
            dflAccNoPurRetu.Properties.DataSource = acc;
     
            tblBranch branch = tblBranchBindingSource.Current as tblBranch;
            if (clsTbDefaultAccount.IsDefaultAccFound(3, branch.brnId))
                dflAccNoBox.EditValue = clsTbDefaultAccount.GetTblDefaultAccountsList.FirstOrDefault(x => x.dflStatus == 3 && x.dfltBrnId == branch.brnId).dflAccNo;

            if (clsTbDefaultAccount.IsDefaultAccFound(4, branch.brnId))
                dflAccNoBank.EditValue = clsTbDefaultAccount.GetTblDefaultAccountsList.FirstOrDefault(x => x.dflStatus == 4 && x.dfltBrnId == branch.brnId).dflAccNo;

            if (clsTbDefaultAccount.IsDefaultAccFound(1, branch.brnId))
                dflAccNoCustomer.EditValue = clsTbDefaultAccount.GetTblDefaultAccountsList.FirstOrDefault(x => x.dflStatus == 1 && x.dfltBrnId == branch.brnId).dflAccNo;

            if (clsTbDefaultAccount.IsDefaultAccFound(2, branch.brnId))
                dflAccNoSupplier.EditValue = clsTbDefaultAccount.GetTblDefaultAccountsList.FirstOrDefault(x => x.dflStatus == 2 && x.dfltBrnId == branch.brnId).dflAccNo;

            if (clsTbDefaultAccount.IsDefaultAccFound(5, branch.brnId))
                dflAccNoEmp.EditValue = clsTbDefaultAccount.GetTblDefaultAccountsList.FirstOrDefault(x => x.dflStatus == 5 && x.dfltBrnId == branch.brnId).dflAccNo;

            if (clsTbDefaultAccount.IsDefaultAccFound(13, branch.brnId))
                dflAccNoRep.EditValue = clsTbDefaultAccount.GetTblDefaultAccountsList.FirstOrDefault(x => x.dflStatus == 13 && x.dfltBrnId == branch.brnId).dflAccNo;

            if (clsTbDefaultAccount.IsDefaultAccFound(6, branch.brnId))
                dflAccNoGrp.EditValue = clsTbDefaultAccount.GetTblDefaultAccountsList.FirstOrDefault(x => x.dflStatus == 6 && x.dfltBrnId == branch.brnId).dflAccNo;

            if (clsTbDefaultAccount.IsDefaultAccFound(7, branch.brnId))
                dflAccNoSales.EditValue = clsTbDefaultAccount.GetTblDefaultAccountsList.FirstOrDefault(x => x.dflStatus == 7 && x.dfltBrnId == branch.brnId).dflAccNo;

            if (clsTbDefaultAccount.IsDefaultAccFound(8, branch.brnId))
                dflAccNoSalesCost.EditValue = clsTbDefaultAccount.GetTblDefaultAccountsList.FirstOrDefault(x => x.dflStatus == 8 && x.dfltBrnId == branch.brnId).dflAccNo;

            if (clsTbDefaultAccount.IsDefaultAccFound(9, branch.brnId))
                dflAccNoSaleRetu.EditValue = clsTbDefaultAccount.GetTblDefaultAccountsList.FirstOrDefault(x => x.dflStatus ==9 && x.dfltBrnId == branch.brnId).dflAccNo;

            if (clsTbDefaultAccount.IsDefaultAccFound(10, branch.brnId))
                dflAccNoSaleRetuCost.EditValue = clsTbDefaultAccount.GetTblDefaultAccountsList.FirstOrDefault(x => x.dflStatus == 10 && x.dfltBrnId == branch.brnId).dflAccNo;

            if (clsTbDefaultAccount.IsDefaultAccFound(11, branch.brnId))
                dflAccNoDiscount.EditValue = clsTbDefaultAccount.GetTblDefaultAccountsList.FirstOrDefault(x => x.dflStatus == 11 && x.dfltBrnId == branch.brnId).dflAccNo;

            if (clsTbDefaultAccount.IsDefaultAccFound(14, branch.brnId))
                dflAccNoPur.EditValue = clsTbDefaultAccount.GetTblDefaultAccountsList.FirstOrDefault(x => x.dflStatus == 14 && x.dfltBrnId == branch.brnId).dflAccNo;

            if (clsTbDefaultAccount.IsDefaultAccFound(15, branch.brnId))
                dflAccNoPurRetu.EditValue = clsTbDefaultAccount.GetTblDefaultAccountsList.FirstOrDefault(x => x.dflStatus == 15 && x.dfltBrnId == branch.brnId).dflAccNo;

        }
        private bool SaveAutoAccNo()
        {
            if (!this.isNew)
            {
                AddOrUpdateDefultAcc();
                return true;
            }
            if (!bbiAutoAccNo.Checked)
                return true;
            return SetNewAccNo();
        }
        private bool SetNewAccNo()
        {
            tblBranch branch = tblBranchBindingSource.Current as tblBranch;
            if (branch == null) return false;
            long dAccBox = this.clsTbAccount.GetNewAccNoMain("1111");
            AddDefultMain(1111,dAccBox, "صناديق فرع " + branch.brnName, Convert.ToByte(1), 1, branch.brnId,(byte)DefaultAccType.Box);

            long dAccBank = this.clsTbAccount.GetNewAccNoMain("1112");
            AddDefultMain(1112, dAccBank, "بنوك فرع " + branch.brnName, Convert.ToByte(1), 1, branch.brnId,(byte)DefaultAccType.Bank);

            long dAccCustomer = this.clsTbAccount.GetNewAccNoMain("1121");
            AddDefultMain(1121, dAccCustomer, "عملاء فرع " + branch.brnName, Convert.ToByte(1), 1, branch.brnId,(byte)DefaultAccType.Customer);

            long dAccSupplier = this.clsTbAccount.GetNewAccNoMain("2111");
            AddDefultMain(2111, dAccSupplier, "موردي فرع " + branch.brnName, Convert.ToByte(1), 2, branch.brnId,(byte)DefaultAccType.Supplier);

            long dAccGrpAcc = this.clsTbAccount.GetNewAccNoMain("1141");
            AddDefultMain(1141,dAccGrpAcc, "مجموعات مخزنية فرع " + branch.brnName, Convert.ToByte(1), 1, branch.brnId,(byte)DefaultAccType.GrpAcc);

            long dAccGrpAccSale = this.clsTbAccount.GetNewAccNoMain("4111");
            AddDefultMain(4111, dAccGrpAccSale, "مبيعات فرع " + branch.brnName, Convert.ToByte(1), 4, branch.brnId,(byte)DefaultAccType.GrpAccSale);

            long dAccGrpAccSaleCost = this.clsTbAccount.GetNewAccNoMain("3121");
            AddDefultMain(3121, dAccGrpAccSaleCost, "تكلفة مبيعات فرع " + branch.brnName, Convert.ToByte(1), 3, branch.brnId,(byte)DefaultAccType.GrpAccSaleCost);

            long dAccGrpAccSaleRtrnCost = this.clsTbAccount.GetNewAccNoMain("3122");
            AddDefultMain(3122, dAccGrpAccSaleRtrnCost, "تكلفة مردود مبيعات فرع " + branch.brnName, Convert.ToByte(1), 3, branch.brnId,(byte)DefaultAccType.GrpAccSaleRtrnCost);

            long dAccGrpAccDiscount = this.clsTbAccount.GetNewAccNoMain("3124");
            AddDefultMain(3124,dAccGrpAccDiscount, "الخصم المسموح به فرع " + branch.brnName, Convert.ToByte(1), 3, branch.brnId,(byte)DefaultAccType.GrpAccDiscount);

            long dAccGrpAccSaleRtrn = this.clsTbAccount.GetNewAccNoMain("3123");
            AddDefultMain(3123,dAccGrpAccSaleRtrn, "مردود مبيعات فرع " + branch.brnName, Convert.ToByte(1), 3, branch.brnId,(byte)DefaultAccType.GrpAccSaleRtrn);
            db.SaveChanges();
            return true;
        }
        public void AddDefultMain(int accParent, long accNo, string accName, byte accCurrency, byte accCategorey, short brnId,byte Status)
        {
            tblAccount acc = new tblAccount()
            {
                accParent = accParent,
                accNo = accNo,
                accName = accName,
                accCurrency = accCurrency,
                accCat = accCategorey,
                accLevel = 5,
                accType = 1,
                accBrnId = brnId,
                accStatus = 1
            };
            db.tblAccounts.Add(acc);
            db.SaveChanges();
            
            db.tblDefaultAccounts.Add(
                new tblDefaultAccount
                {
                    dfltBrnId= brnId,
                    dflAccNo= acc.id,
                    dflStatus= Status
                });
        }
        public void AddOrUpdateDefultAcc(int AccNo, byte state)
        {
            tblBranch branch = tblBranchBindingSource.Current as tblBranch;
            if (clsTbDefaultAccount.IsDefaultAccFound(state, branch.brnId) && AccNo != 0)
                db.tblDefaultAccounts.FirstOrDefault(x => x.dflStatus == state && x.dfltBrnId == branch.brnId).dflAccNo = AccNo;
            else if (AccNo != 0)
            {
                db.tblDefaultAccounts.Add(
                 new tblDefaultAccount
                 {
                     dfltBrnId = branch.brnId,
                     dflAccNo = AccNo,
                     dflStatus = state
                 });
            }
            db.SaveChanges();
        }
            public void AddOrUpdateDefultAcc()
        {
            AddOrUpdateDefultAcc(((dflAccNoBox.EditValue as int?) ?? 0),3);
            AddOrUpdateDefultAcc(((dflAccNoBank.EditValue as int?) ?? 0), 4);
            AddOrUpdateDefultAcc(((dflAccNoCustomer.EditValue as int?) ?? 0),1);

            AddOrUpdateDefultAcc(((dflAccNoSupplier.EditValue as int?) ?? 0), 2);
            AddOrUpdateDefultAcc(((dflAccNoEmp.EditValue as int?) ?? 0),5);
            AddOrUpdateDefultAcc(((dflAccNoRep.EditValue as int?) ?? 0), 13);

            AddOrUpdateDefultAcc(((dflAccNoGrp.EditValue as int?) ?? 0), 6);
            AddOrUpdateDefultAcc(((dflAccNoSales.EditValue as int?) ?? 0), 7);
            AddOrUpdateDefultAcc(((dflAccNoSalesCost.EditValue as int?) ?? 0),8);

            AddOrUpdateDefultAcc(((dflAccNoSaleRetu.EditValue as int?) ?? 0), 9);
            AddOrUpdateDefultAcc(((dflAccNoSaleRetuCost.EditValue as int?) ?? 0), 10);
            AddOrUpdateDefultAcc(((dflAccNoDiscount.EditValue as int?) ?? 0), 11);

            AddOrUpdateDefultAcc(((dflAccNoPur.EditValue as int?) ?? 0), 14);
            AddOrUpdateDefultAcc(((dflAccNoPurRetu.EditValue as int?) ?? 0), 15);
        }
        private void InitData(tblBranch tbBranch)
        {
            if (tbBranch == null)
            {
                this.isNew = true;
                this.tbBranch = new tblBranch()
                {
                    brnNo = clsBranch.GetNewBranchNo(),
                    brnStatus = true
                };
                tblBranchBindingSource.DataSource = this.tbBranch;
                db.tblBranches.Add(tblBranchBindingSource.Current as tblBranch);
                ribbonPageGroupAutoAddAccNo.Visible = true;
                bbiAutoAccNo.Checked = true;
                BbiAutoAccNoItemVisibility(true);
            }
            else
            {
                ribbonPageGroupAutoAddAccNo.Visible = false;
                bbiAutoAccNo.Checked = false;
                BbiAutoAccNoItemVisibility(false);
                this.isNew = false;
                this.brnId = tbBranch.brnId;
                this.brnNo = tbBranch.brnNo;
                this.tbBranch = tbBranch;
                tblBranchBindingSource.DataSource = this.tbBranch;
                db.tblBranches.Attach(tblBranchBindingSource.Current as tblBranch);

                InitImg();
            }
        }

        private void InitImg()
        {
            this.clsBranchImg = new ClsTblBranchImg();
            this.imageBuffer = this.clsBranchImg.GetBranchImg(this.brnId);

            if (this.imageBuffer != null) LoadImage();
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            ChooseImage();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            if (!ValidateBrnNo()) return;
        //    if (!) return;
            if (SaveDB()&& SaveAutoAccNo())
            {
                SaveImage();
                _ucBranch.RefreshListDialog(_resource.GetString("brnSuccessMssg") + this.tbBranch.brnNo, this.isNew);
                this.Close();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void ChooseImage()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;

            try
            {
                FileStream fileStream = new FileStream(openFileDialog1.FileName, FileMode.Open);
                BinaryReader binaryReadr = new BinaryReader(fileStream);
                this.imageBuffer = binaryReadr.ReadBytes((int)fileStream.Length);

                fileStream.Close();
                binaryReadr.Close();
                LoadImage();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void LoadImage()
        {
            pictureEdit1.Image = new ClsTblBranchImg().GetBitmapLogImage();
        }

        private bool SaveImage()
        {
            if (this.imageBuffer == null) return true;

            if (this.isNew) return AddNewImage();
            else return clsBranchImg.SaveImage(this.brnId, this.imageBuffer);
        }

        private bool AddNewImage()
        {
            this.brnId = (from a in db.tblBranches
                          orderby a.brnId descending
                          select a.brnId).FirstOrDefault();

            tblBranchImg tbBranchImg = new tblBranchImg()
            {
                imgBrnId = this.brnId,
                imgBrn = this.imageBuffer
            };
            db.tblBranchImgs.Add(tbBranchImg);

            return SaveDB();
        }

        private bool ValidateBrnNo()
        {
            ChangeFocus();
            bool isFound = false;

            if (this.isNew)
                isFound = clsBranch.IsBranchNoFound(this.tbBranch.brnNo);
            else if (!this.isNew && this.tbBranch.brnNo != this.brnNo)
                isFound = clsBranch.IsBranchNoFound(this.tbBranch.brnNo);

            if (isFound)
            {
                XtraMessageBox.Show(string.Format(_resource.GetString("brnErrMssg"), this.tbBranch.brnNo));
                brnNoTextEdit.Focus();
            }

            return !isFound;
        }

        private void ChangeFocus()
        {
            if (brnNoTextEdit.ContainsFocus)
                brnNameTextEdit.Focus();
            else
                brnNoTextEdit.Focus();
        }

        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng)
            {
                _ci = new CultureInfo("ar");
                _resource = new ComponentResourceManager(typeof(Language.SystemManagementAr));
            }
            else
            {
                _ci = new CultureInfo("en");
                _resource = new ComponentResourceManager(typeof(Language.formAddBranchEn));
            }

            if (MySetting.GetPrivateSetting.LangEng) EnglishTranslation();
        }

        private void EnglishTranslation()
        {
            EnglishLayout();

            foreach (LayoutControlItem item in layoutControlGroup3.Items)
                _resource.ApplyResources(item, item.Name, _ci);
            foreach (LayoutControlItem item in layoutControlGroup5.Items)
                _resource.ApplyResources(item, item.Name, _ci);

            _resource.ApplyResources(ribbonPage1, ribbonPage1.Name);
            _resource.ApplyResources(ribbonPageGroup1, ribbonPageGroup1.Name);
            _resource.ApplyResources(barButtonItem1, barButtonItem1.Name, _ci);
            _resource.ApplyResources(barButtonItem2, barButtonItem2.Name, _ci);
            _resource.ApplyResources(layoutControlGroup3, layoutControlGroup3.Name, _ci);
            _resource.ApplyResources(layoutControlGroup4, layoutControlGroup4.Name, _ci);
            _resource.ApplyResources(layoutControlGroup5, layoutControlGroup5.Name, _ci);
            _resource.ApplyResources(btnImage, btnImage.Name, _ci);
            this.Text = _resource.GetString("this");
        }

        private void EnglishLayout()
        {
            dataLayoutControl1.BeginUpdate();
            dataLayoutControl1.RightToLeft = RightToLeft.No;
            dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = false;
            dataLayoutControl1.EndUpdate();

            this.RightToLeft = RightToLeft.No;
        }

        private bool SaveDB()
        {
            if (ClsSaveDB.Save(db, LogHelper.GetLogger()))
            {
                db.tblBranches.AddOrUpdate();
                Session.GetDataBranches();
                return true;
            }
            return false;
        }
    }
}