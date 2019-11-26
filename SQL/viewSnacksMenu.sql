CREATE VIEW SnacksMenu AS
SELECT itemPicFile, itemName, itemInfo, itemPrice
FROM Item
WHERE Item.catId = 2;



