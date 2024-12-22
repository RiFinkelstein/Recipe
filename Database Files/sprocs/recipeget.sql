create or alter procedure dbo.RecipeGet (
	@RecipeId int = 0, 
	@All bit= 0, 
	@RecipeName varchar(50)=null)
as
begin 
	select @RecipeName = nullif(@RecipeName, '')
	select r.usersid, r.CuisineID, r.recipeid, r.recipename, r.calories, r.DraftedDate, r.PublishedDate, r.archiveddate, r.picture, r.RecipeStatus 	

	from recipe r
	where (@recipeid <>0 and r.recipeid= @recipeid)
	or (@All= 1)
	or (r.recipename is not null and r.RecipeName like '%'+ @recipename +'%')
	order by r.recipename
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


