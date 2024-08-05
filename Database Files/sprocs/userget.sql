create or alter procedure dbo.UserGet (@UsersId int = 0, @All bit= 0, @LastName varchar(35)='')
as
begin 
	select @LastName = nullif(@LastName, '')
    select u.usersid, u.UsersFirstName, u.userslastname, u.usersname 
    from users u
	where u.usersid= @usersid
	or @All= 1
	or u.userslastname like '%'+ @lastname + '%'
	order by u.usersname
end 
go

/*
--unit testing:
exec userget @lastname = '' --return no results
exec userget @lastname = 'a'
exec userget
EXEC userget @all= 1

declare @id int 
SELECT top 1 @id= u.usersid from users u
exec userget @usersid = @id
*/
