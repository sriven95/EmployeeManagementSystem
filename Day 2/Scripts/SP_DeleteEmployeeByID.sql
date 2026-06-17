USE [Employee]
GO

/****** Object:  StoredProcedure [dbo].[SP_DeleteEmployeeByID]    Script Date: 6/16/2026 8:07:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_DeleteEmployeeByID]
(
	@EmployeeID INT
)
AS
BEGIN
	DELETE FROM Employee WHERE EmployeeID=@EmployeeID;
END;
GO

