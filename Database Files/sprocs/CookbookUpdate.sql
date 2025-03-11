CREATE OR ALTER PROC dbo.CookbookUpdate(
    @CookbookID int OUTPUT, -- Corrected parameter name
    @UsersID int,
    @CookbookName varchar(100),
    @Price DECIMAL (10,2),
    @DateCreated DATETIME,
    @Active int
)
AS
BEGIN
    DECLARE @return int = 0;
--AS Take out checking if it's null.
    set @CookbookID = ISNULL(@cookbookID,0)


    IF @CookbookID =0
    BEGIN
        INSERT Cookbook (UsersID, CookbookName, Price, DateCreated, Active)
        VALUES (@UsersID, @CookbookName, @Price, @DateCreated, @Active);
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
            DateCreated = @DateCreated,
            Active= @Active
        WHERE CookbookID = @cookbookID;
    END

    RETURN @return;
END
GO