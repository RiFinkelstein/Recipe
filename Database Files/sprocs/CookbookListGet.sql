create or alter procedure dbo.CookbookListGet 
as
begin 
    SELECT cb.CookbookName as [Cookbook Name], CONCAT(u.usersFirstName,' ', u.UsersLastName) as [Author], COUNT(CBR.recipeID) as [Num Recipes], cb.Price
    from CookBook CB 
    join Users u
    on u.UsersID= cb.UsersID
    join CookbookRecipe CBR 
    on CBR.cookbookID= cb.CookbookID
    where CB.Active = 1
    GROUP BY cb.cookbookname, u.UsersFirstName, u.UsersLastName, cb.Price
    order by cb.CookbookName
end 
go

exec CookbookListGet










