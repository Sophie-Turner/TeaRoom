CREATE VIEW CurrentOrders AS

SELECT orderTime, tableNum, itemName, quantity
FROM Orders

INNER JOIN ItemOrders
ON Orders.orderId = ItemOrders.orderId

INNER JOIN Items
ON ItemOrders.itemId = Items.itemId

WHERE completed = 0
GROUP BY tableNum, orderTime, itemName, quantity;