create or alter PROCEDURE RecipeStepsGet(
    @directionsID int =0,
    @recipeID int=0, 
    @all bit =0, 
    @message VARCHAR(500)= '' OUTPUT

)

as 
begin
        SELECT d.direction, d.StepNumber, r.RecipeID, d.directionsID
        from Recipe R
        join Directions d
        on d.recipeID = r.recipeID
        where @recipeID= r.RecipeID
        order by d.stepNumber
end 
go 



