USE [TestShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertPlaceSession]    Script Date: 14.03.2023 15:12:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_InsertPlaceSession]
	@IdPlace bigint,
	@IdSession bigint,
	@IdUser bigint,
	@DateModified datetime2(7),
	@State int
AS
	Declare @IdPlaceSession bigint

	Insert INTO PlaceSession(IdPlaces,IdSessions,IdUsers,DateModified,State)
		Values (@IdPlace, @IdSession,@IdUser,@DateModified,@State)

	Set @IdPlaceSession = SCOPE_IDENTITY()

	Select ID From PlaceSession Where ID = @IdPlaceSession

