USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdatePlaces]    Script Date: 22.01.2023 21:39:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_UpdatePlaces]
	@Id bigint,
	@IdRow bigint,
	@NumberPlace int
AS
	UPDATE Places
		SET IdRow = @IdRow,
			NumberPlace = @NumberPlace
		WHERE Id = @Id
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT SCOPE_IDENTITY()
END
