CREATE PROCEDURE Delete_ProductsCategories
    @IdProduct UNIQUEIDENTIFIER OUTPUT,
    @IdCategory int
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;
    BEGIN TRY
        DELETE ProductsCategories
        WHERE IdProduct=@IdProduct AND IdCategory=@IdCategory;
		SELECT @IdProduct;
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        THROW;
    END CATCH
END
