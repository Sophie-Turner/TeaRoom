CREATE PROCEDURE newItemOrder(
    @orderId AS INT, 
    @itemId AS INT, 
    @quantity AS INT
    ) AS
    --Maybe this should be a transaction--
    INSERT INTO ItemOrder(orderId, itemId, Quantity)
    VALUES (@orderId, @itemId, @quantity);



