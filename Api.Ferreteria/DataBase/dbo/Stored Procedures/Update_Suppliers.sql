CREATE PROCEDURE Update_Suppliers
    @Id UNIQUEIDENTIFIER,
    @Name VARCHAR(100),
    @City VARCHAR(100),
    @Address VARCHAR(255),
    @PhoneNumber INT,
    @Email VARCHAR(255),
    @Representative VARCHAR(100) = NULL,
    @This_id_user_create UNIQUEIDENTIFIER,
    @UpdatedSupplierId UNIQUEIDENTIFIER OUTPUT
AS
BEGIN
    BEGIN TRY
        UPDATE Suppliers
        SET 
            Name = @Name,
            City = @City,
            Address = @Address,
            PhoneNumber = @PhoneNumber,
            Email = @Email,
            Representative = @Representative,
            This_id_user_create = @This_id_user_create
        WHERE Id = @Id;
        SELECT @Id;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;