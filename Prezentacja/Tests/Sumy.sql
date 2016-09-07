Select * From Production.Product


Select SUM (SRC.StandardCost) - SUM (TRG.StandardCost) AS Result
                                            From Production.Product SRC
                                            Inner Join [qa].[Product_Example_3] TRG
                                            ON SRC.productId = TRG.productId

											
Select SUM (SRC.ListPrice) - SUM (TRG.ListPrice) AS Result
                                            From Production.Product SRC
                                            Inner Join [qa].[Product_Example_3] TRG
                                            ON SRC.productId = TRG.productId


Select SUM (SRC.[Weight]) - SUM (TRG.[Weight]) AS Result
                                            From Production.Product SRC
                                            Inner Join [qa].[Product_Example_3] TRG
                                            ON SRC.productId = TRG.productId






Select * From Production.Product Where ProductID = 940
Select * From [qa].[Product_Example_3] Where ProductID = 940