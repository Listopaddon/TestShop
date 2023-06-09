USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertCinema]    Script Date: 22.01.2023 21:33:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_InsertCinema]
	@Name varchar(255),
	@Picture varchar(255)
AS
	DECLARE @IdCinema bigint
	INSERT into Cinema (Name,Picture)
	Values(@Name,@Picture)

	Set @IdCinema = SCOPE_IDENTITY()

	Select ID From Cinema Where ID = @IdCinema

