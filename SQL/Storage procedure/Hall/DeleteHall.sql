USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteHall]    Script Date: 02.04.2023 20:21:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_DeleteHall]
	@IdHall bigint
AS
	DELETE FROM Hall WHERE ID = @IdHall
BEGIN
	SELECT SCOPE_IDENTITY()
END
