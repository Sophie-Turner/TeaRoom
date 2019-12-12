
CREATE TABLE Categories
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
 tableNum INT NOT NULL,
 completed BIT NOT NULL DEFAULT 0,
 totalPrice MONEY NOT NULL,
 orderTime DATETIME NOT NULL DEFAULT (GETDATE()),
 staffId INT NOT NULL,
 CONSTRAINT pk_Orders PRIMARY KEY (orderId)
);

CREATE TABLE Items
(
 itemId INT NOT NULL IDENTITY,
 itemName VARCHAR(50) NOT NULL,
 itemInfo TEXT,
 itemPicFile VARCHAR(200),
 onSale BIT NOT NULL DEFAULT 0,
 itemPrice MONEY NOT NULL,
 catId INT NOT NULL,
 CONSTRAINT pk_Item PRIMARY KEY (itemId)
);

CREATE TABLE ItemOrders
(
 orderId INT NOT NULL,
 itemId INT NOT NULL,
 quantity INT NOT NULL,
 CONSTRAINT pk_ItemOrder PRIMARY KEY (orderId, itemId)
);


ALTER TABLE Items
 ADD CONSTRAINT fk_Items
 FOREIGN KEY (catId) REFERENCES Categories(catId);
        
ALTER TABLE ItemOrders
 ADD CONSTRAINT fk_ItemOrders_Orders
 FOREIGN KEY (orderId) REFERENCES Orders(orderId);

ALTER TABLE ItemOrders 
 ADD CONSTRAINT fk_ItemOrder_Items
 FOREIGN KEY (itemId) REFERENCES Items(itemId);