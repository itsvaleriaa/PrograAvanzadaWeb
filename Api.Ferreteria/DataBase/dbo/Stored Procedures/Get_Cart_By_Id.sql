CREATE PROCEDURE Get_Cart_By_Id
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    BEGIN TRY
        SELECT 
            Id,
            IdUser,
            DateCreated
            FROM Carts
        WHERE Id = @Id;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
