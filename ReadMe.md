## Native Software Test

This is a repo for Native Software Test for a technical interview. 

### Questions
NOTE:  Add plenty of comments to your solution.
       Do not add any more libraries to the project.  

#### C# Task 1: Edit Products.cshtml to show a list of products in the selected category. 
           Use javascript to add <option> tags to the select (one for each product returned in the JSON).  
		   You will need to complete the linq query in the ProductsInCategory method (using a join and where as appropriate).

Please see in HomeController line number 16 to 49.

#### C# Task 2: Make a new controller method and change the view to edit the price of the product selected above.
           You may want to add a button to click that loads your edit form.

Route URL: http://localhost:55474/Home/Products

#### C# Task 3: Make a new controller method and create/change the view to assign a product to any number of categories.

Route URL: http://localhost:<55474>/ProductAssign/ProductList

***************************************************************************************************************
***************************************************************************************************************

#### SQL Task 1: Write a query to list product codes for products that are in the Veg category.
**** Answer ***

SELECT pd.*, cat.Name FROM ProductInCategory as pic
JOIN Category as cat
ON pic.CategoryID = cat.Id
JOIN Product as pd
ON pic.ProductID = pd.Id
WHERE pic.CategoryID = 2

***************************************************************************************************************
***************************************************************************************************************

#### SQL Task 2: Write an update to increase the price for all fruit by 10%

**** Answer ***

UPDATE Product 
SET Price = (Price * 1.1)
-- SET Price = 100
SELECT pd.*, cat.Name FROM ProductInCategory as pic
JOIN Category as cat
ON pic.CategoryID = cat.Id
JOIN Product as pd
ON pic.ProductID = pd.Id
WHERE pic.CategoryID = 1 

***************************************************************************************************************
***************************************************************************************************************

#### SQL Task 3: The Fruit and Veg company has 3 branches, AUK (Auckland), TGA (Tauranga) and HAM (Hamilton). 
            We want to store inventory data in the database.  
			Add a new table named "Stock" to hold ProductID, BranchCode and QuantityInStock. 

***************************************************************************************************************
**** Answer ***

CREATE TABLE CompanyBranches
(
	BranchCode int Primary Key,
	CityCode varchar(255), 
	CityName varchar(255) 
);

Insert into CompanyBranches (BranchCode, CityCode, CityName)
Values 
(1, 'AUK', 'Auckland'),
(2, 'TGA', 'Tauranga'),
(3, 'HAM', 'Hamilton');

select * from CompanyBranches

CREATE TABLE Stock
(
	Id int Primary Key,
	ProductID int, 
	BranchCode int,  
	QuantityInStock int 
);



SELECT * FROM Stock

***************************************************************************************************************
***************************************************************************************************************

#### SQL Task 4: Enter some data into this table.

***************************************************************************************************************
**** Answer ***

Insert into Stock (Id, ProductID, BranchCode, QuantityInStock)
Values 
(1, 1, 1, 100),
(2, 2, 2, 200),
(3, 3, 3, 300);

***************************************************************************************************************
***************************************************************************************************************


#### SQL Task 5: Explain why we're storing inventory data in the new Stock table rather than adding branch columns 
to the product table.

Answer: I think Inventory (Stock) table is for the Warehouse and auditing. So we can keep track of the 
        how many stocks left over on each branch as a whole company. 

***************************************************************************************************************


#### SQL Task 6: Could you improve how we store stock-in-branch?  Explain (no need to make your suggested changes)

Answer: According to my experiences, I will change both ProductID and BranchCode as the Foreign keys. 
        This makes easier to use with Entity Framework. It will make faster performance while we 
		are loading the data from database. 

