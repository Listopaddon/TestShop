USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetArea]    Script Date: 02.04.2023 20:09:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_GetArea]
	@IdArea bigint
AS
BEGIN
	SELECT * From Area Where ID = @IdArea
END

