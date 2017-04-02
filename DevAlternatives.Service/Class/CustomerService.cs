using DevAlternatives.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevAlternatives.Repository.UnitOfWork;
using DevAlternatives.Models.Customer;
using DevAlternatives.Data;
using System.Data.Entity.Validation;

namespace DevAlternatives.Service.Class
{
    public class CustomerService : ICustomerService
    {
        private IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool ValidateUser(Models.Customer.Login login)
        {

            if (CheckIsPhone(login.EmailOrPhone))
            {
                var customer = _unitOfWork.CustomerRepository.GetAll().Where(e => e.MobilePhone == login.EmailOrPhone).FirstOrDefault();
                if (customer != null)
                {
                    var loginDetails = _unitOfWork.LoginRepository.GetAll().Where(e => e.CustomerID == customer.CustomerID).Where(e => e.Password == login.Password).FirstOrDefault();
                    if (loginDetails != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                  
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (_unitOfWork.LoginRepository.GetAll().Where(e => e.UserName == login.EmailOrPhone && e.Password == login.Password).FirstOrDefault() != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

           
            
        }
        public CustomerDetails GetCustomerDetails(int CustomerID)
        {
            CustomerDetails customer = new CustomerDetails();

            if (CustomerID == 0)
            {

            }
            return customer;
        }
        public int CreateCustomer(CustomerDetails details)
        {
            int customerId = 0;
            try
            {
                Customer objCustomer = new Customer();
                objCustomer.CompanyID = details.CompanyID;
                objCustomer.CustomerActive = "Y";
                objCustomer.CustomerStartDate = DateTime.Now;
                objCustomer.FirstName = details.FirstName;
                objCustomer.FisicalAddress1 = details.FisicalAddress1;
                objCustomer.FisicalAddress2 = details.FisicalAddress2;
                objCustomer.FisicalCity = details.FisicalCitySelected;
                objCustomer.FisicalState = details.FisicalStateSelected;
                objCustomer.FisicalZip = details.FisicalZip;
                objCustomer.HomePhone = details.HomePhone;
                objCustomer.LastName = details.LastName;
                objCustomer.MiddleName = details.MiddleName;
                objCustomer.MobilePhone = details.MobilePhone;
                objCustomer.PostalAddress1 = details.PostalAddress1;
                objCustomer.PostalAddress2 = details.PostalAddress2;
                objCustomer.PostalCity = details.PostalCitySelected;
                objCustomer.PostalState = details.PostalStateSelected;
                objCustomer.PostalZip = details.PostalZip;
                objCustomer.WorkPhone = details.WorkPhone;
                _unitOfWork.CustomerRepository.Insert(objCustomer);
                _unitOfWork.Save(); //getting cutomer ID
                Data.Login objLogin = new Data.Login();
                objLogin.CompanyID = details.CompanyID;
                objLogin.CustomerID = details.CustomerID;
                objLogin.UserName = details.loginDetails.EmailOrPhone;
                objLogin.Password = details.loginDetails.Password;
                CreateUser(objLogin);
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

            return customerId;
        }     
        public bool CheckIfUserNameOrPhoneAvailable(string EmailORPhone)
        {
            if (CheckIsPhone(EmailORPhone))
            {
                return ValidateCustomerPhone(EmailORPhone);
            }
            else
            {
                return ValidateCustomerEmail(EmailORPhone);
               
            }
        }        
        public bool CheckIsPhone(string EmailORPhone)
        {
            if (EmailORPhone.IndexOf('@') > -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #region Private Methods
        private void CreateUser(Data.Login login)
        {
            _unitOfWork.LoginRepository.Insert(login);
        }
        private bool ValidateCustomerEmail(string UserEmail)
        {
            return _unitOfWork.LoginRepository.GetAll().Where(e => e.UserName.ToLower() == UserEmail.ToLower()).FirstOrDefault() != null;
        }
        private bool ValidateCustomerPhone(string UserEmail)
        {
            return _unitOfWork.CustomerRepository.GetAll().Where(e => e.MobilePhone.ToLower() == UserEmail.ToLower()).FirstOrDefault() != null;
        }
        #endregion
    }
}
