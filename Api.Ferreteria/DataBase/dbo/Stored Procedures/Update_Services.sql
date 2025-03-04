CREATE PROCEDURE Update_Services
    @Id int,
	@Name VARCHAR(100),
    @Description VARCHAR(100),
    @Schedule VARCHAR(100),
    @Price float,
    @Photo VARBINARY(MAX),
    @Updated_at DateTime,
    @this_id_user_create UNIQUEIDENTIFIER
AS
BEGIN
    BEGIN TRY
        UPDATE Services
        SET 
            Name = @Name,
            Description=@Description,
            Schedule=@Schedule,
            Price=@Price,
            Photo=@Photo,
            updated_at=@Updated_at,
            This_id_user_create = @this_id_user_create
        WHERE Id = @Id;
        SELECT @Id;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
