USE [TestShop]
GO

CREATE PROCEDURE [dbo].[sp_DeleteFkAreasFromRow]
	@IdArea bigint
AS
DELETE FROM Row WHERE IdArea = @IdArea
BEGIN 
	SELECT SCOPE_IDENTITY()
END