/*
   Saturday, June 13, 20208:20:26 PM
   User: sa
   Server: .\SQLEXPRESS
   Database: accounting
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
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
GO
ALTER TABLE dbo.tblSupplySub
	DROP CONSTRAINT DF_tblSupplySub_supStatus
GO
CREATE TABLE dbo.Tmp_tblSupplySub
	(
	id int NOT NULL IDENTITY (1, 1),
	supNo int NOT NULL,
	supAccNo bigint NOT NULL,
	supAccName nvarchar(80) NOT NULL,
	supDesc nvarchar(70) NULL,
	supPrdBarcode nvarchar(30) NULL,
	supPrdNo nvarchar(15) NULL,
	supPrdName nvarchar(50) NULL,
	supPrdId int NULL,
	supMsur int NULL,
	supCurrency tinyint NULL,
	supQuanMain float(53) NULL,
	supPrice decimal(11, 4) NULL,
	supSalePrice decimal(11, 4) NULL,
	supTaxPercent tinyint NULL,
	supTaxPrice decimal(11, 4) NULL,
	supDscntPercent float(53) NULL,
	supDebit decimal(11, 4) NULL,
	supCredit decimal(11, 4) NULL,
	supDebitFrgn decimal(11, 4) NULL,
	supCreditFrgn decimal(11, 4) NULL,
	supDate date NOT NULL,
	supBrnId smallint NULL,
	supUserId smallint NULL,
	supStatus tinyint NOT NULL,
	supPrdManufacture bit NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_tblSupplySub SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_tblSupplySub ADD CONSTRAINT
	DF_tblSupplySub_supStatus DEFAULT ((1)) FOR supStatus
GO
SET IDENTITY_INSERT dbo.Tmp_tblSupplySub ON
GO
IF EXISTS(SELECT * FROM dbo.tblSupplySub)
	 EXEC('INSERT INTO dbo.Tmp_tblSupplySub (id, supNo, supAccNo, supAccName, supDesc, supPrdBarcode, supPrdNo, supPrdName, supPrdId, supMsur, supCurrency, supQuanMain, supPrice, supSalePrice, supTaxPercent, supTaxPrice, supDscntPercent, supDebit, supCredit, supDebitFrgn, supCreditFrgn, supDate, supBrnId, supUserId, supStatus, supPrdManufacture)
		SELECT id, supNo, supAccNo, supAccName, supDesc, supPrdBarcode, supPrdNo, supPrdName, supPrdId, supMsur, supCurrency, supQuanMain, supPrice, supSalePrice, supTaxPercent, supTaxPrice, supDscntPercent, CONVERT(decimal(9, 4), supDebit), CONVERT(decimal(9, 4), supCredit), supDebitFrgn, supCreditFrgn, supDate, supBrnId, supUserId, supStatus, supPrdManufacture FROM dbo.tblSupplySub WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_tblSupplySub OFF
GO
DROP TABLE dbo.tblSupplySub
GO
EXECUTE sp_rename N'dbo.Tmp_tblSupplySub', N'tblSupplySub', 'OBJECT' 
GO
ALTER TABLE dbo.tblSupplySub ADD CONSTRAINT
	PK_tblSupplySub PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
