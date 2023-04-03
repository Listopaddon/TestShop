using AutoMapper;
using BusinessLogic.LogicBusiness.Place;
using BusinessLogic.LogicBusiness.Row;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Web.Models;

namespace Web.Controllers
{
    public class RowAndPlaceController : Controller
    {
        IRowLogic rowLogic;
        IPlaceLogic placeLogic;
        IMapper mapper;

        public RowAndPlaceController(IRowLogic rowLogic, IPlaceLogic placeLogic, IMapper mapper)
        {
            this.rowLogic = rowLogic;
            this.placeLogic = placeLogic;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("RowAndPlace/GetAllRowsAndPlaces/{idArea}")]
        public IActionResult GetAllRowsAndPlaces(long idArea)
        {
            HttpContext.Session.SetString("idAreaByRow", idArea.ToString());
            List<RowUI> rowUI = new List<RowUI>();
            List<RowModel> rows = rowLogic.GetAreaFromRow(idArea);
            string idSession = HttpContext.Session.GetString("idSession");
            long sessionId = Convert.ToInt64(idSession);

            for (int i = 0; i < rows.Count; i++)
            {
                List<PlaceModel> places = placeLogic.GetPlacesBySession(rows[i].Id, sessionId);
                List<PlaceUI> placesUi = mapper.Map<List<PlaceUI>>(places);

                rowUI.Add(new RowUI(rows[i].Id, rows[i].NumberRow, placesUi));
            }


            return View(rowUI);
        }

        [HttpGet]
        [Route("RowAndPlace/EditPlace/{idPlace}")]
        public IActionResult EditPlace(long idPlace)
        {
            HttpContext.Session.SetString("idPlace", idPlace.ToString());
            PlaceModel place = placeLogic.GetPlace(idPlace);
            PlaceUI placeUI = mapper.Map<PlaceUI>(place);
            return View(placeUI);
        }

        [HttpPost]
        [Route("RowAndPlace/EditPlace/{numberPlace}")]
        public IActionResult EditPlace(int numberPlace)
        {
            long idPlace = Convert.ToInt64(HttpContext.Session.GetString("idPlace"));
            PlaceModel modelPlace = placeLogic.GetPlace(idPlace);
            placeLogic.UpdatePlace(new PlaceModel(idPlace, modelPlace.IdRow, numberPlace));
            long idArea = Convert.ToInt64(HttpContext.Session.GetString("idAreaByRow"));

            return RedirectToAction("GetAllRowsAndPlaces", "RowAndPlace", new { idArea = idArea });
        }
    }
}
