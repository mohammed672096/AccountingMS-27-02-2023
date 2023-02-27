USE [accounting]

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[tblDscntPermission](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[dscUsrId] [smallint] NOT NULL,
	[dscPercent] [tinyint] NOT NULL,
	[dscPermission] [bit] NOT NULL,
 CONSTRAINT [PK_tblDscntPermission] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
