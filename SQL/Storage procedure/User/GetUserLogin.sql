

CREATE PROCEDURE [dbo].[sp_GetUserLogin]
	@Login varchar(255)
AS
BEGIN
	SELECT * FROM Users WHERE Login = @Login
END
GO
