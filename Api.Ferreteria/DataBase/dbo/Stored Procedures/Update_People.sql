CREATE PROCEDURE Update_People
    @Id int OUTPUT,
    @Name VARCHAR(100),
    @FirstLastName VARCHAR(85),
    @City VARCHAR(100),
    @Address VARCHAR(255),
    @PhoneNumber INT
AS
BEGIN
    BEGIN TRY
        UPDATE People
        SET 
            Name = @Name,
            FirstLastName=@FirstLastName,
            City = @City,
            Address = @Address,
            PhoneNumber = @PhoneNumber
        WHERE Id = @Id;
        SELECT @Id;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
