create or alter procedure dbo.RecipeNumGet (
    @RecipeNum int OUTPUT
)
as
begin 
    select @recipenum = count(*) 
    from recipe r 
    return 0;
end 
go

DECLARE @numofrecipes int

EXEC RecipeNumGet @recipenum= @numofrecipes output

SELECT @numofrecipes as RecipeCount


