USE [DVDLibrary]
GO

/****** Object:  StoredProcedure [dbo].[FindByDirector]    Script Date: 8/1/2016 9:44:53 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Thomas Bohn,,Name>
-- Create date: <7/31/2016,,>
-- Description:	<Gets all movies by director,,>
-- =============================================
CREATE PROCEDURE [dbo].[FindByDirector]
(
	@LastName varchar(50)	
)	
AS

DECLARE @DirectorID int
 SET @DirectorID = 
(
SELECT DirectorID
FROM Directors
WHERE LastName = @LastName
)


SELECT @DirectorID
FROM Movies_Directors
WHERE DirectorID = @DirectorID


    -- Insert statements for procedure here
	SELECT MovieTitle
	FROM Movies
	WHERE DirectorID =  @DirectorID


GO

