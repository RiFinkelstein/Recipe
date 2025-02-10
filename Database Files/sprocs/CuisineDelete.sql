CREATE OR ALTER PROCEDURE dbo.CuisineDelete(
    @CuisineID INT,
    @Message VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
    DECLARE @Return INT = 0
   
    BEGIN TRY
        BEGIN TRAN
        -- Delete related RECORDS first

        DELETE FROM CookbookRecipe WHERE RecipeID IN (SELECT RecipeID FROM Recipe WHERE CuisineID = @CuisineID)

        DELETE FROM RecipeIngredient WHERE RecipeID IN (SELECT RecipeID FROM Recipe WHERE CuisineID = @CuisineID)
        DELETE FROM Directions WHERE RecipeID IN (SELECT RecipeID FROM Recipe WHERE CuisineID = @CuisineID)
        

        DELETE FROM CourseMealRecipe WHERE RecipeID IN (SELECT RecipeID FROM Recipe WHERE CuisineID = @CuisineID)

        DELETE FROM Recipe WHERE CuisineID = @CuisineID
       
        -- Delete the cuisine
        DELETE FROM Cuisine WHERE CuisineID = @CuisineID
       
        COMMIT
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH
   
    RETURN @Return
END;
GO