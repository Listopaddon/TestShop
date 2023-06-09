USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateUser]    Script Date: 02.04.2023 20:53:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_UpdateUser]
	@IdUser bigint,
	@Login varchar(255),
	@Password varchar(255),
	@Role varchar(255)
AS
	UPDATE Users
	SET Login = @Login,
	    Password = @Password,
		Role = @Role
	WHERE ID = @IdUser

BEGIN
	SELECT * FROM Users
END

