CREATE PROCEDURE [dbo].[sp_GetCinema]
	@IdCinema bigint
AS
BEGIN
	SELECT * FROM Cinema WHERE ID = @IdCinema
END
GO
