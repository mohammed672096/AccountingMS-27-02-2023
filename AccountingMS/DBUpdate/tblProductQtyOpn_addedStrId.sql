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

CREATE TABLE dbo.Tmp_tblProductQtyOpn
	(
	qtyId int NOT NULL IDENTITY (1, 1) NOT FOR REPLICATION,
	qtyStrId smallint NOT NULL,
	qtyPrdId int NOT NULL,
	qtyPrdMsurId int NOT NULL,
	qtyPrice decimal(10, 3) NOT NULL,
	qtyQuantity float(53) NOT NULL,
	qtyDate date NOT NULL,
	qtyBranchId smallint NOT NULL,
	qtyStatus tinyint NOT NULL
	)  ON [PRIMARY]
ALTER TABLE dbo.Tmp_tblProductQtyOpn SET (LOCK_ESCALATION = TABLE)
ALTER TABLE dbo.Tmp_tblProductQtyOpn ADD CONSTRAINT
	DF_tblProductQtyOpn_qtyStrId DEFAULT 1 FOR qtyStrId
SET IDENTITY_INSERT dbo.Tmp_tblProductQtyOpn ON
IF EXISTS(SELECT * FROM dbo.tblProductQtyOpn)
	 EXEC('INSERT INTO dbo.Tmp_tblProductQtyOpn (qtyId, qtyPrdId, qtyPrdMsurId, qtyPrice, qtyQuantity, qtyDate, qtyBranchId, qtyStatus)
		SELECT qtyId, qtyPrdId, qtyPrdMsurId, qtyPrice, qtyQuantity, qtyDate, qtyBranchId, qtyStatus FROM dbo.tblProductQtyOpn WITH (HOLDLOCK TABLOCKX)')
SET IDENTITY_INSERT dbo.Tmp_tblProductQtyOpn OFF
DROP TABLE dbo.tblProductQtyOpn
EXECUTE sp_rename N'dbo.Tmp_tblProductQtyOpn', N'tblProductQtyOpn', 'OBJECT' 
ALTER TABLE dbo.tblProductQtyOpn ADD CONSTRAINT
	PK_tblProductQtyOpn PRIMARY KEY CLUSTERED 
	(
	qtyId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

COMMIT
select Has_Perms_By_Name(N'dbo.tblProductQtyOpn', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.tblProductQtyOpn', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.tblProductQtyOpn', 'Object', 'CONTROL') as Contr_Per 