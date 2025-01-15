create or alter procedure dbo.IngredientGet(
	@IngredientID int = 0,
	@All bit = 0,
	@Message varchar(500) = ''  output
)
as
begin
	declare @Return int = 0

	select @All = isnull(@All,0), @IngredientID = isnull(@IngredientID,0)

        SELECT i.IngredientID, i.IngredientName
        from ingredient i 
        where IngredientID= @IngredientID
        or @all=1


	return @return
end
go

--EXEC IngredientGet