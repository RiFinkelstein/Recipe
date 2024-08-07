create or alter FUNCTION dbo.NumCaloriesPerMeal(@mealid int)
returns int
as 
begin 
	declare @value int
SELECT  @value= sum(r.calories)
from meal m 
join CourseMeal cm 
on cm.MealID = m.MealID
join CourseMealRecipe cmr
on cmr.CourseMealID= cm.CourseMealID
JOIN recipe R
on r.RecipeID= cmr.RecipeID
where m.MealID= @mealid
GROUP by m.MealID, m.MealName   
RETURN @value
end 
go

SELECT dbo.NumCaloriesPerMeal(m.MealID)
from Meal m

