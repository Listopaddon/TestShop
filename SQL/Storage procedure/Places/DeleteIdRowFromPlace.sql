CREATE PROCEDURE [dbo].[sp_DeleteIdRowFromPlace]
	@IdRow bigint
AS
BEGIN
	DELETE FROM Places WHERE IdRow = @IdRow
	SELECT SCOPE_IDENTITY()
END
GO
