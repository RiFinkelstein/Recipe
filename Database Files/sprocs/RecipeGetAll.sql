--AS Why do you need this sproc in addition to RecipeGet?
CREATE or ALTER PROCEDURE dbo.recipegetall (
    @RecipeID int = 0,
	@All bit = 0,
	@Message varchar(500) = ''  output
)
as
begin 

	declare @Return int = 0

	select @All = isnull(@All,0), @RecipeID = isnull(@RecipeID,0)

    SELECT r.RecipeName, r.RecipeID
    from recipe r
    where RecipeID= @RecipeID
    or @all= 1

    RETURN @Return
end 
go

--exec recipegetall @all=1