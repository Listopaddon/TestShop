using DataAccess.Models;
using DataAccess.Repositories.Row;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestBusinessLogic.Tests.RowTests.SubObjects
{
    public class SubRowRepository : IRowRepository
    {
        List<RowModel> rows;

        public SubRowRepository(List<RowModel> rows)
        {
            this.rows = rows;           
        }
        public long AddRow(long numberRow, long idArea)
        {
            long id = rows.Count;
            rows.Add(new RowModel(id, numberRow, idArea));
            return id;
        }

        public void DeleteFkAreas(long idArea)
        {
            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].IdArea == idArea)
                {
                    rows.Remove(rows[i]);
                    i = -1;
                }
            }
        }

        public void DeleteRow(long id)
        {
            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].Id == id)
                {
                    rows.Remove(rows[i]);
                    break;
                }
            }
        }

        public List<RowModel> GetAreaFromRow(long idArea)
        {
            List<RowModel> result = new List<RowModel>();

            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].IdArea == idArea)
                {
                    result.Add(rows[i]);
                }
            }

            return result;
        }

        public RowModel GetRow(long id)
        {
            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].Id == id)
                {
                    return rows[i];
                }
            }

            return null;
        }

        public List<RowModel> GetRows()
        {
            return rows;
        }

        public void UpdateRow(RowModel row)
        {
            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].Id == row.Id)
                {
                    rows[i] = row;
                    break;
                }
            }
        }
    }
}
