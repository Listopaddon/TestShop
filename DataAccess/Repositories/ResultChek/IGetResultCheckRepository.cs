using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.ResultChek
{
    public interface IGetResultCheckRepository
    {
        public List<Check> GetCheck(long idUser);
    }
}
