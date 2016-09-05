Feature: CheckCounts

@mytag
Scenario: Check count and particular row in Person table
#Given I load data
When table Person.person has 19972 rows
	Then following row is present: FirstName = 'Rob' AND LastName = 'Walters' in following table Person.person with amount of 1
