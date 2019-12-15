CREATE PROCEDURE updateOrderPrice(
    @itemId AS INT,
    @orderId AS INT
) AS
BEGIN
    UPDATE Orders
    SET Orders.totalPrice = Orders.totalPrice + (ItemOrders.quantity * Items.itemPrice)
    FROM Orders

    INNER JOIN ItemOrders
    ON Orders.orderId = ItemOrders.orderId

    INNER JOIN Items
    ON ItemOrders.itemId = Items.itemId

    WHERE ItemOrders.orderId = @orderId
    AND ItemOrders.itemId = @itemId  
END; 

