CREATE PROCEDURE dbo.TruncateAllTables
AS
BEGIN
    TRUNCATE TABLE dbo.tblM_gender;
	TRUNCATE TABLE dbo.tblM_hobby;
	TRUNCATE TABLE dbo.tblT_personal;
END
GO