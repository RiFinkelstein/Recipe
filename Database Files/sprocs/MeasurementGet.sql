create or alter procedure dbo.MeasurementsGet(
	@MeasurementID int = 0,
	@All bit = 0,
	@Message varchar(500) = ''  output
)
as
begin
	declare @Return int = 0

	select @All = isnull(@All,0), @MeasurementID = isnull(@MeasurementID,0)

        SELECT m.MeasurementID, m.MeasurementName
        from Measurement m 
        where MeasurementID= @MeasurementID
        or @All=1


	return @Return
end
go

--EXEC MeasurementGet @all= 1