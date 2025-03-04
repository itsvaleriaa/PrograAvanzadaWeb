CREATE PROCEDURE Update_Categories
	@Id int OUTPUT,
    @Name VARCHAR(100)
AS
BEGIN
    BEGIN TRY
        UPDATE Categories
        SET 
            Name = @Name
        WHERE Id = @Id;
        SELECT @Id;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;