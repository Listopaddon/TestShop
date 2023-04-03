using BusinessLogic.LogicBusiness.Row;
using DataAccess.Models;
using System.Collections.Generic;

namespace UnitTestBusinessLogic.Tests.RowTests.SubObjects
{
    public class SubRowLogic : IRowLogic
    {

        public long AddRow(long numberRow, long idArea) => 0;

        public void DeleteFkAreas(long idArea) { }

        public void DeleteRow(long id) { }

        public List<RowModel> GetAreaFromRow(long idArea) => new List<RowModel>();

        public RowModel GetRow(long id) => new RowModel();

        public List<RowModel> GetRows() => new List<RowModel>();

        public void UpdateRow(RowModel row) { }

    }
}
