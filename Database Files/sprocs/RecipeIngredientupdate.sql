create or alter procedure dbo.RecipeIngredientupdate(
	@RecipeIngredientId int  output,
	@recipeId int ,
	@IngredientId int ,
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0

	select @RecipeIngredientId = isnull(@RecipeIngredientId,0)

	if @RecipeIngredientId = 0
	begin
		insert RecipeIngredient(recipeId, IngredientId)
		values(@recipeId, @IngredientId)

		select @RecipeIngredientId= scope_identity()
	end
	else
	begin
		update RecipeIngredient
		set
			recipeId = @recipeId, 
			IngredientId = @IngredientId
		where RecipeIngredientId = @RecipeIngredientId
	end

	return @return
end
go

