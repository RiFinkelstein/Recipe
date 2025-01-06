CREATE or alter PROCEDURE dbo.cookbookrecipeupdate(
    @cookbookrecipeID int output, 
    @cookbookID int, 
    @recipeid VARCHAR (100),
    @Message varchar(500) = ''  output
)

as 
begin 
        DECLARE @return INT = 0;
        select @cookbookrecipeID = isnull(@cookbookrecipeID,0)

            if @cookbookrecipeID = 0
            begin
                insert CookbookRecipe(cookbookID, RecipeID)
                values(@cookbookID, @recipeid)

                select @cookbookrecipeID= scope_identity()
            end
            else
            begin
                update CookbookRecipe
                set
                    cookbookID = @cookbookID, 
                    RecipeID = @recipeid
                where CookbookRecipeID = @cookbookrecipeID
            end
        RETURN @return;
end
go
