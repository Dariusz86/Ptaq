IF OBJECT_ID('qa.HRTable') IS NOT NULL
	BEGIN
		DROP TABLE qa.HRTable;
	END;

CREATE TABLE qa.HRTable
	(
	NationalIDNumber int NOT NULL,
	LoginId nvarchar(150) NOT NULL,
	JobTitle nvarchar (150) NULL
	)