using AutoMapper;
using BusinessLogic.LogicBusiness.Area;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet]
        [Route("Area/GetAreasByIdHall/{idHall}")]
        public IActionResult GetAreasByIdHall(long idHall)
        {
            HttpContext.Session.SetString("idHallByAddArea", idHall.ToString());
            List<AreaModel> areas = areaLogic.GetFKHall(idHall);
            var areasUI = mapper.Map<List<AreaUI>>(areas);

            return View(areasUI);
        }

        [HttpGet]
        public IActionResult AddArea() => View();

        [HttpPost]
        public IActionResult AddArea(int quantityRows, int quantityPlacesInRow)
        {
            long idHall = Convert.ToInt64(HttpContext.Session.GetString("idHallByAddArea"));
            areaLogic.AddArea(idHall, quantityRows, quantityPlacesInRow);

            return RedirectToAction("GetAreasByIdHall", "Area", new { idHall = idHall });  
        }

        [HttpGet]
        public IActionResult AddAreaByHall() => View();

        [HttpPost]
        [Route ("Area/AddAreaByHall/{idHall}")]
        public IActionResult AddAreaByHall(int quantityRows, int quantityPlacesInRow,long idHall)
        {
            areaLogic.AddArea(idHall, quantityRows, quantityPlacesInRow);
            long idCinema = Convert.ToInt64(HttpContext.Session.GetString("idCinemaByAllHalls"));

            return RedirectToAction("GetHallsByCinema", "Hall", new { idCinema = idCinema });
        }

        [HttpGet]
        public IActionResult ReturnToHall()
        {
            long idHall = Convert.ToInt64(HttpContext.Session.GetString("idHallByAddArea"));

            return RedirectToAction("GetAreasByIdHall", "Area", new { idHall = idHall });
        }

        [HttpGet]
        [Route("Area/DeleteArea/{idArea}")]
        public IActionResult DeleteArea(long idArea)
        {
            areaLogic.DeleteArea(idArea);

            HttpContext.Request.Headers.TryGetValue("Referer", out var headerValue);
            return Redirect(headerValue[0]);
        }
    }
}
