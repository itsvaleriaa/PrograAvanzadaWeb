CREATE TABLE [dbo].[Services]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(50) NOT NULL, 
    [Schedule] VARCHAR(50) NOT NULL, 
    [Price] FLOAT NOT NULL, 
    [Photo] VARBINARY(MAX) NULL, 
    [created_at] DATETIME NOT NULL, 
    [updated_at] DATETIME NULL, 
    [this_id_user_create] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_Services_ToUsers] FOREIGN KEY (this_id_user_create) REFERENCES Users(Id)
)
