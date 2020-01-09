CREATE VIEW CurrentOrders AS

SELECT Orders.orderId, orderTime, tableNum, itemName, quantity
FROM Orders

INNER JOIN ItemOrders
ON Orders.orderId = ItemOrders.orderId

INNER JOIN Items
ON ItemOrders.itemId = Items.itemId

WHERE completed = 0
AND tableNum != 0
GROUP BY Orders.orderId, tableNum, orderTime, itemName, quantity;