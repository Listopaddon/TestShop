USE [TestShopIntegrationTests]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetIdAreas]    Script Date: 21.01.2023 20:11:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[sp_GetIdAreasFromRow] 
	@IdArea bigint
AS
BEGIN
	SELECT * FROM Row WHERE IdArea = @IdArea
END
