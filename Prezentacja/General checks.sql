Select * From production.Product 
Select * From qa.Product 


Select COUNT(*) From production.Product 
Select COUNT(*) From qa.Product 

Select * From production.Product 
Where SafetyStockLevel = 500 And StandardCost > 200

Select * From qa.Product 
Where SafetyStockLevel = 500 And StandardCost > 200
