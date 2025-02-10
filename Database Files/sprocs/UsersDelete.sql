CREATE OR ALTER PROCEDURE dbo.UsersDelete(
    @UsersID INT,
    @Message VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
    DECLARE @Return INT = 0
   
    BEGIN TRY
        BEGIN TRAN
       
        -- Delete related records first
        DELETE FROM CookbookRecipe WHERE RecipeID IN (SELECT RecipeID FROM Recipe WHERE UsersID = @UsersID)

        DELETE FROM CookbookRecipe WHERE CookbookID IN (SELECT CookbookID FROM CookBook WHERE UsersID = @UsersID)

        DELETE FROM RecipeIngredient WHERE RecipeID IN (SELECT RecipeID FROM Recipe WHERE UsersID = @UsersID)
        
        DELETE FROM Directions WHERE RecipeID IN (SELECT RecipeID FROM Recipe WHERE UsersID = @UsersID)

        DELETE FROM CourseMealRecipe WHERE CourseMealID IN (SELECT CourseMealID FROM CourseMeal WHERE MealID IN (SELECT MealID FROM Meal WHERE UsersID = @UsersID));

        DELETE FROM CourseMealRecipe WHERE RecipeID IN (SELECT RecipeID FROM Recipe WHERE UsersID = @UsersID)

        DELETE FROM CourseMeal WHERE MealID IN (SELECT MealID FROM Meal WHERE UsersID = @UsersID )

        DELETE FROM Recipe WHERE UsersID = @UsersID


        DELETE FROM Meal WHERE UsersID = @UsersID

        DELETE FROM CookBook WHERE UsersID = @UsersID

        DELETE FROM Users WHERE UsersID = @UsersID
       
        COMMIT
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH
   
    RETURN @Return
END;





