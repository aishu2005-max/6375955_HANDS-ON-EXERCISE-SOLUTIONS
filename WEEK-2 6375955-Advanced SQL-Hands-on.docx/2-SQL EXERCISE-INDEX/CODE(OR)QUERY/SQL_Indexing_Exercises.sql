
use OnlineRetailStore;
go
-- Drop tables if they exist
DROP TABLE IF EXISTS OrderDetails;
DROP TABLE IF EXISTS Orders;
DROP TABLE IF EXISTS Products;
DROP TABLE IF EXISTS Customers;

-- Create Customers table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    Name VARCHAR(100),
    Region VARCHAR(50)
);

-- Create Products table
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);

-- Create Orders table
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

-- Create OrderDetails table
CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
-- Insert into Customers
INSERT INTO Customers (CustomerID, Name, Region) VALUES
(1, 'Alice', 'North'),
(2, 'Bob', 'South'),
(3, 'Charlie', 'East'),
(4, 'Diana', 'West');

-- Insert into Products
INSERT INTO Products (ProductID, ProductName, Category, Price) VALUES
(1, 'Laptop', 'Electronics', 1200.00),
(2, 'Tablet', 'Electronics', 500.00),
(3, 'Chair', 'Furniture', 150.00),
(4, 'Desk', 'Furniture', 300.00);

-- Insert into Orders
INSERT INTO Orders (OrderID, CustomerID, OrderDate) VALUES
(1, 1, '2023-01-15'),
(2, 2, '2023-02-20'),
(3, 3, '2023-03-25'),
(4, 4, '2023-04-30');

-- Insert into OrderDetails
INSERT INTO OrderDetails (OrderDetailID, OrderID, ProductID, Quantity) VALUES
(1, 1, 1, 1),   -- Alice ordered 1 Laptop
(2, 2, 2, 2),   -- Bob ordered 2 Tablets
(3, 3, 3, 1),   -- Charlie ordered 1 Chair
(4, 4, 4, 3);   -- Diana ordered 3 Desks

-- Exercise 1: Non-Clustered Index
SELECT * FROM Products WHERE ProductName = 'Laptop';
CREATE NONCLUSTERED INDEX IX_Products_ProductName ON Products(ProductName);
SELECT * FROM Products WHERE ProductName = 'Laptop';

-- Exercise 2: Clustered Index
SELECT * FROM Orders WHERE OrderDate = '2023-01-15';
-- Uncomment next two lines to replace clustered index (only if allowed)
-- ALTER TABLE Orders DROP CONSTRAINT PK__Orders__OrderID;
-- CREATE CLUSTERED INDEX IX_Orders_OrderDate ON Orders(OrderDate);
SELECT * FROM Orders WHERE OrderDate = '2023-01-15';

-- Exercise 3: Composite Index
SELECT * FROM Orders WHERE CustomerID = 1 AND OrderDate = '2023-01-15';
CREATE NONCLUSTERED INDEX IX_Orders_CustomerID_OrderDate ON Orders(CustomerID, OrderDate);
SELECT * FROM Orders WHERE CustomerID = 1 AND OrderDate = '2023-01-15';
