USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertHall]    Script Date: 25.07.2022 16:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_InsertHall]
	@IdCinema bigint
AS
	Declare @IdHall bigint

	INSERT Hall (IdCinema)
	Values (@IdCinema)

	SET @IdHall = SCOPE_IDENTITY()

	Select Id From Hall Where Id = @IdHall

