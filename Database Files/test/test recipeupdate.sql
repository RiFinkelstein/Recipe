
DECLARE @RETURN int,
        @CuisineID int,
        @UsersID int,
        @RecipeID int = 0, -- Initialize RecipeID to 0 for new insert
        @RecipeName varchar(50),
        @Calories int;

-- Get valid IDs for testing
SELECT TOP 1 @CuisineID = CuisineID FROM Cuisine;
SELECT TOP 1 @UsersID = UsersID FROM Users;

-- Insert a new recipe
EXEC dbo.recipeupdate
    @RecipeID = @RecipeID OUTPUT,
    @CuisineID = @CuisineID,
    @UsersID = @UsersID,
    @RecipeName = 'Test Recipe',
    @Calories = 500;

-- Check the inserted record
SELECT @RETURN AS ReturnCode, @RecipeID AS NewRecipeID;
SELECT * FROM recipe WHERE RecipeID = @RecipeID;

-- Update the inserted recipe
EXEC dbo.recipeupdate
    @RecipeID = @RecipeID OUTPUT,
    @CuisineID = @CuisineID,
    @UsersID = @UsersID,
    @RecipeName = 'Updated Recipe',
    @Calories = 600;

-- Check the updated record
SELECT @RETURN AS ReturnCode, @RecipeID AS UpdatedRecipeID;
SELECT * FROM recipe WHERE RecipeID = @RecipeID;

-- Clean up
--DELETE FROM recipe WHERE RecipeID = @RecipeID;