CREATE PROCEDURE CreateNewOrder AS

    IF NOT EXISTS (
         SELECT * FROM Orders
        WHERE tableNum = 0
    )
        INSERT INTO Orders(tableNum, completed, totalPrice)
        VALUES (0,0,0);


 


