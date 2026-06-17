USE [Employee]
GO

/****** Object:  StoredProcedure [dbo].[SP_GetAllEmployees]    Script Date: 6/16/2026 8:08:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetAllEmployees]
AS
BEGIN
	SELECT * FROM Employee;
END;
GO

