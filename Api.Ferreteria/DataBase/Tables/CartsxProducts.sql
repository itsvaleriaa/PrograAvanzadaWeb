CREATE TABLE [dbo].[CartsxProducts]
(
	[IdCart] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [IdProduct] UNIQUEIDENTIFIER NOT NULL, 
    [Amount] INT NOT NULL, 
    CONSTRAINT [FK_CartsxProducts_ToCarts] FOREIGN KEY (IdCart) REFERENCES Carts(Id), 
    CONSTRAINT [FK_CartsxProducts_ToProducts] FOREIGN KEY (IdProduct) REFERENCES Products(Id)
)
