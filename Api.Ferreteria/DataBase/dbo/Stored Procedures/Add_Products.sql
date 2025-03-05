CREATE PROCEDURE [dbo].[Add_Products]
	@Name VARCHAR(100),
    @Description VARCHAR(100),
    @Price float,
    @Photo VARBINARY(MAX),
    @Created_at DateTime,
    @this_id_user_create UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Id UNIQUEIDENTIFIER = NEWID();

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Products(Id, Name, Description, Price, Photo, created_at, this_id_user_create)
        VALUES (@Id, @Name, @Description, @Price, @Photo, @Created_at, @this_id_user_create);
        COMMIT TRANSACTION;
		SELECT @Id;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;