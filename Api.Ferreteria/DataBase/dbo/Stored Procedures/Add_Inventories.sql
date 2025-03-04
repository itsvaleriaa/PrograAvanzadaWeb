CREATE PROCEDURE Add_Inventories
	@IdProduct UNIQUEIDENTIFIER,
    @IdSupplier UNIQUEIDENTIFIER,
    @Stock int,
    @Created_At DateTime,
    @This_id_user_create UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Inventories(IdProduct, IdSupplier,Stock,created_at,this_id_user_create)
        VALUES (@IdProduct,@IdSupplier,@Stock,@Created_At,@This_id_user_create);
        COMMIT TRANSACTION;
		SELECT SCOPE_IDENTITY() AS Id;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;