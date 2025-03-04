CREATE PROCEDURE Update_CartService
    @IdCart UNIQUEIDENTIFIER OUTPUT,
    @IdService int
AS
BEGIN
    BEGIN TRY
        UPDATE CartService
        SET 
            IdService=@IdService
        WHERE IdCart = @IdCart;
        SELECT @IdCart;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
