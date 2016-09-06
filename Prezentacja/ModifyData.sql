Insert Into qa.Product Values ('940', 'HL Road Pedal', 'PD-R853', 'False', 'True', 'Silver/Black', '500', '375', 
'35.9596', '80.9900', NULL, NULL, 'G  ', '149.00', '1', 'R ', 'H ', NULL, '13', '70', '5/30/2013 12:00:00 AM', 
NULL, NULL, '44e96967-ab99-41ed-8b41-5bc70a5ca1a9', '2/8/2014 10:03:55 AM')


Update qa.Product 
Set Color = 'Red'
Where ProductID = 940


Update qa.Product 
Set StandardCost = 35.9596--27.568--
Where ProductID = 940