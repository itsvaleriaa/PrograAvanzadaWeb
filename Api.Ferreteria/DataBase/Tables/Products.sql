CREATE TABLE [dbo].[Products]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(50) NOT NULL, 
    [Price] FLOAT NOT NULL, 
    [Photo] VARBINARY(MAX) NULL, 
    [created_at] DATETIME NOT NULL, 
    [updated_at] DATETIME NULL, 
    [this_id_user_create] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_Products_ToUsers] FOREIGN KEY (this_id_user_create) REFERENCES Users(Id)
)
