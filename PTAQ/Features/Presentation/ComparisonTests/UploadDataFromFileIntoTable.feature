Feature: UploadDataFromFileIntoTable


@mytag
Scenario: Upload data from file
	Given I run SQL query from HRTable.sql
	And following output directory: C:\TestFilesTarget 
	And following file name: DataFromHumanResources.txt
		Then I write results from file into qa.HRTable table