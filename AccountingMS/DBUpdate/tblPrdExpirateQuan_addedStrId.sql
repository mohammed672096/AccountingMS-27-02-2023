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

CREATE TABLE dbo.Tmp_tblPrdExpirateQuan
	(
	expId int NOT NULL IDENTITY (1, 1),
	expStrid smallint NOT NULL,
	expPrdId int NOT NULL,
	expPrdMsurId int NOT NULL,
	expPrdMsurStatus tinyint NOT NULL,
	expPrdPriceQuanId int NOT NULL,
	expPrdPrice decimal(10, 3) NOT NULL,
	expQuan float(53) NOT NULL,
	expPrdDate date NOT NULL,
	expDate date NOT NULL,
	expBrnId smallint NOT NULL,
	expStatus tinyint NOT NULL
	)  ON [PRIMARY]
ALTER TABLE dbo.Tmp_tblPrdExpirateQuan SET (LOCK_ESCALATION = TABLE)
ALTER TABLE dbo.Tmp_tblPrdExpirateQuan ADD CONSTRAINT
	DF_tblPrdExpirateQuan_expStrid DEFAULT 1 FOR expStrid
SET IDENTITY_INSERT dbo.Tmp_tblPrdExpirateQuan ON
IF EXISTS(SELECT * FROM dbo.tblPrdExpirateQuan)
	 EXEC('INSERT INTO dbo.Tmp_tblPrdExpirateQuan (expId, expPrdId, expPrdMsurId, expPrdMsurStatus, expPrdPriceQuanId, expPrdPrice, expQuan, expPrdDate, expDate, expBrnId, expStatus)
		SELECT expId, expPrdId, expPrdMsurId, expPrdMsurStatus, expPrdPriceQuanId, expPrdPrice, expQuan, expPrdDate, expDate, expBrnId, expStatus FROM dbo.tblPrdExpirateQuan WITH (HOLDLOCK TABLOCKX)')
SET IDENTITY_INSERT dbo.Tmp_tblPrdExpirateQuan OFF
DROP TABLE dbo.tblPrdExpirateQuan
EXECUTE sp_rename N'dbo.Tmp_tblPrdExpirateQuan', N'tblPrdExpirateQuan', 'OBJECT' 
ALTER TABLE dbo.tblPrdExpirateQuan ADD CONSTRAINT
	PK_tblExpirateQuan PRIMARY KEY CLUSTERED 
	(
	expId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

COMMIT
select Has_Perms_By_Name(N'dbo.tblPrdExpirateQuan', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.tblPrdExpirateQuan', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.tblPrdExpirateQuan', 'Object', 'CONTROL') as Contr_Per 