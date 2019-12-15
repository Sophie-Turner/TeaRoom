CREATE PROCEDURE DeleteIncompleteOrder
AS
    DELETE FROM Orders 
    WHERE tableNum = 0;


