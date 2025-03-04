CREATE PROCEDURE Get_Category_By_Id
	@Id int
AS
BEGIN
    BEGIN TRY
        SELECT 
            Id, 
            Name
        FROM Categories
        WHERE Id = @Id;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;