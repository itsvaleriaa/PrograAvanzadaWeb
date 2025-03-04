CREATE PROCEDURE Get_Inventory_By_Id
	@Id int
AS
BEGIN
    BEGIN TRY
        SELECT 
        I.Id,
        I.IdProduct,
        P.Name AS ProductName,
        I.IdSupplier,
        S.Name AS SuppliersName,
        I.Stock,
        I.created_at,
        I.updated_at
        FROM Inventories AS I
        INNER JOIN Products AS P ON I.IdProduct=P.Id
        INNER JOIN Suppliers AS S ON I.IdSupplier=S.Id
        WHERE I.Id = @Id;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;