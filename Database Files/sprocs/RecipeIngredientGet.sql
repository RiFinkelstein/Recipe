create or alter PROCEDURE RecipeIngredientGet(
    @RecipeIngredientid int =0,
    @recipeID int=0, 
    @all bit =0, 
    @message VARCHAR(500)= '' OUTPUT

)

as 
begin
        SELECT i.ingredientName, m.MeasurementName, ri.Amount, ri.SequenceNumber
        from Recipe R
        join RecipeIngredient RI 
        on r.recipeID = ri.recipeID
        join ingredient i 
        on i.ingredientID = RI.ingredientID
        LEFT join Measurement m 
        on m.MeasurementID = ri.MeasurementID
        where @recipeID= r.RecipeID
        order by ri.SequenceNumber
end 
go 


