USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeletePlaces]    Script Date: 02.04.2023 20:29:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_DeletePlaces] 
	@IdPlace bigint
AS
	DELETE FROM Places WHERE ID = @IdPlace

BEGIN
	SELECT SCOPE_IDENTITY()
END
