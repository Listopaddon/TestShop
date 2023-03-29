using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.LogicBusiness.ResultChek
{
    public interface IGetResultCheckLogic
    {
        public List<Check> GetCheck(long idUser);
    }
}
