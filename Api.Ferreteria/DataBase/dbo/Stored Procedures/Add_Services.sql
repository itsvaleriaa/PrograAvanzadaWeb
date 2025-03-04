CREATE PROCEDURE Add_Services
	@Name VARCHAR(100),
    @Description VARCHAR(100),
    @Schedule VARCHAR(100),
    @Price float,
    @Photo VARBINARY(MAX),
    @Created_at DateTime,
    @this_id_user_create UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Services(Name, Description,Schedule,Price,Photo,created_at,this_id_user_create)
        VALUES (@Name,@Description,@Schedule,@Price,@Photo,@Created_at,@this_id_user_create);
        COMMIT TRANSACTION;
		SELECT SCOPE_IDENTITY() AS Id;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
