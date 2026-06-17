USE [Employee]
GO

/****** Object:  StoredProcedure [dbo].[SP_AddEmployee]    Script Date: 6/16/2026 8:05:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_AddEmployee]
(
	@FirstName VARCHAR(50),
	@LastName VARCHAR(50),
	@Email VARCHAR(50),
	@DepartmentID INT
)
AS
BEGIN
	INSERT INTO Employee
	(
		FirstName,
		LastName,
		Email,
		DepartmentID
	) VALUES
	(
		@FirstName,
		@LastName,
		@Email,
		@DepartmentID
	);
END;
GO

