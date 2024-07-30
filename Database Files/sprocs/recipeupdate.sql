CREATE OR ALTER PROC dbo.recipeupdate(
    @RecipeID int OUTPUT,
    @CuisineID int,
    @UsersID int,
    @RecipeName varchar(50),
    @Calories int)
AS
BEGIN
    DECLARE @return int = 0;

    IF @RecipeID = 0
    BEGIN
        INSERT INTO recipe (CuisineID, UsersID, RecipeName, Calories)
        VALUES (@CuisineID, @UsersID, @RecipeName, @Calories);
        SELECT @RecipeID = SCOPE_IDENTITY();
    END
    ELSE
    BEGIN
        UPDATE recipe
        SET
            CuisineID = @CuisineID,
            UsersID = @UsersID,
            RecipeName = @RecipeName,
            Calories = @Calories
        WHERE RecipeID = @RecipeID;
    END

    RETURN @return;
END
GO
