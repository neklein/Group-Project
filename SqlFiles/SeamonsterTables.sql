Use SeaMonster
Go


if exists (select * from sys.tables where name='Reply')
Drop table Reply
GO

--if exists (select* from sys.tables where name='')
if exists (select * from sys.tables where name='Comment')
Drop table Comment
GO

--if exists (select* from sys.tables where name='')
if exists (select * from sys.tables where name='HashtagPost')
Drop table HashtagPost
GO

if exists (select * from sys.tables where name='PostText')
Drop table PostText
GO

if exists (select * from sys.tables where name='Images')
Drop table Images
GO

if exists (select * from sys.tables where name='Hashtags')
Drop table Hashtags
GO



if exists (select * from sys.tables where name='CategoryPost')
Drop table CategoryPost
GO

if exists (select * from sys.tables where name='Categories')
Drop table Categories
GO


if exists (select * from sys.tables where name='Post')
Drop table Post
GO








Create Table Hashtags 
	(
		HashtagID int identity(1,1) not null primary key,
		Hashtag nvarchar(50),
		DateAdded datetime2 default(getdate())
	)
GO

Create Table Post 
	(
	 PostID int identity (1,1) primary key,
	 PostTitle nvarchar(50) not null,
	 DateCreated datetime2 default(getdate()),
	 Expdate datetime2 default null,
	 ToPostDate datetime2,
	 ispublished bit not null default 0,
	 addedby nvarchar(40) default Current_User,
	 isStatic bit default 0 not null,
	 isforReview bit default 0 not null,
	 DisplayAuthor nvarchar(40) default Current_User,
	 DisplayDate datetime2
	)
GO

Create Table Categories 
	(
	 CategoryID int identity(1,1) primary Key not null,
	 CategoryName nvarchar(50) not null,
	 DateAdded datetime2  not null default(getdate())
	)	
GO

create Table CategoryPost 
	(
	 CategoryID int foreign key references Categories(CategoryID) not null,
	 PostID int foreign key references Post(PostID)
	)

Create Table Images 
	(
		ImageID int identity(1,1) primary key,
		ImageName varchar(30),
		PostId int foreign key references Post(PostID),
	)
GO

Create Table HashtagPost
	(
	  HashtagID int foreign key references Hashtags(HashtagID),
	  PostID int foreign key references Post(PostID)
	)
GO

Create Table PostText 
	(
	   PostTextId int identity(1,1) primary key,
	   PostId int foreign key references Post(PostID),
	   PostText nvarchar(max),
	   textaddedby nvarchar(40) default Current_User
	) 
	GO

Create Table Comment 
	(
	  CommentID int identity(1,1) primary key not null,
	  PostId int foreign key references Post(PostID),
	  CommenterName nvarchar(30) default 'anonymous',
	  CommentDate datetime2 default(getdate()),
	  CommentText nvarchar(500) not null,
	  IsShown bit default 0
	)
go

create Table Reply 
(
	ReplyId int identity(1,1) primary key not null,
	CommentID int foreign key references Comment(CommentID) not null,
	ReplyName nvarchar(30) default 'anonymous',
	ReplyDate datetime2 default(getdate()),
	ReplyText nvarchar(500) not null,
	IsShown bit default 0,
)
GO