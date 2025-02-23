--AS What is this sproc for?
create or alter procedure dbo.RecipeNumGet (
    @RecipeNum int OUTPUT
)
as
begin 
    select @RecipeNum = count(*) 
    from Recipe r 
    return 0;
end 
go
/*
DECLARE @numofrecipes int

EXEC RecipeNumGet @recipenum= @numofrecipes output

SELECT @numofrecipes as RecipeCount
*/


