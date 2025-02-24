create or alter procedure dbo.DashboardGet (
    @CookbookNum int OUTPUT,
    @RecipeNum int OUTPUT,
    @MealNum int OUTPUT

)
as
begin 
SELECT
    @CookbookNum = (select count(*) from  cookbook),
    @RecipeNum = (select count(*) from Recipe), 
    @MealNum = (select count(*) from Meal) 
end 
go