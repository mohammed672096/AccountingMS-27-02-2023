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

CREATE TABLE dbo.Tmp_tblOrderSub
	(
	ordId int NOT NULL IDENTITY (1, 1),
	ordMainId int NOT NULL,
	ordPrdId int NOT NULL,
	ordMsurId int NOT NULL,
	ordPrdBarcode varchar(30) NULL,
	ordQuantity int NOT NULL,
	ordPrice decimal(10, 3) NULL,
	ordTaxPercent tinyint NULL,
	ordTax decimal(10, 3) NULL,
	ordTotal decimal(10, 3) NULL,
	ordDesc nvarchar(80) NULL,
	ordNote nvarchar(80) NULL,
	ordDate date NOT NULL,
	ordBrnId smallint NOT NULL,
	ordStatus tinyint NOT NULL
	)  ON [PRIMARY]
ALTER TABLE dbo.Tmp_tblOrderSub SET (LOCK_ESCALATION = TABLE)
SET IDENTITY_INSERT dbo.Tmp_tblOrderSub ON
IF EXISTS(SELECT * FROM dbo.tblOrderSub)
	 EXEC('INSERT INTO dbo.Tmp_tblOrderSub (ordId, ordMainId, ordPrdId, ordMsurId, ordPrdBarcode, ordQuantity, ordDesc, ordNote, ordDate, ordBrnId, ordStatus)
		SELECT ordId, ordMainId, ordPrdId, ordMsurId, ordPrdBarcode, ordQuantity, ordDesc, ordNote, ordDate, ordBrnId, ordStatus FROM dbo.tblOrderSub WITH (HOLDLOCK TABLOCKX)')
SET IDENTITY_INSERT dbo.Tmp_tblOrderSub OFF
DROP TABLE dbo.tblOrderSub
EXECUTE sp_rename N'dbo.Tmp_tblOrderSub', N'tblOrderSub', 'OBJECT' 
ALTER TABLE dbo.tblOrderSub ADD CONSTRAINT
	PK_tblOrderSub PRIMARY KEY CLUSTERED 
	(
	ordId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

COMMIT
select Has_Perms_By_Name(N'dbo.tblOrderSub', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.tblOrderSub', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.tblOrderSub', 'Object', 'CONTROL') as Contr_Per 