USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSession]    Script Date: 02.04.2023 20:50:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_GetSession]
	@IdSession bigint
AS
	Select * From Session Where ID = @IdSession

