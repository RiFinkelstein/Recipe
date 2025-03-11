CREATE OR ALTER PROCEDURE dbo.RecipeIngredientUpdate(
    @RecipeIngredientID INT OUTPUT,
    @RecipeID INT,
    @IngredientID INT,
    @MeasurementID INT = NULL,  -- Now accepting MeasurementID directly
    @Amount DECIMAL(5,2) = NULL,         -- Optional
    @IngredientName VARCHAR(35) = NULL, 
    @SequenceNumber INT= NULL -- Optional
)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @return INT = 0;
    DECLARE @MeasurementName VARCHAR(35);

    -- Default RecipeIngredientID to 0 if NULL
    SELECT @RecipeIngredientID = ISNULL(@RecipeIngredientID, 0);

    BEGIN TRY
                -- Step 1: Retrieve MeasurementName based on MeasurementID
                IF @MeasurementID IS NOT NULL
                BEGIN
                    SELECT @MeasurementName = MeasurementName FROM Measurement WHERE MeasurementID = @MeasurementID;
                END

            -- Step 2: Insert new RecipeIngredient if RecipeIngredientID = 0
            IF @RecipeIngredientID = 0
            BEGIN
            INSERT INTO RecipeIngredient (RecipeID, IngredientID, MeasurementID, Amount, SequenceNumber)
            VALUES (
                @RecipeID,
                @IngredientID,
--AS Fix logic, this isn't working. Same for update
                @MeasurementID,
                @Amount,
                @SequenceNumber
            );

            -- Capture the new ID
            SELECT @RecipeIngredientID = SCOPE_IDENTITY();
        END
        ELSE
        BEGIN
            --Step 3: Update existing RecipeIngredient
            UPDATE RecipeIngredient
            SET
                RecipeID = @RecipeID,
                IngredientID = @IngredientID,
                MeasurementID = @MeasurementID,
                Amount = @Amount, 
                SequenceNumber= @SequenceNumber
            WHERE RecipeIngredientID = @RecipeIngredientID;

            IF @@ROWCOUNT = 0
            BEGIN
                SET @return = 1;
                RETURN @return;
            END
--AS Why is this necessary?
            END

    END TRY
    BEGIN CATCH
        SET @return = 1;
    END CATCH

    RETURN @return;
END
GO