CREATE VIEW Get_People_View
AS
SELECT Id,
COALESCE(Name, ' ') + COALESCE(FirstLastName, '') AS Name,
City,
Address,
PhoneNumber
FROM People
