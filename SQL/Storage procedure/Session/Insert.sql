USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertSession]    Script Date: 22.01.2023 21:37:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_InsertSession]
	@IdMovie bigint,
	@IdHall bigint,
	@Price decimal(18,0)
AS
	Declare @IdSesion bigint

	INSERT Session (IdMovie,IdHall,Price)
		VALUES (@IdMovie,@IdHall,@Price)

	Set @IdSesion =SCOPE_IDENTITY()

	Select ID From Session Where ID = @IdSesion
