CREATE OR ALTER PROCEDURE dbo.UsersUpdate(
    @UsersID INT OUTPUT,
    @UsersFirstName VARCHAR(35),
    @UsersLastName VARCHAR(35),
    @UsersName VARCHAR(35),
    @Message VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
    DECLARE @Return INT = 0

    SELECT @UsersID = ISNULL(@UsersID, 0)

    IF @UsersID = 0
    BEGIN
        INSERT INTO Users (UsersFirstName, UsersLastName, UsersName)
        VALUES (@UsersFirstName, @UsersLastName, @UsersName)

        SELECT @UsersID = SCOPE_IDENTITY()
    END
    ELSE
    BEGIN
        UPDATE Users
        SET
            UsersFirstName = @UsersFirstName,
            UsersLastName = @UsersLastName,
            UsersName = @UsersName
        WHERE UsersID = @UsersID
    END

    RETURN @Return
END
GO
