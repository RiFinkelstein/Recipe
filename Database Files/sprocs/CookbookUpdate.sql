CREATE OR ALTER PROC dbo.CookbookUpdate(
    @CookbookID int OUTPUT, -- Corrected parameter name
    @UsersID int,
    @CookbookName varchar(100),
    @Price int,
    @DateCreated DATETIME
)
AS
BEGIN
    DECLARE @return int = 0;
<<<<<<< HEAD
--AS Take out checking if it's null.
    IF @CookbookID IS NULL or @CookbookID=0
=======

    IF @CookbookID =0
>>>>>>> ce296b26ad62d933db5305df0d18be524562a86d
    BEGIN
        INSERT Cookbook (UsersID, CookbookName, Price, DateCreated)
        VALUES (@UsersID, @CookbookName, @Price, @DateCreated);
        -- Capture the newly inserted ID
        SELECT @CookbookID = SCOPE_IDENTITY();
    END
    ELSE
    BEGIN
        -- Update existing record
        UPDATE Cookbook
        SET
            UsersID = @UsersID,
            CookbookName = @CookbookName,
            Price = @Price,
            DateCreated = @DateCreated
        WHERE CookbookID = @cookbookID;
    END

    RETURN @return;
END
GO