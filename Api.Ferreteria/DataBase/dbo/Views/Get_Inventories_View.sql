CREATE VIEW Get_Inventories_View
AS
SELECT I.Id,
I.IdProduct,
P.Name AS ProductName,
I.IdSupplier,
S.Name AS SuppliersName,
I.Stock,
I.updated_at
FROM Inventories AS I
INNER JOIN Products AS P ON I.IdProduct=P.Id
INNER JOIN Suppliers AS S ON I.IdSupplier=S.Id