CREATE OR ALTER PROCEDURE dbo.MeasurementsDelete(
    @MeasurementID INT,
    @Message VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
    DECLARE @Return INT = 0
   
    BEGIN TRY
        BEGIN TRAN
       
        -- Delete related records first
        DELETE FROM RecipeIngredient WHERE MeasurementID = @MeasurementID
       
        -- Delete the measurement
        DELETE FROM Measurement WHERE MeasurementID = @MeasurementID
       
        COMMIT
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH
   
    RETURN @Return
END;
GO