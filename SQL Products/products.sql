
Create TABLE Products (
                          Name NVARCHAR(50) NOT NULL,
                          Price DECIMAL(10, 2),
                          Quantity INT,
                          Category NVARCHAR(50)
);

INSERT INTO Products (Name, Price, Quantity, Category)
VALUES ('Iphone 18', 1850.00, 1, 'Mobile'),
       ('Galaxy Fold', 1200.00, 3, 'Mobile'),
       ('MacBook Air', 1400.00, 5, 'Laptop'),
       ('AirPods Pro', 250.00, 12, 'Audio'),
       ('Logitech MX Master', 95.50, 8, 'Accessories');

SELECT * FROM Products;

SELECT Name, Price, Quantity FROM Products;

SELECT * FROM Products WHERE Price > 1000;

SELECT * FROM Products ORDER BY Price DESC;
