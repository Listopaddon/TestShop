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
    public class PlaceController : Controller
    {
        IPlaceSessionLogic placeSession;
        IGetResultCheckLogic check;
        IMapper mapper;

        public PlaceController(IPlaceSessionLogic placeSession, IGetResultCheckLogic check, IMapper mapper)
        {
            this.placeSession = placeSession;
            this.check = check;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("Place/PriceByPlaces/{idPlace}")]
        public IActionResult PriceByPlaces(long idPlace)
        {
            long idSession = Convert.ToInt64(HttpContext.Session.GetString("idSession"));
            long idUser = Convert.ToInt64(HttpContext.Session.GetString("idUser"));

            if (idUser <= 0)
            {
                return RedirectToAction("LogIn", "User");
            }
            placeSession.AddPlaceSession(idPlace, idSession, idUser, StatePlace.Book);

            List<Check> checks = check.GetCheck(idUser);
            List<CheckUI> checkUIs = mapper.Map<List<CheckUI>>(checks);

            return View(checkUIs);
        }

        [HttpGet]
        public IActionResult ResultCheck()
        {
            return View();
        }
    }
}
