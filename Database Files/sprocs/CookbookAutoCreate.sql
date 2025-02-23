CREATE OR ALTER PROCEDURE dbo.CookbookAutoCreate(
    @UsersID INT,
    @CookbookID INT output,
    @Message VARCHAR(100) output)
AS
BEGIN
--AS There is no reason why this code has to be all broken up using variables, this can be done simply in 2 insert statements (the same way it was done in maintenance tasks.)    
    DECLARE @CookbookName VARCHAR(100)= (
        select 'Recipes by ' + U.UsersFirstName + ' ' + U.UsersLastName
        from users u
        where UsersID= @UsersID
    )
    --check if cookbook already exists
    IF EXISTS (SELECT 1 FROM Cookbook WHERE CookbookName = @CookbookName AND UsersID = @UsersID)
    BEGIN
    SET @Message = 'A cookbook with this name already exists for this user.';
    RETURN;
    END

    -- Insert into Cookbook table
    INSERT Cookbook (UsersID, CookbookName, Price, DateCreated, Active)
    VALUES (@UsersID, 
    @CookbookName, 
    (select count(*) * 1.33 from recipe r where r.UsersID= @UsersID), 
    GETDATE()
    , 1);

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


