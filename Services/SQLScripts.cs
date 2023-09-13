namespace WebApplicationAngularWebPortal.Services;

public class SqlScripts
{
	public const string CreateTables =
		@"
CREATE TABLE Customers (ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,  CreatedDate DATETIME NOT NULL, CustomerName NVARCHAR(255) NOT NULL, Address NVARCHAR(500));

CREATE TABLE Products (ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,    ProductName NVARCHAR(255) NOT NULL,    Description NVARCHAR(500),    Category INT,    ProdiceSize INT,    Quantity INT,    Price DECIMAL(18, 2));

CREATE TABLE Orders (ID INT IDENTITY(1, 1) PRIMARY KEY, CustomerID INT,    ProductID INT,    Comment NVARCHAR(500),    TotalCost DECIMAL(18, 2),    Status INT,    FOREIGN KEY (CustomerID) REFERENCES Customers(ID),    FOREIGN KEY (ProductID) REFERENCES Products(ID));";

	public const string InsertData =
		@"
INSERT INTO Customers (CreatedDate, CustomerName, Address, ID) VALUES ('2023-01-01', 'Alice', '123 Main St',1);
INSERT INTO Customers (CreatedDate, CustomerName, Address, ID) VALUES ('2023-01-02', 'Bob', '456 Park Ave',2);
INSERT INTO Customers (CreatedDate, CustomerName, Address, ID) VALUES ('2023-01-03', 'Charlie', '789 Elm St',3);
INSERT INTO Customers (CreatedDate, CustomerName, Address, ID) VALUES ('2023-01-04', 'Dave', '101 Maple St',4);
INSERT INTO Customers (CreatedDate, CustomerName, Address, ID) VALUES ('2023-01-05', 'Eve', '202 Oak St',5);
INSERT INTO Customers (CreatedDate, CustomerName, Address, ID) VALUES ('2023-01-06', 'Frank', '303 Cedar St',6);

INSERT INTO Products (ProductName, Description, Category, ProdiceSize, Quantity, Price, ID) VALUES ('Apple', 'Fresh Apples', 0, 2, 100, 1.20,1);
INSERT INTO Products (ProductName, Description, Category, ProdiceSize, Quantity, Price, ID) VALUES ('Laptop', 'Gaming Laptop', 1, 3, 20, 1200.00,2);
INSERT INTO Products (ProductName, Description, Category, ProdiceSize, Quantity, Price, ID) VALUES ('Shirt', 'Cotton T-Shirt', 2, 1, 50, 20.00,3);
INSERT INTO Products (ProductName, Description, Category, ProdiceSize, Quantity, Price, ID) VALUES ('Table', 'Wooden Table', 3, 3, 10, 250.00,4);
INSERT INTO Products (ProductName, Description, Category, ProdiceSize, Quantity, Price, ID) VALUES ('Face Cream', 'Moisturizing Face Cream', 4, 1, 30, 35.00,5);
";

	public const string InsertOrders =
		@"
	INSERT INTO Orders (CustomerID, ProductID, Comment, TotalCost, Status, ID) VALUES (1, 1, 'I love apples!', 1.20, 1, 1);
	INSERT INTO Orders (CustomerID, ProductID, Comment, TotalCost, Status, ID) VALUES (1, 2, 'Need a new laptop for work.', 1200.00, 2, 2);
	INSERT INTO Orders (CustomerID, ProductID, Comment, TotalCost, Status, ID) VALUES (1, 3, 'Looks comfortable.', 20.00, 1, 3);
	INSERT INTO Orders (CustomerID, ProductID, Comment, TotalCost, Status, ID) VALUES (1, 4, 'For dining room.', 250.00, 1, 4);
	INSERT INTO Orders (CustomerID, ProductID, Comment, TotalCost, Status, ID) VALUES (1, 5, 'For skincare routine.', 35.00, 1, 5);

		
	INSERT INTO Orders (CustomerID, ProductID, Comment, TotalCost, Status, ID) VALUES (2, 1, 'For healthy snacking.', 1.20, 1, 6);
	INSERT INTO Orders (CustomerID, ProductID, Comment, TotalCost, Status, ID) VALUES (2, 3, 'I need new clothes.', 20.00, 3, 7);
	INSERT INTO Orders (CustomerID, ProductID, Comment, TotalCost, Status, ID) VALUES (2, 5, 'Winter skincare.', 35.00, 1, 8);
	INSERT INTO Orders (CustomerID, ProductID, Comment, TotalCost, Status, ID) VALUES (2, 2, 'For my son.', 1200.00, 1, 9);
	INSERT INTO Orders (CustomerID, ProductID, Comment, TotalCost, Status, ID) VALUES (2, 4, 'For the patio.', 250.00, 4, 10);
";
}