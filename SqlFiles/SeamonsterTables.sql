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
if exists (select * from sys.tables where name='CategoryPost')
Drop table CategoryPost
GO

if exists (select * from sys.tables where name='PostText')
Drop table PostText
GO

if exists (select * from sys.tables where name='Images')
Drop table Images
GO

if exists (select * from sys.tables where name='Categories')
Drop table Categories
GO

if exists (select * from sys.tables where name='Post')
Drop table Post
GO








Create Table Categories 
	(
		CategoryID int identity(1,1) not null primary key,
		CategoryTag nvarchar(50),
		DateAdded datetime2 default(getdate())
	)
GO

Create Table Post 
	(
	 PostID int identity (1,1) primary key,
	 PostTitle nvarchar(50) not null,
	 DateCreated datetime2 default(getdate()),
	 Expdate datetime2,
	 ToPostDate datetime2 default(getdate()),
	 ispublished bit not null default 0,
	 addedby nvarchar(40) default Current_User
	)

Create Table Images 
	(
		ImageID int identity(1,1) primary key,
		ImageName varchar(30),
		PostId int foreign key references Post(PostID),
	)
GO

Create Table CategoryPost
	(
	  CategoryID int foreign key references Categories(CategoryID),
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