create or alter procedure dbo.MealListGet 
as
begin 
    SELECT  m.MealName, CONCAT(u.usersFirstName,' ', u.UsersLastName) as [User], Sum(r.Calories) as [Num of Calories], count(distinct CM.CourseID) as [Num of Courses],  count(distinct r.recipeID) as [Num of recipes]
    from Meal m 
    join Users u 
    on u.UsersID = m.UsersID
    join CourseMeal CM 
    on CM.MealID = m.MealID
    join CourseMealRecipe CMR 
    on CM.CourseMealID= CMR.CourseMealID
    join Recipe R 
    on r.RecipeID = CMR.RecipeID
    --WHERE m.active = 1 
    group by m.MealName, u.UsersLastName, u.usersFirstName
    order by m.MealName
end 
go

exec MealListGet






