use accounting

BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION

ALTER TABLE dbo.tblInvStoreSub ADD
	invPriceTotal decimal(11, 3) NOT NULL CONSTRAINT DF_tblInvStoreSub_invPriceTotal DEFAULT 0,
	invSalePrice decimal(11, 3) NOT NULL CONSTRAINT DF_tblInvStoreSub_invSalePrice DEFAULT 0,
	invSalePriceTotal decimal(11, 3) NOT NULL CONSTRAINT DF_tblInvStoreSub_invSalePriceTotal DEFAULT 0

ALTER TABLE dbo.tblInvStoreSub SET (LOCK_ESCALATION = TABLE)

COMMIT
select Has_Perms_By_Name(N'dbo.tblInvStoreSub', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.tblInvStoreSub', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.tblInvStoreSub', 'Object', 'CONTROL') as Contr_Per 