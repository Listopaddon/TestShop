USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteCinema]    Script Date: 02.04.2023 20:12:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_DeleteCinema]
	@IdCinema bigint
AS
	Delete from Cinema Where Id = @IdCinema

BEGIN	
	SELECT SCOPE_IDENTITY()
END
