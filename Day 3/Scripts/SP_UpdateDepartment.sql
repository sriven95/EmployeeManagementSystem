USE [Employee]
GO

/****** Object:  StoredProcedure [dbo].[SP_UpdateDepartment]    Script Date: 6/17/2026 10:23:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_UpdateDepartment]
(
	@DepartmentID INT,
	@DepartmentName VARCHAR(50)
)
AS
BEGIN
	UPDATE Department
	SET DepartmentName=@DepartmentName
	WHERE DepartmentID=@DepartmentID;
END;
GO

