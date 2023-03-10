/*
   Monday, March 1, 20212:16:38 PM
   User: 
   Server: .\sql
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
ALTER TABLE dbo.tblPrdPriceMeasurment
	DROP CONSTRAINT DF_tblPrdPriceMeasurment_ppmWeight
GO
CREATE TABLE dbo.Tmp_tblPrdPriceMeasurment
	(
	ppmId int NOT NULL IDENTITY (1, 1) NOT FOR REPLICATION,
	ppmMsurName nvarchar(30) NULL,
	ppmPrice decimal(9, 4) NULL,
	ppmSalePrice decimal(11, 4) NULL,
	ppmMinSalePrice decimal(11, 4) NULL,
	ppmRetailPrice decimal(11, 4) NULL,
	ppmBatchPrice decimal(11, 4) NULL,
	ppmBarcode1 nvarchar(30) NULL,
	ppmBarcode2 nvarchar(30) NULL,
	ppmBarcode3 nvarchar(30) NULL,
	ppmConversion decimal(9, 4) NULL,
	ppmDefault decimal(9, 4) NULL,
	ppmPrdId int NOT NULL,
	ppmWeight bit NOT NULL,
	ppmBrnId smallint NULL,
	ppmStatus tinyint NOT NULL,
	ppmManufacture bit NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_tblPrdPriceMeasurment SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_tblPrdPriceMeasurment ADD CONSTRAINT
	DF_tblPrdPriceMeasurment_ppmWeight DEFAULT ((0)) FOR ppmWeight
GO
SET IDENTITY_INSERT dbo.Tmp_tblPrdPriceMeasurment ON
GO
IF EXISTS(SELECT * FROM dbo.tblPrdPriceMeasurment)
	 EXEC('INSERT INTO dbo.Tmp_tblPrdPriceMeasurment (ppmId, ppmMsurName, ppmPrice, ppmSalePrice, ppmMinSalePrice, ppmRetailPrice, ppmBatchPrice, ppmBarcode1, ppmBarcode2, ppmBarcode3, ppmConversion, ppmDefault, ppmPrdId, ppmWeight, ppmBrnId, ppmStatus, ppmManufacture)
		SELECT ppmId, ppmMsurName, ppmPrice, ppmSalePrice, ppmMinSalePrice, ppmRetailPrice, ppmBatchPrice, ppmBarcode1, ppmBarcode2, ppmBarcode3, CONVERT(decimal(9, 4), ppmConversion), CONVERT(decimal(9, 4), ppmDefault), ppmPrdId, ppmWeight, ppmBrnId, ppmStatus, ppmManufacture FROM dbo.tblPrdPriceMeasurment WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_tblPrdPriceMeasurment OFF
GO
DROP TABLE dbo.tblPrdPriceMeasurment
GO
EXECUTE sp_rename N'dbo.Tmp_tblPrdPriceMeasurment', N'tblPrdPriceMeasurment', 'OBJECT' 
GO
ALTER TABLE dbo.tblPrdPriceMeasurment ADD CONSTRAINT
	PK_tblPrdPriceMeasurment PRIMARY KEY CLUSTERED 
	(
	ppmId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
