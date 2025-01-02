CREATE OR ALTER PROC dbo.CookbookUpdate(
    @cookbookID int OUTPUT, -- Corrected parameter name
    @UsersID int,
    @cookbookName varchar(100),
    @price int,
    @datecreated DATETIME
)
AS
BEGIN
    DECLARE @return int = 0;

    IF @cookbookID IS NULL or @cookbookID=0
    BEGIN
        INSERT Cookbook (UsersID, CookbookName, Price, DateCreated)
        VALUES (@UsersID, @cookbookName, @price, @datecreated);
        -- Capture the newly inserted ID
        SELECT @cookbookID = SCOPE_IDENTITY();
    END
    ELSE
    BEGIN
        -- Update existing record
        UPDATE Cookbook
        SET
            UsersID = @UsersID,
            CookbookName = @cookbookName,
            Price = @price,
            DateCreated = @datecreated
        WHERE CookbookID = @cookbookID;
    END

    RETURN @return;
END
GO