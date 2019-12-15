CREATE PROCEDURE updateQuantity(
    @itemId AS INT,
    @orderId AS INT
) AS
BEGIN
    UPDATE ItemOrders
    SET quantity = quantity + 1
    WHERE ItemOrders.orderId = @orderId
    AND ItemOrders.itemId = @itemId  
END; 

