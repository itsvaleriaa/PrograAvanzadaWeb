CREATE PROCEDURE Update_CartsxProducts
    @IdCart UNIQUEIDENTIFIER OUTPUT,
    @IdProduct UNIQUEIDENTIFIER,
    @Amount int
AS
BEGIN
    BEGIN TRY
        UPDATE CartsxProducts
        SET 
            Amount=@Amount
        WHERE IdCart = @IdCart AND IdProduct=@IdProduct;
        SELECT @IdCart;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
