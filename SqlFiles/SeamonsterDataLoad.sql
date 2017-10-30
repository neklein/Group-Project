use SeaMonster
go

delete from Images
delete from PostText
delete from CategoryPost
delete from Categories
delete from post 
DBCC CHECKIDENT (Post,reseed, 0)
DBCC CHECKIDENT (Images,reseed, 0)
DBCC CHECKIDENT (Categories,reseed, 0)
DBCC CHECKIDENT (CategoryPost,reseed, 0)
DBCC CHECKIDENT (PostText,reseed, 0)



Insert into Post 