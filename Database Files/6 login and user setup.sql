

--replace //loginname// and //password// with secret values from vault
--IMPORTANT create login in MASTER
--use master
CREATE LOGIN //loginname// with PASSWORD= '//password//'

--IMPORTAN switch to RecipeDB
CREATE USER dev_user from LOGIN //loginname//

ALTER role db_datareader add member dev_user
ALTER role db_datawriter add member dev_user