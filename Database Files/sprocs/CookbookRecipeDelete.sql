CREATE or alter PROCEDURE dbo.cookbookrecipeDelete(
    @cookbookrecipeID int =0, 
    @Message varchar(500) = ''  output
)

as 
begin 
        DECLARE @return INT = 0;
        
        select @cookbookrecipeID = isnull(@cookbookrecipeID,0)

        delete cookbookrecipe where cookbookrecipeID = @cookbookrecipeID
        
        RETURN @return;
end
go
