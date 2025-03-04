CREATE TABLE [dbo].[Users]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [IdPerson] INT NOT NULL, 
    [Email] VARCHAR(50) NOT NULL, 
    [PasswordHash] VARCHAR(255) NOT NULL, 
    [Created_at] DATETIME NULL, 
    [Updated_at] DATETIME NULL, 
    CONSTRAINT [FK_Users_ToPeople] FOREIGN KEY (IdPerson) REFERENCES People(Id)
)
