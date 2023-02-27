USE [accounting]


SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[tblNotification](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[notId] [int] NOT NULL,
	[notNo] [int] NULL,
	[notName] [nvarchar](100) NULL,
	[notDesc] [nvarchar](100) NULL,
	[notAmount] [decimal](13, 3) NULL,
	[notType] [tinyint] NOT NULL,
	[notDate] [date] NOT NULL,
	[notUsrId] [smallint] NOT NULL,
	[notBrnId] [smallint] NOT NULL,
	[notStatus] [bit] NOT NULL,
 CONSTRAINT [PK_tblNotification] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
