CREATE PROCEDURE dbo.BulkInsertPersonalData
    @Entities dbo.PersonalTableType READONLY
AS
BEGIN
    -- This insert is performed *atomically* within the SP
    -- It uses a single database operation (the SP call)
    INSERT INTO dbo.tblT_personal (Name, GenderId, HobbyId, Age)
    SELECT
        Name,
        GenderId,
        HobbyId,
		Age
    FROM
        @Entities;

    SELECT @@ROWCOUNT AS RowsAffected;
END
GO