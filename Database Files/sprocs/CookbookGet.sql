create or alter procedure dbo.CookbookGet (
	@cookbookID int = 0,
	@All bit= 1
	)
as
begin 
	select c.CookbookID, c.CookbookName, c.UsersID, c.Price, cast(c.Active as int) as active, c.DateCreated
	from cookbook c
	where @cookbookID= c.CookbookID or @all= 1
	order by c.CookbookName
end 
go

exec dbo.CookbookGet 
exec dbo.CookbookGet  @cookbookID = 1