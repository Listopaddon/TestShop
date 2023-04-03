using AutoMapper;
using BusinessLogic.LogicBusiness.Cinema;
using BusinessLogic.LogicBusiness.Movie;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        ICinemaLogic cLogic;
        IMovieLogic mLogic;
        IMapper mapper;

        public HomeController(ICinemaLogic cLogic, IMovieLogic mLogic, IMapper mapper)
        {
            this.cLogic = cLogic;
            this.mLogic = mLogic;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<CinemaModel> cinemas = cLogic.GetCinemas();
            var cinemasUI = mapper.Map<List<CinemaUI>>(cinemas);
            return View(cinemasUI);
        }

        [HttpGet]
        [Route("Home/GetAllMoviesForCinema/{idCinema}")]
        public IActionResult GetAllMoviesForCinema(long idCinema)
        {
            HttpContext.Session.SetString("idCinemaForMovie", idCinema.ToString());
            List<MovieSessionModel> movies = mLogic.GetMoviesWithCinema(idCinema);
            var moviesUI = mapper.Map<List<MovieSessionModelUI>>(movies);
            return View(moviesUI);
        }

        [HttpGet]
        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
