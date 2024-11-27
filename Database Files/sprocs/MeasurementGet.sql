create or alter procedure dbo.MeasurementGet(
	@MeasurementID int = 0,
	@All bit = 0,
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0

	select @All = isnull(@All,0), @MeasurementID = isnull(@MeasurementID,0)

        SELECT m.MeasurementID, m.MeasurementName
        from Measurement m 
        where MeasurementID= @MeasurementID
        or @all=1


	return @return
end
go

EXEC IngredientGet