CREATE or ALTER PROCEDURE dbo.RecipeDelete(
    @recipeid INT,
    @message VARCHAR(500) = '' OUTPUT
)
as 
begin 
    DECLARE @return int =0
if exists (SELECT* from recipe r where r.RecipeID=@recipeid and (r.Status != 'drafted' or DATEDIFF(day, r.ArchivedDate, GETDATE())<30))

BEGIN
  SELECT @return =1, 
  @message= 'cannot delete recipe that is drafted or the recipe has been archived more than 30 days ago'
  goto finished
END

begin try
begin tran
    delete ri from RecipeIngredient ri where ri.recipeID= @recipeid
    delete d from Directions d where RecipeID= @recipeid
    delete r from recipe r where RecipeID= @recipeid

  commit
  end try
  begin catch
	rollback;
	throw
end catch
    finished: 
    return @return

END
go

