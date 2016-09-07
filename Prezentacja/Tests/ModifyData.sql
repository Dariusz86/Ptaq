Update [qa].[Product_Example_1]
Set Color = 'Red'
Where ProductID = 940

Update [qa].[Product_Example_1]
Set ModifiedDate = '2014-02-08 10:11:36.000'


Insert Into [qa].[Product_Example_2] Values ('940', 'HL Road Pedal', 'PD-R853', 'False', 'True', 'Silver/Black', '500', '375', 
'35.9596', '80.9900', NULL, NULL, 'G  ', '149.00', '1', 'R ', 'H ', NULL, '13', '70', '5/30/2013 12:00:00 AM', 
NULL, NULL, '44e96967-ab99-41ed-8b41-5bc70a5ca1a9', '2/8/2014 10:03:55 AM')


Update [qa].[Product_Example_3]
Set StandardCost = 27.568--35.9596--
Where ProductID = 940


--Insert Into [qa].[Product_Example_3]
--Select * From production.Product


--Select * From [Production].[Product]
--Select * From [qa].[Product_Example_1]