using BusinessLogic.LogicBusiness.Area;
using BusinessLogic.LogicBusiness.Cinema;
using BusinessLogic.LogicBusiness.Hall;
using BusinessLogic.LogicBusiness.Place;
using BusinessLogic.LogicBusiness.PlaceSession;
using BusinessLogic.LogicBusiness.Row;
using BusinessLogic.LogicBusiness.Session;
using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.Repositories.Area;
using DataAccess.Repositories.Cinema;
using DataAccess.Repositories.Hall;
using DataAccess.Repositories.Place;
using DataAccess.Repositories.PlaceSession;
using DataAccess.Repositories.Row;
using DataAccess.Repositories.Session;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace IntegerTestsBusinessLogic.RowTests
{
    [TestClass]
    public class RowLogicTests
    {
        RowLogic rowLogic;
        PlaceLogic placeLogic;
        PlaceSessionLogic placeSessionLogic;
        AreaLogic areaLogic;
        CinemaLogic cinemaLogic;
        HallLogic hallLogic;
        SessionLogic sessionLogic;
        string connectionString = ConnectionString.connectionStringFake;
        long idCinema;
        long idHall;
        long idArea;

        [TestInitialize]
        public void Initialize()
        {
            placeSessionLogic = new PlaceSessionLogic(new PlaceSessionRepository(connectionString));
            placeLogic = new PlaceLogic(new PlaceRepository(connectionString), placeSessionLogic);
            rowLogic = new RowLogic(new RowRepository(connectionString), placeLogic);
            sessionLogic = new SessionLogic(new SessionRepository(connectionString), placeSessionLogic);
            areaLogic = new AreaLogic(new AreaRepository(connectionString), rowLogic, placeLogic);
            hallLogic = new HallLogic(new HallRepository(connectionString), areaLogic, sessionLogic);
            cinemaLogic = new CinemaLogic(new CinemaRepository(connectionString), hallLogic);

            idCinema = cinemaLogic.AddCinema("TestCinema", "img");
            idHall = hallLogic.AddHall(idCinema);
            idArea = areaLogic.AddArea(idHall);
        }

        [TestMethod]
        public void AddRowTest()
        {
            //Act
            long result = rowLogic.AddRow(2, idArea);
            long expected = rowLogic.GetRow(result).Id;

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void UpdateRowTest()
        {
            //Arrange
            RowModel expected = rowLogic.GetRow(rowLogic.AddRow(32, idArea));

            //Act
            rowLogic.UpdateRow(expected);
            RowModel result = rowLogic.GetRow(expected.Id);

            //Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.IdArea, result.IdArea);
            Assert.AreEqual(expected.NumberRow, result.NumberRow);
        }

        [TestMethod]
        public void DeleteRowTest()
        {
            //Arrange
            long id = rowLogic.AddRow(300, idArea);

            //Act
            rowLogic.DeleteRow(id);

            //Assert
            Assert.IsNull(rowLogic.GetRow(id));
        }

        [TestMethod]
        public void DeleteFkAreaFromRow()
        {
            //Arrange
            long idArea = areaLogic.AddArea(idHall);
            rowLogic.GetRow(rowLogic.AddRow(23, idArea));
            rowLogic.GetRow(rowLogic.AddRow(23, idArea));
            rowLogic.GetRow(rowLogic.AddRow(23, idArea));

            //Act
            rowLogic.DeleteFkAreas(idArea);
            List<RowModel> rows = rowLogic.GetAreaFromRow(idArea);

            //Assert
            Assert.AreEqual(rows.Count, 0);
        }

        [TestMethod]
        public void GetRowTest()
        {
            //Arrange
            long idRow = rowLogic.AddRow(23, idArea);
            RowModel expected = new RowModel(idRow, 23, idArea);

            //Act
            RowModel result = rowLogic.GetRow(idRow);

            //Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.IdArea, result.IdArea);
            Assert.AreEqual(expected.NumberRow, result.NumberRow);
        }

        [TestMethod]
        public void GetRowsTest()
        {
            //Arrange
            List<RowModel> expected = rowLogic.GetRows();
            expected.Add(rowLogic.GetRow(rowLogic.AddRow(3, idArea)));

            //Act
            List<RowModel> result = rowLogic.GetRows();

            //Assert
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdArea, result[i].IdArea);
                Assert.AreEqual(expected[i].NumberRow, result[i].NumberRow);
            }
        }

        [TestMethod]
        public void GetAreaFromRowTest()
        {
            //Arrange
            long idArea = areaLogic.AddArea(idHall);
            List<RowModel> expected = rowLogic.GetAreaFromRow(idArea);
            expected.Add(rowLogic.GetRow(rowLogic.AddRow(30, idArea)));

            //Act
            List<RowModel> result = rowLogic.GetAreaFromRow(idArea);

            //Assert
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdArea, result[i].IdArea);
                Assert.AreEqual(expected[i].NumberRow, result[i].NumberRow);
            }
        }
    }
}
