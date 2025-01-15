CREATE or ALTER PROCEDURE dbo.RecipeDelete(
    @RecipeID INT,
    @Message VARCHAR(500) = '' OUTPUT
)
as 
begin 
    DECLARE @Return int =0, @DeleteAllowed varchar(60)= ''
    select @DeleteAllowed =ISNULL(dbo.isRecipeDelteAllowed(@RecipeId), '') 
    if @DeleteAllowed <> ''


--if exists (SELECT* from recipe r where r.RecipeID=@recipeid and (r.Status = 'published' or DATEDIFF(day, r.ArchivedDate, GETDATE())<30))

BEGIN
  SELECT @Return =1, @Message= @DeleteAllowed
  --@Message= 'can only delete recipe that is currently drafted or the recipe has been archived more than 30 days ago'
  goto finished
END

begin try
begin tran
    delete ri from RecipeIngredient ri where ri.RecipeID= @Recipeid
    delete d from Directions d where RecipeID= @RecipeID
    delete r from recipe r where RecipeID= @RecipeiD

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




