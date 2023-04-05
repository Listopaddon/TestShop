USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateHall]    Script Date: 02.04.2023 20:22:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_UpdateHall]
	@IdHall bigint,
	@IdCinema bigint
AS
	UPDATE Hall
		SET IdCinema = @IdCinema
	    WHERE ID =@IdHall

BEGIN
	SELECT SCOPE_IDENTITY()
END

