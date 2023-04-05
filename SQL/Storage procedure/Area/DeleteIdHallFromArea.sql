USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteIdHallFromArea]    Script Date: 02.04.2023 20:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_DeleteIdHallFromArea]
	@IdArea bigint
AS
BEGIN
	DELETE  FROM Area WHERE Id = @IdArea
	SELECT SCOPE_IDENTITY()
END
