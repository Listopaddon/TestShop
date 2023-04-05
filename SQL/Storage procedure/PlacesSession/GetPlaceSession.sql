CREATE PROCEDURE [dbo].[sp_GetPlaceSession]
	@IdPlaceSession bigint
AS
BEGIN
	SELECT * FROM PlaceSession WHERE ID = @IdPlaceSession
END
GO
