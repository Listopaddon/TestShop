using DataAccess.Models;
using DataAccess.Repositories.ResultChek;
using System.Collections.Generic;


namespace BusinessLogic.LogicBusiness.ResultChek
{
    public class GetResultCheckLogic : IGetResultCheckLogic
    {
        IGetResultCheckRepository resultCheckRepository;

        public GetResultCheckLogic(IGetResultCheckRepository resultCheckRepository)
        {
            this.resultCheckRepository = resultCheckRepository;
        }

        public List<Check> GetCheck(long idUser) => resultCheckRepository.GetCheck(idUser);
    }
}
