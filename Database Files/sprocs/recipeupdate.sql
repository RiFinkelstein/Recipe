CREATE OR ALTER PROC dbo.Recipeupdate(
    @RecipeID int OUTPUT,
    @CuisineID int,
    @UsersID int,
    @RecipeName varchar(50),
    @Calories int, 
    @DraftedDate DATETIME)
AS
BEGIN
    DECLARE @return int = 0;

    IF @RecipeID = 0
    BEGIN
        INSERT INTO recipe (CuisineID, UsersID, RecipeName,DraftedDate, Calories)
        VALUES (@CuisineID, @UsersID, @RecipeName,@drafteddate, @Calories);
        SELECT @RecipeID = SCOPE_IDENTITY();
    END
    ELSE
    BEGIN
        UPDATE recipe
        SET
            CuisineID = @CuisineID,
            UsersID = @UsersID,
            RecipeName = @RecipeName,
            DraftedDate= @drafteddate,
            Calories = @Calories
        WHERE RecipeID = @RecipeID;
    END

    RETURN @return;
END
GO
