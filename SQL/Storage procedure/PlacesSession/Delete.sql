USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeletePlaceSession]    Script Date: 01.06.2022 21:31:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_DeletePlaceSession]
	@Id bigint
AS
	DELETE FROM PlaceSession WHERE ID = @Id
BEGIN
	SELECT SCOPE_IDENTITY()
END
