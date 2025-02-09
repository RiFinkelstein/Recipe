CREATE OR ALTER PROCEDURE dbo.IngredientsDelete(
    @IngredientID INT,
    @Message VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
    DECLARE @Return INT = 0
   
    BEGIN TRY
        BEGIN TRAN
       
        -- Delete related records first
        DELETE FROM RecipeIngredient WHERE IngredientID = @IngredientID
       
        -- Delete the ingredient
        DELETE FROM Ingredient WHERE IngredientID = @IngredientID
       
        COMMIT
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH
   
    RETURN @Return
END;

