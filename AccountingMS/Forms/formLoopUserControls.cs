using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class formLoopUserControls : DevExpress.XtraEditors.XtraForm
    {
        accountingEntities db = new accountingEntities();
        ClsTblUserControl clsTbUserControl = new ClsTblUserControl();
        ClsTblControl clstbControl = new ClsTblControl();
        dynamic userControl = new ucOrders(OrderType.Receipt);
        private byte xtraInputText = 30;

        public formLoopUserControls()
        {
            InitializeComponent();
        }

        private void BtnLoopRibbonItems_Click(object sender, EventArgs e)
        {
            foreach (var control in this.userControl.ribbonControl.Manager.Items)
            {
                if (control is BarButtonItem item && !string.IsNullOrEmpty(item.Name))
                {
                    var input = XtraInputBox.Show(CreatXtraInputObject(item.Name, item.Caption));
                    if (input != null)
                    {
                        Console.WriteLine($"ItemName : {item.Name}, ItemCaption : {item.Caption.Split(new[] { '\r', '\n' }).FirstOrDefault()}");
                        AddTblControlObj(item.Name, item.Caption.Split(new[] { '\r', '\n' }).FirstOrDefault(), Convert.ToByte(input));
                    }
                }
            }
        }

        private void BtnLoopBarItems_Click(object sender, EventArgs e)
        {
            var frm = new FormMain();
            foreach (var control in frm.ribbonControl.Manager.Items)
            {
                if (control is BarItem item && !string.IsNullOrEmpty(item.Name))
                {
                    if (this.clsTbUserControl.CheclBBI(item.Name) || item is BarSubItem) continue;
                    if (item.Name.StartsWith("barButtonItemRprt")) continue;

                    var input = XtraInputBox.Show(CreatXtraInputObject(item.Name, item.Caption));
                    if (input != null)
                    {
                        Console.WriteLine($"Addedd BBiName : {item.Name}, caption : {item.Caption}");
                        AddTblUserControlObj(item.Name, item.Caption, Convert.ToByte(input));
                    }
                }
            }
        }

        private XtraInputBoxArgs CreatXtraInputObject(string itemName, string itemCaption)
        {
            return new XtraInputBoxArgs()
            {
                Caption = "AddItems?",
                Prompt = $"ItemName : {itemName} \nItemCaption : {itemCaption}",
                DefaultResponse = this.xtraInputText
            };
        }

        private void AddTblControlObj(string ucName, string ucCaption, byte ucNo)
        {
            db.tblControls.Add(new tblControl()
            {
                cntucNo = ucNo,
                cntName = ucName,
                cntCaption = ucCaption
            });
        }

        private void AddTblUserControlObj(string ucName, string ucCaption, byte ucNo)
        {
            db.tblUserControls.Add(new tblUserControl()
            {
                ucNo = ucNo,
                ucName = ucName,
                ucCaption = ucCaption
            });
        }

        private void BtnSaveDB_Click(object sender, EventArgs e)
        {
            if (ClsSaveDB.Save(db, LogHelper.GetLogger()))
                XtraMessageBox.Show("SavedSuccessfully!");
        }

        private void BtnShowUserControl_Click(object sender, EventArgs e)
        {
            this.userControl.Dock = DockStyle.Fill;
            Form frm = new Form() { Width = 700 };
            frm.Controls.Add(this.userControl);
            frm.Show();
        }

        private void BtnUpdateControlsEnCaption_Click(object sender, EventArgs e)
        {
            foreach (var tbControl in db.tblControls.ToList())
            {
                if (tbControl.cntName == "bbiNew")
                    tbControl.cntCaptionEn = "New";
                else if (tbControl.cntName == "bbiEdit")
                    tbControl.cntCaptionEn = "Edit";
                else if (tbControl.cntName == "bbiDelete")
                    tbControl.cntCaptionEn = "Delete";
                else if (tbControl.cntName == "bbiRefresh")
                    tbControl.cntCaptionEn = "Refresh";
                else if (tbControl.cntName == "bbiPrintPreview")
                    tbControl.cntCaptionEn = "Print";
            }
            if (ClsSaveDB.Save(db, LogHelper.GetLogger()))
                XtraMessageBox.Show("SavedSuccessfully!");
        }

        private void btnChangeCntucNo_Click(object sender, EventArgs e)
        {
            //ChangeCntucNo(32, 35);

            if (ClsSaveDB.Save(db, LogHelper.GetLogger()))
                XtraMessageBox.Show("SavedSuccessfully!");
        }

        private void ChangeCntucNo(byte v1, byte v2)
        {
            foreach (var tbControl in this.clstbControl.GetControlListByUCNo(v1))
            {
                db.tblControls.Attach(tbControl);
                tbControl.cntucNo = v2;
            }
        }
    }
}