use HeartyHealthDB 
go
--SELECT CONCAT('GRANT EXECUTE ON ', ROUTINE_NAME, ' TO approle;')
--FROM INFORMATION_SCHEMA.ROUTINES
--WHERE ROUTINE_TYPE = 'PROCEDURE';



GRANT EXECUTE ON CookbookAutoCreate TO approle;
GRANT EXECUTE ON CookbookDelete TO approle;
GRANT EXECUTE ON CookbookGet TO approle;
GRANT EXECUTE ON CookbookNumGet TO approle;
GRANT EXECUTE ON cookbookrecipeDelete TO approle;
GRANT EXECUTE ON CookbookRecipeGet TO approle;
GRANT EXECUTE ON cookbookrecipeupdate TO approle;
GRANT EXECUTE ON CookbookUpdate TO approle;
GRANT EXECUTE ON CourseDelete TO approle;
GRANT EXECUTE ON CourseGet TO approle;
GRANT EXECUTE ON CourseUpdate TO approle;
GRANT EXECUTE ON CuisineDelete TO approle;
GRANT EXECUTE ON CuisineGet TO approle;
GRANT EXECUTE ON CuisineUpdate TO approle;
GRANT EXECUTE ON IngredientDelete TO approle;
GRANT EXECUTE ON IngredientGet TO approle;
GRANT EXECUTE ON IngredientUpdate TO approle;
GRANT EXECUTE ON MealListGet TO approle;
GRANT EXECUTE ON MealNumGet TO approle;
GRANT EXECUTE ON MeasurementDelete TO approle;
GRANT EXECUTE ON MeasurementUpdate TO approle;
GRANT EXECUTE ON MeasurementGet TO approle;
GRANT EXECUTE ON RecipeClone TO approle;
GRANT EXECUTE ON RecipeDelete TO approle;
GRANT EXECUTE ON RecipeDirectionsDelete TO approle;
GRANT EXECUTE ON RecipeDirectionsGet TO approle;
GRANT EXECUTE ON DirectionsUpdate TO approle;
GRANT EXECUTE ON RecipeGet TO approle;
GRANT EXECUTE ON recipegetall TO approle;
GRANT EXECUTE ON RecipeIngredientDelete TO approle;
GRANT EXECUTE ON RecipeIngredientGet TO approle;
GRANT EXECUTE ON RecipeIngredientUpdate TO approle;
GRANT EXECUTE ON RecipeListGet TO approle;
GRANT EXECUTE ON RecipeNumGet TO approle;
GRANT EXECUTE ON Recipeupdate TO approle;
GRANT EXECUTE ON UsersDelete TO approle;
GRANT EXECUTE ON UsersGet TO approle;
GRANT EXECUTE ON DashboardGet TO approle;
GRANT EXECUTE ON UsersUpdate TO approle;