USE [Employee]
GO

/****** Object:  StoredProcedure [dbo].[SP_DeleteDepartmentByID]    Script Date: 6/16/2026 8:07:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_DeleteDepartmentByID]
(
	@DepartmentID INT
)
AS
BEGIN
	DELETE FROM Department WHERE DepartmentID=@DepartmentID;
END;
GO

