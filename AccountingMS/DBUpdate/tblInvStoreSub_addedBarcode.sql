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

ALTER TABLE dbo.tblInvStoreSub
	DROP CONSTRAINT DF_tblInvStoreSub_invPriceTotal
ALTER TABLE dbo.tblInvStoreSub
	DROP CONSTRAINT DF_tblInvStoreSub_invSalePrice
ALTER TABLE dbo.tblInvStoreSub
	DROP CONSTRAINT DF_tblInvStoreSub_invSalePriceTotal
CREATE TABLE dbo.Tmp_tblInvStoreSub
	(
	id int NOT NULL IDENTITY (1, 1),
	invMainId int NOT NULL,
	invBarcode nvarchar(50) NULL,
	invPrdId int NOT NULL,
	invPrdMsurId int NOT NULL,
	invPrdGrpId int NOT NULL,
	invQuanStr float(53) NOT NULL,
	invQuanAvl float(53) NOT NULL,
	invQuanDefr float(53) NOT NULL,
	invPriceAvrg decimal(11, 3) NOT NULL,
	invPriceDefr decimal(11, 3) NOT NULL,
	invPriceTotal decimal(11, 3) NOT NULL,
	invSalePrice decimal(11, 3) NOT NULL,
	invSalePriceTotal decimal(11, 3) NOT NULL
	)  ON [PRIMARY]
ALTER TABLE dbo.Tmp_tblInvStoreSub SET (LOCK_ESCALATION = TABLE)
ALTER TABLE dbo.Tmp_tblInvStoreSub ADD CONSTRAINT
	DF_tblInvStoreSub_invPriceTotal DEFAULT ((0)) FOR invPriceTotal
ALTER TABLE dbo.Tmp_tblInvStoreSub ADD CONSTRAINT
	DF_tblInvStoreSub_invSalePrice DEFAULT ((0)) FOR invSalePrice
ALTER TABLE dbo.Tmp_tblInvStoreSub ADD CONSTRAINT
	DF_tblInvStoreSub_invSalePriceTotal DEFAULT ((0)) FOR invSalePriceTotal
SET IDENTITY_INSERT dbo.Tmp_tblInvStoreSub ON
IF EXISTS(SELECT * FROM dbo.tblInvStoreSub)
	 EXEC('INSERT INTO dbo.Tmp_tblInvStoreSub (id, invMainId, invPrdId, invPrdMsurId, invPrdGrpId, invQuanStr, invQuanAvl, invQuanDefr, invPriceAvrg, invPriceDefr, invPriceTotal, invSalePrice, invSalePriceTotal)
		SELECT id, invMainId, invPrdId, invPrdMsurId, invPrdGrpId, invQuanStr, invQuanAvl, invQuanDefr, invPriceAvrg, invPriceDefr, invPriceTotal, invSalePrice, invSalePriceTotal FROM dbo.tblInvStoreSub WITH (HOLDLOCK TABLOCKX)')
SET IDENTITY_INSERT dbo.Tmp_tblInvStoreSub OFF
DROP TABLE dbo.tblInvStoreSub
EXECUTE sp_rename N'dbo.Tmp_tblInvStoreSub', N'tblInvStoreSub', 'OBJECT' 
ALTER TABLE dbo.tblInvStoreSub ADD CONSTRAINT
	PK_tblInvStore PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

COMMIT
select Has_Perms_By_Name(N'dbo.tblInvStoreSub', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.tblInvStoreSub', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.tblInvStoreSub', 'Object', 'CONTROL') as Contr_Per 