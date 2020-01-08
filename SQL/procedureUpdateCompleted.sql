CREATE PROCEDURE UpdateCompleted(
    @orderTime AS DATETIME
) AS
 UPDATE Orders
 SET completed = 1
 WHERE orderTIme = @orderTime;
 