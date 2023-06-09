USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateCinema]    Script Date: 02.04.2023 20:12:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_UpdateCinema]
	@IdCinema bigint,
	@Name varchar(255),
	@Picture varchar(255)
AS
	Update Cinema
	SET Name = @Name,
		Picture = @Picture
	WHERE Id = @IdCinema
BEGIN	
	SELECT SCOPE_IDENTITY()
END

