CREATE PROCEDURE [dbo].[sp_GetPlace]
	@IdPlace bigint
AS
BEGIN
	 SELECT *From Places Where ID = @IdPlace
END
GO
