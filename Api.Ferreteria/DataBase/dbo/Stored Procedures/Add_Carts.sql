CREATE PROCEDURE Add_Carts
    @Id UNIQUEIDENTIFIER OUTPUT,
    @IdUser UNIQUEIDENTIFIER,
    @DateCreated DateTime
AS
BEGIN
    SET NOCOUNT ON;
    SET @Id = NEWID();

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Carts(Id,IdUser, DateCreated)
        VALUES (@Id, @IdUser, @DateCreated);
        COMMIT TRANSACTION;
		SELECT @Id;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;