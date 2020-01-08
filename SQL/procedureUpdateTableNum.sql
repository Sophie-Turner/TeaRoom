CREATE PROCEDURE UpdateTableNum(
    @tableNum AS INT
) AS
BEGIN
    UPDATE Orders
    SET Orders.tableNum = @tableNum
    WHERE Orders.tableNum = 0  
END; 

