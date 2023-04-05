CREATE PROCEDURE [dbo].[sp_GetSessionByMovie]
	@IdMovie bigint
AS
BEGIN
	SELECT * FROM Session s WHERE s.IdMovie = @IdMovie
END
GO
