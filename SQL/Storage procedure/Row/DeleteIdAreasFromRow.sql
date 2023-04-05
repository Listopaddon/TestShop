USE [TestShopIntegrationTest]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteFkAreasFromRow]    Script Date: 02.02.2023 12:51:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_DeleteIdAreasFromRow]
	@IdArea bigint
AS
DELETE FROM Row WHERE IdArea = @IdArea
BEGIN 
	SELECT SCOPE_IDENTITY()
END