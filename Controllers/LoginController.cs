using Microsoft.AspNetCore.Mvc;
using ZJAllemanWeb.Models;
using ZJAllemanWeb.Services;

namespace ZJAllemanWeb.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            ViewBag.isFailedLogin = false;
            ViewBag.isFailedCreation = false;
            return View();
        }

        public IActionResult CreateAccount()
        {
            return View();
        }

        public IActionResult SaveAccount(UserModel userModel)
        {
            LoginService loginService = new LoginService();
            UserModel newUser = loginService.CreateAccount(userModel);

            if (loginService.IsValid(newUser))
            {
                return View("CreateSuccess", newUser);
            }

            ViewBag.isFailedCreation = true;
            return View("Login");
        }

        public IActionResult ProcessLogin(UserModel userModel)
        {
            LoginService loginService = new LoginService();

            if (loginService.IsValid(userModel))
            {
                return View("LoginSuccess", userModel);
            }

            ViewBag.isFailedLogin = true;
            return View("Login");
        }
    }
}
