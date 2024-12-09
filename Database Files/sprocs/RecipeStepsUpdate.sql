CREATE OR ALTER PROCEDURE dbo.RecipeStepsUpdate(
    @directionsID INT OUTPUT ,
    @recipeId  INT,
    @Direction VARCHAR(1000) = null,
    @stepnumber INT= null
)
AS
BEGIN
    DECLARE @return int = 0;

    if @directionsID = 0 
    begin 
    insert into Directions (RecipeID, Direction, StepNumber)
    VALUEs (@recipeId, @Direction, @stepnumber);
    SELECT @directionsID= SCOPE_IDENTITY();
end 
    ELSE
    begin 
    UPDATE Directions
        set 
        RecipeID= @recipeId, 
        Direction= @Direction, 
        StepNumber= @stepnumber
    WHERE directionsID = @directionsID;

END
RETURN @return;


end 
go