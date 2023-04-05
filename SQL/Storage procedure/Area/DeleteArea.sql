USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteArea]    Script Date: 02.04.2023 20:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_DeleteArea]
	@IdArea bigint
AS
	DELETE FROM Area Where ID = @IdArea
BEGIN
	SELECT SCOPE_IDENTITY()
END
