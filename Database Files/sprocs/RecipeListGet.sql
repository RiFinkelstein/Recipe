create or alter procedure dbo.RecipeListGet
as
begin 
	select r.RecipeID, r.RecipeName, r.RecipeStatus, CONCAT(u.usersFirstName,' ', u.UsersLastName) as [User], r.Calories, count(i.ingredientID) as [Num Ingredients]
	from recipe r
    join users u 
    on u.UsersID = r.UsersID
    left join RecipeIngredient ri 
    on r.RecipeID= ri.RecipeID
    left join ingredient i
    on i.ingredientID= ri.IngredientID
    GROUP by r.RecipeID, r.RecipeName, r.RecipeStatus, u.usersFirstName, u.UsersLastName, r.Calories
	order by r.RecipeStatus DESC
end 
go

exec RecipeListGet