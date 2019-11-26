CREATE PROCEDURE ThanksForOrder(@orderId AS INT) AS
SELECT  tableNum, orderId 
FROM Orders
WHERE orderId = @orderId;


