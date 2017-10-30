use SeaMonster
GO

/*if exists( select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME='GetCarBrief')
 drop procedure GetCarBrief
 GO*/

 Create Procedure GetPublishedPosts AS
 Begin
 Select p.Title, p.DateCreated, p.ToPostDate, pt.PostText, I.ImageName from Post p
 left join PostText pt on pt.PostId=p.PostID
 left join Images I on I.PostId=p.PostID
 where p.ispublished=1
 order by p.DateCreated
 End  
GO

Create procedure GetImagesForPost(@PostID int) As
begin
select * from Images i 
where i.PostId=@PostID
end
go

Create procedure GetCommentbyID (@PostID int) AS
begin 
select c.CommenterName, c.CommentDate, c.CommentText from Comment c 
where c.PostId=@PostID
END
GO

