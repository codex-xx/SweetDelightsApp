USE SweetDelightsDB;
GO

-- Insert sample Cakes
INSERT INTO Cake (CakeType, Price) VALUES
('Classic Chocolate Cake', 800.00),
('Vanilla Buttercream Cake', 750.00),
('Red Velvet Cake', 950.00),
('Black Forest Cake', 1100.00),
('Ube Halaya Cake', 900.00);

-- Insert sample Icings
INSERT INTO Icing (IcingType, Price) VALUES
('Chocolate Ganache', 120.00),
('Vanilla Buttercream', 100.00),
('Cream Cheese Frosting', 140.00),
('Whipped Cream', 90.00),
('Fondant Finish', 200.00);

-- Insert sample Toppings
INSERT INTO Topping (ToppingType, Price) VALUES
('Fresh Strawberries', 150.00),
('Chocolate Shavings', 80.00),
('Macarons (4 pcs)', 200.00),
('Oreo Crumbs', 70.00),
('Gold Sprinkles', 120.00);

-- Insert sample Customers (optional)
INSERT INTO Customer (FirstName, LastName, ContactNumber, Email, StreetAddress, Barangay, City) VALUES
('Anna','Santos','09171234567','anna.santos@example.com','123 Mabini St','San Miguel','Makati'),
('Marco','Reyes','09179876543','marco.reyes@example.com','45 Rizal Ave','Poblacion','Quezon City'),
('Liza','Garcia','09175551234','liza.garcia@example.com','Unit 2, 88 Lopez St','Barangay 5','Pasig'),
('John','Dela Cruz','09170001111','john.delacruz@example.com','7 Mabuhay Rd','Barangay 3','Manila'),
('Maya','Lopez','09171112222','maya.lopez@example.com','88 Sampaguita St','Barangay 2','Cebu City');

-- Optionally link a cake to an icing and topping (junction tables)
INSERT INTO CakeIcing (CakeID, IcingID) VALUES (1,1),(1,2);
INSERT INTO CakeTopping (CakeID, ToppingID) VALUES (1,1),(1,2);
