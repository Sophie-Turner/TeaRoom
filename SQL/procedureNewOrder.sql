CREATE PROCEDURE newOrder(@tableNum AS INT) AS
--Can I pass in the total price from other SQL procedure?--
--This should probably be a transaction--
INSERT INTO Orders(tableNum, completed) --also totalPrice--
VALUES (@tableNum, 0);



