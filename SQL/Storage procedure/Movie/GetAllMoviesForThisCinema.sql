USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllMovieForThisCinema]    Script Date: 05.04.2023 0:04:52 ******/
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

	SELECT DISTINCT m.Id,
					m.Name,
					m.Discription,
					m.Time,
					s.Id,
					s.IdHall,
					s.Price FROM Session s
		Join Movie m on s.IdMovie = m.ID
		Join Hall h on s.IdHall = h.ID AND h.IdCinema = @IdCinema
END

SET ANSI_NULLS ON
