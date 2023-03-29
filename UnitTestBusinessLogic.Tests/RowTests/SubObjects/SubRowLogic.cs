using BusinessLogic.LogicBusiness.Place;
using BusinessLogic.LogicBusiness.Row;
using DataAccess.Models;
using DataAccess.Repositories.Row;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestBusinessLogic.Tests.RowTests.SubObjects
{
    public class SubRowLogic : IRowLogic
    {

        public long AddRow(long numberRow, long idArea)
        {
            return new RowModel().Id;
        }

        public void DeleteFkAreas(long idArea) { }

        public void DeleteRow(long id)
        {
            throw new NotImplementedException();
        }

        public List<RowModel> GetAreaFromRow(long idArea)
        {
            return new List<RowModel>();
        }

        public Dictionary<RowModel, List<PlaceModel>> GetPlacesbyRow(long idArea)
        {
            return null;
        }

        public RowModel GetRow(long id)
        {
            return new RowModel();
        }

        public List<RowModel> GetRows()
        {
            return new List<RowModel>();
        }

        public void UpdateRow(RowModel row) { }
       
    }
}
