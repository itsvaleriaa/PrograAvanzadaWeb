CREATE PROCEDURE Update_Products
    @Id UNIQUEIDENTIFIER OUTPUT,
    @Name VARCHAR(100),
    @Description VARCHAR(100),
    @Price float,
    @Photo VARBINARY(MAX),
    @Updated_at DateTime,
    @this_id_user_create UNIQUEIDENTIFIER
AS
BEGIN
    BEGIN TRY
        UPDATE Products
        SET 
            Name = @Name,
            Description=@Description,
            Price=@Price,
            Photo=@Photo,
            updated_at=@Updated_at,
            this_id_user_create = @This_id_user_create
        WHERE Id = @Id;
        SELECT @Id;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
