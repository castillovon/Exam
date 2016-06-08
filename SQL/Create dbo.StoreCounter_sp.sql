USE [Exam]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StoreCounter_sp]
	@cnt int = 0
	
AS
	IF EXISTS(SELECT * FROM [dbo].[Counter])
	  BEGIN
	    UPDATE [dbo].[Counter] SET CNTR = @cnt
	  END
	ELSE
	  BEGIN
	    INSERT INTO [dbo].[Counter] VALUES (@cnt)
	  END
