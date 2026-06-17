USE [Employee]
GO

/****** Object:  StoredProcedure [dbo].[SP_CreateEmployeeTable]    Script Date: 6/16/2026 8:06:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_CreateEmployeeTable]
AS
BEGIN
	CREATE TABLE Employee
	(
		EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
		FirstName VARCHAR(50) NOT NULL,
		LastName VARCHAR(50) NOT NULL,
		Email VARCHAR(50),

		DepartmentID INT NOT NULL

		CONSTRAINT FK_Employee_Department
		FOREIGN KEY (DepartmentID)
		REFERENCES Department(DepartmentID)
	);
END;
GO

