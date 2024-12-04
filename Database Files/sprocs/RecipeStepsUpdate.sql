CREATE OR ALTER PROCEDURE dbo.RecipeStepsUpdate(
    @directionsID INT OUTPUT,
    @recipeId INT,
    @Direction VARCHAR(1000),
    @step INT,
    @Message VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @return INT = 0;

    -- Validate inputs
    IF @recipeId IS NULL OR @Direction IS NULL OR LEN(@Direction) = 0 OR @step <= 0
    BEGIN
        SET @Message = 'Invalid input parameters.';
        SET @return = 1;
        RETURN @return;
    END

    -- Default values
    SELECT @directionsID = ISNULL(@directionsID, 0);

    BEGIN TRY
        IF @directionsID = 0
        BEGIN
            -- Check if StepNumber already exists for the RecipeID
            IF EXISTS (
                SELECT 1
                FROM Directions
                WHERE RecipeID = @recipeId AND StepNumber = @step
            )
            BEGIN
                SET @Message = 'Step number already exists for the specified recipe.';
                SET @return = 1;
                RETURN @return;
            END

            -- Insert new step
            INSERT INTO Directions (RecipeID, Direction, StepNumber)
            VALUES (@recipeId, @Direction, @step);

            SET @directionsID = SCOPE_IDENTITY();
            SET @Message = 'Step successfully added.';
        END
        ELSE
        BEGIN
            -- Validate that directionsID exists
            IF NOT EXISTS (
                SELECT 1
                FROM Directions
                WHERE directionsID = @directionsID
            )
            BEGIN
                SET @Message = 'Update failed: directionsID not found.';
                SET @return = 1;
                RETURN @return;
            END

            -- Check for duplicate StepNumber for other directionsID
            IF EXISTS (
                SELECT 1
                FROM Directions
                WHERE RecipeID = @recipeId AND StepNumber = @step AND directionsID <> @directionsID
            )
            BEGIN
                SET @Message = 'Another step already exists with the same step number.';
                SET @return = 1;
                RETURN @return;
            END

            -- Update existing step
            UPDATE Directions
            SET
                RecipeID = @recipeId,
                Direction = @Direction,
                StepNumber = @step
            WHERE directionsID = @directionsID;

            IF @@ROWCOUNT = 0
            BEGIN
                SET @Message = 'Update failed: DirectionsID not found.';
                SET @return = 1;
            END
            ELSE
            BEGIN
                SET @Message = 'Step successfully updated.';
            END
        END
    END TRY
    BEGIN CATCH
        SET @Message = ERROR_MESSAGE();
        SET @return = 1;
    END CATCH

    RETURN @return;
END
GO

