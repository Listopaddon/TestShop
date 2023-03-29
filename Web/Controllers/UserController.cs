using AutoMapper;
using BusinessLogic.LogicBusiness.User;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        IUserLogic userLogic;

        public UserController(IUserLogic userLogic)
        {
            this.userLogic = userLogic;
        }

        [HttpPost]
        public IActionResult LogIn(string login, string password)
        {
            UserModel user = userLogic.LogIn(login, password);
            if (user == null)
            {
                return RedirectToAction("UserWasNotFound", "User");
            }
            SetUserSession(user.ID.ToString(), user.Login);

            return Redirect(HttpContext.Session.GetString("redirectURL"));
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            HttpContext.Request.Headers.TryGetValue("Referer", out var headerValue);
            HttpContext.Session.SetString("redirectURL", headerValue[0]);
            return View();
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(string login, string password)
        {
            if (!userLogic.IsValidLogin(login))
            {
                return RedirectToAction("UserWasNotFound", "User");
            }
            userLogic.Registration(login, password);



            return Redirect(HttpContext.Session.GetString("redirectURL"));
        }

        public IActionResult UserWasNotFound()
        {
            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        private void SetUserSession(string id, string login)
        {
            HttpContext.Session.SetString("idUser", id);
            HttpContext.Session.SetString("loginUser", login);
        }
    }
}
