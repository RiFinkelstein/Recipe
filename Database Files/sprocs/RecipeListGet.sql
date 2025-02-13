create or alter procedure dbo.RecipeListGet
as
begin 
	select r.RecipeID, r.RecipeName, r.RecipeStatus, CONCAT(u.UsersFirstName,' ', u.UsersLastName) as [User], r.Calories, count(i.IngredientID) as [Num Ingredients]
	from Recipe r
    join Users u 
    on u.UsersID = r.UsersID
    left join RecipeIngredient ri 
    on r.RecipeID= ri.RecipeID
    left join Ingredient i
    on i.IngredientID= ri.IngredientID
    GROUP by r.RecipeID, r.RecipeName, r.RecipeStatus, u.UsersFirstName, u.UsersLastName, r.Calories
	order by r.RecipeStatus DESC, r.RecipeName
end 
go

--exec RecipeListGet