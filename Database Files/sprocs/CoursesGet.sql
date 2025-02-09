create or alter procedure dbo.CoursesGet(
    @All bit = 0
)
as
begin 
    SELECT c.CourseID, c.CourseName, c.courseSequence 
    from course c
	order by c.courseSequence
end 
go


