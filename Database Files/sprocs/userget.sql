create or alter procedure dbo.UserGet (
	@UsersID int = 0, 
	@All bit= 0, 
	@LastName varchar(35)='')
as
begin 
	select @LastName = nullif(@LastName, '')
    select u.UsersID, u.UsersFirstName, u.userslastname, u.usersname 
    from Users u
	where u.UsersID= @UsersID
	or @All= 1
	or u.UsersLastName like '%'+ @LastName + '%'
	order by u.UsersName
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
