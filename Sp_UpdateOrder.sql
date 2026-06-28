CREATE OR ALTER PROCEDURE dbo.uspUpdateOrder
(
    @JsonData NVARCHAR(MAX)
)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @OrderHeaderID UNIQUEIDENTIFIER;

        SET @OrderHeaderID = JSON_VALUE(@JsonData, '$.OrderHeaderID');

        IF NOT EXISTS (
            SELECT 1 
            FROM OrderHeader
            WHERE OrderHeaderID = @OrderHeaderID
        )
        BEGIN
            ;THROW 50001, 'Order not found', 1;
        END

        UPDATE OrderHeader
        SET
            OrderDate = JSON_VALUE(@JsonData, '$.OrderDate'),
            ShipCity = JSON_VALUE(@JsonData, '$.ShipCity'),
            ShipAddress = JSON_VALUE(@JsonData, '$.ShipAddress'),
            CustomerID = JSON_VALUE(@JsonData, '$.CustomerID')
        WHERE OrderHeaderID = @OrderHeaderID;

        DELETE FROM OrderDetail
        WHERE OrderHeaderID = @OrderHeaderID;

        INSERT INTO OrderDetail
        (
            OrderDetailID,
            OrderHeaderID,
            ProductID,
            UnitPrice,
            Quantity,
			IsDeleted
        )
        SELECT
            OrderDetailID,
            @OrderHeaderID,
            ProductID,
            UnitPrice,
            Quantity,
			0
        FROM OPENJSON(@JsonData, '$.OrderDetails')
        WITH (
            OrderDetailID UNIQUEIDENTIFIER '$.OrderDetailID',
            ProductID UNIQUEIDENTIFIER '$.ProductID',
            UnitPrice DECIMAL(18,2) '$.UnitPrice',
            Quantity INT '$.Quantity'
        );

        COMMIT TRANSACTION;

    END TRY
    BEGIN CATCH

        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;

    END CATCH
END
GO