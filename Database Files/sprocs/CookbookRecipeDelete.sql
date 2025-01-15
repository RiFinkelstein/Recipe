CREATE or alter PROCEDURE dbo.cookbookrecipeDelete(
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
