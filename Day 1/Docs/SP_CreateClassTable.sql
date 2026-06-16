USE [Class]
GO

/****** Object:  StoredProcedure [dbo].[CreateStudentTable]    Script Date: 6/15/2026 9:15:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateStudentTable]
AS
BEGIN
	CREATE TABLE Student(
		StudentID INT IDENTITY(1,1) PRIMARY KEY,
		FirstName VARCHAR(50) NOT NULL,
		LastName VARCHAR(50) NOT NULL,
		Email VARCHAR(50) NOT NULL,

		ClassID INT NOT NULL,

		CONSTRAINT Fk_Class_Student
		FOREIGN KEY (ClassID)
		REFERENCES Class(ClassID)

	);
END;
GO

