CREATE or ALTER PROCEDURE dbo.RecipeDelete(
    @RecipeID INT,
    @Message VARCHAR(2000) = '' OUTPUT
)
as 
begin 
--AS No need for a separate function for this, leave the sproc how it was with the logic in the sproc.
    DECLARE @Return int =0
    
    if exists (
        select 1 from recipe r 
        where r.RecipeID = @RecipeID
        and (r.RecipeStatus = 'published' or DATEDIFF(day, r.ArchivedDate, GETDATE()) <30))
BEGIN
  SELECT @Return =1, @Message= 'Can only delete recipe that is currently drafted or has been archvied more than 30 days ago'
  goto finished
END

begin try
begin tran

        -- Delete from all related tables first to maintain referential integrity
        DELETE FROM CookbookRecipe WHERE RecipeID = @RecipeID
        DELETE FROM CourseMealRecipe WHERE RecipeID = @RecipeID
        DELETE FROM RecipeIngredient WHERE RecipeID = @RecipeID
        DELETE FROM Directions WHERE RecipeID = @RecipeID

        -- Delete orphaned CourseMeal records if they no longer have associated recipes
        DELETE FROM CourseMeal WHERE CourseMealID IN (
            SELECT cm.CourseMealID
            FROM CourseMeal cm
            LEFT JOIN CourseMealRecipe cmr ON cm.CourseMealID = cmr.CourseMealID
            WHERE cmr.CourseMealID IS NULL
        )

        --finally delete the recipe
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




