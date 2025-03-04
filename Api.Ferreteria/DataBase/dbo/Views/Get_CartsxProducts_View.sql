CREATE VIEW Get_CartsxProducts_View
AS
SELECT
CP.IdCart,
CP.IdProduct,
P.Name AS ProductName
FROM CartsxProducts AS CP
INNER JOIN Products AS P ON CP.IdProduct=P.Id