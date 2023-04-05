CREATE PROCEDURE [dbo].[sp_GetHallByIdCinema] 
	@IdCinema bigint
AS
BEGIN
	SELECT * FROM Hall WHERE IdCinema = @IdCinema
END
GO
