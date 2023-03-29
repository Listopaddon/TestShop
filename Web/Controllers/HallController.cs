using AutoMapper;
using BusinessLogic.LogicBusiness.Hall;
using BusinessLogic.LogicBusiness.Movie;
using BusinessLogic.LogicBusiness.Session;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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

        [Route("Hall/GetHallsByCinema/{idCinema}")]
        public IActionResult GetHallsByCinema(long idCinema)//1
        {
            List<HallModel> halls = hallLogic.GetHallByIdCinema(idCinema);
            var hallsUI = mapper.Map<List<HallUI>>(halls);

            return View(hallsUI);
        }

        [HttpGet]
        [Route("Hall/GetHallByMovie/{idCinema}")]
        public IActionResult GetHallByMovie(long idCinema)//1
        {
            long idMovie = Convert.ToInt64(HttpContext.Session.GetString("idMovie"));
            List<HallModel> halls = hallLogic.GetHallByIdMovie(idMovie,idCinema);
            var hallsUI = mapper.Map<List<HallUI>>(halls);

            return View(hallsUI);
        }

        [Route("Hall/GetHall/{idHall}")]
        public IActionResult GetHall(long idHall, long idSession)//1
        {
            HttpContext.Session.SetString("idSession", idSession.ToString());
            HallModel hall = hallLogic.GetHall(idHall);
            var hallUI = mapper.Map<HallUI>(hall);

            return View(hallUI);
        }

        //[HttpGet]
        //[Route("Hall/SelectHallForMovie/{idMoive}")]
        //public IActionResult SelectHallForMovie(long idMovie)
        //{
        //    HttpContext.Session.SetString("idMovieForCinema", idMovie.ToString());
        //    long idCinema = Convert.ToInt64(HttpContext.Session.GetString("idCinemaForMovie"));
        //    List<HallModel> halls = hallLogic.GetHallByIdCinema(idCinema);
        //    var hallsUI = mapper.Map<List<HallUI>>(halls);

        //    return View(hallsUI);
        //}
    }
}
