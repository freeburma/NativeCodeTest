USE [NativeSoftwareTest]
GO

SELECT * FROM Category
SELECT * FROM Product
SELECT * FROM ProductInCategory


-- SQL Task 1: Write a query to list product codes for products that are in 
-- the Veg category.

SELECT pd.*, cat.Name FROM ProductInCategory as pic
JOIN Category as cat
ON pic.CategoryID = cat.Id
JOIN Product as pd
ON pic.ProductID = pd.Id
WHERE pic.CategoryID = 1

-- SQL Task 2: Write an update to increase the price for all fruit by 10%
UPDATE Product 
SET Price = (Price * 1.1)
-- SET Price = 100
SELECT pd.*, cat.Name FROM ProductInCategory as pic
JOIN Category as cat
ON pic.CategoryID = cat.Id
JOIN Product as pd
ON pic.ProductID = pd.Id
WHERE pic.CategoryID = 1 


--CREATE TABLE CompanyBranches
--(
--	BranchCode int Primary Key,
--	CityCode varchar(255), 
--	CityName varchar(255) 
--);

--Insert into CompanyBranches (BranchCode, CityCode, CityName)
--Values 
--(1, 'AUK', 'Auckland'),
--(2, 'TGA', 'Tauranga'),
--(3, 'HAM', 'Hamilton');

select * from CompanyBranches

CREATE TABLE Stock
(
	Id int Primary Key,
	ProductID int, 
	BranchCode int,  
	QuantityInStock int 
);

SELECT * FROM Category
SELECT * FROM Product
select * from CompanyBranches


--Insert into Stock (Id, ProductID, BranchCode, QuantityInStock)
--Values 
--(1, 1, 1, 100),
--(2, 2, 2, 200),
--(3, 3, 3, 300);