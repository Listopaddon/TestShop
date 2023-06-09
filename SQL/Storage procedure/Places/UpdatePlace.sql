USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdatePlace]    Script Date: 02.04.2023 20:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_UpdatePlace]
	@IdPlace bigint,
	@IdRow bigint,
	@NumberPlace int
AS
	UPDATE Places
		SET IdRow = @IdRow,
			NumberPlace = @NumberPlace
		WHERE Id = @IdPlace
BEGIN
	SELECT SCOPE_IDENTITY()
END

