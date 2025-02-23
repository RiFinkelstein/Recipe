CREATE OR ALTER PROCEDURE RecipeClone(
    @OriginalRecipeID INT,
    @ClonedRecipeID int OUTPUT,
    @Message VARCHAR(500) output)
AS
BEGIN

    DECLARE @Return INT = 0;
    begin try 
        BEGIN TRANSACTION;

    --initialize output message
    set @message = '';

        -- Check if the original recipe exists
    IF NOT EXISTS (SELECT 1 FROM Recipe WHERE RecipeID = @OriginalRecipeID)
    BEGIN
        SET @Message = 'Error: Original recipe not found.';
        ROLLBACK
        RETURN;
    END

    -- Check if this recipe has already been cloned
    IF EXISTS (
        SELECT 1
        FROM Recipe
        WHERE RecipeName LIKE (SELECT RecipeName FROM Recipe WHERE RecipeID = @OriginalRecipeID) + ' - clone'
    )
    BEGIN
        SET @Message = 'Error: This recipe has already been cloned and cannot be cloned again.';
        ROLLBACK;
        RETURN;
    END

    -- Clone the recipe
    INSERT Recipe (UsersID, CuisineID, RecipeName, Calories, DraftedDate, PublishedDate, ArchivedDate)
    SELECT
        UsersID,
        CuisineID,
        RecipeName + ' - clone', -- Append " - clone" to the name
        Calories,
        GETDATE(), -- Use the current date for the drafted date
        null, 
        null 
    FROM Recipe
    WHERE RecipeID = @OriginalRecipeID;

    SET @ClonedRecipeID = SCOPE_IDENTITY();

    -- Clone related recipe steps and ingredients
    INSERT INTO Directions (RecipeID, StepNumber, Direction)
    SELECT @ClonedRecipeID, D.StepNumber, D.Direction
    FROM Directions D 
    WHERE RecipeID = @OriginalRecipeID;

    INSERT INTO RecipeIngredient (RecipeID, IngredientID, MeasurementID, Amount, SequenceNumber)
    SELECT @ClonedRecipeID, Ri.IngredientID, Ri.MeasurementID, RI.Amount, RI.SequenceNumber
    FROM RecipeIngredient RI
    WHERE RecipeID = @OriginalRecipeID;

    -- Success message
        SET @Message = 'Recipe cloned successfully!';
        COMMIT;
    END TRY
    BEGIN CATCH
        -- Handle SQL errors
        ROLLBACK;
        SET @Message = 'Error cloning recipe: ' + ERROR_MESSAGE();
        SET @ClonedRecipeID = NULL;
        THROW;  -- Rethrow the error to be handled by C#

    END CATCH
    RETURN @Return
END
GO


