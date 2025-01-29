using Microsoft.AspNetCore.Mvc;

namespace ZJAllemanWeb.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Weather()
        {
            return View();
        }
    }
}
