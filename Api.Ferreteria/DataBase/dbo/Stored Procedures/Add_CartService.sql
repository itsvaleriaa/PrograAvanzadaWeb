CREATE PROCEDURE Add_CartService
    @IdProduct UNIQUEIDENTIFIER,
    @IdService int,
    @IdCart UNIQUEIDENTIFIER OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO CartService(IdCart,IdService)
        VALUES (@IdCart,@IdService);
        COMMIT TRANSACTION;
		SELECT @IdCart;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;