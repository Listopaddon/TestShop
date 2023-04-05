USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertPlaces]    Script Date: 22.01.2023 21:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_InsertPlaces] 
	@IdRow bigint,
	@NumberPlace int
AS
	Declare @IdPlace bigint

	INSERT INTO Places (IdRow,NumberPlace)
		Values (@IdRow,@NumberPlace)

	Set @IdPlace = SCOPE_IDENTITY()

	Select ID from Places Where ID = @IdPlace
		
