INSERT INTO Orders(tableNum, completed, totalPrice)
VALUES (0, 0, 0);
SELECT * FROM Orders;

INSERT INTO ItemOrders(orderId, itemId, quantity)
VALUES (3, 1, 1), (3, 5, 2);
SELECT * FROM ItemOrders;

SELECT itemName, quantity, itemPrice
FROM Items

INNER JOIN ItemOrders
ON Items.itemId = ItemOrders.itemId

INNER JOIN Orders
ON ItemOrders.orderId = Orders.orderId

WHERE tableNum = 0;