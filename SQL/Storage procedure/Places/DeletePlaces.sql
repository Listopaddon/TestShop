USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeletePlaces]    Script Date: 16.05.2022 21:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_DeletePlaces] 
	@Id bigint
AS
	DELETE FROM Places WHERE ID = @Id
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT SCOPE_IDENTITY()
END
