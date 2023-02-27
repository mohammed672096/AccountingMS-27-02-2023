

CREATE TABLE [dbo].[InventoryBalancingDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MainID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[UnitID] [int] NOT NULL,
	[Qty] [float] NOT NULL,
	[RealQty] [float] NOT NULL,
	[Shotage] [float] NOT NULL,
	[Surplus] [float] NOT NULL,
	[Cost] [float] NOT NULL,
	[TotalCost] [float] NOT NULL,
	[Price] [float] NOT NULL,
	[TotalPrice] [float] NOT NULL,
 CONSTRAINT [PK_InventoryBalancingDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[InventoryBalancingDetails] ADD  DEFAULT ((0)) FOR [TotalPrice]
GO


