USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSession]    Script Date: 23.05.2022 20:16:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetSession]
	@Id bigint
AS
	Select * From Session Where ID = @Id
