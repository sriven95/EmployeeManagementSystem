USE [Employee]
GO

/****** Object:  StoredProcedure [dbo].[SP_GetAllEmployeeByID]    Script Date: 6/16/2026 8:08:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_GetAllEmployeeByID]
(
	@EmployeeID INT
)
AS
BEGIN
	SELECT * FROM Employee WHERE EmployeeID=@EmployeeID;
END;
GO

