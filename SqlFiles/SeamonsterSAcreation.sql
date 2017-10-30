use master
go 

create Login SeamonsterSA With Password = 'ocean' 
Create User SeamonserSA for Login SeamonsterSA
GO

create database SeaMonster
GO

Use SeaMonster
Go
sp_adduser 'SeamonsterSA'
GO
sp_addrolemember 'db_owner', 'SeamonsterSA'
GO
sp_addrolemember 'db_datareader', 'SeamonsterSA'
GO
sp_addrolemember 'db_datawriter', 'SeamonsterSA'
GO

grant execute to SeamonsterSA
GO

