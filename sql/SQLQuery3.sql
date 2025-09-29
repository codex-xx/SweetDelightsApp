-- Create database
IF DB_ID('SweetDelightsDB') IS NULL
    CREATE DATABASE SweetDelightsDB;
GO

USE SweetDelightsDB;
GO

-- Drop tables if they already exist (optional safety)
IF OBJECT_ID('CakeTopping','U') IS NOT NULL DROP TABLE CakeTopping;
IF OBJECT_ID('CakeIcing','U') IS NOT NULL DROP TABLE CakeIcing;
IF OBJECT_ID('OrderDetails','U') IS NOT NULL DROP TABLE OrderDetails;
IF OBJECT_ID('Delivery','U') IS NOT NULL DROP TABLE Delivery;
IF OBJECT_ID('Billing','U') IS NOT NULL DROP TABLE Billing;
IF OBJECT_ID('Customization','U') IS NOT NULL DROP TABLE Customization;
IF OBJECT_ID('Orders','U') IS NOT NULL DROP TABLE Orders;
IF OBJECT_ID('Topping','U') IS NOT NULL DROP TABLE Topping;
IF OBJECT_ID('Icing','U') IS NOT NULL DROP TABLE Icing;
IF OBJECT_ID('Cake','U') IS NOT NULL DROP TABLE Cake;
IF OBJECT_ID('Customer','U') IS NOT NULL DROP TABLE Customer;

-- Customer
CREATE TABLE Customer (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    ContactNumber NVARCHAR(20),
    Email NVARCHAR(100),
    StreetAddress NVARCHAR(150),
    Barangay NVARCHAR(100),
    City NVARCHAR(100)
);

-- Cake
CREATE TABLE Cake (
    CakeID INT IDENTITY(1,1) PRIMARY KEY,
    CakeType NVARCHAR(100) NOT NULL,
    Price DECIMAL(10,2) NOT NULL
);

-- Icing
CREATE TABLE Icing (
    IcingID INT IDENTITY(1,1) PRIMARY KEY,
    IcingType NVARCHAR(100) NOT NULL,
    Price DECIMAL(10,2) NOT NULL
);

-- Topping
CREATE TABLE Topping (
    ToppingID INT IDENTITY(1,1) PRIMARY KEY,
    ToppingType NVARCHAR(100) NOT NULL,
    Price DECIMAL(10,2) NOT NULL
);

-- Orders (Order is reserved)
CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT NOT NULL,
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
    OrderType NVARCHAR(50),
    TotalAmount DECIMAL(12,2) NOT NULL DEFAULT 0.00,
    Status NVARCHAR(50) DEFAULT 'Pending',
    CONSTRAINT FK_Orders_Customer FOREIGN KEY (CustomerID)
        REFERENCES Customer(CustomerID)
);

-- Customization
CREATE TABLE Customization (
    CustomizationID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT NOT NULL,
    CakeID INT NOT NULL,
    PersonalizedMessage NVARCHAR(200),
    MixedFlavors BIT DEFAULT 0,
    SpecialInstructions NVARCHAR(500),
    CONSTRAINT FK_Customization_Order FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    CONSTRAINT FK_Customization_Cake FOREIGN KEY (CakeID) REFERENCES Cake(CakeID)
);

-- Billing
CREATE TABLE Billing (
    BillingID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT NOT NULL,
    PaymentMethod NVARCHAR(50),
    AmountPaid DECIMAL(12,2) DEFAULT 0.00,
    PaymentDate DATETIME,
    CONSTRAINT FK_Billing_Order FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);

-- Delivery
CREATE TABLE Delivery (
    DeliveryID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT NOT NULL,
    DeliveryType NVARCHAR(50),
    DeliveryDate DATE,
    DeliveryTime TIME,
    StreetAddress NVARCHAR(150),
    Barangay NVARCHAR(100),
    City NVARCHAR(100),
    CONSTRAINT FK_Delivery_Order FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);

-- OrderDetails
CREATE TABLE OrderDetails (
    OrderID INT NOT NULL,
    CakeID INT NOT NULL,
    Quantity INT DEFAULT 1,
    Subtotal DECIMAL(12,2) DEFAULT 0.00,
    CONSTRAINT PK_OrderDetails PRIMARY KEY (OrderID, CakeID),
    CONSTRAINT FK_OrderDetails_Order FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    CONSTRAINT FK_OrderDetails_Cake FOREIGN KEY (CakeID) REFERENCES Cake(CakeID)
);

-- CakeIcing
CREATE TABLE CakeIcing (
    CakeID INT NOT NULL,
    IcingID INT NOT NULL,
    CONSTRAINT PK_CakeIcing PRIMARY KEY (CakeID, IcingID),
    CONSTRAINT FK_CakeIcing_Cake FOREIGN KEY (CakeID) REFERENCES Cake(CakeID),
    CONSTRAINT FK_CakeIcing_Icing FOREIGN KEY (IcingID) REFERENCES Icing(IcingID)
);

-- CakeTopping
CREATE TABLE CakeTopping (
    CakeID INT NOT NULL,
    ToppingID INT NOT NULL,
    CONSTRAINT PK_CakeTopping PRIMARY KEY (CakeID, ToppingID),
    CONSTRAINT FK_CakeTopping_Cake FOREIGN KEY (CakeID) REFERENCES Cake(CakeID),
    CONSTRAINT FK_CakeTopping_Topping FOREIGN KEY (ToppingID) REFERENCES Topping(ToppingID)
);
