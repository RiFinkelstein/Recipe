CREATE OR ALTER PROC dbo.RecipeUpdate(
    @RecipeID int OUTPUT,
    @CuisineID int,
    @UsersID int,
    @RecipeName varchar(50),
    @Calories int, 
    @DraftedDate DATE OUTPUT, 
    @Publisheddate date= null OUTPUT, 
    @Archiveddate date= null OUTPUT)
AS
BEGIN
    DECLARE @Return int = 0;

    IF @RecipeID=0

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

    SELECT 
        @DraftedDate = r.DraftedDate,
        @Publisheddate= r.PublishedDate, 
        @Archiveddate= r.ArchivedDate 
        from recipe r 
        where r.RecipeID= @RecipeID

    RETURN @Return;
END
GO
