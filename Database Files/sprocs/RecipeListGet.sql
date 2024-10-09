create or alter procedure dbo.RecipeListGet
as
begin 
	select r.RecipeID, r.RecipeName, r.Status, CONCAT(u.usersFirstName,' ', u.UsersLastName) as [User], r.Calories, count(i.ingredientID) as [Num Ingredients]
	from recipe r
    join users u 
    on u.UsersID = r.UsersID
    join RecipeIngredient ri 
    on r.RecipeID= ri.RecipeID
    join ingredient i
    on i.ingredientID= ri.IngredientID
    GROUP by r.RecipeID, r.RecipeName, r.Status, u.usersFirstName, u.UsersLastName, r.Calories
	order by r.status DESC
end 
go

exec RecipeListGet