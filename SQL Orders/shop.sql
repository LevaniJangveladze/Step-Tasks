
CREATE DATABASE ShopDb;
GO

USE ShopDb;
GO

CREATE TABLE Categories
(
    Id   INT IDENTITY (1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);

CREATE TABLE Products
(
    Id         INT IDENTITY (1,1) PRIMARY KEY,
    Name       NVARCHAR(100)  NOT NULL,
    Price      DECIMAL(10, 2) NOT NULL,
    CategoryId INT            NOT NULL FOREIGN KEY REFERENCES Categories (Id)
);

INSERT INTO Categories (Name)
VALUES ('Electronics'),
       ('Furniture'),
       ('Toys'),
       ('Books');

INSERT INTO Products (Name, Price, CategoryId)
VALUES ('Laptop', 1400.00, 1),
       ('Headphones', 399.00, 1),
       ('Monitor', 380.00, 1),
       ('Keyboard', 95.00, 1),
       ('DivanKreslo', 500.00, 2),
       ('Magida', 320.00, 2),
       ('Takhti', 180.00, 2),
       ('DatviMashka', 30.00, 3),
       ('Puzzle', 25.00, 3),
       ('DedaEna', 20.00, 4);

-- Products grouped by category, only categories with more than 2 products
SELECT c.Name        AS Category,
       COUNT(*)      AS ProductCount,
       SUM(p.Price)  AS Total,
       MIN(p.Price)  AS Cheapest,
       MAX(p.Price)  AS MostExpensive
FROM Products p
         JOIN Categories c ON p.CategoryId = c.Id
GROUP BY c.Name
HAVING COUNT(*) > 2;



CREATE TABLE Orders
(
    Id        INT IDENTITY (1,1) PRIMARY KEY,
    Status    NVARCHAR(20) NOT NULL,
    OrderDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE OrderItems
(
    Id        INT IDENTITY (1,1) PRIMARY KEY,
    OrderId   INT            NOT NULL FOREIGN KEY REFERENCES Orders (Id),
    ProductId INT            NOT NULL FOREIGN KEY REFERENCES Products (Id),
    Quantity  INT            NOT NULL,
    Price     DECIMAL(10, 2) NOT NULL
);

INSERT INTO Orders (Status)
VALUES ('Pending'),
       ('Pending'),
       ('Shipped'),
       ('Shipped'),
       ('Cancelled');

INSERT INTO OrderItems (OrderId, ProductId, Quantity, Price)
VALUES (1, 1, 1, 1400.00),
       (1, 4, 2, 95.00),
       (2, 2, 1, 399.00),
       (3, 5, 1, 500.00),
       (3, 6, 2, 320.00),
       (3, 9, 3, 25.00),
       (4, 3, 1, 380.00),
       (5, 10, 1, 20.00);

-- Orders grouped by status: how many orders, how many items, total value
SELECT o.Status                    AS Status,
       COUNT(DISTINCT o.Id)        AS OrderCount,
       COUNT(oi.Id)                AS ItemCount,
       SUM(oi.Quantity * oi.Price) AS TotalValue
FROM Orders o
         JOIN OrderItems oi ON oi.OrderId = o.Id
GROUP BY o.Status;