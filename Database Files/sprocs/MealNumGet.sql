create or alter procedure dbo.MealNumGet (
    @MealNum int OUTPUT
)
as
begin 
    select @MealNum = count(*) 
    from Meal m 
    return 0;
end 
go
/*
DECLARE @numofmeal int

EXEC MealNumGet @MealNum= @numofmeal output

SELECT @numofmeal as MealCount
*/

