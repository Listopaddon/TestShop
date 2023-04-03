using AutoMapper;
using BusinessLogic.LogicBusiness.PlaceSession;
using BusinessLogic.LogicBusiness.ResultChek;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Web.Models;

namespace Web.Controllers
{
    public class PlaceSessionController : Controller
    {
        IPlaceSessionLogic placeSession;
        IGetResultCheckLogic check;
        IMapper mapper;

        public PlaceSessionController(IPlaceSessionLogic placeSession, IGetResultCheckLogic check, IMapper mapper)
        {
            this.placeSession = placeSession;
            this.check = check;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("PlaceSession/PriceByPlaces/{idPlace}")]
        public IActionResult PriceByPlaces(long idPlace)
        {
            long idSession = Convert.ToInt64(HttpContext.Session.GetString("idSession"));
            long idUser = Convert.ToInt64(HttpContext.Session.GetString("idUser"));
            HttpContext.Session.SetString("idPlace", idPlace.ToString());

            if (idUser <= 0)
            {
                return RedirectToAction("LogIn", "User");
            }
            long idPlaceSession = placeSession.AddPlaceSession(idPlace, idSession, idUser, StatePlace.Book);
            HttpContext.Session.SetString("idPlaceSession", idPlaceSession.ToString());

            return RedirectToAction("Basket", "PlaceSession");
        }

        [HttpGet]
        public IActionResult Basket()
        {
            long idUser = Convert.ToInt64(HttpContext.Session.GetString("idUser"));

            List<Check> checks = check.GetCheck(idUser);
            List<CheckUI> checkUIs = mapper.Map<List<CheckUI>>(checks);

            return View(checkUIs);
        }

        [HttpGet]
        [Route("PlaceSession/UnbookPlace/{idPlace}")]
        public IActionResult UnbookPlace(long idPlace)
        {
            placeSession.DeleteIdPlaceFromPlaceSession(idPlace);
            HttpContext.Request.Headers.TryGetValue("Referer", out var headerValue);

            return Redirect(headerValue[0]);
        }

        [HttpGet]
        [Route("PlaceSession/DeleteCheck/{idPlaceSession}")]
        public IActionResult DeleteCheck(long idPlaceSession)
        {
            placeSession.DeletePlaceSession(idPlaceSession);
            HttpContext.Request.Headers.TryGetValue("Referer", out var headerValue);

            return Redirect(headerValue[0]);
        }

        [HttpGet]
        public IActionResult ReturnOnRowsAndPlaces()
        {
            long idArea = Convert.ToInt64(HttpContext.Session.GetString("idAreaByRow"));

            return RedirectToAction("GetAllRowsAndPlaces", "Row", new { idArea = idArea });
        }

        [HttpGet]
        public IActionResult ResultCheck() => View();
    }
}
