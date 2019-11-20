INSERT INTO Category(catName, catInfo, catPicFile)
VALUES 
       ('Snacks', 'Freshly made snacks', 'biscuit.png'),
       ('Drinks', 'Refreshing beverages', 'tea.jpg');

INSERT INTO Item(itemName, itemInfo, itemPicFile, onSale, itemPrice, catId)
VALUES 
        ('Scone', '1 scone with jam and cream in separate containers. Ingredients: wheat flour, baking powder, caster sugar, sea salt, coconut oil, almond milk.', 'scone.jpg', 1, 1.20, 2),
        ('Carrot cake', '1 slice. Ingredients: flour, sugar, egg, vegetable oil, bicarbonate of soda, salt, cinnamon, carrots, walnuts.', 'cake.jpg', 1, 2.00, 2),
        ('Locomotive shaped biscuit', '1 biscuit. Ingredients: butter, caster sugar, egg yolk, vanilla extract, flour.', 'biscuit.png', 1, 0.50, 2),
        ('Nuts & raisins', 'Bowl of mixed nuts & raisins. Ingredients: hazelnuts, peanuts, cashew nuts, brazil nuts, raisins.', 'nuts.jpg', 1, 1.50, 2),
        ('Water', '300 mL glass of still water.', 'water.jpg', 1, 0.00, 1),
        ('Tea', 'Tea in a tea car shaped teapot. Contains caffeine.', 'tea.jpg', 1, 1.20, 1),
        ('Coffee', 'Ground coffee in a 300 mL cup. Contains caffeine.', 'coffee.png', 1, 1.50, 1),
        ('Rooibos tea', 'Caffeine-free tea made from the rooibos (redbush) plant.', 'rooisbos.jpg', 1, 1.20, 1);

INSERT INTO Staff(staffName)
VALUES
        ('Chris Mayne'), ('Colin Flowers'), ('Theresa May'), ('Shirley Isthebest');
