CREATE PROCEDURE Update_User
    @Id UNIQUEIDENTIFIER OUTPUT,
    @Email VARCHAR(50),
    @PasswordHash VARCHAR(255),
    @Updated_at DateTime
AS
BEGIN
    BEGIN TRY
        UPDATE Users
        SET 
            Email=@Email,
            PasswordHash=@PasswordHash,
            Updated_at=@Updated_at
        WHERE Id = @Id;
        SELECT @Id;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;

