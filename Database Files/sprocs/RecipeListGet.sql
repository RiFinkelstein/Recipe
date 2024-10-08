create or alter procedure dbo.RecipeListGet (
    @RecipeId int = 0, @All bit= 0, @RecipeName varchar(50)='')
as
begin 
	select @RecipeName = nullif(@RecipeName, '')
	select r.RecipeID, r.RecipeName, r.Status, CONCAT(u.usersFirstName,' ', u.UsersLastName) as [User], r.Calories, count(i.ingredientID) as [Num Ingredients]
	from recipe r
    join users u 
    on u.UsersID = r.UsersID
    join RecipeIngredient ri 
    on r.RecipeID= ri.RecipeID
    join ingredient i
    on i.ingredientID= ri.IngredientID
	where (@recipeid=0 or r.recipeid= @recipeid)
	or @All= 1
	or (r.recipename like '%'+ @RecipeName + '%' or @recipename is null)
    GROUP by r.RecipeID, r.RecipeName, r.Status, u.usersFirstName, u.UsersLastName, r.Calories
	order by r.status DESC
end 
go

exec RecipeListGet