create or alter procedure dbo.IngredientGet(
	@IngredientID int = 0,
	@All bit = 0,
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0

	select @All = isnull(@All,0), @IngredientID = isnull(@IngredientID,0)

        SELECT *
        from ingredient i 
        where ingredientID= @IngredientID
        or @all=1


	return @return
end
go

EXEC IngredientGet