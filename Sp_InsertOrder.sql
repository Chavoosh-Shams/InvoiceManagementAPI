CREATE OR ALTER PROCEDURE dbo.uspInsertOrder
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

        SELECT
            @OrderHeaderID = OrderHeaderID
        FROM OPENJSON(@JsonData)
        WITH
        (
            OrderHeaderID UNIQUEIDENTIFIER '$.OrderHeaderID'
        );

        INSERT INTO OrderHeader
        (
            OrderHeaderID,
            OrderDate,
            ShipCity,
            ShipAddress,
            CustomerID,
            IsDeleted
        )
        SELECT
            OrderHeaderID,
            OrderDate,
            ShipCity,
            ShipAddress,
            CustomerID,
            0
        FROM OPENJSON(@JsonData)
        WITH
        (
            OrderHeaderID UNIQUEIDENTIFIER '$.OrderHeaderID',
            OrderDate DATETIME2 '$.OrderDate',
            ShipCity NVARCHAR(200) '$.ShipCity',
            ShipAddress NVARCHAR(500) '$.ShipAddress',
            CustomerID UNIQUEIDENTIFIER '$.CustomerID'
        );

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
        WITH
        (
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

        DECLARE @ErrorMessage NVARCHAR(MAX);
        SET @ErrorMessage = ERROR_MESSAGE();

        RAISERROR(@ErrorMessage, 16, 1);

    END CATCH
END
GO