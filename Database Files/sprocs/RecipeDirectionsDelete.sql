create or alter procedure dbo.RecipeDirectionsDelete(
	@DirectionsID int = 0,
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0

	select @DirectionsID = isnull(@DirectionsID,0)

	delete Directions where DirectionsID = @DirectionsID

	return @return
end
go
