USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetHall]    Script Date: 02.04.2023 20:23:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_GetHall]
	@IdHall bigint
AS
	SELECT * FROM Hall WHERE ID = @IdHall

