CREATE VIEW Get_ProductsCategories_View
AS
SELECT PC.IdProduct, PC.IdCategory, C.Name
FROM ProductsCategories AS PC
INNER JOIN Categories AS C ON C.Id=PC.IdCategory
