Feature: DownloadDataFromTable

@mytag
Scenario Outline: Dwonload specific data from HumanResources.Employee table
	Given following output directory: C:\Files\TestFilesTarget 
	And following file name: DataFromHumanResources.txt
	Then I store all logins for <JobTitle> and <BirthDate> which are male

Examples:
| JobTitle									| BirthDate			  |
|   Senior Tool Designer					|   1974-12-23        |
|   Design Engineer							|   1959-03-11        |
|   Research and Development Manager        |   1987-02-24        |
|   Senior Tool Designer					|   1978-01-17        |