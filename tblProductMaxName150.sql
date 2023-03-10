/*
   Sunday, June 7, 20204:32:16 PM
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
ALTER TABLE dbo.tblProduct
	DROP CONSTRAINT DF_tblProduct_prdSaleTax
GO
ALTER TABLE dbo.tblProduct
	DROP CONSTRAINT DF_tblProduct_prdStatus
GO
ALTER TABLE dbo.tblProduct
	DROP CONSTRAINT DF_tblProduct_ReorderLevel
GO
ALTER TABLE dbo.tblProduct
	DROP CONSTRAINT DF_tblProduct_MaxLevel
GO
CREATE TABLE dbo.Tmp_tblProduct
	(
	id int NOT NULL IDENTITY (1, 1),
	prdNo nvarchar(15) NOT NULL,
	prdName nvarchar(150) NOT NULL,
	prdNameEng varchar(50) NULL,
	prdGrpNo int NOT NULL,
	prdDesc nvarchar(50) NULL,
	prdSaleTax bit NOT NULL,
	prdBrnId smallint NULL,
	prdStatus tinyint NOT NULL,
	prdPriceTax bit NOT NULL,
	ReorderLevel float(53) NOT NULL,
	MaxLevel float(53) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_tblProduct SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_tblProduct ADD CONSTRAINT
	DF_tblProduct_prdSaleTax DEFAULT ((0)) FOR prdSaleTax
GO
ALTER TABLE dbo.Tmp_tblProduct ADD CONSTRAINT
	DF_tblProduct_prdStatus DEFAULT ((1)) FOR prdStatus
GO
ALTER TABLE dbo.Tmp_tblProduct ADD CONSTRAINT
	DF_tblProduct_ReorderLevel DEFAULT ((0)) FOR ReorderLevel
GO
ALTER TABLE dbo.Tmp_tblProduct ADD CONSTRAINT
	DF_tblProduct_MaxLevel DEFAULT ((0)) FOR MaxLevel
GO
SET IDENTITY_INSERT dbo.Tmp_tblProduct ON
GO
IF EXISTS(SELECT * FROM dbo.tblProduct)
	 EXEC('INSERT INTO dbo.Tmp_tblProduct (id, prdNo, prdName, prdNameEng, prdGrpNo, prdDesc, prdSaleTax, prdBrnId, prdStatus, prdPriceTax, ReorderLevel, MaxLevel)
		SELECT id, prdNo, prdName, prdNameEng, prdGrpNo, prdDesc, prdSaleTax, prdBrnId, prdStatus, prdPriceTax, ReorderLevel, MaxLevel FROM dbo.tblProduct WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_tblProduct OFF
GO
DROP TABLE dbo.tblProduct
GO
EXECUTE sp_rename N'dbo.Tmp_tblProduct', N'tblProduct', 'OBJECT' 
GO
ALTER TABLE dbo.tblProduct ADD CONSTRAINT
	PK_colid PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
