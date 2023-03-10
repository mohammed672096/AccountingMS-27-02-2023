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

CREATE TABLE dbo.Tmp_tblFinancialYear
	(
	fyId int NOT NULL IDENTITY (1, 1) NOT FOR REPLICATION,
	fyName nvarchar(15) NOT NULL,
	fyDateStart smalldatetime NOT NULL,
	fyDateEnd smalldatetime NOT NULL,
	fyBranchId smallint NOT NULL,
	fyIsNewYear bit NOT NULL,
	fyStatus bit NOT NULL
	)  ON [PRIMARY]

ALTER TABLE dbo.Tmp_tblFinancialYear SET (LOCK_ESCALATION = TABLE)

ALTER TABLE dbo.Tmp_tblFinancialYear ADD CONSTRAINT
	DF_tblFinancialYear_fyIsNewYear DEFAULT 0 FOR fyIsNewYear

SET IDENTITY_INSERT dbo.Tmp_tblFinancialYear ON

IF EXISTS(SELECT * FROM dbo.tblFinancialYear)
	 EXEC('INSERT INTO dbo.Tmp_tblFinancialYear (fyId, fyName, fyDateStart, fyDateEnd, fyBranchId, fyStatus)
		SELECT fyId, fyName, fyDateStart, fyDateEnd, fyBranchId, fyStatus FROM dbo.tblFinancialYear WITH (HOLDLOCK TABLOCKX)')

SET IDENTITY_INSERT dbo.Tmp_tblFinancialYear OFF

DROP TABLE dbo.tblFinancialYear

EXECUTE sp_rename N'dbo.Tmp_tblFinancialYear', N'tblFinancialYear', 'OBJECT' 

ALTER TABLE dbo.tblFinancialYear ADD CONSTRAINT
	PK_tblFinancialYear PRIMARY KEY CLUSTERED 
	(
	fyId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]


COMMIT
select Has_Perms_By_Name(N'dbo.tblFinancialYear', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.tblFinancialYear', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.tblFinancialYear', 'Object', 'CONTROL') as Contr_Per 