USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllMovieForThisCinema]    Script Date: 17.01.2023 23:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetAllMovieForThisCinema] 
	@IdCinema bigint
AS
BEGIN
	--SELECT * FROM Movie WHERE CinemaId = @IdCinema

	SELECT m.* FROM Session s
		Join Movie m on s.IdMovie = m.ID
		Join Session a on s.IdHall = a.ID
		Join Hall h on a.IdHall = h.ID AND h.IdCinema = 4
END
