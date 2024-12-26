create or alter procedure dbo.CookbookGet (
	@cookbookID int = 0, 
	@All bit= 0)
as
begin 
	select c.CookbookID, c.CookbookName, c.UsersID, c.Price, cast(c.Active as int) as active, c.DateCreated
	from cookbook c
	order by c.CookbookName
end 
go

exec dbo.CookbookGet 
