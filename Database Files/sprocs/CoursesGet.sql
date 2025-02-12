create or alter procedure dbo.CourseGet(
    @CourseID int =0,
    @All bit = 0
)
as
begin 
    SELECT c.CourseID, c.CourseName, c.courseSequence 
    from course c
    where c.courseID= @courseid
	or @All= 1
    order by c.courseSequence

end 
go


