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
    join RecipeIngredient RI
    on RI.RecipeID = r.RecipeID
    join Directions d 
    on d.RecipeID= r.RecipeID
    where r.RecipeID= @recipeid
    GROUP by r.RecipeID, r.RecipeName, c.CuisineName

RETURN @value
end 
go

SELECT dbo.RecipeInfo(r.recipeid), r.*
from recipe r 
