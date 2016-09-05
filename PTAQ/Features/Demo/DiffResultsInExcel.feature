Feature: DiffResultsInExcel

@mytag
Scenario: 1.0 CreateSourceAndTargetFiles
	Given following output directory: C:\TestFiles
	And following file name: SourceProducts
		Then I write results from [Production].[Product] into CSV file
	Given following output directory: C:\TestFiles
	And following file name: TargetProducts
		Then I write results from [qa].[Product] into CSV file


@mytag
Scenario: 2.0 CompareTwoFilesAndWriteDifferencesIntoExcel
	Given following output directory: C:\TestFiles
	Then I use xls to compare SourceProducts.csv with TargetProducts.csv




#@mytag
#Scenario: CreateTargetFile
#	Given following output directory: C:\TestFiles
#	And following file name: TargetProducts
#		Then I write results from [qa].[Product] into ExcelFile