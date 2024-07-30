SELECT TOP 1 r.RecipeID 
FROM recipe r JOIN RecipeIngredient ri 
ON r.RecipeID = ri.RecipeID 
JOIN Directions d 
ON r.RecipeID = d.RecipeID 
JOIN CourseMealRecipe cmr 
ON r.RecipeID = cmr.RecipeID 
JOIN CookbookRecipe cbr 
ON r.RecipeID = cbr.RecipeID
where r.Status = 'drafted' 
or DATEDIFF(day, r.ArchivedDate, GETDATE())>30

select * from recipe where RecipeID=5