CREATE OR ALTER PROCEDURE dbo.RecipeIngredientUpdate(
    @RecipeIngredientId INT OUTPUT,
    @RecipeId INT,
    @IngredientId INT,
    @MeasurementName VARCHAR(35) = NULL, -- Optional
    @Amount DECIMAL(5,2) = NULL,         -- Optional
    @IngredientName VARCHAR(35) = NULL -- Optional
   --@Message VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @return INT = 0;

    -- Default RecipeIngredientId to 0 if NULL
    SELECT @RecipeIngredientId = ISNULL(@RecipeIngredientId, 0);

    BEGIN TRY
        IF @RecipeIngredientId = 0
        BEGIN
            -- Insert New Recipe Ingredient
            INSERT INTO RecipeIngredient (RecipeID, IngredientID, MeasurementID, Amount, SequenceNumber)
            VALUES (
                @RecipeId,
                @IngredientId,
                (SELECT MeasurementID FROM Measurement WHERE MeasurementName = @MeasurementName),
                @Amount,
                (SELECT ISNULL(MAX(SequenceNumber), 0) + 1 FROM RecipeIngredient WHERE RecipeID = @RecipeId)
            );

            -- Capture the new ID
            SELECT @RecipeIngredientId = SCOPE_IDENTITY();
            --SET @Message = 'Recipe ingredient successfully added.';
        END
        ELSE
        BEGIN
            -- Update existing RecipeIngredient
            UPDATE RecipeIngredient
            SET
                RecipeID = @RecipeId,
                IngredientID = @IngredientId,
                MeasurementID = (SELECT MeasurementID FROM Measurement WHERE MeasurementName = @MeasurementName),
                Amount = @Amount
            WHERE RecipeIngredientID = @RecipeIngredientId;

            IF @@ROWCOUNT = 0
            BEGIN
                --SET @Message = 'Update failed: RecipeIngredientID not found.';
                SET @return = 1;
                RETURN @return;
            END

            -- Update IngredientName if provided
            IF @IngredientName IS NOT NULL
            BEGIN
                UPDATE Ingredient
                SET IngredientName = @IngredientName
                WHERE IngredientID = @IngredientId;

                IF @@ROWCOUNT = 0
                BEGIN
                    --SET @Message = 'Update failed: IngredientID not found.';
                    SET @return = 1;
                    RETURN @return;
                END
            END

            --SET @Message = 'Recipe ingredient successfully updated.';
        END
    END TRY
    BEGIN CATCH
        -- Capture the error message
        --SET @Message = ERROR_MESSAGE();
        SET @return = 1;
    END CATCH

    RETURN @return;
END
GO