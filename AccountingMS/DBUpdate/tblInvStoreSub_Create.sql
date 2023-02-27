USE [accounting]

CREATE TABLE [dbo].[tblInvStoreSub](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[invMainId] [int] NOT NULL,
	[invPrdId] [int] NOT NULL,
	[invPrdMsurId] [int] NOT NULL,
	[invPrdGrpId] [int] NOT NULL,
	[invQuanStr] [float] NOT NULL,
	[invQuanAvl] [float] NOT NULL,
	[invQuanDefr] [float] NOT NULL,
	[invPriceAvrg] [decimal](11, 3) NOT NULL,
	[invPriceDefr] [decimal](11, 3) NOT NULL,
	[invPriceTotal] [decimal](11, 3) NOT NULL,
	[invSalePrice] [decimal](11, 3) NOT NULL,
	[invSalePriceTotal] [decimal](11, 3) NOT NULL,
 CONSTRAINT [PK_tblInvStore] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[tblInvStoreSub] ADD  CONSTRAINT [DF_tblInvStoreSub_invPriceTotal]  DEFAULT ((0)) FOR [invPriceTotal]

ALTER TABLE [dbo].[tblInvStoreSub] ADD  CONSTRAINT [DF_tblInvStoreSub_invSalePrice]  DEFAULT ((0)) FOR [invSalePrice]

ALTER TABLE [dbo].[tblInvStoreSub] ADD  CONSTRAINT [DF_tblInvStoreSub_invSalePriceTotal]  DEFAULT ((0)) FOR [invSalePriceTotal]
