using BusinessLogic.LogicBusiness.Place;
using DataAccess.Models;
using DataAccess.Repositories.Row;
using System.Collections.Generic;

namespace BusinessLogic.LogicBusiness.Row
{
    public class RowLogic : IRowLogic
    {
        IRowRepository rowRepository;
        IPlaceLogic placeLogic;

        public RowLogic(IRowRepository rowRepository, IPlaceLogic placeLogic)
        {
            this.rowRepository = rowRepository;
            this.placeLogic = placeLogic;
        }

        public long AddRow(long numberRow, long idArea)
        {
            return rowRepository.AddRow(numberRow, idArea);
        }

        public void DeleteFkAreas(long idArea)
        {
            List<RowModel> rows = rowRepository.GetAreaFromRow(idArea);
            for (int i = 0; i < rows.Count; i++)
            {
                placeLogic.DeleteIdRowFromPlace(rows[i].Id);
            }

            for (int i = 0; i < rows.Count; i++)
            {
                rowRepository.DeleteFkAreas(rows[i].IdArea);
            }
        }

        public void DeleteRow(long id)
        {
            rowRepository.DeleteRow(id);
        }

        public List<RowModel> GetAreaFromRow(long idArea)
        {
            return rowRepository.GetAreaFromRow(idArea);
        }             

        public RowModel GetRow(long id)
        {
            return rowRepository.GetRow(id);
        }

        public List<RowModel> GetRows()
        {
            return rowRepository.GetRows();
        }

        public void UpdateRow(RowModel row)
        {
            rowRepository.UpdateRow(row);
        }
    }
}
