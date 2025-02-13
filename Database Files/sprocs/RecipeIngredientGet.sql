create or alter PROCEDURE RecipeIngredientGet(
    @RecipeIngredientID int =0,
    @RecipeID int=0, 
    @All bit =0, 
    @Message VARCHAR(500)= '' OUTPUT

)
as 
begin 
    DECLARE @Return int=0

    SELECT @All = ISNULL(@all, 0), @RecipeIngredientID = ISNULL(@RecipeIngredientID, 0), @RecipeID= ISNULL(@RecipeID, 0)

    SELECT RI.RecipeIngredientID, ri.RecipeID, ri.IngredientID, i.IngredientName, m.MeasurementID,  ri.Amount, ri.SequenceNumber
        from Recipe R
        join RecipeIngredient RI 
        on r.RecipeID = ri.RecipeID
        join ingredient i 
        on i.IngredientID = RI.IngredientID
        LEFT join Measurement m 
        on m.MeasurementID = ri.MeasurementID
        where @RecipeID= r.RecipeID
        or @all=1
        or ri.RecipeID= @RecipeID
        order by ri.SequenceNumber
  


    RETURN @return

end 
go

--exec RecipeIngredientGet @all=1
--exec RecipeIngredientGet @recipeID =4

