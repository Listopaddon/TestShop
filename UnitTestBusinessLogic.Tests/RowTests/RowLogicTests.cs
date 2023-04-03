using BusinessLogic.LogicBusiness.Place;
using BusinessLogic.LogicBusiness.Row;
using DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using UnitTestBusinessLogic.Tests.PlaceSessionTests.SubObjects;
using UnitTestBusinessLogic.Tests.PlaceTests.SubObjects;
using UnitTestBusinessLogic.Tests.RowTests.SubObjects;

namespace UnitTestBusinessLogic.Tests.RowTests
{
    [TestClass]
    public class RowLogicTests
    {
        RowLogic rowLogic;
        PlaceLogic placeLogic;

        [TestInitialize]
        public void Initialize()
        {
            List<RowModel> rows = new List<RowModel>
            {
                new RowModel(0,1,1),
                new RowModel(1,2,1),
                new RowModel(2,3,1),
                new RowModel(3,4,2),
                new RowModel(4,5,2),
                new RowModel(5,6,2),
            };

            List<PlaceModel> places = new List<PlaceModel>()
            {
                new PlaceModel(0,1,1),
                new PlaceModel(1,1,2),
                new PlaceModel(2,1,3),
                new PlaceModel(3,2,1),
                new PlaceModel(4,2,2),
                new PlaceModel(5,3,3)
            };

            placeLogic = new PlaceLogic(new SubPlaceRepository(places), new SubPlaceSessionLogic());
            rowLogic = new RowLogic(new SubRowRepository(rows), placeLogic);

        }

        [TestMethod]
        public void AddRowTest() => Assert.AreEqual(6, rowLogic.AddRow(4, 2));

        [TestMethod]
        public void UpdateRowTest()
        {
            RowModel expected = new RowModel(3, 5, 1);
            rowLogic.UpdateRow(expected);
            List<RowModel> result = rowLogic.GetRows();

            Assert.AreEqual(expected.Id, result[3].Id);
            Assert.AreEqual(expected.IdArea, result[3].IdArea);
            Assert.AreEqual(expected.NumberRow, result[3].NumberRow);
        }

        [TestMethod]
        public void DeleteRowTest()
        {
            long id = 5;
            RowModel result = null;
            List<RowModel> rows = rowLogic.GetRows();
            rowLogic.DeleteRow(id);

            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].Id == id)
                {
                    result = rows[i];
                    break;
                }
            }

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetRowTest()
        {
            RowModel expected = new RowModel(1, 2, 1);
            RowModel result = rowLogic.GetRow(1);

            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.IdArea, result.IdArea);
            Assert.AreEqual(expected.NumberRow, result.NumberRow);

        }

        [TestMethod]
        public void GetRowsTest()
        {
            List<RowModel> expected = rowLogic.GetRows();
            expected.Add(new RowModel(7, 9, 9));

            List<RowModel> result = rowLogic.GetRows();

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
            List<RowModel> expected = new List<RowModel>
            {
                new RowModel(0,1,1),
                new RowModel(1,2,1),
                new RowModel(2,3,1)
            };

            List<RowModel> result = rowLogic.GetAreaFromRow(1);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdArea, result[i].IdArea);
                Assert.AreEqual(expected[i].NumberRow, result[i].NumberRow);
            }
        }

        [TestMethod]
        public void DeleteIdAreaFromRowTest()
        {
            long id = 1;
            List<RowModel> result = new List<RowModel>();
            List<RowModel> rows = rowLogic.GetRows();
            rowLogic.DeleteFkAreas(id);

            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].IdArea == id)
                {
                    result.Add(rows[i]);
                }
            }

            Assert.AreEqual(result.Count, 0);
        }
    }
}
