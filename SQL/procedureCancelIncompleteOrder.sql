CREATE PROCEDURE CancelIncompleteOrder AS

DELETE FROM ItemOrders 
FROM ItemOrders
INNER JOIN Orders
ON ItemOrders.orderId = Orders.orderId
WHERE tableNum = 0;

DELETE FROM Orders
WHERE tableNum = 0;

