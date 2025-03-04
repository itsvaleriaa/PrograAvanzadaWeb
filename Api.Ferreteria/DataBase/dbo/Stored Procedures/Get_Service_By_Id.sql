CREATE PROCEDURE Get_Service_By_Id
    @Id int
AS
BEGIN
    BEGIN TRY
        SELECT 
            Id, 
            Name, 
            Description,
            Schedule,
            Price,
            Photo,
            created_at,
            updated_at,
            this_id_user_create
        FROM Services
        WHERE Id = @Id;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
