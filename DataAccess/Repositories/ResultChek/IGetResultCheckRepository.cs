using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Repositories.ResultChek
{
    public interface IGetResultCheckRepository
    {
        public List<Check> GetCheck(long idUser);
    }
}
