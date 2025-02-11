create or alter FUNCTION dbo.IsRecipeDeleteAllowed(@recipeid int)
returns VARCHAR(60)

as 
begin 
    declare @value VARCHAR(60)= ''
if EXISTS (SELECT* from recipe r where r.RecipeID=@recipeid and (r.recipestatus = 'published' or DATEDIFF(day, r.ArchivedDate, GETDATE())<30))
begin 
 select @value= 'can only delete recipe that is currently drafted or the recipe has been archived more than 30 days ago'
end

    return @value

end 
go 