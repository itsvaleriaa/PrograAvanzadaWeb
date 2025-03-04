CREATE TABLE [dbo].[ProductsCategories]
(
	[IdProduct] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [IdCategory] INT NOT NULL, 
    CONSTRAINT [FK_ProductsCategories_ToProducts] FOREIGN KEY (IdProduct) REFERENCES Products(Id), 
    CONSTRAINT [FK_ProductsCategories_ToCategories] FOREIGN KEY (IdCategory) REFERENCES Categories(Id)
)
