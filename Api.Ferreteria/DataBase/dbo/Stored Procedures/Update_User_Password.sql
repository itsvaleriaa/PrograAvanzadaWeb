CREATE PROCEDURE [dbo].[Update_User_Password]
    @Email VARCHAR(50),
    @PasswordHash VARCHAR(255),
    @Updated_at DateTime
AS
BEGIN
    BEGIN TRY
        UPDATE Users
        SET 
            PasswordHash=@PasswordHash,
            Updated_at=@Updated_at
        WHERE Email = @Email;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;

