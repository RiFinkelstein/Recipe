CREATE or ALTER PROCEDURE dbo.RecipeDelete(
    @recipeid INT    
)
as 
begin 
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

END
go

