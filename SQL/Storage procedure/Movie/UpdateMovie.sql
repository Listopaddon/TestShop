USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateMovie]    Script Date: 02.04.2023 20:27:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_UpdateMovie]
	@IdMovie bigint,
	@Name varchar(255),
	@Discription varchar(255),
	@Time varchar (255)
AS
	UPDATE Movie
	SET Name = @Name,
		Discription = @Discription,
		Time = @Time
	WHERE ID = @IdMovie
BEGIN
	SELECT SCOPE_IDENTITY()
END

