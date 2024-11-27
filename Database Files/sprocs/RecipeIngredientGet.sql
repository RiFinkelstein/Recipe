create or alter PROCEDURE RecipeIngredientGet(
    @RecipeIngredientid int =0,
    @recipeID int=0, 
    @all bit =0, 
    @message VARCHAR(500)= '' OUTPUT

)
as 
begin 
    DECLARE @return int=0

    SELECT @all = ISNULL(@all, 0), @RecipeIngredientid = ISNULL(@RecipeIngredientid, 0), @recipeID= ISNULL(@recipeID, 0)
SELECT RI.RecipeIngredientID,
       RI.RecipeID,
       RI.IngredientID,
       RI.MeasurementID,
       RI.Amount,
       RI.SequenceNumber
FROM Recipe R
JOIN RecipeIngredient RI
    ON R.RecipeID = RI.RecipeID
WHERE @recipeID = R.RecipeID
   OR @all = 1
ORDER BY RI.SequenceNumber;
  


    RETURN @return

end 
go

--exec RecipeIngredientGet @all=1
--exec RecipeIngredientGet @recipeID =35