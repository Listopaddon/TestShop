USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateSession]    Script Date: 02.04.2023 20:49:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_UpdateSession]
	@IdSession bigint,
	@IdMovie bigint,
	@IdHall bigint,
	@Price decimal(18,0)
AS
	UPDATE Session
		SET IdMovie = @IdMovie,
			IdHall = @IdHall,
			Price = @Price
		WHERE ID = @IdSession
BEGIN
	SELECT SCOPE_IDENTITY()
END

