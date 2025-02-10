CREATE OR ALTER PROCEDURE dbo.MeasurementUpdate(
    @MeasurementID INT OUTPUT,
    @MeasurementName VARCHAR(35),
    @Message VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
    DECLARE @Return INT = 0

    SELECT @MeasurementID = ISNULL(@MeasurementID, 0)

    IF @MeasurementID = 0
    BEGIN
        INSERT INTO Measurement (MeasurementName)
        VALUES (@MeasurementName)

        SELECT @MeasurementID = SCOPE_IDENTITY()
    END
    ELSE
    BEGIN
        UPDATE Measurement
        SET
            MeasurementName = @MeasurementName
        WHERE MeasurementID = @MeasurementID
    END

    RETURN @Return
END
GO

