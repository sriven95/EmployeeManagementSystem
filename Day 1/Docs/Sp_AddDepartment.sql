USE [Employee]
GO

/****** Object:  StoredProcedure [dbo].[AddDepartment]    Script Date: 6/15/2026 9:17:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddDepartment]
AS
BEGIN
	INSERT INTO Department(
		DepartmentName
	) VALUES (
		'HR'
	);
END;
GO

