CREATE PROCEDURE UpdateCompleted(
    @orderId AS INT
) AS
 UPDATE Orders
 SET completed = 1
 WHERE Orders.orderId = @orderId;