using DevAlternatives.Models.Customer;
using DevAlternatives.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevAlternatives.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerService _customerService;
        ICompanyService _companyService;
        ICommonService _commonService;
        public CustomerController(ICustomerService userService, ICompanyService companyService, ICommonService commonService)
        {
            _customerService = userService;
            _companyService = companyService;
            _commonService = commonService;
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login login)
        {
            if (_customerService.ValidateUser(login))
            {
                return View("Dashboard");
            }
            else
            {
                return Content("Login Failed");
            }

        }

        [HttpGet]
        public ActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            CustomerDetails details = new CustomerDetails();
            details.Companies = _companyService.CompanyDropDownList();
            details.FisicalState = _commonService.GetAllStates();
            //details.FisicalCity = _commonService.GetAllCities();
            //details.PostalCity = _commonService.GetAllCities();
            details.FisicalCity = new Dictionary<int, string>();
            details.PostalCity = new Dictionary<int, string>();
            details.PostalState = _commonService.GetAllStates();
            return View(details);
        }

        [HttpPost]
        public ActionResult Register(CustomerDetails details)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _customerService.CreateCustomer(details);
                    return Content("Registration Succesful.");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Content("false Something Went Wrong in Registration");
        }

        public JsonResult CheckForValidCustomerName(string loginDetails_EmailOrPhone)
        {
            if (string.IsNullOrEmpty(loginDetails_EmailOrPhone))
            {
                loginDetails_EmailOrPhone = Request.QueryString[0];
            }
            if (!_customerService.CheckIfUserNameOrPhoneAvailable(loginDetails_EmailOrPhone))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            string errorMessage = loginDetails_EmailOrPhone + " is not available";
            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        public JsonResult CheckForValidCustomerPhone(string MobilePhone)
        {
            if (!_customerService.CheckIfUserNameOrPhoneAvailable(MobilePhone))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            string errorMessage = MobilePhone + " is not available";
            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetCities(string id)
        {
            var result = _commonService.GetCityByState(id);

            return Json(new SelectList(result, "Key", "Value"), JsonRequestBehavior.AllowGet);
        }
    }
}
