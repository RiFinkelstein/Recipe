create or alter procedure dbo.RecipeStepsUpdate(
	@directionsID int  output,
	@recipeId int ,
    @Direction VARCHAR(1000),
    @step int,
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0

	select @directionsID = isnull(@directionsID,0), @recipeId = isnull(@directionsID,0)

	if @directionsID = 0
	begin
		insert Directions(RecipeID, Direction, StepNumber)
		values(@recipeId, @Direction, @step)

		select @directionsID= scope_identity()
	end
	else
	begin
		update Directions
		set
			recipeId = @recipeId 
			--directionsID = @directionsID
		where directionsID = @directionsID
	end

	return @return
end
go

