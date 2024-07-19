create or alter procedure dbo.userget (@usersid int = 0, @all bit= 0, @lastname varchar(35)='')
as
begin 
	select @lastname = nullif(@lastname, '')
    select u.usersid, u.UsersFirstName, u.userslastname, u.username 
    from users u
	where u.usersid= @usersid
	or @all= 1
	or u.userslastname like '%'+ @lastname + '%'
	order by u.username
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
