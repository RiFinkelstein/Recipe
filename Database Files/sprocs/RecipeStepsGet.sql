create or alter PROCEDURE RecipeStepsGet(
    @DirectionsID int =0,
    @RecipeID int=0, 
    @All bit =0, 
    @Message VARCHAR(500)= '' OUTPUT

)

as 
begin
        SELECT d.zdirection, d.StepNumber, r.RecipeID, d.DirectionsID
        from Recipe R
        join Directions d
        on d.EecipeID = r.RecipeID
        where @RecipeID= r.RecipeID
        order by d.StepNumber
end 
go 



