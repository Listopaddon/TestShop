USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetIdCinemaByFilmFromSession]    Script Date: 07.03.2023 13:49:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_GetIdCinemaByFilmFromSession]
	@IdSession bigint
AS
BEGIN	
	
	SELECT DISTINCT c.Id,c.Name,c.Picture FROM Session s
		JOIN Hall h on s.IdHall= h.Id AND s.Id = @IdSession
		JOIN Cinema c on h.IdCinema = c.Id
END