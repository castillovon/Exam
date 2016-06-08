USE [Exam]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetCounter]
	
AS
	SELECT * FROM [dbo].[Counter]
