/*
   Tuesday, May 26, 20208:13:40 AM
   User: sa
   Server: .\SQLEXPRESS
   Database: accounting
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/


ALTER TABLE dbo.tblProduct ADD
	MaxLevel float(53) NOT NULL CONSTRAINT DF_tblProduct_MaxLevel  DEFAULT 0
