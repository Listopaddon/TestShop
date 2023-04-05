CREATE PROCEDURE [dbo].[sp_DeleteIdHallFromSession]
	@IdHall bigint
AS
BEGIN
	DELETE FROM Session WHERE IdHall =@IdHall
	SELECT SCOPE_IDENTITY()
END
GO
