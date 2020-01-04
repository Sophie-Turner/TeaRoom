CREATE PROCEDURE AddToOrder (
    @itemId AS INT
) AS
DECLARE @thisOrderId INT;

    IF NOT EXISTS (
        SELECT * FROM Orders
        WHERE tableNum = 0
    )
    BEGIN
        INSERT INTO Orders(tableNum, completed, totalPrice)
        VALUES (0,0,0);
    END;

SET @thisOrderId = (
    SELECT orderId
    FROM Orders
    WHERE tableNum = 0
)

IF EXISTS (
    SELECT * FROM ItemOrders
    WHERE ItemOrders.orderId = @thisOrderId
    AND ItemOrders.itemId = @itemId
)
    BEGIN
        UPDATE ItemOrders
        SET quantity = quantity + 1
        WHERE ItemOrders.orderId = @thisOrderId
        AND ItemOrders.itemId = @itemId;
    END
ELSE 
    BEGIN
        INSERT INTO ItemOrders(orderId, itemId, quantity)
        VALUES (@thisOrderId, @itemId, 1);
    END;







 


