CREATE PROCEDURE [dbo].[Add_User]
    @IdPerson int,
    @Email varchar(50),
    @PasswordHash VARCHAR(255),
    @Created_at DateTime
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Id AS UNIQUEIDENTIFIER=NEWID();
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Users(Id,IdPerson, Email,PasswordHash,Created_at)
        VALUES (@Id,@IdPerson,@Email, @PasswordHash, @Created_At);

        INSERT INTO UsersRoles(IdUser,IdRole)
        VALUES(@Id, 2)
        COMMIT TRANSACTION;
		SELECT @Id;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;