using AutoMapper;
using BusinessLogic.LogicBusiness.Area;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Web.Models;

namespace Web.Controllers
{
    public class AreaController : Controller
    {
        IAreaLogic areaLogic;
        IMapper mapper;

        public AreaController(IMapper mapper, IAreaLogic areaLogic)
        {
            this.areaLogic = areaLogic;
            this.mapper = mapper;
        }

        [Route("Area/GetAreasByIdHall/{idHall}")]
        public IActionResult GetAreasByIdHall(long idHall)
        {
            List<AreaModel> areas = areaLogic.GetFKHall(idHall);
            var areasUI = mapper.Map<List<AreaUI>>(areas);

            return View(areasUI);
        }
    }
}
