CREATE TABLE [dbo].[People]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] VARCHAR(50) NOT NULL, 
    [FirstLastName] VARCHAR(70) NOT NULL, 
    [City] VARCHAR(50) NOT NULL,
    [Address] VARCHAR(150) NOT NULL, 
    [PhoneNumber] INT NULL, 
    [created_at] DATETIME NOT NULL
)
