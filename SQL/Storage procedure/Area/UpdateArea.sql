USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateArea]    Script Date: 02.04.2023 20:08:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_UpdateArea]
	@IdArea bigint,
	@IdHall bigint
AS
	UPDATE Area
		SET IdHall = @IdHall
	WHERE ID = @IdArea

BEGIN
	SELECT SCOPE_IDENTITY()
END

