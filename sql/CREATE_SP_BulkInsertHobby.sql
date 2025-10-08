CREATE PROCEDURE dbo.BulkInsertHobbies
    @Data dbo.StringListType READONLY
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.tblM_hobby (Name)
    SELECT
        d.Name
    FROM
        @Data d
    WHERE
        d.Name NOT IN (SELECT Name FROM dbo.tblM_hobby)
END
GO