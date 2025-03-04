CREATE PROCEDURE Add_CartsxProducts
    @IdProduct UNIQUEIDENTIFIER,
    @Amount int,
    @IdCart UNIQUEIDENTIFIER OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO CartsxProducts (IdCart,IdProduct,Amount)
        VALUES (@IdCart,@IdProduct,@Amount);
        COMMIT TRANSACTION;
		SELECT @IdCart;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;