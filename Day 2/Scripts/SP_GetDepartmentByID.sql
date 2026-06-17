USE [Employee]
GO

/****** Object:  StoredProcedure [dbo].[SP_GetDepartmentByID]    Script Date: 6/16/2026 8:09:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetDepartmentByID]
(
	@DepartmentID INT
)
AS
BEGIN
	SELECT * FROM Department WHERE DepartmentID=@DepartmentID;
END;
GO

