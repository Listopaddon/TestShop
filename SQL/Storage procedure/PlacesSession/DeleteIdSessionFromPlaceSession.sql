CREATE PROCEDURE [dbo].[sp_DeleteIdSessionFromPlaceSession]
	@IdSession bigint
AS
BEGIN
	DELETE FROM PlaceSession WHERE IdSessions = @IdSession
	SELECT SCOPE_IDENTITY()
END
GO
