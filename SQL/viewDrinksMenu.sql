CREATE VIEW DrinksMenu AS 
SELECT itemPicFile, itemName, itemInfo, itemPrice
FROM Items
WHERE Items.catId = 1;





