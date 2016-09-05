Select * From [HumanResources].[Employee]

Select * From Person.person


Select * From qa.Demo


Select * From [Production].[Product]
Select * From [qa].[Product]

Select * From [Person].[CountryRegion]

Insert Into [Person].[CountryRegion]
Values ('AA', NULL, '2008-04-30')

Select * From [Production].[Product]
Except 
Select * From [qa].[Product]


Select * From [qa].[Product]
Except
Select * From [Production].[Product]


Select * From Production.Product Where ProductID = 940
Select * From qa.Product Where ProductID = 940


(Select ProductID, Name, ProductNumber, MakeFlag, FinishedGoodsFlag, Color, SafetyStockLevel, ReorderPoint, StandardCost, ListPrice, Size, SizeUnitMeasureCode, WeightUnitMeasureCode, Weight, DaysToManufacture, ProductLine, Class, Style, ProductSubcategoryID, ProductModelID, SellStartDate, SellEndDate, DiscontinuedDate From Production.Product
Except
Select ProductID, Name, ProductNumber, MakeFlag, FinishedGoodsFlag, Color, SafetyStockLevel, ReorderPoint, StandardCost, ListPrice, Size, SizeUnitMeasureCode, WeightUnitMeasureCode, Weight, DaysToManufacture, ProductLine, Class, Style, ProductSubcategoryID, ProductModelID, SellStartDate, SellEndDate, DiscontinuedDate From qa.Product)
Union ALL
(Select ProductID, Name, ProductNumber, MakeFlag, FinishedGoodsFlag, Color, SafetyStockLevel, ReorderPoint, StandardCost, ListPrice, Size, SizeUnitMeasureCode, WeightUnitMeasureCode, Weight, DaysToManufacture, ProductLine, Class, Style, ProductSubcategoryID, ProductModelID, SellStartDate, SellEndDate, DiscontinuedDate From qa.Product
Except
Select ProductID, Name, ProductNumber, MakeFlag, FinishedGoodsFlag, Color, SafetyStockLevel, ReorderPoint, StandardCost, ListPrice, Size, SizeUnitMeasureCode, WeightUnitMeasureCode, Weight, DaysToManufacture, ProductLine, Class, Style, ProductSubcategoryID, ProductModelID, SellStartDate, SellEndDate, DiscontinuedDate From Production.Product)


Update qa.Product 
Set Color = 'Red'
Where ProductID = 940


Update qa.Product 
Set StandardCost = 35.9596--27.568--
Where ProductID = 940


Insert Into qa.Product Values ('940', 'HL Road Pedal', 'PD-R853', 'False', 'True', 'Silver/Black', '500', '375', 
'35.9596', '80.9900', NULL, NULL, 'G  ', '149.00', '1', 'R ', 'H ', NULL, '13', '70', '5/30/2013 12:00:00 AM', 
NULL, NULL, '44e96967-ab99-41ed-8b41-5bc70a5ca1a9', '2/8/2014 10:03:55 AM')


Select SUM (PP.StandardCost) - SUM (QA.StandardCost) AS Result
From [Production].[Product] PP
Inner Join [qa].[Product] QA
ON PP.ProductID = QA.ProductID

Delete From qa.Product
Where ProductID = 940

Select Count (*) From qa.Product 
