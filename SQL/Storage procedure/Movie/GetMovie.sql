USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[spo_GetMovie]    Script Date: 05.01.2023 13:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_GetMovie]
	@IdMovie bigint
AS
BEGIN
	SELECT * FROM Movie WHERE ID = @IdMovie
END
