using DevAlternatives.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevAlternatives.Models.Employee;
using DevAlternatives.Repository.UnitOfWork;
using DevAlternatives.Data;
using System.Data.Entity.Validation;

namespace DevAlternatives.Service.Class
{
    public class EmployeeService : IEmployeeService
    {
        private IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool CheckIfEmailAlreadyTaken(string Email)
        {
            return _unitOfWork.EmployeeRepository.GetAll().Where(e => e.Email.ToLower() == Email.ToLower()).FirstOrDefault() != null;
        }

        public int CreateEmployee(EmployeeDetails details)
        {
            int employeeID = 0;
            try
            {
                Employee objEmployee = new Employee();
                objEmployee.CompanyID = details.CompanyID;
                objEmployee.IsActive = "Y";
                objEmployee.StartDate = DateTime.Now;
                objEmployee.Name = details.Name;
                objEmployee.FisicalAddress1 = details.FisicalAddress1;
                objEmployee.FisicalAddress2 = details.FisicalAddress2;
                objEmployee.FisicalCity = details.FisicalCitySelected;
                objEmployee.FisicalState = details.FisicalStateSelected;
                objEmployee.FisicalZip = details.FisicalZip;
                objEmployee.HomePhone = details.HomePhone;
                objEmployee.LastName = details.LastName;
                objEmployee.MiddleName = details.MiddleName;
                objEmployee.MobilePhone = details.MobilePhone;
                objEmployee.PostalAddress1 = details.PostalAddress1;
                objEmployee.PostalAddress2 = details.PostalAddress2;
                objEmployee.PostalCity = details.PostalCitySelected;
                objEmployee.PostalState = details.PostalStateSelected;
                objEmployee.PostalZip = details.PostalZip;
                objEmployee.WorkPhone = details.WorkPhone;
                objEmployee.Extension = details.Extension;
                objEmployee.Email = details.loginDetails.Email;
                //  objLogin.UserName = details.loginDetails.EmailOrPhone;
                objEmployee.Password = details.loginDetails.Password;
                _unitOfWork.EmployeeRepository.Insert(objEmployee);
                _unitOfWork.Save();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

            return employeeID;
        }

        public bool ValidateUser(EmployeeLogin login)
        {
            if (_unitOfWork.EmployeeRepository.GetAll().Where(e => e.Email == login.Email && e.Password == login.Password).FirstOrDefault() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
