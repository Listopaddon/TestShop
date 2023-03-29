using BusinessLogic.LogicBusiness.Place;
using BusinessLogic.LogicBusiness.PlaceSession;
using BusinessLogic.LogicBusiness.Row;
using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.Repositories.Place;
using DataAccess.Repositories.PlaceSession;
using DataAccess.Repositories.Row;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace IntegerTestsBusinessLogic.RowTests
{
    [TestClass]
    public class RowLogicTests
    {
        RowLogic rowLogic;
        string connectionString = ConnectionString.connectionStringFake;

        [TestInitialize]
        public void Initialize()
        {
            rowLogic = new RowLogic(new RowRepository(connectionString),
                                    new PlaceLogic(new PlaceRepository(connectionString),
                                    new PlaceSessionLogic(new PlaceSessionRepository(connectionString))));
        }

        [TestMethod]
        public void AddRowTest()
        {
            long result = rowLogic.AddRow(3, 3);
            long expected = rowLogic.GetRow(result).Id;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void UpdateRowTest()
        {
            long id = rowLogic.AddRow(3, 3);
            RowModel expected = new RowModel(id, 3, 3);
            rowLogic.UpdateRow(expected);
            RowModel result = rowLogic.GetRow(id);

            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.IdArea, result.IdArea);
            Assert.AreEqual(expected.NumberRow, result.NumberRow);
        }

        [TestMethod]
        public void DeleteRowTest()
        {
            long id = rowLogic.AddRow(3, 3);
            rowLogic.DeleteRow(id);
            Assert.IsNull(rowLogic.GetRow(id));
        }

        [TestMethod]
        public void DeleteFkAreaFromRow()
        {
            int idArea = 3;

            rowLogic.GetRow(rowLogic.AddRow(23, idArea));
            rowLogic.GetRow(rowLogic.AddRow(23, idArea));
            rowLogic.GetRow(rowLogic.AddRow(23, idArea));

            rowLogic.DeleteFkAreas(idArea);

            List<RowModel> rows = rowLogic.GetAreaFromRow(idArea);

            Assert.AreEqual(rows.Count, 0);
        }

        [TestMethod]
        public void GetRowTest()
        {
            long id = rowLogic.AddRow(23, 3);
            RowModel expected = new RowModel(id, 23, 3);
            RowModel result = rowLogic.GetRow(id);

            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.IdArea, result.IdArea);
            Assert.AreEqual(expected.NumberRow, result.NumberRow);
        }

        [TestMethod]
        public void GetRowsTest()
        {
            List<RowModel> expected = rowLogic.GetRows();
            expected.Add(rowLogic.GetRow(rowLogic.AddRow(3, 3)));

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
            long id = 3;
            List<RowModel> expected = rowLogic.GetAreaFromRow(id);
            expected.Add(rowLogic.GetRow(rowLogic.AddRow(3, 3)));

            List<RowModel> result = rowLogic.GetAreaFromRow(id);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdArea, result[i].IdArea);
                Assert.AreEqual(expected[i].NumberRow, result[i].NumberRow);
            }
        }
    }
}
