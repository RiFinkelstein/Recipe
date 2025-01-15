create or alter procedure dbo.CuisineGet (
	@CuisineID int = 0, 
	@All bit= 0, 
	@CuisineName varchar(35)='')
as
begin 
	select @CuisineName = nullif(@CuisineName, '')
    SELECT c.CuisineID, c.CuisineName 
    from cuisine c
	where c.CuisineID= @CuisineID
	or @All= 1
	or c.CuisineName like '%'+ @CuisineName + '%'
	order by c.CuisineName
end 
go

/*
unit testing:
exec Cuisineget @cuisinename = '' --return no results
exec Cuisineget @cuisinename = 'a'
exec Cuisineget
EXEC Cuisineget @all= 1

declare @id int 
SELECT top 1 @id = c.cuisineid from cuisine c 
exec Cuisineget @cuisineid = @id
*/

