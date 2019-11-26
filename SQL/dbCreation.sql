DROP TABLE itemOrder;
DROP TABLE item;
DROP TABLE Orders;
DROP TABLE Category;
DROP TABLE Staff;

CREATE TABLE Staff
(
 staffId SMALLINT NOT NULL IDENTITY,
 staffName VARCHAR(50) NOT NULL,
 CONSTRAINT pk_Staff PRIMARY KEY (staffId)
);

CREATE TABLE Category
(
 catId INT NOT NULL IDENTITY,
 catName VARCHAR(50) NOT NULL,
 catInfo TEXT,
 catPicFile VARCHAR(200),
 CONSTRAINT pk_Category PRIMARY KEY (catId)
);

CREATE TABLE Orders
(
 orderId INT NOT NULL IDENTITY,
 tableNum TINYINT NOT NULL,
 completed BIT NOT NULL DEFAULT 0,
 totalPrice SMALLMONEY NOT NULL,
 orderTime DATETIME NOT NULL DEFAULT (GETDATE()),
 staffId SMALLINT NOT NULL,
 CONSTRAINT pk_Orders PRIMARY KEY (orderId)
);

CREATE TABLE Item
(
 itemId SMALLINT NOT NULL IDENTITY,
 itemName VARCHAR(50) NOT NULL,
 itemInfo TEXT,
 itemPicFile VARCHAR(200),
 onSale BIT NOT NULL DEFAULT 0,
 itemPrice SMALLMONEY NOT NULL,
 catId INT NOT NULL,
 CONSTRAINT pk_Item PRIMARY KEY (itemId)
);

CREATE TABLE ItemOrder
(
 orderId INT NOT NULL,
 itemId SMALLINT NOT NULL,
 quantity TINYINT NOT NULL,
 CONSTRAINT pk_ItemOrder PRIMARY KEY (orderId, itemId)
);

ALTER TABLE Orders
 ADD CONSTRAINT fk_Orders
 FOREIGN KEY (staffId) REFERENCES Staff(staffId);

ALTER TABLE Item
 ADD CONSTRAINT fk_Item
 FOREIGN KEY (catId) REFERENCES Category(catId);
        
ALTER TABLE ItemOrder
 ADD CONSTRAINT fk_ItemOrder_Orders
 FOREIGN KEY (orderId) REFERENCES Orders(orderId);

ALTER TABLE ItemOrder 
 ADD CONSTRAINT fk_ItemOrder_Item
 FOREIGN KEY (itemId) REFERENCES Item(itemId);