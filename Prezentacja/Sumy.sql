Update qa.Product 
Set StandardCost = 35.9596--27.568--
Where ProductID = 940



Select SUM (PP.StandardCost) - SUM (QA.StandardCost) AS Result
From [Production].[Product] PP
Inner Join [qa].[Product] QA
ON PP.ProductID = QA.ProductID



Select SUM (SRC.StandardCost) - SUM (TRG.StandardCost) AS Result
                                            From Production.Product SRC
                                            Inner Join qa.Product TRG
                                            ON SRC.productId = TRG.productId



											
Select SUM (SRC.ListPrice) - SUM (TRG.ListPrice) AS Result
                                            From Production.Product SRC
                                            Inner Join qa.Product TRG
                                            ON SRC.productId = TRG.productId