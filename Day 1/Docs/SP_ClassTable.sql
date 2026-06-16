USE [Class]
GO

/****** Object:  StoredProcedure [dbo].[CreateClassTable]    Script Date: 6/15/2026 9:15:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateClassTable]
AS 
BEGIN
	CREATE TABLE Class(
		ClassID INT IDENTITY(1,1) PRIMARY KEY,
		ClassName VARCHAR(50) NOT NULL
	);
END;
GO

