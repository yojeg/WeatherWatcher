using System.Web.Mvc;

namespace WeatherMonitor.Web.Controllers
{
    using AutoMapper;
    using DataAccessLayer;
    using Models;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly WeatherMonitorDbContext _context;

        public HomeController(WeatherMonitorDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var weathers = _context.Weathers.ToList();
            var model = weathers.Select(Mapper.DynamicMap<WeatherModel>);

            return View(model);
        }
    }
}
