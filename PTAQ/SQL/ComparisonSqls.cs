using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.SQL
{
    static class ComparisonSqls
    {
        public static string ExceptForProducts = @"Select Count (*) As NrOfDiffs From
                                                (
                                                (Select ProductID, Name, ProductNumber, MakeFlag, FinishedGoodsFlag, Color, SafetyStockLevel, ReorderPoint, StandardCost, ListPrice, Size, SizeUnitMeasureCode, WeightUnitMeasureCode, Weight, DaysToManufacture, ProductLine, Class, Style, ProductSubcategoryID, ProductModelID, SellStartDate, SellEndDate, DiscontinuedDate From Production.Product
                                                Except
                                                Select ProductID, Name, ProductNumber, MakeFlag, FinishedGoodsFlag, Color, SafetyStockLevel, ReorderPoint, StandardCost, ListPrice, Size, SizeUnitMeasureCode, WeightUnitMeasureCode, Weight, DaysToManufacture, ProductLine, Class, Style, ProductSubcategoryID, ProductModelID, SellStartDate, SellEndDate, DiscontinuedDate From qa.Product)
                                                Union ALL
                                                (Select ProductID, Name, ProductNumber, MakeFlag, FinishedGoodsFlag, Color, SafetyStockLevel, ReorderPoint, StandardCost, ListPrice, Size, SizeUnitMeasureCode, WeightUnitMeasureCode, Weight, DaysToManufacture, ProductLine, Class, Style, ProductSubcategoryID, ProductModelID, SellStartDate, SellEndDate, DiscontinuedDate From qa.Product
                                                Except
                                                Select ProductID, Name, ProductNumber, MakeFlag, FinishedGoodsFlag, Color, SafetyStockLevel, ReorderPoint, StandardCost, ListPrice, Size, SizeUnitMeasureCode, WeightUnitMeasureCode, Weight, DaysToManufacture, ProductLine, Class, Style, ProductSubcategoryID, ProductModelID, SellStartDate, SellEndDate, DiscontinuedDate From Production.Product)
                                                ) AS SQ";

        public static string DiffsOnSums = @"Select SUM (SRC.{0}) - SUM (TRG.{0}) AS Result
                                            From {1} SRC
                                            Inner Join {2} TRG
                                            ON SRC.{3} = TRG.{3}";



        public static string CountFromGivenTable = @"Select NationalIDNumber, LoginId, JobTitle From [HumanResources].[Employee]
                                                    Where JobTitle = '{0}' And BirthDate = '{1}' And Gender = 'M'";
        public const string Top20Employees = "Select TOP 20 * From [HumanResources].[Employee]";
        public const string Products = "Select * From {0}";
    }
}
