USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdatePlaceSession]    Script Date: 02.04.2023 20:39:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_UpdatePlaceSession]
	@IdPlaceSession bigint,
	@IdPlaces bigint,
	@IdSession bigint,
	@IdUsers bigint,
	@DateModified datetime2(7),
	@State int
AS
	Update  PlaceSession
		SET IdPlaces = @IdPlaces,
			IdSessions = @IdSession,
			IdUsers = @IdUsers,
			DateModified = @DateModified,
			State = @State
		Where ID = @IdPlaceSession
BEGIN
	SELECT SCOPE_IDENTITY()
END

