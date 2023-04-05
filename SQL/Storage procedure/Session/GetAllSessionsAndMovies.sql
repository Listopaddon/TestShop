USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllSessionsAndMovies]    Script Date: 10.03.2023 21:25:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_GetAllSessionsAndMovies]
	
AS
BEGIN
	SELECT m.Id, m.Name,m.Discription,
					m.Time, s.Id, s.IdHall, s.Price
					FROM Session s
	JOIN Movie m on s.IdMovie = m.Id

END
