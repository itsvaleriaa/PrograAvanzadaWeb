CREATE PROCEDURE [dbo].[Get_People_By_Id]
    @Id int
AS
BEGIN
    BEGIN TRY
        SELECT 
            Id, 
            Name, 
			FirstLastName,
            City, 
            Address, 
            PhoneNumber, 
            created_at
        FROM People
        WHERE Id = @Id;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;