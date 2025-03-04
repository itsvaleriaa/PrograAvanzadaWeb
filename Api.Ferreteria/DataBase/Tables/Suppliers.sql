CREATE TABLE [dbo].[Suppliers]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [City] VARCHAR(90) NOT NULL,
    [Address] VARCHAR(80) NOT NULL, 
    [PhoneNumber] INT NOT NULL, 
    [Email] VARCHAR(50) NOT NULL, 
    [Representative] VARCHAR(50) NULL, 
    [this_id_user_create] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_Suppliers_ToUsers] FOREIGN KEY (this_id_user_create) REFERENCES Users(Id)
)
