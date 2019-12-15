CREATE PROCEDURE CreateNewItem(
    @itemName AS VARCHAR(50),
    @itemInfo AS TEXT,
    @onSale AS BIT,
    @itemPrice AS MONEY,
    @catId AS INT
    ) AS
BEGIN
    INSERT INTO Items(itemName, itemInfo, onSale, itemPrice, catId)
    VALUES
        (@itemName, @itemInfo, @onSale, @itemPrice, @catId);
END;
