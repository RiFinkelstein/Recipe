CREATE OR ALTER PROCEDURE RecipeClone
    @OriginalRecipeID INT
AS
BEGIN
    --SET NOCOUNT ON;

    DECLARE @ClonedRecipeID INT;

    -- Clone the recipe
    INSERT INTO Recipe (UsersID, CuisineID, RecipeName, Calories, DraftedDate, PublishedDate, ArchivedDate)
    SELECT
        UsersID,
        CuisineID,
        RecipeName + ' - clone', -- Append " - clone" to the name
        Calories,
        GETDATE(),
        null, 
        null -- Use the current date for the drafted date
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

END

