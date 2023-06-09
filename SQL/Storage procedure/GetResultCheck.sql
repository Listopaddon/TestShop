USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetResultCheck]    Script Date: 02.04.2023 15:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_GetResultCheck]
	@idUser bigint
AS
BEGIN
	
	SELECT  ps.Id, m.Name,m.Time,
		    p.NumberPlace,r.NumberRow,
			c.Name,s.Price FROM PlaceSession ps 
		   
	Join Session s on ps.IdSessions = s.Id 
	Join Movie m on s.IdMovie = m.Id
	Join Places p on ps.IdPlaces = p.Id
	Join Row r on p.IdRow = r.Id
	Join Hall h on s.IdHall = h.Id
	Join Cinema c on h.IdCinema = c.Id
	WHERE ps.IdUsers = @idUser
END
