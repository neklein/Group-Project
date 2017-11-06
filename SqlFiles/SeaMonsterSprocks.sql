use SeaMonster
GO

/*if exists( select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME='GetCarBrief')
 drop procedure GetCarBrief
 GO*/

 if exists( select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME='GetPublishedPosts')
 drop procedure GetPublishedPosts
 GO

  if exists( select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME='GetImagesForPost')
 drop procedure GetImagesForPost
 GO

 if exists( select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME='GetCommentbyID')
 drop procedure GetCommentbyID
 GO

 if exists( select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME='ApprovePost')
 drop procedure ApprovePost
 GO

  if exists( select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME='ApproveComment')
 drop procedure ApproveComment
 GO

 if exists( select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME='ApproveReply')
 drop procedure ApproveReply
 GO

 if exists( select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME='CreatePost')
 drop procedure CreatePost
 GO

  if exists( select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME='AddImage')
 drop procedure AddImage
 GO

  if exists( select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME='AddNewHashtag')
 drop procedure AddNewHashtag
 GO

  if exists( select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME='ReuseHashtag')
 drop procedure ReuseHashtag
 GO

   if exists( select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME='GetPostByID')
 drop procedure GetPostByID
 GO

 if exists( select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME='GetReplyByComment')
 drop procedure GetReplyByComment
 GO

  if exists( select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME='GetCategorybyPost')
 drop procedure GetCategorybyPost
 GO

 if exists( select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME='GetHashtagsByPost')
 drop procedure GetHashtagsByPost
 GO

 if exists( select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME='GetPostByHashtag')
 drop procedure GetPostByHashtag
 GO

  if exists( select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME='GetPostByCategory')
 drop procedure GetPostByCategory
 GO

 if exists( select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME='GetPostByAuthor')
 drop procedure GetPostByAuthor
 GO

  if exists( select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME='SavePost')
 drop procedure SavePost
 GO

 if exists( select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME='AdminSavePost')
 drop procedure AdminSavePost
 GO


 if exists( select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME='GetALLPosts')
 drop procedure GetALLPosts
 GO

 if exists( select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME='CreatePostComplete')
 drop procedure CreatePostComplete
 GO

 if exists( select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME='AddCategoryPost')
 drop procedure AddCategoryPost
 GO
 --------------------Searches and Gets------------------------------------------

 
 Create Procedure GetALLPosts as
 begin
 select p.PostID, p.PostTitle, p.DateCreated, isnull(p.ToPostDate, p.DateCreated)AS ToPostDate, p.DisplayAuthor, 
 isnull(p.DisplayDate, p.DateCreated)AS DisplayDate, pt.PostText, p.isforReview, p.Expdate, p.ispublished, p.isStatic, p.addedby 
 from Post p
 left join PostText pt on pt.PostId=p.PostID
 order by p.DateCreated
 end
 go 


 Create Procedure GetPublishedPosts AS
 Begin
select p.PostID, p.PostTitle, p.DateCreated, p.ToPostDate, p.DisplayAuthor, 
 p.DisplayDate, pt.PostText, p.isforReview, p.Expdate, p.ispublished, p.isStatic, p.addedby 
 from Post p
 left join PostText pt on pt.PostId=p.PostID
 where p.ispublished=1
 order by p.DateCreated
 End  
GO

Create Procedure GetPostByID (@PostID int) AS
 Begin
select p.PostID, p.PostTitle, p.DateCreated, p.ToPostDate, p.DisplayAuthor, 
 p.DisplayDate, pt.PostText, p.isforReview, p.Expdate, p.ispublished, p.isStatic, p.addedby
  from Post p
 left join PostText pt on pt.PostId=p.PostID
 where p.PostID=@PostID
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
select c.CommentID, c.CommenterName, c.CommentDate, c.CommentText from Comment c 
where c.PostId=@PostID
END
GO

create procedure GetReplyByComment (@CommentId int) As
begin
select * from Reply r
where r.CommentID=@CommentId
end
go

Create Procedure GetCategorybyPost(@PostID int)AS
begin
Select c.CategoryName, c.CategoryID  from Categories c
left join CategoryPost cp on cp.CategoryID=c.CategoryID
where cp.PostID=@PostID
end
GO

Create Procedure GetHashtagsByPost (@PostID int) AS
Begin 
select h.Hashtag, h.HashtagID from HashTags h
left join HashtagPost hp on hp.HashtagID =h.HashtagID
where hp.PostID=@PostID
end
go

Create Procedure GetPostByHashtag (@HashtagID int) AS
begin
 select p.PostID, p.PostTitle, p.DateCreated, p.ToPostDate, p.DisplayAuthor, 
 p.DisplayDate, pt.PostText, p.isforReview, p.Expdate, p.ispublished, p.isStatic, p.addedby
 from Post p
 left join PostText pt on pt.PostId=p.PostID
 left join HashtagPost h on h.PostID=p.PostID
 where h.HashtagID=@HashtagID
 order by p.DateCreated
end
Go

Create Procedure GetPostByCategory (@CategoryID int)AS
begin
Select p.PostID, p.PostTitle, p.DateCreated, p.ToPostDate, p.DisplayAuthor, 
 p.DisplayDate, pt.PostText, p.isforReview, p.Expdate, p.ispublished, p.isStatic, p.addedby
from Post p
left join PostText pt on pt.PostId=p.PostID
left join CategoryPost cp on cp.PostId=p.PostID
where cp.CategoryID=@CategoryID
end
go

Create Procedure GetPostByAuthor (@DisplayAuthor nvarchar(40)) AS
Begin
 select p.PostID, p.PostTitle, p.DateCreated, p.ToPostDate, p.DisplayAuthor, 
 p.DisplayDate, pt.PostText, p.isforReview, p.Expdate, p.ispublished, p.isStatic, p.addedby
 from post p
 left join PostText pt on pt.PostId=p.PostID
 where p.DisplayAuthor=@DisplayAuthor
 END
 GO

---------------Admin---------------------
Create Procedure ApprovePost (@PostID int) AS
begin
update Post set
Post.ispublished=1
where PostID=PostID
End
GO

Create Procedure ApproveComment (@CommentId int) AS
begin
update Comment set
Comment.IsShown=1
where CommentID =@CommentId
end  
go

Create Procedure ApproveReply (@ReplyId int)AS
Begin 
update Reply set
Reply.IsShown=1
where ReplyId=@ReplyId
END
GO

Create Procedure CreatePost(@PostID int Output, @PostTitle nvarchar(50), @PostText nvarchar(max), @ExpDate DateTime2 = null, @ToPostDate DateTime2 =null, @DisplayAuthor nvarchar(40), @DisplayDate datetime2 =null) AS
begin 
insert into Post (PostTitle, Expdate,ToPostDate,DisplayAuthor,DisplayDate) values (@PostTitle, @ExpDate,@ToPostDate, @DisplayAuthor,@DisplayDate)
set @PostID=SCOPE_IDENTITY();
insert into PostText (PostId, PostText) Values (@PostID, @PostText)
END
Go

Create Procedure AddImage(@ImageName varchar(30), @PostID int) AS
Begin
insert into Images (ImageName, PostId) values (@ImageName, @PostID)
End
Go



Create Procedure AddNewHashtag (@Hashtag nvarchar(50), @HashtagID int output, @PostID int)As
begin
begin transaction
Insert into Hashtags (Hashtag) Values (@Hashtag)
set @HashtagID=SCOPE_IDENTITY();
insert into HashtagPost values(@HashtagID, @PostId)
commit 
end  
GO

Create Procedure ReuseHashtag (@HashtagID int, @PostId int) AS
Begin
Insert into HashtagPost (HashtagID, PostID) Values (@HashtagID, @PostId)
End
Go

Create Procedure SavePost (@PostID int, @PostTitle nvarchar(50), @PostText nvarchar(max), @ExpDate DateTime2 null, @ToPostDate DateTime2 null, @DisplayAuthor nvarchar(40), @DisplayDate datetime2, @isForReview bit, @isStatic bit) AS
Begin
Update Post SET 
PostTitle=@PostTitle,
ExpDate=@ExpDate,
ToPostDate=@ToPostDate,
DisplayAuthor=@DisplayAuthor,
DisplayDate=@DisplayDate,
isforReview=@isForReview,
isStatic=@isStatic
where PostID=@PostID

update PostText Set
PostText=@PostText
where PostId=@PostID
END
GO

Create Procedure AdminSavePost (@PostID int, @PostTitle nvarchar(50), @PostText nvarchar(max), @ExpDate DateTime2 null, @ToPostDate DateTime2 null, @DisplayAuthor nvarchar(40), @DisplayDate datetime2, @isForReview bit, @isPublished bit) AS
Begin
Update Post SET 
PostTitle=@PostTitle,
ExpDate=@ExpDate,
ToPostDate=@ToPostDate,
DisplayAuthor=@DisplayAuthor,
DisplayDate=@DisplayDate,
isforReview=@isForReview,
ispublished=@isPublished
where PostID=@PostID

update PostText Set
PostText=@PostText
where PostId=@PostID
END
GO



Create Procedure CreatePostComplete(@PostID int Output, @PostTitle nvarchar(50), @PostText nvarchar(max), @ExpDate DateTime2 = null, @ToPostDate DateTime2 =null, @DisplayAuthor nvarchar(40), @DisplayDate datetime2 =null, @isPublished bit, @isforreview bit, @isStatic bit) AS
begin 
insert into Post (PostTitle, Expdate,ToPostDate,DisplayAuthor,DisplayDate, ispublished, isforReview, isStatic) 
values (@PostTitle, @ExpDate,@ToPostDate, @DisplayAuthor,@DisplayDate, @isPublished, @isforreview, @isStatic)
set @PostID=SCOPE_IDENTITY();
insert into PostText (PostId, PostText) Values (@PostID, @PostText)
END
Go

Create Procedure AddCategoryPost (@PostID int, @CategoryID int) As
begin
If Not Exists (select * from CategoryPost where PostID=@PostID and CategoryID=@CategoryID)
insert into CategoryPost (CategoryID, PostID) Values (@CategoryID, @PostID)
end
GO

select * from post
select* from PostText
select * from Hashtags
select * from HashtagPost
select * from CategoryPost
select * from post where ispublished=1