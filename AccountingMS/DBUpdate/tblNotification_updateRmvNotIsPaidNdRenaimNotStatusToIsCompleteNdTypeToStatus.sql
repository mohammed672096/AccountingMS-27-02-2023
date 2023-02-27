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

ALTER TABLE dbo.tblNotification
	DROP CONSTRAINT DF_tblNotification_notIsPaid
CREATE TABLE dbo.Tmp_tblNotification
	(
	id int NOT NULL IDENTITY (1, 1),
	notSupId int NOT NULL,
	notEntId int NULL,
	notNo int NULL,
	notName nvarchar(100) NULL,
	notDesc nvarchar(100) NULL,
	notAmount decimal(13, 3) NULL,
	notAmountPaid decimal(13, 3) NULL,
	notDate date NOT NULL,
	notUsrId smallint NOT NULL,
	notBrnId smallint NOT NULL,
	notIsComplete bit NOT NULL,
	notStatus tinyint NOT NULL
	)  ON [PRIMARY]
ALTER TABLE dbo.Tmp_tblNotification SET (LOCK_ESCALATION = TABLE)
SET IDENTITY_INSERT dbo.Tmp_tblNotification ON
IF EXISTS(SELECT * FROM dbo.tblNotification)
	 EXEC('INSERT INTO dbo.Tmp_tblNotification (id, notSupId, notEntId, notNo, notName, notDesc, notAmount, notAmountPaid, notDate, notUsrId, notBrnId, notIsComplete, notStatus)
		SELECT id, notSupId, notEntId, notNo, notName, notDesc, notAmount, notAmountPaid, notDate, notUsrId, notBrnId, notStatus, notType FROM dbo.tblNotification WITH (HOLDLOCK TABLOCKX)')
SET IDENTITY_INSERT dbo.Tmp_tblNotification OFF
DROP TABLE dbo.tblNotification
EXECUTE sp_rename N'dbo.Tmp_tblNotification', N'tblNotification', 'OBJECT' 
ALTER TABLE dbo.tblNotification ADD CONSTRAINT
	PK_tblNotification PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

COMMIT
select Has_Perms_By_Name(N'dbo.tblNotification', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.tblNotification', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.tblNotification', 'Object', 'CONTROL') as Contr_Per 