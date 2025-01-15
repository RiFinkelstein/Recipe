CREATE or ALTER PROCEDURE dbo.recipegetall (
    @RecipeID int = 0,
	@All bit = 0,
	@Message varchar(500) = ''  output
)
as
begin 

	declare @return int = 0

	select @All = isnull(@All,0), @recipeid = isnull(@recipeid,0)

    SELECT r.RecipeName, r.RecipeID
    from recipe r
    where RecipeID= @recipeid
    or @all= 1

    RETURN @return
end 
go

exec recipegetall @all=1