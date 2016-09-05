Feature: DataFlow

@mytag
Scenario: DataFlow
Given I run SQL query from Product.sql
	And following output directory: C:\TestFiles
	And following file name: Products
	Then I write results from [Production].[Product] into CSV file
	And I write results from file into qa.Product table