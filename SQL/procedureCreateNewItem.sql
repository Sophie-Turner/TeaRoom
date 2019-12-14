CREATE PROCEDURE CreateNewItem(
    @itemName AS VARCHAR(50),
    @itemInfo AS TEXT,
    @itemPicFile AS VARCHAR(200),
    @onSale AS BIT,
    @itemPrice AS MONEY,
    @catId AS INT
    ) AS
BEGIN
    INSERT INTO Items(itemName, itemInfo, itemPicFile, onSale, itemPrice, catId)
    VALUES
        (@itemName, @itemInfo, @itemPicFile, @onSale, @itemPrice, @catId);
END;