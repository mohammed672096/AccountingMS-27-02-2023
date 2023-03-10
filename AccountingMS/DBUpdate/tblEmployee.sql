/*
   Saturday, January 16, 20215:08:48 PM
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
ALTER TABLE dbo.tblEmployee ADD
	expirationInsurance date NULL,
	expirationResidence date NULL,
	reminderInsurance int NULL,
	reminderResidence int NULL
GO
DECLARE @v sql_variant 
SET @v = N'تاريخ انتهاء التامين'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tblEmployee', N'COLUMN', N'expirationInsurance'
GO
DECLARE @v sql_variant 
SET @v = N'تاريخ انتهاء الاقامة'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tblEmployee', N'COLUMN', N'expirationResidence'
GO
ALTER TABLE dbo.tblEmployee SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
