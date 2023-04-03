using DataAccess.Models;
using System.Collections.Generic;

namespace BusinessLogic.LogicBusiness.ResultChek
{
    public interface IGetResultCheckLogic
    {
        public List<Check> GetCheck(long idUser);
    }
}
