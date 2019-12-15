CREATE PROCEDURE CreateNewItemOrder(
    @orderId AS INT,
    @itemId AS INT,
    @quantity AS INT
    ) AS
BEGIN
    INSERT INTO ItemOrders(orderId, itemId, quantity)
    VALUES
        (@orderId, @itemId, @quantity);
END;


