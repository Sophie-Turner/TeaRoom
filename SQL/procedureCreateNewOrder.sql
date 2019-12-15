CREATE PROCEDURE CreateNewOrder AS
BEGIN
    DELETE FROM Orders 
    WHERE Orders.tableNum = 0;

    INSERT INTO Orders(tableNum, completed, totalPrice)
    VALUES
        (0, 0, 0);
END;
