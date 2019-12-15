CREATE PROCEDURE UpdateTableNum(
    @orderId AS INT,
    @tableNum AS INT
) AS
BEGIN
    UPDATE Orders
    SET Orders.tableNum = @tableNum
    WHERE Orders.orderId = @orderId  
END; 

