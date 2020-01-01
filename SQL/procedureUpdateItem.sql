CREATE PROCEDURE UpdateItem(
    @itemId AS INT,
    @newItemName AS VARCHAR(50),
    @newItemInfo AS TEXT,
    @newOnSale AS BIT,
    @newItemPrice AS MONEY,
    @newCatId AS INT
) AS
BEGIN
 UPDATE Items
 SET itemName = @newItemName,
    itemInfo = @newItemInfo,
    onSale = @newOnSale,
    itemPrice = @newItemPrice,
    catId = @newCatId
WHERE itemId = @itemId
END; 
