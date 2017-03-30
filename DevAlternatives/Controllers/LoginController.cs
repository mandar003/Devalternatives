using DevAlternatives.Models.User;
using DevAlternatives.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevAlternatives.Controllers
{
    public class LoginController : Controller
    {
        IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login login)
        {
            if(_userService.ValidateUser(login))
            {
                return Content("True");
            }
            else
            {
                return Content("False");
            }
            return View();
        }
    }
}