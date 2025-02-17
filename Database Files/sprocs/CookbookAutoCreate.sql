CREATE OR ALTER PROCEDURE dbo.CookbookAutoCreate(
    @UsersID INT,
    @CookbookID INT output,
    @Message VARCHAR(100) output)
AS
BEGIN
    Declare @CookbookName VARCHAR(100)
    Declare @RecipeCount INT 
    Declare @Price DECIMAL(10,2)   

    -- Get user full name
    SELECT @CookbookName = 'Recipes by ' + U.UsersFirstName + ' ' + U.UsersLastName
    FROM Users U
    WHERE UsersID = @UsersID;

    IF EXISTS (SELECT 1 FROM Cookbook WHERE CookbookName = @CookbookName AND UsersID = @UsersID)
    BEGIN
    SET @Message = 'A cookbook with this name already exists for this user.';
    RETURN;
    END

    -- Count user's recipes
    SELECT @RecipeCount = COUNT(*)
    FROM Recipe
    WHERE UsersID = @UsersID;

    -- If no recipes, exit
    IF @RecipeCount = 0
    BEGIN
        set @Message= 'User has no recipes to create a cookbook';
        RETURN;
    END
    --if the user does have recipes, clear the message
    SET @Message= ''

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

    set @Message= 'Cookbook created successfully!';
END
GO


