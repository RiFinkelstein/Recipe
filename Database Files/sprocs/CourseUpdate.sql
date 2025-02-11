CREATE OR ALTER PROCEDURE dbo.CourseUpdate(
    @CourseID INT OUTPUT,
    @CourseName VARCHAR(50),
    @CourseSequence INT,
    @Message VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
    DECLARE @Return INT = 0

    SELECT @CourseID = ISNULL(@CourseID, 0)

    IF @CourseID = 0
    BEGIN
        INSERT INTO Course (CourseName, CourseSequence)
        VALUES (@CourseName, @CourseSequence)

        SELECT @CourseID = SCOPE_IDENTITY()
    END
    ELSE
    BEGIN
        UPDATE Course
        SET
            CourseName = @CourseName,
            CourseSequence = @CourseSequence
        WHERE CourseID = @CourseID
    END

    RETURN @Return
END
GO