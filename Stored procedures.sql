drop proc [dbo].[IsExistLogin] 

go

Create proc [dbo].[IsExistLogin] 
@login nvarchar(50),
@password nvarchar(50)
as
select * from dbo.Logins 
where dbo.Logins.Login = @login and dbo.Logins.Password = @password

go

drop proc [dbo].[GetUserByEmail]

go

Create proc [dbo].[GetUserByEmail] 
@eMail nvarchar(50)
as
select * from dbo.Logins 
where dbo.Logins.EMail = @eMail

go

drop proc [dbo].[AddNewUser] 

go

Create proc [dbo].[AddNewUser] 
@email nvarchar(50),
@login nvarchar(50),
@password nvarchar(50)
as
insert into dbo.Logins values(@email, @login, @password, 0)

go

drop proc [dbo].[GetUserByLogin] 

go

Create proc [dbo].[GetUserByLogin] 
@login nvarchar(50)
as
select * from dbo.Logins 
where dbo.Logins.Login = @login

GO

drop proc [dbo].[IsExistEMail] 

go

Create proc [dbo].[IsExistEMail] 
@eMail nvarchar(50)
as
select * from dbo.Logins 
where dbo.Logins.EMail = @eMail

GO

drop proc dbo.SetFileWay 

go

create proc dbo.SetFileWay 
@ID_Record int,
@FileWay nvarchar(100)
as
update Records 
set FileWay = @FileWay
where ID_Record = @ID_Record
 
go

drop proc dbo.SetImage

go

create proc dbo.SetImage
@ID_Record int,
@Image nvarchar(100)
as
update Records 
set Image = @Image
where ID_Record = @ID_Record
 
go

drop proc [dbo].[ChangePassTo]

go

create proc [dbo].[ChangePassTo]
@Login nvarchar(50),
@Password nvarchar(50)
as
update dbo.Logins 
set dbo.Logins.Password = @Password
where dbo.Logins.Login = @Login

GO

drop proc [dbo].[MadeAdminUser]

go

create proc [dbo].[MadeAdminUser]
@Login nvarchar(50)
as
update dbo.Logins
set dbo.Logins.IsAdmin = 1
where dbo.Logins.Login = @Login

go

drop proc AddNewRecord

go

create proc AddNewRecord
@Name nvarchar(250),
@Author nvarchar(50),
@Year int,
@UploadBy int,
@UploadDate Datetime,
@Type nvarchar(20),
@Format nvarchar(20)
as
insert into Records values(@Name, null, @Author, @Year, @UploadBy, @UploadDate, @Type, 'temp', @Format)

go

drop proc GetIdRecord

go

create proc GetIdRecord
@UploadDate Datetime
as
select Records.ID_Record from Records
where @UploadDate = Records.UploadDate

go

drop proc dbo.AddNewMusic 

go

create proc dbo.AddNewMusic 
@ID_Record int,
@PlayTyme nvarchar(20),
@BitRate int,
@Album nvarchar(50),
@Style nvarchar(20)
as
insert into dbo.Music values (@ID_Record,@PlayTyme,@BitRate,@Album,@Style)

go

drop proc dbo.AddNewMovie 

go

create proc dbo.AddNewMovie 
@ID_Record int,
@PlayTyme nvarchar(20),
@Genre nvarchar(20),
@Quality nvarchar(20)
as
insert into dbo.Movies values (@ID_Record,@PlayTyme,@Genre,@Quality)

go

drop proc dbo.AddNewBook

go

create proc dbo.AddNewBook
@ID_Record int,
@PublishingHouse nvarchar(50),
@Pages int
as
insert into dbo.Books values (@ID_Record, @PublishingHouse, @Pages)

go

drop proc dbo.GetAllRecords

go

create proc dbo.GetAllRecords
as
select * from Records 

go

drop proc DeleteMusic

go

Create proc DeleteMusic
@ID int
as
delete from Music
where Music.ID_Record=@ID

go


drop proc DeleteBook

go

Create proc DeleteBook
@ID int
as
delete from Books
where Books.ID_Record = @ID

go

drop proc DeleteMovie

go

Create proc DeleteMovie
@ID int
as
delete from Movies
where Movies.ID_Record = @ID

go

drop proc DeleteRecord

go

Create proc DeleteRecord
@ID int
as
delete from Records
where Records.ID_Record = @ID

go

drop proc [dbo].[GetRecordById]

go

create proc [dbo].[GetRecordById]
@ID int
as
select * from Records 
where Records.ID_Record = @ID

GO

drop proc [dbo].[GetMusicById]

go

create proc [dbo].[GetMusicById]
@ID int
as
select * from Music 
where Music.ID_Record = @ID

go

drop proc [dbo].[GetBookById]

go

create proc [dbo].[GetBookById]
@ID int
as
select * from Books 
where Books.ID_Record = @ID

go

drop proc [dbo].[GetMovieById]

go

create proc [dbo].[GetMovieById]
@ID int
as
select * from Movies
where Movies.ID_Record = @ID

go

drop proc [dbo].[GetUserById]

go

create proc [dbo].[GetUserById]
@ID int
as
select * from Logins 
where Logins.ID_Login = @ID

go