CREATE PROCEDURE Update_Inventories
	@Id int OUTPUT,
    @Stock int,
    @Updated_at DateTime,
    @This_id_user_create UNIQUEIDENTIFIER
AS
BEGIN
    BEGIN TRY
        UPDATE Inventories
        SET 
            Stock=@Stock,
            updated_at=@Updated_at,
            this_id_user_create=@This_id_user_create
        WHERE Id = @Id;
        SELECT @Id;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;