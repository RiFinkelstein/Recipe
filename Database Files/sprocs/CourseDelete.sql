CREATE OR ALTER PROCEDURE dbo.CourseDelete(
    @CourseID INT,
    @Message VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
    DECLARE @Return INT = 0
   
    BEGIN TRY
        BEGIN TRAN
       
        -- Delete related records first
        delete from coursemealrecipe where CourseMealID in (select CourseMealID from CourseMeal where CourseID = @CourseID)
        DELETE FROM CourseMeal WHERE CourseID = @CourseID
       
        -- Delete the course
        DELETE FROM Course WHERE CourseID = @CourseID
       
        COMMIT
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH
   
    RETURN @Return
END;

go
