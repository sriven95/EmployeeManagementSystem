USE [Employee]
GO

/****** Object:  StoredProcedure [dbo].[CreateEmployeeTable]    Script Date: 6/15/2026 9:12:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateEmployeeTable]
AS
BEGIN
	CREATE TABLE Employee(
		EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
		FirstName VARCHAR(50) NOT NULL,
		LastName VARCHAR(50) NOT NULL,
		Email VARCHAR(50) NOT NULL,

		DepartmentID INT NOT NULL,
		
		CONSTRAINT FK_Employee_Department
		FOREIGN KEY (DepartmentID)
		REFERENCES Department(DepartmentID)
	);

END;
GO

