Feature: DataFlowAndDataQualityTest


@mytag
Scenario: 1.0 VerifyData
Given table qa.Product has 504 rows
    When following row is present: SafetyStockLevel = 1000 in following table qa.Product with amount of 156
	And following row is present: SafetyStockLevel = 500 And StandardCost > 200 in following table qa.Product with amount of 45
	Then I compare Data using Except query


@mytag
Scenario Outline: 2.0 VerifySums
	And I verify Sums on <Column> for following source table <SourceTable> and following target table <TargetTable> using join on productId column

Examples:
| Column       | SourceTable        | TargetTable |
| StandardCost | Production.Product | qa.Product  |
| ListPrice    | Production.Product | qa.Product  |
| Weight       | Production.Product | qa.Product  |


