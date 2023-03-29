using DataAccess.Models;
using DataAccess.Repositories.ResultChek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.LogicBusiness.ResultChek
{
    public class GetResultCheckLogic : IGetResultCheckLogic
    {
        IGetResultCheckRepository repository;

        public GetResultCheckLogic(IGetResultCheckRepository repository)
        {
            this.repository = repository;
        }

        public List<Check> GetCheck(long idUser)
        {
            return repository.GetCheck(idUser);
        }
    }
}
