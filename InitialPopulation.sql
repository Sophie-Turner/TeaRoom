INSERT INTO Category(catName, catInfo, catPicFile)
VALUES 
       ('Snacks', 'Freshly made snacks', 'scone.JPG'),
       ('Drinks', 'Refreshing beverages', 'rooibos.JPG');

INSERT INTO Item(itemName, itemInfo, itemPicFile, onSale, itemPrice, catName)
VALUES 
        ('Scone', '1 scone with jam and cream in separate containers. Ingredients: wheat flour, baking powder, caster sugar, sea salt, coconut oil, almond milk.', 'scone.JPG', 1, 1.20, 'Snacks'),
        ('Carrot cake', '1 slice. Ingredients: flour, sugar, egg, vegetable oil, bicarbonate of soda, salt, cinnamon, carrots, walnuts.', 'cake.JPG', 1, 2.00, 'Snacks'),
        ('Locomotive shaped biscuit', '1 biscuit. Ingredients: butter, caster sugar, egg yolk, vanilla extract, flour.', 'biscuit.PNG', 1, 0.50, 'Snacks'),
        ('Nuts & raisins', 'Bowl of mixed nuts & raisins. Ingredients: hazelnuts, peanuts, cashew nuts, brazil nuts, raisins.', 'nuts.JPG', 1, 1.50, 'Snacks'),
        ('Water', '300 mL glass of still water.', 'water.JPG', 1, 0.00, 'Drinks'),
        ('Tea', 'Tea in a tea car shaped teapot. Contains caffeine.', 'tea.JPG', 1, 1.20, 'Drinks'),
        ('Coffee', 'Ground coffee in a 300 mL cup. Contains caffeine.', 'coffee.PNG', 1, 1.50, 'Drinks'),
        ('Rooibos tea', 'Caffeine-free tea made from the rooibos (redbush) plant.', 'rooisbos.JPG', 1, 1.20, 'Drinks');

INSERT INTO Staff(staffName)
VALUES
        ('Chris Mayne'), ('Colin Flowers'), ('Theresa May'), ('Shirley Isthebest');