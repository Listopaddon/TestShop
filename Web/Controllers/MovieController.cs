﻿using AutoMapper;
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
    public class MovieController : Controller
    {
        ISessionLogic sessionlogic;
        IMapper mapper;
        IMovieLogic movieLogic;

        public MovieController(IMapper mapper, ISessionLogic session, IMovieLogic movieLogic)
        {
            this.sessionlogic = session;
            this.mapper = mapper;
            this.movieLogic = movieLogic;
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            List<MovieSessionModel> movies = sessionlogic.GetAllSessionsAndMovies();
            var moviesUI = mapper.Map<List<MovieSessionModelUI>>(movies);

            return View(moviesUI);
        }

        [HttpGet]
        [Route("Movie/GetOnlyMovieWithoutSession/{idHall}")]
        public IActionResult GetOnlyMovieWithoutSession(long idHall)
        {
            HttpContext.Session.SetString("idHall", idHall.ToString());
            List<MovieModel> movies = movieLogic.GetMovies();
            var moviesUI = mapper.Map<List<MovieUI>>(movies);

            return View(moviesUI);
        }

        [HttpGet]
        public IActionResult AddNewMovie()
        {
            HttpContext.Request.Headers.TryGetValue("Referer", out var headerValue);
            HttpContext.Session.SetString("redirectURL", headerValue[0]);
            return View();
        }

        [HttpPost]
        public IActionResult AddNewMovie(string name, string discription, DateTime time)
        {
            movieLogic.AddMovie(name, discription, time);
            return Redirect(HttpContext.Session.GetString("redirectURL"));
        }


    }
}
