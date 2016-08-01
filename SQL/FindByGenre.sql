USE [DVDLibrary]
GO

/****** Object:  StoredProcedure [dbo].[FindByGenre]    Script Date: 8/1/2016 9:45:06 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<THOMAS BOHN>
-- Create date: <7/31/2016>
-- Description:	<Find movie by genre>
-- =============================================
CREATE PROCEDURE [dbo].[FindByGenre] (
@GenreDescription varchar(50)
)
AS

	DECLARE @GenreID int
	SET @GenreID = 
	(
	SELECT GenreID
	FROM Genres
	WHERE GenreDescription = @GenreDescription
	)

SELECT MovieTitle, NumberOfCopies, RunTime, ReleaseDate, StudioName
FROM Movies
WHERE GenreID = @GenreID



GO

