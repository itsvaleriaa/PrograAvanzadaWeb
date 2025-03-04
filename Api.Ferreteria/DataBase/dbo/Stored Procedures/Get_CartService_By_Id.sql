CREATE PROCEDURE Get_CartService_By_Id
    @IdCart UNIQUEIDENTIFIER
AS
BEGIN
    BEGIN TRY
        SELECT 
            CS.IdCart,
            CS.IdService,
            S.Name AS ServiceName,
            S.Description AS ServiceDescription,
            S.Schedule AS ServiceSchedule, 
            S.Schedule AS ServicePrice
            FROM CartService AS CS
            INNER JOIN Services AS S ON CS.IdService=S.Id
        WHERE IdCart = @IdCart;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;