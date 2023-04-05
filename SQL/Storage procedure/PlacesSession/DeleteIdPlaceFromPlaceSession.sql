CREATE PROCEDURE [dbo].[sp_DeleteIdPlaceFromPlaceSession]
	@IdPlace bigint
AS
BEGIN
	DELETE FROM PlaceSession WHERE IdPlaces = @IdPlace
	SELECT SCOPE_IDENTITY()
END
GO
