USE [accounting]
GO



CREATE TABLE [dbo].[TaxDeclaration](
	[ID] [int] IDENTITY(1,1)  NOT NULL,
	[Code] [varchar](50) NOT NULL, 
	[FromDate] [DateTime]NOT NULL, 
	[ToDate] [DateTime]NOT NULL, 
	[Notes] [nvarchar](max),
	Sales float not null,
	SalesReturn float not null,
	SalesTax float not null,
	SalesTotal float not null,
	SalesReturnTotal float not null,
	SalesTaxTotal float not null,

	Purchase float not null,
	PurchaseReturn float not null,
	PurchaseTax float not null,
	PurchaseTotal float not null,
	PurchaseReturnTotal float not null,
	PurchaseTaxTotal float not null,

	CurrentTax float not null,

 CONSTRAINT [PK_TaxDeclaration] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


