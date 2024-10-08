create or alter procedure dbo.CookbookNumGet (
    @CookbookNum int OUTPUT
)
as
begin 
    select @CookbookNum = count(*) 
    from CookBook 
    return 0;
end 
go

DECLARE @numofCookbook int

EXEC CookbookNumGet @CookbookNum= @numofCookbook output

SELECT @numofCookbook as cookbookcount


