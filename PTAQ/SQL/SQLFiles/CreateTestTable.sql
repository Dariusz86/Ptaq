IF OBJECT_ID('qa.Demo') IS NOT NULL
	BEGIN
		DROP TABLE qa.Demo;
	END;

CREATE TABLE qa.Demo
	(
	ID int NOT NULL IDENTITY (1,1),
	SourceSystem nvarchar(50) NOT NULL,
	Measure nvarchar(150) NOT NULL,
	AggregatedValue decimal (28,8) NULL
	)