using DevAlternatives.Models.Employee;
using DevAlternatives.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevAlternatives.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeService _employeeService;
        ICompanyService _companyService;
        ICommonService _commonService;
        public EmployeeController(IEmployeeService userService, ICompanyService companyService, ICommonService commonService)
        {
            _employeeService = userService;
            _companyService = companyService;
            _commonService = commonService;
        }
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(EmployeeLogin login)
        {
            if (_employeeService.ValidateUser(login))
            {
                return View("Dashboard");
            }
            else
            {
                return Content("False");
            }

        }


        [HttpGet]
        public ActionResult Register()
        {
            EmployeeDetails details = new EmployeeDetails();
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
        public ActionResult Register(EmployeeDetails details)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeService.CreateEmployee(details);
                    return Content("Registration Succesful.");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Content("false Something Went Wrong in Registration");
        }

        public JsonResult CheckForValidEmployeeEmail(string loginDetails_Email)
        {
            if (string.IsNullOrEmpty(loginDetails_Email))
            {
                loginDetails_Email = Request.QueryString[0];
            }
            if (!_employeeService.CheckIfEmailAlreadyTaken(loginDetails_Email))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            string errorMessage = loginDetails_Email + " is not available";
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