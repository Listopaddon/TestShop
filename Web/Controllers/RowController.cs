using AutoMapper;
using BusinessLogic.LogicBusiness.Place;
using BusinessLogic.LogicBusiness.Row;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading;
using Web.Models;

namespace Web.Controllers
{
    public class RowController : Controller
    {
        IRowLogic rowLogic;
        IPlaceLogic placeLogic;
        IMapper mapper;

        public RowController(IRowLogic rowLogic, IPlaceLogic placeLogic, IMapper mapper)
        {
            this.rowLogic = rowLogic;
            this.placeLogic = placeLogic;
            this.mapper = mapper;
        }

        [Route("Row/GetAllRowsAndPlaces/{idArea}")]
        public IActionResult GetAllRowsAndPlaces(long idArea)
        {
            List<RowUI> rowUI = new List<RowUI>();
            List<RowModel> rows = rowLogic.GetAreaFromRow(idArea);
            string idSession = HttpContext.Session.GetString("idSession");
            long sessionId = Convert.ToInt64(idSession);

            for (int i = 0; i < rows.Count; i++)
            {
                List<PlaceModel> places = placeLogic.GetPlacesBySession(rows[i].Id, sessionId);
                List<PlaceUI> placesUi = mapper.Map<List<PlaceUI>>(places);

                rowUI.Add(new RowUI(rows[i].NumberRow, placesUi));
            }


            return View(rowUI);
        }
    }
}
