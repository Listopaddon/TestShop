USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteUser]    Script Date: 02.04.2023 20:56:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_DeleteUser]
	@IdUser bigint
AS
	DELETE from Users WHERE ID = @IdUser

	SELECT SCOPE_IDENTITY()