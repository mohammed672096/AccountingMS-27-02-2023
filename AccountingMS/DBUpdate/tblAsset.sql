/*
   Thursday, January 28, 202112:54:30 PM
   User: 
   Server: DESKTOP-3SCODCE\SQL
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
ALTER TABLE dbo.tblAsset
	DROP CONSTRAINT DF_tblAsset_asEntNo
GO
CREATE TABLE dbo.Tmp_tblAsset
	(
	id int NOT NULL IDENTITY (1, 1),
	asAccNo bigint NOT NULL,
	asAccName nvarchar(80) NOT NULL,
	asDate datetime NULL,
	asEntId int NOT NULL,
	asEntNo int NOT NULL,
	asDebit decimal(10, 2) NULL,
	asCredit decimal(10, 2) NULL,
	asDesc nvarchar(150) NULL,
	asStatus tinyint NULL,
	asView tinyint NULL,
	asUserId smallint NULL,
	asBrnId smallint NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_tblAsset SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_tblAsset ADD CONSTRAINT
	DF_tblAsset_asEntNo DEFAULT ((0)) FOR asEntNo
GO
SET IDENTITY_INSERT dbo.Tmp_tblAsset ON
GO
IF EXISTS(SELECT * FROM dbo.tblAsset)
	 EXEC('INSERT INTO dbo.Tmp_tblAsset (id, asAccNo, asAccName, asDate, asEntId, asEntNo, asDebit, asCredit, asDesc, asStatus, asView, asUserId, asBrnId)
		SELECT id, asAccNo, asAccName, CONVERT(datetime, asDate), asEntId, asEntNo, asDebit, asCredit, asDesc, asStatus, asView, asUserId, asBrnId FROM dbo.tblAsset WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_tblAsset OFF
GO
DROP TABLE dbo.tblAsset
GO
EXECUTE sp_rename N'dbo.Tmp_tblAsset', N'tblAsset', 'OBJECT' 
GO
ALTER TABLE dbo.tblAsset ADD CONSTRAINT
	PK_tblAsset PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
