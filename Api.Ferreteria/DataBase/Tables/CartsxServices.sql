CREATE TABLE [dbo].[CartsxServices]
(
	[IdCart] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [IdService] INT NOT NULL, 
    CONSTRAINT [FK_CartsxServices_ToCarts] FOREIGN KEY (IdCart) REFERENCES Carts(Id), 
    CONSTRAINT [FK_CartsxServices_ToServices] FOREIGN KEY (IdService) REFERENCES Services(Id) 
)
