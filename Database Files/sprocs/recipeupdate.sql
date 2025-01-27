CREATE OR ALTER PROC dbo.Recipeupdate(
    @RecipeID int OUTPUT,
    @CuisineID int,
    @UsersID int,
    @RecipeName varchar(50),
    @Calories int, 
    @DraftedDate DATE, 
    @Publisheddate date= null, 
    @Archiveddate date= null)
AS
BEGIN
    DECLARE @Return int = 0;

    IF @RecipeID IS NULL or @RecipeID=0

    BEGIN
        INSERT INTO Recipe (CuisineID, UsersID, RecipeName, DraftedDate, PublishedDate, ArchivedDate, Calories)
        VALUES (@CuisineID, @UsersID, @RecipeName,isnull(@DraftedDate, GETDATE()), @PublishedDate, @ArchivedDate, @Calories);
        SELECT @RecipeID = SCOPE_IDENTITY();
    END
    
    ELSE
    BEGIN
        UPDATE recipe
        SET
            CuisineID = @CuisineID,
            UsersID = @UsersID,
            RecipeName = @RecipeName,
            DraftedDate = nullif(@DraftedDate, ''),
            PublishedDate = nullif(@PublishedDate, ''),
            ArchivedDate = nullif(@ArchivedDate, ''),
            Calories = @Calories
        WHERE RecipeID = @RecipeID;
    END

    RETURN @Return;
END
GO
