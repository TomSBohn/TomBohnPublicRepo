USE [DVDLibrary]
GO

/****** Object:  StoredProcedure [dbo].[GetAllAvailableMovies]    Script Date: 8/1/2016 9:45:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Thomas Bohn>
-- Create date: <7/31/2016,,>
-- Description:	<Lists all availible movies>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllAvailableMovies] 
AS
SELECT * 
FROM Movies
WHERE NumberOfCopies > 0

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

END

GO

