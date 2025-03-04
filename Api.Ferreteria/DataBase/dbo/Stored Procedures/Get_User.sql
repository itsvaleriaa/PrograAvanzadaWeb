CREATE PROCEDURE Get_User
	@Email VARCHAR(100)
AS
BEGIN
    BEGIN TRY
        SELECT 
            Id,
            IdPerson,
            Email,
            PasswordHash,
            Created_at,
            Updated_at
        FROM Users
        WHERE Email = @Email;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;