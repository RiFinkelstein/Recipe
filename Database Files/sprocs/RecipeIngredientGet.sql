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

    SELECT RI.RecipeIngredientID, ri.RecipeID, ri.IngredientID, i.ingredientName, m.MeasurementID, m.MeasurementName, ri.Amount, ri.SequenceNumber
        from Recipe R
        join RecipeIngredient RI 
        on r.recipeID = ri.recipeID
        join ingredient i 
        on i.ingredientID = RI.ingredientID
        LEFT join Measurement m 
        on m.MeasurementID = ri.MeasurementID
        where @recipeID= r.RecipeID
            or @all=1
    or ri.RecipeID= @recipeID
        order by ri.SequenceNumber
  


    RETURN @return

end 
go

--exec RecipeIngredientGet @all=1
--exec RecipeIngredientGet @recipeID =35