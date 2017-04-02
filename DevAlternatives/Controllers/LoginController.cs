using DevAlternatives.Models.Customer;
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
        ICustomerService _customerervice;
        ICompanyService _companyService;
        public LoginController(ICustomerService userService, ICompanyService companyService)
        {
            _customerervice = userService;
            _companyService = companyService;
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login login)
        {
            if(_customerervice.ValidateUser(login))
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