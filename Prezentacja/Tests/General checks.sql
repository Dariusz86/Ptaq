Select * From production.Product 
Select * From [qa].[Product_Example_1]


Select COUNT(*) As SourceNumberOfRows From production.Product 
Select COUNT(*) AS TargetNumberOfRows From [qa].[Product_Example_1]

Select * From production.Product 
Where SafetyStockLevel = 500 And StandardCost > 200

Select * From [qa].[Product_Example_1]
Where SafetyStockLevel = 500 And StandardCost > 200
