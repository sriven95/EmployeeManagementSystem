USE [Employee]
GO

/****** Object:  StoredProcedure [dbo].[SP_GetAllDepartments]    Script Date: 6/16/2026 8:07:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetAllDepartments]
AS
BEGIN
	SELECT * FROM Department;
END;
GO

