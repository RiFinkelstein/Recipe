create or alter procedure dbo.CookbookGet (
	@CookbookID int = 0,
	@All bit= 0
	)
as
begin 
--AS Why is the case necessary?
	select c.CookbookID, c.CookbookName, c.UsersID, c.Price, c.Active, c.DateCreated
	from cookbook c
	where @CookbookID= c.CookbookID or @all= 1
	order by c.CookbookName
end 
go

--exec dbo.CookbookGet @all= 1
--exec dbo.CookbookGet  @cookbookID = 1