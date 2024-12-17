CREATE OR ALTER PROC dbo.Recipepdate(
    @RecipeID int OUTPUT,
    @CuisineID int,
    @UsersID int,
    @RecipeName varchar(50),
    @Calories int, 
    @DraftedDate DATETIME2)
AS
BEGIN
    DECLARE @return int = 0;

    IF @RecipeID = 0
    BEGIN
        INSERT INTO recipe (CuisineID, UsersID, RecipeName, Calories, DraftedDate)
        VALUES (@CuisineID, @UsersID, @RecipeName, @Calories, @drafteddate);
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
