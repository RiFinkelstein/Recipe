CREATE OR ALTER procedure dbo.CookbookRecipeGet (
    @CookbookRecipeID INT = 0,
    @cookbookid INT = 0,
    @all BIT = 1,
    @message VARCHAR(500) = '' OUTPUT
)
AS
BEGIN

    DECLARE @return INT= 0
    SELECT
        @all = ISNULL(@all, 0),
        @CookbookRecipeID = ISNULL(@CookbookRecipeID, 0),
        @cookbookid = ISNULL(@cookbookid, 0);

        SELECT r.RecipeName, cr.CookBookSequenceNumber
        FROM recipe r
        JOIN CookbookRecipe cr 
        ON r.recipeID = cr.recipeID
        WHERE cr.cookbookID = @cookbookid
        order by cr.CookBookSequenceNumber

    
    RETURN @return; 
END
GO