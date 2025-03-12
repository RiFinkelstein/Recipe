create or alter procedure dbo.RecipeGet (
	@RecipeID int = 0, 
	@All bit= 0, 
	@RecipeName varchar(50)=null)
as
begin 
	select @RecipeName = nullif(@RecipeName, '')
	select r.UsersID, r.CuisineID, r.RecipeID, r.RecipeName, r.Calories, r.DraftedDate, r.PublishedDate, r.ArchivedDate, r.Picture, r.RecipeStatus

	from recipe r
	where (@RecipeID <>0 and r.recipeID= @recipeID)
	or @All= 1
	or (r.RecipeName is not null and r.RecipeName like '%'+ @RecipeName +'%')
	order by r.RecipeName
end 
go

/*
unit testing:
exec recipeget @recipename = '' --return no results
exec recipeget @recipename = 'a'
exec recipeget
EXEC recipeget @all= 1

declare @id int 
SELECT top 1 @id = r.recipeid from recipe r 
exec recipeget @recipeid = @id
*/


