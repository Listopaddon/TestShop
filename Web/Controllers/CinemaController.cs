using AutoMapper;
using BusinessLogic.LogicBusiness.Cinema;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Web.Models;

namespace Web.Controllers
{
    public class CinemaController : Controller
    {
        ICinemaLogic cinemaLogic;
        IMapper mapper;

        public CinemaController(ICinemaLogic cinemaLogic, IMapper mapper)
        {
            this.cinemaLogic = cinemaLogic;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("Cinema/ViewCinemaByFilm/{idMovie}")]
        public IActionResult ViewCinemaByFilm(long idMovie, long idSession)
        {
            HttpContext.Session.SetString("idSession", idSession.ToString());
            HttpContext.Session.SetString("idMovie", idMovie.ToString());
            List<CinemaModel> cinemas = cinemaLogic.GetIdCinemaByFilmFromSession(idMovie);
            var cinemasUI = mapper.Map<List<CinemaUI>>(cinemas);

            return View(cinemasUI);
        }

        [HttpGet]
        public IActionResult AddCinema()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCinema(string name, string picture)
        {
            cinemaLogic.AddCinema(name, picture);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("Cinema/DeleteCinema/{idCinema}")]
        public IActionResult DeleteCinema(long idCinema)
        {
            cinemaLogic.DeleteCinema(idCinema);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("Cinema/EditCinema/{idCinema}")]
        public IActionResult EditCinema(long idCinema)
        {
            HttpContext.Session.SetString("IdCinemaByEdit", idCinema.ToString());
            CinemaModel cinemaModel = cinemaLogic.GetCinema(idCinema);
            CinemaUI cinema = mapper.Map<CinemaUI>(cinemaModel);

            return View(cinema);
        }

        [HttpPost]
        public IActionResult EditCinema(string name, string picture)
        {
            long idCinema = Convert.ToInt64(HttpContext.Session.GetString("IdCinemaByEdit"));
            CinemaModel cinemaModel = new CinemaModel(idCinema, name, picture);
            cinemaLogic.UpdateCinema(cinemaModel);

            return RedirectToAction("Index", "Home");
        }
    }
}
