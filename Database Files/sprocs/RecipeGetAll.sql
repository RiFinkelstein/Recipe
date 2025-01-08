CREATE or ALTER PROCEDURE dbo.recipegetall
as
begin 
    SELECT r.RecipeName, r.RecipeID
    from recipe r
    order by r.RecipeName
end 
go

exec recipegetall