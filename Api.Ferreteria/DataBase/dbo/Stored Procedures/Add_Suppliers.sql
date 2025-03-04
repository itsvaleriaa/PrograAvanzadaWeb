CREATE PROCEDURE Add_Suppliers
    @Name VARCHAR(100),
    @City VARCHAR(100),
    @Address VARCHAR(255),
    @PhoneNumber INT,
    @Email VARCHAR(255),
    @Representative VARCHAR(100) = NULL,
    @this_id_user_create UNIQUEIDENTIFIER,
    @Id UNIQUEIDENTIFIER OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Id = NEWID();

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Suppliers (Id, Name, City, Address, PhoneNumber, Email, Representative, This_id_user_create)
        VALUES (@Id, @Name, @City, @Address, @PhoneNumber, @Email, @Representative, @this_id_user_create);
        COMMIT TRANSACTION;
		SELECT @Id;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;