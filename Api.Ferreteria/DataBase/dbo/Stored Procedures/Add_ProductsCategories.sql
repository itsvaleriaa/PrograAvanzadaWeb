CREATE PROCEDURE Add_ProductsCategories
    @IdProduct UNIQUEIDENTIFIER OUTPUT,
    @IdCategory int
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO ProductsCategories(IdProduct, IdCategory)
        VALUES (@IdProduct, @IdCategory);
        COMMIT TRANSACTION;
		SELECT @IdProduct;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;