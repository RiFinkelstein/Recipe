CREATE OR ALTER PROCEDURE dbo.CuisineUpdate(
    @CuisineID INT OUTPUT,
    @CuisineName VARCHAR(35),
    @Message VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
    DECLARE @Return INT = 0

    SELECT @CuisineID = ISNULL(@CuisineID, 0)

    IF @CuisineID = 0
    BEGIN
        INSERT INTO Cuisine (CuisineName)
        VALUES (@CuisineName)

        SELECT @CuisineID = SCOPE_IDENTITY()
    END
    ELSE
    BEGIN
        UPDATE Cuisine
        SET
            CuisineName = @CuisineName
        WHERE CuisineID = @CuisineID
    END

    RETURN @Return
END
GO


