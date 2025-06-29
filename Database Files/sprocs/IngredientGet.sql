create or alter procedure dbo.IngredientGet(
	@IngredientName VARCHAR(50)= null,
	@IngredientID int = 0,
	@All bit = 0,
	@Message varchar(500) = ''  output,
	@includeBlank bit= 0 
)
as
begin
	declare @Return int = 0
	select @IngredientName = nullif(@IngredientName, ''),   @includeBlank = isnull(@includeblank, '')

	select @All = isnull(@All,0), @IngredientID = isnull(@IngredientID,0)

        SELECT i.IngredientID, i.IngredientName
        from ingredient i 
        where IngredientID= @IngredientID
        or @all=1
		or (i.ingredientName is not null and i.ingredientName like '%'+ @IngredientName +'%')

		UNION SELECT 0, ''
		where @includeBlank=1


	return @return
end
go

--unit test:
/* 
exec IngredientGet @IngredientName = '' --return no results
exec IngredientGet @IngredientName = 'a'

exec IngredientGet
exec IngredientGet @all=1, @includeblank= 1

declare @id int
select top 1 @id = i.IngredientID from ingredient i 

exec IngredientGet  @ingredientID =@id

*/