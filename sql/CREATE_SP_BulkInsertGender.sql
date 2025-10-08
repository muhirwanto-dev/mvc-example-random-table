CREATE PROCEDURE dbo.BulkInsertGenders
    @Data dbo.StringListType READONLY
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.tblM_gender (Name)
    SELECT
        d.Name
    FROM
        @Data d
    WHERE
        d.Name NOT IN (SELECT Name FROM dbo.tblM_gender)
END
GO