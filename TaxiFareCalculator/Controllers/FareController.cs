using System;
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
            #region Exception Handling
            catch (ArgumentException ex)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message.ToString());
            }
            catch (NullReferenceException ex)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message.ToString());
            }
            catch (OverflowException ex)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message.ToString());
            }
            catch (Exception)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Unknown error processing your fare");
            }
            #endregion
        }
    }
}