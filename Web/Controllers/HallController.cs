using AutoMapper;
using BusinessLogic.LogicBusiness.Hall;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Web.Models;

namespace Web.Controllers
{
    public class HallController : Controller
    {
        IMapper mapper;
        IHallLogic hallLogic;

        public HallController(IMapper mapper, IHallLogic hallLogic)
        {
            this.hallLogic = hallLogic;
            this.mapper = mapper;

        }

        [HttpGet]
        [Route("Hall/GetHallsByCinema/{idCinema}")]
        public IActionResult GetHallsByCinema(long idCinema)
        {
            HttpContext.Session.SetString("idCinemaByAllHalls", idCinema.ToString());
            List<HallModel> halls = hallLogic.GetHallByIdCinema(idCinema);
            var hallsUI = mapper.Map<List<HallUI>>(halls);

            return View(hallsUI);
        }

        [HttpGet]
        [Route("Hall/GetHallByMovie/{idCinema}")]
        public IActionResult GetHallByMovie(long idCinema)
        {
            HttpContext.Session.SetString("idCinemaByHall", idCinema.ToString());
            long idMovie = Convert.ToInt64(HttpContext.Session.GetString("idMovie"));
            List<HallModel> halls = hallLogic.GetHallByIdMovie(idMovie, idCinema);
            var hallsUI = mapper.Map<List<HallUI>>(halls);

            return View(hallsUI);
        }

        [HttpGet]
        [Route("Hall/GetHall/{idHall}")]
        public IActionResult GetHall(long idHall, long idSession)
        {
            HttpContext.Session.SetString("idSession", idSession.ToString());
            HallModel hall = hallLogic.GetHall(idHall);
            var hallUI = mapper.Map<HallUI>(hall);

            return View(hallUI);
        }

        [HttpGet]
        public IActionResult AddHall()
        {
            long idCinema = Convert.ToInt64(HttpContext.Session.GetString("idCinemaForMovie"));
            long idHall = hallLogic.AddHall(idCinema);

            return RedirectToAction("AddAreaByHall", "Area", new { idHall = idHall });
        }

        [HttpGet]
        [Route("Hall/DeleteHall/{idHall}")]
        public IActionResult DeleteHall(long idHall)
        {
            hallLogic.DeleteHall(idHall);
            HttpContext.Request.Headers.TryGetValue("Referer", out var headerValue);
            return Redirect(headerValue[0]);
        }
    }
}
