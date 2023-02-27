USE [accounting]

CREATE TABLE [dbo].[tblInvStoreMain](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[invNo] [int] NOT NULL,
	[invStrId] [smallint] NOT NULL,
	[invDate] [smalldatetime] NOT NULL,
	[invBrnId] [smallint] NOT NULL,
	[invStatus] [tinyint] NOT NULL,
 CONSTRAINT [PK_tblInvStoreMain] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]