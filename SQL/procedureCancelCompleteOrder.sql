CREATE PROCEDURE CancelCompleteOrder(
    @orderId AS INT
) AS
DELETE FROM ItemOrders 
FROM ItemOrders
INNER JOIN Orders
ON ItemOrders.orderId = Orders.orderId
WHERE ItemOrders.orderId = @orderId;

DELETE FROM Orders
WHERE Orders.orderId = @orderId;