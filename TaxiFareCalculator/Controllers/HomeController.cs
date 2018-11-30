
using System.Web.Mvc;
using TaxiFareCalculator.BusinessLogic.Abstractions;
using TaxiFareCalculator.BusinessLogic;
namespace TaxiFareCalculator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}