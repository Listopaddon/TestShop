USE [master]
GO
/****** Object:  Database [TestShopIntegrationTests]    Script Date: 14.03.2023 13:57:01 ******/
CREATE DATABASE [TestShopIntegrationTests]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TetsShopIntegrationTests', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TetsShopIntegrationTests.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TetsShopIntegrationTests_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TetsShopIntegrationTests_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TestShopIntegrationTests] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestShopIntegrationTests].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TestShopIntegrationTests] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TestShopIntegrationTests] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TestShopIntegrationTests] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TestShopIntegrationTests] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TestShopIntegrationTests] SET ARITHABORT OFF 
GO
ALTER DATABASE [TestShopIntegrationTests] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TestShopIntegrationTests] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TestShopIntegrationTests] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TestShopIntegrationTests] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TestShopIntegrationTests] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TestShopIntegrationTests] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TestShopIntegrationTests] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TestShopIntegrationTests] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TestShopIntegrationTests] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TestShopIntegrationTests] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TestShopIntegrationTests] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TestShopIntegrationTests] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TestShopIntegrationTests] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TestShopIntegrationTests] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TestShopIntegrationTests] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TestShopIntegrationTests] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TestShopIntegrationTests] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TestShopIntegrationTests] SET RECOVERY FULL 
GO
ALTER DATABASE [TestShopIntegrationTests] SET  MULTI_USER 
GO
ALTER DATABASE [TestShopIntegrationTests] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TestShopIntegrationTests] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TestShopIntegrationTests] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TestShopIntegrationTests] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TestShopIntegrationTests] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TestShopIntegrationTests] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TestShopIntegrationTests', N'ON'
GO
ALTER DATABASE [TestShopIntegrationTests] SET QUERY_STORE = OFF
GO
USE [TestShopIntegrationTests]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 14.03.2023 13:57:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdHall] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cinema]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cinema](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NULL,
	[Picture] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hall]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hall](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCinema] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Discription] [varchar](255) NULL,
	[Time] [datetime] NULL,
 CONSTRAINT [PK__Movie__3214EC07A7DB179F] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Places]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Places](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdRow] [bigint] NOT NULL,
	[NumberPlace] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlaceSession]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlaceSession](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdPlaces] [bigint] NOT NULL,
	[IdSessions] [bigint] NOT NULL,
	[IdUsers] [bigint] NOT NULL,
	[DateModified] [datetime2](7) NOT NULL,
	[State] [int] NOT NULL,
 CONSTRAINT [PK__PlaceSes__3214EC079C75C25D] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Row]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Row](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[NumberRow] [bigint] NOT NULL,
	[IdArea] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Session]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Session](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdMovie] [bigint] NOT NULL,
	[IdHall] [bigint] NOT NULL,
	[Price] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](255) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[Role] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Area]  WITH CHECK ADD FOREIGN KEY([IdHall])
REFERENCES [dbo].[Hall] ([Id])
GO
ALTER TABLE [dbo].[Hall]  WITH CHECK ADD FOREIGN KEY([IdCinema])
REFERENCES [dbo].[Cinema] ([Id])
GO
ALTER TABLE [dbo].[Places]  WITH CHECK ADD FOREIGN KEY([IdRow])
REFERENCES [dbo].[Row] ([Id])
GO
ALTER TABLE [dbo].[PlaceSession]  WITH CHECK ADD  CONSTRAINT [FK__PlaceSess__DateM__398D8EEE] FOREIGN KEY([IdPlaces])
REFERENCES [dbo].[Places] ([Id])
GO
ALTER TABLE [dbo].[PlaceSession] CHECK CONSTRAINT [FK__PlaceSess__DateM__398D8EEE]
GO
ALTER TABLE [dbo].[PlaceSession]  WITH CHECK ADD  CONSTRAINT [FK__PlaceSess__IdSes__3A81B327] FOREIGN KEY([IdSessions])
REFERENCES [dbo].[Session] ([Id])
GO
ALTER TABLE [dbo].[PlaceSession] CHECK CONSTRAINT [FK__PlaceSess__IdSes__3A81B327]
GO
ALTER TABLE [dbo].[PlaceSession]  WITH CHECK ADD  CONSTRAINT [FK__PlaceSess__IdUse__3B75D760] FOREIGN KEY([IdUsers])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[PlaceSession] CHECK CONSTRAINT [FK__PlaceSess__IdUse__3B75D760]
GO
ALTER TABLE [dbo].[Row]  WITH CHECK ADD FOREIGN KEY([IdArea])
REFERENCES [dbo].[Area] ([Id])
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD FOREIGN KEY([IdHall])
REFERENCES [dbo].[Hall] ([Id])
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FK__Session__Price__35BCFE0A] FOREIGN KEY([IdMovie])
REFERENCES [dbo].[Movie] ([Id])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK__Session__Price__35BCFE0A]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteArea]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteArea]
	@IdArea bigint
AS
	DELETE FROM Area Where ID = @IdArea
BEGIN
	SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteCinema]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_DeleteCinema]
	@IdCinema bigint
AS
	Delete from Cinema Where Id = @IdCinema

BEGIN	
	SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteFkAreasFromRow]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_DeleteFkAreasFromRow]
	@IdArea bigint
AS
DELETE FROM Row WHERE IdArea = @IdArea
BEGIN 
	SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteHall]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteHall]
	@IdHall bigint
AS
	DELETE FROM Hall WHERE ID = @IdHall
BEGIN
	SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteIdHallFromArea]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteIdHallFromArea]
	@IdArea bigint
AS
BEGIN
	DELETE  FROM Area WHERE Id = @IdArea
	SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteIdHallFromSession]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteIdHallFromSession]
	@IdHall bigint
AS
BEGIN
	DELETE FROM Session WHERE IdHall =@IdHall
	SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteIdPlaceFromPlaceSession]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteIdPlaceFromPlaceSession]
	@IdPlace bigint
AS
BEGIN
	DELETE FROM PlaceSession WHERE IdPlaces = @IdPlace
	SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteIdRowFromPlace]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteIdRowFromPlace]
	@IdRow bigint
AS
BEGIN
	DELETE FROM Places WHERE IdRow = @IdRow
	SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteIdSessionFromPlaceSession]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteIdSessionFromPlaceSession]
	@IdSession bigint
AS
BEGIN
	DELETE FROM PlaceSession WHERE IdSessions = @IdSession
	SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteIdUserFromPlaceSession]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteIdUserFromPlaceSession]
	@IdUser bigint
AS
BEGIN
	DELETE FROM PlaceSession WHERE IdUsers = @IdUser
	SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteMovie]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteMovie] 
	@IdMovie bigint
AS
	DELETE FROM Movie WHERE ID = @IdMovie
BEGIN
	SELECT SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[sp_DeletePlace]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeletePlace] 
	@IdPlace bigint
AS
	DELETE FROM Places WHERE ID = @IdPlace

BEGIN
	SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeletePlaceSession]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeletePlaceSession]
	@Id bigint
AS
	DELETE FROM PlaceSession WHERE ID = @Id
BEGIN
	SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteRow]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteRow]
	@IdRow bigint	
AS
BEGIN
	DELETE FROM ROW WHERE Id = @IdRow
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteSession]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteSession]
	@Id bigint
AS
	DELETE FROM Session WHERE ID = @ID
BEGIN
	SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteUser]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteUser]
	@IdUser bigint
AS
	DELETE from Users WHERE ID = @IdUser

	SELECT SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllMovieForThisCinema]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAllMovieForThisCinema] 
	@IdCinema bigint
AS
BEGIN

	SELECT DISTINCT m.Id,
					m.Name,
					m.Discription,
					m.Time,
					s.Id,
					s.IdHall,
					s.Price FROM Session s
		Join Movie m on s.IdMovie = m.ID
		Join Hall a on s.IdHall = a.ID
		Join Hall h on a.IdCinema = h.ID AND h.IdCinema = @IdCinema
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllSessionsAndMovies]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetAllSessionsAndMovies]
	
AS
BEGIN
	SELECT m.Id, m.Name,m.Discription,
					m.Time, s.Id, s.IdHall, s.Price
					FROM Session s
	JOIN Movie m on s.IdMovie = m.Id

END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetArea]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetArea]
	@IdArea bigint
AS
BEGIN
	SELECT * From Area Where ID = @IdArea
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAreaFKHall]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAreaFKHall]
	@IdHall bigint
AS
BEGIN
	SELECT * From Area Where IdHall = @IdHall
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAreas]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetAreas]	
AS
BEGIN
	SELECT * From Area 
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetCinema]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetCinema]
	@IdCinema bigint
AS
BEGIN
	SELECT * FROM Cinema WHERE ID = @IdCinema
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCinemas]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetCinemas] 
AS
BEGIN
	SELECT * FROM Cinema
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetHall]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetHall]
	@IdHall bigint
AS
	SELECT * FROM Hall WHERE ID = @IdHall

GO
/****** Object:  StoredProcedure [dbo].[sp_GetHallByIdCinema]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetHallByIdCinema] 
	@IdCinema bigint
AS
BEGIN
	SELECT * FROM Hall WHERE IdCinema = @IdCinema
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetHallByIdMovie]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetHallByIdMovie]
	@IdMovie bigint, 
	@IdCinema bigint
AS
BEGIN
	SELECT DISTINCT h.Id,h.IdCinema From Hall h
	JOIN Session s on s.IdHall = h.Id AND s.IdMovie = @IdMovie AND h.IdCinema = @IdCinema
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetHallFKCinema]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetHallFKCinema]
	@IdCinema bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * From Hall WHERE IdCinema =@IdCinema
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetHalls]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetHalls]
AS
	SELECT * From Hall

GO
/****** Object:  StoredProcedure [dbo].[sp_GetIdAreasFromRow]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_GetIdAreasFromRow] 
	@IdArea bigint
AS
BEGIN
	SELECT * FROM Row WHERE IdArea = @IdArea
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetIdCinemaByFilmFromSession]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetIdCinemaByFilmFromSession]
	@IdMovie bigint
AS
BEGIN	
	
	SELECT DISTINCT c.Id,c.Name,c.Picture FROM Session s
		JOIN Hall h on s.IdHall= h.Id AND s.IdMovie = @IdMovie
		JOIN Cinema c on h.IdCinema = c.Id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetMovie]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetMovie]
	@IdMovie bigint
AS
BEGIN
	SELECT * FROM Movie WHERE ID = @IdMovie
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetMovies]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetMovies]

AS
	SELECT * FROM Movie

GO
/****** Object:  StoredProcedure [dbo].[sp_GetPlace]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPlace]
	@IdPlace bigint
AS
BEGIN
	 SELECT * From Places Where ID = @IdPlace
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetPlaces]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPlaces]

AS
	SELECT * FROM Places

GO
/****** Object:  StoredProcedure [dbo].[sp_GetPlaceSession]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPlaceSession]
	@IdPlaceSession bigint
AS
BEGIN
	SELECT * FROM PlaceSession WHERE ID = @IdPlaceSession
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetPlaceSessionFKPlaces]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPlaceSessionFKPlaces]
	@IdPlace bigint
AS
	SELECT * FROM PlaceSession WHERE IdPlaces = @IdPlace

GO
/****** Object:  StoredProcedure [dbo].[sp_GetPlaceSessionFKSession]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPlaceSessionFKSession]
	@IdSession bigint
AS
	SELECT * From PlaceSession WHERE IdSessions = @IdSession

GO
/****** Object:  StoredProcedure [dbo].[sp_GetPlaceSessionFKUser]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPlaceSessionFKUser]
	@IdUser bigint
AS
	SELECT * FROM PlaceSession Where IdUsers = @IdUser

GO
/****** Object:  StoredProcedure [dbo].[sp_GetPlaceSessions]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPlaceSessions] 	
AS
	SELECT * FROM PlaceSession

GO
/****** Object:  StoredProcedure [dbo].[sp_GetPlacesFKRow]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPlacesFKRow]
	@IdRow bigint
AS
BEGIN
	SELECT * From Places Where IdRow = @IdRow
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetResultCheck]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetResultCheck]
	@idUser bigint
AS
BEGIN
	
	SELECT  ps.Id, m.Name,m.Time,
		    p.NumberPlace,r.NumberRow,
			c.Name,s.Price FROM PlaceSession ps 
		   
	Join Session s on ps.IdSessions = s.Id 
	Join Movie m on s.IdMovie = m.Id
	Join Places p on ps.IdPlaces = p.Id
	Join Row r on p.IdRow = r.Id
	Join Hall h on s.IdHall = h.Id
	Join Cinema c on h.IdCinema = c.Id
	WHERE ps.IdUsers = @idUser
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetRow]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetRow]	
	@IdRow bigint
AS
BEGIN
	SELECT * FROM Row WHERE Id = @IdRow
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetRows]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetRows] 

AS
BEGIN
	SELECT * FROM Row
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetSession]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetSession]
	@IdSession bigint
AS
	Select * From Session Where ID = @IdSession

GO
/****** Object:  StoredProcedure [dbo].[sp_GetSessionByMovie]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetSessionByMovie]
	@IdMovie bigint
AS
BEGIN
	SELECT * FROM Session s WHERE s.IdMovie = @IdMovie
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSessionFkHall]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetSessionFkHall]
	@IdHall bigint
AS
BEGIN
	SELECT * From Session Where IdHall = @IdHall
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetSessions]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetSessions]
AS
	SELECT * From Session

GO
/****** Object:  StoredProcedure [dbo].[sp_GetUser]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetUser]
	@IdUser bigint
AS
BEGIN
	SELECT * From Users Where ID = @IdUser
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserLogin]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetUserLogin]
	@Login varchar(255)
AS
BEGIN
	SELECT * FROM Users WHERE Login = @Login
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUsers]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetUsers]
	
AS
	SELECT * FROM Users

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertArea]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertArea]
	@IdHall bigint
AS
	Insert into Area(IdHall)
	values (@IdHall)
BEGIN
	SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertCinema]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertCinema]
	@Name varchar(255),
	@Picture varchar(255)
AS
	DECLARE @IdCinema bigint
	INSERT into Cinema (Name,Picture)
	Values(@Name,@Picture)

	Set @IdCinema = SCOPE_IDENTITY()

	Select ID From Cinema Where ID = @IdCinema

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertHall]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertHall]
	@IdCinema bigint
AS
	Declare @IdHall bigint

	INSERT Hall (IdCinema)
	Values (@IdCinema)

	SET @IdHall = SCOPE_IDENTITY()

	Select Id From Hall Where Id = @IdHall

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertMovie]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertMovie]
	@Name varchar(255),
	@Discription varchar(255),
	@Time varchar (255)
AS
	Declare @IdMovie bigint

	INSERT INTO Movie (Name,Discription, Time)
	VALUES (@Name,@Discription,@Time)

	Set @IdMovie = SCOPE_IDENTITY()

	Select ID From Movie Where ID = @IdMovie

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertPlaces]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertPlaces] 
	@IdRow bigint,
	@NumberPlace int
AS
	Declare @IdPlace bigint

	INSERT INTO Places (IdRow,NumberPlace)
		Values (@IdRow,@NumberPlace)

	Set @IdPlace = SCOPE_IDENTITY()

	Select ID from Places Where ID = @IdPlace

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertPlaceSession]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertPlaceSession]
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

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertRow]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertRow]
	@NumberRow bigint,
	@IdArea bigint
AS
BEGIN
	DECLARE @IdRow bigint
		INSERT INTO Row (NumberRow,IdArea)
			VALUES (@NumberRow,@IdArea)

	SET @IdRow = SCOPE_IDENTITY()

	SELECT Id FROM Row WHERE Id = @IdRow
END

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertSession]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertSession]
	@IdMovie bigint,
	@IdHall bigint,
	@Price decimal(18,0)
AS
	Declare @IdSesion bigint

	INSERT Session (IdMovie,IdHall,Price)
		VALUES (@IdMovie,@IdHall,@Price)

	Set @IdSesion =SCOPE_IDENTITY()

	Select ID From Session Where ID = @IdSesion

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertUser]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertUser]
	@Login varchar(255),
	@Password varchar(255),
	@Role varchar(255)
AS
	Declare @IdUser bigint

	INSERT INTO Users (Login, Password, Role)
	VALUES (@Login,@Password,@Role)

	Set @IdUser = SCOPE_IDENTITY ()

	Select ID From Users Where ID = @IdUser

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateArea]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UpdateArea]
	@IdArea bigint,
	@IdHall bigint
AS
	UPDATE Area
		SET IdHall = @IdHall
	WHERE ID = @IdArea

BEGIN
	SELECT SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateCinema]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateCinema]
	@IdCinema bigint,
	@Name varchar(255),
	@Picture varchar(255)
AS
	Update Cinema
	SET Name = @Name,
		Picture = @Picture
	WHERE Id = @IdCinema
BEGIN	
	SELECT SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateHall]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UpdateHall]
	@IdHall bigint,
	@IdCinema bigint
AS
	UPDATE Hall
		SET IdCinema = @IdCinema
	    WHERE ID =@IdHall

BEGIN
	SELECT SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateMovie]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateMovie]
	@IdMovie bigint,
	@Name varchar(255),
	@Discription varchar(255),
	@Time varchar (255)
AS
	UPDATE Movie
	SET Name = @Name,
		Discription = @Discription,
		Time = @Time
	WHERE ID = @IdMovie
BEGIN
	SELECT SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdatePlace]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UpdatePlace]
	@IdPlace bigint,
	@IdRow bigint,
	@NumberPlace int
AS
	UPDATE Places
		SET IdRow = @IdRow,
			NumberPlace = @NumberPlace
		WHERE Id = @IdPlace
BEGIN
	SELECT SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdatePlaceSession]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UpdatePlaceSession]
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

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateRow]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateRow] 
	@Id bigint,	
	@NumberRow bigint,
	@IdArea bigint

AS
BEGIN
	UPDATE Row
		SET NumberRow = @NumberRow,
			IdArea = @IdArea
		WHERE Id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateSession]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateSession]
	@IdSession bigint,
	@IdMovie bigint,
	@IdHall bigint,
	@Price decimal(18,0)
AS
	UPDATE Session
		SET IdMovie = @IdMovie,
			IdHall = @IdHall,
			Price = @Price
		WHERE ID = @IdSession
BEGIN
	SELECT SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateUser]    Script Date: 03.04.2023 19:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UpdateUser]
	@IdUser bigint,
	@Login varchar(255),
	@Password varchar(255),
	@Role varchar(255)
AS
	UPDATE Users
	SET Login = @Login,
	    Password = @Password,
		Role = @Role
	WHERE ID = @IdUser

BEGIN
	SELECT * FROM Users
END

GO
