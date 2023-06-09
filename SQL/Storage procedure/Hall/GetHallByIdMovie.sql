USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetHallByIdMovie]    Script Date: 27.03.2023 16:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_GetHallByIdMovie]
	@IdMovie bigint, 
	@IdCinema bigint
AS
BEGIN
	SELECT DISTINCT h.Id,h.IdCinema From Hall h
	JOIN Session s on s.IdHall = h.Id AND s.IdMovie = @IdMovie AND h.IdCinema = @IdCinema
END
