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

ALTER TABLE dbo.tblEntrySub ADD
	entInvoDate date NULL

ALTER TABLE dbo.tblEntrySub SET (LOCK_ESCALATION = TABLE)

COMMIT
select Has_Perms_By_Name(N'dbo.tblEntrySub', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.tblEntrySub', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.tblEntrySub', 'Object', 'CONTROL') as Contr_Per 