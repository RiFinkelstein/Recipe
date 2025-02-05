CREATE OR ALTER PROCEDURE dbo.CookbookAutoCreate(
    @UsersID INT,
    @CookbookID INT output)
AS
BEGIN
    Declare @CookbookName VARCHAR(100) NULL
    Declare @RecipeCount INT null
    Declare @Price DECIMAL(10,2) null   
    -- Get user full name
    SELECT @CookbookName = 'Recipes by ' + U.UsersFirstName + ' ' + U.UsersLastName
    FROM Users U
    WHERE UsersID = @UsersID;

    -- Count user's recipes
    SELECT @RecipeCount = COUNT(*)
    FROM Recipe
    WHERE UsersID = @UsersID;

    -- If no recipes, exit
    IF @RecipeCount = 0
    BEGIN
        PRINT 'User has no recipes to create a cookbook';
        RETURN;
    END

    -- Calculate price
    SET @Price = @RecipeCount * 1.33;

    -- Insert into Cookbook table
    INSERT Cookbook (UsersID, CookbookName, Price, DateCreated, Active)
    VALUES (@UsersID, @CookbookName, @Price, GETDATE(), 1);

    -- Get the newly created CookbookID
    SET @CookbookID = SCOPE_IDENTITY();

    -- Insert recipes into CookbookRecipe table, ordered by RecipeName
    INSERT INTO CookbookRecipe (CookbookID, RecipeID, CookBookSequenceNumber)
    SELECT
        @CookbookID,
        RecipeID,
        ROW_NUMBER() OVER (ORDER BY RecipeName) -- Assign sequence numbers
    FROM Recipe
    WHERE UsersID = @UsersID;

    PRINT 'Cookbook created successfully!';
END
GO


