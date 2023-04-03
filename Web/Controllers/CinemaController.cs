using AutoMapper;
using BusinessLogic.LogicBusiness.Cinema;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult ViewCinemaByFilm(long idMovie,long idSession)
        {
            HttpContext.Session.SetString("idSession",idSession.ToString());
            HttpContext.Session.SetString("idMovie", idMovie.ToString());
            List<CinemaModel> cinemas = cinemaLogic.GetIdCinemaByFilmFromSession(idMovie);
            var cinemasUI = mapper.Map<List<CinemaUI>>(cinemas);

            return View(cinemasUI);
        }

        
    }
}
