USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertUser]    Script Date: 30.07.2022 14:30:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_InsertUser]
	@Login varchar(255),
	@Password varchar(255),
	@Role varchar(255)
AS
	Declare @IdUser bigint

	INSERT INTO Users (Login, Password, Role)
	VALUES (@Login,@Password,@Role)

	Set @IdUser = SCOPE_IDENTITY ()

	Select ID From Users Where ID = @IdUser