CREATE VIEW CurrentOrders AS
SELECT orderTime, tableNum, itemName
--Do an join through composite table to get items in order--
FROM Orders
INNER JOIN ItemOrder 
ON Orders.orderId = ItemOrder.orderId
INNER JOIN Item
ON ItemOrder.itemId = Item.itemId
WHERE completed = 0
ORDER BY orderTime;

