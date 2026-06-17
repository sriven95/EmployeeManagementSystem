USE [Employee]
GO

/****** Object:  StoredProcedure [dbo].[SP_AddDepartment]    Script Date: 6/16/2026 8:05:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_AddDepartment]
(
	@DepartmentName VARCHAR(50)
)
AS
BEGIN
	INSERT INTO Department
	(
		DepartmentName
	)
	VALUES
	(
		@DepartmentName
	);
END;
GO

