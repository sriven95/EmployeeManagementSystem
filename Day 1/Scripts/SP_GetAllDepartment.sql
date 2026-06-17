USE [Employee]
GO

/****** Object:  StoredProcedure [dbo].[GetAllDepartment]    Script Date: 6/15/2026 9:18:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllDepartment]
AS
BEGIN
	SELECT * FROM Department;
END;
GO

