--AS File has 1 after the name.
CREATE OR ALTER procedure dbo.CookbookRecipeGet (
    --@CookbookRecipeID INT = 0,
    @CookbookID INT = 0,
    @all BIT = 1,
    @message VARCHAR(500) = '' OUTPUT
)
AS
BEGIN

    DECLARE @return INT= 0
    SELECT
        @all = ISNULL(@all, 0),
        --@CookbookRecipeID = ISNULL(@CookbookRecipeID, 0),
        @CookbookID = ISNULL(@CookbookID, 0);

        SELECT r.RecipeName, cr.CookBookSequenceNumber, cr.CookbookRecipeID, r.RecipeID, cr.CookbookID
        FROM recipe r
        JOIN CookbookRecipe cr 
        ON r.RecipeID = cr.RecipeID
        WHERE cr.CookbookID = @CookbookID
        order by cr.CookBookSequenceNumber

    
    RETURN @return; 
END
GO