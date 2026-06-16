USE [Employee]
GO

/****** Object:  StoredProcedure [dbo].[CreateDepartmentTable]    Script Date: 6/15/2026 9:11:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateDepartmentTable]
AS
BEGIN
	CREATE TABLE Department(
		DepartmentID INT IDENTITY(1,1) PRIMARY KEY,
		DepartmentName VARCHAR(50)
	);
END;
GO

