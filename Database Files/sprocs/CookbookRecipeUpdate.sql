<<<<<<< HEAD
--AS Sproc name should be proper cased
CREATE or alter PROCEDURE dbo.cookbookrecipeupdate(
=======
CREATE or alter PROCEDURE dbo.CookbookRecipeUpdate(
>>>>>>> ce296b26ad62d933db5305df0d18be524562a86d
    @CookbookRecipeID int output, 
    @CookbookID int, 
    @RecipeID int,
    @CookBookSequenceNumber int,
    @Message varchar(500) = ''  output
)

as 
begin 
        DECLARE @return INT = 0;
        select @cookbookrecipeID = isnull(@cookbookrecipeID,0)

            if @cookbookrecipeID = 0
            begin
                insert CookbookRecipe(cookbookID, RecipeID, CookBookSequenceNumber)
                values(@cookbookID, @recipeid, @CookBookSequenceNumber)

                select @cookbookrecipeID= scope_identity()
            end
            else
            begin
                update CookbookRecipe
                set
                    CookbookID = @CookbookID, 
                    RecipeID = @RecipeID,
                    CookBookSequenceNumber= @CookBookSequenceNumber
                where CookbookRecipeID = @CookbookRecipeID
            end
        RETURN @return;
end
go
