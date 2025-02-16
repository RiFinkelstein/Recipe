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

    SELECT RI.RecipeIngredientID, ri.RecipeID, ri.Amount, ri.IngredientID, RI.MeasurementID, ri.SequenceNumber
        from Recipe R
        join RecipeIngredient RI 
        on r.RecipeID = ri.RecipeID
        where @RecipeID= r.RecipeID
        or @all=1
        or ri.RecipeID= @RecipeID
        order by ri.SequenceNumber
  


    RETURN @return

end 
go

--exec RecipeIngredientGet @all=1
--exec RecipeIngredientGet @recipeID =4

