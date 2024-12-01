create or alter procedure dbo.RecipeIngredientDelete(
	@RecipeIngredientID int = 0,
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0

	select @RecipeIngredientID = isnull(@RecipeIngredientID,0)

	delete RecipeIngredient where RecipeIngredientID = @RecipeIngredientID

	return @return
end
go
