CREATE or ALTER PROCEDURE dbo.RecipeDelete(
    @recipeid INT    
)
as 
begin 
begin try
begin tran
	delete RecipeIngredient where RecipeID= @recipeid  
    delete recipe where RecipeID= @recipeid  
  commit
  end try
  begin catch
	rollback;
	throw
end catch

END
go


