USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteSession]    Script Date: 21.05.2022 8:51:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_DeleteSession]
	@Id bigint
AS
	DELETE FROM Session WHERE ID = @ID
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT SCOPE_IDENTITY()
END
