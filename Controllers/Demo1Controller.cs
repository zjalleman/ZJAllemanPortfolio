using Microsoft.AspNetCore.Mvc;

namespace ZJAllemanWeb.Controllers
{
    public class Demo1Controller : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
