using System.Web.Mvc;

namespace WeatherMonitor.Web.Controllers
{
    using System.Collections.Generic;
    using Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new List<WeatherModel>());
        }
    }
}
