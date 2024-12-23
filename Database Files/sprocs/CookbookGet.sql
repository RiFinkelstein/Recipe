create or alter procedure dbo.CookbookGet (
	@cookbookID int = 0, 
	@All bit= 0)
as
begin 
	select c.CookbookID, c.CookbookName, c.UsersID, c.Price, c.Active, c.DateCreated
	from cookbook c
    where @All= 1
	order by c.CookbookName
end 
go
