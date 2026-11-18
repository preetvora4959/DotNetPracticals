CREATE TABLE Products
(
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    ProductName VARCHAR(100) NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL
);

INSERT INTO Products (ProductName, Quantity, Price)
VALUES
('Laptop', 10, 55000),
('Keyboard', 25, 1200),
('Mouse', 30, 600),
('Monitor', 15, 8500);