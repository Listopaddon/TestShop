USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertMovie]    Script Date: 19.01.2023 20:13:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_InsertMovie]
	@Name varchar(255),
	@Discription varchar(255),
	@Time varchar (255)
AS
	Declare @IdMovie bigint

	INSERT INTO Movie (Name,Discription, Time)
	VALUES (@Name,@Discription,@Time)

	Set @IdMovie = SCOPE_IDENTITY()

	Select ID From Movie Where ID = @IdMovie

