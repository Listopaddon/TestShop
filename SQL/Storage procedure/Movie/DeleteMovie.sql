USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteMovie]    Script Date: 02.04.2023 20:26:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_DeleteMovie] 
	@IdMovie bigint
AS
	DELETE FROM Movie WHERE ID = @IdMovie
BEGIN
	SELECT SCOPE_IDENTITY()
END

