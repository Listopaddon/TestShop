USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetMoviesWithCinema]    Script Date: 09.01.2023 21:44:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetMoviesWithCinema] 
	@IdCinema bigint
AS
BEGIN
	SELECT * FROM Movie WHERE CinemaId = @IdCinema
END
