script to create login and user is excluded from this repo
create a file called create-login.sql (this file is ignored by git ignore in this repo)
add the following script to that file


--IMPORTANT create login in MASTER
--use master
CREATE LOGIN [loginname] with PASSWORD = '[password]'

--IMPORTANT switch to HeartyHealthDB
CREATE USER [username] from LOGIN [login name]