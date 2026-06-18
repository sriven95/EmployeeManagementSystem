USE [Employee]
GO

/****** Object:  StoredProcedure [dbo].[SP_UpdateEmployee]    Script Date: 6/17/2026 10:24:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_UpdateEmployee]
(
	@EmployeeID INT,
	@FirstName VARCHAR(50),
	@LastName  VARCHAR(50),
	@Email VARCHAR(50)
)
AS
BEGIN
	UPDATE Employee
	SET FirstName=@FirstName,LastName=@LastName,Email=@Email
	WHERE EmployeeID=@EmployeeID;
END;
GO

