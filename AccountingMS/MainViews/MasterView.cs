using DevExpress.XtraEditors;
using Hassib.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class MasterView : Hassib.Common.MainViews.MasterForm 
    {
        public MasterView()
        {
            InitializeComponent();
           
        }

        public override void AfterPrint()
        {
            
        }

        public override void BeforeSave()
        {
         
        }

        public override bool CheckAction(WindowActions actions)
        {
            return true;
        }

        public override void Saved()
        {
             
        }
    }
}