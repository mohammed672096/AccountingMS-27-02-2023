namespace AccountingMS.Forms
{
    public partial class Form_Progress : DevExpress.XtraEditors.XtraForm
    {

        private static Form_Progress instance;
        public static Form_Progress Instance { get { if (instance == null || instance.IsDisposed == true) instance = new Form_Progress(); return instance; } }

        public Form_Progress()
        {
            InitializeComponent();
        }


    }
}