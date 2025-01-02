CREATE OR ALTER PROCEDURE dbo.CookbookDelete(
    @CookbookID INT,
    @Message VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
    DECLARE @Return INT = 0;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Delete related entries in CookbookRecipe table
        DELETE CR
        FROM CookbookRecipe CR
        WHERE CR.CookbookID = @CookbookID;

        -- Delete the cookbook itself
        DELETE CB
        FROM CookBook CB
        WHERE CB.CookbookID = @CookbookID;

        SET @Message = 'Cookbook deleted successfully.';
        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        SET @Message = ERROR_MESSAGE();
        THROW;
    END CATCH

    RETURN @Return;
END;
GO