Select * From production.Product 
Select * From qa.Product 


Select COUNT(*) From production.Product 
Select COUNT(*) From qa.Product 

Where SafetyStockLevel = 500 And StandardCost > 200
