create or alter procedure dbo.recipeget (@recipeid int = 0, @all bit= 0, @Recipename varchar(50)='')
as
begin 
	select @Recipename = nullif(@Recipename, '')
	select r.usersid, r.CuisineID, r.recipeid, r.recipename, r.calories, r.DraftedDate, r.PublishedDate, r.archiveddate, r.picture, r.STATUS
	from recipe r
	where r.recipeid= @recipeid
	or @all= 1
	or r.recipename like '%'+ @Recipename + '%'
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


