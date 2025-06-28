USE OnlineRetailStore;

-- CREATING PRODUCTS TABLE
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);

--INSERTING SAMPLE DATA INTO PRODUCTS TABLE
INSERT INTO Products VALUES
(1, 'iPhone 15', 'Electronics', 1000),
(2, 'Samsung Galaxy', 'Electronics', 950),
(3, 'MacBook Pro', 'Electronics', 2000),
(4, 'Dell XPS', 'Electronics', 1800),
(5, 'Cotton T-shirt', 'Apparel', 30),
(6, 'Silk Shirt', 'Apparel', 45),
(7, 'Leather Jacket', 'Apparel', 120),
(8, 'Denim Jeans', 'Apparel', 50),
(9, 'Blender', 'Home Appliance', 80),
(10, 'Microwave Oven', 'Home Appliance', 120),
(11, 'Air Fryer', 'Home Appliance', 120)

--SELECTING ALL ROWS AND COLUMNS FROM TABLE
SELECT * FROM PRODUCTS;

--USING ROW_NUMBER() TO ASSIGN A UNIQUE RANK WITHIN EACH CATEGORY.
SELECT 
    ProductID, ProductName, Category, Price,
    ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum
FROM Products;

--USING RANK() AND DENSE_RANK() TO COMPARE HOW TIES ARE HANDLED
SELECT 
    ProductID, ProductName, Category, Price,
    RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS Rank
FROM Products;

SELECT 
    ProductID, ProductName, Category, Price,
    DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRank
FROM Products;

--FIND TOP 3 MOST EXPENSIVE PRODUCTS IN EACH CATEGORY USING DIFFERENT RANKING FUNCTIONS.
WITH RankedProducts AS (
    SELECT *,
           ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum
    FROM Products
)
SELECT * 
FROM RankedProducts
WHERE RowNum <= 3;


