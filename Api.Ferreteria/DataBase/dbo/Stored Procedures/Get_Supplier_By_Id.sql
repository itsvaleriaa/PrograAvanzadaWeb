CREATE PROCEDURE Get_Supplier_By_Id
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    BEGIN TRY
        SELECT 
            Id, 
            Name, 
            City, 
            Address, 
            PhoneNumber, 
            Email, 
            Representative, 
            This_id_user_create
        FROM Suppliers
        WHERE Id = @Id;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;