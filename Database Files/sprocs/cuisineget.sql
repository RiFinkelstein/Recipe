create or alter procedure dbo.Cuisineget (@cuisineid int = 0, @all bit= 0, @cuisinename varchar(35)='')
as
begin 
	select @cuisinename = nullif(@cuisinename, '')
    SELECT c.cuisineid, c.cuisinename 
    from cuisine c
	where c.cuisineid= cuisineid
	or @all= 1
	or c.cuisinename like '%'+ @cuisinename + '%'
	order by c.cuisinename
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

