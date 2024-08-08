create or alter function dbo.RecipeInfo(@recipeid int)
returns varchar(500)
as 
begin 
	declare @value varchar(500)= ''
    SELECT @value= CONCAT(r.RecipeName, ' (', c.CuisineName , ')  has ',
      (SELECT count(*) from RecipeIngredient where recipeID= r.recipeID), ' ingredients and ', 
      (SELECT count(*) from directions where recipeID= r.recipeID),  ' steps') 
    from recipe r 
    join Cuisine c
    on c.CuisineID = r.CuisineID
    where r.RecipeID= @recipeid
RETURN @value
end 
go

SELECT dbo.RecipeInfo(r.recipeid), r.*
from recipe r 
