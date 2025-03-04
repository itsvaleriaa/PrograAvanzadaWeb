CREATE PROCEDURE Update_Carts
    @Id UNIQUEIDENTIFIER OUTPUT,
    @IdUser UNIQUEIDENTIFIER,
    @DateCreated DateTime
AS
BEGIN
    BEGIN TRY
        UPDATE Carts
        SET 
            DateCreated=@DateCreated
        WHERE Id = @Id AND IdUser=@IdUser;
        SELECT @Id;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;