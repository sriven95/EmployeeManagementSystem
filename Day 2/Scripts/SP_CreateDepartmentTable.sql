USE [Employee]
GO

/****** Object:  StoredProcedure [dbo].[SP_CreateDepartmentTable]    Script Date: 6/16/2026 8:06:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_CreateDepartmentTable]
AS
BEGIN
	CREATE TABLE Department
	(
		DepartmentID INT IDENTITY(1,1) PRIMARY KEY,
		DepartmentName VARCHAR(50) NOT NULL
	)
END;
GO

