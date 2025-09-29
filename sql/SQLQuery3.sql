USE SweetDelight;
GO

INSERT INTO Cake (CakeType, Price) VALUES
('Classic Chocolate Cake', 800.00),
('Vanilla Buttercream Cake', 750.00),
('Red Velvet Cake', 950.00),
('Black Forest Cake', 1100.00),
('Ube Halaya Cake', 900.00);

INSERT INTO Icing (IcingType, Price) VALUES
('Chocolate Ganache', 120.00),
('Vanilla Buttercream', 100.00),
('Cream Cheese Frosting', 140.00),
('Whipped Cream', 90.00),
('Fondant Finish', 200.00);

INSERT INTO Topping (ToppingType, Price) VALUES
('Fresh Strawberries', 150.00),
('Chocolate Shavings', 80.00),
('Macarons (4 pcs)', 200.00),
('Oreo Crumbs', 70.00),
('Gold Sprinkles', 120.00);

INSERT INTO CakeIcing (CakeID, IcingID) VALUES (1, 1);
INSERT INTO CakeIcing (CakeID, IcingID) VALUES (2, 2);
INSERT INTO CakeIcing (CakeID, IcingID) VALUES (3, 3);
INSERT INTO CakeIcing (CakeID, IcingID) VALUES (4, 4);
INSERT INTO CakeIcing (CakeID, IcingID) VALUES (5, 5);
INSERT INTO CakeTopping (CakeID, ToppingID) VALUES (1, 1);
INSERT INTO CakeTopping (CakeID, ToppingID) VALUES (2, 2);
INSERT INTO CakeTopping (CakeID, ToppingID) VALUES (3, 3);
INSERT INTO CakeTopping (CakeID, ToppingID) VALUES (4, 4);
INSERT INTO CakeTopping (CakeID, ToppingID) VALUES (5, 5);