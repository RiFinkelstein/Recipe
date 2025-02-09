CREATE OR ALTER PROCEDURE dbo.RecipeDirectionsUpdate(
    @DirectionsID INT OUTPUT ,
    @RecipeID  INT,
    @Direction VARCHAR(1000) = null,
    @StepNumber INT= null
)
AS
BEGIN
    DECLARE @Return int = 0;
    if @DirectionsID = 0 
    begin 
    insert into Directions (RecipeID, Direction, StepNumber)
    VALUES (@RecipeID, @Direction, @StepNumber);
    SELECT @DirectionsID= SCOPE_IDENTITY();
end 
    ELSE
    begin 
    UPDATE Directions
        set 
        RecipeID= @RecipeID, 
        Direction= @Direction, 
        StepNumber= @StepNumber
    WHERE DirectionsID = @DirectionsID;

END
RETURN @Return;


end 
go