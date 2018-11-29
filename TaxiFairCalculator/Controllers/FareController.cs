using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaxiFareCalculator.Models;
using TaxiFareCalculator.BusinessLogic;
using TaxiFareCalculator.BusinessLogic.Abstractions;
using System.Web.Mvc;
using System.Net;

namespace TaxiFareCalculator.Controllers
{
    public class FareController : Controller
    {
        [HttpPost()]
        public ActionResult CalculateFare(TaxiRide fare) {
            try
            {
                IFareCalculator calculator = new FareCalculator();
                return Json(calculator.CalculateFare(fare));
            }
            catch (ArgumentException ex)
            {
                return Json(ex.Message);
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message);
            }
        }
    }
}