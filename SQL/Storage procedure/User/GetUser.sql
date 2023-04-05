CREATE PROCEDURE [dbo].[sp_GetUser]
	@IdUser bigint
AS
BEGIN
	SELECT * From Users Where ID = @IdUser
END
GO
