create or alter procedure dbo.RecipeStepsDelete(
	@directionsID int = 0,
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0

	select @directionsID = isnull(@directionsID,0)

	delete Directions where directionsID = @directionsID

	return @return
end
go
