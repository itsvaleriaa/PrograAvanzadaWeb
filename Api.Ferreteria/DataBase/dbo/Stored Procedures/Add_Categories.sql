﻿CREATE PROCEDURE Add_Categories
	@Name VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Categories(Name)
        VALUES (@Name);
        COMMIT TRANSACTION;
		SELECT SCOPE_IDENTITY() AS Id;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;