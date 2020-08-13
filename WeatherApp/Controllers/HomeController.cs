using System.Web.Mvc;
using WeatherApp.Helpers.Classes;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private IApiHelper _iApiHelper;
        public HomeController(IApiHelper _iApiHelper)
        {
            this._iApiHelper = _iApiHelper;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetWeatherInfo(string cityName)
        {

            var modelForView = _iApiHelper.GetWeatherInfo(cityName);

            return View("Index", modelForView);
        }
    }
}