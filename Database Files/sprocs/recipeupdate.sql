CREATE OR ALTER PROC dbo.Recipeupdate(
    @RecipeID int OUTPUT,
    @CuisineID int,
    @UsersID int,
    @RecipeName varchar(50),
    @Calories int, 
    @DraftedDate DATE, 
    @publisheddate date= null, 
    @archiveddate date= null)
AS
BEGIN
    DECLARE @return int = 0;

    IF @RecipeID IS NULL or @RecipeID=0

    BEGIN
        INSERT INTO recipe (CuisineID, UsersID, RecipeName,DraftedDate, PublishedDate, ArchivedDate, Calories)
        VALUES (@CuisineID, @UsersID, @RecipeName,isnull(@drafteddate, GETDATE()), @publisheddate, @archiveddate, @Calories);
        SELECT @RecipeID = SCOPE_IDENTITY();
    END
    ELSE
    BEGIN
        UPDATE recipe
        SET
            CuisineID = @CuisineID,
            UsersID = @UsersID,
            RecipeName = @RecipeName,
            DraftedDate= isnull(@drafteddate, DraftedDate),
            Calories = @Calories
        WHERE RecipeID = @RecipeID;
    END

    RETURN @return;
END
GO
