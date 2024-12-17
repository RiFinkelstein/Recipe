create or alter FUNCTION dbo.IsRecipeDelteAllowed(@recipeID int)
returns VARCHAR(60)

as 
begin 
    declare @value VARCHAR(60)= ''
if EXISTS (select * from direction D where d.recipeID= @Direction)
begin 
 select @value= 'cannot delete recipe that has related records'
end

    return @value

end 
go 

