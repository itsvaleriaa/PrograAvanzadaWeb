CREATE PROCEDURE Get_Product_By_Id
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    BEGIN TRY
        SELECT 
            Id, 
            Name,
            Description,
            Price,
            Photo,
            created_at,
            updated_at,
            This_id_user_create
        FROM Products
        WHERE Id = @Id;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
