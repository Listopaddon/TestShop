using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Repositories.Row
{
    public interface IRowRepository
    {
        public long AddRow(long numberRow, long idArea);
        public void UpdateRow(RowModel row);
        public void DeleteRow(long id);
        public RowModel GetRow(long id);
        public List<RowModel> GetRows();
        public List<RowModel> GetAreaFromRow(long idArea);
        public void DeleteFkAreas(long idArea);
    }
}
