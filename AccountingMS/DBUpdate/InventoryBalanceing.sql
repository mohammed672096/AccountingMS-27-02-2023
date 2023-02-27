

CREATE TABLE [dbo].[InventoryBalanceing](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Date] [datetime] NOT NULL,
	[BranchID] [int] NOT NULL,
	[EmployeeName] [nvarchar](250) NOT NULL,
	[TotalShortageQty] [float] NOT NULL,
	[TotalSurplusQty] [float] NOT NULL,
	[TotalShortageValue] [float] NOT NULL,
	[TotalSurplusValue] [float] NOT NULL,
	[NetProfitOrLoses] [float] NOT NULL,
	[TotalShortageValueSale] [float] NOT NULL,
	[TotalSurplusValueSale] [float] NOT NULL,
	[NetProfitOrLosesSale] [float] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[IsPosted] [bit] NOT NULL,
 CONSTRAINT [PK_InventoryBalanceing] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


