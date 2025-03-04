CREATE PROCEDURE Get_CartsxProducts_By_IdCart
    @IdCart UNIQUEIDENTIFIER
AS
BEGIN
    BEGIN TRY
        SELECT 
            CP.IdCart, 
            CP.IdProduct,
            P.Name AS ProductName,
            CP.Amount
        FROM CartsxProducts AS CP
        INNER JOIN Products AS P ON CP.IdProduct=P.Id
        WHERE IdCart = @IdCart;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;