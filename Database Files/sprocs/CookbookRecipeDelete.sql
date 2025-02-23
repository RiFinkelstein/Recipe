<<<<<<< HEAD
--AS Sproc name should be proper cased
CREATE or alter PROCEDURE dbo.cookbookrecipeDelete(
=======
CREATE or alter PROCEDURE dbo.CookbookRecipeDelete(
>>>>>>> ce296b26ad62d933db5305df0d18be524562a86d
    @CookbookRecipeID int =0, 
    @Message varchar(500) = ''  output
)

as 
begin 
        DECLARE @return INT = 0;
        
        select @CookbookRecipeID = isnull(@CookbookRecipeID,0)

        delete CookbookRecipe where CookbookRecipeID = @CookbookRecipeID
        
        RETURN @return;
end
go
