CREATE VIEW IncompleteOrders AS

SELECT itemName, quantity, itemPrice
FROM Items

INNER JOIN ItemOrders
ON Items.itemId = ItemOrders.itemId

INNER JOIN Orders
ON ItemOrders.orderId = Orders.orderId

WHERE tableNum = 0;