CREATE PROCEDURE [dbo].[sp_DeleteIdUserFromPlaceSession]
	@IdUser bigint
AS
BEGIN
	DELETE FROM PlaceSession WHERE IdUsers = @IdUser
	SELECT SCOPE_IDENTITY()
END
GO
