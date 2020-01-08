
CREATE PROCEDURE CancelCompleteOrder(
    @orderTIme AS DATETIME
) AS
DELETE FROM ItemOrders 
FROM ItemOrders
INNER JOIN Orders
ON ItemOrders.orderId = Orders.orderId
WHERE orderTime = @orderTime;

DELETE FROM Orders
WHERE orderTime = @orderTIme;