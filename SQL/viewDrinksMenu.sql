CREATE VIEW DrinksMenu AS 
SELECT itemPicFile, itemName, itemInfo, itemPrice
FROM Item
WHERE Item.catId = 1;





