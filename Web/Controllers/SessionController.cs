﻿using BusinessLogic.LogicBusiness.Cinema;
using BusinessLogic.LogicBusiness.Movie;
using BusinessLogic.LogicBusiness.Session;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Web.Models;

namespace Web.Controllers
{
    public class SessionController : Controller
    {
        ISessionLogic sessionLogic;
        IMovieLogic movieLogic;
        ICinemaLogic cinemaLogic;

        public SessionController(ISessionLogic sessionLogic, IMovieLogic movieLogic, ICinemaLogic cinemaLogic)
        {
            this.sessionLogic = sessionLogic;
            this.movieLogic = movieLogic;
            this.cinemaLogic = cinemaLogic;
        }


        [HttpGet]
        public IActionResult AddMovieForCinema()
        {
            return View();
        }

        [HttpPost]
        [Route("Session/AddMovieForCinema/{idMovie}")]
        public IActionResult AddMovieForCinema(decimal price, long idMovie)
        {
            long idCinema = Convert.ToInt64(HttpContext.Session.GetString("idCinemaForMovie"));
            long idHall = Convert.ToInt64(HttpContext.Session.GetString("idHall"));
            sessionLogic.AddSession(idMovie, idHall, price);
            MovieModel movie = movieLogic.GetMovie(idMovie);
            CinemaModel cinema = cinemaLogic.GetCinema(idCinema);

            ResultMovieForAddUI result = new ResultMovieForAddUI(idHall, movie.Name, movie.Discription, cinema.Name, movie.Time);

            return RedirectToAction("Index","Home");
        }


    }
}