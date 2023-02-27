using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DAL;
using System.Data;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using System.IO;
using DevExpress.Utils.VisualEffects;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.ObjectModel;
using System.Data.Linq;
using DevExpress.XtraLayout; 

namespace ERP.Forms
{
	public partial class frm_Inv_Invoice : frm_Master 
	{
		Inv_Invoice  Invoice = new Inv_Invoice();
		RepositoryItemGridLookUpEdit repoItems = new RepositoryItemGridLookUpEdit();
		RepositoryItemLookUpEdit repoUOM = new RepositoryItemLookUpEdit();
		RepositoryItemLookUpEdit repoSize = new RepositoryItemLookUpEdit();
		RepositoryItemLookUpEdit repoColor = new RepositoryItemLookUpEdit();
		RepositoryItemDateEdit repoDate = new RepositoryItemDateEdit();
		RepositoryItemLookUpEdit Revenuerepo = new RepositoryItemLookUpEdit();
		RepositoryItemLookUpEdit PaySourceRepo = new RepositoryItemLookUpEdit();
		RepositoryItemLookUpEdit repoUsers = new RepositoryItemLookUpEdit();
		RepositoryItemLookUpEdit repoCurrency = new RepositoryItemLookUpEdit();
		RepositoryItemLookUpEdit repoStore = new RepositoryItemLookUpEdit();
		DAL.ERPDataContext DetailsDataContexst;
		public Master.InvoiceType invoiceType ;
		GridView repositoryItemGridLookUpEdit1View;
		Dictionary<int, string> CodesDictionary = new Dictionary<int, string>();
		struct ItemBalanceInStore
		{
			public  int ItemID;
			public int StoreID;
			public int UnitID;
			public double Balance;
		}
		List<ItemBalanceInStore> itemsBalanceInStores = new List<ItemBalanceInStore>();
		void ViewItemBalanceInGrid(int itemID , int storeID )
		{

	   
			Task mainTask = Task.Factory.StartNew(() =>
			{
				double balance = 0;

				Task tsk = Task.Factory.StartNew(() =>
				{
					DAL.ERPDataContext dbc = new DAL.ERPDataContext(Program.setting.con);
					var logSumIN = dbc.Inv_StoreLogs.Where(x => x.ItemID == itemID && x.StoreID == storeID).Sum(x => x.ItemQuIN) ?? 0;
					var logSumOut = dbc.Inv_StoreLogs.Where(x => x.ItemID == itemID && x.StoreID == storeID).Sum(x => x.ItemQuOut) ?? 0;
					balance = ((double)logSumIN - (double)logSumOut);
				});
				Task.WaitAll(tsk);

				DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
				var units = db.Inv_ItemUnits.Where(x => x.ItemID == itemID).ToList();
				Invoke(new Action(delegate ()
				{

					itemsBalanceInStores.RemoveAll(x => x.ItemID == itemID);
					units.ForEach(u =>
					{
						itemsBalanceInStores.Add(new ItemBalanceInStore()
						{
							ItemID = itemID,
							StoreID = storeID,
							UnitID = u.UnitID,
							Balance =   balance / u.Factor
						});
					});
				}));
			});
		}
		//   object CustomersList;
		bool AllowDirectPost;
		bool AllowDirectPay;

		void LoadInvoiceType()
		{
			lyc_DeliveryDate.Visibility = lyc_DueDate.Visibility = lyc_Net.Visibility = lyc_Paid.Visibility =  lyc_Remains.Visibility
		    = lyc_SalesBook.Visibility = lyg_ItemAdds.Visibility = lyg_OtherExpences.Visibility = lyg_PartInfo.Visibility =
			lyg_Pays.Visibility = lyg_StockState.Visibility = lyc_Shiping .Visibility = lyg_Totals.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
	     	DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

			LookUpEdit_PartType .Properties.DataSource = new[]
					{
					  new { ID = 1 ,Name =  LangResource.Vendor  },
					  new { ID = 2 ,Name =  LangResource.Customer  },
					  new { ID = 3 ,Name =  LangResource.Employee  },
					  new { ID = 4 ,Name =  LangResource.Account  },
					};

			
			switch (invoiceType)
			{
				case  Master.InvoiceType.SalesInvoice :
					AllowDirectPost = db.St_WorkFlowSources.Where(x => x.Parent == (int)invoiceType && x.SourceType == (int)Master.InvoiceSourcesType.Inventory && x.Source == ((int)Master.SystemProssess.DirectWithdrawFromStore)).Count() == 1;
					AllowDirectPay  = db.St_WorkFlowSources.Where(x => x.Source  == (int)invoiceType && x.SourceType == (int)Master.InvoiceSourcesType.Cash  && x.Parent  == ((int)Master.SystemProssess.DirectPay )).Count() == 1;
						 lyc_DeliveryDate.Visibility = lyc_DueDate.Visibility = lyc_Net.Visibility = lyc_Paid.Visibility  = lyc_Remains.Visibility = lyc_SalesBook.Visibility 
						= lyg_ItemAdds.Visibility = lyg_OtherExpences.Visibility = lyg_PartInfo.Visibility =
					lyg_Pays.Visibility = lyg_StockState.Visibility = lyc_Shiping .Visibility = lyg_Totals.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always ;
					this.Text = LangResource.SalesInvoice;
					this.Name = "frm_SalesInvoice";
					lyc_PostDate.Text = LangResource.OutDate;
					lyc_DueDate.Text = LangResource.g_DueDate;
					LookUpEdit_PostState.Properties.DataSource = new List<Master.NameAndIDDataSource>() {new Master.NameAndIDDataSource()
					  {
						  ID = 0,
						  Name = string.Format("{0} {1}", LangResource.Without, LangResource.Withdraw_Stock),
					  } };

					if (AllowDirectPost) {
						((List<Master.NameAndIDDataSource>)LookUpEdit_PostState.Properties.DataSource).AddRange(
									new List<Master.NameAndIDDataSource>(){
				                    new Master.NameAndIDDataSource(){ ID = 1 ,Name =string.Format("{0} ", LangResource.WithdrawFromStore ) },
							        new Master.NameAndIDDataSource(){ ID = 2 ,Name =string.Format("{0} ", LangResource.WithdrawnToAnotherStore   ) } });
					}
					this.Name = "frm_SalesInvoice";
					this.Text = LangResource.SalesInvoice; 
					break;
				case Master.InvoiceType.PurchaseInvoice :
					AllowDirectPost = db.St_WorkFlowSources.Where(x => x.Parent == (int)invoiceType && x.SourceType == (int)Master.InvoiceSourcesType.Inventory && x.Source == ((int)Master.SystemProssess.DirectPostToStore )).Count() == 1;
					AllowDirectPay = db.St_WorkFlowSources.Where(x => x.Source == (int)invoiceType && x.SourceType == (int)Master.InvoiceSourcesType.Cash && x.Parent == ((int)Master.SystemProssess.DirectPay)).Count() == 1;
					lyc_DeliveryDate.Visibility = lyc_DueDate.Visibility = lyc_Net.Visibility = lyc_Paid.Visibility = lyc_Remains.Visibility = lyc_SalesBook.Visibility
				   = lyg_ItemAdds.Visibility = lyg_OtherExpences.Visibility = lyg_PartInfo.Visibility =
			        lyg_Pays.Visibility = lyg_StockState.Visibility = lyc_Shiping.Visibility = lyg_Totals.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
					this.Text = LangResource.PurchaseInvoice ;
					this.Name = "frm_PurchaseInvoice";
					lyc_PostDate.Text = LangResource.PostDate ;
					lyc_DueDate.Text = LangResource.g_DueDate;
					LookUpEdit_PostState.Properties.DataSource = new List<Master.NameAndIDDataSource>() {new Master.NameAndIDDataSource()
					  {
						  ID = 0,
						  Name = string.Format("{0} {1}", LangResource.Without, LangResource.Post_Stock),
					  } };

					if (AllowDirectPost)
					{
						((List<Master.NameAndIDDataSource>)LookUpEdit_PostState.Properties.DataSource).AddRange(
									new List<Master.NameAndIDDataSource>(){
									new Master.NameAndIDDataSource(){ ID = 1 ,Name =string.Format("{0} ", LangResource.PostedToStore ) },
									new Master.NameAndIDDataSource(){ ID = 2 ,Name =string.Format("{0} ", LangResource.PostedToAnotherStore   ) } });
					} 
					break;
				default:
					throw new NotImplementedException ();
	 
			}
		}
		public frm_Inv_Invoice(List<int> lst , Master.InvoiceType _InvoiceType)
		{
			InitializeComponent();
			invoiceType = _InvoiceType;
			LoadInvoiceType(); 
			New();
			this.list = lst;

		}
		public frm_Inv_Invoice(int ID)
		{
			InitializeComponent();
			LoadItem(ID);
			if (Invoice.InvoiceType == (byte)Master.InvoiceType.SalesInvoice)
			{
				if (CurrentSession.user.SalesInvoiceSececyLevel < Invoice.SecresyLevel)
				{
					XtraMessageBox.Show(LangResource.UserHasNoAccess);
					this.Close();
				}
			}
			else if (Invoice.InvoiceType == (byte)Master.InvoiceType.PurchaseInvoice )
			{
				if (CurrentSession.user.PurchaseInvoiceSececyLevel < Invoice.SecresyLevel)
				{
					XtraMessageBox.Show(LangResource.UserHasNoAccess);
					this.Close();
				}
			}
		}


		/// <summary>
		///  Load invoice By ID 
		/// </summary>
		/// <param name="ID"></param>
		/// <param name="lst"></param>
		public frm_Inv_Invoice(int ID, List<int> lst = null)
		{
		  
			InitializeComponent(); 
			LoadItem(ID);
			if (Invoice.InvoiceType == (byte)Master.InvoiceType.SalesInvoice)
			{
				if (CurrentSession.user.SalesInvoiceSececyLevel < Invoice.SecresyLevel)
				{
					XtraMessageBox.Show(LangResource.UserHasNoAccess);
					this.Close();
				}
			}
			else if (Invoice.InvoiceType == (byte)Master.InvoiceType.PurchaseInvoice)
			{
				if (CurrentSession.user.PurchaseInvoiceSececyLevel < Invoice.SecresyLevel)
				{
					XtraMessageBox.Show(LangResource.UserHasNoAccess);
					this.Close();
				}
			}
			this.list = lst;
		}
		/// <summary>
		/// Creat new invoice and load data from outer source 
		/// </summary>
		/// <param name="ID">The source ID </param>
		/// <param name="TypeToLoad">The source of the invoice to load data from [  Ex: ord=Sales order , req=Sales Requst , pof=Price Offer ]  </param>
		/// <param name="lst"></param>
		public frm_Inv_Invoice(int ID,Master.PartTypes _partType, Master.InvoiceType _InvoiceType, List<int> lst = null)
		{
			InitializeComponent();
			invoiceType = _InvoiceType;
			LoadInvoiceType();
			New();
			Invoice.PartType = (byte)_partType;
			Invoice.PartID = ID; 
			this.list = lst;

		}
		/// <summary>
		/// This field is used to get the names of the columns exp:nameof(InvoDInsta.ItemID)
		/// </summary>
		Inv_InvoiceDetail InvoDInsta = new Inv_InvoiceDetail(); // instance of invoice detal to get the names from 
		public override void frm_Load(object sender, EventArgs e)
		{
			LoadInvoiceType();

			GridView_Items.Columns.Add(new GridColumn() { VisibleIndex = 0, Name = "clmIndex", FieldName = "Index", UnboundType = DevExpress.Data.UnboundColumnType.Integer ,MaxWidth = 25  });
			GridView_Items.Columns["Index"].OptionsColumn.AllowFocus = false;
			GridView_Items.Columns.Add(new GridColumn() { VisibleIndex = 1, Name = "clmCode", FieldName = "Code" ,UnboundType = DevExpress.Data.UnboundColumnType.String });
			GridView_Items.Columns.Add(new GridColumn() { VisibleIndex = 50, Name = "clmCurrentBalance", FieldName = "CurrentBalance", UnboundType = DevExpress.Data.UnboundColumnType.Object  });
			Master.RestoreGridLayout(GridView_Items, this);

			this.spn_DeductionTax.Properties.Increment = 0.01M;
			this.spn_DeductionTax.Properties.Mask.EditMask = "p";
			this.spn_DeductionTax.Properties.Mask.UseMaskAsDisplayFormat = true ;
			this.spn_DeductionTax.Properties.MaxValue = 1;

			this.spn_AddTax  .Properties.Increment = 0.01M;
			this.spn_AddTax.Properties.Mask.EditMask = "p";
			this.spn_AddTax.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.spn_AddTax.Properties.MaxValue = 1;

			this.spn_Discount .Properties.Increment = 0.01M;
			this.spn_Discount.Properties.Mask.EditMask = "p";
			this.spn_Discount.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.spn_Discount.Properties.MaxValue = 1;

			RefreshData();

			repoItems.CloseUp += glkp_Customer_CloseUp; 
			repoItems.ValidateOnEnterKey = true;
			repoItems.AllowNullInput = DefaultBoolean.False;
			repoItems.BestFitMode = BestFitMode.BestFitResizePopup;
			repoItems.ImmediatePopup = true;
			repoItems.EditValueChanged += RepoItems_EditValueChanged;
			repoItems.TextEditStyle = TextEditStyles.DisableTextEditor;

			lkp_Store.EditValueChanging += Lkp_Store_EditValueChanging;
			LookUpEdit_PartID.Properties.PopupFormWidth = 300;
			GridView_Items.CustomUnboundColumnData += GridView_Items_CustomUnboundColumnData; 


			repositoryItemGridLookUpEdit1View = new GridView();
			repoItems.View = this.repositoryItemGridLookUpEdit1View;
			repositoryItemGridLookUpEdit1View.Appearance.HeaderPanel.Options.UseTextOptions = true;
			repositoryItemGridLookUpEdit1View.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Far;
			repositoryItemGridLookUpEdit1View.Appearance.Row.Options.UseTextOptions = true;
			repositoryItemGridLookUpEdit1View.Appearance.Row.TextOptions.HAlignment = HorzAlignment.Near;
			repositoryItemGridLookUpEdit1View.FocusRectStyle = DrawFocusRectStyle.RowFocus;
			repositoryItemGridLookUpEdit1View.OptionsBehavior.AllowAddRows = DefaultBoolean.False;
			repositoryItemGridLookUpEdit1View.OptionsBehavior.AllowDeleteRows = DefaultBoolean.False;
			repositoryItemGridLookUpEdit1View.OptionsBehavior.AutoSelectAllInEditor = false;
			repositoryItemGridLookUpEdit1View.OptionsBehavior.AutoUpdateTotalSummary = false;
			repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
			repositoryItemGridLookUpEdit1View.OptionsSelection.UseIndicatorForSelection = true;
			repositoryItemGridLookUpEdit1View.OptionsView.BestFitMaxRowCount = 10;
			repositoryItemGridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
			repositoryItemGridLookUpEdit1View.OptionsView.ShowDetailButtons = false;
			repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
			repositoryItemGridLookUpEdit1View.OptionsView.ShowIndicator = false;


			LookUpEdit_PartID.Properties.View.PopulateColumns(LookUpEdit_PartID.Properties.DataSource);
	  
			Master.TranslateGridColumn(gridView3);
			Master.TranslateGridColumn(gridView1);
			Master.TranslateGridColumn(gridView3);
			Master.TranslateGridColumn(gridView4);
			Master.TranslateGridColumn(LookUpEdit_PartID.Properties.View);



			repositoryItemGridLookUpEdit1View.PopulateColumns(repoItems.DataSource);
			repositoryItemGridLookUpEdit1View.Columns["ID"].Visible = false;



			btn_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
			barItem_Search.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
			SubItem_ConvertTo.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
			btn_ConverToItemTake.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
			btn_ConverToItemTake.ItemClick += Btn_ConverToItemTake_ItemClick;

			lkp_List.ValueMember = "ID";
			lkp_List.DisplayMember = "ID";

			repoStore.NullText =  repoItems.NullText = LookUpEdit_SourceID.Properties.NullText  = repoUOM.NullText = repoColor.NullText = repoSize.NullText= Revenuerepo.NullText  = "";
			lkp_Store.Properties.ValueMember = "ID";
			lkp_Store.Properties.DisplayMember = "Name";

		 
			LookUpEdit_SourceID .Properties.ValueMember = "ID";
			LookUpEdit_SourceID.Properties.DisplayMember = "Name";


			LookUpEdit_SalesRep .Properties.ValueMember = "ID";
			LookUpEdit_SalesRep.Properties.DisplayMember = "Name";


			LookUpEdit_PartID.Properties.ValueMember = "ID";
			LookUpEdit_PartID.Properties.DisplayMember = "Name";

			LookUpEdit_PartType .Properties.ValueMember = "ID";
			LookUpEdit_PartType.Properties.DisplayMember = "Name";
			LookUpEdit_PartType.Properties.ShowHeader = false;
		 	//LookUpEdit_PartType.Properties.Columns[0].Visible  = false ;


			LookUpEdit_Source.Properties.ValueMember = "ID";
			LookUpEdit_Source.Properties.DisplayMember = "Name";


			LookUpEdit_PostState .Properties.ValueMember = "ID";
			LookUpEdit_PostState.Properties.DisplayMember = "Name";
			LookUpEdit_PostState.Properties.ShowHeader = false;
			//LookUpEdit_PostState.Properties.Columns[0].Visible = false;

			LookUpEdit_PostAcount.Properties.ValueMember = "ID";
			LookUpEdit_PostAcount.Properties.DisplayMember = "Name";
			LookUpEdit_PostAcount.Properties.ShowHeader = false;
			//LookUpEdit_PostAcount.Properties.Columns[0].Visible = false;


			LookUpEdit_PartID.Properties.ValueMember = "ID";
			LookUpEdit_PartID.Properties.DisplayMember = "Name";

			Revenuerepo.Buttons.Add(new EditorButton("Add", ButtonPredefines.Plus));
			Revenuerepo.ButtonClick += Revenuerepo_ButtonClick;
			Revenuerepo.ValueMember = "ID";
			Revenuerepo.DisplayMember = "Name";

			PaySourceRepo.ValueMember = "ID";
			PaySourceRepo.DisplayMember = "Name";

			repoItems.ValueMember = "ID";
			repoItems.DisplayMember = "Name";
		 
			
			repoStore.ValueMember = "ID";
			repoStore.DisplayMember = "Name";

			 

			repoItems.Buttons.Add(new EditorButton("Add", ButtonPredefines.Plus));
			repoItems.ButtonClick += RepoItems_ButtonClick;
			 

			repoUOM.ValueMember = "ID";
			repoUOM.DisplayMember = "Name";
			repoUOM.PopulateColumns();
			repoUOM.Columns["ID"].Visible = false;

			repoSize.ValueMember = "ID";
			repoSize.DisplayMember = "Name";
			repoSize.PopulateColumns();
			repoSize.Columns["ID"].Visible = false;
			repoSize.Buttons.Add(new EditorButton("Add", ButtonPredefines.Plus));
			repoSize.ButtonClick += RepoSize_ButtonClick;
			repoColor.ValueMember = "ID";
			repoColor.DisplayMember = "Name";
			repoColor.PopulateColumns();
			repoColor.Columns["ID"].Visible = false;
			repoColor.Buttons.Add(new EditorButton("Add", ButtonPredefines.Plus));
			repoColor.ButtonClick += RepoColor_ButtonClick;

			repoDate.CalendarView = CalendarView.TouchUI;
			RepositoryItemSpinEdit repospin = new RepositoryItemSpinEdit();
			RepositoryItemSpinEdit repospinPrecintage = new RepositoryItemSpinEdit();

			repospinPrecintage.Increment = 0.01M;
			repospinPrecintage.Mask.EditMask = "p";
			repospinPrecintage.Mask.UseMaskAsDisplayFormat = true;
			repospinPrecintage.MaxValue = 1;

			GridControl_Items.RepositoryItems.AddRange(new RepositoryItem[]
			{ repoStore,repoItems , repoUOM, repospin,repoColor ,repoSize ,repoDate,repospinPrecintage });
			gridControl_OtherCosts.RepositoryItems.Add(Revenuerepo);
			gridControl_OtherCosts.RepositoryItems.Add(repospin);
			GridView_OtherCosts.Columns["AccID"].ColumnEdit = Revenuerepo;
			GridView_OtherCosts.Columns["Amount"].ColumnEdit = repospin;

			GridView_OtherCosts.Columns["ID"].Visible = GridView_OtherCosts.Columns["ID"].OptionsColumn.ShowInCustomizationForm = false;
			GridView_OtherCosts.Columns["InID"].Visible = GridView_OtherCosts.Columns["InID"].OptionsColumn.ShowInCustomizationForm = false;
			GridView_OtherCosts.TranslateColumns();

			GridView_Items.Columns["ID"].OptionsColumn.AllowShowHide  = GridView_Items.Columns["InvoiceID"].OptionsColumn.AllowShowHide =
				GridView_Items.Columns["ID"].Visible = GridView_Items.Columns["InvoiceID"].Visible  = false ; 
			GridView_Items.Columns["CurrentBalance"].OptionsColumn.AllowEdit = false;
			GridView_Items.Columns[nameof(InvoDInsta.ItemID)].ColumnEdit = repoItems;
			GridView_Items.Columns[nameof(InvoDInsta.StoreID )].ColumnEdit = repoStore;

			GridView_Items.Columns[nameof(InvoDInsta.ItemUnitID)].ColumnEdit = repoUOM;
			GridView_Items.Columns[nameof(InvoDInsta.Price)].ColumnEdit = repospin;
			GridView_Items.Columns[nameof(InvoDInsta.Discount)].ColumnEdit = repospinPrecintage;
			GridView_Items.Columns[nameof(InvoDInsta.DiscountValue)].ColumnEdit = repospin; 
			GridView_Items.Columns[nameof(InvoDInsta.ItemQty)].ColumnEdit = repospin;
			GridView_Items.Columns[nameof(InvoDInsta.Size)].ColumnEdit = repoSize;
			GridView_Items.Columns[nameof(InvoDInsta.Color)].ColumnEdit = repoColor;
			GridView_Items.Columns[nameof(InvoDInsta.ExpDate)].ColumnEdit = repoDate;
			GridView_Items.Columns[nameof(InvoDInsta.TotalPrice)].OptionsColumn.AllowFocus = false;
			GridView_Items.Columns[nameof(InvoDInsta.TotalCostValue )].OptionsColumn.AllowFocus = false; 
			GridView_Items.Columns["CurrentBalance"].OptionsColumn.ShowInCustomizationForm = (bool)CurrentSession.user.ShowItemBalance;
			if (GridView_Items.Columns["CurrentBalance"].Visible && !(bool)CurrentSession.user.ShowItemBalance)
				GridView_Items.Columns["CurrentBalance"].Visible = false;
			GridView_Items.TranslateColumns();

			GridView_Items.Columns["Code"].Caption = LangResource.Barcode;
			GridView_Items.Columns[nameof(InvoDInsta.TotalCostValue )].Caption = LangResource.ActCost ;
			GridView_Items.Columns[nameof(InvoDInsta.Batch  )].Caption = LangResource.Batch ;
			GridView_Items.Columns["CurrentBalance"].Caption = LangResource.CurrentBalance ;

			lkp_List.DisplayMember = "ID";
			lkp_List.ValueMember = "ID";
			lkp_List.PopulateColumns();
			lkp_List.Columns[1].FormatType = FormatType.DateTime;
			lkp_List.Columns[1].FormatString = "g";

		  
			RepositoryItemLookUpEdit repoPayTypes = new RepositoryItemLookUpEdit();

			var payTypes = new List<Master.NameAndIDDataSource>()
						{ 
					      	new Master.NameAndIDDataSource(){ID = 5 ,Name = LangResource.PreviousCashNote }
						};

			if (AllowDirectPay && CurrentSession.user.CanPayFromSalesInvoice)
			{
				  payTypes.AddRange(new List<Master.NameAndIDDataSource> ()
						{
						new Master.NameAndIDDataSource(){ID = 1 ,Name = LangResource.CashPay  },
						new Master.NameAndIDDataSource(){ID = 2 ,Name = LangResource.BankTransfer },
						new Master.NameAndIDDataSource(){ID = 3 ,Name = LangResource.PayCards },
						new Master.NameAndIDDataSource(){ID = 4 ,Name = LangResource.OnAccount }, 
			            } );
			}
			if(AllowDirectPost == true)
			{

			}

			repoPayTypes.DataSource = payTypes;
			repoPayTypes.ValueMember = "ID";
			repoPayTypes.DisplayMember  = "Name";

			repoCurrency.ValueMember = "ID";
			repoCurrency.DisplayMember = "Name";
			repoCurrency.NullText = "";
			repoUsers.ValueMember = "ID";
			repoUsers.DisplayMember = "Name";
			repoUsers.NullText = "";
			PaySourceRepo.NullText = "";

			GridControl_Pays.RepositoryItems.AddRange (new RepositoryItem[] {
			PaySourceRepo,
			repospin,
			repoPayTypes,
			repoCurrency,
			repoUsers
			}); 
			GridView_Pays.Columns["PayID"].ColumnEdit = PaySourceRepo;
			GridView_Pays.Columns["PayType"].ColumnEdit = repoPayTypes;
			GridView_Pays.Columns["CurrancyRate"].ColumnEdit = repospin;
			GridView_Pays.Columns["Amount"].ColumnEdit = repospin;
			GridView_Pays.Columns["CurrancyID"].ColumnEdit = repoCurrency;
			GridView_Pays.Columns["UserID"].ColumnEdit = repoUsers;
			GridView_Pays.Columns["SourceType"].Visible =
			GridView_Pays.Columns["SourceID"].Visible =
			GridView_Pays.Columns["UserID"].OptionsColumn.AllowFocus =
			GridView_Pays.Columns["InsertDate"].OptionsColumn.AllowFocus =
			GridView_Pays.Columns["ID"].Visible = false;

			RepositoryItemButtonEdit buttonEdit = new RepositoryItemButtonEdit();
			GridControl_Pays.RepositoryItems.Add(buttonEdit); 
			buttonEdit.Buttons.Clear();
			buttonEdit.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
			buttonEdit.ButtonClick += ButtonEdit_ButtonClick;
			GridColumn clmnDelete = new GridColumn() { Name = "Delete", FieldName = "Delete",ColumnEdit = buttonEdit, VisibleIndex = 14, Width = 15 };
			buttonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
			GridColumn clmnDeleteBarcode = new GridColumn() { Name = "Delete", ColumnEdit = buttonEdit, VisibleIndex = 100, Width = 15 }; 
			GridView_Pays.Columns.Add(clmnDelete);
			
			GridView_Pays.TranslateColumns();
			GridView_Pays.Columns["PayID"].Caption = LangResource.PayAccount;
			GridView_Pays.Columns["PayType"].Caption = LangResource.PayType ;
			GridView_Pays.Columns["Refrence"].Caption = LangResource.RefrenceNumber;
			GridView_Pays.Columns["PayDate"].Caption = LangResource.PayDate;
			GridView_Pays.Columns["CurrancyRate"].Caption = LangResource.CurrancyRate;
			GridView_Pays.Columns["InsertDate"].Caption = LangResource.InsertDate;



			GridView_Pays.FocusedColumnChanged += GridView_Pays_FocusedColumnChanged;
			GridView_Pays.FocusedRowChanged += GridView_Pays_FocusedRowChanged;
			GridView_Pays.CustomRowCellEditForEditing += GridView_Pays_CustomRowCellEditForEditing;
			GridView_Pays.InitNewRow += GridView_Pays_InitNewRow;
			GridView_Pays.CellValueChanged += GridView_Pays_CellValueChanged;
			GridView_Pays.RowCountChanged += GridView_Pays_RowCountChanged;
			GridView_Pays.ValidateRow += GridView_Pays_ValidateRow;
			GridView_Pays.InvalidRowException += GridView_Pays_InvalidRowException;
			GridControl_Pays.ProcessGridKey += GridControl_Pays_ProcessGridKey;

			// SubItem_Printbills
			//  
			SubItem_Printbills.Caption = LangResource.PrintBills;
			btn_PrintItemsBills.Caption = LangResource.ItemWithDrawOrder;
			btn_PrintItemsBills.ItemClick += Btn_PrintItemsBills_ItemClick;
			btn_PayBills.Caption = LangResource.InvoicePayBill;
			btn_PayBills.ItemClick += Btn_PayBills_ItemClick;
			SubItem_Printbills.Visibility = btn_PrintItemsBills.Visibility = btn_ShowHints .Visibility =
				btn_PayBills.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
			GetData();

			RunUserPrivilage();



			#region DataChangedEventHandlers 
			dt_Date.EditValueChanged   += DataChanged;
			memoEdit1.EditValueChanged += DataChanged;
			lkp_Store.EditValueChanged += DataChanged;
			txt_Code.EditValueChanged  += DataChanged;
			LookUpEdit_PartID.EditValueChanged += DataChanged;
			LookUpEdit_SourceID.EditValueChanged += DataChanged;
			txt_Address.EditValueChanged += DataChanged;
			txt_Attn.EditValueChanged += DataChanged;
			txt_Code.EditValueChanged += DataChanged;
			dt_DeliveryDate.EditValueChanged += DataChanged;
			dt_DueDate.EditValueChanged += DataChanged; 
			dt_OutFromStoreDate.EditValueChanged += DataChanged;
			lkp_Car.EditValueChanged += DataChanged;
			lkp_CCenter.EditValueChanged += DataChanged;
			lkp_Driver.EditValueChanged += DataChanged;
			lkp_SaleBookID.EditValueChanged += DataChanged;
			memoEdit1.EditValueChanged += DataChanged;
			memoEdit_ShipTo.EditValueChanged += DataChanged;
			spn_AddTax.EditValueChanged += DataChanged;
			spn_AddTaxVal.EditValueChanged += DataChanged;
			spn_Discount.EditValueChanged += DataChanged;
			spn_DiscountVal.EditValueChanged += DataChanged;
			spn_Net.EditValueChanged += DataChanged;
			spn_Paid.EditValueChanged += DataChanged;
			spn_DeductionTax.EditValueChanged += DataChanged;
			spn_DeductionTaxVal.EditValueChanged += DataChanged;
			spn_TotalRevenue.EditValueChanged += DataChanged;
		   


			#endregion
		}

		private void GridControl_Pays_ProcessGridKey(object sender, KeyEventArgs e)
		{
			try
			{

				GridControl gridControl = sender as GridControl;
				GridView focusedView = gridControl.FocusedView as GridView;
				if (e.KeyCode == Keys.Return)
				{
					GridColumn focusedColumn = (gridControl.FocusedView as ColumnView).FocusedColumn;
					int focusedRowHandle = (gridControl.FocusedView as ColumnView).FocusedRowHandle;
					if (focusedView.FocusedColumn == focusedView.Columns["Refrence"])
					{
						GridControl_Pays_ProcessGridKey(sender, new KeyEventArgs(Keys.Tab));
					}

					if (focusedView.FocusedRowHandle < 0)
					{
						focusedView.AddNewRow();
						focusedView.FocusedColumn = focusedView.Columns["Refrence"];
					}
					else
					{
						focusedView.FocusedRowHandle = focusedRowHandle + 1;
						focusedView.FocusedColumn = focusedView.Columns["Refrence"];
					}
					e.Handled = true;
				}
				else if (e.KeyCode == Keys.Tab && e.Modifiers != Keys.Shift)
				{
					if (focusedView.FocusedColumn.VisibleIndex == 0)
						focusedView.FocusedColumn = focusedView.VisibleColumns[focusedView.VisibleColumns.Count - 1];
					else
						focusedView.FocusedColumn = focusedView.VisibleColumns[focusedView.FocusedColumn.VisibleIndex - 1];
					e.Handled = true;
				}
				else if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
					focusedView.DeleteSelectedRows();
				//else if (e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift)
				//{
				//    if (focusedView.FocusedColumn.VisibleIndex == focusedView.VisibleColumns.Count)
				//        focusedView.FocusedColumn = focusedView.VisibleColumns[0];
				//    else
				//        focusedView.FocusedColumn = focusedView.VisibleColumns[focusedView.FocusedColumn.VisibleIndex + 1];
				//    e.Handled = true;
				//}
				//else
				//{
				//    //if (e.KeyCode != Keys.Up || focusedView.GetFocusedRow() == null || !(focusedView.GetFocusedRow() as DataRowView).IsNew || focusedView.GetFocusedRowCellValue("ItemId") != null && !(focusedView.GetFocusedRowCellValue("ItemId").ToString() == string.Empty))
				//    //    return;
				//    //focusedView.DeleteRow(focusedView.FocusedRowHandle);
				//}
			}
			catch
			{
			}
		}

		private void GridView_Pays_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
		{
			if ((e.Row as Acc_Pay ).PayID  == 0)
				e.ExceptionMode = ExceptionMode.Ignore;
			else
				e.ExceptionMode = ExceptionMode.NoAction;
		}

		private void LookUpEdit_PostState_EditValueChanged(object sender, EventArgs e)
		{
			DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
			var store = CurrentSession.UserAccessbileStores.Where(x => x.ID == lkp_Store.EditValue.ToInt()).SingleOrDefault();
	        var storesInventoryAccounts = db.Acc_Accounts.Where(x => CurrentSession.UserAccessbileStores.Select(s => s.InventoryAccount).Contains(x.ID)).Select(x=>new { x.ID , x.Name }).ToList();
			var storesSalesAccounts = db.Acc_Accounts.Where(x => CurrentSession.UserAccessbileStores.Select(s => s.SellAccountID).Contains(x.ID)).Select(x => new { x.ID, x.Name }).ToList(); 
			var storesPurchaseAccounts = db.Acc_Accounts.Where(x => CurrentSession.UserAccessbileStores.Select(s => s.PurchaseAccountID ).Contains(x.ID)).Select(x => new { x.ID, x.Name }).ToList(); 
			var storesCostOfSoldGoodsAccounts = db.Acc_Accounts.Where(x => CurrentSession.UserAccessbileStores.Select(s => s.CostOfSoldGoodsAcc).Contains(x.ID)).Select(x => new { x.ID, x.Name }).ToList();
			var stores = CurrentSession.UserAccessbileStores.Select(x => new { x.ID, x.Name }).ToList();
			if (store == null)
			{ 
				return; 
			}
			switch (LookUpEdit_PostState.EditValue .ToInt() )
			{
				case 0:
					LookUpEdit_PostAcount.Properties.DataSource = null;
					LookUpEdit_PostAcount.EditValue = null;
					lyc_PostAccount.Visibility= lyc_PostDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
					break;
				case 1:

					LookUpEdit_PostAcount.ReadOnly = true;
					lyc_PostAccount.Visibility = lyc_PostDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always ;
					if (invoiceType == Master.InvoiceType.SalesInvoice)
					{
						LookUpEdit_PostAcount.Properties.DataSource = CurrentSession.Company.StockIsPeriodic ? stores : storesCostOfSoldGoodsAccounts;
						LookUpEdit_PostAcount.EditValue = Invoice.PostAccount = CurrentSession.Company.StockIsPeriodic ? store.SellAccountID : store.CostOfSoldGoodsAcc;
					}
					else if (invoiceType == Master.InvoiceType.SalesReturn)
					{
						LookUpEdit_PostAcount.Properties.DataSource = CurrentSession.Company.StockIsPeriodic ? stores : storesInventoryAccounts;
						LookUpEdit_PostAcount.EditValue = Invoice.PostAccount = CurrentSession.Company.StockIsPeriodic ? store.ID : store.InventoryAccount;
					}
					else if (invoiceType == Master.InvoiceType.PurchaseInvoice)
					{
						LookUpEdit_PostAcount.Properties.DataSource = CurrentSession.Company.StockIsPeriodic ? stores : storesInventoryAccounts;
						LookUpEdit_PostAcount.EditValue = Invoice.PostAccount = CurrentSession.Company.StockIsPeriodic ? store.ID : store.InventoryAccount;
					}
					else if (invoiceType == Master.InvoiceType.PurchaseReturn)
					{
						throw new NotImplementedException(); 
					}
					else if (invoiceType == Master.InvoiceType.ItemAdd)
					{
						throw new NotImplementedException();
					}
					else if (invoiceType == Master.InvoiceType.ItemDamage)
					{
						throw new NotImplementedException();
					}
					else if (invoiceType == Master.InvoiceType.ItemOpenBalance)
					{
						throw new NotImplementedException();
					}
					else if (invoiceType == Master.InvoiceType.ItemTake)
					{
						throw new NotImplementedException();
					}
					else
						throw new NotImplementedException();
					break;
				case 2:
					LookUpEdit_PostAcount.ReadOnly = false ;
					lyc_PostAccount.Visibility = lyc_PostDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
					if (invoiceType == Master.InvoiceType.SalesInvoice)
					{
						LookUpEdit_PostAcount.Properties.DataSource = CurrentSession.Company.StockIsPeriodic ? stores : storesInventoryAccounts;
						LookUpEdit_PostAcount.EditValue = CurrentSession.Company.StockIsPeriodic ? store.SellAccountID : store.InventoryAccount ;
					}
					else if (invoiceType == Master.InvoiceType.SalesReturn)
					{
						LookUpEdit_PostAcount.Properties.DataSource = CurrentSession.Company.StockIsPeriodic ? stores : storesCostOfSoldGoodsAccounts;
						LookUpEdit_PostAcount.EditValue = CurrentSession.Company.StockIsPeriodic ? store.ID : store.InventoryAccount;
					}
					else if (invoiceType == Master.InvoiceType.PurchaseInvoice)
					{
						LookUpEdit_PostAcount.Properties.DataSource = CurrentSession.Company.StockIsPeriodic ? stores : storesInventoryAccounts;
						LookUpEdit_PostAcount.EditValue = CurrentSession.Company.StockIsPeriodic ? store.ID : store.InventoryAccount;
					}
					else if (invoiceType == Master.InvoiceType.PurchaseReturn)
					{
						throw new NotImplementedException();
					}
					else if (invoiceType == Master.InvoiceType.ItemAdd)
					{
						throw new NotImplementedException();
					}
					else if (invoiceType == Master.InvoiceType.ItemDamage)
					{
						throw new NotImplementedException();
					}
					else if (invoiceType == Master.InvoiceType.ItemOpenBalance)
					{
						throw new NotImplementedException();
					}
					else if (invoiceType == Master.InvoiceType.ItemTake)
					{
						throw new NotImplementedException();
					}
					else
						throw new NotImplementedException();
					break;
			} 

		}

		 

		private void LookUpEdit_PartType_EditValueChanged(object sender, EventArgs e)
		{
			DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
			switch (LookUpEdit_PartType.EditValue.ToInt())
			{
				case 0:
					LookUpEdit_PartID.Properties.DataSource = null; 
					LookUpEdit_PartID.EditValue =0;
					break;
				case 1:
					LookUpEdit_PartID.Properties.DataSource = CurrentSession.UserAccessbileVendors .Select(c=> new { c.ID, c.Name, c.City, c.Address, c.Mobile, c.Phone }).ToList();
					LookUpEdit_PartID.EditValue = CurrentSession.user.DefaultVendor ;
					layoutControlItem3.Text = LangResource.Vendor;
					break;
				case 2:
					LookUpEdit_PartID.Properties.DataSource = CurrentSession.UserAccessbileCustomers.Select(c => new { c.ID, c.Name, c.City, c.Address, c.Mobile, c.Phone }).ToList();
					LookUpEdit_PartID.EditValue = CurrentSession.user.DefaultCustomer ;
					layoutControlItem3.Text = LangResource.Customer ;

					break;
				case 3:
					LookUpEdit_PartID.Properties.DataSource = db.HR_Employees .Select(c => new { c.ID, c.Name}).ToList();
					LookUpEdit_PartID.EditValue = 0;
					layoutControlItem3.Text = LangResource.Employee ;

					break;
				case 4:
					LookUpEdit_PartID.Properties.DataSource = db.Acc_Accounts.Where(x=> CurrentSession.UserAccessbileAccounts.Select(a=>a.ID ).Contains(x.ID ) && 
					db.Acc_Accounts .Where (a=>a.ParentID  == x.ID ).Count() == 0 ).Select(c => new { c.ID, c.Name }).ToList();
					LookUpEdit_PartID.EditValue = 0;
					layoutControlItem3.Text = LangResource.Account ;

					break;

			}
		}

		private void GridView_Items_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
		{
			if (e.Column.FieldName == "Index")
			{
				if (e.IsGetData)
					e.Value = e.ListSourceRowIndex + 1;
			}
			else if (e.Column.FieldName == "Code")
			{
				if (e.IsGetData)
				{

					var code = "";
					CodesDictionary.TryGetValue(GridView_Items.GetRowHandle(e.ListSourceRowIndex), out code);
					e.Value = code;

				}
				else
				{
					CodesDictionary.Remove(GridView_Items.GetRowHandle(e.ListSourceRowIndex));
					if (e.Value != null)
						CodesDictionary.Add(GridView_Items.GetRowHandle(e.ListSourceRowIndex), e.Value.ToString());
				}
			}
			else if (e.Column.FieldName == "CurrentBalance")
			{
				if (e.IsGetData)
				{
					var row = e.Row as Inv_InvoiceDetail ;
					if (row == null || row.ItemID == 0) return;
				   
					var balance =itemsBalanceInStores.Where(x=>x.ItemID == row.ItemID&&x.UnitID == row.ItemUnitID  && x.StoreID == (row.StoreID??lkp_Store.EditValue.ToInt())).FirstOrDefault() ;
					if(balance.ItemID == 0)
					{
						ViewItemBalanceInGrid(row.ItemID, (row.StoreID ?? lkp_Store.EditValue.ToInt()));
						return;
					}
				 
					e.Value = balance.Balance ;
				}
				
			}

		}

		private void GridView_Pays_ValidateRow(object sender, ValidateRowEventArgs e)
		{
			var row = e.Row as Acc_Pay;
			var view = sender as GridView;
			if(row.Amount <= 0)
			{ 
				view.SetColumnError(view.Columns[nameof(row.Amount)], LangResource.ErrorValMustBeGreaterThan0);

				e.Valid = false;
			}
			if(row.PayType <= 0)
			{
				view.SetColumnError(view.Columns[nameof(row.PayType)], ""); 
				e.Valid = false;
			}
			if (row.PayID  <= 0)
			{
				view.SetColumnError(view.Columns[nameof(row.PayID)], ""); 
				e.Valid = false;
			}
			if (row.PayDate.Year <= 1950)
			{
				
				view.SetColumnError(view.Columns[nameof(row.PayDate)], ""); 
				e.Valid = false;
			}
			if ((row.PayType == 2  || row.PayType == 3) && (row.Refrence == null || row.Refrence .Trim() == "") )
			{ 
				view.SetColumnError(view.Columns[nameof(row.Refrence)], LangResource.MustEnterTheBankTransferNumber); 
				e.Valid = false;
			}
			if (row.PayType == 5 && row.PayID.ValidAsIntNonZero () == false )
			{
				
				//view.SetColumnError(view.Columns[nameof(row.Refrence)], LangResource.MustEnterCashNoteNumber);
				e.Valid = false;
			}
			if (row.CurrancyRate  <= 0)
			{
				view.SetColumnError(view.Columns[nameof (row.CurrancyRate)], LangResource.ErrorValMustBeGreaterThan0); 
				e.Valid = false;
			}
			var pays = GridView_Pays.DataSource as Collection<Acc_Pay>;
			if (pays == null)
				return;
			
			var matchedPays = pays.Where(x => x.PayType == row.PayType && x.PayID == row.PayID);
			if(matchedPays.Count()  > 1)
			{
				if(row.PayType == (int)Master.PayTypes.CashNote)
				{
					view.DeleteRow(e.RowHandle);
					XtraMessageBox.Show(LangResource.CantAddCashNoteTwice);
				}
				else if( row.CurrancyID == matchedPays .Last ().CurrancyID)
				{
					matchedPays.Last().Amount += row.Amount;
					view.DeleteRow(e.RowHandle);

				}
			}


		}

		private void GridView_Pays_RowCountChanged(object sender, EventArgs e)
		{
			var sum = (GridView_Pays.DataSource as Collection<Acc_Pay>).Sum(x => x.Amount);
			spn_Paid.EditValue = sum;
		}

		private void GridView_Pays_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			var row = GridView_Pays.GetRow(e.RowHandle) as Acc_Pay;
			DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

			if (e.Column.FieldName == nameof(row .CurrancyID))
			{
				var currency = db.Acc_Currencies.Where(x => x.ID == row.CurrancyID).Single();
				row.CurrancyRate = currency.LastRate ;
			}
			else if (e.Column.FieldName == nameof(row.Amount ) || e.Column.FieldName == nameof(row.CurrancyID ))
			{
				IsPaidChangedByUser = true;
			}
			else if (e.Column.FieldName == nameof(row.Refrence ))
			{
				//if (row.PayType == (int)Master.PayTypes.CashNote)
				//{
				if (row.Refrence.Contains("*"))
				{
					var code = row.Refrence.Replace("#", "");
					var list = code.Split(new string[] { "*" }, StringSplitOptions.RemoveEmptyEntries);
					if (list.Count() > 1)
					{
						switch (list[0].ToInt()) // TODO to bw configerd after adding another pay types 
						{
							case (int)Master.SystemProssess.CashNoteIn:
							case (int)Master.SystemProssess.CashNoteOut:
								bool isCashIn = (list[0].ToInt() == (int)Master.SystemProssess.CashNoteIn);
								if ((isCashIn && invoiceType.In(Master.InvoiceType.SalesInvoice, Master.InvoiceType.PurchaseReturn) == false) ||
									(!isCashIn && invoiceType.In(Master.InvoiceType.SalesReturn, Master.InvoiceType.PurchaseInvoice) == false) )
								{
									XtraMessageBox.Show(LangResource.CantUseCashNoteInWithThisInvoice);
									GridView_Pays.DeleteRow(e.RowHandle);
									return;
								}

								Acc_CashNote cashNote = db.Acc_CashNotes.Where(x => x.Code == Convert.ToInt32(list[1])  && x.IsCashNote == isCashIn).SingleOrDefault();
								if(cashNote == null ) 
								{

									GridView_Pays.DeleteRow(e.RowHandle );
									return ;
								}
								if(cashNote.LinkType != (byte) Master.SystemProssess.Without)
								{
									XtraMessageBox.Show(LangResource.SorryThisCashNoteIsLinkedToAnotherInvoice);
									GridView_Pays.DeleteRow(e.RowHandle);
									return;
								}
								if (cashNote.PartType  != LookUpEdit_PartType.EditValue.ToInt() || cashNote.PartID != LookUpEdit_PartID.EditValue.ToInt())
								{
									XtraMessageBox.Show(LangResource.ErorrPartsMustBeMached);
									GridView_Pays.DeleteRow(e.RowHandle);
									return;
								}
								row.PayType = (int)Master.PayTypes.CashNote; 
								row.PayID = cashNote.ID; 
								row.Amount = cashNote.Amount + cashNote.DiscountValue;
								row.Code = cashNote.Code.ToString();
								row.CurrancyID = 1;
								row.CurrancyRate = 1;
								row.InsertDate = db.GetSystemDate();
								row.Notes = "";
								row.Refrence = cashNote.Code.ToString();
								row.PayDate = cashNote.Date;
								row.UserID = cashNote.LastUpdateUserID ?? CurrentSession.user.ID; 
								break;
						}

					}
					//}

				}
			}
		 

			row.UserID = CurrentSession.user.ID;
			row.InsertDate = db.GetSystemDate();
			GridView_Pays_RowCountChanged(sender, null);


		}

		private void GridView_Pays_InitNewRow(object sender, InitNewRowEventArgs e)
		{
			DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
			var row = GridView_Pays.GetRow(e.RowHandle) as Acc_Pay;
			if (row.PayType == 0) 
				row.PayType = 1;
			row.UserID = CurrentSession.user.ID;
			row.InsertDate = db.GetSystemDate();
			row.PayDate = Invoice.Date;
			row.CurrancyID = 1;
			row.CurrancyRate = 1;
			row.SourceType =(int)invoiceType ;
			row.SourceID = Invoice.ID;
			row.Refrence = "";
		}

		private void GridView_Pays_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
		{
			DAL.ERPDataContext dbc = new DAL.ERPDataContext(Program.setting.con);
			GridView Senderview = sender as GridView;
			var row = GridView_Pays.GetRow(e.RowHandle) as Acc_Pay;


			if (e.Column.FieldName == "PayID")
			{
				RepositoryItemLookUpEdit PayIDRepoEXP = new RepositoryItemLookUpEdit();
				PayIDRepoEXP.NullText = "";
				if (Senderview.GetRowCellValue(e.RowHandle, "PayType").ValidAsIntNonZero() == false)
				{ e.RepositoryItem = new RepositoryItem(); return; }

				var drawers = CurrentSession.UserAccessibleDrawer.Where(x => x.LinkedToBranch == 0 || x.LinkedToBranch == lkp_Store.EditValue.ToInt()).Select(x => new {ID =  x.ACCID ,  Name = x.Name });
				var banks = CurrentSession.UserAccessibleBanks.Where(x => x.LinkedToBranch == 0 || x.LinkedToBranch == lkp_Store.EditValue.ToInt()).Select(x => new { ID = x.AccountID , Name = x.BankName });
				var paycards = CurrentSession.UserAccessiblePayCards.Where(x => banks.Select(b => b.ID).Contains(x.BankID)).Select(x => new { x.ID, Name = x.Number });
				var accounts = CurrentSession.UserAccessbileAccounts.Where(x => dbc.Acc_Accounts.Where(a => x.ParentID == x.ID).Count() == 0).Select(x => new { x.ID, Name = x.Name });
				var CashNotes = dbc.Acc_CashNotes.Where(x => x.ID == row.PayID ).Select(x => new { x.ID, x.Code });
				switch (Senderview.GetRowCellValue(e.RowHandle, "PayType").ToInt())
				{
					case 1:
						PayIDRepoEXP.DataSource = drawers.ToList();
						break;
					case 2:
						PayIDRepoEXP.DataSource = banks.ToList();
						break;
					case 3:
						PayIDRepoEXP.DataSource = paycards.ToList();
						break;
					case 4:
						PayIDRepoEXP.DataSource = accounts.ToList();
						break;
					case 5:
						PayIDRepoEXP.DataSource = CashNotes.ToList();
						break;
				}
				PayIDRepoEXP.DisplayMember = "Name";
				PayIDRepoEXP.ValueMember = "ID";
				PayIDRepoEXP.PopulateColumns();
				PayIDRepoEXP.Columns[0].Visible = false;
				e.RepositoryItem = PayIDRepoEXP;
			}
			
			
		}

		private void ButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
		{
			GridView view = ((GridControl)((ButtonEdit)sender).Parent).MainView as GridView;
		   
			if (view.FocusedRowHandle >= 0)
			{
				var row = GridView_Pays.GetFocusedRow() as Acc_Pay;
				if (row != null)
				{
					if (row.PayType == (int)Master.PayTypes.CashNote && row.ID > 0 )
					{
						XtraMessageBox .Show(LangResource.CantEditThisDocFormThisScreen);
						return;
					}
				};
				view.DeleteSelectedRows();
			}

		}


		private void GridView_Pays_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
		{
			GridView_Pays_FocusedColumnChanged(sender, new FocusedColumnChangedEventArgs(GridView_Pays.FocusedColumn, GridView_Pays.FocusedColumn));
			
		}

		private void GridView_Pays_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
		{
			var row = GridView_Pays.GetFocusedRow() as Acc_Pay;
			if (row == null || e.FocusedColumn == null) return;
			if (row.PayType == (int)Master.PayTypes.CashNote)
			{
				e.FocusedColumn.OptionsColumn.AllowEdit = false ;
				GridView_Pays.Columns[nameof(row.Refrence)].OptionsColumn.AllowEdit = true;
				GridView_Pays.Columns["Delete"].OptionsColumn.AllowEdit = true;
				GridView_Pays.Columns["Delete"].OptionsColumn.ReadOnly = false;
				return; 
			}
			else
			{
				e.FocusedColumn.OptionsColumn.AllowEdit  = true ;
				GridView_Pays.Columns["UserID"].OptionsColumn.AllowEdit =
				GridView_Pays.Columns["InsertDate"].OptionsColumn.AllowEdit = false;
			}


			if (CurrentSession.user.CanPayFromSalesInvoice == false && row.PayID == (int)Master.PayTypes.Drawer&&invoiceType == Master.InvoiceType.SalesInvoice )
			{
				e.FocusedColumn.OptionsColumn.AllowEdit = true;
				return;
			}
			if (e.FocusedColumn.FieldName == nameof ( row.CurrancyRate )  )
			{
				e.FocusedColumn.OptionsColumn.AllowEdit = row.CurrancyID == 1;
			}

			GridView_Pays.Columns["Delete"].OptionsColumn.AllowEdit = true;
			GridView_Pays.Columns["Delete"].OptionsColumn.ReadOnly  = false;
		}

		public override void DataChanged(object sender, EventArgs e)
		{
			if (CurrentSession.user.CanApproveSalesInvoices == false)
				CheckEdit_IsApproved.Checked = false;
			base.DataChanged(sender, e);
		}
		private void Btn_ConverToItemTake_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (IsDocumentSaved())
			{
				if (Invoice.PostState != 0)
				{
					XtraMessageBox.Show("هذه الفاتوره مصروفه من المخزن ، لا يمكن صرفها مره اخري ");
				}
				else
				{
					throw new NotImplementedException();

				}
			}

		}

		private void Btn_PayBills_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			PrintPayBill();
		}

		private void Btn_PrintItemsBills_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			PrintItemTakeBill();
		}

	  
		private void Revenuerepo_ButtonClick(object sender, ButtonPressedEventArgs e)
		{

			if (e.Button.GetType() != typeof(EditorButton) || e.Button.Tag == null)
				return;

			string btnName = e.Button.Tag.ToString();
			if (btnName == "Add")
			{
				switch (invoiceType)
				{
					case  Master.InvoiceType.SalesInvoice :
				    Master.AddRevenueAccount(this);
					break;
					case Master.InvoiceType.PurchaseInvoice :
						Master.AddExpencesAccount(this);
						break;
				}

			}
		}


		private void Lkp_Store_EditValueChanging(object sender, ChangingEventArgs e)
		{
			for (int i = 0; i <= GridView_Items.RowCount - 1; i++)
			{
				if (GridView_Items.GetRowCellValue(i, "StoreID").ToString() == e.OldValue.ToString())
					GridView_Items.SetRowCellValue(i, "StoreID", e.NewValue);
			}
		}
		private void RepoColor_ButtonClick(object sender, ButtonPressedEventArgs e)
		{
			if (e.Button.GetType() != typeof(EditorButton) || e.Button.Tag == null)
				return;

			string btnName = e.Button.Tag.ToString();
			if (btnName == "Add")
			{
				DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

				frm_Main.OpenForm(new frm_Inv_Color(), true);

				repoColor.DataSource = (from c in db.Inv_Colors select c).ToList();

			}
		}
		private void RepoSize_ButtonClick(object sender, ButtonPressedEventArgs e)
		{
			if (e.Button.GetType() != typeof(EditorButton) || e.Button.Tag == null)
				return;

			string btnName = e.Button.Tag.ToString();
			if (btnName == "Add")
			{
				DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

				frm_Main.OpenForm(new frm_Inv_Size(), true);
				repoSize.DataSource = (from s in db.Inv_Sizes select s).ToList();

			}
		}
		private void RepoItems_ButtonClick(object sender, ButtonPressedEventArgs e)
		{
			if (e.Button.GetType() != typeof(EditorButton) || e.Button.Tag == null)
				return;

			string btnName = e.Button.Tag.ToString();
			if (btnName == "Add")
			{
				frm_Main.OpenForm(new frm_Item());

			}
		}
		private void RepoItems_EditValueChanged(object sender, EventArgs e)
		{
			GridView_Items.PostEditor();
		}



		
		void RefreshPaySources()
		{
			DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
			var banks = CurrentSession.UserAccessibleBanks.Where(x => x.LinkedToBranch == 0 || x.LinkedToBranch == lkp_Store.EditValue.ToInt()).Select(x => new {ID = x.AccountID , Name = x.BankName }).ToList();
			var drawers = CurrentSession.UserAccessibleDrawer.Where(x => x.LinkedToBranch == 0 || x.LinkedToBranch == lkp_Store.EditValue.ToInt()).Select(x => new { ID = x.ACCID??0 , Name = x.Name }).ToList();
			var paycards = CurrentSession.UserAccessiblePayCards.Where(x => banks.Select(b=>b.ID ).Contains (x.BankID )).Select(x => new { x.ID, Name = x.Number  }).ToList();
			var accounts = CurrentSession.UserAccessbileAccounts.Where(x=> db.Acc_Accounts.Where(a=>a.ParentID == x.ID ).Count() == 0 ).Select(x => new { x.ID, Name = x.Name  }).ToList();
			var CashNotes = db.Acc_CashNotes.Where(x => x.IsCashNote == true && ((x.LinkType == (int)invoiceType && x.LinkID == Invoice.ID) || x.LinkType == 0)).Select(x => new { x.ID,Name = x.Code.ToString() }).ToList();
			var dataSources = CashNotes;
			dataSources.AddRange(drawers);
			dataSources.AddRange(paycards);
			dataSources.AddRange(accounts);
			dataSources.AddRange(banks);
			PaySourceRepo.DataSource = dataSources;

		}

		public override void RefreshData()
		{
			DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
			var store = (from s in db.Inv_Stores select new { s.ID, s.Name }).ToList();
			lkp_Store.Properties.DataSource = store;
			repoStore.DataSource = store;
			repoUOM.DataSource = (from u in db.Inv_UOMs select u).ToList();
			repoItems.DataSource = (from i in CurrentSession.Products select new { i.ID, i.Name }).ToList();
			repoSize.DataSource = (from s in db.Inv_Sizes select s).ToList();
			repoColor.DataSource = (from c in db.Inv_Colors select c).ToList();
			Revenuerepo.DataSource = (CurrentSession.UserAccessbileAccounts.Where(x => x.Number.ToString().StartsWith("4") && x.Number != "4").Select(x => new { x.ID, x.Name }));
			RefreshPaySources();
			repoUsers.DataSource = db.St_Users.Select(x => new { x.ID, Name = x.UserName }).ToList();
			repoCurrency.DataSource = db.Acc_Currencies.Select(x => new { x.ID, x.Name });

			var Sources = db.St_WorkFlowSources.Where(x => x.Source == (int)invoiceType && x.SourceType == (int)Master.InvoiceSourcesType.Inventory).Select(x => new { ID = x.Parent  }).OrderByDescending (x=>x.ID ).ToList();
			
			LookUpEdit_Source.Properties.DataSource = Sources.Select(x=>new Master.NameAndIDDataSource {ID =  x.ID, Name = Master.Prossess[x.ID] }).ToList();


			LookUpEdit_SalesRep.Properties.DataSource = db.HR_Employees.Where(x => x.IsSalesRepresentative).Select(x =>new { x.ID , x.Code , x.Name }).ToList();
			var result = from c in db.Inv_Invoices
						 where invoiceType == Master.InvoiceType.PurchaseInvoice 
						 select new
						 {
							 c.ID,
							 c.Date,
							 c.Net ,
						 };
			

			lkp_List.DataSource = result;
			if (list == null) list = result.Select(x => x.ID).ToList();
			GetItemTakeBills();
		}
		 
		public override void GoTo(int id)
		{
			if (id.ToString() == txt_ID.Text) return;
			if (ChangesMade && !SaveChangedData()) return; 
			LoadObject(id);
		}
		private bool ValidData()
		{
			if (GridView_Items.RowCount == 0)
			{
				XtraMessageBox.Show(LangResource.ErrorMustInsertOneItemAtLeast, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (GridView_Items.HasColumnErrors)
			{
				return false;
			}
			if (Convert.ToDouble(spn_Remains.EditValue) > 0 &&
				 Convert.ToDouble(txt_MaxCredit.Text) < (CustomerBalance.Balance * -1)
				 && invoiceType == Master.InvoiceType.SalesInvoice )
			{
				if (CurrentSession.user.WhenSellingToMaxCreditCustomer == 1 &&
					   XtraMessageBox.Show(LangResource.WarningCustomerRachedThereMaxCredit, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				{
					return false;
				}
				if (CurrentSession.user.WhenSellingToMaxCreditCustomer == 2)
				{
					XtraMessageBox.Show(LangResource.ErrorCantSellToThatCustomerRechedMaxCredit, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}
			}
			if(LookUpEdit_PartID.EditValue == null || LookUpEdit_PartID.EditValue == DBNull.Value  || LookUpEdit_PartID.EditValue.GetType() != typeof(int))
			{
				LookUpEdit_PartID.ErrorText = LangResource.ErrorCantBeEmpry;
				return false;
			}
			if (lkp_Store.EditValue == null || lkp_Store.EditValue == DBNull.Value || lkp_Store.EditValue.GetType() != typeof(int))
			{
				lkp_Store.ErrorText = LangResource.ErrorCantBeEmpry;
				return false;
			}
		   
			//if (chk_PostState .Checked && dt_OutFromStoreDate .EditValue == null || dt_OutFromStoreDate.EditValue == DBNull.Value || dt_OutFromStoreDate.EditValue.GetType() != typeof(DateTime))
			//{
			//    dt_OutFromStoreDate.ErrorText = LangResource.ErrorCantBeEmpry;
			//    return false;
			//}
			if(Invoice.Date < CurrentSession.Company.CompanyFYearStart || dt_Date.DateTime < CurrentSession.Company.CompanyFYearStart)
			{
				if(CurrentSession.user.CanEditInClosedPeriod == true  &&
					XtraMessageBox.Show(LangResource.WarningYouAreEditingInClosedPeriod, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				{
					return false;
				}
				if (CurrentSession.user.CanEditInClosedPeriod == false)
					return false;
			}
			return true;

		}
		int GetNextID()
		{
			DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
			try
			{
				return (int)db.Inv_Invoices.Max(n => n.ID) + 1;
			}
			catch
			{
				return (int)1;
			}
		}

		class Acc_Pays : Acc_Pay // Map to sql db table 
		{

		}
		SqlTableDependency<Acc_Pays> PayTableWathcher;
		public  override bool IsNew { get => base.IsNew; 
			set { base.IsNew = value; 
				if(IsNew)
				{
					PayTableWathcher?.Dispose();
				}
				else
				{
				 
					try
					{
						PayTableWathcher = new SqlTableDependency<Acc_Pays>(
						Program.setting.con,
						filter: new CustomPayTableWathcherFilter(Invoice.ID,(int)Invoice.InvoiceType));
						PayTableWathcher.OnChanged += TableDependency_Changed;
						PayTableWathcher.Start(); 
					}catch(Exception e)
					{
						MessageBox.Show("{0} , \n Pay watsher is not active " , e.Message );
						PayTableWathcher?.Dispose();
					}
					finally
					{
					}
				}

			}
		}

		void TableDependency_Changed(object sender, RecordChangedEventArgs<Acc_Pays> e)
		{
			if (e.ChangeType != ChangeType.None)
			{
				var changedEntity = e.Entity;
				if(this.IsHandleCreated)
				this.Invoke (new Action (()=>  GetPays()));
			}
		}
		public class CustomPayTableWathcherFilter : ITableDependencyFilter
		{
			private readonly int _sourceID;
			private readonly int _sourceType;

			public CustomPayTableWathcherFilter(int SourceID , int SourceType)
			{
				_sourceID = SourceID;
				_sourceType = SourceType ;
			}

			public string Translate()
			{
				return string.Format("[SourceID] = {0} and [SourceID] = {1}" , _sourceID, _sourceType);
			}
		}
		public override void Save()
		{
		   // if (IsNew && !CanAdd) { XtraMessageBox.Show(LangResource.CantAddNoPermission, "", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
		  if (CanSave() == false) return;
			if (!ValidData()) { return; }
			if (GridView_Items.FocusedRowHandle < 0)
			{
				GridView_Items_ValidateRow(GridView_Items, new ValidateRowEventArgs(GridView_Items.FocusedRowHandle, GridView_Items.GetRow(GridView_Items.FocusedRowHandle)));
				
			}
			DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
			if (IsNew)
			{
				Invoice = new Inv_Invoice();
				db.Inv_Invoices.InsertOnSubmit(Invoice);
				Invoice.UserID = CurrentSession.user.ID;
			}
			else
			{
				Invoice = db.Inv_Invoices.Where(x => x.ID == Invoice.ID).First();
				if (Invoice == null)
				{
					Invoice = new Inv_Invoice();
					db.Inv_Invoices.InsertOnSubmit(Invoice);
					Invoice.UserID = CurrentSession.user.ID;
				}
				Invoice.LastUpdateUserID = CurrentSession.user.ID;
				Invoice.LastUpdateDate = db.GetSystemDate();
				if(Invoice .IsApproved ==false && CheckEdit_IsApproved.Checked  ){
					Invoice.ApprovedBy = CurrentSession.user.ID;
				}
			}

			SetData();

			if(Invoice.SourceID .ValidAsIntNonZero())
			{
				if (Invoice.Source == 1)
				{
					var order = db.SL_Orders.Where(x => x.ID == Invoice.SourceID).Single();
					order.Status = 2;
				}
				else if (Invoice.Source == 2)
				{
					var request = db.SL_Requests.Where(x => x.ID == Invoice.SourceID).Single();
					request.Status = 2;
				}
				else if (Invoice.Source == 3)
				{ 
					// TODO : After creation the price offer 
			
				}
				
			}
			db.SubmitChanges();
			var invoiceDetails = ((Collection<Inv_InvoiceDetail>)GridView_Items.DataSource);
			var invoiceOtherExpense = ((Collection<Inv_InvoicesExpense >)GridView_OtherCosts .DataSource);
			foreach (var item in invoiceDetails)
				item.InvoiceID = Invoice.ID;
			foreach (var item in invoiceOtherExpense)
				item.InID = Invoice.ID;
			foreach (var item in ((Collection<Acc_Pay>)GridView_Pays.DataSource))
			{
				item.SourceID  = Invoice.ID;
				item.SourceType  =(int) Invoice.InvoiceType;

			}
			DetailsDataContexst.SubmitChanges();

			if (Invoice.IsApproved)
			{
				#region Journals

				var partTypeName = LookUpEdit_PartType.Text;
				var PartAccount = 0;
				var IsPartDebit = true;
				var storeAccount = 0;
				var DiscountAccount = 0;
				var DeductTaxAccount = 0;
				var AddTaxAccount = 0;
				var InsertCostOfSoldGoods = false;
				var InsertInventoryJournal = false;
				var InsertPayJournal = false;
				var IsStockOut = false;
				var MainMessage = "";  
				switch (invoiceType  )
				{
					case Master.InvoiceType.SalesInvoice:
						IsPartDebit = true;
						storeAccount =  db.Inv_Stores.Where(x => x.ID == Invoice.StoreID).Select(x => x.SellAccountID).FirstOrDefault().Value ;
						DeductTaxAccount = (int)CurrentSession.Company.SalesDeductTaxAccount;
						AddTaxAccount = (int)CurrentSession.Company.SalesAddTaxAccount;
						InsertCostOfSoldGoods = (CurrentSession.Company.StockIsPeriodic == false && Invoice.PostState > 0);
						DiscountAccount = CurrentSession.Company.SalesDiscountAccount;
						InsertInventoryJournal = true;// Invoice.PostState > 0
						MainMessage =   LangResource.SalesInvoice + " " + LangResource.Number + " " + Invoice.ID + " " + LangResource.To + " " + partTypeName + " " + LookUpEdit_PartID.Text;
						InsertPayJournal = GridView_Pays.RowCount > 0;
						IsStockOut = true;
						break;
					case Master.InvoiceType.PurchaseInvoice :
						//throw new NotImplementedException();
						IsPartDebit = false ;
						storeAccount = CurrentSession.Company.StockIsPeriodic?
							db.Inv_Stores.Where(x => x.ID == Invoice.StoreID).Select(x => x.PurchaseAccountID ).FirstOrDefault().Value
							: db.Inv_Stores.Where(x => x.ID == Invoice.StoreID).Select(x => x.InventoryAccount ).FirstOrDefault().Value;
						DeductTaxAccount = (int)CurrentSession.Company.PurchaseDeductTaxAccount ;
						AddTaxAccount = (int)CurrentSession.Company.PurchaseAddTaxAccount ;
						InsertCostOfSoldGoods = false;
						DiscountAccount = CurrentSession.Company.PurchaseDiscountAccount ;
						InsertInventoryJournal = true;// Invoice.PostState > 0
						MainMessage = LangResource.PurchaseInvoice  + " " + LangResource.Number + " " + Invoice.ID + " " + LangResource.From  + " " + partTypeName + " " + LookUpEdit_PartID.Text;
						InsertPayJournal = GridView_Pays.RowCount > 0;
						IsStockOut = false;
						break;
					default:
						throw new NotImplementedException();
						 
				}
				switch (Invoice.PartType  )
				{
					case (int)Master.PartTypes.Vendor :
						PartAccount = db.Pr_Vendors.Where(x => x.ID == Invoice.PartID).SingleOrDefault().Account;
						break;
					case (int)Master.PartTypes.Customer :
						PartAccount = db.Sl_Customers.Where(x => x.ID == Invoice.PartID).SingleOrDefault().Account;
						break;
					case (int)Master.PartTypes.Account :
						PartAccount =  Invoice.PartID ;
						break;
					case (int)Master.PartTypes.Employee :
						PartAccount = db.HR_Employees .Where(x => x.ID == Invoice.PartID).SingleOrDefault().AccountId .Value ;
						break;
				}


				db.Inv_StoreLogs.DeleteAllOnSubmit(from l in db.Inv_StoreLogs where l.Type == 6 && (from d in db.Inv_InvoiceDetails where d.InvoiceID == Invoice.ID select d.ID).ToList().Contains((int)l.TypeID) select l);
				db.SubmitChanges();
				Master.DeleteAccountAcctivity(((int)invoiceType).ToString() , Invoice.ID.ToString());

				DAL.Acc_Activity acctivity = new Acc_Activity()
				{
					CostCEnter = Invoice.CCenter,
					Date = Invoice.Date,
					Note = LangResource.SalesInvoice + " " + LangResource.Number + " " + Invoice.ID,
					StoreID = Invoice.StoreID,
					Type = ((int)invoiceType).ToString(),
					TypeID = Invoice.ID.ToString(),InsertDate = Invoice.LastUpdateDate ,
					LastUpdateDate = Invoice.LastUpdateDate,
					LastUpdateUserID=Invoice.LastUpdateUserID ,
					UserID = Invoice.UserID 

				};
				db.Acc_Activities.InsertOnSubmit(acctivity);
				db.SubmitChanges();


				// Creat Journal Details//////////////////////////////////////////
				

				if (Invoice.DeductTaxValue   > 0) // For Sales deduction tax 
				{
					db.Acc_ActivityDetials.InsertOnSubmit(new Acc_ActivityDetial() 
					{
						ACCID = DeductTaxAccount,
						Debit = IsPartDebit ? Convert.ToDouble( Invoice.DeductTaxValue):0,
						Credit = !IsPartDebit ? Convert.ToDouble(Invoice.DeductTaxValue):0,
						AcivityID = acctivity.ID,
						Note = string.Format("{0}-{1}", MainMessage, LangResource.DeductionTax),
						CurrencyID = 1 ,CurrencyRate = 1 ,CostCenter = Invoice.CCenter

					});

					// for customer debit Deduction tax
					db.Acc_ActivityDetials.InsertOnSubmit(new Acc_ActivityDetial()
					{
						ACCID = PartAccount,
						Debit = IsPartDebit ? 0 : Invoice.DeductTaxValue,
						Credit = IsPartDebit ? Invoice.DeductTaxValue : 0,
						AcivityID = acctivity.ID,
						DueDate = Invoice.DueDate,
						Note = string.Format("{0}-{1}", MainMessage, LangResource.DeductionTax),
						CurrencyID = 1,
						CurrencyRate = 1,
						CostCenter = Invoice.CCenter

					});
				}
				if (Invoice.AddTaxVal > 0) // For Sales Add tax 
				{
					db.Acc_ActivityDetials.InsertOnSubmit(new Acc_ActivityDetial()
					{
						ACCID = AddTaxAccount,
						Debit = IsPartDebit ? 0 : Invoice.AddTaxVal,
						Credit = !IsPartDebit ? 0 : Invoice.AddTaxVal,
						AcivityID = acctivity.ID,
						Note = MainMessage+" " + LangResource.SalesAddTaxAccount,
					 
						CurrencyID = 1,
						CurrencyRate = 1,
						CostCenter = Invoice.CCenter

					});
					// for customer debit Added tax 
					db.Acc_ActivityDetials.InsertOnSubmit(new Acc_ActivityDetial()
					{
						ACCID = PartAccount,
						Debit = IsPartDebit ? Invoice.AddTaxVal : 0,
						Credit = IsPartDebit ? 0 : Invoice.AddTaxVal,
						AcivityID = acctivity.ID,
						DueDate = Invoice.DueDate,
						Note = string.Format("{0}-{1}", MainMessage, LangResource.AddedTax),
						CurrencyID = 1,
						CurrencyRate = 1,
						CostCenter = Invoice.CCenter

					});
				}

				// OtherExpences
				if (Invoice.TotalRevenue > 0)
				{
					var source = GridView_OtherCosts.DataSource as Collection<Inv_InvoicesExpense>;
					foreach (var row in source)
					{
						row.InID = Invoice.ID;
						db.Acc_ActivityDetials.InsertOnSubmit(new Acc_ActivityDetial()
						{
							ACCID = (int)row.AccID ,
							Debit = IsPartDebit ? 0 : row.Amount.Value  ,
							Credit = !IsPartDebit ? 0 : row.Amount.Value ,
							AcivityID = acctivity.ID,
							Note =string.Format("{0} {1}-{2}", MainMessage ,LangResource.Expenses , db.Acc_Accounts.Where(x=>x.ID == row.AccID ).SingleOrDefault().Name) ,
							CurrencyID = 1,
							CurrencyRate = 1,
							CostCenter = Invoice.CCenter

						});
					}
					// for customer debit Epences
					db.Acc_ActivityDetials.InsertOnSubmit(new Acc_ActivityDetial()
					{
						ACCID = PartAccount,
						Debit = IsPartDebit ? Invoice.TotalRevenue : 0,
						Credit = IsPartDebit ? 0 : Invoice.TotalRevenue,
						AcivityID = acctivity.ID,
						DueDate = Invoice.DueDate,
						Note = string.Format("{0}-{1}", MainMessage, LangResource.Expenses),
						CurrencyID = 1,
						CurrencyRate = 1,
						CostCenter = Invoice.CCenter

					});
				}


				if (InsertCostOfSoldGoods)
				{
					var costValue = ((Collection<Inv_InvoiceDetail>)GridView_Items.DataSource).Sum(x => x.TotalCostValue);
					var CostOfSoldGoodsForStores = ((Collection<Inv_InvoiceDetail>)GridView_Items.DataSource).GroupBy(g => g.StoreID ?? Invoice.StoreID)
						.Select(x => new { StoreID = x.Key, TotalCost = x.Sum(s => s.TotalCostValue) }).ToList();
					CostOfSoldGoodsForStores.ForEach(s =>
					{

						// Cost Of Sold goods
						db.Acc_ActivityDetials.InsertOnSubmit(new Acc_ActivityDetial()
						{
							ACCID = (int)db.Inv_Stores.Where(x => x.ID == s.StoreID  ).Select(x => x.InventoryAccount ).FirstOrDefault(),
							Debit = IsPartDebit ? s.TotalCost:0,
							Credit = IsPartDebit? 0: s.TotalCost,
							AcivityID = acctivity.ID,
							Note = string.Format("{0}-{1}", MainMessage, LangResource.CostOfSoldGoods),
							CurrencyID = 1,
							CurrencyRate = 1,
							CostCenter = Invoice.CCenter
						});

					});
					
					// Cost Of Sold goods
					db.Acc_ActivityDetials.InsertOnSubmit(new Acc_ActivityDetial()
					{
						ACCID = Invoice.PostAccount .Value ,
						Debit = IsPartDebit ? 0: CostOfSoldGoodsForStores.Sum(x => x.TotalCost),
						Credit = IsPartDebit ? CostOfSoldGoodsForStores.Sum(x => x.TotalCost) : 0,
						AcivityID = acctivity.ID,
						Note = string.Format("{0}-{1}", MainMessage, LangResource.CostOfSoldGoods), 
						CurrencyID = 1,
						CurrencyRate = 1,
						CostCenter = Invoice.CCenter
					});

				}
				// for store sell discount 
				if (Invoice.DiscountValue > 0) 
				{ 
					db.Acc_ActivityDetials.InsertOnSubmit(new Acc_ActivityDetial()
					{
						ACCID = DiscountAccount,
						Debit = IsPartDebit?  Invoice.DiscountValue:0,
						Credit = IsPartDebit ? 0 : Invoice.DiscountValue,
						AcivityID = acctivity.ID,
						Note = string.Format("{0}-{1}", MainMessage, LangResource.Discount), 
						CurrencyID = 1,
						CurrencyRate = 1,
						CostCenter = Invoice.CCenter

					});  
					db.Acc_ActivityDetials.InsertOnSubmit(new Acc_ActivityDetial()
					{
						ACCID = PartAccount,
						Debit = IsPartDebit?0: Invoice.DiscountValue,
						Credit = IsPartDebit? Invoice.DiscountValue:0,
						AcivityID = acctivity.ID,
						Note = string.Format("{0}-{1}", MainMessage, LangResource.Discount), 
						CurrencyID = 1,
						CurrencyRate = 1,
						CostCenter = Invoice.CCenter
					});
				}

				

				// for customer debit Total "Not the net " 
				if (InsertInventoryJournal)
				{
					db.Acc_ActivityDetials.InsertOnSubmit(new Acc_ActivityDetial()
					{
						ACCID = PartAccount,
						Debit = IsPartDebit ? Invoice.Total:0,
						Credit = IsPartDebit ? 0 : Invoice.Total,
						AcivityID = acctivity.ID,
						DueDate = Invoice.DueDate,
						Note = string.Format("{0}", MainMessage), 
						CurrencyID = 1,
						CurrencyRate = 1,
						CostCenter = Invoice.CCenter

					});

					db.Acc_ActivityDetials.InsertOnSubmit(new Acc_ActivityDetial() // For store sell account
					{
						ACCID = storeAccount,
						Debit = IsPartDebit ? 0 : Invoice.Total,
						Credit = !IsPartDebit ? 0 : Invoice.Total,
						AcivityID = acctivity.ID,
						Note = string.Format("{0}", MainMessage),
						CurrencyID = 1,
						CurrencyRate = 1,
						CostCenter = Invoice.CCenter
					});


				}
				if (InsertPayJournal)
				{
					foreach (var pay in ((Collection<Acc_Pay>)GridView_Pays.DataSource))
					{
						DAL.Acc_Activity PayAcctivity = new Acc_Activity()
						{
							CostCEnter = Invoice.CCenter,
							Date = pay.PayDate ,
							Note = string.Format("{0}-{1}", MainMessage ,LangResource.Pay), 
							StoreID = Invoice.StoreID,
							Type = ((int)invoiceType).ToString(),
							TypeID = Invoice.ID.ToString(),
							InsertDate = pay.InsertDate ,
							LastUpdateDate = Invoice.LastUpdateDate ,
							LastUpdateUserID =pay.UserID ,
							UserID = pay.UserID

						};
						db.Acc_Activities.InsertOnSubmit(PayAcctivity);
						db.SubmitChanges();

						switch (pay.PayType)
						{
							case 1:// Drawer
							case 2:// Bank
							case 4:// Account
								db.Acc_ActivityDetials.InsertOnSubmit(new Acc_ActivityDetial()
								{
									ACCID = pay.PayID,
									Debit = IsPartDebit ? pay.Amount:0,
									Credit = IsPartDebit ? 0: pay.Amount,
									AcivityID = PayAcctivity.ID,
									DueDate = pay.PayDate,
									Note = string.Format("{0}-{1}", MainMessage, LangResource.Pay), 
									CurrencyID = pay.CurrancyID ,
									CurrencyRate = pay.CurrancyRate ,
									CostCenter = Invoice.CCenter
								});
								db.Acc_ActivityDetials.InsertOnSubmit(new Acc_ActivityDetial()
								{
									ACCID = (int)CurrentSession.UserAccessbileCustomers.Where(x => x.ID == Invoice.PartID).Select(x => x.Account).SingleOrDefault(),
									Debit = IsPartDebit ? 0: pay.Amount,
									Credit = IsPartDebit ? pay.Amount:0,
									AcivityID = PayAcctivity.ID,
									DueDate = pay.PayDate,
									Note = string.Format("{0}-{1}", MainMessage, LangResource.Pay), 
									CurrencyID = pay.CurrancyID,
									CurrencyRate = pay.CurrancyRate,
									CostCenter = Invoice.CCenter
								});
								break;

							case 3://Pay Card 
								var card = db.Acc_PayCards.Where(x => x.ID == pay.PayID).SingleOrDefault();
								var bank = db.Acc_Banks.Where(x => x.ID == card.BankID ).SingleOrDefault();
								db.Acc_ActivityDetials.InsertOnSubmit(new Acc_ActivityDetial()
								{
									ACCID = bank.AccountID ,
									Debit = IsPartDebit ? pay.Amount -(pay.Amount *card.Commission ):0,
									Credit = IsPartDebit ? 0: pay.Amount - (pay.Amount * card.Commission),
									AcivityID = PayAcctivity.ID,
									DueDate = pay.PayDate,
									Note = string.Format("{0}-{1}", MainMessage, LangResource.Pay), 
									CurrencyID = pay.CurrancyID,
									CurrencyRate = pay.CurrancyRate,
									CostCenter = Invoice.CCenter
								});
								if(card.Commission > 0) db.Acc_ActivityDetials.InsertOnSubmit(new Acc_ActivityDetial()
								{
									ACCID = card .CommissionAccount,
									Debit = IsPartDebit ? (pay.Amount * card.Commission):0,
									Credit = IsPartDebit ? 0:(pay.Amount * card.Commission),
									AcivityID = PayAcctivity.ID,
									DueDate = pay.PayDate,
									Note = string.Format("{0}-{2}-{1}", MainMessage, LangResource.Pay,LangResource.Commission), 
									CurrencyID = pay.CurrancyID,
									CurrencyRate = pay.CurrancyRate,
									CostCenter = Invoice.CCenter
								});
								db.Acc_ActivityDetials.InsertOnSubmit(new Acc_ActivityDetial()
								{
									ACCID = (int)CurrentSession.UserAccessbileCustomers.Where(x => x.ID == Invoice.PartID).Select(x => x.Account).SingleOrDefault(),
									Debit = IsPartDebit ? 0: pay.Amount,
									Credit = IsPartDebit ? pay.Amount:0,
									AcivityID = PayAcctivity.ID,
									DueDate = pay.PayDate,
									Note = string.Format("{0}-{1}", MainMessage, LangResource.Pay), 
									CurrencyID = pay.CurrancyID,
									CurrencyRate = pay.CurrancyRate,
									CostCenter = Invoice.CCenter
								});
								break;
							case 5:
								Acc_CashNote  cashNote = db.Acc_CashNotes.Where(x => x.ID == pay.PayID ).SingleOrDefault();
								if(cashNote != null)
								{
									cashNote.LinkID  = Invoice.ID;
									cashNote.LinkType  =(byte) invoiceType ;
									//db.Acc_Pays.DeleteAllOnSubmit(db.Acc_Pays.Where(x => x.PayType == ((int)Master.PayTypes.CashNote) && x.PayID == cashNote.ID));
									//db.SubmitChanges(); 
									//db.Acc_Pays.InsertOnSubmit(new Acc_Pay()
									//{
									//	PayType = (int)Master.PayTypes.CashNote,
									//	PayID = cashNote.ID,
									//	Amount = cashNote.DiscountValue + cashNote.Amount,
									//	Code = cashNote.Code.ToString(),
									//	CurrancyID = 1,
									//	CurrancyRate = 1,
									//	InsertDate = db.GetSystemDate(),
									//	Notes = "",
									//	Refrence = cashNote.Code.ToString(),
									//	PayDate = cashNote.Date,
									//	UserID = cashNote.LastUpdateUserID ?? CurrentSession.user.ID,
									//	SourceID = cashNote.LinkID.Value,
									//	SourceType = cashNote.LinkType
									//});
								}
								break;
							default:
								break;
						}

					}

				}


				ChangeSet cs = db.GetChangeSet();
				double debit = 0;
				double credit = 0;

				foreach (var item in cs.Inserts  )
				{ 
					
					if (item.GetType () == typeof(Acc_ActivityDetial))
					{
						debit += ((Acc_ActivityDetial)item).Debit;
						credit += ((Acc_ActivityDetial)item).Credit ;

					}
				}
				if (debit != credit)
				{
					XtraMessageBox.Show("Debit ={" + debit + "}   / Credit={" + credit + "} حدث خطأ ما , القيود غير متزنه ");
				}
				#endregion 


				db.Inv_StoreLogs.DeleteAllOnSubmit(db.Inv_StoreLogs.Where(x => x.Type == (int)invoiceType && invoiceDetails.Select(d => d.ID).Contains(x.TypeID ?? 0)));
				if(Invoice.PostState > 0 )
				foreach (var item in invoiceDetails)
				{
					var unit = CurrentSession.ProductsUints .Where(x => x.UnitID == item.ItemUnitID && x.ItemID == item.ItemID).SingleOrDefault();
						db.Inv_StoreLogs.InsertOnSubmit(new Inv_StoreLog()
						{
							Type = (int)invoiceType,
							TypeID = item.ID,
							Batch = item.Batch,
							BuyPrice = item.TotalCostValue / unit.Factor / item.ItemQty,
							Color = item.Color,
							date = Invoice.OutFromStoreDate,
							ExpDate = item.ExpDate,
							ItemID = item.ItemID,
							ItemQuIN = IsStockOut? 0 : item.ItemQty * unit.Factor,
							ItemQuOut = IsStockOut? item.ItemQty * unit.Factor:0,
							Note = MainMessage,
							SellPrice = item.TotalPrice / unit.Factor / item.ItemQty,
							Serial = item.Serial,
							Size = item.Size,
							StoreID = item.StoreID ?? Invoice.StoreID
						});
						if(Invoice.PostState == 2)
						{
							var ToStoreAccount = 0;
							ToStoreAccount = db.Inv_Stores.Where(x =>
						 x.CloseInventoryAccount == Invoice.PostAccount.Value ||
						 x.CostOfSoldGoodsAcc == Invoice.PostAccount.Value ||
						 x.InventoryAccount == Invoice.PostAccount.Value ||
						 x.OpenInventoryAccount == Invoice.PostAccount.Value ||
						 x.PurchaseAccountID == Invoice.PostAccount.Value ||
						 x.PurchaseReturnAccountID == Invoice.PostAccount.Value ||
						 x.SellAccountID == Invoice.PostAccount.Value ||
						 x.SellReturnAccountID == Invoice.PostAccount.Value
							).FirstOrDefault().ID;
							db.Inv_StoreLogs.InsertOnSubmit(new Inv_StoreLog()
							{
								Type = (int)invoiceType,
								TypeID = item.ID,
								Batch = item.Batch,
								BuyPrice = item.TotalCostValue / unit.Factor / item.ItemQty,
								Color = item.Color,
								date = Invoice.OutFromStoreDate,
								ExpDate = item.ExpDate,
								ItemID = item.ItemID,
								ItemQuIN = !IsStockOut ? 0 : item.ItemQty * unit.Factor,
								ItemQuOut = !IsStockOut ? item.ItemQty * unit.Factor : 0,
								Note = MainMessage,
								SellPrice = item.TotalPrice / unit.Factor / item.ItemQty,
								Serial = item.Serial,
								Size = item.Size,
								StoreID = ToStoreAccount,
							});
						}
				}
				db.SubmitChanges();
			}
				db.SubmitChanges();

			if (IsNew && Program.setting.PrintPayBillOnSave )
				PrintPayBill();
			if (IsNew && Program.setting.PrintItemWithdrawBillOnSave )
				PrintItemTakeBill();
			base.Save();


		}
		public override void RunUserPrivilage()
		{
			base.RunUserPrivilage();
		  lkp_Store .ReadOnly  = !(bool)CurrentSession.user.CanChangeStore;
		  lkp_CCenter   .ReadOnly  = !(bool)CurrentSession.user.CanChangeCCenter;

			try
			{

			
			GridView_Items.Columns["CurrentBalance"].OptionsColumn.ShowInCustomizationForm = (bool)CurrentSession.user.ShowItemBalance;
			if (GridView_Items.Columns["CurrentBalance"].Visible && !(bool)CurrentSession.user.ShowItemBalance)
				GridView_Items.Columns["CurrentBalance"].Visible = false;


			spn_Discount.ReadOnly = !CurrentSession.user.CanAddTotalDiscount;
			spn_DiscountVal .ReadOnly = !CurrentSession.user.CanAddTotalDiscount;
			if (CurrentSession.user.HideItemCost) GridView_Items.Columns["TotalCostValue"].Visible =
			GridView_Items.Columns["TotalCostValue"].OptionsColumn.ShowInCustomizationForm =
			 GridView_Items.Columns["CostValue"].Visible =
			GridView_Items.Columns["CostValue"].OptionsColumn.ShowInCustomizationForm = false;
			}
			catch (Exception)
			{

				
			}
			if (CurrentSession.user.HideItemDiscount)
			GridView_Items.Columns[nameof(InvoDInsta.DiscountValue) ].Visible =
			GridView_Items.Columns[nameof(InvoDInsta.DiscountValue)].OptionsColumn.ShowInCustomizationForm = 
			GridView_Items.Columns[nameof(InvoDInsta.Discount) ].Visible = 
			GridView_Items.Columns[nameof(InvoDInsta.Discount) ].OptionsColumn.ShowInCustomizationForm = false; 
			GridView_Items.Columns[nameof(InvoDInsta.Price)].OptionsColumn.AllowEdit = CurrentSession.user.CanChangeItemPrice;


			if (CheckEdit_IsApproved.Checked == false && CurrentSession.user.CanApproveSalesInvoices)
				CheckEdit_IsApproved.Enabled = true;
			else
				CheckEdit_IsApproved.Enabled = false;

			
			//GridView_Pays.OptionsView.NewItemRowPosition = CurrentSession.user.CanPayFromSalesInvoice ? NewItemRowPosition.Top : NewItemRowPosition.None;
			
			LookUpEdit_SalesRep.ReadOnly = !CurrentSession.user.CanChangeSalesRepresentative;
 
		  
			SubItem_Printbills.Enabled = (btn_PrintItemsBills.Enabled || btn_PayBills.Enabled);



		}
		public override void New()
		{
			if (ChangesMade && !SaveChangedData()) return;
			RefreshData();
			itemsBalanceInStores = new List<ItemBalanceInStore>();
			Invoice = new Inv_Invoice()
			{
				ID = GetNextID(),
				InvoiceType = (byte)invoiceType,
				CCenter = CurrentSession.user.DefualtCCenter,
				PostState = 1,
				Date = (new DAL.ERPDataContext()).GetSystemDate(),
				OutFromStoreDate = (new DAL.ERPDataContext()).GetSystemDate(),
				DueDate = (new DAL.ERPDataContext()).GetSystemDate(),
				DeliveryDate = (new DAL.ERPDataContext()).GetSystemDate(),
				Code = (new DAL.ERPDataContext()).GetSystemDate().ToString("yyyyMMdd") + Invoice.ID.ToString(),
				IsApproved = CurrentSession.user.CanApproveSalesInvoices,
				SalesRep = CurrentSession.user.DefaultSalesRepresentative,
				SecresyLevel = 5,
			
			};
			DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

			switch (invoiceType)
			{
				case  Master.InvoiceType .SalesInvoice :
					Invoice.PartType = (int)Master.PartTypes.Customer ;
					Invoice.PartID = CurrentSession.user.DefaultCustomer;
					Invoice.StoreID = CurrentSession.user.DefaultStore;
					
					break;
				case Master.InvoiceType.PurchaseInvoice :
					Invoice.PartType = (int)Master.PartTypes.Vendor ;
					Invoice.PartID = CurrentSession.user.DefaultVendor ;
					Invoice.StoreID = CurrentSession.user.DefaultRawStore ;
					break;
				default:
					throw new NotImplementedException();

				
			}

			var sources = ((List<Master.NameAndIDDataSource>)LookUpEdit_Source.Properties.DataSource);
			if (sources.Where(x => x.ID == (int)Master.SystemProssess.Without).Count() > 0)
				Invoice.Source  = (int)Master.SystemProssess.Without;
			else
				Invoice.Source = sources.First().ID;


			if (((List<Master.NameAndIDDataSource>)LookUpEdit_PostState .Properties.DataSource).Count() > 1)
				Invoice.PostState  = 1;
			else
				Invoice.PostState = 0;
			LookUpEdit_PostState_EditValueChanged(null, null);
			GetData();


			if ((CurrentSession.user.CanPayFromSalesInvoice && invoiceType == Master.InvoiceType.SalesInvoice && AllowDirectPay))
			{
				((Collection<Acc_Pay>)GridView_Pays.DataSource ).Add(new Acc_Pay()
				{
					CurrancyID = 1,
					Amount = 0,
					Code = Invoice.Code,
					CurrancyRate = 1,
					InsertDate = Invoice.Date,
					PayDate = Invoice.Date,
					PayType = 1,
					PayID =CurrentSession.UserAccessibleDrawer .Where (x=>x.ID ==  CurrentSession.user.DefaultDrawer ).Single().ACCID .Value  ,
					SourceID = Invoice.ID,
					SourceType = (int)invoiceType,
					UserID = CurrentSession.user.ID
				});
			}
			base.New();
			IsNew = true;
			ChangesMade = false;
		}
		public override void Delete()
		{
			DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
			//if (!CanPerformDelete()) return;
			if (IsNew) return; 
			PartNumber = txt_ID.Text.ToString();
			PartName = this.LookUpEdit_PartID.Text;
			if (Master.AskForDelete(this, IsNew, PartName, PartNumber))
			{
				Delete(new List<int>() { Invoice.ID }, this.Name,invoiceType );
				list.Remove(Invoice.ID);
				New();
			}

		} 
		void SetData()
		{
			Invoice.ID = Convert.ToInt32(txt_ID.Text);
			Invoice.Code = txt_Code.Text;
			Invoice.PartID = Convert.ToInt32(LookUpEdit_PartID.EditValue);
			Invoice.AttintionMs = txt_Attn.Text;
			Invoice.StoreID  = Convert.ToInt32(lkp_Store.EditValue);
		  //  Invoice.PostState = chk_PostState.Checked;
			Invoice.OutFromStoreDate = dt_OutFromStoreDate.DateTime;
			Invoice.Date = dt_Date.DateTime;
			Invoice.DueDate = dt_DueDate.DateTime;
			Invoice.DeliveryDate = dt_DeliveryDate.DateTime;
			Invoice.Source = LookUpEdit_Source.EditValue.ToInt();
			Invoice.SourceID =(LookUpEdit_SourceID.EditValue != null )?Convert.ToInt32( LookUpEdit_SourceID.EditValue) :0;
			Invoice.CCenter = (int?)lkp_CCenter.EditValue;
			Invoice.SalesBookID = (int?)lkp_SaleBookID.EditValue ;
			Invoice.Notes = memoEdit1.Text;
			Invoice.DiscountRatio = Convert.ToDouble ( spn_Discount.EditValue);
			Invoice.DiscountValue  = Convert.ToDouble(spn_DiscountVal.EditValue);
			Invoice.Total = Convert.ToDouble(spn_Total .EditValue);
			Invoice.TotalRevenue = Convert.ToDouble(spn_TotalRevenue  .EditValue);
			Invoice.AddTax = Convert.ToDouble(spn_AddTax .EditValue);
			Invoice.AddTaxVal = Convert.ToDouble(spn_AddTaxVal .EditValue);
			Invoice.DeductTaxRatio = Convert.ToDouble(spn_DeductionTax.EditValue);
			Invoice.DeductTaxValue = Convert.ToDouble(spn_DeductionTaxVal.EditValue);
			Invoice.Net = Convert.ToDouble(spn_Net .EditValue); 
			Invoice.Car = Convert.ToInt32 (lkp_Car.EditValue);
			Invoice.Driver  = Convert.ToInt32(lkp_Driver .EditValue);
			Invoice.ShippingAddress = memoEdit_ShipTo.Text;
			Invoice.Destination =txt_Address.Text ;
			Invoice.SalesRep = LookUpEdit_SalesRep.EditValue.ToInt();
			Invoice.SecresyLevel = Convert.ToByte(ComboBoxEdit_SecresyLevel.SelectedIndex);
			Invoice.IsApproved = CheckEdit_IsApproved.Checked;
			Invoice.PostState =(byte) LookUpEdit_PostState.EditValue.ToInt();
			Invoice.PostAccount = LookUpEdit_PostAcount .EditValue.ToInt();
			Invoice.InvoiceType  = (byte)invoiceType ;
			Invoice.PartType = (byte)LookUpEdit_PartType .EditValue.ToInt();
			if (Convert.ToDouble(spn_Remains.EditValue) > 0 && Convert.ToDouble(spn_Paid.EditValue) > 0)
				Invoice.PayType = null;
			else 
				Invoice.PayType = (Convert.ToDouble(spn_Remains.EditValue) == 0);
			PartName = LookUpEdit_PartID.Text;
			PartNumber = Invoice.ID.ToString();

		}

		bool IsLoadingData = false;
 
		void GetData()
		{
			DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
			DetailsDataContexst = new DAL.ERPDataContext(Program.setting.con); 
			invoiceType = (Master.InvoiceType) Invoice.InvoiceType ;
			IsLoadingData = true;
			txt_ID.Text = Invoice.ID.ToString();
			txt_Code.Text = Invoice.Code;

			IsPaidChangedByUser=true ; // to diable auto inserting value into paied spenEdit
			LookUpEdit_PartID.EditValue = Invoice.PartID;
			txt_Attn.Text = Invoice.AttintionMs;
			lkp_Store.EditValue = Invoice.StoreID;
		   // chk_PostState.Checked = Invoice.PostState;
			dt_OutFromStoreDate.EditValue = Invoice.OutFromStoreDate;
			dt_Date.DateTime = Invoice.Date;
			dt_DueDate.EditValue = Invoice.DueDate;
			dt_DeliveryDate.EditValue = Invoice.DeliveryDate;
			LookUpEdit_Source.EditValue = Invoice.Source;
			LookUpEdit_SalesRep.EditValue = Invoice.SalesRep;
			LookUpEdit_PostAcount.EditValue  = Invoice.PostAccount;
			LookUpEdit_PostState.EditValue =(int) Invoice.PostState ;
			LookUpEdit_PartType.EditValue = (int)Invoice.PartType;

			ComboBoxEdit_SecresyLevel.SelectedIndex = Invoice.SecresyLevel;
			LookUpEdit_SourceID.EditValue = Invoice.SourceID ;
			lkp_CCenter.EditValue = Invoice.CCenter;
			lkp_SaleBookID.EditValue = Invoice.SalesBookID;
			memoEdit1.Text = Invoice.Notes;
			spn_Discount.EditValue = Invoice.DiscountRatio;
			spn_DiscountVal.EditValue = Invoice.DiscountValue;
			spn_Total.EditValue = Invoice.Total;
			spn_TotalRevenue.EditValue = Invoice.TotalRevenue;
			spn_AddTax.EditValue = Invoice.AddTax;
			spn_AddTaxVal.EditValue = Invoice.AddTaxVal;
			spn_DeductionTax.EditValue = Invoice.DeductTaxRatio;
			spn_DeductionTaxVal.EditValue = Invoice.DeductTaxValue;
			spn_Net.EditValue = Invoice.Net; 
			lkp_Car.EditValue = Invoice.Car;
			lkp_Driver.EditValue = Invoice.Driver;
			memoEdit_ShipTo.Text = Invoice.ShippingAddress;
			txt_Address.Text = Invoice.Destination;
			 

			barItem_Search.EditValue = Invoice.ID;


			PartName = LookUpEdit_PartID.Text;
			PartNumber = Invoice.ID.ToString();


			txt_InsertUser.Text = db.St_Users.Where(x => x.ID == Invoice.UserID).Select(x => x.UserName).FirstOrDefault();
			txt_UpdateUser.Text = db.St_Users.Where(x => x.ID == Invoice.LastUpdateUserID).Select(x => x.UserName).FirstOrDefault();
			txt_LastUpdate.Text = (Invoice.LastUpdateDate != null) ? ((DateTime)Invoice.LastUpdateDate).ToString("yyyy-MM-dd dddd hh:mm tt") : "";
		   
		   
		   
		   
			IQueryable< Inv_InvoiceDetail> InvoiceDetails = 
				DetailsDataContexst.Inv_InvoiceDetails .Select<DAL.Inv_InvoiceDetail, DAL.Inv_InvoiceDetail>((Expression<Func<DAL.Inv_InvoiceDetail, DAL.Inv_InvoiceDetail>>)
				(x => x)).Where(x =>   x.InvoiceID  == Invoice.ID);
			GridControl_Items.DataSource = InvoiceDetails;

			
			gridControl_OtherCosts.DataSource =
				DetailsDataContexst.Inv_InvoicesExpenses .Select<DAL.Inv_InvoicesExpense, DAL.Inv_InvoicesExpense>((Expression<Func<DAL.Inv_InvoicesExpense, DAL.Inv_InvoicesExpense>>)
				(x => x)).Where(x => x.InID  == Invoice.ID);
			GetPays();
			GetItemTakeBills(); 
			CheckEdit_IsApproved.Checked = Invoice.IsApproved; 
			IsPaidChangedByUser=false  ;

			ChangesMade = false;
			IsLoadingData = false;

		}
    	void GetPays()
		{
			GridControl_Pays.DataSource =
				DetailsDataContexst.Acc_Pays.Select<DAL.Acc_Pay, DAL.Acc_Pay>((Expression<Func<DAL.Acc_Pay, DAL.Acc_Pay>>)
				(x => x)).Where(x => x.SourceType == (int)invoiceType && x.SourceID == Invoice.ID);

		}
		void GetItemTakeBills()
		{
			DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);

			var bill = (from b in      db.Inv_ItemTakes 
						join u in db.St_Users on b.UserID equals u.ID 
						 where b.Type == 1  && b.TypeID == Invoice.ID
					   select  new { b.ID, b.Code, b.Date, u.UserName  , Details = (from d in db.Inv_ItemTakeDetails
																				   join l in db.Inv_StoreLogs on d.ID equals l.TypeID
																				   join i in db.Inv_Items on d.ItemID equals i.ID 
																				   join u in db.Inv_UOMs  on d.ItemUnitID equals u.ID 
																				   join s in db.Inv_Stores on d.BranchID equals s.ID 
																				   where d.ItemTakeID == b.ID && l.Type == 4
																				   select new
																				   {
																					   ItemID = i.Name ,
																					   ItemUnitID = u.Name ,
																					   d.ItemeQty,
																					   BranchID = s.Name ,
																					   l.Serial,
																					   l.Size,
																					   l.Color,
																					   l.ExpDate
																				   }
										 ).ToList()
					   }).ToList();
			gridControl_ItemOut.DataSource = bill;
			//LookUpEdit_PostState.Enabled = (bill.Count() == 0);
			bdg_TotalTakeBills.Visible = (bill.Count() > 0);
			bdg_TotalTakeBills.Properties.Text = bill.Count().ToString();
			gridControl_TotalItemsOut.DataSource = (from d in db.Inv_ItemTakeDetails
									   join i in db.Inv_Items on d.ItemID equals i.ID
									   join u in db.Inv_UOMs on d.ItemUnitID equals u.ID
									   where bill.Select(x => x.ID).Contains(d.ItemTakeID)  
									   group d.ItemeQty  by new { ItemID = i.Name, ItemUnitID = u.Name  } into Grouped
									   select new
									   {
										  Grouped .Key.ItemID ,
										  Grouped .Key .ItemUnitID,
										 Total =   Grouped.Sum(),
									   }
										 ).ToList();

		}
		void LoadObject(int ID)
		{
			DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
			Invoice = (from i in db.Inv_Invoices where i.ID == ID select i).First();
			if (Invoice.SecresyLevel > CurrentSession .user.SalesInvoiceSececyLevel)
			{
				XtraMessageBox.Show(LangResource.UserHasNoAccess);
				New();
				return;
			} 
			GetData();
			IsNew = false;
		}

		private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
		{
			try
			{

				GridControl gridControl = sender as GridControl;
				GridView focusedView = gridControl.FocusedView as GridView;
				if (e.KeyCode == Keys.Return)
				{
					GridColumn focusedColumn = (gridControl.FocusedView as ColumnView).FocusedColumn;
					int focusedRowHandle = (gridControl.FocusedView as ColumnView).FocusedRowHandle;
					if (focusedView.FocusedColumn == focusedView.Columns["Code"])
					{
						gridControl1_ProcessGridKey(sender, new KeyEventArgs(Keys.Tab));
					}

					if (focusedView.FocusedRowHandle < 0)
					{
						focusedView.AddNewRow();
						focusedView.FocusedColumn = focusedView.Columns["Code"];
					}
					else
					{
						focusedView.FocusedRowHandle = focusedRowHandle + 1;
						focusedView.FocusedColumn = focusedView.Columns["Code"];
					}
					e.Handled = true;
				}
				else if (e.KeyCode == Keys.Tab && e.Modifiers != Keys.Shift)
				{
					if (focusedView.FocusedColumn.VisibleIndex == 0)
						focusedView.FocusedColumn = focusedView.VisibleColumns[focusedView.VisibleColumns.Count - 1];
					else
						focusedView.FocusedColumn = focusedView.VisibleColumns[focusedView.FocusedColumn.VisibleIndex - 1];
					e.Handled = true;
				}
				else if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
					focusedView.DeleteSelectedRows();
				//else if (e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift)
				//{
				//    if (focusedView.FocusedColumn.VisibleIndex == focusedView.VisibleColumns.Count)
				//        focusedView.FocusedColumn = focusedView.VisibleColumns[0];
				//    else
				//        focusedView.FocusedColumn = focusedView.VisibleColumns[focusedView.FocusedColumn.VisibleIndex + 1];
				//    e.Handled = true;
				//}
				//else
				//{
				//    //if (e.KeyCode != Keys.Up || focusedView.GetFocusedRow() == null || !(focusedView.GetFocusedRow() as DataRowView).IsNew || focusedView.GetFocusedRowCellValue("ItemId") != null && !(focusedView.GetFocusedRowCellValue("ItemId").ToString() == string.Empty))
				//    //    return;
				//    //focusedView.DeleteRow(focusedView.FocusedRowHandle);
				//}
			}
			catch
			{
			}
		}

		private void GridView_Items_ValidateRow(object sender, ValidateRowEventArgs e)
		{
			GridView view = sender as GridView;
			ColumnView columnView = sender as ColumnView;
			int index = e.RowHandle;
			Inv_InvoiceDetail detail = e.Row as Inv_InvoiceDetail;
			if (detail == null || detail.ItemID <= 0)
			{
				e.Valid = false;
				//view.DeleteRow(e.RowHandle);

				//GridView_Items.IsNewItemRow(GridView_Items.FocusedRowHandle);
				return;
			}

			Inv_Item item = CurrentSession.Products.Where(x => x.ID == detail.ItemID).Single();
			if (detail.ItemID.ValidAsIntNonZero() == false)
			{
				e.Valid = false;
				view.SetColumnError(view.Columns[nameof(detail.ItemID)], LangResource.ErrorCantBeEmpry);
			}
			// if (columnView.get)
			if (detail.ItemQty <= 0)
			{
				e.Valid = false;
				view.SetColumnError(view.Columns[nameof(detail.ItemQty)], LangResource.ErrorValMustBeGreaterThan0);
			}
			if (detail.TotalPrice < detail.TotalCostValue)
			{
				if (CurrentSession.user.SellLowerPriceThanBuy == 1)
				{
					e.Valid = false;
					view.SetColumnError(view.Columns[nameof(detail.Price)], LangResource.ErrorCantSellLowerPriceThanBuy);

				}
				else if (CurrentSession.user.SellLowerPriceThanBuy == 0)
				{

					view.SetColumnError(view.Columns[nameof(detail.Price)], LangResource.ItemPriceIsLowerThanCostPrice + "-" + LangResource.PressESCToDismess, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
					//var dialogResult  = XtraMessageBox.Show(text: LangResource.DoYouWantToSellWithPriceLowerThanCost, caption: LangResource.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					//if(dialogResult == DialogResult.No)
					//{
					//    e.Valid = false;
					//    view.SetColumnError(view.Columns[nameof(detail.Price)], LangResource.ErrorCantSellLowerPriceThanBuy, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning );
					//}
				}
			}
			if (LookUpEdit_PostState.EditValue.ValidAsIntNonZero() == false)
			{
				if (item.Serial == true && string.IsNullOrWhiteSpace(detail.Serial))
				{
					e.Valid = false;
					view.SetColumnError(view.Columns[nameof(detail.Serial)], LangResource.ErrorCantBeEmpry);
				}
				if (item.Color && detail.Color.ValidAsIntNonZero() == false)
				{
					e.Valid = false;
					view.SetColumnError(view.Columns[nameof(detail.Color)], LangResource.ErrorCantBeEmpry);
					view.Columns[nameof(detail.Color)].Visible = true;

				}
				if (item.Size && detail.Size.ValidAsIntNonZero() == false)
				{
					e.Valid = false;
					view.SetColumnError(view.Columns[nameof(detail.Size)], LangResource.ErrorCantBeEmpry);
					view.Columns[nameof(detail.Size)].Visible = true;

				}
				if (item.Expier && detail.ExpDate.HasValue == false)
				{
					view.Columns[nameof(detail.ExpDate)].Visible = true;
					e.Valid = false;
					view.SetColumnError(view.Columns[nameof(detail.ExpDate)], LangResource.ErrorCantBeEmpry);
				}
				if (CurrentSession.user.WhenSellingQtyNoBalance == 1 && itemsBalanceInStores.Where(x => x.ItemID == item.ID).Select(x => x.Balance).Single() <= 0)
				{

					view.Columns["CurrentBalance"].Visible = true;
					e.Valid = false;
					view.SetColumnError(view.Columns["CurrentBalance"], LangResource.ErrorCantTakeItemWithNoBalance);

				}
				if (item.Expier && detail.ExpDate.HasValue)
				{
					int relationship = DateTime.Compare(detail.ExpDate.Value, DateTime.Now.Date);
					if (relationship <= 0)
					{
						if (CurrentSession.user.WhenSelllingItemHasExpired == 1)
						{
							if (XtraMessageBox.Show(LangResource.WarningItemHasExpired, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
							{
								view.DeleteRow(e.RowHandle);
							}
						}
						if (CurrentSession.user.WhenSelllingItemHasExpired == 2)
						{
							view.Columns[nameof(detail.ExpDate)].Visible = true;
							e.Valid = false;
							view.SetColumnError(view.Columns[nameof(detail.ExpDate)], LangResource.ErrorCantBeEmpry);
						}

					}
				}
			}
			if (detail.ItemQty > 0 && IsNew && Master.IsItemReachedReorderLevel(item.ID, detail.StoreID.ToInt()))
			{
				if (CurrentSession.user.WhenSellingQtyLessThanReorder == 1)
				{
					if (XtraMessageBox.Show(LangResource.WarningItemTakeRechedReorderLevel, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					{
						view.DeleteRow(e.RowHandle);
					}
				}
				if (CurrentSession.user.WhenSellingQtyLessThanReorder == 2)
				{
					XtraMessageBox.Show(LangResource.ErorrCantTakeSellItemReachedReorderLevel, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
					view.DeleteRow(e.RowHandle);
				}


			}



		}

		private void GridView_Items_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
		{
			if ((e.Row as Inv_InvoiceDetail ).ItemID == 0)
				e.ExceptionMode = ExceptionMode.Ignore;
			else
				e.ExceptionMode = ExceptionMode.NoAction;
		}
		
		private void GridView_Items_RowCountChanged(object sender, EventArgs e)
		{
		   
			GridView_Items_RowUpdated(sender, new RowObjectEventArgs(0, "Index")); 

		}
		void LoadItem(int ID)
		{
			DAL.ERPDataContext dbc = new DAL.ERPDataContext(Program.setting.con);
			Invoice = (from i in dbc.Inv_Invoices where i.ID == ID select i).First();
			GetData();
			IsNew = false;
		}
		private void GridView_Items_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
		{
			GridView view = sender as GridView;
			if (view == null || view.Columns.Count == 0 ) return;
			Inv_InvoiceDetail detail =  view.GetRow(e.FocusedRowHandle ) as Inv_InvoiceDetail;
			if (detail == null)
				return;
			Inv_Item item = CurrentSession.Products.Where(x => x.ID == detail.ItemID).SingleOrDefault ();
			if (item == null ) return;

			int h = e.FocusedRowHandle; 
			view.Columns[nameof(InvoDInsta.Size)].OptionsColumn.AllowEdit = item.Size   ;
			view.Columns[nameof(InvoDInsta.ExpDate)].OptionsColumn.AllowEdit = item.Expier;
			view.Columns[nameof(InvoDInsta.Color)].OptionsColumn.AllowEdit = item.Color;
			view.Columns[nameof(InvoDInsta.Serial)].OptionsColumn.AllowEdit = item.Serial;
			view.Columns[nameof(InvoDInsta.ItemQty)].OptionsColumn.AllowEdit = !item.Serial;
			if (!view.Columns[nameof(InvoDInsta.ItemQty)].OptionsColumn.AllowEdit)
				view.SetRowCellValue(h, nameof(InvoDInsta.ItemQty), 1);

		   
		}
		

		private void GridView_Items_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
		{
			GridView_Items_FocusedRowChanged(sender, new FocusedRowChangedEventArgs(0, GridView_Items.FocusedRowHandle));

		}
		private void frm_Inv_Invoice_FormClosing(object sender, FormClosingEventArgs e)
		{
			Master.SaveGridLayout(GridView_Items, this);
			Master.SaveGridLayout(gridView1 , this);
			Master.SaveGridLayout(repositoryItemGridLookUpEdit1View, this);
			Master.SaveGridLayout(gridLookUpEdit1View, this);
		}
		private void GridView_Items_RowUpdated(object sender, RowObjectEventArgs e)
		{
			var items = GridView_Items.DataSource as Collection<Inv_InvoiceDetail>;
			if (items == null)
				spn_Total.EditValue = 0; 
			else 
			spn_Total.EditValue = items.Sum(x => x.TotalPrice);  
			ChangesMade = true;
		}

		private void GridView_Items_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
		{
			InvoicesHelper.GridView_Items_CustomRowCellEditForEditing(sender, e, true ,true );
		}
		Master.ItemLog SharedLog;
		private void GridView_Items_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			if (e.RowHandle > GridView_Items.RowCount - 1) return;
			GridControl gridControl = sender as GridControl;
			GridView View = GridView_Items as GridView;
			DAL.ERPDataContext dbc = new DAL.ERPDataContext(Program.setting.con);
			int index = e.RowHandle;
			Inv_InvoiceDetail detail =View.GetRow(index) as Inv_InvoiceDetail;
			if (detail == null)
				return;
			var item = CurrentSession.Products .Where(x=>x.ID == detail.ItemID );
			if (e.Column == null) return; 
			switch (e.Column.FieldName)
			{
				case "Code":
					if (e.Value == null || e.Value == DBNull.Value || e.Value.ToString().Trim() == string.Empty) View.DeleteRow(index);
					SharedLog = Master.SearchForItem(e.Value.ToString(), (lkp_Store.EditValue == null) ? 0 : Convert.ToInt32(lkp_Store.EditValue));
					if (SharedLog.ItemID == 0)
					{
						View.DeleteRow(index);
						break;
					}
					detail.ItemID= SharedLog.ItemID;
					if (CodesDictionary.ContainsKey(index))
						CodesDictionary.Remove(index);
					GridView_Items_CellValueChanged(sender, new CellValueChangedEventArgs(index, View.Columns[nameof(InvoDInsta.ItemID)], detail.ItemID) );
					break;
				case nameof(InvoDInsta.ItemID ) :
					if (detail.ItemID ==0)   //e.Value == null || e.Value == DBNull.Value || e.Value.ToString().Trim() == string.Empty)
					{
						View.DeleteRow(index);
						break ;
					}
					if (item == null) return;
					if (SharedLog .ItemID == 0 )
						SharedLog = Master.GetNextItemForSell(detail.ItemID , Convert.ToInt32(lkp_Store.EditValue)); 
					detail.ItemUnitID = SharedLog.UnitID;  
					detail.StoreID = SharedLog.StoreID == 0 ? lkp_Store.EditValue.ToInt() : SharedLog.StoreID;
					detail.ItemQty = 1;
					detail.Color = SharedLog.Color;
					detail.ExpDate = SharedLog.ExpirDate;
					detail.Size = SharedLog.Size;
					detail.Batch = SharedLog.Batch;
					GridView_Items_CellValueChanged(sender, new CellValueChangedEventArgs(index, View.Columns[nameof(InvoDInsta.ItemUnitID)], detail.ItemUnitID)); 
					GridView_Items_CellValueChanged(sender, new CellValueChangedEventArgs(index, View.Columns[nameof(InvoDInsta.ItemQty)], detail.ItemQty)); 
					break;
				case nameof(InvoDInsta.ItemUnitID ) :
					if (detail.ItemUnitID <=0) break ;
					var unit = CurrentSession.ProductsUints.Where(i=> i.ItemID == detail.ItemID  &&  i.UnitID ==detail.ItemUnitID).FirstOrDefault();
					if (unit == null) break ;
					switch (invoiceType)
					{
						case  Master.InvoiceType.SalesInvoice:
								detail.Price = unit.SellPrice;
							break;
						case Master.InvoiceType.PurchaseInvoice :
							detail.Price = unit.BuyPrice ;
							break;
						default:
							throw new NotImplementedException();
					}
					GridView_Items_CellValueChanged(sender, new CellValueChangedEventArgs(index, View.Columns[nameof(InvoDInsta.Price)], detail.Price));
					GridView_Items_CellValueChanged(sender, new CellValueChangedEventArgs(index, View.Columns[nameof(InvoDInsta.ItemQty)], detail.ItemQty));
					break;
				case nameof(InvoDInsta.ItemQty):
					if (detail.ItemID ==0 ) break ;
					unit = CurrentSession.ProductsUints.Where(i => i.ItemID == detail.ItemID && i.UnitID == detail.ItemUnitID).FirstOrDefault();
					double qty = detail.ItemQty  * unit .Factor ;
					var   ppq = (from p in dbc.Inv_ItemPPQs   where p.ItemID == detail.ItemID   && p.FromQty < qty && p.ToQty > qty    select  p.Price ).FirstOrDefault () ;
					if (ppq != null)
						detail.Price = Convert.ToDouble( ppq)  * unit.Factor;
					GridView_Items_CellValueChanged(sender, new CellValueChangedEventArgs(index, View.Columns[nameof(InvoDInsta.Price)], View.GetRowCellValue(index, nameof(InvoDInsta.Price))));
					var CurrentItemCostPerQty = Master.GetCurrentItemCost(detail.StoreID??lkp_Store .EditValue .ToInt(), detail.ItemID);
					unit = CurrentSession.ProductsUints.Where(i => i.ItemID == detail.ItemID && i.UnitID == detail.ItemUnitID).FirstOrDefault();
					if (unit == null) break; 
					if (CurrentItemCostPerQty == null|| CurrentItemCostPerQty.Count ==0)
						break;
					var store = CurrentSession.UserAccessbileStores.Where(x => x.ID == (detail.StoreID ?? lkp_Store.EditValue.ToInt())).SingleOrDefault();
					if (store == null)
						break;
					if (store.CostMethod == 0|| store.CostMethod == 1)
					{
					   
						var remainingQty = detail.ItemQty * unit.Factor;
						double totalPrice = 0;
						int pos = 0;

						if (store.CostMethod == 1)
							pos = CurrentItemCostPerQty.Count - 1;

						while (remainingQty > 0)
						{
							if (CurrentItemCostPerQty.Count - 1 < pos)
								break;
							double minmumQty = (remainingQty <= CurrentItemCostPerQty[pos].AvalableAmount) ? remainingQty : CurrentItemCostPerQty[pos].AvalableAmount;
							totalPrice += CurrentItemCostPerQty[pos].UnitCostPrice * minmumQty;
							remainingQty = remainingQty - minmumQty;
							if (store.CostMethod == 1)
								pos--;
							else
								pos++;
						}
						detail.TotalCostValue = totalPrice;
					}
					else
					{
						detail.TotalCostValue = CurrentItemCostPerQty.Average(x=>x.UnitCostPrice ) * detail.ItemQty* unit.Factor; ; 
					}
					detail.CostValue = detail.TotalCostValue / detail.ItemQty;

					break;
				case nameof(InvoDInsta.Price):
				case nameof(InvoDInsta.Discount):
				   // if (View.FocusedColumn.FieldName == "DiscountVal") break;
					detail.DiscountValue = detail.Discount * (detail.ItemQty  * detail.Price);
					GridView_Items_CellValueChanged(sender, new CellValueChangedEventArgs(index, View.Columns[nameof(InvoDInsta.DiscountValue)], detail.DiscountValue)); 
					break;
				case nameof(InvoDInsta.DiscountValue):
					if (View.FocusedColumn.FieldName == nameof(InvoDInsta.DiscountValue)) {
						detail.Discount = detail.DiscountValue / (detail.ItemQty * detail.Price) ; 
					}
					detail.TotalPrice = (detail.ItemQty * detail.Price) - detail.DiscountValue;  
					break;  
			}
			SharedLog.ItemID = 0;

		}
		Master.AccountBalance CustomerBalance;
		private void glkp_Customer_EditValueChanged(object sender, EventArgs e)
		{
			DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
			var cus = (from c in db.Sl_Customers
					  where c.ID == Convert.ToInt32(LookUpEdit_PartID.EditValue)
					  select c).FirstOrDefault();
			if (cus == null) return;
			txt_Address.Text = cus.Address;
			txt_City.Text = cus.City;
			txt_MaxCredit.Text = cus.MaxCredit.ToString();
			txt_Mobile.Text = cus.Mobile;
			txt_Phone.Text = cus.Phone;
			CustomerBalance = Master.GetAccountBalance(cus.Account);
			txt_BalanceBefore.Text = Math.Abs( CustomerBalance.Balance).ToString();
			txt_BBType.Text = (CustomerBalance.Balance >= 0) ? LangResource.Debit : LangResource.Credit;
			if (IsNew)
			{
				txt_BalanceAfter.Text = Math.Abs((CustomerBalance.Balance + Convert.ToDouble(spn_Remains.EditValue))).ToString();
				txt_BAType.Text = ((CustomerBalance.Balance - Convert.ToDouble(spn_Remains.EditValue)) >= 0) ? LangResource.Debit : LangResource.Credit;
			}
			else
			{
				txt_BalanceAfter.Text = txt_BalanceBefore.Text;
				txt_BAType.Text = txt_BBType.Text;
			}



		}

		private void glkp_Customer_ButtonClick(object sender, ButtonPressedEventArgs e)
		{
			if (e.Button.GetType() != typeof(EditorButton) || e.Button.Tag == null)
				return;

			string btnName = e.Button.Tag.ToString();
			if (btnName == "Add")
			{
				DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
				frm_Main.OpenForm(new frm_Customer ());

			   
			}
		}

		private void glkp_Customer_Popup(object sender, EventArgs e)
		{
			Master.RestoreGridLookUpEditViewLayout(sender, this.Name);

		}
		private MemoryStream rep_layout = new MemoryStream();
		private void glkp_Customer_CloseUp(object sender, CloseUpEventArgs e)
		{
			Master.SaveGridLookUpEditViewLayout (sender, this.Name);
		}

		private void chk_PostState_CheckedChanged(object sender, EventArgs e)
		{
			dt_OutFromStoreDate.Enabled = LookUpEdit_PostState.ValidAsIntNonZero();
		   
		}

		private void gridView2_ValidateRow(object sender, ValidateRowEventArgs e)
		{
			if (GridView_OtherCosts .GetRowCellValue(e.RowHandle, "Amount") == null ||
				GridView_OtherCosts.GetRowCellValue(e.RowHandle, "Amount") == DBNull.Value ||
			 Convert.ToDouble(GridView_OtherCosts.GetRowCellValue(e.RowHandle, "Amount")) <= 0)
			{
				GridView_OtherCosts.SetColumnError(GridView_OtherCosts.Columns["Amount"], LangResource.ErrorValMustBeGreaterThan0);

				e.Valid = false;
			}
			if (GridView_OtherCosts.GetRowCellValue(e.RowHandle, "AccID") == null ||
				GridView_OtherCosts.GetRowCellValue(e.RowHandle, "AccID") == DBNull.Value ||
			Convert.ToDouble(GridView_OtherCosts.GetRowCellValue(e.RowHandle, "AccID")) <= 0)
			{
				GridView_OtherCosts.SetColumnError(GridView_OtherCosts.Columns["AccID"], LangResource.ErrorCantBeEmpry);
				e.Valid = false;
			}

		}

		private void gridView2_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
		{
			e.ExceptionMode = ExceptionMode.NoAction ;
		}

		private void gridView2_RowUpdated(object sender, RowObjectEventArgs e)
		{
			var source = GridView_OtherCosts.DataSource as Collection<Inv_InvoicesExpense>;

			if (source != null &&  source.Count > 0)
				spn_TotalRevenue.EditValue = source.Sum(x => x.Amount);
			else
				spn_TotalRevenue.EditValue = 0;

		}

		private void gridControl2_ProcessGridKey(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
			   GridView_OtherCosts.DeleteSelectedRows();
		}

		private void gridView2_RowCountChanged(object sender, EventArgs e)
		{
			gridView2_RowUpdated(sender, new RowObjectEventArgs(0, "AccID"));
		  

		}

		private void lkp_Store_EditValueChanged(object sender, EventArgs e)
		{
			LookUpEdit_PostState_EditValueChanged(null, null);
			UpdateItemsBalanceFromGridView();
		}
		void UpdateItemsBalanceFromGridView()
		{
			bool _ChangeIsMade = this.ChangesMade;
			GridView View = GridView_Items;
			for (int i = 0; i <= GridView_Items.RowCount - 1; i++)
			{
				int h = i;
				if (View.GetRowCellValue(h, "ItemID") == null || View.GetRowCellValue(h, "ItemID") == DBNull.Value) return;
				if (View.Columns["CurrentBalance"].Visible != false || CurrentSession.user.WhenSellingQtyNoBalance == 1)
				{
					ViewItemBalanceInGrid(View.GetRowCellValue(h, "ItemID").ToInt(), lkp_Store.EditValue.ToInt());

				}

			}
			this.ChangesMade = _ChangeIsMade;

		}
		void CalculateItemBalanceInRow(int h)
		{
			GridView View = GridView_Items;
			if (View.GetRowCellValue(h, "ItemID") == null || View.GetRowCellValue(h, "ItemID") == DBNull.Value) return;
			ViewItemBalanceInGrid(View.GetRowCellValue(h, "ItemID").ToInt(), lkp_Store.EditValue.ToInt());


		}
		

		private void spn_Precent_EditValueChanged(object sender, EventArgs e)
		{
			SpinEdit spn_Precent = sender as SpinEdit;
			if (spn_Precent == null) return;
			SpinEdit spn_Val = null ;
			switch (spn_Precent.Name)
			{
				case nameof(spn_DeductionTax)  :
					spn_Val = spn_DeductionTaxVal;
					break;
				case nameof(spn_AddTax):
					spn_Val = spn_AddTaxVal ;

					break;
				case nameof(spn_Discount):
					spn_Val = spn_DiscountVal ;
					break;
			}
			if (spn_Val == null) return;
			if (spn_Val.IsEditorActive) return;
			Double Prst = Convert.ToDouble(spn_Precent.EditValue);
			Double Val  = Convert.ToDouble(spn_Val.EditValue);
			Double Total = Convert.ToDouble(spn_Total .EditValue);
			spn_Val.EditValue = (Total * Prst);
			   

		}
		void CalculateNetVal()
		{
			Double Total = Convert.ToDouble(spn_Total .EditValue);
			Double ADDTax = Convert.ToDouble(spn_AddTaxVal  .EditValue);
			Double DeductionTax = Convert.ToDouble(spn_DeductionTaxVal  .EditValue);
			Double Discount = Convert.ToDouble(spn_DiscountVal  .EditValue);
			Double OtherCharges = Convert.ToDouble(spn_TotalRevenue.EditValue);
			spn_Net.EditValue =( Total + ADDTax + OtherCharges) -  DeductionTax -Discount ;

		}

		private void spn_Total_EditValueChanged(object sender, EventArgs e)
		{
			spn_Precent_EditValueChanged(spn_AddTax, null);
			spn_Precent_EditValueChanged(spn_DeductionTax , null);
			spn_Precent_EditValueChanged(spn_Discount , null);
			CalculateNetVal();
		}

		private void spn_Val_EditValueChanged(object sender, EventArgs e)
		{
			CalculateNetVal();
			SpinEdit spn_Val = sender as SpinEdit;
			if (spn_Val == null) return;
			if (!spn_Val.IsEditorActive) return;
			SpinEdit spn_Precent = null;
			switch (spn_Val.Name)
			{
				case nameof(spn_DeductionTaxVal ):
					spn_Precent = spn_DeductionTax;
					break;
				case nameof(spn_AddTaxVal):
					spn_Precent = spn_AddTax;

					break;
				case  nameof(spn_DiscountVal ):
					spn_Precent = spn_Discount;
					break;
			}
			if (spn_Precent == null) return;
	
			Double Prst = Convert.ToDouble(spn_Precent.EditValue);
			Double Val = Convert.ToDouble(spn_Val.EditValue);
			Double Total = Convert.ToDouble(spn_Total.EditValue);
			spn_Precent.EditValue = (Val / Total);
  

		}
		bool IsPaidChangedByUser;

		private void spn_Net_EditValueChanged(object sender, EventArgs e)
		{
			if (CurrentSession.user.CanPayFromSalesInvoice == true )
			{
				if (!IsPaidChangedByUser) {

					var firstPay = ((Collection<Acc_Pay>)GridView_Pays.DataSource).FirstOrDefault();
					if(firstPay != null )
						firstPay.Amount  =Convert.ToDouble( spn_Net.EditValue);

					GridView_Pays_RowCountChanged(null, null);
				}
			}
			spn_Remains.EditValue = Convert.ToDouble(spn_Net.EditValue) - Convert.ToDouble(spn_Paid.EditValue);
			spn_Remains_EditValueChanged(null, null);
		}

		private void spn_Paid_EditValueChanged(object sender, EventArgs e)
		{
			spn_Remains.EditValue =  Convert.ToDouble(spn_Net.EditValue) -( Convert.ToDouble(spn_Paid.EditValue));

			if (IsNew)
			{
				txt_BalanceAfter.Text = Math.Abs((CustomerBalance.Balance + Convert.ToDouble(spn_Remains.EditValue))).ToString();
				txt_BAType.Text = ((CustomerBalance.Balance - Convert.ToDouble(spn_Remains.EditValue)) >= 0) ? LangResource.Debit : LangResource.Credit;
			}
			else
			{
				txt_BalanceAfter.Text = txt_BalanceBefore.Text;
				txt_BAType.Text = txt_BBType.Text;
			}
		}

		private void gridView3_DoubleClick(object sender, EventArgs e)
		{
			if (gridView3.FocusedRowHandle >= 0)
			{

				frm_Main.OpenForm(new frm_ItemTake(Convert.ToInt32(gridView3.GetFocusedRowCellValue("ID")), list), openNew: true);
			}
		}

		private void gridControl2_ViewRegistered(object sender, ViewOperationEventArgs e)
		{
			GridView view = e.View as GridView;
			view.OptionsView.ShowFooter = false;
			view.OptionsView.ShowViewCaption = true;
			view.ViewCaption = LangResource.Details;
			view.Columns["ItemID"].Caption = LangResource.Item;
			view.Columns["ItemUnitID"].Caption = LangResource.Unit;
			view.Columns["ItemeQty"].Caption = LangResource.QTY;
			view.Columns["BranchID"].Caption = LangResource.Store;
  
			view.Columns["Size"].Caption = LangResource.Size;
			view.Columns["ExpDate"].Caption = LangResource.ExpDate;
			view.Columns["Serial"].Caption = LangResource.Serial;
			view.Columns["Color"].Caption = LangResource.Color;
			 
			view.Columns["Color"].ColumnEdit = repoColor;
			view.Columns["Size"].ColumnEdit = repoSize;
			repoColor.NullText = repoSize.NullText = "";
			view.SynchronizeClones = true;
			view.Name = "Details";
		}

		private void spn_Remains_EditValueChanged(object sender, EventArgs e)
		{
			if (Convert.ToDouble(spn_Remains.EditValue) == 0)
				spn_Remains.BackColor = System.Drawing.Color.LightGreen ;
			else
				spn_Remains.BackColor = System.Drawing.Color.Red;

			if (spn_Remains.EditValue.ToInt() <= 0)
				ComboBoxEdit_PayStatus.SelectedIndex = 2; //مسدده
			else if (spn_Remains.EditValue.ToInt() > 0 && spn_Remains.EditValue.ToInt() < spn_Net.EditValue.ToInt())
				ComboBoxEdit_PayStatus.SelectedIndex = 1; //مسدده جزئياً
			else if (spn_Remains.EditValue.ToInt() > 0 && spn_Remains.EditValue.ToInt() == spn_Net.EditValue.ToInt())
				ComboBoxEdit_PayStatus.SelectedIndex = 0; //غير مسدده  
			else
				ComboBoxEdit_PayStatus.SelectedIndex = -1;
		}
		public static bool CheckIfInvoiceCanBeDeleted(int id ,int invoiceType, out string _Message)
		{
			DAL.ERPDataContext db = new ERPDataContext(Program.setting.con);
			_Message = LangResource.InvoicesDeletedSuccssefully.Replace("@", id.ToString());
			if (db.Inv_Invoices.Where(x=>x.Source == invoiceType &&x.SourceID == id ).Count() > 0)
			{
				_Message = LangResource.InvoiceDeleteFaild.Replace("@",id.ToString()) + Environment.NewLine + LangResource.CantDeleteInvoiceRelatedBills;
				return false;
			}


			return true; 
		}

		private void GridView_Items_RowCellStyle(object sender, RowCellStyleEventArgs e)
		{
			

			
		}

		private void GridView_Items_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
		{
	      //InvoicesHelper.GridView_Items_CustomDrawCell(sender , e );

		}

		private void spn_Net_DoubleClick(object sender, EventArgs e)
		{
			IsPaidChangedByUser = false;
			spn_Net_EditValueChanged(sender, new EventArgs());
		}

		public override void Print()
		{
			if(Invoice.IsApproved == false )
				XtraMessageBox.Show(LangResource.MustApproveDocumentFirst ); 
			else if (ComboBoxEdit_PayStatus.SelectedIndex  != 2  && CurrentSession.user .CanPrintNotPaidSalesInvoice == false   ) 
				XtraMessageBox.Show(LangResource.CantPrintUnPaidInvoices); 
			else 
				Print(new List<int>() { Invoice.ID }, this.Name,invoiceType );

		}

	 

		public static void Delete(List<int> ids, string CallerForm,Master.InvoiceType _invoiceType)   
			 
		{
			if (!(new frm_Inv_Invoice (null,_invoiceType)).CanPerformDelete()) return;
			DAL.ERPDataContext db = new ERPDataContext(Program.setting.con);
			List<int> PassList = new List<int>();
			string log = string.Empty;
			foreach (int item in ids )
			{
				string Msg = string.Empty ;
				if (CheckIfInvoiceCanBeDeleted(item, (int)_invoiceType,out Msg))
					PassList.Add(item);
				log += Msg + Environment.NewLine;
			}
			ids = PassList;


			foreach (var item in ids)
			{
				Master.InsertUserLog(2, CallerForm, "", item.ToString());
		        Master.DeleteAccountAcctivity(((int)_invoiceType).ToString(), item.ToString()); 
			}
			db.Inv_InvoicesExpenses.DeleteAllOnSubmit(db.Inv_InvoicesExpenses.Where(x => ids.Contains((int)x.InID)));
			db.Inv_StoreLogs.DeleteAllOnSubmit(from l in db.Inv_StoreLogs where l.Type == (int)_invoiceType && (from d in db.Inv_InvoiceDetails where ids.Contains(d.InvoiceID ) select d.ID).ToList().Contains((int)l.TypeID) select l);
			db.SubmitChanges();
			db.Inv_InvoiceDetails.DeleteAllOnSubmit(from d in db.Inv_InvoiceDetails where ids.Contains(d.InvoiceID ) select d);
			db.SubmitChanges();
			db.Inv_Invoices.DeleteAllOnSubmit(db.Inv_Invoices.Where(c => ids.Contains(c.ID)));
			db.SubmitChanges();
			frm_LogViewer.ViewLog(LangResource.InvoiceDeleteLog, log);
			Master.RefreshAllWindows();

		}
	   
		public static  object   PrintDataSource(List<int> ids, Master.InvoiceType invoiceType )
		{

			DAL.ERPDataContext db = new ERPDataContext(Program.setting.con);
		 
			var Invoice =( from h in db.Inv_Invoices
						join b in db.Inv_Stores on h.StoreID equals b.ID
						from p in db.Sl_Customers.Where(x => x.ID == h.PartID).DefaultIfEmpty()
						from user in db.St_Users.Where(x => x.ID == h.UserID).DefaultIfEmpty() 
						where ids.Contains(h.ID)
						select new
						{
							h.ID,
							h.Code,
							h.PartType ,
							PartTypeText="",
							Customer = p.Name,
							h.AttintionMs,
							Store = b.Name,
							h.Date,
							h.DueDate,
							h.Notes,
							h.DiscountRatio,
							h.DiscountValue,
							h.Total,
							h.TotalRevenue,
							h.AddTax,
							h.AddTaxVal,
							h.DeductTaxRatio, 
							h.DeductTaxValue,
							h.Net,
							NetText = "",
							Paid = ((double?)(db.Acc_Pays.Where(x => x.SourceType == (int)invoiceType && x.SourceID == h.ID).Select(x => x.Amount * x.CurrancyRate).Sum())) ?? 0,
							Remains = h.Net - ((double?)(db.Acc_Pays.Where(x => x.SourceType == (int)invoiceType  && x.SourceID == h.ID).Select(x => x.Amount * x.CurrancyRate).Sum())) ?? 0,
							h.Car,
							h.Driver,
							h.Destination,
							h.ShippingAddress, 
							p.City,
							p.Address,
							p.Mobile,
							p.Phone,
							user.UserName,
							Products = db.Inv_InvoiceDetails.Where(x=>x.InvoiceID == h.ID).Select(x=>new
							{
								x.InvoiceID,
								Index = 0,
								Item = db.Inv_Items.Where(u => u.ID == x.ItemID ).SingleOrDefault().Name,
								Unit = db.Inv_UOMs.Where(u=>u.ID == x.ItemUnitID ).SingleOrDefault().Name ,
								x.ItemQty,
								x.Price,
								x.Discount,
								x.DiscountValue,
								x.TotalPrice,
								Color = db.Inv_Colors.Where(u => u.ID == x.Color ).SingleOrDefault().Name,
								x.ExpDate,
								x.Serial,
								Size = db.Inv_Sizes .Where(u => u.ID == x.Size).SingleOrDefault().Name,
								x.Batch
							}).ToList()
						}).ToList();

			var parts = new[]
				 {
					  new { ID = 1 ,Name =  LangResource.Vendor  },
					  new { ID = 2 ,Name =  LangResource.Customer  },
					  new { ID = 3 ,Name =  LangResource.Employee  },
					  new { ID = 4 ,Name =  LangResource.Account  },
					};


			Invoice.ForEach(x =>
			{
				x.Set(i => i.NetText, Master.ConvertMoneyToText(x.Net.ToString(), 1));
				x.Set(i => i.PartTypeText, parts.Single(p => p.ID == x.PartType).Name);
				int Index = 1; 
				x.Products.ForEach(p =>
					p.Set(i => i.Index, Index++));
				
			});
		
		   
			return Invoice;
		}
		private void PrintPayBill( )
		{
			Master.SystemProssess  cashProcess= 0;
			if (invoiceType.In(Master.InvoiceType.SalesInvoice, Master.InvoiceType.PurchaseReturn))
				cashProcess = Master.SystemProssess.CashNoteIn;
			else if (invoiceType.In(Master.InvoiceType.SalesReturn, Master.InvoiceType.PurchaseInvoice))
				cashProcess = Master.SystemProssess.CashNoteOut;
			else
				return;



			var smartCode = Master.GenerateSmartCode(prossess: cashProcess, IsNew: 0, PartType: Invoice.PartType, PartID: Invoice.PartID, SourceType:(int)invoiceType, SourceID: Invoice.ID);
			Reporting.rpt_Inv_InvoicePayBill.Print(PrintDataSource(new List<int>() { Invoice.ID },invoiceType ),smartCode );
		}

		private void adornerUIManager1_QueryGuideFlyoutControl(object sender, QueryGuideFlyoutControlEventArgs e)
		{
			if (e.SelectedElement.TargetElement == txt_Code)
				e.Control = new UserControls.uc_HintControl(ref adornerUIManager1, LangResource.h_InvoiceCode);
			if (e.SelectedElement.TargetElement == txt_Attn )
				e.Control = new UserControls.uc_HintControl(ref adornerUIManager1, LangResource.h_InvoiceAttention );

			if (e.SelectedElement.TargetElement == lkp_Store  )
				e.Control = new UserControls.uc_HintControl(ref adornerUIManager1, LangResource.h_InvoiceStore );
			//if (e.SelectedElement.TargetElement == chk_PostState )
			//    e.Control = new UserControls.uc_HintControl(ref adornerUIManager1, LangResource.h_InvoiceOutFromStore );
			if (e.SelectedElement.TargetElement == dt_OutFromStoreDate)
				e.Control = new UserControls.uc_HintControl(ref adornerUIManager1, LangResource.h_InvoiceOutFromStoreDate);
			if (e.SelectedElement.TargetElement == dt_Date)
				e.Control = new UserControls.uc_HintControl(ref adornerUIManager1, LangResource.h_InvoiceDate );
			if (e.SelectedElement.TargetElement == dt_DeliveryDate)
				e.Control = new UserControls.uc_HintControl(ref adornerUIManager1, LangResource.h_InvoiceDeleveryDate );
			if (e.SelectedElement.TargetElement == dt_DueDate)
				e.Control = new UserControls.uc_HintControl(ref adornerUIManager1, LangResource.h_DueDate );
			if (e.SelectedElement.TargetElement == LookUpEdit_SourceID)
				e.Control = new UserControls.uc_HintControl(ref adornerUIManager1, LangResource.h_InvoiceOrderNumber );
			if (e.SelectedElement.TargetElement == lkp_CCenter )
				e.Control = new UserControls.uc_HintControl(ref adornerUIManager1, LangResource.h_CoastCenter );
			if (e.SelectedElement.TargetElement == lkp_SaleBookID )
				e.Control = new UserControls.uc_HintControl(ref adornerUIManager1, LangResource.h_InvoicesBook );
			if (e.SelectedElement.TargetElement == txt_InsertUser )
				e.Control = new UserControls.uc_HintControl(ref adornerUIManager1, LangResource.h_InsertUser );
			if (e.SelectedElement.TargetElement == txt_LastUpdate )
				e.Control = new UserControls.uc_HintControl(ref adornerUIManager1, LangResource.h_lastUpdateDate );
			if (e.SelectedElement.TargetElement == txt_UpdateUser)
				e.Control = new UserControls.uc_HintControl(ref adornerUIManager1, LangResource.h_lastUpdateUser);
			//if (e.SelectedElement.TargetElement == xtraTabPage1 )
			//    e.Control = new UserControls.uc_HintControl(ref adornerUIManager1, LangResource.h_OtherExpences );
			if (e.SelectedElement.TargetElement == spn_Total  )
				e.Control = new UserControls.uc_HintControl(ref adornerUIManager1, LangResource.h_Total );
			if (e.SelectedElement.TargetElement == spn_Net )
				e.Control = new UserControls.uc_HintControl(ref adornerUIManager1, LangResource.h_InoiceNet );

		  
		}

		private void glkp_SaleOrder_EditValueChanged(object sender, EventArgs e)
		{
			if (LookUpEdit_SourceID.EditValue == null) return;
			FillFromSalesOrder(Convert.ToInt32(LookUpEdit_SourceID.EditValue));
		}
		public void FillFromSalesOrder(int ID)
		{
			if (!IsNew) return;  
		   // Details_Datatable.Rows.Clear();
			DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
			var query = from d in db.SL_OrderDetails
						where d.OrderID.ToString() == ID.ToString()
						select new
						{
							d.OrderID,
							d.ItemID,
							d.ItemUnitID,
							d.ItemQty,
							d.Price,
							d.TotalPrice,
							d.Color,
							d.Size,

						};
			var PArt = from c in db.SL_Orders where c.ID == ID select c.CustomerID;
			LookUpEdit_PartID.EditValue = PArt.SingleOrDefault();
			foreach (var q in query.ToList())
			{
				var TakenQty = ((from d in db.Inv_InvoiceDetails 
								 from b in db.Inv_Invoices .Where(x => x.ID == d.InvoiceID )
								 where d.ItemID == q.ItemID && d.ItemUnitID == q.ItemUnitID
								 && b.Source   == q.OrderID
								 select d.ItemQty).ToList().DefaultIfEmpty().Sum());
				double RemainingItemQty = q.ItemQty - TakenQty;
				if (RemainingItemQty > 0)
				{ 
				 //   Details_Datatable.Rows.Add();
					int h = GridView_Items.RowCount - 1;
					GridView_Items.SetRowCellValue(h, "ItemID", q.ItemID);
				  //  SetUnitID = false;
					GridView_Items.SetRowCellValue(h, "ItemUnitID", q.ItemUnitID);
					GridView_Items.SetRowCellValue(h, "Price", q.Price);
					GridView_Items.SetRowCellValue(h, "ItemQty", RemainingItemQty);
					GridView_Items.SetRowCellValue(h, "Color", q.Color);
					GridView_Items.SetRowCellValue(h, "Size", q.Size);
				}


			}
			if (GridView_Items.RowCount == 0)
			{
			   // XtraMessageBox.Show(LangResource.InfoAlOrderItemsHaseBeenTake, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

		}

		private void glkp_SaleOrder_ButtonClick(object sender, ButtonPressedEventArgs e)
		{
			if (e.Button.GetType() != typeof(EditorButton) || e.Button.Tag == null) return;
			if (LookUpEdit_SourceID .EditValue == null || LookUpEdit_SourceID.EditValue == DBNull.Value && Convert.ToInt32(LookUpEdit_SourceID.EditValue) == 0  ) return;
			if (e.Button.Tag.ToString() == "Open")
				frm_Main.OpenForm(new frm_Sl_Order(Convert.ToInt32(LookUpEdit_SourceID.EditValue)), openNew:true , CloseIfOpen:false);
			 
		}

	

		private void CreatePayReceipt_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
		{

		}

		private void layoutControlGroup5_Shown(object sender, EventArgs e)
		{
			
		}

		private void CheckEdit_IsApproved_CheckedChanged(object sender, EventArgs e)
		{


			
			if (Invoice.IsApproved  == false && CheckEdit_IsApproved.Checked  == true && ((IsNew == ChangesMade == true) || IsNew == false) && CurrentSession.user.CanApproveSalesInvoices )
			{
				if (   XtraMessageBox.Show(text: LangResource.DoYouWantToApproveAndSaveTheDocument, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
				  CheckEdit_IsApproved.Checked = true;
					Save();    
				}
				else
					CheckEdit_IsApproved.Checked = false; 
			}

			CheckEdit_IsApproved.Text = (CheckEdit_IsApproved.Checked) ? LangResource.DocumentApproved  : LangResource.NotApproved1 ;
			 
			if (CheckEdit_IsApproved.Checked == false && CurrentSession.user.CanApproveSalesInvoices)
				CheckEdit_IsApproved.Enabled = true;
			else
				CheckEdit_IsApproved.Enabled = false;

		}

 

		private void SimpleButton_CreatePayReciept_Click(object sender, EventArgs e)
		{
		   PrintPayBill();
		}
		private void gridView1_RowUpdated(object sender, RowObjectEventArgs e)
		{
			MessageBox.Show((e.RowHandle ).ToString());
		}

		private void PrintItemTakeBill()
		{
			Reporting.rpt_Inv_InvoiceItemTakeBill.Print(PrintDataSource(new List<int>() { Invoice.ID },invoiceType ));
		}
	 

		public static void Print(List<int> ids, string CallerForm,Master.InvoiceType invoiceType)
		{
			if ((new frm_Inv_Invoice (null, invoiceType)).CanPerformPrint() == false) return;
			List<int> IdsToRemove = new List<int>();
			DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
			var invoicesList = db.Inv_Invoices.Where(x => ids.Contains(x.ID) && x.IsApproved == true  ).Select(x =>  x.ID ).ToList(); 
			foreach (var item in invoicesList )
			{
			   
				Master.InsertUserLog(3, CallerForm, "", item.ToString());
			}
			if (invoicesList.Count > 0)
			  Reporting.rpt_Inv_Invoice.Print(PrintDataSource(invoicesList, invoiceType), invoiceType);
			if(invoicesList.Count != ids.Count)
			{
				XtraMessageBox.Show(LangResource.SomeDocumentsCantBePrint_notApproved);
			} 
			//base.Print();
		}

		public override void ShowHints()
		{
			base.ShowHints();
			adornerUIManager1.ShowGuides = DefaultBoolean.True;

		}

		private void layoutControlGroup5_CustomButtonChecked(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
		{
			var group = sender as LayoutControlGroup;
			group.Expanded = !group.Expanded;
			group.TextLocation = group.Expanded ? Locations.Top : Locations.Left ;
		}

	

		private void LookUpEdit_Source_EditValueChanged(object sender, EventArgs e)
		{
			DAL.ERPDataContext db = new DAL.ERPDataContext(Program.setting.con);
			var dateSource = (new[] { new { ID = 0 } }).ToList() ;
			dateSource.Clear();
			switch (LookUpEdit_Source.EditValue )
			{
				case (int)Master.InvoiceType.SalesOrder :
				    dateSource = db.Inv_Invoices.Where(x => x.PostState == 0 && x.InvoiceType == (int)Master.InvoiceType.SalesOrder).Select(x => new { x.ID }).ToList();
					break;
			}
			LookUpEdit_SourceID.Properties.DataSource = dateSource;
		}

		private void LookUpEdit_PartID_EditValueChanging(object sender, ChangingEventArgs e)
		{
			var pays = GridView_Pays.DataSource as Collection<Acc_Pay>;

			if(pays != null && pays.Count(x => x.PayType == (byte)Master.PayTypes.CashNote) != 0 && IsLoadingData == false )
			{
				XtraMessageBox.Show(LangResource.CantChangePartAfterAddingCashNotes);
				e.Cancel = true;
			}

		}
	}
}
